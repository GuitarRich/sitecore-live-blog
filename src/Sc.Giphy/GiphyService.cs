namespace Sc.Giphy
{
	using System;
	using System.Net.Http;
	using System.Net.Http.Headers;

	using Newtonsoft.Json;

	using Sc.Giphy.Model;

	public class GiphyService
	{
		protected const string GiphyRandomApi = "http://api.giphy.com/v1/gifs/random";

		/// <summary>
		/// Gets the giphy random.
		/// </summary>
		/// <param name="searchTerm">The search term.</param>
		/// <returns></returns>
		public string GetGiphyRandom(string searchTerm)
		{
			var apiKey = Sitecore.Configuration.Settings.GetSetting("Sc.Giphy.ApiKey", "dc6zaTOxFJmzC");
			var urlParameters = $"?api_key={apiKey}&tag={searchTerm.Replace(" ", "+")}";

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(GiphyRandomApi);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				using (var response = client.GetAsync(urlParameters).Result)
				{
					var json = response.Content.ReadAsStringAsync().Result;

					var giphyObject = JsonConvert.DeserializeObject<GiphyResult>(json);

					return giphyObject.Data.ImageUrl;
				}
			}
		}
	}
}
