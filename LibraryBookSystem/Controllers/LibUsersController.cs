using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryBookSystem.Models;

namespace LibraryBookSystem.Controllers
{
    public class LibUsersController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: LibUsers May need to change ActionResults to ViewResults
        public ActionResult Index()
        {
            return View(db.LibUsers.ToList());
        }

        // GET: LibUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibUser libUser = db.LibUsers.Find(id);
            if (libUser == null)
            {
                return HttpNotFound();
            }
            return View(libUser);
        }

        // GET: LibUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FirstName,LastName,UserName,Email,Phone")] LibUser libUser)
        {
            if (ModelState.IsValid)
            {
                db.LibUsers.Add(libUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libUser);
        }

        // GET: LibUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibUser libUser = db.LibUsers.Find(id);
            if (libUser == null)
            {
                return HttpNotFound();
            }
            return View(libUser);
        }

        // POST: LibUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,UserName,Email,Phone")] LibUser libUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libUser);
        }

        // GET: LibUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibUser libUser = db.LibUsers.Find(id);
            if (libUser == null)
            {
                return HttpNotFound();
            }
            return View(libUser);
        }

        // POST: LibUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibUser libUser = db.LibUsers.Find(id);
            db.LibUsers.Remove(libUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: LibUsers
        public string DoOtherStuff()
        {
            return "this is the Library User method";
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
