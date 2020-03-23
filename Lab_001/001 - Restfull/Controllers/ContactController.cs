using _001___Restfull.Models;
using _001___Restfull.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _001___Restfull.Controllers
{
    public class ContactController : ApiController
    {
        private ContactService contactRepository;

        public ContactController()
        {
            this.contactRepository = new ContactService();
        }

        [Route("contact/listcontacts")]
        [HttpGet]
        public Contact[] ListContacts()
        {
            return contactRepository.GetAllContacts();
        }

        [Route("contact/savecontact")]
        [HttpPost]
        public HttpResponseMessage SaveContact(Contact contact)
        {
            this.contactRepository.SaveContact(contact);

            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);

            return response;
        }
    }
}
