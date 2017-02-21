using ProductivityTracker_Helpers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTracker_Business.Interface
{
    public interface ILoginExecutor : IBaseExecutor
    {
        BaseResponse VerifyLogin(string emailId, string password);
    }
}
