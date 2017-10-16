using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Omi.Base;
using Omi.Data;
using Omi.Extensions;
using Omi.Modules.HomeBuilder.ServiceModel;
using Omi.Modules.HomeBuilder.Services;
using Omi.Modules.HomeBuilder.ViewModels;
using Omi.Modules.ModuleBase;
using System.Collections.Generic;
using System.Linq;
using System;

using static Omi.Modules.HomeBuilder.Utilities.ViewModelUtilities;
using System.Threading.Tasks;
using Omi.Modules.FileAndMedia.Base;
using Omi.Modules.FileAndMedia.ViewModel;
using Omi.Modules.HomeBuilder.DbSeed;
using Omi.Modules.HomeBuilder.Entities;
using Omi.Base.ViewModel;
using Omi.Modules.ModuleBase.ViewModels;

namespace Omi.Modules.HomeBuilder.Controllers
{
    public class PackageController : BaseController
    {
        public readonly PackageService _packageService;

        public PackageController(
            PackageService packageService,
            ILogger<PackageController> logger, 
            UserManager<ApplicationUser> userManager) 
            : base(logger, userManager)
        {
            _packageService = packageService;
        }

        private PackageViewModel EmptyPackageViewModel
        {
            get
            {
                var designThemes = _packageService.GetAllDesignThemes();
                var packageIncludeItems = _packageService.GetAllPackageIncludedItems();
                var houseStyle = _packageService.GetAllHouseStyles();

                var result = new PackageViewModel
                {
                    AvaliableDesignThemes = designThemes.Select(o => TaxomonyViewModel.FromEntity(o)),
                    AvaliablePackageIncludedItems = packageIncludeItems.Select(o => TaxomonyViewModel.FromEntity(o)),
                    AvaliableHouseStyles = houseStyle.Select(o => TaxomonyViewModel.FromEntity(o)),
                };

                return result;
            }
        }

        public BaseJsonResult GetEmptyPackageViewModel()         
            => new BaseJsonResult(Base.Properties.Resources.POST_SUCCEEDED, EmptyPackageViewModel);

        public async Task<BaseJsonResult> GetPackageViewModel(long packageId)
        {
            var package = await _packageService.GetPackageById(packageId);
            var viewModel = ToPackageViewModel(package);
            return new BaseJsonResult(Omi.Base.Properties.Resources.POST_SUCCEEDED, viewModel);
        }

        [AllowAnonymous]
        public async Task<BaseJsonResult> GetPackage(long packageName)
        {
            var package = await _packageService.GetPackageById(packageName);
            var viewModel = ToPackageViewModel(package);
            return new BaseJsonResult(Omi.Base.Properties.Resources.POST_SUCCEEDED, viewModel);
        }

        [AllowAnonymous]
        public BaseJsonResult GetDesignThemes()
        {
            var designTheme = _packageService.GetAllDesignThemes();
            var result = designTheme.Select(o => TaxomonyViewModel.FromEntity(o));

            return new BaseJsonResult(Omi.Base.Properties.Resources.POST_SUCCEEDED, result);
        }

        [AllowAnonymous]
        public BaseJsonResult GetHouseStyles()
        {
            var designTheme = _packageService.GetAllHouseStyles();
            var result = designTheme.Select(o => TaxomonyViewModel.FromEntity(o));

            return new BaseJsonResult(Omi.Base.Properties.Resources.POST_SUCCEEDED, result);
        }

        [AllowAnonymous]
        public async Task<BaseJsonResult> GetPackages(PackageFilterViewModel viewModel)
        {
            var serviceModel = viewModel.ToServiceModel();
            var entities = await _packageService.GetPackages(serviceModel);

            var viewModels = new PageEntityViewModel<Package, PackageViewModel>(entities, o => ToPackageViewModel(o));

            return new BaseJsonResult(Omi.Base.Properties.Resources.POST_SUCCEEDED, viewModels);
        }

        [HttpPost]
        public async Task<BaseJsonResult> CreateNewPackage([FromBody]PackageUpdateViewModel viewModel)
        {
            var packageServiceModel = viewModel.ToPackageServiceModel();
            packageServiceModel.User = CurrentUser;

            var newPackage = await _packageService.CreateNewPackage(packageServiceModel);

            return new BaseJsonResult(Omi.Base.Properties.Resources.POST_SUCCEEDED, newPackage.Id);
        }

        [HttpPost]
        public async Task<BaseJsonResult> UpdatePackage([FromBody]PackageUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return new ModelStateErrorJsonResult(ModelState.Values);

            var packageServiceModel = model.ToPackageServiceModel();
            packageServiceModel.User = CurrentUser;

            await _packageService.UpdatePackageAsync(packageServiceModel);

            return new BaseJsonResult(Omi.Base.Properties.Resources.POST_SUCCEEDED, model.Id);
        }

        private PackageViewModel ToPackageViewModel(Package package)
        {
            var packageViewModel = EmptyPackageViewModel;

            packageViewModel.Id = package.Id;

            var detail = package.PackageDetails.FirstOrDefault();
            packageViewModel.Price = detail.Price;
            packageViewModel.Area = detail.Area;
            packageViewModel.Title = detail.Title;
            packageViewModel.SortText = detail.SortText;

            var avatarFile = package.EnitityFiles.FirstOrDefault(o => o.UsingType == (int)FileUsingType.Avatar);
            packageViewModel.Avatar = FileEntityInfo.FromEntity(avatarFile.FileEntity);

            var pictureFiles = package.EnitityFiles.Where(o => o.UsingType == (int)FileUsingType.Picture);
            packageViewModel.Pictures = pictureFiles.Select(o => FileEntityInfo.FromEntity(o.FileEntity));

            var houseType = package.EntityTaxonomies.FirstOrDefault(o => o.Taxonomy.TaxonomyTypeId == HouseStyleSeed.HouseStyle.Id);
            packageViewModel.HouseTypeId = houseType.TaxonomyId;
            packageViewModel.HouseTypeLabel = houseType.Taxonomy.TaxonomyDetails.FirstOrDefault(o => o.Language == Omi.Base.Properties.Resources.DEFAULT_LANGUAGE).Label;

            var designTheme = package.EntityTaxonomies.FirstOrDefault(o => o.Taxonomy.TaxonomyTypeId == DesignThemeSeed.DesignTheme.Id);
            packageViewModel.DesignThemeId = designTheme.TaxonomyId;
            packageViewModel.DesignThemeLabel = designTheme.Taxonomy.TaxonomyDetails.FirstOrDefault(o => o.Language == Omi.Base.Properties.Resources.DEFAULT_LANGUAGE).Label;

            var includedItems = package.EntityTaxonomies.Where(o => o.Taxonomy.TaxonomyTypeId == PackageIncludedSeed.PackageIncludedItem.Id);
            packageViewModel.PackageIncludedItemIds = includedItems.Select(o => o.TaxonomyId);
            packageViewModel.PackageIncludedItems = includedItems.Select(o => TaxomonyViewModel.FromEntity(o.Taxonomy));

            return packageViewModel;
        }
    }
}
