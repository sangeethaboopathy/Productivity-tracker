using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_Business.Interface;
using ProductivityTracker_Business.Executors;
using ProductivityTracker_DataModel.Queries.Dashboard;
using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_Models.ViewModels.Dashboard;

namespace ProductivityTracker_Business.Executors
{
    public class DashboardExecutor : BaseExecutors, IDashboardExecutor
    {
        public BaseResponse GetAccountDetails()
        {
            try
            {
                var accountsList = queryFactory.ResolveQuery<IGetAccountInfoQuery>().Execute();
                return new AccountInfoViewModel
                {
                    HasError = false,
                    Accounts = accountsList
                };
            }
            catch (Exception ex)
            {
                return new AccountInfoViewModel
                {
                    HasError = true
                };
            }
        }
    }
}
