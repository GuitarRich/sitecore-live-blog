namespace Sc.LiveBlog.Data
{
	using Sc.LiveBlog.Model;

	public interface IBlogEntryManager
	{
		void PostNewEntry(BlogEntryModel model);
	}
}
