namespace Sc.LiveBlog.Factories
{
	using System;
	using System.Linq;

	using Sc.LiveBlog.Configuration;
	using Sc.LiveBlog.Parser;
	using Sc.LiveBlog.Parser.Commands;

	public class CommandFactory
	{
		/// <summary>
		/// Gets the default command parser intance.
		/// </summary>
		/// <returns></returns>
		public ICommandParser GetCommandParser()
		{
			var commandParser = LiveBlogConfigurationManager.Configuration.DefaultCommandParserProvider;
			var parser = commandParser.GetInstance<ICommandParser>();
			parser.Name = commandParser.Name;

			return parser;
		}

		/// <summary>
		/// Gets the command instance from the command parser
		/// </summary>
		/// <param name="commandParser">The command parser.</param>
		/// <param name="commandName">Name of the command.</param>
		/// <returns></returns>
		public ILiveBlogCommand GetCommand(ICommandParser commandParser, string commandName)
		{
			if (commandParser.Name != LiveBlogConfigurationManager.Configuration.DefaultCommandParserProvider.Name)
			{
				throw new ArgumentException("You must use the default command parser provider");
			}

			var command =
				LiveBlogConfigurationManager.Configuration.DefaultCommandParserProvider.Commands.FirstOrDefault(
					c => c.Name.Equals(commandName, StringComparison.InvariantCultureIgnoreCase));

			return command?.GetInstance<ILiveBlogCommand>();
		}
	}
}
