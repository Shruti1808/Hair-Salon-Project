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

            //For stylists

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

            Get["stylists/edit/{id}"] = parameters => {
                Stylist SelectedStylist = Stylist.Find(parameters.id);
                return View["stylists_edit.cshtml", SelectedStylist];
            };

            Patch["stylists/edit/{id}"] = parameters => {
                Stylist updatedStylist = Stylist.Find(parameters.id);
                updatedStylist.Update(Request.Form["newName"]);
                List<Stylist> allStylists =Stylist.GetAll();
                return View["stylists.cshtml",allStylists];
            };

            Get["stylist/delete/{id}"] = parameters => {
                Stylist SelectedStylist = Stylist.Find(parameters.id);
                return View["stylist_remove.cshtml", SelectedStylist];
            };
            Delete["stylist/delete/{id}"] = parameters => {
                Stylist SelectedStylist = Stylist.Find(parameters.id);
                SelectedStylist.Delete();
                List<Stylist> allStylists =Stylist.GetAll();
                return View["stylists.cshtml",allStylists];
            };

            Delete["/stylists/delete"] = _ => {
                Stylist.DeleteAll();
                List<Stylist> allStylists =Stylist.GetAll();
                return View["stylists.cshtml",allStylists];
            };


         //For Clients

         Get["stylists/{id}/clients/new"] = parameters => {
             int stylistId = parameters.id;
             return View ["client_new.cshtml", stylistId];
         };

            Get["/clients"]  =_=> {
                List<Client> allClients = Client.GetAll();
                return View["clients.cshtml",allClients];
            };

            Post["/clients/new"]=_=>{
                Client newClient = new Client(Request.Form["clientName"],Request.Form["stylistId"]);
                newClient.Save();
                Dictionary<string, object> model = new Dictionary<string, object>();
                int stylistId = newClient.GetStylistId();
                var selectedStylist = Stylist.Find(stylistId);
                var stylistClients = selectedStylist.GetClients();
                model.Add("stylistkey", selectedStylist);
                model.Add("clientkey", stylistClients);
                return View["stylist_detail.cshtml", model];
            };

            Get["client/edit/{id}"] = parameters => {
                Client SelectedClient = Client.Find(parameters.id);
                return View["client_edit.cshtml", SelectedClient];
            };

            Patch["client/edit/{id}"] = parameters => {
                Client updatedClient = Client.Find(parameters.id);
                updatedClient.Update(Request.Form["newClientName"]);

                Dictionary<string, object> model = new Dictionary<string, object>();
                Client editedClient = Client.Find(parameters.id);
                int stylistId = editedClient.GetStylistId();
                var selectedStylist = Stylist.Find(stylistId);
                var stylistClients = selectedStylist.GetClients();
                model.Add("stylistkey", selectedStylist);
                model.Add("clientkey", stylistClients);
                return View["stylist_detail.cshtml", model];

            };

            Get["client/delete/{id}"] = parameters => {
                Client SelectedClient = Client.Find(parameters.id);
                return View["clients_remove.cshtml", SelectedClient];
            };


            Delete["client/delete/{id}"] = parameters => {
                Client selectedClient = Client.Find(parameters.id);
                int stylistId = selectedClient.GetStylistId();
                selectedClient.Delete();
                Dictionary<string, object> model = new Dictionary<string, object>();
                var selectedStylist = Stylist.Find(stylistId);
                var stylistClients = selectedStylist.GetClients();
                model.Add("stylistkey", selectedStylist);
                model.Add("clientkey", stylistClients);
                return View["stylist_detail.cshtml", model];

            };

            Delete["/clients/delete"] = _ => {
                Client.DeleteAll();
                List<Stylist> allStylists =Stylist.GetAll();
                return View["stylists.cshtml",allStylists];
            };

        }
    }
}
