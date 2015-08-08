using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTMST.Controllers
{
    public class SummerEventController : Controller
    {

        [OutputCache(Duration = 60, VaryByParam = "none")]
        // GET: SummerEvent
        public ActionResult Index()
        {
            return View();
        }

        // GET: SummerEvent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SummerEvent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SummerEvent/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SummerEvent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SummerEvent/Edit/5
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

        // GET: SummerEvent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SummerEvent/Delete/5
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
