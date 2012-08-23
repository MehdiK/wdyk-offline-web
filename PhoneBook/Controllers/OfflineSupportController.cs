using System.Text;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    [Authorize]
    public class OfflineSupportController : Controller
    {
         public PartialViewResult AppCacheManifest()
         {
             return PartialView();
         }

        public ViewResult OnlineOnlyPage()
        {
            return View();
        }
    }
}