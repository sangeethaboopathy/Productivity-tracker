using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_DataAccess.Context;
using ProductivityTracker_DataAccess.Core;
using ProductivityTracker_DataAccess.DomainModels;
using ProductivityTracker_DataModel.Commands.Account;

namespace ProductivityTracker_DataAccess.CommandHandlers.Account
{
    public class CompleteAccountCommandHandler : CommandHandlerBase<CompleteAccountCommand, SqlServerContext>
    {
        public CompleteAccountCommandHandler(SqlServerContext dbContextInput) : base(dbContextInput)
        {
        }

        public override void Execute(CompleteAccountCommand command)
        {
            var account = dbContext.MarketingAccountDetails.Find(command.AccountId);
            if (account != null)
            {
                var timeLog = dbContext.AccountTimeLogDetails.Find(command.TimeLogId);
                if (timeLog != null && timeLog.AccountId == command.AccountId)
                {
                    timeLog.EndTime = DateTime.Now;
                    timeLog.Comment = command.Comment;
                }

                dbContext.SaveChanges();
            }
        }
    }
}
