using AutoMapper;
using ContactsAPI.Contracts;
using ContactsAPI.Data;
using ContactsAPI.Models;
using ContactsAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        //private readonly ContactsContext context;
        private readonly IContactService contactService;

        private readonly IMapper mapper;
        public ContactsController(IContactService contactService, IMapper mapper)
        {
            //this.context = context;
            this.contactService = contactService;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts([FromQuery]PaginationQuery query)
        {
            var pagination = mapper.Map<PaginationFilter>(query);


            //return Ok(await this.contactService.GetAllContactsAsync(pagination));


            return Ok(new PagesResponse<Contact>(contacts));

        }

        // Get by Id
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            //var isContact = await context.Contacts.FirstOrDefaultAsync(g => g.Id == id);

            //if (isContact == null) return NotFound();

            //return isContact;

            throw new NotImplementedException();
        }


        // Post
        [HttpPost]
        public async Task<bool> CreateContact([FromBody]Contact contact)
        {
            //await context.Contacts.AddAsync(contact);
            //var created = await context.SaveChangesAsync();
            //return created > 0;

            throw new NotImplementedException();
        }

        // Update By Id

        [HttpPut]
        public async Task<bool> UpdateContact([FromBody]Contact contact)
        {
            //context.Contacts.Update(contact);
            //var result = await context.SaveChangesAsync();
            //return result > 0;

            throw new NotImplementedException();
        }

        // Delete by id

        [HttpDelete]
        public async Task<bool> DeleteContact(Contact contact)
        {
            //context.Contacts.Remove(contact);
            //var result = await context.SaveChangesAsync();
            //return result > 0;

            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("pages/{page}/{limit}")]
        public async Task<List<Contact>> GetPageContacts(int page, int limit)
        {
            //var skipAmount = (page * limit) - limit;
            //return await context.Contacts.Skip(skipAmount).Take(limit).ToListAsync();

            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("/search")]
        public async Task<ActionResult<List<Contact>>> NameSearch([FromQuery] string name)
        {
            //List<Contact> result = await context.Contacts.Where(c => c.Name.Contains(name)).ToListAsync();
            //return result.Count() > 0 ? result : NotFound();

            throw new NotImplementedException();
        }
    }
}
