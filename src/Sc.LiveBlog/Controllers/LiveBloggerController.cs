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
			// TODO: What level of security do we need to put here? 
			// Make sure they are logged in as a Sitecore user... Roles???

			var hubContext = GlobalHost.ConnectionManager.GetHubContext<LiveBlogNotifier>();
			hubContext.Clients.All.blogPosted(blogEntry, blogType);

			return new JsonResult();
		}
	}
}
