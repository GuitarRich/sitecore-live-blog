// ReSharper disable AssignNullToNotNullAttribute
namespace Sc.LiveBlog.Speak
{
	using System;
	using System.IO;
	using System.Net;
	using System.Text;

	using Sitecore.Diagnostics;
	using Sitecore.Resources.Pipelines.ResolveScript;
	using Sitecore.Text;
	using Sitecore.Web;

	/// <summary>
	/// Resovles the SignalRHubs javasript for SPEAK applications
	/// </summary>
	/// <remarks>
	/// Code based on: http://laubplusco.net/signalr-component-sitecore-speak/
	/// </remarks>
	public class ResolveSignalRHubs : ResolveScriptProcessor
	{
		public override void Process(ResolveScriptArgs args)
		{
			Assert.ArgumentNotNull(args, "args");
			if (!args.FileName.StartsWith("signalr/hubs.js", StringComparison.InvariantCultureIgnoreCase))
			{
				return;
			}

			args.AbortPipeline();
			var urlString = new UrlString(WebUtil.GetScheme() + "://" + WebUtil.GetHostName() + "/signalr/hubs");
			var request = WebRequest.Create(urlString.ToString());
			var responseStream = request.GetResponse().GetResponseStream();
			Assert.IsNotNull(responseStream, "Could not read SignalR hubs script");

			var script = new StreamReader(responseStream).ReadToEnd();

			args.SetContent(RequireSignalR(script), DateTime.Now);
		}

		private static string RequireSignalR(string script)
		{
			return "define([\"//ajax.aspnetcdn.com/ajax/signalr/jquery.signalr-2.2.0.min.js\"], function() {" + script + "});";
		}
	}
}
