﻿using Microsoft.Owin;

[assembly: OwinStartup(typeof(Sc.LiveBlog.Pipelines.Initialize.RegisterSignalRProcessor))]
namespace Sc.LiveBlog.Pipelines.Initialize
{
	using Owin;

	using Sitecore.Pipelines;

	public class RegisterSignalRProcessor
	{
		/// <summary>
		/// Configurations the specified application - called by the OwinStartup attibute on the namespace above.
		/// </summary>
		/// <param name="app">The application.</param>
		public void Configuration(IAppBuilder app)
		{
			app.MapSignalR();
		}

		public virtual void Process(PipelineArgs args)
		{
			// TODO: Setup any MVC routing in here:
		}
	}
}
