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
    public class UploadAccountsCommandHandler : CommandHandlerBase<UploadAccountsCommand, SqlServerContext>
    {
        public UploadAccountsCommandHandler(SqlServerContext dbContextInput) : base(dbContextInput)
        {
        }

        public override void Execute(UploadAccountsCommand command)
        {
            foreach (var account in command.Accounts)
            {
                var isAlreadyPresent =
                    dbContext.MarketingAccountDetails.FirstOrDefault(var => var.CustomAccountId == account.CustomId);
                if (isAlreadyPresent != null)
                {
                    isAlreadyPresent.StartDate = Convert.ToDateTime(account.StartDate);
                    isAlreadyPresent.AccountName = account.AccountName;
                    isAlreadyPresent.UpdatedOn = DateTime.Now;
                    isAlreadyPresent.UpdatedBy = command.UserId;
                }
                else
                {
                    dbContext.MarketingAccountDetails.Add(new MarketingAccountDetail
                    {
                        StartDate = Convert.ToDateTime(account.StartDate),
                        AccountName = account.AccountName,
                        CustomAccountId = account.CustomId,
                        CreatedBy = command.UserId,
                        CreatedOn = DateTime.Now,
                        Status = "New",
                        StatusInt = 1
                    });
                }
            }

            dbContext.SaveChanges();
        }
    }
}
