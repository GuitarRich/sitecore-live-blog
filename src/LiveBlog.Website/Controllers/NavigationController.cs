namespace LiveBlog.Website.Controllers
{
	using System.Web.Mvc;

	using LiveBlog.Website.Model;

	using Rainbow.Storage.Sc;

	using Sitecore.Exceptions;

	public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult MainNavigation()
        {
	        var siteRoot = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.RootPath);
	        if (siteRoot == null)
	        {
		        throw new ItemNotFoundException();
	        }

	        var data = new NavigationViewModel
	        {
				SiteRoot = siteRoot,
		        Items = siteRoot.Children
	        };

            return this.View(data);
        }
    }
}