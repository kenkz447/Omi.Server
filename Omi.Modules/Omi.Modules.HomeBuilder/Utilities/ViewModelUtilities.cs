﻿using Omi.Extensions;
using Omi.Modules.HomeBuilder.Entities;
using Omi.Modules.HomeBuilder.ServiceModel;
using Omi.Modules.HomeBuilder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Omi.Modules.HomeBuilder.Utilities
{
    public static class ViewModelUtilities
    {
        public static PackageDetail GetPackageDetail(this PackageUpdateViewModel viewModel)
            => new PackageDetail
            {
                PackageId = viewModel.Id,
                Area = viewModel.Area,
                Price = viewModel.Price,
                SortText = viewModel.SortText,
                Title = viewModel.Title,
                Language = Base.Properties.Resources.DEFAULT_LANGUAGE
            };

        public static PackageServiceModel ToPackageServiceModel(this PackageUpdateViewModel viewModel)
        {
            var taxonomyIds = new List<long>(viewModel.PackageIncludedItemIds)
                    {
                        viewModel.HouseTypeId, viewModel.DesignThemeId,
                    };

            var pictureFileIds = new List<long>(viewModel.Pictures.Select(o => o.FileId));
            var detail = viewModel.GetPackageDetail();

            var addNewpackageServiceModel = new PackageServiceModel()
            {
                Id = viewModel.Id,
                Name = viewModel.Title.ToEntityName(),
                Detail = detail,
                TaxonomyIds = taxonomyIds,
                AvatarFileId = viewModel.Avatar.FileId,
                PictureFileIds = pictureFileIds
            };

            return addNewpackageServiceModel;
        }
    }
}
