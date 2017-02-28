using ProductivityTracker_Business;
using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_Helpers.Enums;
using ProductivityTracker_Models.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductivityTracker.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string emailId, string password)
        {
            BaseResponse response = null;
            LoginResultVM result = new LoginResultVM();

            var loginExecutor = ExecutorFacade.GetLoginInstance();

            response = loginExecutor.VerifyLogin(emailId, password);

            if(!response.HasError)
            {
                result = (LoginResultVM)response;
                if (result.LoginResult == LoginResultEnum.Success)
                {
                    var userDetailsExecutor = ExecutorFacade.GetUserDetailsInstance();
                    var userDetails = (UserDetails)userDetailsExecutor.GetUserDetails(emailId, password);

                    Session["UserName"] = userDetails.UserName;
                    Session["UserId"] = userDetails.UserId;

                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}