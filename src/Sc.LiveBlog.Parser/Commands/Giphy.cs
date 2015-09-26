namespace Sc.LiveBlog.Parser.Commands
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Web.UI;

	using Sc.Giphy;

	public class Giphy : ILiveBlogCommand
	{
		public string Execute(string[] parameters)
		{
			if (parameters.Any() == false)
			{
				throw new ArgumentOutOfRangeException();
			}

			var giphy = new GiphyService();
			var search = string.Join(" ", parameters);

			var result = giphy.GetGiphyRandom(search);

			// Build the image tag
			using (var sw = new StringWriter())
			{
				using (var htmlWriter = new HtmlTextWriter(sw))
				{
					htmlWriter.AddAttribute(HtmlTextWriterAttribute.Src, result);
					htmlWriter.AddAttribute(HtmlTextWriterAttribute.Alt, search);
					htmlWriter.RenderBeginTag(HtmlTextWriterTag.Img);
					htmlWriter.RenderEndTag();

					return sw.ToString();
				}
			}
		}
	}
}
