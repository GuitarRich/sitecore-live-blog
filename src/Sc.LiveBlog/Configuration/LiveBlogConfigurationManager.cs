namespace Sc.LiveBlog.Configuration
{
	using Sitecore.Configuration;

	public class LiveBlogConfigurationManager
	{
		static LiveBlogConfigurationManager()
		{
			Configuration = (IConfigurationProvider)Factory.CreateObject("/sitecore/liveBlog/configurationProvider", true);
		}

		public static IConfigurationProvider Configuration { get; }
	}
}
