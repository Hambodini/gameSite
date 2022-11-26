using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gameSite.Models;

namespace gameSite.Controllers
{
    public class PlayerItemsDBController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlayerItemsDB
        public ActionResult Index()
        {
            return View(db.PlayerItems.ToList());
        }
        public ActionResult IndexByUser()
        {
            return View("IndexByUser", db.PlayerItems.ToList());
        }

        // GET: PlayerItemsDB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerItem playerItem = db.PlayerItems.Find(id);
            if (playerItem == null)
            {
                return HttpNotFound();
            }
            return View(playerItem);
        }

        // GET: PlayerItemsDB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerItemsDB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Userid,Itemid,Quantity,Useremail")] PlayerItem playerItem)
        {
            if (ModelState.IsValid)
            {
                db.PlayerItems.Add(playerItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playerItem);
        }

        // GET: PlayerItemsDB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerItem playerItem = db.PlayerItems.Find(id);
            if (playerItem == null)
            {
                return HttpNotFound();
            }
            return View(playerItem);
        }

        // POST: PlayerItemsDB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Userid,Itemid,Quantity,Useremail")] PlayerItem playerItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playerItem);
        }

        // GET: PlayerItemsDB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerItem playerItem = db.PlayerItems.Find(id);
            if (playerItem == null)
            {
                return HttpNotFound();
            }
            return View(playerItem);
        }

        // POST: PlayerItemsDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerItem playerItem = db.PlayerItems.Find(id);
            db.PlayerItems.Remove(playerItem);
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
