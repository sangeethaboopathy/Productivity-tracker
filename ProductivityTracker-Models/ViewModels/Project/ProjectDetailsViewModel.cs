using System.Collections.Generic;
using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_Models.Dto.Projects;

namespace ProductivityTracker_Models.ViewModels.Project
{
    public class ProjectDetailsViewModel : BaseResponse
    {
        public List<ProjectDropdownDto> Projects { get; set; }
        public string ProjectName { get; set; }
    }
}
