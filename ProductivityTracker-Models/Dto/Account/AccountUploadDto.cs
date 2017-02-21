using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTracker_Models.Dto.Account
{
    public class AccountUploadDto
    {
        public string CustomId { get; set; }
        public string AccountName { get; set; }
        public string StartDate { get; set; }
    }
}
