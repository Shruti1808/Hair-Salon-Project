using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }

    //Test for empty database in the beginning
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    //Test for Equal override
    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //Arrange, Act
      Client firstClient = new Client("Becky",1);
      Client secondClient = new Client("Becky",1);

      //Assert
      Assert.Equal(firstClient,secondClient);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
        Client testClient = new Client("Becky", 1);

        //Act
        testClient.Save();
        List<Client> result = Client.GetAll();
        List<Client> testList = new List<Client>{testClient};

        //Assert
        Assert.Equal(testList, result);
    }
  }
}
