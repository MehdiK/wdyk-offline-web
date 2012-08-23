using System.Data.Entity;

namespace PhoneBook.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}