using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System;

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

     // [HttpGet("/books/{bookId}")]
     // public ActionResult Index(int bookId)
     // {
     //   // List<Book> allBooks = Book.GetAll();
     //   Book thisBook = new Book();
     //   Book.Find(thisBook.GetId());
     //   return View();
     // }
     //
     [HttpGet("/books/{bookId}")]
     public ActionResult Show(int bookId)
     {
       List<Book> allBooks = Book.GetAll();
       Book thisBook = Book.Find(bookId);
       //author.AddAuthorToBook(thisBook);
       return View(thisBook);
     }

     [HttpPost("/books/{bookId}")]
     public ActionResult Show(int bookId, string authorId)
     {
       int newAuthorId = int.Parse(authorId);
       List<Book> allBooks = Book.GetAll();
       Book thisBook = Book.Find(bookId);
       List<Author> allAuthors = Author.GetAll();
       Author thisAuthor = Author.Find(newAuthorId);
       thisAuthor.AddAuthorToBook(thisBook);
       return View(thisBook);
     }

   }
}
