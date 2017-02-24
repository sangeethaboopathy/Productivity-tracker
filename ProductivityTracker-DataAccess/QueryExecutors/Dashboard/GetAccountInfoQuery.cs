using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_DataAccess.Context;
using ProductivityTracker_DataAccess.Core;
using ProductivityTracker_DataAccess.DomainModels;
using ProductivityTracker_DataModel.Queries.Dashboard;
using ProductivityTracker_Models.Dto.Dashboard;

namespace ProductivityTracker_DataAccess.QueryExecutors.Dashboard
{
    public class GetAccountInfoQuery : QueryBase<SqlServerContext>, IGetAccountInfoQuery
    {
        public GetAccountInfoQuery(SqlServerContext dbContextInput) : base(dbContextInput)
        {
        }

        public List<AccountInfoDto> Execute()
        {
            var accountsList = (from accounts in dbContext.MarketingAccountDetails
                                join timelog in dbContext.AccountTimeLogDetails on accounts.AccountId equals timelog.AccountId into subSet
                                from rightJoin in subSet.DefaultIfEmpty()
                                orderby accounts.StatusInt, accounts.StartDate
                                select new AccountInfoDto
                                {
                                    StartDate = accounts.StartDate,
                                    AccountId = accounts.AccountId,
                                    AccountName = accounts.AccountName,
                                    CompletedOn = rightJoin != null ? rightJoin.EndTime : null,
                                    CreatedOn = accounts.CreatedOn,
                                    CustomId = accounts.CustomAccountId,
                                    PickedBy = rightJoin != null ? dbContext.UserPersonalDetails.FirstOrDefault(x => x.UserId == rightJoin.UserId).FirstName : null,
                                    PickedOn = rightJoin != null ? (DateTime?)rightJoin.StartTime : null,
                                    Status = accounts.Status,
                                    TimeLogId = rightJoin != null ? rightJoin.AccountTimeLogId : 0
                                }).ToList();

            return accountsList;
        }
    }
}
