using SoftUniContests.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftUniContests.Controllers
{
    public abstract class BaseController : Controller
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
    }
}