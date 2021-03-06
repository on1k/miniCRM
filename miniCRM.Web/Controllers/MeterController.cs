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
        // Выводим список всех счетчиков
        public ActionResult Index()
        {
            var meters = dbMeter.GetAll().OrderByDescending(m => m.ElectricMeterID).Select(s => s);
            return View(meters);
        }

        [HttpGet]
        // GET: Создание нового счетчика
        public ActionResult Create()
        {
            return View();
        }

        // POST: Создание нового счетчика
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

        // GET: Ищем по id счетчик и передаем в представление
        public ActionResult Edit(int? id)
        {
            var result = dbMeter.GetOne(id);
            if (result == null)
            {
                return View("Index");
            }
            
            return View(result);
        }

        // POST: Обновляем данные 
        [HttpPost]
        public ActionResult Edit(ElectricMeter meter)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    dbMeter.Edit(meter);
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

        // GET: По id передаем объект для удаления
        public ActionResult Delete(int? id)
        {
            var result = dbMeter.GetOne(id);
            if (result == null)
            {
                return View("Index");
            }

            return View(result);
        }

        // POST: Удаление
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteMeter(ElectricMeter meter)
        {
            try
            {
                // TODO: Add delete logic here
                dbMeter.Delete(meter);
                dbMeter.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
