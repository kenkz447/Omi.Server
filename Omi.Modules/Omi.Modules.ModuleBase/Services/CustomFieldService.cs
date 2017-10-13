using Omi.Modules.ModuleBase.Entities;
using Omi.Modules.ModuleBase.Base.EntityModels;
using Omi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Omi.Modules.ModuleBase.Services
{
    public class CustomFieldService : BaseEntityService
    {
        public ModuleBaseDbContext _context;

        public CustomFieldService(ModuleBaseDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CustomField> GetModuleBase(CustomFieldServiceModel model)
        {
            var result = _context.CustomField.AsQueryable();

            if (model.GroupId != null)
                result = result.Where(o => o.CustomFieldGroupId == model.GroupId);

            return result;
        }

        public int CountCustomFieldGroups()
        {
            return _context.CustomFieldGroup.Count(o => o.DeleteByUser.Id != null);
        }

        public IEnumerable<CustomFieldGroup> GetCustomFieldGroups(CustomFieldGroupServiceModel model = null)
        {
            var result = BaseEntityFilter(_context.CustomFieldGroup, model);

            return result;
        }
    }
}
