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

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Author()
    {
      Author testAuthor = new Author("Jonathan Safran Foer");
      testAuthor.Save();
      Author foundAuthor = Author.Find(testAuthor.GetId());
      // Assert
      Assert.AreEqual(testAuthor.GetName(), foundAuthor.GetName());
    }

    [TestMethod]
    public void Save_SavesToDatabase_AuthorList()
    {
      //Arrange
      Author testAuthor = new Author("Tom Clancy");
      //Act
      testAuthor.Save();
      List<Author> result = Author.GetAll();
      List<Author> testList = new List<Author>{testAuthor};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Author testAuthor = new Author("1984");

      //Act
      testAuthor.Save();
      Author savedAuthor = Author.GetAll()[0];

      int result = savedAuthor.GetId();
      int testId = testAuthor.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Update_UpdatesAuthorInDatabase_String()
    {
      //Arrange
      Author testAuthor = new Author("Dennis Lehane");
      testAuthor.Save();
      string secondName = "Jonathan Krakauer";

      //Act
      testAuthor.Update("name", secondName);
      string result = Author.Find(testAuthor.GetId()).GetName();

      //Assert
      Assert.AreEqual(secondName, result);
    }

    // [TestMethod]
    // public void GetStylistId_ReturnsAuthorsParentStylistId_Int()
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
