using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_Business.Interface;
using ProductivityTracker_DataModel.Commands.Account;
using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_Models.Dto.Account;

namespace ProductivityTracker_Business.Executors
{
    public class AccountExecutor : BaseExecutors, IAccountExecutor
    {
        public BaseResponse UploadAccountsInfo(string fileContent, int userId)
        {
            try
            {
                var accountsList = new List<AccountUploadDto>();

                var accounts = fileContent.Split('\n');
                foreach (var account in accounts)
                {
                    var accountInfo = account.Split('\t');
                    if(accountInfo[0].Equals("CID-AID"))
                        continue;
                    
                    accountsList.Add(new AccountUploadDto
                    {
                        CustomId = accountInfo[0],
                        AccountName = accountInfo[1],
                        StartDate = accountInfo[2]
                    });
                }

                commandsFactory.ExecuteCommand(new UploadAccountsCommand
                {
                    UserId = userId,
                    Accounts = accountsList
                });

                return new BaseResponse
                {
                    HasError = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    HasError = false
                };
            }
        }

        public BaseResponse PickAccount(int userId, int accountId)
        {
            try
            {
                commandsFactory.ExecuteCommand(new PickAccountCommand
                {
                    AccountId = accountId,
                    UserId = userId
                });

                return new BaseResponse
                {
                    HasError = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    HasError = false
                };
            }
        }

        public BaseResponse CompleteAccount(int userId, int accountId, int timeLogId, string comment)
        {
            try
            {
                commandsFactory.ExecuteCommand(new CompleteAccountCommand
                {
                    AccountId = accountId,
                    UserId = userId,
                    TimeLogId = timeLogId,
                    Comment = comment
                });

                return new BaseResponse
                {
                    HasError = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    HasError = false
                };
            }
        }
    }
}
