namespace Sc.LiveBlog.SignalR
{
	using Microsoft.AspNet.SignalR;
	using Microsoft.AspNet.SignalR.Hubs;

	public class LiveBlogNotifier : Hub
	{
		public void PostBlogEntry(string blogText, int blogType)
		{
			var hubContext = GlobalHost.ConnectionManager.GetHubContext<LiveBlogNotifier>();
			hubContext.Clients.All.blogPosted(blogText, blogType);
		}
	}
}
