using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmBook_v7.Models;

/* The Guides controller simply was used to enable a scaffolded CRUD matrix for administrative 
 * purposes such that agricultural guides could be created & modified appropriately*/
 
namespace FarmBook_v7.Controllers
{
    public class GuidesController : Controller
    {
        private FarmerContext db = new FarmerContext();

        //
        // GET: /Article/

        public ActionResult Index()
        {
            return View(db.Guides.ToList());
        }

        //
        // GET: /Article/Details/5

        public ActionResult Details(int id = 0)
        {
            Guide article = db.Guides.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // GET: /Article/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Article/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guide article)
        {
            if (ModelState.IsValid)
            {
                db.Guides.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        //
        // GET: /Article/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Guide article = db.Guides.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // POST: /Article/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guide article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        //
        // GET: /Article/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Guide article = db.Guides.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // POST: /Article/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guide article = db.Guides.Find(id);
            db.Guides.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}