using Omi.Modules.ModuleBase;
using Microsoft.Extensions.Logging;
using Omi.Modules.HomeBuilder.Services;
using Microsoft.AspNetCore.Mvc;
using Omi.Base;
using System.Threading.Tasks;
using Omi.Modules.HomeBuilder.ViewModels;
using Omi.Modules.HomeBuilder.ServiceModel;
using System.Linq;
using Omi.Modules.ModuleBase.ViewModels;
using Omi.Modules.Location.ViewModel;
using Microsoft.AspNetCore.Identity;
using Omi.Data;

namespace Omi.Modules.HomeBuilder.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly ProjectService _projectService;

        public ProjectController(
            ProjectService projectService,
            UserManager<ApplicationUser> userManager,
            ILogger<ProjectController> logger) : base(logger, userManager)
        {
            _projectService = projectService;
        }

        private ProjectViewModelExtended _emptyProjectViewModel;
        private ProjectViewModelExtended EmptyProjectViewModel
        {
            get
            {
                if (_emptyProjectViewModel != null)
                    return _emptyProjectViewModel;

                var projectTypes = _projectService.GetAllProjectTypes();
                var geographicaLocations = _projectService.getAllGeographicaLocations();

                _emptyProjectViewModel = new ProjectViewModelExtended
                {
                    AvaliableProjectTypes = projectTypes.Select(o => TaxomonyViewModel.FromEntity(o)),
                    AvaliableGeographicaLocations = geographicaLocations.Select(o => GeographicaLocationViewModel.FromEntity(o)),
                };

                return _emptyProjectViewModel;
            }
        }

        public BaseJsonResult GetEmptyProjectViewModel()
            => new BaseJsonResult(Base.Properties.Resources.POST_SUCCEEDED, EmptyProjectViewModel);

        public async Task<BaseJsonResult> GetProject(long projectId)
        {
            var project = await _projectService.GetProjectById(projectId);

            var viewModel = ProjectViewModelExtended.FromEntity(project);
            viewModel.AvaliableGeographicaLocations = EmptyProjectViewModel.AvaliableGeographicaLocations;
            viewModel.AvaliableProjectTypes = EmptyProjectViewModel.AvaliableProjectTypes;

            return new BaseJsonResult(Omi.Base.Properties.Resources.POST_SUCCEEDED, viewModel);
        }

        [HttpPost]
        public async Task<BaseJsonResult> CreateNewProject([FromBody]ProjectViewModel viewModel)
        {
            var serviceModel = ProjectServiceModel.FromViewModel(viewModel);
            serviceModel.User = CurrentUser;

            var newProject = await _projectService.CreateNewProject(serviceModel);

            return new BaseJsonResult(Omi.Base.Properties.Resources.POST_SUCCEEDED, newProject.Id);
        }

        [HttpPost]
        public async Task<BaseJsonResult> UpdateProject([FromBody]ProjectViewModel model)
        {
            var projectServiceModel = ProjectServiceModel.FromViewModel(model);
            projectServiceModel.User = CurrentUser;

            await _projectService.UpdateProjectAsync(projectServiceModel);

            return new BaseJsonResult(Omi.Base.Properties.Resources.POST_SUCCEEDED, model.Id);
        }
    }
}