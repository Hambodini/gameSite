using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gameSite.Models;
using Microsoft.AspNet.Identity;

namespace gameSite.Controllers
{
    public class ShopItemsDBController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShopItemsDB
        public ActionResult Index()
        {
            return View(db.ShopItems.ToList());
        }
        public ActionResult Buy(int? id)
        {
            //get the game
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            // get the user
            var Userid = User.Identity.GetUserId();
            var user = db.Users.Find(Userid);
            //conditions for validating payment
            if (user.Caps > game.UnlockCost)
            {
                user.Caps -= game.UnlockCost;
                db.SaveChanges();
            }
            else
            {
                ViewBag.error = "not enough caps";
            }

            return RedirectToAction("Index");
        }

        // GET: ShopItemsDB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopItem shopItem = db.ShopItems.Find(id);
            if (shopItem == null)
            {
                return HttpNotFound();
            }
            return View(shopItem);
        }

        // GET: ShopItemsDB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopItemsDB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Itemid,Price,Name")] ShopItem shopItem)
        {
            if (ModelState.IsValid)
            {
                db.ShopItems.Add(shopItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shopItem);
        }

        // GET: ShopItemsDB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopItem shopItem = db.ShopItems.Find(id);
            if (shopItem == null)
            {
                return HttpNotFound();
            }
            return View(shopItem);
        }

        // POST: ShopItemsDB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Itemid,Price,Name")] ShopItem shopItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shopItem);
        }

        // GET: ShopItemsDB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopItem shopItem = db.ShopItems.Find(id);
            if (shopItem == null)
            {
                return HttpNotFound();
            }
            return View(shopItem);
        }

        // POST: ShopItemsDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShopItem shopItem = db.ShopItems.Find(id);
            db.ShopItems.Remove(shopItem);
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
