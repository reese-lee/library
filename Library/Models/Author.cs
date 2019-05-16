
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Library.Models
{
  public class Author
  {
    private string _name;
    private int _id;

    public Author()
    {

    }

    public Author(string name)
    {
      _name = name;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetId(int id)
    {
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string name)
    {
      _name = name;
    }
    //
    //     public void SetCopies(int copies)
    //     {
    //       _copies = copies;
    //     }
    //
    //     public int GetCopies()
    //     {
    //       return _copies;
    //     }

    public void AddAuthorToBook(Book theBook)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `books_authors` (`book_id`, `author_id`) VALUES ('"+theBook.GetId()+"', "+_id+");";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Author Find(int check)
    {
      Author author = new Author();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM authors where id = "+check+";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      //nested if in a while loop to eliminate an error that was saying "Read must be done first"
      while(rdr.Read())
      {
        if(rdr.IsDBNull(0) == false)
        {
          author.SetId(rdr.GetInt32(0));
          author.SetName(rdr.GetString(1));
          // author.SetCopies(rdr.Getint(2));
        }
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return author;
    }

    // USE JOIN TABLE TO FIND BOOK BY AUTHOR
    // public static Book findBook()
    // {
    //
    // }


    public static List<Author> GetAll()
    {
      List<Author> allAuthors = new List<Author> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM authors;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        Author newAuthor = new Author();
        newAuthor.SetId(rdr.GetInt32(0));
        newAuthor.SetName(rdr.GetString(1));
        // newAuthor.SetCopies(rdr.GetInt32(2));
        allAuthors.Add(newAuthor);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allAuthors;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM authors;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Book> GetBooks()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT books.* FROM authors
      JOIN books_authors ON (authors.id = books_authors.author_id)
      JOIN books ON (books_authors.book_id = books.id)
      WHERE authors.id = @AuthorId;";
      MySqlParameter authorIdParameter = new MySqlParameter();
      authorIdParameter.ParameterName = "@AuthorId";
      authorIdParameter.Value = _id;
      cmd.Parameters.Add(authorIdParameter);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Book> books = new List<Book> {};
      while(rdr.Read())
      {
        // int bookId = rdr.GetInt32(0);
        // string bookTitle = rdr.GetString(1);
        Book book = new Book();
        book.SetId(rdr.GetInt32(0));
        book.SetTitle(rdr.GetString(1));
        books.Add(book);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return books;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `authors` (`name`) VALUES ('"+_name+"');";
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
      cmd.CommandText = @"UPDATE `authors` SET `"+field+"` = '"+change+"' WHERE `authors`.`id` = "+_id+";";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"delete from authors WHERE `authors`.`id` = "+_id+";";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherAuthor)
    {
      if (!(otherAuthor is Author))
      {
        return false;
      }
      else
      {
        Author newAuthor = (Author) otherAuthor;
        bool idEquality = this.GetId() == newAuthor.GetId();
        bool descriptionEquality = this.GetName() == newAuthor.GetName();
        return (idEquality && descriptionEquality);
      }
    }
  }
}
