namespace Sc.LiveBlog.CommandParser
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;

	using Sc.LiveBlog.Configuration;
	using Sc.LiveBlog.Factories;
	using Sc.LiveBlog.Parser;
	using Sc.LiveBlog.Parser.Commands;

	public class DefaultCommandParser : ICommandParser
	{
		protected readonly IDictionary<string, ICommandParser> Commands;

		protected readonly object InitializeCommandLock = new object();

		/// <summary>
		/// Initializes a new instance of the <see cref="DefaultCommandParser"/> class.
		/// </summary>
		public DefaultCommandParser()
		{
			this.Commands = new Dictionary<string, ICommandParser>();
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Parses the specified input.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public string Parse(string input)
		{
			if (input.StartsWith("/") == false)
			{
				// If we have a default command, run the input thru it, otherwise just return the input
				var defaultCommand = LiveBlogConfigurationManager.Configuration.DefaultCommandParserProvider.DefaultCommand?.Name;
				return string.IsNullOrWhiteSpace(defaultCommand) == false ? this.RunCommand(defaultCommand, new[] { input }) : input;
			}

			// get the parameters of the command. 1st is always the command,
			// others are the params for the command. We split on white space that
			// is not in quotes
			var parameters = Regex.Matches(input.Substring(1), @"[\""].+?[\""]|[^ ]+")
				.Cast<Match>()
				.Select(m => m.Value)
				.ToList();

			return this.RunCommand(parameters[0], parameters.Skip(1).ToArray());
		}

		/// <summary>
		/// Runs the command.
		/// </summary>
		/// <param name="commandName">Name of the command.</param>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		protected virtual string RunCommand(string commandName, string[] input)
		{
			var command = this.GetCommand(commandName);
			if (command != null)
			{
				return command.Execute(input);
			}

			// If the command is not matched, just return the input
			// TODO: Maybe we could set some state here that would indicate an invalid command to the user?
			return string.Join(" ", input);
		}

		/// <summary>
		/// Gets the command.
		/// </summary>
		/// <param name="commandName">Name of the command.</param>
		/// <returns></returns>
		protected virtual ILiveBlogCommand GetCommand(string commandName)
		{
			return FactoryManager.CommandFactory.GetCommand(this, commandName);
		}
	}
}
