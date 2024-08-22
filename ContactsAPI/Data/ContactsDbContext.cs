using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Data
{
    public class ContactsDbContext : DbContext
    {
        public DbSet<ContactsModel> Contacts { get; set; }




        public ContactsDbContext (DbContextOptions<ContactsDbContext> options) : base(options)
        {
  
        }
    }
}
