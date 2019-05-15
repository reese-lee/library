using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Models;
using System.Collections.Generic;
using System;

namespace Library.Tests
{
  [TestClass]
  public class AuthorTest : IDisposable
  {

    public void Dispose()
    {
      Author.ClearAll();
    }

    public AuthorTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=library_test;";
    }

    [TestMethod]
    public void AuthorConstructor_CreatesInstanceOfAuthor_Author()
    {
      Author newAuthor = new Author("Kurt Vonnegut");
      Assert.AreEqual(typeof(Author), newAuthor.GetType());
    }

  [TestMethod]
   public void GetAll_AuthorEmptyAtFirst_List()
   {
     //Arrange, Act
     int result = Author.GetAll().Count;

     //Assert
     Assert.AreEqual(0, result);
   }

   [TestMethod]
    public void GetAll_AuthorNotEmpty_List()
    {
      //Arrange, Act
      Author test = new Author("Paulo Coehlo");
      test.Save();
      int result = Author.GetAll().Count;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Mary Shelley";
      Author newAuthor = new Author(name);

      //Act
      string result = newAuthor.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_AuthorList()
    {
      //Arrange
      List<Author> newList = new List<Author> { };

      //Act
      List<Author> result = Author.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAuthors_AuthorList()
    {
      //Arrange
      Author newAuthor1 = new Author("Chuck Palahniuk");
      newAuthor1.Save();
      Author newAuthor2 = new Author("Michael Pollan");
      newAuthor2.Save();
      List<Author> newList = new List<Author> { newAuthor1, newAuthor2 };

      //Act
      List<Author> result = Author.GetAll();

      //Assert
      Assert.AreEqual(newList[0].GetName(), result[0].GetName());
    }

    [TestMethod]
    public void Find_ReturnsCorrectAuthorFromDatabase_Author()
    {
      //Arrange
      Author testAuthor = new Author("Charlotte Bronte");
      testAuthor.Save();

      //Act
      Author foundAuthor = Author.Find(testAuthor.GetId());

      //Assert
      Assert.AreEqual(testAuthor.GetId(), foundAuthor.GetId());
    }
  //
  //   [TestMethod]
  //   public void Equals_ReturnsTrueIfNamesAreTheSame_Book()
  //   {
  //     Book testBook = new Book("The hound of Baskerville");
  //     testBook.Save();
  //     Book foundBook = Book.Find(testBook.GetId());
  //     // Assert
  //     Assert.AreEqual(testBook.GetTitle(), foundBook.GetTitle());
  //   }
  //
  //   [TestMethod]
  //   public void Save_SavesToDatabase_BookList()
  //   {
  //     //Arrange
  //     Book testBook = new Book("Anne of Green Gables");
  //     //Act
  //     testBook.Save();
  //     List<Book> result = Book.GetAll();
  //     List<Book> testList = new List<Book>{testBook};
  //
  //     //Assert
  //     CollectionAssert.AreEqual(testList, result);
  //   }
  //
  //   [TestMethod]
  //   public void Save_AssignsIdToObject_Id()
  //   {
  //     //Arrange
  //     Book testBook = new Book("1984");
  //
  //     //Act
  //     testBook.Save();
  //     Book savedBook = Book.GetAll()[0];
  //
  //     int result = savedBook.GetId();
  //     int testId = testBook.GetId();
  //
  //     //Assert
  //     Assert.AreEqual(testId, result);
  //   }
  //
  //   [TestMethod]
  //   public void Update_UpdatesBookInDatabase_String()
  //   {
  //     //Arrange
  //     Book testBook = new Book("The Alchemist");
  //     testBook.Save();
  //     string secondName = "The Zahir";
  //
  //     //Act
  //     testBook.Update("title", secondName);
  //     string result = Book.Find(testBook.GetId()).GetTitle();
  //
  //     //Assert
  //     Assert.AreEqual(secondName, result);
  //   }

    // [TestMethod]
    // public void GetStylistId_ReturnsBooksParentStylistId_Int()
    // {
    //   //Arrange
    //   Stylist newStylist = new Stylist("Sheila Moore", "Hair dying", 0);
    //   Book newBook = new Book("Wallace Tan", newStylist.Id, 1);
    //
    //   //Act
    //   int result = newBook.StylistId;
    //
    //   //Assert
    //   Assert.AreEqual(newStylist.Id, result);
    // }

  }
}
