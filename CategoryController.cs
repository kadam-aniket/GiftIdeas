using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiftIdeas.Models;

namespace GiftIdeas.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private GiftIdeasContext db = new GiftIdeasContext();
        // GET: Admin/Category
        public ActionResult Index()                         //create get method
        {
            
            // var x = db.Catagories.ToList();
            var x = db.Occassions.ToList();
            return View(x);
        }
        public ActionResult SaveCategory(string cat)        // create post method
        {
            Occassion occassionobj = new Occassion();
            occassionobj.Occassion_Name = cat;                   //Occassion_Name is a column name  cat is temp var which can hold temporary data
            db.Occassions.Add(occassionobj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Occassion occassionobj = db.Occassions.Find(id);
            return View(occassionobj);
        }
        [HttpPost]
        public ActionResult Edit(Occassion occassionobj)
        {
            db.Entry(occassionobj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult Delete(int id)
        {
            Occassion occassionobj = db.Occassions.Find(id);
            db.Occassions.Remove(occassionobj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Occassion occassionobj = db.Occassions.Find(id);
            return View(occassionobj);
        }
    }
}       