using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Library.Models
{
  public class Book
  {
    private string _title;
    private int _id;
    private int _copies;

    public Book()
    {

    }

    public Book(string title)
    {
      _title = title;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetId(int id)
    {
      _id = id;
    }

    public string GetTitle()
    {
      return _title;
    }

    public void SetTitle(string title)
    {
      _title = title;
    }

    public void SetCopies(int copies)
    {
      _copies = copies;
    }

    public int GetCopies()
    {
      return _copies;
    }

    // public void AddAuthorToBook(Book theBook)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM books
    //   JOIN books_authors ON (authors.Id = books_authors.author_id)
    //   JOIN authors ON (books_authors.book_id = books.Id)
    //   WHERE books.Id = @"+theBook.GetId()+";";
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //   conn.Dispose();
    //   }
    //
    // }

    public static Book Find(int check)
    {
      Book book = new Book();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM books where id = "+check+";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      //nested if in a while loop to eliminate an error that was saying "Read must be done first"
      while(rdr.Read())
      {
        if(rdr.IsDBNull(0) == false)
        {
          book.SetId(rdr.GetInt32(0));
          book.SetTitle(rdr.GetString(1));
          // book.SetCopies(rdr.Getint(2));
        }
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return book;
    }

    public static List<Book> GetAll()
    {
      List<Book> allBooks = new List<Book> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM books;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        Book newBook = new Book();
        newBook.SetId(rdr.GetInt32(0));
        newBook.SetTitle(rdr.GetString(1));
        // newBook.SetCopies(rdr.GetInt32(2));
        allBooks.Add(newBook);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allBooks;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM books; DELETE FROM copies;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }

    //check if book exists
    public static Book findBook(string search)
    {
      List<Book> allBooks = Book.GetAll();
      foreach(Book book in allBooks)
      {
        if(book.GetTitle() == search)
        {
          return book;
        }
      }
      Book uselessBook = new Book("");
      return uselessBook;
    }

    public List<int> GetBooksForDoctor()
    {
      List<int> allBooks = new List<int> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `assignment` WHERE `book_id` = "+_id+";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        allBooks.Add(rdr.GetInt32(2));
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allBooks;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `books` (`title`) VALUES ('"+_title+"');";
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Update(string field, string change)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE `books` SET `"+field+"` = '"+change+"' WHERE `books`.`id` = "+_id+";";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    //
    // public void Delete()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"delete from book WHERE `book`.`id` = "+_id+";";
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }

    public override bool Equals(System.Object otherBook)
    {
      if (!(otherBook is Book))
      {
        return false;
      }
      else
      {
         Book newBook = (Book) otherBook;
         bool idEquality = this.GetId() == newBook.GetId();
         bool descriptionEquality = this.GetTitle() == newBook.GetTitle();
         return (idEquality && descriptionEquality);
       }
    }

  }
}
