using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTracker_Models.Dto.Dashboard
{
    public class AccountInfoDto
    {
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public int AccountId { get; set; }
        public string CustomId { get; set; }
        public string AccountName { get; set; }
        public string StartDate { get; set; }
        public string PickedBy { get; set; }
        public DateTime? PickedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int TimeLogId { get; set; }
        public List<ProgressHistory> ProgressHistory { get; set; }
    }

    public class ProgressHistory
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
}
