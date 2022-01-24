using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelExample.Models;


namespace ModelExample.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            List<Books> books = new List<Books>()
            {
                new Books() { BookId = 101, AuthorName = "A.P.J", Rate = 450 },
                new Books() { BookId = 102, AuthorName = "Anurima Roy", Rate = 380 },
                new Books() { BookId = 103, AuthorName = "Ruskin Bond", Rate = 940 }
            };
            return View(books);
        }

        public ActionResult Details(int id)
        {
            List<Books> books = new List<Books>()
            {
                new Books() { BookId = 101, AuthorName = "A.P.J", Rate = 450 },
                new Books() { BookId = 102, AuthorName = "Anurima Roy", Rate = 380 },
                new Books() { BookId = 103, AuthorName = "Ruskin Bond", Rate = 940 }
            };
            Books matchingBook = null;
            foreach (var item in books)
            {
                if (item.BookId == id)
                {
                    matchingBook = item;
                }
            }
            return View(matchingBook);
        }
    }
}
