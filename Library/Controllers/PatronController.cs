using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
   public class PatronController : Controller
   {

     [HttpGet("/patron")]
     public ActionResult Index()
     {
       return View();
     }
   }
}
