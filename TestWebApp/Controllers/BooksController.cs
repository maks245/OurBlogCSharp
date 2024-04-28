using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class BooksController : Controller
    {
        LibraryDb libraryDb;

        public BooksController()
        {
            libraryDb = LibraryDb.Instance;
        }

        // get: bookscontroller
        public ActionResult BookList()
        {
            return View(libraryDb.Books);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            var book = libraryDb.Books.FirstOrDefault(x => x.Id == id);

            return View(book);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var book = libraryDb.Books.FirstOrDefault(x => x.Id == id);
            return View(book);
        }

        // POST: BooksController/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book, int id)
        {
            var bookToEdit = libraryDb.Books.FirstOrDefault();

            bookToEdit.Title = book.Title;
            bookToEdit.Description = book.Description;
            
            return Redirect("/");
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
