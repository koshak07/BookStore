using BookStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }

        public IActionResult Index(string sortOrder)
        {
            ViewData["AuthorSortParam"] = string.IsNullOrEmpty(sortOrder) ? "author_desc" : "";
            ViewData["TitleSortParam"] = sortOrder == "title" ? "title_desc" : "title";
            ViewData["YearSortParam"] = sortOrder == "year" ? "year_desc" : "year";

            var books = from b in _context.Books
                        select b;
            //sort
            switch (sortOrder)
            {
                case "author_desc":
                    books = books.OrderByDescending(b => b.Author);
                    break;
                case "title":
                    books = books.OrderBy(b => b.Title);
                    break;
                case "title_desc":
                    books = books.OrderByDescending(b => b.Title);
                    break;
                case "year":
                    books = books.OrderBy(b => b.Year);
                    break;
                case "year_desc":
                    books = books.OrderByDescending(b => b.Year);
                    break;
                default:
                    books = books.OrderBy(b => b.Author);
                    break;
            }

            return View(books.ToList());
        }

        // не требуется по тз
        //public IActionResult Buy(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var book = _context.Books.Find(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Books.Remove(book);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}
    }
}
