namespace Sc.LiveBlog.Pipelines.Initialize
{
	using System.Web.Http;

	using Sitecore.Pipelines;

	public class RegisterHttpRoutes
	{
		public void Process(PipelineArgs args)
		{
			Sitecore.Diagnostics.Log.Info("LiveBlog: Initializing HttpRoutes", this);
			System.Web.Http.GlobalConfiguration.Configure(this.Configure);
		}

		protected void Configure(HttpConfiguration configuration)
		{
			Sitecore.Diagnostics.Log.Info("LiveBlog: Initializing HttpRoutes[Configure]", this);

			var routes = configuration.Routes;
			routes.MapHttpRoute("LiveBlog", "sitecore/api/liveblogservices/{action}/{id}", new
			{
				Controller = "LiveBlogServices",
				Action = "GetItem"
			});
		}
	}
}
