using ProductivityTracker_DataModel.Core;
using ProductivityTracker_Models.ViewModels.Login;

namespace ProductivityTracker_DataModel.Queries.Login
{
    public interface IGetUserDetails : IQuery
    {
        UserDetails Execute(string emailId, string password);
    }
}
