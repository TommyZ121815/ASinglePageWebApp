using ASinglePageWebApp.Model;
using ASinglePageWebApp.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ASinglePageWebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        Uri WebApiAddress = new Uri("http://localhost:57620/");
        
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: Contact
        public async Task<ActionResult> Index(int? page)
        {
            List<Contact> contacts = new List<Contact>();
            int pageNumber = (page ?? 1) - 1;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = WebApiAddress;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Using http get to getall the details info of contacts
                HttpResponseMessage response = await client.GetAsync("api/Home/GetAllContacts/" + pageNumber);
                
                //Check if the response is corrected. 
                if (response.IsSuccessStatusCode)
                {
                    var contact = response.Content.ReadAsStringAsync();
                    contacts = JsonConvert.DeserializeObject<List<Contact>>(contact.Result);
                }               
            }
            return View(contacts);
        }

        // GET: Contact/Details/5
        public async Task<ActionResult> Details(int id)
        {
            //var contact =  _contactService.GetContactById(id);
            Contact contactOjbect = new Contact();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = WebApiAddress;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Home/" + id);

                if (response.IsSuccessStatusCode)
                {
                    var contact = response.Content.ReadAsStringAsync();
                    contactOjbect = JsonConvert.DeserializeObject<Contact>(contact.Result);
                }
            }
            return View(contactOjbect);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = WebApiAddress;
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    await client.PostAsJsonAsync("api/Home/Create", contact);             
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Contact EditedContact)
        {
            try
            {
                // Assign id to current contact entity
                EditedContact.ContactID = id;
                _contactService.UpdateContact(EditedContact);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {              
                return View();
            }
        }

        // GET: Contact/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            //_contactService.DeleteContact(id);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = WebApiAddress;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await client.DeleteAsync("api/Home/" + id);                           
            }            

            return RedirectToAction("Index");
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
