using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTracker_Models.ViewModels.Login
{
    public class LoginResultVM : BaseResponse
    {
        public LoginResultEnum LoginResult { get; set; }
    }
}
