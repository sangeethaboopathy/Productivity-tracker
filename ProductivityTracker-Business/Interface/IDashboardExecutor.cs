using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_Models.ViewModels.Dashboard;

namespace ProductivityTracker_Business.Interface
{
    public interface IDashboardExecutor : IBaseExecutor
    {
        BaseResponse GetAccountDetails();
    }
}
