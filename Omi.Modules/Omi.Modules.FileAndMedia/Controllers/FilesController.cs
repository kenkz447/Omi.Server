﻿using Microsoft.AspNetCore.Identity;
using Omi.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Omi.Base;
using Omi.Modules.FileAndMedia.Services;
using Omi.Modules.ModuleBase;
using Omi.Modules.FileAndMedia.ServiceModels;
using Omi.Modules.ModuleBase.Base.ServiceModel;
using System.Linq;
using System;
using Omi.Modules.FileAndMedia.ViewModel;

namespace Omi.Modules.FileAndMedia.Controllers
{
    public class FilesController : BaseController
    {
        private readonly FileService _fileService;

        public FilesController(
            FileService fileService,
            UserManager<ApplicationUser> userManager, 
            ILogger<FilesController> logger) : base(logger, userManager)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<BaseJsonResult> Upload()
        {
            try
            {
                var uploadedEntity = await _fileService.Upload(Request.Form.Files, CurrentUser);

                if (uploadedEntity.Count() != 0)
                    _logger.LogInformation("A file was uploaded to server.");

                var result = uploadedEntity.Select(fileEntity => new FileEntityInfo(fileEntity));

                return new BaseJsonResult(Omi.Base.Properties.Resources.POST_SUCCEEDED, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BaseJsonResult GetFiles()
        {
            var entities = _fileService.GetFileEntities(new FileEntityFilterServiceModel {
                // Service model properties...
            });

            var result = entities.Select(fileEntity => new FileEntityInfo(fileEntity));

            return new BaseJsonResult(Omi.Base.Properties.Resources.POST_SUCCEEDED, result);
        }

        /// <summary>
        /// Delete a file form server
        /// </summary>
        /// <param name="id">FileEntity Id</param>
        /// <returns></returns>
        public async Task<BaseJsonResult> Delete(long id)
        {
            var serviceModel = new BaseDeleteServiceModel()
            {
                EntityId = id
            };

            var result = await _fileService.Delete(serviceModel);

            if (result.Code == Omi.Base.Properties.Resources.POST_SUCCEEDED)
                _logger.LogInformation($"A file was deleted.");

            return result;
        }
    }
}
