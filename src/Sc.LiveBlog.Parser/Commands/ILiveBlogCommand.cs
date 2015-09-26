namespace Sc.LiveBlog.Parser.Commands
{
	public interface ILiveBlogCommand
	{
		string Execute(string[] parameters);
	}
}
