using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OTMST.Models;
using System.IO;


namespace OTMST.Controllers
{
    public class ArtisansController : Controller
    {

        private OTMST_Entities db = new OTMST_Entities()
        {
            
        };
        


        // GET: Artisans
        [OutputCache(Duration = 86400, VaryByParam = "none")]
        public ActionResult Index()
        {
            //return View();
            var artisans = from a in db.tblOTMST_Artisans where a.ArtisanStatus=="Active" orderby a.LastName
                           select a;
            return View(artisans.ToList());
        }

        // GET: Artisans/List
        [OutputCache(Duration = 0, VaryByParam = "none")]
        public ActionResult List(string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "last_name_desc" : "";
            ViewBag.FirstNameSortParm = sortOrder == "first_name" ? "first_name_desc" : "first_name";
            ViewBag.ArtSortParm = sortOrder == "art" ? "art_desc" : "art";
            ViewBag.TourStopSortParm = sortOrder == "tourstop" ? "tourstop_desc" : "tourstop";
            ViewBag.BusinessNameSortParm = sortOrder == "business_name" ? "business_name_desc" : "business_name";
            var artisans = from a in db.tblOTMST_Artisans where a.ArtisanStatus=="Active" orderby a.LastName
                           select a;
            switch (sortOrder)
            {
                case "last_name_desc":
                    artisans = artisans.OrderByDescending(e => e.LastName);
                    break;
                case "first_name_desc":
                    artisans = artisans.OrderByDescending(e => e.FirstName);
                    break;
                case "first_name":
                    artisans = artisans.OrderBy(e => e.FirstName);
                    break;
                case "art_desc":
                    artisans = artisans.OrderByDescending(e => e.Art);
                    break;
                case "art":
                    artisans = artisans.OrderBy(e => e.Art);
                    break;
                case "tourstop_desc":
                    artisans = artisans.OrderByDescending(e => e.TourStop);
                    break;
                case "tourstop":
                    artisans = artisans.OrderBy(e => e.TourStop);
                    break;
                case "business_name_desc":
                    artisans = artisans.OrderByDescending(e => e.BusinessName);
                    break;
                case "business_name":
                    artisans = artisans.OrderBy(e => e.BusinessName);
                    break;
            }
            return View(artisans.ToList());
        }


        // GET: Artisans/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblOTMST_Artisan tblOTMST_Artisan = db.tblOTMST_Artisan.Find(id);
        //    if (tblOTMST_Artisan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblOTMST_Artisan);
        //}

        // GET: Artisans/Details/Bowers
        public ActionResult Show(string searchString)
        {
            //var artisans = from a in db.tblOTMST_Artisan select a;

            //var query = from a in db.tblOTMST_Artisan
            //            where a.LastName==searchString
            //            select a;
            //tblOTMST_Artisan tblOTMST_Artisan = new tblOTMST_Artisan();

            tblOTMST_Artisans tblOTMST_Artisans = db.tblOTMST_Artisans.SqlQuery("SELECT * FROM tblOTMST_Artisans WHERE LastName='" + searchString + "'").Single();
            try
            {
                tblOTMST_Artisans.Images = Directory.EnumerateFiles(Server.MapPath("~/Content/Images/ArtisansOptimized/" + searchString))
                              .Select(fn => "~/Content/Images/ArtisansOptimized/" + searchString + "/" + Path.GetFileName(fn));
            }
            catch (Exception) {
                tblOTMST_Artisans.Images = null;
            };

           if (tblOTMST_Artisans == null)
            {
                return HttpNotFound();
            }
            return View(tblOTMST_Artisans);
        }


    }
}
