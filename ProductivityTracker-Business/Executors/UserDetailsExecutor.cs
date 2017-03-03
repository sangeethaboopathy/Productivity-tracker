using ProductivityTracker_Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_Models.ViewModels.Login;
using ProductivityTracker_DataModel.Queries.Login;

namespace ProductivityTracker_Business.Executors
{
    public class UserDetailsExecutor : BaseExecutors, IUserDetailsExecutor
    {
        public BaseResponse GetUserDetails(string emailId, string password)
        {
            try
            {
                var result = queryFactory.ResolveQuery<IGetUserDetails>().Execute(emailId, password);
                return new UserDetails
                {
                    HasError = false,
                    UserId = result.UserId,
                    UserName = result.UserName,
                    Email = result.Email,
                    Gender = result.Gender
                };
            }
            catch (Exception ex)
            {
                return new UserDetails
                {
                    HasError = true
                };
            }
        }
    }
}
