namespace Sc.LiveBlog.Parser.Configuration
{
	using System;
	using System.Configuration;
	using System.Linq;

	public class CommandParserConfiguration : ICommandParserConfigurtation
	{
		public CommandParserConfiguration(string name, string typeName, string defaultCommandName,
			ICommandConfiguration[] commands)
		{
			this.Name = name;
			this.TypeName = typeName;
			this.Commands = commands;
			if (string.IsNullOrWhiteSpace(defaultCommandName) == false)
			{
				this.DefaultCommand = commands.FirstOrDefault(command => command.Name == defaultCommandName);
			}
		}

		public string Name { get; }
		public string TypeName { get; }
		public ICommandConfiguration DefaultCommand { get; }
		public ICommandConfiguration[] Commands { get; }

		private Type commandType;

		public T GetInstance<T>() where T : ICommandParser
		{
			if (this.commandType == null)
			{
				this.commandType = Type.GetType(this.TypeName);
			}

			if (this.commandType == null)
			{
				throw new ConfigurationErrorsException("The command type was not found");
			}

			return (T)Activator.CreateInstance(this.commandType);
		}
	}
}
