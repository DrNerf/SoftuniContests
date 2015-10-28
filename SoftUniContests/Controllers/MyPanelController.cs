using SoftUniContests.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftUniContests.Controllers
{
    [Authorize]
    public class MyPanelController : BaseController
    {
        [HttpPost]
        public ActionResult DeleteContest(int contestID)
        {
            try
            {
                unitOfWork.ContestsRepository.Delete(contestID);
                unitOfWork.Save();
                return Json(new GenericResponse<object> { IsSuccess = true, Message = "Contest deleted!" });
            }
            catch (Exception ex)
            {
                return Json(new GenericResponse<object> { IsSuccess = true, Message = ex.Message });
            }
        }

        public ActionResult CreateContest()
        {
            return View(new ContestModel());
        }

        [HttpPost]
        public ActionResult CreateContest(ContestModel model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ContestsRepository.Insert(model);
                unitOfWork.Save();
                return Redirect("/Home/MyPanel"); 
            }
            else
            {
                return View("CreateContest", model);
            }
        }
    }
}