using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MyLibrary.Core.Extensions;

//using Humanizer;
//using MyLibrary.Core.Extensions;

namespace ConsoleApp
{
	static class Program
	{
		public static List<double> GetNumbers(double start, double end)
		{
			List<double> returnList = new List<double> { start };
			double x = start;
			do
			{
				returnList.Add(x);
				x = returnList[returnList.Count - 2] + x;
			} while (x <= end);

			return returnList;
		}

		private static void Main()
		{
			Random random = new Random();
			var tmp = new List<string>();
			var find = new List<string>();
			var watch = new Stopwatch();

			Console.WriteLine("Starting...");
			#region Initialize

			for (int i = 0; i < 10000; i++)
			{
				tmp.Add("item" + random.Next(10000));
			}

			var tmpHash = new HashSet<string>(tmp);

			for (int i = 0; i < 10000; i++)
			{
				find.Add("item" + random.Next(10000));
			}

			Console.WriteLine("TempCount: " + tmp.Count);

			#endregion Initialize

			watch.Restart();
			//for (int rpt = 0; rpt < 100000; rpt++)
			//{
			//	tmp.Contains(find[rpt]);
			//}
			var whereInCount = tmp.WhereIn(find).Count();
			watch.Stop();
			Console.WriteLine("Hash: " + watch.ElapsedMilliseconds + " ms elapsed.");
			Console.WriteLine("Count: " + whereInCount);

			watch.Restart();
			//for (int rpt = 0; rpt < 100000; rpt++)
			//{
			//	tmpHash.Contains(find[rpt]);
			//}
			var whereIn2Count = tmp.WhereIn(find).Count();
			watch.Stop();
			Console.WriteLine("List: " + watch.ElapsedMilliseconds + " ms elapsed.");
			Console.WriteLine("Count: " + whereIn2Count);

			Console.WriteLine("Done. Press CTRL-C to exit...");
			Console.Read();
			//string number = "27";
			//string reallyLongString = "Some really, really, really long string to parse and truncate.";
			//int[] integers = { 1, 1, 2, 3, 3, 6 };
			//string[] strings = { "a", "b", "d", "z" };
			//char charD = 'a';

			//Console.WriteLine(string.Join(",", GetNumbers(2, 1590809955000)));

			//Console.WriteLine((number + ".ConvertTo<int>()").PadRight(50) + " => " + number.ConvertTo(-1));
			//Console.WriteLine((number + ".ConvertTo<double>()").PadRight(50) + " => " + number.ConvertTo(-1D));
			//Console.WriteLine((number + ".ConvertTo<decimal>()").PadRight(50) + " => " + number.ConvertTo<decimal>(-1));
			//Console.WriteLine((number + ".ConvertTo<DateTime>(DateTime.MinValue)").PadRight(50) + " => " + number.ConvertTo(DateTime.MinValue));
			//Console.WriteLine("integers.Mode().ToString(\"|\")".PadRight(50) + " => " + integers.Mode().ToString("|"));
			//Console.WriteLine("strings.ToString(\", \")".PadRight(50) + " => " + strings.ToString(", "));
			//Console.WriteLine(reallyLongString.Truncate(7, "...", Truncator.FixedNumberOfWords));
			//Console.WriteLine(reallyLongString.Truncate(8, "...", Truncator.FixedLength));
			//Console.WriteLine(reallyLongString.Truncate(8, "...", Truncator.FixedNumberOfCharacters));
			//Console.WriteLine((charD + ".ToHex()").PadRight(50) + " => " + 'a'.ToHex());
			//Console.ReadLine();
		}
	}
}
