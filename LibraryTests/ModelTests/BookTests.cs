using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Models;
using System.Collections.Generic;
using System;

namespace Library.Tests
{
  [TestClass]
  public class LibraryTest : IDisposable
  {

    public void Dispose()
    {
      Book.ClearAll();
    }

    public LibraryTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=library_test;";
    }

    [TestMethod]
    public void BookConstructor_CreatesInstanceOfBook_Book()
    {
      Book newBook = new Book("test");
      Assert.AreEqual(typeof(Book), newBook.GetType());
    }

  [TestMethod]
   public void GetAll_BooksEmptyAtFirst_List()
   {
     //Arrange, Act
     int result = Book.GetAll().Count;

     //Assert
     Assert.AreEqual(0, result);
   }
  
   [TestMethod]
    public void GetAll_BooksNotEmpty_List()
    {
      //Arrange, Act
      Book test = new Book("Test");
      test.Save();
      int result = Book.GetAll().Count;

      //Assert
      Assert.AreEqual(1, result);
    }
  //
  //   [TestMethod]
  //   public void GetName_ReturnsName_String()
  //   {
  //     //Arrange
  //     string name = "Shelley Miles";
  //     Book newBook = new Book(name);
  //
  //     //Act
  //     string result = newBook.GetName();
  //
  //     //Assert
  //     Assert.AreEqual(name, result);
  //   }
  //
  //   [TestMethod]
  //   public void GetAll_ReturnsEmptyList_BookList()
  //   {
  //     //Arrange
  //     List<Book> newList = new List<Book> { };
  //
  //     //Act
  //     List<Book> result = Book.GetAll();
  //
  //     //Assert
  //     CollectionAssert.AreEqual(newList, result);
  //   }
  //
  //   [TestMethod]
  //   public void GetAll_ReturnsBooks_BookList()
  //   {
  //     //Arrange
  //     Book newBook1 = new Book("Lydia Goh");
  //     newBook1.Save();
  //     Book newBook2 = new Book("Nancy Wing");
  //     newBook2.Save();
  //     List<Book> newList = new List<Book> { newBook1, newBook2 };
  //
  //     //Act
  //     List<Book> result = Book.GetAll();
  //
  //     //Assert
  //     // This is a way to avoid the CollectionAssert error that says "(Element at index 0 do not match)", because we are working with databases now.
  //     Assert.AreEqual(newList[0].GetName(), result[0].GetName());
  //   }
  //
  //   [TestMethod]
  //   public void Find_ReturnsCorrectBookFromDatabase_Book()
  //   {
  //     //Arrange
  //     Book testBook = new Book("Hua-Min Rae");
  //     testBook.Save();
  //
  //     //Act
  //     Book foundBook = Book.Find(testBook.GetId());
  //
  //     //Assert
  //     Assert.AreEqual(testBook, foundBook);
  //   }
  //
  //   [TestMethod]
  //   public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
  //   {
  //     // Arrange, Act
  //     Client firstClient = new Client("Lindsey Mules", 1, 2);
  //     Client secondClient = new Client("Lindsey Mules", 1, 2);
  //
  //     // Assert
  //     Assert.AreEqual(firstClient, secondClient);
  //   }
  //
  //   [TestMethod]
  //   public void Save_SavesToDatabase_ClientList()
  //   {
  //     //Arrange
  //     Client testClient = new Client("Laura Gingham", 3, 1);
  //
  //     //Act
  //     testClient.Save();
  //     List<Client> result = Client.GetAll();
  //     List<Client> testList = new List<Client>{testClient};
  //
  //     //Assert
  //     CollectionAssert.AreEqual(testList, result);
  //   }
  //
  //   [TestMethod]
  //   public void Save_AssignsIdToObject_Id()
  //   {
  //     //Arrange
  //     Client testClient = new Client("Erin Jung", 1, 2);
  //
  //     //Act
  //     testClient.Save();
  //     Client savedClient = Client.GetAll()[0];
  //
  //     int result = savedClient.Id;
  //     int testId = testClient.Id;
  //
  //     //Assert
  //     Assert.AreEqual(testId, result);
  //   }
  //
  //   [TestMethod]
  //   public void Edit_UpdatesClientInDatabase_String()
  //   {
  //     //Arrange
  //     Client testClient = new Client("Lolo Lee", 1, 2);
  //     testClient.Save();
  //     string secondName = "Lola Lee";
  //
  //     //Act
  //     testClient.Edit(secondName);
  //     string result = Client.Find(testClient.Id).Name;
  //
  //     //Assert
  //     Assert.AreEqual(secondName, result);
  //   }
  //
  //   [TestMethod]
  //   public void GetStylistId_ReturnsClientsParentStylistId_Int()
  //   {
  //     //Arrange
  //     Stylist newStylist = new Stylist("Sheila Moore", "Hair dying", 0);
  //     Client newClient = new Client("Wallace Tan", newStylist.Id, 1);
  //
  //     //Act
  //     int result = newClient.StylistId;
  //
  //     //Assert
  //     Assert.AreEqual(newStylist.Id, result);
  //   }

  }
}
