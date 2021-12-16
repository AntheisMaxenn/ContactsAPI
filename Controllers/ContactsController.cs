using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        // Declare Context variable.
        private readonly ContactsContext context;
        // injct the service and assign to the local variable.

        public ContactsController(ContactsContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Contact>> GetAllContacts()
        {
            return await context.Contacts.ToListAsync();
        }

        // Get by Id
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            var isContact = await context.Contacts.FirstOrDefaultAsync(g => g.Id == id);

            if (isContact == null) return NotFound();
            
            return isContact;
        }


        // Post
        [HttpPost]
        public async Task<bool> CreateContact([FromBody]Contact contact)
        {
            await context.Contacts.AddAsync(contact);
            var created = await context.SaveChangesAsync();
            return created > 0;
        }

        // Update By Id

        [HttpPut]
        public async Task<bool> UpdateContact([FromBody]Contact contact)
        {
            context.Contacts.Update(contact);
            var result = await context.SaveChangesAsync();
            return result > 0;

        }

        // Delete by id

        [HttpDelete]
        public async Task<bool> DeleteContact(Contact contact)
        {
            context.Contacts.Remove(contact);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        [HttpGet]
        [Route("pages/{page}/{limit}")]
        public async Task<List<Contact>> GetPageContacts(int page, int limit)
        {
            var skipAmount = (page * limit) - limit;
            return await context.Contacts.Skip(skipAmount).Take(limit).ToListAsync();
        }

        [HttpPost]
        [Route("/search")]
        public async Task<ActionResult<List<Contact>>> NameSearch([FromBody] string name)
        {
            List<Contact> result = await context.Contacts.Where(c => c.Name.Contains(name)).ToListAsync();
            return result.Count() > 0 ? result : NotFound();
        }
    }
}
