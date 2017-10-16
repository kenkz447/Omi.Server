using Microsoft.EntityFrameworkCore;
using Omi.Base.Collection;
using Omi.Modules.HomeBuilder.DbSeed;
using Omi.Modules.HomeBuilder.Entities;
using Omi.Modules.HomeBuilder.ServiceModel;
using Omi.Modules.ModuleBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Omi.Modules.HomeBuilder.Utilities;
using Omi.Modules.Location.Services;
using Omi.Modules.Location.Entities;
using Omi.Extensions;

namespace Omi.Modules.HomeBuilder.Services
{
    public class ProjectService
    {
        private readonly HomeBuilderDbContext _context;
        private readonly LocationService _locationService;
        public ProjectService(
            HomeBuilderDbContext context,
            LocationService locationService)
        {
            _context = context;
            _locationService = locationService;
        }

        public IEnumerable<Taxonomy> GetAllProjectTypes()
            => _context.Taxonomy.Include(o => o.TaxonomyDetails).Where(o => o.TaxonomyTypeId == ProjectTypeSeed.ProjectType.Id).AsNoTracking();

        public IEnumerable<GeographicaLocation> getAllGeographicaLocations()
            => _locationService.GetGeographicaLocations();

        private IQueryable<Project> GetProjects()
            => _context.Project
            .Include(o => o.ProjectDetails)
            .Include(o => o.EnitityFiles)
            .ThenInclude(o => o.FileEntity)
            .Include(o => o.EntityTaxonomies)
            .ThenInclude(o => o.Taxonomy)
            .ThenInclude(o => o.TaxonomyDetails)
            .Include(o => o.City)
            .AsNoTracking()
            .AsQueryable();

        public async Task<PaginatedList<Project>> GetProjects(ProjectFilterServiceModel serviceModel)
        {
            var Projects = GetProjects();

            foreach (var taxonomyId in serviceModel.TaxonomyIds)
                if (taxonomyId != default(long))
                    Projects = Projects.Where(o => o.EntityTaxonomies.Select(e => e.TaxonomyId).Contains(taxonomyId));

            Projects = Projects.OrderByDescending(o => o.Id);

            var result = await PaginatedList<Project>.CreateAsync(Projects, serviceModel.Page, serviceModel.PageSize);

            return result;
        }

        public async Task<Project> GetProjectById(long projectId)
            => await GetProjects().SingleAsync(o => o.Id == projectId);

        public async Task<Project> GetProjectByName(string projectName)
            => await GetProjects().SingleAsync(o => o.Name == projectName);

        public async Task<Project> CreateNewProject(ProjectServiceModel serviceModel)
        {
            var newProject = new Project
            {
                Name = serviceModel.Name,
                CreateByUserId = serviceModel.User.Id,
                ProjectDetails = new List<ProjectDetail>() {
                    serviceModel.Detail
                },
                EnitityFiles = serviceModel.GetEntityFiles(),
                EntityTaxonomies = new List<ProjectTaxonomy>(
                    serviceModel.TaxonomyIds.Select(taxonomyId => new ProjectTaxonomy { TaxonomyId = taxonomyId })),
                CityId = serviceModel.CityId
            };

            var add = await _context.Project.AddAsync(newProject);

            _context.SaveChanges();

            return add.Entity;
        }

        public async Task<Project> UpdateProjectAsync(ProjectServiceModel serviceModel)
        {
            var project = await GetProjectById(serviceModel.Id);
            var newProject = serviceModel.ToEntity();

            _context.Entry(project).CurrentValues.SetValues(newProject);
            _context.Entry(project).Property(o => o.CreateByUserId).IsModified = false;
            _context.Entry(project).Property(o => o.CreateDate).IsModified = false;

            project.CityId = newProject.CityId;

            foreach (var newDetail in newProject.ProjectDetails)
            {
                var oldDetail = project.ProjectDetails.FirstOrDefault(o => o.Language == newDetail.Language);
                if (oldDetail.Language == newDetail.Language)
                {
                    newDetail.Id = oldDetail.Id;
                    _context.Entry(oldDetail).CurrentValues.SetValues(newDetail);
                }
            }

            _context.TryUpdateManyToMany(project.EnitityFiles, newProject.EnitityFiles, o => o.FileEntityId);
            _context.TryUpdateManyToMany(project.EntityTaxonomies, newProject.EntityTaxonomies, o => o.TaxonomyId);

            await _context.SaveChangesAsync();

            return newProject;
        }
    }
}
