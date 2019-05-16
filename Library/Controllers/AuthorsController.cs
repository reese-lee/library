using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
   public class AuthorsController : Controller
   {

     [HttpGet("/authors")]
     public ActionResult Index(string author)
     {
       Author newAuthor = new Author(author);
       newAuthor.Save();
       List<Author> allAuthors = Author.GetAll();
       return View();
     }
   }
}
