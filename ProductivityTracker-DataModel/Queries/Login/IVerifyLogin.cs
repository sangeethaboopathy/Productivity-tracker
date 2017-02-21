using ProductivityTracker_DataModel.Core;
using ProductivityTracker_Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTracker_DataModel.Queries.Login
{
    public interface IVerifyLogin : IQuery
    {
        LoginResultEnum Execute(string emailId, string password);
    }
}
