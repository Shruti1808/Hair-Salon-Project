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
    public void Test_EqualOverride_ReturnsTrueIfNamesAreTheSame()
    {
      //Arrange, Act
      Client firstClient = new Client("Becky",1);
      Client secondClient = new Client("Becky",1);

      //Assert
      Assert.Equal(firstClient,secondClient);
    }

    [Fact]
    public void Test_NewClient_SavesToDatabase()
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

    [Fact]
    public void Test_EditClient_UpdatesClientInDatabase()
    {
      //Arrange
      string clientname = "Beck";
      Client testClient = new Client(clientname, 1);
      testClient.Save();
      string newClientName = "Becky";

      //Act
      testClient.Update(newClientName);

      string result = testClient.GetName();

      //Assert
      Assert.Equal(newClientName, result);
    }

    [Fact]
    public void Test_Find_FindsClientInDatabase()
    {
      //Arrange
      Client testClient = new Client("Beck",1);
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.GetId());
      Console.WriteLine(testClient);
      Console.WriteLine(foundClient);

      //Assert
      Assert.Equal(testClient, foundClient);
    }
  }
}
