using System.Data.Entity;

namespace PhoneBook.Data
{
    public class DevDataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
            var contacts = new[]
            {
                new Contact { UserName = "User1", FullName = "John Smith", Address = "12 Smith St, Brisbane, QLD 4000", PhoneNumber = "04123123123" },
                new Contact { UserName = "User1", FullName = "Helen Smith", Address = "12 Smith St, Brisbane, QLD 4000", PhoneNumber = "072342342" },
                new Contact { UserName = "User1", FullName = "Tony Jones", PhoneNumber = "0456745765" },
                new Contact { UserName = "User1", FullName = "David Bloom", PhoneNumber = "0412300982" },

                new Contact { UserName = "User2", FullName = "Alan Boy", Address = "1 Boy St, Gold Coast, QLD 4250", PhoneNumber = "0412121221" },
                new Contact { UserName = "User2", FullName = "Tara Drum", Address = "84 Roma St, Brisbane, QLD 4000", PhoneNumber = "0745645623" },
            };

            foreach (var contact in contacts)
                context.Contacts.Add(contact);
        }
    }
}