using ContactManagerApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerApplication.Data
{
    public class ContactDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }
    }
}
