namespace Sc.LiveBlog.Model
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	using Newtonsoft.Json;

	using Sitecore.Data.Items;

	[JsonObject("item")]
	public class ItemModel
	{
		public ItemModel(Item baseItem)
		{
			this.ItemId = baseItem.ID.Guid;
			this.Name = baseItem.Name;

			this.Title = baseItem["Blog Title"];
			this.LiveBlogRaw = baseItem["BlogEntries"];

			if (string.IsNullOrWhiteSpace(this.LiveBlogRaw) == false)
			{
				this.LiveBlogEntries = JsonConvert.DeserializeObject<IEnumerable<BlogEntryModel>>(this.LiveBlogRaw);
			}
		}

		[JsonProperty("itemId")]
		public Guid ItemId { get; }

		[JsonProperty("name")]
		public string Name { get; }

		[JsonProperty("blogTitle")]
		public string Title { get; }

		[JsonProperty("raw")]
		public string LiveBlogRaw { get; }

		[JsonProperty("entries")]
		public IEnumerable<BlogEntryModel> LiveBlogEntries { get; }
	}
}
