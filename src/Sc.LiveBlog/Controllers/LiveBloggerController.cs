namespace Sc.LiveBlog.Controllers
{
	using System.Web.Mvc;

	using Sc.LiveBlog.Model;

	public class LiveBloggerController : Controller
	{
		public ActionResult LiveBlog()
		{
			var data = new LiveBlogViewModel();
			return this.View(data);
		}

		//public JsonResult PostBlog(string blogEntry, int blogType)
		//{
		//	// TODO: What level of security do we need to put here? 
		//	// Make sure they are logged in as a Sitecore user... Roles???

		//	var hubContext = GlobalHost.ConnectionManager.GetHubContext<LiveBlogHub>();
		//	hubContext.Clients.All.blogPosted(blogEntry, blogType);

		//	return new JsonResult();
		//}
	}
}
