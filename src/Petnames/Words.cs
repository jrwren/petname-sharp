//  Words.cs
//
//  Created by Jay Wren on 10/22/17.
//  Copyright © 2017 Jay Wren. All rights reserved.
//
using System;
using System.Collections.Generic;

namespace Petnames
{
	public static partial class Words
	{
		public static Lazy<Random> random = new Lazy<Random>(() => new Random());

		public static Random Random => random.Value;

		public static string RandomBetween(IList<string> words, int start, int end)
		{
			return words[Random.Next(start, end)];
		}

		public static string RandomItem(IList<string> words)
		{
			return RandomBetween(words, 0, words.Count);
		}

		public static string RandomAdverb()
		{
			return RandomItem(LargeAdverbs);
		}

		public static string RandomAdjectives()
		{
			return RandomItem(LargeAdjectives);
		}

		public static string RandomAnimal()
		{
			return RandomItem(LargeNames);
		}

		public static string RandomName()
		{
			return RandomItem(MediumNames);
		}

		public static string RandomPhrase(int numwords = 2, string separator = "-", bool name = false, bool alliterative = false)
		{
			Func<string> namer = RandomAnimal;
			if (name)
			{
				namer = () => RandomName();
			}
			if (1 == numwords)
			{
				return namer();
			}
			Func<string> getadj = RandomAnimal;
			Func<string> getadv = RandomAdverb;
			var bname = namer();
			if (alliterative)
			{
				var letter = bname[0];
				getadj = () =>
				{
					var o = adjectiveOffsets[letter];
					return RandomBetween(LargeAdjectives, o.Item1, o.Item2);
				};
				getadv = () =>
				{
					var o = adverbOffsets[letter];
					return RandomBetween(LargeAdverbs, o.Item1, o.Item2);
				};
			}
			if (2 == numwords)
			{
				return getadj() + separator + bname;
			}
			var petname = new List<string>();
			for (int i = 0; i < numwords - 2; i++)
			{
				petname.Add(getadv());
			}
			petname.Add(getadj());
			petname.Add(bname);
			return string.Join(separator, petname);
		}

		public static Dictionary<char, Tuple<int, int>> adverbOffsets = new Dictionary<char, Tuple<int, int>>{
			{'a', Tuple.Create (0  , 677 )},
			{'b', Tuple.Create ( 678  ,  1025 )},
			{'c', Tuple.Create ( 1026  ,  1859 )},
			{'d', Tuple.Create ( 1860  ,  2452 )},
			{'e', Tuple.Create ( 2453  ,  2856 )},
			{'f', Tuple.Create ( 2857  ,  3239 )},
			{'g', Tuple.Create ( 3240  ,  3510 )},
			{'h', Tuple.Create ( 3511  ,  3844 )},
			{'i', Tuple.Create ( 3845  ,  4525 )},
			{'j', Tuple.Create ( 4526  ,  4597 )},
			{'k', Tuple.Create ( 4598  ,  4631 )},
			{'l', Tuple.Create ( 4632  ,  4873 )},
			{'m', Tuple.Create ( 4874  ,  5248 )},
			{'n', Tuple.Create ( 5249  ,  6565 )},
			{'o', Tuple.Create ( 6566  ,  7112 )},
			{'p', Tuple.Create ( 7113  ,  7961 )},
			{'q', Tuple.Create ( 7962  ,  8004 )},
			{'r', Tuple.Create ( 8005  ,  8381 )},
			{'s', Tuple.Create ( 8382  ,  9780 )},
			{'t', Tuple.Create ( 9781  ,  10167 )},
			{'u', Tuple.Create ( 10168  ,  12208 )},
			{'v', Tuple.Create ( 12209  ,  12348 )},
			{'w', Tuple.Create ( 12349  ,  12519 )},
			{'x', Tuple.Create ( 12520  ,  12525 )},
			{'y', Tuple.Create ( 12526  ,  12537 )},
			{'z', Tuple.Create ( 12538  ,  12546 )},
		};

		public static Dictionary<char, Tuple<int, int>> adjectiveOffsets = new Dictionary<char, Tuple<int, int>>{
			{'a', Tuple.Create ( 0  ,  1905 ) },
			{'b', Tuple.Create ( 1906  ,  2901 )},
			{'c', Tuple.Create ( 2902  ,  5074 )},
			{'d', Tuple.Create ( 5075  ,  6201 )},
			{'e', Tuple.Create ( 6202  ,  7223 )},
			{'f', Tuple.Create ( 7224  ,  8155 )},
			{'g', Tuple.Create ( 8156  ,  8989 )},
			{'h', Tuple.Create ( 8990  ,  10178 )},
			{'i', Tuple.Create ( 10179  ,  11619 )},
			{'j', Tuple.Create ( 11620  ,  11767 )},
			{'k', Tuple.Create ( 11768  ,  11913 )},
			{'l', Tuple.Create ( 11914  ,  12640 )},
			{'m', Tuple.Create ( 12641  ,  13787 )},
			{'n', Tuple.Create ( 13788  ,  17088 )},
			{'o', Tuple.Create ( 17089  ,  17986 )},
			{'p', Tuple.Create ( 17987  ,  21096 )},
			{'q', Tuple.Create ( 21097  ,  21187 )},
			{'r', Tuple.Create ( 21188  ,  21983 )},
			{'s', Tuple.Create ( 21984  ,  25400 )},
			{'t', Tuple.Create ( 25401  ,  26502 )},
			{'u', Tuple.Create ( 26503  ,  35758 )},
			{'v', Tuple.Create ( 35759  ,  36131 )},
			{'w', Tuple.Create ( 36132  ,  36479 )},
			{'x', Tuple.Create ( 36480  ,  36504 )},
			{'y', Tuple.Create ( 36505  ,  36525 )},
			{'z', Tuple.Create ( 36526  ,  36581 )},
		};
	}
}
