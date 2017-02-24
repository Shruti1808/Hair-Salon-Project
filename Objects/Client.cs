using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylistId;

    public Client(string name, int stylistId, int id = 0)
    {
      _id = id;
      _name = name;
      _stylistId = stylistId;
    }

    public string GetName()
    {
      return _name;
    }
    public void SetName()
    {
      _name = name;
    }

    public int GetId()
    {
      return _id;
    }

    public int GetStylistId()
    {
      return _stylistId;
    }

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }


    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId()== newClient.GetId());
        bool nameEquality = (this.GetName() == newClient.GetName());
        bool stylistIdEquality = (this.GetStylistId()== newClient.GetStylistId());

        return (idEquality && nameEquality && stylistIdEquality);
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client>{};

      SqlConnection conn = DB.Connection();
      conn.Open;

      SqlCommand cmd = new SqlCommand("Select * from clients;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int ClientId = rdr.GetInt32(0);
        string ClientName = rdr.GetString(1);
        int clientStylistId = rdr.GetInt32(2);
        Client newClient = new Client (ClientName,clientStylistId,ClientId);
        allClients.Add(newClient);
      }

      if (rdr !=null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allClients;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }



















  }
}
