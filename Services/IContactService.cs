using ContactsAPI.Contracts;
using ContactsAPI.Models;

namespace ContactsAPI.Services
{
    public interface IContactService
    {


        // Get All Contacts

        Task<PagesResponse<Contact>> GetAllContactsAsync(PaginationFilter paginationFilter);


        // Get Contact By Id

        Task<Contact> GetContactByIdAsync(int id);

        // Create Contact.

        Task<bool> CreateContactAsync(Contact contact);

        // Update Contact.

        Task<bool> UpdateContactAsync(Contact contact);

        // Delete Contact

        Task<bool> DeleteContactAsync(Contact contact);

        // Name Search

        Task<List<Contact>> SearchByNameAsync(string name);

        // paginated Contacts.



    }
}
