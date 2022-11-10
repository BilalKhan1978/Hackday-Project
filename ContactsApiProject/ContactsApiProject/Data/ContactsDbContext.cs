using ContactsApiProject.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactsApiProject.Data
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions options) : base(options)
        {
        }

    public DbSet<Contact> Contacts { get; set; }
    
    }
}
