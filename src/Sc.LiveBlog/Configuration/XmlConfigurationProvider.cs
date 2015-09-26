/*
 *
 * Configuration Provider and setup inspired by the genious of https://github.com/kamsar
 *
 */

namespace Sc.LiveBlog.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Xml;

	using Sc.LiveBlog.Parser.Configuration;

	using Sitecore.Configuration;
	using Sitecore.Diagnostics;

	/// <summary>
	/// Reads Unicorn dependency configurations from XML (e.g. Sitecore web.config section sitecore/unicorn)
	/// </summary>
	public class XmlConfigurationProvider : IConfigurationProvider
	{
		private ICommandParserConfigurtation[] commandParserProviders;
		private ICommandParserConfigurtation defaultCommandParserProvider;

		/// <summary>
		/// Gets the command parser providers.
		/// </summary>
		/// <value>
		/// The command parser providers.
		/// </value>
		public ICommandParserConfigurtation[] CommandParserProviders
		{
			get
			{
				if (this.commandParserProviders == null)
				{
					this.LoadConfiguration();
				}

				return this.commandParserProviders;
			}
		}

		/// <summary>
		/// Gets the default command parser provider.
		/// </summary>
		/// <value>
		/// The default command parser provider.
		/// </value>
		public ICommandParserConfigurtation DefaultCommandParserProvider
		{
			get
			{
				if (this.defaultCommandParserProvider == null)
				{
					this.LoadConfiguration();
				}

				return this.defaultCommandParserProvider;
			}
		}

		protected virtual XmlNode GetConfigurationNode()
		{
			return Factory.GetConfigNode("/sitecore/liveBlog");
		}

		protected virtual void LoadConfiguration()
		{
			var configNode = this.GetConfigurationNode();
			Assert.IsNotNull(configNode, "Root LiveBlog config node not found. Missing LiveBlog.config?");

			var defaultProvider = configNode.SelectSingleNode("./commandParserProviders")?.Attributes?["defaultProvider"]?.Value ?? "default";

			var configurationNodes = configNode.SelectNodes("./commandParserProviders/commandParser");

			// no configs let's get outta here
			if (configurationNodes == null || configurationNodes.Count == 0)
			{
				this.commandParserProviders = new ICommandParserConfigurtation[0];
				return;
			}

			var providers = new Collection<ICommandParserConfigurtation>();
			var nameChecker = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			foreach (XmlElement element in configurationNodes)
			{
				var configuration = this.LoadCommandParserConfigurtation(element);

				if (nameChecker.Contains(configuration.Name))
				{
					throw new InvalidOperationException("The LiveBlog CommandParserProvider '" + configuration.Name + "' is defined twice. Configurations should have unique names.");
				}

				nameChecker.Add(configuration.Name);

				if (configuration.Name.Equals(defaultProvider))
				{
					this.defaultCommandParserProvider = configuration;
				}

				providers.Add(configuration);
			}

			this.commandParserProviders = providers.ToArray();
		}

		protected virtual ICommandParserConfigurtation LoadCommandParserConfigurtation(XmlElement configuration)
		{
			var name = this.GetAttributeValue(configuration, "name");

			Assert.IsNotNullOrEmpty(name, "CommandParserProvider node had empty or missing name attribute.");

			var type = this.GetAttributeValue(configuration, "type");
			Assert.IsNotNullOrEmpty(type, "Command node had empty or missing type attribute.");

			var defaultCommandName = configuration.SelectSingleNode("./commands")?.Attributes?["defaultCommand"]?.Value;

			var commandNodes = configuration.SelectNodes("./commands/command");
			Assert.IsNotNull(commandNodes, "No commands found for the CommandParserProvider.");

			var commands = new List<ICommandConfiguration>();
			foreach (XmlElement command in commandNodes)
			{
				commands.Add(this.LoadCommandConfiguration(command));
			}

			return new CommandParserConfiguration(name, type, defaultCommandName, commands.ToArray());

		}

		protected virtual ICommandConfiguration LoadCommandConfiguration(XmlElement command)
		{
			var name = this.GetAttributeValue(command, "name");
			Assert.IsNotNullOrEmpty(name, "Command node had empty or missing name attribute.");

			var keyword = this.GetAttributeValue(command, "keyword");
			Assert.IsNotNullOrEmpty(keyword, "Command node had empty or missing keyword attribute.");

			var description = this.GetAttributeValue(command, "description");

			var type = this.GetAttributeValue(command, "type");
			Assert.IsNotNullOrEmpty(type, "Command node had empty or missing type attribute.");

			return new CommandConfiguration(name, keyword, description, type);
		}

		/// <summary>
		/// Gets an XML attribute value, returning null if it does not exist and its inner text otherwise.
		/// </summary>
		protected virtual string GetAttributeValue(XmlNode node, string attribute)
		{
			return node?.Attributes?[attribute]?.InnerText;
		}
	}
}