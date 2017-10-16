using Microsoft.EntityFrameworkCore;
using Omi.Base.Collection;
using Omi.Extensions;
using Omi.Modules.FileAndMedia.Base;
using Omi.Modules.FileAndMedia.Entities;
using Omi.Modules.HomeBuilder.DbSeed;
using Omi.Modules.HomeBuilder.Entities;
using Omi.Modules.HomeBuilder.ServiceModel;
using Omi.Modules.ModuleBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Omi.Modules.HomeBuilder.Utilities.ServiceUtilities;

namespace Omi.Modules.HomeBuilder.Services
{
    public class PackageService
    {
        private readonly HomeBuilderDbContext _context;
        public PackageService(HomeBuilderDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Taxonomy> GetAllDesignThemes()
            => _context.Taxonomy.Include(o => o.TaxonomyDetails).Where(o => o.TaxonomyTypeId == DesignThemeSeed.DesignTheme.Id).AsNoTracking();

        public IEnumerable<Taxonomy> GetAllPackageIncludedItems()
            => _context.Taxonomy.Include(o => o.TaxonomyDetails).Where(o => o.TaxonomyTypeId == PackageIncludedSeed.PackageIncludedItem.Id).AsNoTracking();

        public IEnumerable<Taxonomy> GetAllHouseStyles()
            => _context.Taxonomy.Include(o => o.TaxonomyDetails).Where(o => o.TaxonomyTypeId == HouseStyleSeed.HouseStyle.Id).AsNoTracking();

        private IQueryable<Package> GetPackages()
            => _context.Package
            .Include(o => o.PackageDetails)
            .Include(o => o.EnitityFiles)
            .ThenInclude(o => o.FileEntity)
            .Include(o => o.EntityTaxonomies)
            .ThenInclude(o => o.Taxonomy)
            .ThenInclude(o => o.TaxonomyDetails)
            .AsNoTracking()
            .AsQueryable();

        public async Task<PaginatedList<Package>> GetPackages(PackageFilterServiceModel serviceModel)
        {
            var packages = GetPackages();

            foreach (var taxonomyId in serviceModel.TaxonomyIds)
                if(taxonomyId != default(long))
                    packages = packages.Where(o => o.EntityTaxonomies.Select(e => e.TaxonomyId).Contains(taxonomyId));

            if (serviceModel.BudgetMin != default(int))
                packages = packages.Where(o => o.PackageDetails.FirstOrDefault(e => e.Language == Omi.Base.Properties.Resources.DEFAULT_LANGUAGE).Price >= serviceModel.BudgetMin);

            if (serviceModel.BudgetMax != default(int))
                packages = packages.Where(o => o.PackageDetails.FirstOrDefault(e => e.Language == Omi.Base.Properties.Resources.DEFAULT_LANGUAGE).Price <= serviceModel.BudgetMax);

            packages = packages.OrderByDescending(o => o.Id);

            var result = await PaginatedList<Package>.CreateAsync(packages, serviceModel.Page, serviceModel.PageSize);

            return result;
        }

        public async Task<Package> GetPackageById(long packageId)
            => await GetPackages().SingleAsync(o => o.Id == packageId);

        public async Task<Package> GetPackageByName(string packageName)
            => await GetPackages().SingleAsync(o => o.Name == packageName);

        public async Task<Package> CreateNewPackage(PackageServiceModel serviceModel)
        {
            var newPackage = new Package
            {
                Name = serviceModel.Name,
                CreateByUserId = serviceModel.User.Id,
                PackageDetails = new List<PackageDetail>() {
                    serviceModel.Detail
                },
                EnitityFiles = serviceModel.GetEntityFiles(),
                EntityTaxonomies = new List<PackageTaxonomy>(
                    serviceModel.TaxonomyIds.Select(taxonomyId => new PackageTaxonomy { TaxonomyId = taxonomyId }))
            };

            var add = await _context.Package.AddAsync(newPackage);

            _context.SaveChanges();

            return add.Entity;
        }

        public async Task<Package> UpdatePackageAsync(PackageServiceModel serviceModel)
        {
            var package = await GetPackageById(serviceModel.Id);
            var newPackage = serviceModel.ToEntity();

            _context.Entry(package).CurrentValues.SetValues(newPackage);
            _context.Entry(package).Property(o => o.CreateByUserId).IsModified = false;
            _context.Entry(package).Property(o => o.CreateDate).IsModified = false;

            foreach (var newDetail in newPackage.PackageDetails)
            {
                var oldDetail = package.PackageDetails.FirstOrDefault(o => o.Language == newDetail.Language);
                if (oldDetail.Language == newDetail.Language)
                {
                    newDetail.Id = oldDetail.Id;
                    _context.Entry(oldDetail).CurrentValues.SetValues(newDetail);
                }
            }

            _context.TryUpdateManyToMany(package.EnitityFiles, newPackage.EnitityFiles, o => o.FileEntityId);
            _context.TryUpdateManyToMany(package.EntityTaxonomies, newPackage.EntityTaxonomies, o => o.TaxonomyId);

            await _context.SaveChangesAsync();

            return newPackage;
        }
    }
}