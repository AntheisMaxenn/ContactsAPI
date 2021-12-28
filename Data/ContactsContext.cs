using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ContactsAPI.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {

        }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(await SeedLargData());
        }

        public DbSet<Contact> Contacts { get; set; }

        public async Task<Contact[]> SeedLargData()
        {
            var fileContent = await File.ReadAllTextAsync("Data/seed.json");
            
            var contacts = JsonSerializer.Deserialize<Contact[]>(fileContent);

            return contacts;
        }
    
    }

}
