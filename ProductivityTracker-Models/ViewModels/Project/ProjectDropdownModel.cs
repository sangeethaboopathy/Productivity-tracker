using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_Models.Dto.Projects;

namespace ProductivityTracker_Models.ViewModels.Project
{
    public class ProjectDropdownModel : BaseResponse
    {
        public List<ProjectDropdownDto> Projects { get; set; }
    }
}
