using ProductivityTracker_Business;
using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_Models.Dto.Dashboard;
using ProductivityTracker_Models.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductivityTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AccountInfoViewModel accountDetails = new AccountInfoViewModel();

            var dashboardExecutor = ExecutorFacade.GetDashboardInstance();
            accountDetails = (AccountInfoViewModel)dashboardExecutor.GetAccountDetails();

            return View(accountDetails);
        }

        public ActionResult UploadFiles()
        {
            BaseResponse response = null;
            AccountInfoViewModel accountDetails = new AccountInfoViewModel();
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;

                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];

                        var accountExecutor = ExecutorFacade.GetAccountInstance();

                        BinaryReader b = new BinaryReader(file.InputStream);
                        byte[] binData = b.ReadBytes((int)file.InputStream.Length);

                        string result = System.Text.Encoding.UTF8.GetString(binData);
                        response = accountExecutor.UploadAccountsInfo(result, 1);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (response != null && !response.HasError)
            {
                var dashboardExecutor = ExecutorFacade.GetDashboardInstance();
                accountDetails = (AccountInfoViewModel)dashboardExecutor.GetAccountDetails();                
            }

            return PartialView("_AccountInfo", accountDetails);
        }

        [HttpPost]
        public ActionResult PickAccount(int id)
        {
            var accountExecutor = ExecutorFacade.GetAccountInstance();
            AccountInfoViewModel accountDetails = new AccountInfoViewModel();
            BaseResponse response = accountExecutor.PickAccount(Convert.ToInt16(Session["UserId"]), id);

            if (response != null && !response.HasError)
            {
                var dashboardExecutor = ExecutorFacade.GetDashboardInstance();
                accountDetails = (AccountInfoViewModel)dashboardExecutor.GetAccountDetails();
            }

            return PartialView("_AccountInfo", accountDetails);
        }

        [HttpPost]
        public ActionResult CompleteAccount(int timeLogId, int accountId, int statusId, string comments)
        {
            var accountExecutor = ExecutorFacade.GetAccountInstance();
            AccountInfoViewModel accountDetails = new AccountInfoViewModel();
            BaseResponse response = accountExecutor.CompleteAccount(1, accountId, timeLogId, statusId, comments);

            if (response != null && !response.HasError)
            {
                var dashboardExecutor = ExecutorFacade.GetDashboardInstance();
                accountDetails = (AccountInfoViewModel)dashboardExecutor.GetAccountDetails();
            }

            return PartialView("_AccountInfo", accountDetails);
        }        
    }
}