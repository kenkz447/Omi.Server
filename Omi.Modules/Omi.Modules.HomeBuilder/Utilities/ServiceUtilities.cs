using Omi.Modules.FileAndMedia.Base;
using Omi.Modules.HomeBuilder.Entities;
using Omi.Modules.HomeBuilder.ServiceModel;
using System.Collections.Generic;
using System.Linq;

namespace Omi.Modules.HomeBuilder.Utilities
{
    public static class ServiceUtilities
    {
        public static IList<PackageFile> GetPackageFiles(PackageServiceModel serviceModel)
        {
            var packageFiles = new List<PackageFile>()
                {
                    new PackageFile
                    {
                        UsingType = (int)FileUsingType.Avatar,
                        FileEntityId = serviceModel.AvatarFileId,
                        PackageId = serviceModel.Id,
                    },
                };

            packageFiles.AddRange(serviceModel.PictureFileIds.Select(o => new PackageFile
            {
                UsingType = (int)FileUsingType.Picture,
                FileEntityId = o,
                PackageId = serviceModel.Id,
            }));

            return packageFiles;
        }
    }
}