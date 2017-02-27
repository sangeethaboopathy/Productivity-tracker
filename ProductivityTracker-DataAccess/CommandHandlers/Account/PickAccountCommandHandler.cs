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
    public class PickAccountCommandHandler : CommandHandlerBase<PickAccountCommand, SqlServerContext>
    {
        public PickAccountCommandHandler(SqlServerContext dbContextInput) : base(dbContextInput)
        {
        }

        public override void Execute(PickAccountCommand command)
        {
            var account = dbContext.MarketingAccountDetails.Find(command.AccountId);
            if (account != null)
            {
                var updateDate = DateTime.Now;
                account.Status = "In Progress";
                account.StatusInt = 2;
                account.UpdatedBy = command.UserId;
                account.UpdatedOn = updateDate;

                dbContext.AccountTimeLogDetails.Add(new AccountTimeLogDetail
                {
                    UserId = command.UserId,
                    AccountId = command.AccountId,
                    StartTime = updateDate
                });

                dbContext.SaveChanges();
            }
        }
    }
}
