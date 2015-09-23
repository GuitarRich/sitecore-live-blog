namespace Sc.LiveBlog.Hubs
{
	using Microsoft.AspNet.SignalR;

	public class LiveBlogHub : Hub
	{
		public void PostBlogEntry(string blogText, int blogType)
		{
			var hubContext = GlobalHost.ConnectionManager.GetHubContext<LiveBlogHub>();
			hubContext.Clients.All.blogPosted(blogText, blogType);
		}
	}
}
