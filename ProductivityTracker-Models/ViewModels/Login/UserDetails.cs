using ProductivityTracker_Helpers.Contracts;

namespace ProductivityTracker_Models.ViewModels.Login
{
    public class UserDetails : BaseResponse
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
