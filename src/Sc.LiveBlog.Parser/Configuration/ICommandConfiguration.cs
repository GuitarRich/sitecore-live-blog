namespace Sc.LiveBlog.Parser.Configuration
{
	using System.Dynamic;
	using System.Runtime.InteropServices.ComTypes;

	using Sc.LiveBlog.Parser.Commands;

	public interface ICommandConfiguration
	{
		string Name { get; }

		string Keyword { get; }

		string Description { get; }

		string TypeName { get; }

		T GetInstance<T>() where T : ILiveBlogCommand;
	}
}
