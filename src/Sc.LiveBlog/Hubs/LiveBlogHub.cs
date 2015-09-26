namespace Sc.LiveBlog.Hubs
{
	using System;

	using Microsoft.AspNet.SignalR;

	using Sc.LiveBlog.Factories;

	public class LiveBlogHub : Hub
	{
		public void PostBlogEntry(string blogText, string blogType)
		{
			var hubContext = GlobalHost.ConnectionManager.GetHubContext<LiveBlogHub>();

			// Process the blogText for commands
			var commandParser = FactoryManager.CommandFactory.GetCommandParser();
			var modifiedBlogText = commandParser.Parse(blogText);

			hubContext.Clients.All.blogPosted(modifiedBlogText, blogType, DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss zzz"));
		}
	}
}
