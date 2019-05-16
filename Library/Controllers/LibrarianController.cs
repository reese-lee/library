
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
    public ActionResult Index(string title)
    {
      Book newBook = new Book(title);
      // Author newAuthor = new Author(author);
      newBook.Save();
      // newAuthor.Save();
      return RedirectToAction();
    }

    // [HttpPost("/authors")]
    // public ActionResult Index(string author)
    // {
    //   Author newAuthor = new Author(author);
    //   // newBook.Save();
    //   newAuthor.Save();
    //   return RedirectToAction();
    // }

    [HttpPost("/librarian/search/book{id}")]
    public ActionResult Show(string search)
    {
      //check if a book exists
      //if book exists, return book object
      Book findBook = Book.findBook(search);
      if(findBook.GetTitle() == "")
      {
        //Error
        return View("Index");
      }
      else {
        return View("Show", findBook);
      }
    }

    // page where librarian can update/delete book
    // [HttpGet("/librarian/books/show")]
    // public ActionResult Show()
    // {
    //   List<Book>
    // }

  }
}
