using System.Web.Mvc;
using PhoneBook.Data;
using System.Linq;

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
            var contacts = _dataContext.Contacts.Where(c => c.UserName == User.Identity.Name);
            return View(contacts);
        }
    }
}
