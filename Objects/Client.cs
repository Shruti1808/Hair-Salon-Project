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

  }
}
