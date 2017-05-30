﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miniCRM.Data.Entities;
using miniCRM.Data.Abstract;

namespace miniCRM.Web.Controllers
{
    public class MeterController : Controller
    {
        IBaseRepository<ElectricMeter> dbMeter;
        public MeterController(IBaseRepository<ElectricMeter> repo)
        {
            dbMeter = repo;
        }
        // GET: Meter
        public ActionResult Index()
        {
            var meters = dbMeter.GetAll().OrderByDescending(m => m.ElectricMeterID).Select(s => s);
            return View(meters);
        }

        // GET: Meter/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        // GET: Meter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meter/Create
        [HttpPost]
        public ActionResult Create(ElectricMeter meter)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbMeter.Add(meter);
                    dbMeter.Save();
                    return RedirectToAction("Index");
                }
                return View(meter);
            }
            catch
            {
                return View();
            }
        }

        // GET: Meter/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Meter/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Meter/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Meter/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}