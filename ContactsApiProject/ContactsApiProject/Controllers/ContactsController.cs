using ContactsApiProject.Data;
using ContactsApiProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsDbContext _dbContext;
        public ContactsController(ContactsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            return Ok(await _dbContext.Contacts.ToListAsync());
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }


        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                FullName = addContactRequest.FullName,
                Email = addContactRequest.Email,
                Phone = addContactRequest.Phone,
                Address = addContactRequest.Address
            };

            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();

            return Ok(contact);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid
                id, UpdateContactRequest updateContactRequest)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                contact.FullName = updateContactRequest.FullName;
                contact.Email = updateContactRequest.Email;
                contact.Phone = updateContactRequest.Phone;
                contact.Address = updateContactRequest.Address;

                await _dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                _dbContext.Remove(contact);
                await _dbContext.SaveChangesAsync();
                return Ok(contact);
            }

            return NotFound();
        }


    }
}
