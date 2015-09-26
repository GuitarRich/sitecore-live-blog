namespace Sc.LiveBlog.Configuration
{
	using Sc.LiveBlog.Parser;
	using Sc.LiveBlog.Parser.Configuration;

	public interface IConfigurationProvider
	{
		ICommandParserConfigurtation[] CommandParserProviders { get; }

		ICommandParserConfigurtation DefaultCommandParserProvider { get; }
	}
}
