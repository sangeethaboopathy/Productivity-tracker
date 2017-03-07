using ProductivityTracker_Business;
using ProductivityTracker_Helpers.Constants;
using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_Helpers.Enums;
using ProductivityTracker_Models.ViewModels.Login;
using System.Web.Mvc;
using ProductivityTracker_Business.Interface;

namespace ProductivityTracker.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginExecutor _loginExecutor = ExecutorFacade.GetLoginInstance();
        private readonly IUserDetailsExecutor _userDetailsExecutor= ExecutorFacade.GetUserDetailsInstance();

        public ActionResult Index()
        {
            string error = (string) TempData["Error"];
            switch (error)
            {
                case "FailedLogin":
                    ViewBag.Error = "Invalid credentials. Please try again.";
                    break;
                case "InternalServerError":
                    ViewBag.Error = "Internal server error. Please contact Administrator.";
                    break;
            }
            return View();
        }

        public ActionResult Login(string emailId, string password)
        {
            var response = _loginExecutor.VerifyLogin(emailId, password);

            if(!response.HasError)
            {
                LoginResultVM result = (LoginResultVM) response;
                if (result.LoginResult == LoginResultEnum.Success)
                {
                    var userDetails = (UserDetails) _userDetailsExecutor.GetUserDetails(emailId, password);

                    Session[SessionConstants.User_Name] = userDetails.UserName;
                    Session[SessionConstants.User_Id] = userDetails.UserId;
                    Session[SessionConstants.Gender] = userDetails.Gender;

                    return RedirectToAction("Index", "Projects");
                }
                else
                {
                    TempData["Error"] = "FailedLogin";
                    return RedirectToAction("Index", "Login");
                }
            }

            TempData["Error"] = "InternalServerError";
            return RedirectToAction("Index", "Login");
        }
    }
}