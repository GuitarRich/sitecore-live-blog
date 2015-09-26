namespace Sc.LiveBlog.Factories
{
	public class FactoryManager
	{
		static FactoryManager()
		{
			CommandFactory = new CommandFactory();
		}

		public static CommandFactory CommandFactory { get; }
	}
}
