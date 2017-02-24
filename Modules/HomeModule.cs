using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {

        return View["index.cshtml",allStylists];
      };

      Get["/clients"] = _ => {
        List<Client> AllClients = Client.GetAll();
        return View["clients.cshtml", AllClients];
      };

      Get["/categories"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["categories.cshtml", AllCategories];
      };
      
    }
  }
}
