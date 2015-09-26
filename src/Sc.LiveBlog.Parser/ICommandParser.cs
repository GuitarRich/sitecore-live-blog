namespace Sc.LiveBlog.Parser
{
	public interface ICommandParser
	{
		string Name { get; set; }

		string Parse(string input);
	}
}
