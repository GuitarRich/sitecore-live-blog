namespace Sc.LiveBlog.Model
{
	using Newtonsoft.Json;

	[JsonObject("blogEntry")]
	public class BlogEntryModel
	{
		[JsonProperty("blogId")]
		public string BlogId { get; set; }

		[JsonProperty("type")]
		public string EntryType { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("timeStamp")]
		public string TimeStamp { get; set; }
	}
}
