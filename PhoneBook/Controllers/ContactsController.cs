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
            var vm = contacts.Select(Map);
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

            var dbContact = Map(contact);
            _dataContext.Contacts.Add(dbContact);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var contact = _dataContext.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
                return RedirectToAction("Index");

            return View(Map(contact));
        }

        [HttpPost]
        public ActionResult Edit(ContactModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var contact = _dataContext.Contacts.FirstOrDefault(c => c.Id == model.Id);
            if (contact == null)
                return RedirectToAction("Index");

            contact.Address = model.Address;
            contact.PhoneNumber = model.PhoneNumber;
            contact.FullName = model.FullName;
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        ContactModel Map(Contact contact)
        {
            return new ContactModel { Id = contact.Id, FullName = contact.FullName, Address = contact.Address, PhoneNumber = contact.PhoneNumber };
        }

        Contact Map(ContactModel viewmodel)
        {
            return new Contact { Address = viewmodel.Address, FullName = viewmodel.FullName, PhoneNumber = viewmodel.PhoneNumber, UserName = User.Identity.Name }; 
        }
    }
}
