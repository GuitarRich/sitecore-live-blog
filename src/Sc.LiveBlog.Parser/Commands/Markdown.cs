namespace Sc.LiveBlog.Parser.Commands
{
	using System;
	using System.Linq;

	using MarkdownSharp;

	public class Markdown : ILiveBlogCommand
	{
		public string Execute(string[] parameters)
		{
			if (parameters.Any() == false)
			{
				throw new ArgumentOutOfRangeException(nameof(parameters));
			}

			// Parameter zero holds all the content for default commands
			var input = parameters[0];
			var markdown = new MarkdownSharp.Markdown();
			var output = markdown.Transform(input);

			return output;
		}
	}
}
