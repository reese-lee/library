using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Library.Models
{
  public class Patron
  {
    private string _name;
    private int _id;

    public Patron()
    {

    }

    public Patron (string name)
    {
      _name = name;
    }

    public int GetId()
    {
      return _id;
    }


  }
}
