using Microsoft.EntityFrameworkCore;
using TestTaskWebApi.Models;

namespace TestTaskWebApi.Context
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        {
            /*Database.EnsureDeleted();*/
            //Database.EnsureCreated();

        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
