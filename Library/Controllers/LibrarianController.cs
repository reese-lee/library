using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
   public class LibrarianController : Controller
   {

     [HttpGet("/librarian")]
     public ActionResult Index()
     {
       return View();
     }

     //[HttpGet("/librarian/books/show")] with update/delete/cancel
   }
}
