using Omi.Modules.FileAndMedia.ViewModel;
using Omi.Modules.HomeBuilder.Entities;
using Omi.Modules.ModuleBase.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Omi.Modules.HomeBuilder.ViewModels
{
    public class PackageUpdateViewModel2
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string SortText { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Area { get; set; }

        [Required]
        public long HouseTypeId { get; set; }

        [Required]
        public long DesignThemeId { get; set; }

        public string Language { get; set; } = Omi.Base.Properties.Resources.DEFAULT_LANGUAGE;

        public FileEntityInfo Avatar { get; set; }
        public IEnumerable<FileEntityInfo> Pictures { get; set; }
        public IEnumerable<long> PackageIncludedItemIds { get; set; }

        public IEnumerable<TaxomonyViewModel> ValiablePackageIncludedItems { get; set; }
        public IEnumerable<TaxomonyViewModel> ValiableDesignThemes { get; set; }
        public IEnumerable<TaxomonyViewModel> ValiableHouseStyles { get; set; }

    }

public class PackageViewModel
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string SortText { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Area { get; set; }

        [Required]
        public long HouseTypeId { get; set; }
        public string HouseTypeLabel { get; set; }

        [Required]
        public long DesignThemeId { get; set; }
        public string DesignThemeLabel { get; set; }

        public string Language { get; set; } = Omi.Base.Properties.Resources.DEFAULT_LANGUAGE;

        public FileEntityInfo Avatar { get; set; }
        public IEnumerable<FileEntityInfo> Pictures { get; set; }
        public IEnumerable<long> PackageIncludedItemIds { get; set; }
        public IEnumerable<TaxomonyViewModel> PackageIncludedItems { get; set; }

        public IEnumerable<TaxomonyViewModel> ValiablePackageIncludedItems { get; set; }
        public IEnumerable<TaxomonyViewModel> ValiableDesignThemes { get; set; }
        public IEnumerable<TaxomonyViewModel> ValiableHouseStyles { get; set; }

    }
}
