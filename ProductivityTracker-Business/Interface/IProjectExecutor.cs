using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_Helpers.Contracts;

namespace ProductivityTracker_Business.Interface
{
    public interface IProjectExecutor : IBaseExecutor
    {
        BaseResponse GetProjectsForDropdown();
    }
}
