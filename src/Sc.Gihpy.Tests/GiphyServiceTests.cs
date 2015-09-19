namespace Sc.Gihpy.Tests
{
	using System;

	using NUnit.Framework;

	using Sc.Giphy;

	[TestFixture]
    public class GiphyServiceTests
    {
		[Test]
		public void GetGiphyRandom_Kangaroo()
		{
			var giphy = new GiphyService();
			var imageUrl = giphy.GetGiphyRandom("kangaroo");

			Console.WriteLine($"The image url returned was: {imageUrl}");

			Assert.IsNotNull(imageUrl);
			Assert.IsNotEmpty(imageUrl);
		}
    }
}
