using System;
using System.Collections.Generic;
using System.Linq;
using ProductivityTracker_DataAccess.Context;
using ProductivityTracker_DataAccess.Core;
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
            List<AccountInfoDto> info = new List<AccountInfoDto>();

            foreach (var item in dbContext.MarketingAccountDetails)
            {
                var accountInfo = new AccountInfoDto
                {
                    StartDate = item.StartDate,
                    AccountId = item.AccountId,
                    AccountName = item.AccountName,
                    CreatedOn = item.CreatedOn,
                    CustomId = item.CustomAccountId,
                    Status = item.Status,
                };
                var timelog = dbContext.AccountTimeLogDetails.Where(x => x.AccountId == item.AccountId).OrderByDescending(var => var.EndTime).FirstOrDefault();

                if (timelog != null)
                {
                    accountInfo.PickedBy = timelog != null ? dbContext.UserPersonalDetails.FirstOrDefault(x => x.UserId == timelog.UserId).FirstName : null;
                    accountInfo.PickedOn = timelog != null ? (DateTime?)timelog.StartTime : null;
                    accountInfo.TimeLogId = timelog != null ? timelog.AccountTimeLogId : 0;
                    accountInfo.CompletedOn = timelog != null ? timelog.EndTime : null;
                }

                info.Add(accountInfo);
            }

            //var accountsList = (from accounts in dbContext.MarketingAccountDetails
            //                    join timelog in timelogList on accounts.AccountId equals timelog.AccountId into subSet
            //                    from rightJoin in subSet.DefaultIfEmpty()
            //                    orderby accounts.StatusInt, accounts.StartDate
            //                    select new AccountInfoDto
            //                    {
            //                        StartDate = accounts.StartDate,
            //                        AccountId = accounts.AccountId,
            //                        AccountName = accounts.AccountName,
            //                        CompletedOn = rightJoin != null ? rightJoin.EndTime : null,
            //                        CreatedOn = accounts.CreatedOn,
            //                        CustomId = accounts.CustomAccountId,
            //                        PickedBy = rightJoin != null ? dbContext.UserPersonalDetails.FirstOrDefault(x => x.UserId == rightJoin.UserId).FirstName : null,
            //                        PickedOn = rightJoin != null ? (DateTime?)rightJoin.StartTime : null,
            //                        Status = accounts.Status,
            //                        TimeLogId = rightJoin != null ? rightJoin.AccountTimeLogId : 0
            //                    }).ToList();

            //return accountsList;

            return info.ToList();
        }
    }
}
