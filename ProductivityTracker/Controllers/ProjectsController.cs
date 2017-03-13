using ProductivityTracker_Business;
using ProductivityTracker_Business.Interface;
using ProductivityTracker_Models.ViewModels.Project;
using System;
using System.Web.Mvc;

namespace ProductivityTracker.Controllers
{
    [CustomAuthorize]
    public class ProjectsController : Controller
    {
        private readonly IProjectExecutor _projectExecutor = ExecutorFacade.GetProjectsInstance();

        public ActionResult Index()
        {
            var viewModel = new ProjectDetailsViewModel();
            var projects = _projectExecutor.GetProjectsForDropdown();
            if (projects.HasError)
                throw new Exception();

            var projectModel = (ProjectDropdownModel)projects;
            viewModel.Projects = projectModel.Projects;

            return View("Index", viewModel);
        }
    }
}