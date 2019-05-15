using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;

namespace Library.Controllers
{
   public class BooksController : Controller
   {

     [HttpGet("/books")]
     public ActionResult Index()
     {
       List<Book> allBooks = Book.GetAll();
       return View(allBooks);
     }

     //[HttpGet("/librarian/books/show")] with update/delete/Cancel


   }
}
