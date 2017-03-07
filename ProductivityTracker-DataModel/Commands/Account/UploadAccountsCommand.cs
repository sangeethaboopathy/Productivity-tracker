using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_DataModel.Core;
using ProductivityTracker_Models.Dto.Account;

namespace ProductivityTracker_DataModel.Commands.Account
{
    public class UploadAccountsCommand : ICommand
    {
        public List<AccountUploadDto> Accounts { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}
