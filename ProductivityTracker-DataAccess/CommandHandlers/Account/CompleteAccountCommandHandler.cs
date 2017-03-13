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
            if (command.StatusInt == 5)
            {
                var account = dbContext.MarketingAccountDetails.Find(command.AccountId);
                if (account != null)
                {
                    var timelog = dbContext.AccountTimeLogDetails.Where(x => x.AccountId == command.AccountId);

                    foreach(var item in timelog)
                    {
                        dbContext.AccountTimeLogDetails.Remove(item);
                    }

                    account.Status = "New";
                    account.StatusInt = 1;
                    account.UpdatedBy = command.UserId;
                    account.UpdatedOn = DateTime.Now;

                    dbContext.SaveChanges();
                }
            }
            else
            {
                var account = dbContext.MarketingAccountDetails.Find(command.AccountId);
                if (account != null)
                {
                    var updateDate = DateTime.Now;
                    account.Status = command.StatusInt == 3 ? "Paused" : "Completed";
                    account.StatusInt = command.StatusInt;
                    account.UpdatedOn = updateDate;

                    var timeLog = dbContext.AccountTimeLogDetails.Find(command.TimeLogId);
                    if (timeLog != null && timeLog.AccountId == command.AccountId)
                    {
                        timeLog.EndTime = DateTime.Now;
                        timeLog.Comment = command.Comment;
                        timeLog.Status = command.StatusInt;
                    }

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
