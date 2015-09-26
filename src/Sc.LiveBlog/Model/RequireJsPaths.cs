namespace Sc.LiveBlog.Model
{
	using Sc.LiveBlog.Helpers;

	public class RequireJsPaths
	{
		public bool Enabled => ConfigurationManager.GetBoolSetting("LiveBlog.UseRequireJs");

		/// <summary>
		/// Gets or sets the signalr require definition.
		/// </summary>
		/// <value>
		/// The signal r.
		/// </value>
		public string SignalR => ConfigurationManager.GetSetting("LiveBlog.RequireKeys.SignalR");

		/// <summary>
		/// Gets or sets the jquery require definition.
		/// </summary>
		/// <value>
		/// The j query.
		/// </value>
		public string JQuery => ConfigurationManager.GetSetting("LiveBlog.RequireKeys.JQuery");

		/// <summary>
		/// Gets or sets the main script require definition.
		/// </summary>
		/// <value>
		/// The script.
		/// </value>
		public string Script => ConfigurationManager.GetSetting("LiveBlog.RequireKeys.LiveBlog");
	}
}
