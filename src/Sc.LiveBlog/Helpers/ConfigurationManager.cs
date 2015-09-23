namespace Sc.LiveBlog.Helpers
{
	public static class ConfigurationManager
	{
		/// <summary>
		/// Gets the setting as a string.
		/// </summary>
		/// <param name="setting">The setting.</param>
		/// <returns></returns>
		public static string GetSetting(string setting)
		{
			return Sitecore.Configuration.Settings.GetSetting(setting);
		}

		/// <summary>
		/// Gets the setting as a boolean.
		/// </summary>
		/// <param name="setting">The setting.</param>
		/// <returns></returns>
		public static bool GetBoolSetting(string setting)
		{
			return Sitecore.Configuration.Settings.GetBoolSetting(setting, false);
		}
	}
}
