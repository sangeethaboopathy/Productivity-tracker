using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductivityTracker_Business;
using ProductivityTracker_Business.Interface;
using ProductivityTracker_Helpers.Contracts;
using ProductivityTracker_Models.ViewModels.Dashboard;

namespace ProductivityTracker.Controllers
{
    [CustomAuthorize]
    public class AccountsController : Controller
    {
        private readonly IDashboardExecutor _dashboardExecutor = ExecutorFacade.GetDashboardInstance();
        private readonly IAccountExecutor _accountExecutor = ExecutorFacade.GetAccountInstance();
        private readonly IProjectExecutor _projectExecutor = ExecutorFacade.GetProjectsInstance();

        public ActionResult UploadFiles(int projectId)
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
                        
                        BinaryReader b = new BinaryReader(file.InputStream);
                        byte[] binData = b.ReadBytes((int)file.InputStream.Length);

                        string result = System.Text.Encoding.UTF8.GetString(binData);
                        response = _accountExecutor.UploadAccountsInfo(result, 1, projectId);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (response != null && !response.HasError)
            {
                return RedirectToAction("GetAccountsDetails", new { projectId = projectId });
            }

            throw new Exception();
        }

        public ActionResult GetAccountsDetails(int projectId)
        {
            var accountDetails = (AccountInfoViewModel)_dashboardExecutor.GetAccountDetails(projectId);

            return PartialView("_AccountInfo", accountDetails);
        }

        [HttpPost]
        public ActionResult PickAccount(int id, int projectId)
        {
            AccountInfoViewModel accountDetails = new AccountInfoViewModel();
            BaseResponse response = _accountExecutor.PickAccount(Convert.ToInt16(Session["UserId"]), id);

            if (response != null && !response.HasError)
            {
                return RedirectToAction("GetAccountsDetails", new { projectId = projectId });
            }

            throw new Exception();
        }

        [HttpPost]
        public ActionResult CompleteAccount(int timeLogId, int accountId, int statusId, string comments, int projectId)
        {
            AccountInfoViewModel accountDetails = new AccountInfoViewModel();
            BaseResponse response = _accountExecutor.CompleteAccount(1, accountId, timeLogId, statusId, comments);

            if (response != null && !response.HasError)
            {
                return RedirectToAction("GetAccountsDetails", new { projectId = projectId });
            }

            throw new Exception();
        }

        public ActionResult Accounts()
        {
            var projects = _projectExecutor.GetProjectsForDropdown();
            if (projects.HasError)
                throw new Exception();

            ViewBag.Projects = projects;

            return View("AccountsView");
        }
    }
}