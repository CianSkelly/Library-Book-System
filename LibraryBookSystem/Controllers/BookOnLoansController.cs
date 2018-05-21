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
    public class BookOnLoansController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: BookOnLoans
        //added .Where(b => b.ActualDateReturned == null);
        public ActionResult Index()
        {
            var bookOnLoans = db.BookOnLoans.Include(b => b.Book).Include(b => b.LibUser).Where(b => b.ActualDateReturned == null);
            return View(bookOnLoans.ToList());
        }

        ////****Books that are on loan****
        //SELECT Book.Title, Book.ISBN, BookOnLoan.DateDueForReturn
        //From Books
        //INNER JOIN BookOnLoan on Book.BookID
        //Where BookOnLoan.DateDueForReturn > DateTime.today && BookOnLoan.ActualDateReturned ==Null


        // GET: BookOnLoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookOnLoan bookOnLoan = db.BookOnLoans.Find(id);
            if (bookOnLoan == null)
            {
                return HttpNotFound();
            }
            return View(bookOnLoan);
        }

        // GET: BookOnLoans/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.Books, "BookID", "ISBN");
            ViewBag.UserID = new SelectList(db.LibUsers, "UserID", "FirstName");
            return View();
        }

        // POST: BookOnLoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OnLoanID,UserID,BookID,DateIssued,DateDueForReturn,ActualDateReturned")] BookOnLoan bookOnLoan)
        {
            if (ModelState.IsValid)
            {
                db.BookOnLoans.Add(bookOnLoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.Books, "BookID", "ISBN", bookOnLoan.BookID);
            ViewBag.UserID = new SelectList(db.LibUsers, "UserID", "FirstName", bookOnLoan.UserID);
            return View(bookOnLoan);
        }

        // GET: BookOnLoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookOnLoan bookOnLoan = db.BookOnLoans.Find(id);
            if (bookOnLoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "ISBN", bookOnLoan.BookID);
            ViewBag.UserID = new SelectList(db.LibUsers, "UserID", "FirstName", bookOnLoan.UserID);
            return View(bookOnLoan);
        }

        // POST: BookOnLoans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Book.Title,OnLoanID,UserID,BookID,DateIssued,DateDueForReturn")] BookOnLoan bookOnLoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookOnLoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "ISBN", bookOnLoan.BookID);
            ViewBag.UserID = new SelectList(db.LibUsers, "UserID", "FirstName", bookOnLoan.UserID);
            return View(bookOnLoan);
        }

        // GET: BookOnLoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookOnLoan bookOnLoan = db.BookOnLoans.Find(id);
            if (bookOnLoan == null)
            {
                return HttpNotFound();
            }
            return View(bookOnLoan);
        }

        // POST: BookOnLoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookOnLoan bookOnLoan = db.BookOnLoans.Find(id);
            db.BookOnLoans.Remove(bookOnLoan);
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
