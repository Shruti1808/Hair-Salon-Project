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
        return View["index.cshtml"];
      };

      Get["/clients"] = _ => {
        List<Client> AllClients = Client.GetAll();
        return View["clients.cshtml", AllClients];
      };

      Get["/stylists"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };

      Get["/stylists/{id}"] = parameters => {
        var SelectedStylist = Stylist.Find(parameters.id);
        Model.Add("stylist", SelectedStylist);
        return View["stylists.cshtml",SelectedStylist];
      };

      Get["/stylists/new"] = _ => {
        return View["stylists_edit.cshtml"];
      };

    }
  }
}
