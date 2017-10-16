using Omi.Modules.FileAndMedia.Base;
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
        public long CityId { get; set; }

        [Required]
        public long ProjectTypeId { get; set; }

        [Required]
        public FileEntityInfo Avatar { get; set; }

    }

    public class ProjectViewModelExtended : ProjectViewModel
    {
        public GeographicaLocationViewModel City { get; set; }

        public TaxomonyViewModel ProjectType { get; set; }

        public IEnumerable<TaxomonyViewModel> AvaliableProjectTypes { get; set; }
        public IEnumerable<GeographicaLocationViewModel> AvaliableGeographicaLocations { get; set; }

        public static ProjectViewModelExtended FromEntity(Project entity)
        {
            var entityDetail = entity.ProjectDetails.FirstOrDefault();
            var avatarFile = entity.EnitityFiles.FirstOrDefault(o => o.UsingType == (int)FileUsingType.Avatar).FileEntity;
            var projectType = entity.EntityTaxonomies.FirstOrDefault(o => o.Taxonomy.TaxonomyTypeId == ProjectTypeSeed.ProjectType.Id);

            return new ProjectViewModelExtended()
            {
                Id = entity.Id,
                Name = entity.Name,
                Title = entityDetail.Title,
                Area = entityDetail.Area,
                Language = entityDetail.Language,
                Street = entityDetail.Street,
                StartedYear = entityDetail.StartedYear,
                TotalApartment = entityDetail.TotalApartment,
                Website = entityDetail.Website,
                Invertor = entityDetail.Investor,
                CityId = entity.CityId,
                Avatar = FileEntityInfo.FromEntity(avatarFile),
                ProjectTypeId = projectType.ProjectId
            };
        }
    }
}
