namespace LiveBlog.Website.Controllers
{
	using System.Web.Mvc;

	public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult MainNavigation()
        {
            return this.View();
        }
    }
}