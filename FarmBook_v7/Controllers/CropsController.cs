using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmBook_v7.Models;

/* The Crops controller is the most essential class with regards to the FarmBook application
 * It was scaffolded using the CRUD matrix
 * the additional methods here include:
 * Search() -- that searches for a specific crop based on a textual string entry
 * GettingStarted() -- provides an accordion droplist encaspulated with farming starter info captured in its view
 * GuideSelection() -- simple method that allows a list of farming guide options to be displayed 
 */

namespace FarmBook_v7.Controllers
{
    public class CropsController : Controller
    {
        //private CropDBContext db = new CropDBContext();
        private FarmerContext db = new FarmerContext();
        //
        // GET: /Crop/

        public ActionResult Index()
        {
            return View(); //return View(db.Crops.ToList());
        }

        //
        // GET: /Crop/Details/5

        public ActionResult Details(int id = 0)
        {
            Crop crop = db.Crops.Find(id);
            if (crop == null)
            {
                return HttpNotFound();
            }
            return View(crop);
        }

        //
        // GET: /Crop/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Crop/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Crop crop)
        {
            if (ModelState.IsValid)
            {
                db.Crops.Add(crop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crop);
        }

        //
        // GET: /Crop/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Crop crop = db.Crops.Find(id);
            if (crop == null)
            {
                return HttpNotFound();
            }
            return View(crop);
        }

        //
        // POST: /Crop/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Crop crop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crop);
        }

        //
        // GET: /Crop/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Crop crop = db.Crops.Find(id);
            if (crop == null)
            {
                return HttpNotFound();
            }
            return View(crop);
        }

        //
        // POST: /Crop/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crop crop = db.Crops.Find(id);
            db.Crops.Remove(crop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // search crop
        //public ActionResult Search(string cropLocation, string searchString) 
        public ActionResult Search(string searchString) 
        { 
            /*var LocationLst = new List<string>(); 
 
            var CropQry = from d in db.Crops
                               orderby d.CropLocation 
                               select d.CropLocation; 
            
            LocationLst.AddRange(CropQry.Distinct()); 
            ViewBag.cropLocation = new SelectList(LocationLst); 
            */
            var crops = from cr in db.Crops
                         select cr;

            // user has keyed in search specification
            if (!String.IsNullOrEmpty(searchString))
            {
                crops = crops.Where(s => s.CropName.Contains(searchString));
            }
            
            
            /*
            // when search specification actual target is null/void
            if (string.IsNullOrEmpty(cropLocation)) 
            {
                return View(crops); 
            }
            else 
            {
                return View(crops.Where(x => x.CropLocation == cropLocation)); 
            }
            */
            return View(crops);
            
        }

        public ActionResult CropSelection(string dropItem)
        {
            return View();
        } 

        public ActionResult GettingStarted()
        {
            return View();
        }
        public ActionResult GuideSelection()
        {
            return View();
        }
        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}