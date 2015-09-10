namespace Sc.LiveBlog.Pipelines.HttpRequestBegin
{
	using System;

	using Sitecore.Diagnostics;
	using Sitecore.Pipelines.HttpRequest;

	public class IgnoreSignalR : HttpRequestProcessor
	{
		public override void Process(HttpRequestArgs args)
		{
			Assert.ArgumentNotNull(args, "args");
			var prefixes =
				Sitecore.Configuration.Settings.GetSetting(Constants.Settings.IgnoreSignalRPrefixes, "/signalr").Split('|');

			if (prefixes.Length > 0)
			{
				var filePath = args.Url.FilePath;
				foreach (var prefix in prefixes)
				{
					if (filePath.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
					{
						args.AbortPipeline();
						return;
					}
				}
			}
		}
	}
}
