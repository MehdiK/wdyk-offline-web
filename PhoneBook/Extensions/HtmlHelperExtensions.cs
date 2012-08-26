using System.Web.Mvc;

namespace PhoneBook.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ConditionalManifest(this HtmlHelper helper)
        {
            var url = new UrlHelper(helper.ViewContext.RequestContext);
            if (helper.ViewBag.SupportsOffline != null)
                return new MvcHtmlString(string.Format("manifest ='{0}'", url.Action("AppCacheManifest", "OfflineSupport")));

            return new MvcHtmlString(string.Empty);
        }

        public static MvcHtmlString WebSiteLastPublishDate (this HtmlHelper helper) 
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(assembly.Location);
            return new MvcHtmlString(fileInfo.LastWriteTime.ToString());
        }
    }
}