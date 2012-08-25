using System.Web.Mvc;
using PhoneBook.Data;
using System.Linq;

namespace PhoneBook.Controllers
{
    [Authorize]
    public class OfflineSupportController : Controller
    {
        readonly DataContext _dataContext = new DataContext();

         public PartialViewResult AppCacheManifest()
         {
             return PartialView();
         }

        public ViewResult OnlineOnlyPage()
        {
            return View();
        }

        public ActionResult ContactsEdit()
        {
            var contacts = _dataContext.Contacts.Where(c => c.UserName == User.Identity.Name).Select(c => c.Id).ToList();
            return PartialView(contacts);
        }
    }
}