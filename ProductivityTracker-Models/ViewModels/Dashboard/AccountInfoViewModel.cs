using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_Models.Dto.Dashboard;

namespace ProductivityTracker_Models.ViewModels.Dashboard
{
    public class AccountInfoViewModel : BaseResponse
    {
        public List<AccountInfoDto> Accounts { get; set; }
    }
}
