using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GiftIdeas.Models;

namespace GiftIdeas.Areas.Admin.Controllers
{
    public class GiftCategoriesController : Controller
    {
        private GiftIdeasContext db = new GiftIdeasContext();

        // GET: Admin/GiftCategories
        public ActionResult Index()
        {
            return View(db.GiftCategories.ToList());
        }

        // GET: Admin/GiftCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftCategory giftCategory = db.GiftCategories.Find(id);
            if (giftCategory == null)
            {
                return HttpNotFound();
            }
            return View(giftCategory);
        }

        // GET: Admin/GiftCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GiftCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] GiftCategory giftCategory)
        {
            if (ModelState.IsValid)
            {
                db.GiftCategories.Add(giftCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giftCategory);
        }

        // GET: Admin/GiftCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftCategory giftCategory = db.GiftCategories.Find(id);
            if (giftCategory == null)
            {
                return HttpNotFound();
            }
            return View(giftCategory);
        }

        // POST: Admin/GiftCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] GiftCategory giftCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giftCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giftCategory);
        }

        // GET: Admin/GiftCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftCategory giftCategory = db.GiftCategories.Find(id);
            if (giftCategory == null)
            {
                return HttpNotFound();
            }
            return View(giftCategory);
        }

        // POST: Admin/GiftCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiftCategory giftCategory = db.GiftCategories.Find(id);
            db.GiftCategories.Remove(giftCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
