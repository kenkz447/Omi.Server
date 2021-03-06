﻿using Omi.Modules.FileAndMedia.Base;
using Omi.Modules.FileAndMedia.ViewModel;
using Omi.Modules.HomeBuilder.DbSeed;
using Omi.Modules.HomeBuilder.Entities;
using Omi.Modules.Location.ViewModel;
using Omi.Modules.ModuleBase.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Omi.Modules.HomeBuilder.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
            Language = Omi.Base.Properties.Resources.DEFAULT_LANGUAGE;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Title { get; set; }

        public string Invertor { get; set; }

        public string Street { get; set; }

        public string Website { get; set; }

        public string Language { get; set; }

        [Required]
        public int TotalApartment { get; set; }

        [Required]
        public int Area { get; set; }

        [Required]
        public int StartedYear { get; set; }

        [Required]
        public int? CityId { get; set; }

        [Required]
        public long ProjectTypeId { get; set; }

        [Required]
        public long ProjectStatusId { get; set; }

        [Required]
        public FileEntityInfo Avatar { get; set; }

        public string MapLatitude { get; set; }
        public string MapLongitude { get; set; }

        public IEnumerable<ProjectBlockViewModel> ProjectBlocks { get; set; }
    }

    public class ProjectViewModelExtended : ProjectViewModel
    {
        public GeographicaLocationViewModel City { get; set; }

        public TaxomonyViewModel ProjectType { get; set; }

        public IEnumerable<TaxomonyViewModel> AvaliableProjectTypes { get; set; }
        public IEnumerable<TaxomonyViewModel> AvaliableProjectStatus { get; set; }

        public IEnumerable<GeographicaLocationViewModel> AvaliableGeographicaLocations { get; set; }

        public static ProjectViewModelExtended FromEntity(Project entity, ProjectViewModelExtended baseViewModel = null)
        {
            var entityDetail = entity.ProjectDetails.FirstOrDefault();
            var avatarFile = entity.EnitityFiles.FirstOrDefault(o => o.UsingType == (int)FileUsingType.Avatar).FileEntity;
            var projectType = entity.EntityTaxonomies.FirstOrDefault(o => o.Taxonomy.TaxonomyTypeId == ProjectTypeSeed.ProjectType.Id);
            var projectStatus = entity.EntityTaxonomies.FirstOrDefault(o => o.Taxonomy.TaxonomyTypeId == ProjectStatusSeed.ProjectStatus.Id);

            var resultViewModel = baseViewModel ?? new ProjectViewModelExtended();

            resultViewModel.Id = entity.Id;
            resultViewModel.Name = entity.Name;

            resultViewModel.Title = entityDetail.Title;
            resultViewModel.Area = entityDetail.Area;
            resultViewModel.Language = entityDetail.Language;
            resultViewModel.Street = entityDetail.Street;
            resultViewModel.StartedYear = entityDetail.StartedYear;
            resultViewModel.TotalApartment = entityDetail.TotalApartment;
            resultViewModel.Website = entityDetail.Website;
            resultViewModel.Invertor = entityDetail.Investor;
            resultViewModel.MapLatitude = entityDetail.MapLatitude;
            resultViewModel.MapLongitude = entityDetail.MapLongitude;

            resultViewModel.CityId = entity.CityId;
            resultViewModel.ProjectTypeId = projectType.TaxonomyId;
            resultViewModel.ProjectType = TaxomonyViewModel.FromEntity(projectType.Taxonomy);

            if (projectStatus != null)
            {
                resultViewModel.ProjectStatusId = projectStatus.TaxonomyId;
                resultViewModel.ProjectType = TaxomonyViewModel.FromEntity(projectStatus.Taxonomy);
            }

            resultViewModel.ProjectBlocks = entity.ProjectBlocks.Select(o => ProjectBlockViewModelExtension.FromEnitity(o));

            resultViewModel.Avatar = FileEntityInfo.FromEntity(avatarFile);

            return resultViewModel;
        }
    }
}
