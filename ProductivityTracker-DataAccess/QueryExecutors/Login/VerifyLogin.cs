using ProductivityTracker_DataAccess.Context;
using ProductivityTracker_DataAccess.Core;
using ProductivityTracker_DataModel.Queries.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_Helpers.Enums;

namespace ProductivityTracker_DataAccess.QueryExecutors.Login
{
    public class VerifyLogin : QueryBase<SqlServerContext>, IVerifyLogin
    {
        public VerifyLogin(SqlServerContext dbContextInput) : base(dbContextInput)
        {
        }

        public LoginResultEnum Execute(string emailId, string password)
        {
            return dbContext.UserLoginDetails.Any(var => var.EmailId.Equals(emailId) && var.Password.Equals(password))
                ? LoginResultEnum.Success
                : LoginResultEnum.Failure;
        }
    }
}
