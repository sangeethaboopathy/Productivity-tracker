using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_Business.Interface;
using ProductivityTracker_DataModel.Queries.Projects;
using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_Models.ViewModels.Project;

namespace ProductivityTracker_Business.Executors
{
    public class ProjectExecutor : BaseExecutors, IProjectExecutor
    {
        public BaseResponse GetProjectsForDropdown()
        {
            try
            {
                var result = queryFactory.ResolveQuery<IGetProjectsForDropdownQuery>().Execute();
                return new ProjectDropdownModel
                {
                    HasError = false,
                    Projects = result
                };
            }
            catch (Exception ex)
            {
                return new ProjectDropdownModel
                {
                    HasError = true
                };
            }
        }
    }
}
