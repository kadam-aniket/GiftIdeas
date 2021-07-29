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
    public class GiftForWhomsController : Controller
    {
        private GiftIdeasContext db = new GiftIdeasContext();

        // GET: Admin/GiftForWhoms
        public ActionResult Index()
        {
            return View(db.GiftForWhoms.ToList());
        }

        // GET: Admin/GiftForWhoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftForWhom giftForWhom = db.GiftForWhoms.Find(id);
            if (giftForWhom == null)
            {
                return HttpNotFound();
            }
            return View(giftForWhom);
        }

        // GET: Admin/GiftForWhoms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GiftForWhoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] GiftForWhom giftForWhom)
        {
            if (ModelState.IsValid)
            {
                db.GiftForWhoms.Add(giftForWhom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giftForWhom);
        }

        // GET: Admin/GiftForWhoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftForWhom giftForWhom = db.GiftForWhoms.Find(id);
            if (giftForWhom == null)
            {
                return HttpNotFound();
            }
            return View(giftForWhom);
        }

        // POST: Admin/GiftForWhoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] GiftForWhom giftForWhom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giftForWhom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giftForWhom);
        }

        // GET: Admin/GiftForWhoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftForWhom giftForWhom = db.GiftForWhoms.Find(id);
            if (giftForWhom == null)
            {
                return HttpNotFound();
            }
            return View(giftForWhom);
        }

        // POST: Admin/GiftForWhoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiftForWhom giftForWhom = db.GiftForWhoms.Find(id);
            db.GiftForWhoms.Remove(giftForWhom);
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
