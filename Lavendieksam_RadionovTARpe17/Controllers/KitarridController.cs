using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lavendieksam_RadionovTARpe17.Models;

namespace Lavendieksam_RadionovTARpe17.Controllers
{
    public class KitarridController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Kitarrid
        public ActionResult Index()
        {
            return View(db.Kitarrs.ToList());
        }

        // GET: Kitarrid/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitarr kitarr = db.Kitarrs.Find(id);
            if (kitarr == null)
            {
                return HttpNotFound();
            }
            return View(kitarr);
        }

        // GET: Kitarrid/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kitarrid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Mudel,Hind")] Kitarr kitarr)
        {
            if (ModelState.IsValid)
            {
                db.Kitarrs.Add(kitarr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kitarr);
        }

        // GET: Kitarrid/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitarr kitarr = db.Kitarrs.Find(id);
            if (kitarr == null)
            {
                return HttpNotFound();
            }
            return View(kitarr);
        }

        // POST: Kitarrid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mudel,Hind")] Kitarr kitarr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kitarr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kitarr);
        }

        // GET: Kitarrid/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitarr kitarr = db.Kitarrs.Find(id);
            if (kitarr == null)
            {
                return HttpNotFound();
            }
            return View(kitarr);
        }

        // POST: Kitarrid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kitarr kitarr = db.Kitarrs.Find(id);
            db.Kitarrs.Remove(kitarr);
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
