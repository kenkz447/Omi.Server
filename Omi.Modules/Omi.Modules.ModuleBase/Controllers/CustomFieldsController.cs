using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Omi.Modules.ModuleBase.Entities;
using Omi.Modules.ModuleBase.ViewModels;
using Omi.Modules.ModuleBase.Services;

namespace Omi.Modules.ModuleBase.Controllers
{
    public class ModuleBaseController : BaseController
    {
        private readonly CustomFieldService _customFieldService;

        public ModuleBaseController(
            ILogger<ModuleBaseController> logger, 
            CustomFieldService customFieldsService) : base(logger)
        {
            _customFieldService = customFieldsService;
        }

        [AllowAnonymous]
        public IEnumerable<CustomFieldGroup> GetCustomFieldGroups([FromBody]SearchCustomFieldGroupViewModel viewModel)
        {
            return _customFieldService.GetCustomFieldGroups();
        }
    }
}