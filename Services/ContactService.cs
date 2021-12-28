using ContactsAPI.Contracts;
using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactsContext context;
        public ContactService(ContactsContext context)
        {
            this.context = context;
        }

        // Service methods will return Domain objects, Mapping is implemented by the caller.
        // Async Methods will have the "Async" Appended.

        // Get All Contacts

        public async Task<PagesResponse<Contact>> GetAllContactsAsync(PaginationFilter paginationFilter = null)
        {
            int total = await context.Contacts
                .CountAsync();

            int skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

            List<Contact> data = await context.Contacts
                .Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();

            PagesResponse<Contact> results = new PagesResponse<Contact>(data);
            results.Total = total;
            results.PageNumber = paginationFilter.PageNumber;
            results.PageSize = paginationFilter.PageSize;

            return results;
        }

        public Task<Contact> GetContactByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Create Contact.

        public Task<bool> CreateContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        // Update Contact.

        public Task<bool> UpdateContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        // Delete Contact

        public Task<bool> DeleteContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        // Name Search

        public Task<List<Contact>> SearchByNameAsync(string name)
        {
            throw new NotImplementedException();
        }


    }
}
