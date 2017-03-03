using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_DataModel.Core;
using ProductivityTracker_Models.Dto.Projects;

namespace ProductivityTracker_DataModel.Queries.Projects
{
    public interface IGetProjectsForDropdownQuery: IQuery
    {
        List<ProjectDropdownDto> Execute();
    }
}
