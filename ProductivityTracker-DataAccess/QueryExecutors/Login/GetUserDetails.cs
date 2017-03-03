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
            var loginDetails = dbContext.UserLoginDetails.Where(x => x.EmailId == emailId && x.Password == password).First();
            var userDetails = dbContext.UserPersonalDetails.Where(x => x.UserId == loginDetails.UserId).First();

            var info = new UserDetails
            {
                UserId = loginDetails.UserId,
                Email = loginDetails.EmailId,
                Password = loginDetails.Password,
                UserName = userDetails.FirstName,
                Gender = userDetails.Gender
            };

            return info;
        }
    }
}
