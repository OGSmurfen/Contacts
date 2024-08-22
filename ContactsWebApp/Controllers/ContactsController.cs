using ContactsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContactsWebApp.Controllers
{
    public class ContactsController : Controller
    {
        Uri contactsApiAddress = new Uri("https://localhost:7271/api");
        private readonly HttpClient client;

        public ContactsController()
        {
            client = new HttpClient();
            client.BaseAddress = contactsApiAddress;
        }


        [HttpGet]
        public  IActionResult Index()
        {
            List<ContactsVM> contactsList = new List<ContactsVM>();
            HttpResponseMessage response =  client.GetAsync(client.BaseAddress + "/ContactsControllerAPI/GetContacts").Result;

            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                contactsList = JsonConvert.DeserializeObject<List<ContactsVM>>(data);
            }


            return View(contactsList);
        }
        
    }
}
