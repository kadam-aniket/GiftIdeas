using GiftIdeas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GiftIdeas.Areas.Admin.Controllers
{
    public class GiftController : Controller
    {
        // GET: Admin/Gift
        private GiftIdeasContext db = new GiftIdeasContext();
        public ActionResult Index()
        {
            var y = db.Gifts.ToList();
            return View(y);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.occassion = db.Occassions.ToList();
            ViewBag.GiftCategory = db.GiftCategories.ToList();
            ViewBag.giftforwhom = db.GiftForWhoms.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(string inputpara, List<int>xyz, List<int> giftcatlist, List<int> giftforwhomlist)
        {
            Gift giftobj = new Gift();
            
            giftobj.GiftIdCategoryIds = new List<GiftIdCategoryId>();
            
            giftobj.Name = inputpara;
           
            foreach (var item in xyz)
            {
                GiftIdCategoryId giftcategory = new GiftIdCategoryId();
                giftcategory.CategoryId = item;

                giftobj.GiftIdCategoryIds.Add(giftcategory);
                //db.GiftIdCategoryIds.Add(giftcategory);
                // db.SaveChanges();
            }

            //int gId = giftobj.Id;
            //foreach (var x in giftcatlist)
            //{
            //    GiftIdJoinGiftCatagoryId giftcatobj = new GiftIdJoinGiftCatagoryId();
            //    giftcatobj.GiftId = gId;
            //    giftcatobj.GiftCategoryId = x;
            //    db.GiftIdJoinGiftCatagoryIds.Add(giftcatobj);
            //    db.SaveChanges();
            //}

            //foreach (var GiftRecipient in giftforwhomlist)
            //{
            //    GiftIdJoinGiftforwhomId objmapping = new GiftIdJoinGiftforwhomId();
            //    objmapping.GiftId = gId;
            //    objmapping.GiftForwhomId = GiftRecipient;       //GiftRecipient is variable
            //    db.GiftIdJoinGiftforwhomIds.Add(objmapping);
            //    db.SaveChanges();
            //}

            db.Gifts.Add(giftobj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.occassion = db.Occassions.ToList();
            Gift giftobj = db.Gifts.Find(id);
            return View(giftobj);
        }
        [HttpPost]
        public ActionResult Edit(Gift giftobj)
        {
            db.Entry(giftobj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
           
           List<GiftIdCategoryId>gc =db.GiftIdCategoryIds.Where(c => c.GiftId == id).ToList();
            foreach (var item in gc)
            {
                db.GiftIdCategoryIds.Remove(item);
                db.SaveChanges();
            }
            

            Gift giftobj = db.Gifts.Find(id);
            db.Gifts.Remove(giftobj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            ViewBag.occassions = (from d in db.GiftIdCategoryIds
                             join f in db.Occassions
                             on d.CategoryId equals f.Id
                             where d.GiftId ==id
                             select f.Occassion_Name).ToList();

            Gift giftobj = db.Gifts.Find(id);
            return View(giftobj);
        }

        public ActionResult Save_DeleteGiftIdCatId(int GiftId,int occassionId, bool IsSelect)
        {
           
            
            if (IsSelect)
            {
                GiftIdCategoryId objgc = new GiftIdCategoryId();
                objgc.GiftId = GiftId;
                objgc.CategoryId = occassionId;
                db.GiftIdCategoryIds.Add(objgc);
                db.SaveChanges();
            }
            else
            {
                GiftIdCategoryId objGiftCat = db.GiftIdCategoryIds.Where(a => a.GiftId == GiftId && a.CategoryId == occassionId).First();
                
                db.GiftIdCategoryIds.Remove(objGiftCat);
                db.SaveChanges();
            }
            return View();
        }
    }
}