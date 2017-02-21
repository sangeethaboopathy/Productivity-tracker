using ProductivityTracker_Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_DataModel.Queries.Login;
using ProductivityTracker_Models.ViewModels.Login;

namespace ProductivityTracker_Business.Executors
{
    public class LoginExecutor : BaseExecutors, ILoginExecutor
    {
        public BaseResponse VerifyLogin(string emailId, string password)
        {
            try
            {
                var result = queryFactory.ResolveQuery<IVerifyLogin>().Execute(emailId, password);
                return new LoginResultVM
                {
                    HasError = false,
                    LoginResult = result
                };
            }
            catch (Exception ex)
            {
                return new LoginResultVM
                {
                    HasError = true
                };
            }
        }
    }
}
