using miniCRM.Data.Abstract;
using miniCRM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace miniCRM.Web.Controllers
{
    public class CompanyController : Controller
    {
        IBaseRepository<Company> dbCompany;
        public CompanyController(IBaseRepository<Company> repo)
        {
            dbCompany = repo;
        }
        // GET: Company
        public ActionResult Index()
        {
            var companies = dbCompany.GetAll().OrderBy(m => m.CompanyID).Select(c => c);
            return View("Companies", companies);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Company company)
        {
            try
            {

                return RedirectToAction("Companies");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
      
    }

}