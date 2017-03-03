using ProductivityTracker_DataAccess.Context;
using ProductivityTracker_DataAccess.Core;
using ProductivityTracker_DataModel.Queries.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_Models.ViewModels.Login;

namespace ProductivityTracker_DataAccess.QueryExecutors.Login
{
    public class GetUserDetails : QueryBase<SqlServerContext>, IGetUserDetails
    {
        public GetUserDetails(SqlServerContext dbContextInput) : base(dbContextInput)
        {
        }

        public UserDetails Execute(string emailId, string password)
        {
            var loginDetails = dbContext.UserLoginDetails.First(x => x.EmailId == emailId && x.Password == password);
            var userDetails = dbContext.UserPersonalDetails.First(x => x.UserId == loginDetails.UserId);

            var info = new UserDetails
            {
                UserId = loginDetails.UserId,
                Email = loginDetails.EmailId,
                UserName = userDetails.FirstName,
                Gender = userDetails.Gender
            };

            return info;
        }
    }
}
