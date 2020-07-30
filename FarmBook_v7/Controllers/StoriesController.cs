using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmBook_v7.Models;
using System.IO;

/* The Stories controller simply was used to enable a scaffolded CRUD matrix for user
 * end enablement so that they could share or view stories of their liking
 * key additional methods here include:
 * FileUpload() -- this method allows user to upload multiple files like images or videos
 * to reference in their stories;
 * to a maximum size of 2GB, the filePath captures the location of their file to upload
 * and are stored in a Upload folder */

namespace FarmBook_v7.Controllers
{
    public class StoriesController : Controller
    {
        private FarmerContext db = new FarmerContext();

        //
        // GET: /Stories/

        public ActionResult Index()
        {
            return View(db.Stories.ToList());
        }

        //
        // GET: /Stories/Details/5

        public ActionResult Details(int id = 0)
        {
            Story story = db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // GET: /Story/FileUpload
        public ActionResult FileUpload()
        {
            return View();
        }

        // POST: /Story/FileUpload

        [HttpPost]
        public ActionResult FileUpload(Upload fyles)
        {
            foreach (var file in fyles.Files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("/Uploads"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("Create");
        }

        //
        // GET: /Stories/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Stories/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Story story)
        {
            if (ModelState.IsValid)
            {
                db.Stories.Add(story);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(story);
        }

        //
        // GET: /Stories/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Story story = db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        //
        // POST: /Stories/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Story story)
        {
            if (ModelState.IsValid)
            {
                db.Entry(story).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(story);
        }

        //
        // GET: /Stories/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Story story = db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        //
        // POST: /Stories/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Story story = db.Stories.Find(id);
            db.Stories.Remove(story);
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