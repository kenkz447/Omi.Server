using Omi.Data;
using Omi.Modules.FileAndMedia.Base;
using Omi.Modules.HomeBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Omi.Modules.HomeBuilder.Utilities;
using Omi.Modules.FileAndMedia.Base.Entity;
using Omi.Modules.HomeBuilder.ViewModels;

namespace Omi.Modules.HomeBuilder.ServiceModel
{
    public class ProjectServiceModel : 
        IServiceModelWithFiles<Project, ProjectFile>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long AvatarFileId { get; set; }

        public long CityId { get; set; }

        public ProjectDetail Detail { get; set; }

        public ApplicationUser User { get; set; }

        public IEnumerable<long> TaxonomyIds { get; set; }

        public Project ToEntity()
        {
            var newProject = new Project
            {
                Id = Id,
                Name = Name,
                CreateByUserId = User.Id,
                ProjectDetails = new List<ProjectDetail>() {
                    Detail
                },
                EnitityFiles = GetEntityFiles(),
                EntityTaxonomies = new List<ProjectTaxonomy>(
                    TaxonomyIds.Select(taxonomyId => new ProjectTaxonomy { TaxonomyId = taxonomyId, ProjectId = Id }))
            };
            return newProject;
        }

        public IEnumerable<ProjectFile> GetEntityFiles()
        {
            var ProjectFiles = new List<ProjectFile>()
                {
                    new ProjectFile
                    {
                        UsingType = (int)FileUsingType.Avatar,
                        FileEntityId = AvatarFileId,
                        EntityId = Id,
                    },
                };

            return ProjectFiles;
        }

        public static ProjectServiceModel FromViewModel(ProjectViewModel viewModel)
        {
            return new ProjectServiceModel
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Detail = new ProjectDetail
                {
                    Title = viewModel.Title,
                    Language = viewModel.Language,
                    Area = viewModel.Area,
                    Investor = viewModel.Invertor,
                    StartedYear = viewModel.StartedYear,
                    TotalApartment = viewModel.TotalApartment,
                    Website = viewModel.Website,
                    Street = viewModel.Street
                },
                AvatarFileId = viewModel.Avatar.FileId,
                TaxonomyIds = new List<long>
                {
                    viewModel.ProjectTypeId
                },
                CityId = viewModel.CityId,
            };
        }
    }
}
