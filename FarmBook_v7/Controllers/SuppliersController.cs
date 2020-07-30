using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmBook_v7.Models;

/* The Suppliers controller simply was used to enable a scaffolded CRUD matrix for administrative 
 * purposes of creating our own tailored suppliers that are recommended to the users based on
 * locational settngs e.g suppliers in the Eastern Cape province 
 */

namespace FarmBook_v7.Controllers
{
    public class SuppliersController : Controller
    {
        //private SupplierContext db = new SupplierContext();
        private FarmerContext db = new FarmerContext();
        //
        // GET: /Supplier/

        public ActionResult Index()
        {
            List<Supplier> suppliers = db.Suppliers.ToList();
            return View(suppliers);
        }

        //
        // GET: /Supplier/Details/5

        public ActionResult Details(int id = 0)
        {
            Supplier supplier = db.Suppliers.Single(sup => sup.SupplierID == id);
            return View(supplier);
        }

        //
        // GET: /Supplier/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Supplier/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        //
        // GET: /Supplier/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        //
        // POST: /Supplier/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        //
        // GET: /Supplier/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        //
        // POST: /Supplier/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // search crop
        public ActionResult Search(string supplierLocation)
        {
            var LocationLst = new List<string>();

            var SuppQry = from d in db.Suppliers
                          orderby d.SupplierLocation
                          select d.SupplierLocation;

            LocationLst.AddRange(SuppQry.Distinct());
            ViewBag.supplierLocation = new SelectList(LocationLst);

            var suppliers = from cr in db.Suppliers
                        select cr;
            //var c = suppliers;

            // when search specification actual target is null/void
            if (string.IsNullOrEmpty(supplierLocation))
            {
                return View(suppliers);
            }
            else
            {
                return View(suppliers.Where(x => x.SupplierLocation == supplierLocation));
            }

        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}