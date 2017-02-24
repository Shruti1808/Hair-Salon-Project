using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
  public class Stylist
  {
    private int _id;
    private string _clientname;

    public Stylist(string clientname, int id = 0)
    {
      _id = id;
      _clientname = clientname;
    }

    public string GetName()
    {
      return _clientname;
    }

    public int GetId()
    {
      return _id;
    }

    public override bool Equals(System.Object otherStylist)
   {
       if (!(otherStylist is Stylist))
       {
         return false;
       }
       else
       {
         Stylist newStylist = (Stylist) otherStylist;
         bool idEquality = (this.GetId() == newStylist.GetId());
         bool stylistnameEquality = (this.GetName() == newStylist.GetName());
         return (idEquality && stylistnameEquality);
       }
     }


     public static List<Stylist> GetAll()
    {
      List<Stylist> allStylist = new List<Stylist>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylist;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);
        allStylist.Add(newStylist);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allStylist;
    }
