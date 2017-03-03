﻿using ProductivityTracker_Business;
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
                    var userDetails = (UserDetails) userDetailsExecutor.GetUserDetails(emailId, password);

                    Session["UserName"] = userDetails.UserName;
                    Session["UserId"] = userDetails.UserId;

                    return RedirectToAction("Index", "Home");
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