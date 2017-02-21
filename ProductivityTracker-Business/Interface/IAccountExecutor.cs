using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_Helpers.Contracts;

namespace ProductivityTracker_Business.Interface
{
    public interface IAccountExecutor: IBaseExecutor
    {
        BaseResponse UploadAccountsInfo(string fileContent, int userId);
        BaseResponse PickAccount(int userId, int accountId);
        BaseResponse CompleteAccount(int userId, int accountId, int timeLogId, string comment);
    }
}
