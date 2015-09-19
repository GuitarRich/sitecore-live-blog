namespace Sc.Giphy.Model
{
	using Newtonsoft.Json;

	[JsonObject("meta")]
	public class GiphyResultMeta
	{
		[JsonProperty("status")]
		public int Status { get; set; }

		[JsonProperty("msg")]
		public string Message { get; set; }
	}
}
