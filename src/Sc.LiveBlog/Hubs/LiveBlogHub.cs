namespace Sc.LiveBlog.Hubs
{
	using System;
	using System.Security.Authentication;

	using Microsoft.AspNet.SignalR;

	using Newtonsoft.Json;

	using Sc.LiveBlog.Factories;
	using Sc.LiveBlog.Model;

	public class LiveBlogHub : Hub
	{
		public void PostBlogEntry(string blogId, string blogText)
		{
			var hubContext = GlobalHost.ConnectionManager.GetHubContext<LiveBlogHub>();

			// Process the blogText for commands
			var commandParser = FactoryManager.CommandFactory.GetCommandParser();
			var modifiedBlogText = commandParser.Parse(blogText);

			var blogEntry = new BlogEntryModel
			{
				BlogId = blogId,
				EntryType = "default",
				Text = modifiedBlogText,
				TimeStamp = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss zzz")
			};

			var json = JsonConvert.SerializeObject(blogEntry);

			hubContext.Clients.All.blogPosted(json);
		}
	}
}
