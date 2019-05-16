using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.Models
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
