namespace Sc.LiveBlog.Controllers
{
	using System.Security.Authentication;
	using System.Web.Mvc;

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;

	using Sc.LiveBlog.Model;

	using Sitecore.Data;
	using Sitecore.Exceptions;
	using Sitecore.Services.Infrastructure.Web.Http;
	using Sitecore.Web;

	public class LiveBlogServicesController : ServicesApiController
	{
		[HttpGet]
		public JObject GetItem(string id)
		{
			if (!Sitecore.Context.User.IsAuthenticated)
			{
				throw new AuthenticationException();
			}

			if (Sitecore.Context.User.IsInRole("LiveBlogger") == false && Sitecore.Context.IsAdministrator == false)
			{
				throw new AuthenticationException();
			}

			//var id = WebUtil.GetQueryString("id");
			if (ID.IsID(id) == false)
			{
				throw new ItemNotFoundException();
			}

			var itemId = ID.Parse(id);
			var item = this.MasterDatabase.GetItem(itemId);

			var model = new ItemModel(item);
			return JObject.FromObject(model);
		}

		//public JsonResult PostBlog(string blogEntry, int blogType)
		//{
		//	// TODO: What level of security do we need to put here? 
		//	// Make sure they are logged in as a Sitecore user... Roles???

		//	var hubContext = GlobalHost.ConnectionManager.GetHubContext<LiveBlogHub>();
		//	hubContext.Clients.All.blogPosted(blogEntry, blogType);

		//	return new JsonResult();
		//}

		private Database masterDatabase;

		protected virtual Database MasterDatabase
			=> this.masterDatabase ?? (this.masterDatabase = Sitecore.Configuration.Factory.GetDatabase("master"));
	}
}
