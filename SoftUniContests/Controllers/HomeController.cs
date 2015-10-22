using SoftUniContests.BusinessObjects.Models;
using SoftUniContests.BusinessObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftUniContests.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyPanel()
        {
            MyPanelViewModel viewModel = new MyPanelViewModel();
            viewModel.Contests = unitOfWork.ContestsRepository.Get<ContestModel>().ToList();
            return View(viewModel);
        }
    }
}