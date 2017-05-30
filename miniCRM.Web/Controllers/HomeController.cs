using miniCRM.Data;
using miniCRM.Data.Abstract;
using miniCRM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miniCRM.Web.Models;

namespace miniCRM.Web.Controllers
{
    public class HomeController : Controller
    {
        public IBaseRepository<Act> dbAct;
        public HomeController (IBaseRepository<Employe> repo, IBaseRepository<Act> repoAct)
        {
            dbAct = repoAct;
        }

        // GET: Home
        public ActionResult Index()
        {
            var list = dbAct.GetAll().Where(m => m.ActID > 0).OrderByDescending(m => m.ActualDate).Select(c => c).AsQueryable();

                return View(list);
        }
    }
}