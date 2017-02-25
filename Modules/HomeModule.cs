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
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        return View["index.cshtml",model];
      };



    }
  }
}
