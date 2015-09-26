namespace Sc.LiveBlog.Parser.Configuration
{
	using System;
	using System.Configuration;

	using Sc.LiveBlog.Parser.Commands;

	public class CommandConfiguration : ICommandConfiguration
	{
		public CommandConfiguration(string name, string keyword, string description, string type)
		{
			this.Name = name;
			this.Keyword = keyword;
			this.Description = description;
			this.TypeName = type;
		}

		public string Name { get; }
		public string Keyword { get; }
		public string Description { get; }
		public string TypeName { get; }

		private Type commandType;

		public T GetInstance<T>() where T : ILiveBlogCommand
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
