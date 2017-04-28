using ASinglePageWebApp.DAL;
using ASinglePageWebApp.DAL.Repositories;
using ASinglePageWebApp.Data.Common;
using ASinglePageWebApp.Model;
using ASinglePageWebApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASinglePageWebApp.ServicesLayer.Controllers
{
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {

        private IContactService _contactService;

        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: /api/Contact/GetAllContacts/
        [HttpGet]
        [Route("GetAllContacts/{page:int}")] 
        public HttpResponseMessage GetAllContacts(int page)
        {
            //int pageNumber = (page ?? 1) - 1;
            //int totalCount = 0;
            //int PageSize = 10;
            //var contacts = _contactService.GetAllContacts(page+1, PageSize, out totalCount);
            var contacts = _contactService.GetAll();
            var enumerable = contacts as IList<Contact> ?? contacts.ToList();
            var response = enumerable.Any()
                ? Request.CreateResponse(HttpStatusCode.OK, enumerable)
                : Request.CreateResponse(HttpStatusCode.NotFound, "No Contacts Found");
            return response;
        }

        // GET: api/Get/5
        public HttpResponseMessage Get(int id)
        {
            var contacts = _contactService.GetContactById(id);
            var response = Request.CreateResponse(HttpStatusCode.OK, contacts);
            return response;

        }

        // POST: api/Create
        public void Create(Contact contact)
        {
            _contactService.CreateContact(contact);
        }

        // PUT: api/Home/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Home/5
        public void Delete(int id)
        {
            _contactService.DeleteContact(id);
        }
    }
}
