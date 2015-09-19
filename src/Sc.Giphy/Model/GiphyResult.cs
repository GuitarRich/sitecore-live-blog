namespace Sc.Giphy.Model
{
	using Newtonsoft.Json;

	[JsonObject]
	public class GiphyResult
	{
		[JsonProperty("data")]
		public GiphyResultData Data { get; set; }

		[JsonProperty("meta")]
		public GiphyResultMeta Meta { get; set; }
	}
}
