using Omi.Data;
using Omi.Modules.FileAndMedia.Base;
using Omi.Modules.HomeBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Omi.Modules.HomeBuilder.Utilities;

namespace Omi.Modules.HomeBuilder.ServiceModel
{
    public class PackageServiceModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public PackageDetail Detail { get; set; }

        public IEnumerable<long> TaxonomyIds { get; set; }

        public long AvatarFileId { get; set; }
        public IEnumerable<long> PictureFileIds { get; set; }

        public ApplicationUser User { get; set; }

        public Package CreatePackageFromServiceModel()
        {
            var newPackage = new Package
            {
                Id = Id,
                Name = Name,
                CreateByUserId = User.Id,
                PackageDetails = new List<PackageDetail>() {
                    Detail
                },
                PackageFiles = ServiceUtilities.GetPackageFiles(this),
                EntityTaxonomies = new List<PackageTaxonomy>(
                    TaxonomyIds.Select(taxonomyId => new PackageTaxonomy { TaxonomyId = taxonomyId, PackageId = Id }))
            };
            return newPackage;
        }
    }
}
