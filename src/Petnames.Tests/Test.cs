using NUnit.Framework;
using System;
namespace Petnames
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void HasRandomPhrase()
		{
			var phrase = Words.RandomPhrase(4, " ", true, false);
			var parts = phrase.Split(' ');
			Assert.AreEqual(4, parts.Length);
		}

		[Test()]
		public void HasRandomPhraseWithDefaults()
		{
			var phrase = Words.RandomPhrase(4);
			var parts = phrase.Split('-');
			Assert.AreEqual(4, parts.Length);
		}
	}
}
