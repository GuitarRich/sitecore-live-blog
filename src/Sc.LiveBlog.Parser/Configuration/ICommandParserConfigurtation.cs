namespace Sc.LiveBlog.Parser.Configuration
{
	public interface ICommandParserConfigurtation
	{
		string Name { get; }
		string TypeName { get; }

		ICommandConfiguration DefaultCommand { get; }

		ICommandConfiguration[] Commands { get; }

		T GetInstance<T>() where T : ICommandParser;
	}
}
