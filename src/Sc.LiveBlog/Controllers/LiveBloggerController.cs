namespace Sc.LiveBlog.Controllers
{
	using System.Web.Mvc;

	using Microsoft.AspNet.SignalR;

	using Sc.LiveBlog.SignalR;

	public class LiveBloggerController : Controller
	{
		public ActionResult LiveBlog()
		{
			return this.View();
		}

		public JsonResult PostBlog(string blogEntry, int blogType)
		{
			var hubContext = GlobalHost.ConnectionManager.GetHubContext<LiveBlogNotifier>();


			return new JsonResult();
		}
	}
}
