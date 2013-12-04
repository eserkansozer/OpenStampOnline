using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StampOnline.Models;

namespace StampOnline.Controllers
{
    public class TestController : Controller
    {

        private IStampContainer _db;

        public TestController(IStampContainer stampContainer)
        {
            _db = stampContainer;
        }

        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View(_db.OStamps.ToList());
        }

        //
        // GET: /Test/Details/5

        public ActionResult Details(int id = 0)
        {
            OStamp ostamp = _db.OStamps.Find(id);
            if (ostamp == null)
            {
                return HttpNotFound();
            }
            return View(ostamp);
        }

        //
        // GET: /Test/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Test/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OStamp ostamp)
        {
            if (ModelState.IsValid)
            {
                _db.OStamps.Add(ostamp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ostamp);
        }

        //
        // GET: /Test/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OStamp ostamp = _db.OStamps.Find(id);
            if (ostamp == null)
            {
                return HttpNotFound();
            }
            return View(ostamp);
        }

        //
        // POST: /Test/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OStamp ostamp)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(ostamp).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ostamp);
        }

        //
        // GET: /Test/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OStamp ostamp = _db.OStamps.Find(id);
            if (ostamp == null)
            {
                return HttpNotFound();
            }
            return View(ostamp);
        }

        //
        // POST: /Test/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OStamp ostamp = _db.OStamps.Find(id);
            _db.OStamps.Remove(ostamp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}