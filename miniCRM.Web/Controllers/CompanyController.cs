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
        IBaseRepository<ElectricMeter> dbMeters;
        public CompanyController(IBaseRepository<Company> repo, IBaseRepository<ElectricMeter> meterRepo)
        {
            dbCompany = repo;
            dbMeters = meterRepo;
        }

        private SelectList CreateMeterList()
        {
            var metersList = dbMeters.GetAll().ToList();
            SelectList list = new SelectList(metersList, "ElectricMeterID", "SerialNumber");
            return list;
        }
        // GET: Company
        public ActionResult Index()
        {
            var companies = dbCompany.GetAll().OrderBy(m => m.CompanyID).Select(c => c);
            return View("Companies", companies);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //Создаем список для выбора счетчика
            //var list = CreateMeterList();
            var metersList = dbMeters.GetAll().ToList();
            SelectList list = new SelectList(metersList, "ElectricMeterID", "SerialNumber");
            ViewBag.meterlist = list;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Company company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbCompany.Add(company);
                    dbCompany.Save();
                    return RedirectToAction("Index");
                }
                return View(company);
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //TODO: Вынести создание списка за пределы методов
            //Создаем список для выбора счетчика 
            var list = CreateMeterList();
            ViewBag.meterlist = list;
            var result = dbCompany.GetOne(id);
            if (result == null)
            {
                return View("Index");
            }
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit (Company company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbCompany.Edit(company);
                    dbCompany.Save();
                    return RedirectToAction("Index");
                }
                return View(company);
            }
            catch
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var result = dbCompany.GetOne(id);
            if (result == null)
            {
                return View("Index");
            }
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteCompany (Company company)
        {
            try
            {
                dbCompany.Delete(company);
                dbCompany.Save();
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }
      
    }

}