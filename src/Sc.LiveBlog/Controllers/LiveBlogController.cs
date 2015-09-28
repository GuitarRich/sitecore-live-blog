namespace Sc.LiveBlog.Controllers
{
	using System.Security.Authentication;
	using System.Web.Mvc;

	using Newtonsoft.Json.Linq;

	using Sc.LiveBlog.Model;

	using Sitecore.Data;
	using Sitecore.Exceptions;
	using Sitecore.Web;

	public class LiveBlogController : Controller
	{
		public ActionResult LiveBlog()
		{
			var data = new LiveBlogViewModel();
			return this.View(data);
		}
	}
}
