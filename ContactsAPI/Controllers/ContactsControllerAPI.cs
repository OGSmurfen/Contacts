using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactsAPI.Data;
using ContactsAPI.Models;
using ContactsAPI.Repository.IRepository;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsControllerAPI : ControllerBase
    {
        private readonly IContactsRepository contactsRepository;

        public ContactsControllerAPI(IContactsRepository contactsRepository)
        {
            this.contactsRepository = contactsRepository;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactsModel>>> GetContacts()
        {
            return await contactsRepository.GetAllAsync();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactsModel>> GetContacts(int id)
        {
            var contact = await contactsRepository.GetAsync(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContacts(int id, ContactsModel contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            contactsRepository.Update(contact);

            try
            {
                await contactsRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactsModel>> PostContacts(ContactsModel contact)
        {
            await contactsRepository.CreateAsync(contact);
            return CreatedAtAction("GetContacts", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContacts(int id)
        {
            var contact = await contactsRepository.GetAsync(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            await contactsRepository.DeleteAsync(contact);

            return NoContent();
        }

        private bool ContactsExists(int id)
        {
            return contactsRepository.ContactsExists(id);
        }
    }
}
