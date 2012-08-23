using System.Web.Mvc;
using PhoneBook.Data;
using System.Linq;
using PhoneBook.Models;

namespace PhoneBook.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        // I am instantiating this here only to make the sample very simple
        // WARNING: Please do not write code like this in production
        readonly DataContext _dataContext = new DataContext();

        //
        // GET: /PhoneBook/
        public ActionResult Index()
        {
            var contacts = _dataContext.Contacts.Where(c => c.UserName == User.Identity.Name).ToList();
            var vm = contacts.Select(
                c => new ContactModel { Id = c.Id, FullName = c.FullName, Address = c.Address, PhoneNumber = c.PhoneNumber });
            return View(vm);
        }

        public ActionResult Create()
        {
            return View(new Contact());
        }

        [HttpPost]
        public ActionResult Create(ContactModel contact)
        {
            if (!ModelState.IsValid)
                return View();

            var dbContact = new Contact { Address = contact.Address, FullName = contact.FullName, PhoneNumber = contact.PhoneNumber, UserName = User.Identity.Name };
            _dataContext.Contacts.Add(dbContact);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
