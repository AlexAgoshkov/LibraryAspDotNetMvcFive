using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryOnAspDotNetMvcFive.Models;
using System.Data.Entity;


namespace LibraryOnAspDotNetMvcFive.Controllers
{
    public class HomeController : Controller
    {
        LibraryContext db = new LibraryContext();

        public ActionResult LibraryJournal()
        {
            var book = db.Books.Include(p => p.Reader).Include(g => g.SupplyState);

            return View(book.ToList());
        }

        public ActionResult LibraryReturn()
        {
            var book = db.Books.Include(p => p.Reader).Include(g => g.ReturnState);

            return View(book.ToList());
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BookCatalog()
        {
            var book = db.Books;
            return View(book.ToList());
        }


        [HttpGet]
        public ActionResult ReaderCatalog()
        {
            var read = db.Readers;
            return View(read.ToList());
        }

        [HttpGet]
        public ActionResult GetBook()
        {

            SelectList read = new SelectList(db.Readers, "Id", "FullName");

            SelectList book = new SelectList(db.Books, "Id", "BookTitle");

            SelectList author = new SelectList(db.Books, "Id", "Author");

            SelectList year = new SelectList(db.Books, "Id", "Year");

            ViewBag.Readers = read;

            ViewBag.Books = book;

            ViewBag.Author = author;

            ViewBag.Years = year;

            return View();
        }

        [HttpPost]
        public ActionResult GetBook(Book book)
        {
            //db.Books.Add(books);
            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateReader()
        {

            SelectList read = new SelectList(db.Readers, "Id", "FullName");
            ViewBag.Readers = read;
            return View();
        }

        [HttpPost]
        public ActionResult CreateReader(Reader read)
        {

            db.Readers.Add(read);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = db.Books.Find(id);
            if (book != null)
            {

                SelectList read = new SelectList(db.Readers, "Id", "FullName", book.ReaderId);
                ViewBag.Readers = read;
                return View(book);
            }
            return RedirectToAction("LibraryJournal");
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("LibraryJournal");
        }

        public ActionResult Delete(Book book)
        {
            db.Entry(book).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("LibraryJournal");
        }

    }

}