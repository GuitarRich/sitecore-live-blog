namespace Sc.LiveBlog.Model
{
	using Sc.LiveBlog.Helpers;

	public class LiveBlogViewModel
	{
		public LiveBlogViewModel()
		{
			this.Require = new RequireJsPaths();
		}

		/// <summary>
		/// Gets or sets the require js settings.
		/// </summary>
		/// <value>
		/// The require.
		/// </value>
		public RequireJsPaths Require { get; private set; }

		/// <summary>
		/// Gets or sets the view locations.
		/// </summary>
		/// <value>
		/// The view locations.
		/// </value>
		public string ViewLocations => ConfigurationManager.GetSetting("LiveBlog.ViewLocations");



	}
}
