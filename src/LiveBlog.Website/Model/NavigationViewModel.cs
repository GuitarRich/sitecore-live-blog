namespace LiveBlog.Website.Model
{
	using System.Collections.Generic;

	using Sitecore.Data.Items;

	public class NavigationViewModel
	{
		public Item SiteRoot { get; set; }

		public IEnumerable<Item> Items { get; set; }
	}
}