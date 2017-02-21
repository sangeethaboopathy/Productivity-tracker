using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_DataModel.Core;

namespace ProductivityTracker_DataModel.Commands.Account
{
    public class CompleteAccountCommand : ICommand
    {
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public int TimeLogId { get; set; }
        public string Comment { get; set; }
    }
}
