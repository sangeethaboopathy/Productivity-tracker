using ProductivityTracker_Helpers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTracker_Business.Interface
{
    public interface IUserDetailsExecutor : IBaseExecutor
    {
        BaseResponse GetUserDetails(string emailId, string password);
    }
}
