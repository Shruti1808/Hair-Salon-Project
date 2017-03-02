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
            Get["/"] =_=> {
                return View ["index.cshtml"];
            };
            Get["/stylists"]  =_=> {
                List<Stylist> allStylists = Stylist.GetAll();
                return View["stylists.cshtml",allStylists];
            };

            Get["/stylists/new"] =_=> {
                return View ["stylist_add.cshtml"];
            };

            Post["/stylists/new"]=_=>{
                Stylist newStylist = new Stylist(Request.Form["stylistName"]);
                newStylist.Save();
                List<Stylist> allStylists =Stylist.GetAll();
                return View["stylists.cshtml",allStylists];
            };

            Get["/stylists/{id}"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object>();
                var selectedStylist = Stylist.Find(parameters.id);
                var stylistClients = selectedStylist.GetClients();
                model.Add("stylistkey", selectedStylist);
                model.Add("clientkey", stylistClients);
                return View["stylist_detail.cshtml", model];
            };

            Get["stylists/{id}/clients/new"] = parameters => {
                int stylistId = parameters.id;
                return View ["client_new.cshtml", stylistId];
            };

            Post["/clients/new"]=_=>{
                Client newClient = new Client(Request.Form["clientName"], Request.Form["stylistId"]);
                newClient.Save();
                List<Client> allClients =Client.GetAll();
                return View["clients.cshtml",allClients];
            };






        }
    }
}
