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
    public class PlaadidController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Plaadid
        public ActionResult Index()
        {
            return View(db.Plaats.ToList());
        }

		public ActionResult Osta(int id)
		{
			Plaat plaat = db.Plaats.Find(id);
			db.Plaats.Remove(plaat); /*Kustutab antud plaadi loetelust */
			db.SaveChanges(); /*Salvestab muudatused*/
			return RedirectToAction("Index"); /*Saadab tagasi /Plaadid lehele*/
		}

		// GET: Plaadid/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plaat plaat = db.Plaats.Find(id);
            if (plaat == null)
            {
                return HttpNotFound();
            }
            return View(plaat);
        }

        // GET: Plaadid/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plaadid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nimi,Artist,Žanr,Hind")] Plaat plaat)
        {
            if (ModelState.IsValid)
            {
                db.Plaats.Add(plaat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plaat);
        }
		// GET: Plaadid/Edit/5
		[Authorize]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plaat plaat = db.Plaats.Find(id);
            if (plaat == null)
            {
                return HttpNotFound();
            }
            return View(plaat);
        }

        // POST: Plaadid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nimi,Artist,Žanr,Hind")] Plaat plaat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plaat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plaat);
        }

        // GET: Plaadid/Delete/5
		[Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plaat plaat = db.Plaats.Find(id);
            if (plaat == null)
            {
                return HttpNotFound();
            }
            return View(plaat);
        }

        // POST: Plaadid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plaat plaat = db.Plaats.Find(id);
            db.Plaats.Remove(plaat);
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
