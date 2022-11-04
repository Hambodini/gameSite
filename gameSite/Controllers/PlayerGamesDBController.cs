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
    public class PlayerGamesDBController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlayerGamesDB
        public ActionResult Index()
        {
            return View(db.PlayerGames.ToList());
        }

        // GET: PlayerGamesDB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerGame playerGame = db.PlayerGames.Find(id);
            if (playerGame == null)
            {
                return HttpNotFound();
            }
            return View(playerGame);
        }

        // GET: PlayerGamesDB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerGamesDB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Gameid,Userid,Useremail")] PlayerGame playerGame)
        {
            if (ModelState.IsValid)
            {
                db.PlayerGames.Add(playerGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playerGame);
        }

        // GET: PlayerGamesDB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerGame playerGame = db.PlayerGames.Find(id);
            if (playerGame == null)
            {
                return HttpNotFound();
            }
            return View(playerGame);
        }

        // POST: PlayerGamesDB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Gameid,Userid,Useremail")] PlayerGame playerGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playerGame);
        }

        // GET: PlayerGamesDB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerGame playerGame = db.PlayerGames.Find(id);
            if (playerGame == null)
            {
                return HttpNotFound();
            }
            return View(playerGame);
        }

        // POST: PlayerGamesDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerGame playerGame = db.PlayerGames.Find(id);
            db.PlayerGames.Remove(playerGame);
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
