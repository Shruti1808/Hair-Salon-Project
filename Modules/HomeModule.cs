using System;
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
        List<Stylist> allStylists = Stylist.GetAll();
        List<Client> allClients = Client.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        model.Add("clients", allClients);
        return View["index.cshtml",model];
      };



    }
  }
}
