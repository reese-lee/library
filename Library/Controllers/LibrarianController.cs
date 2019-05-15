using Microsoft.AspNetCore.Mvc;
using Library.Models;

namespace Library.Controllers
{
   public class LibrarianController : Controller
   {

     [HttpGet("/librarian")]
     public ActionResult Index()
     {
       return View();
     }

     [HttpPost("/librarian")]
     public ActionResult Index(string title, string author)
     {
       Book newBook = new Book(title);
       Author newAuthor = new Author(author);
       newBook.Save();
       newAuthor.Save();
       return RedirectToAction();
     }

     // page where librarian can update/delete book
     // [HttpGet("/librarian/books/show")]
     // public ActionResult Show()
     // {
     //   List<Book>
     // }

   }
}
