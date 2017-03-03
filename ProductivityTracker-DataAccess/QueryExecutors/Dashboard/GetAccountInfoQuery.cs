﻿using System;
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

                accountInfo.ProgressHistory = new List<ProgressHistory>();
                var history = dbContext.AccountTimeLogDetails.Where(x => x.AccountId == item.AccountId);
                if(history!=null)
                {
                    foreach(var log in history)
                    {
                        var historyItem = new ProgressHistory
                        {
                            StartTime = log.StartTime,
                            EndTime = log.EndTime,
                            UserName = dbContext.UserPersonalDetails.FirstOrDefault(x => x.UserId == log.UserId).FirstName
                        };

                        if (log.Status != null)
                        {
                            switch (log.Status)
                            {
                                case 1:
                                    historyItem.Status = "New";
                                    break;
                                case 2:
                                    historyItem.Status = "In progress";
                                    break;
                                case 3:
                                    historyItem.Status = "Paused";
                                    break;
                                case 4:
                                    historyItem.Status = "Completed";
                                    break;
                                default:
                                    historyItem.Status = "New";
                                    break;
                            }
                        }

                        accountInfo.ProgressHistory.Add(historyItem);
                    }
                }

                var timelog = dbContext.AccountTimeLogDetails.Where(x => x.AccountId == item.AccountId).OrderByDescending(var => var.StartTime).FirstOrDefault();

                if (timelog != null)
                {
                    accountInfo.PickedBy = timelog != null ? dbContext.UserPersonalDetails.FirstOrDefault(x => x.UserId == timelog.UserId).FirstName : null;
                    accountInfo.PickedOn = timelog != null ? (DateTime?)timelog.StartTime : null;
                    accountInfo.TimeLogId = timelog != null ? timelog.AccountTimeLogId : 0;
                    accountInfo.CompletedOn = timelog != null ? timelog.EndTime : null;
                }

                info.Add(accountInfo);
            }
            
            return info.ToList();
        }
    }
}
