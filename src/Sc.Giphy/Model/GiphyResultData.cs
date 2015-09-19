namespace Sc.Giphy.Model
{
	using Newtonsoft.Json;

	[JsonObject("data")]
	public class GiphyResultData
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }

		[JsonProperty("image_width")]
		public string Width { get; set; }

		[JsonProperty("image_height")]
		public string Height { get; set; }
	}
}
