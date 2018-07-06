using System;
using System.Collections.Generic;
using System.Diagnostics;
using Humanizer;
using MyLibrary.Extensions;

namespace ConsoleApp
{
	static class Program
	{
		private static void Main()
		{
			var tmp = new List<string>();
			for (int i = 0; i < 1000000; i++)
			{
				if (i % 3 == 0)
				{
					tmp.Add(null);
				}
				else
				{
					tmp.Add("item" + i);
				}
			}

			Console.WriteLine("TempCount: " + tmp.Count);
			var watch = new Stopwatch();
			watch.Start();
			var temp = tmp.RemoveNull();
			
			watch.Stop();
			Console.WriteLine("RemoveNull: "+ watch.ElapsedMilliseconds + " elapsed.");
			tmp = new List<string>();

			for (int i = 0; i < 1000000; i++)
			{
				if (i % 3 == 0)
				{
					tmp.Add(null);
				}
				else
				{
					tmp.Add("item" + i);
				}
			}
			Console.WriteLine("TempCount: " + tmp.Count);
			watch.Restart();
			temp = tmp.RemoveNull();
			watch.Stop();
			Console.WriteLine("RemoveNullYield: " + watch.ElapsedMilliseconds + " elapsed.");
			Console.Read();
			return;
			string number = "27";
			string reallyLongString = "Some really, really, really long string to parse and truncate.";
			int[] integers = { 1, 1, 2, 3, 3, 6 };
			string[] strings = { "a", "b", "d", "z" };
			char charD = 'a';

			Console.WriteLine(string.Join(",", GetNumbers(2, 1590809955000)));

			Console.WriteLine((number + ".ConvertTo<int>()").PadRight(50) + " => " + number.ConvertTo(-1));
			Console.WriteLine((number + ".ConvertTo<double>()").PadRight(50) + " => " + number.ConvertTo(-1D));
			Console.WriteLine((number + ".ConvertTo<decimal>()").PadRight(50) + " => " + number.ConvertTo<decimal>(-1));
			Console.WriteLine((number + ".ConvertTo<DateTime>(DateTime.MinValue)").PadRight(50) + " => " + number.ConvertTo(DateTime.MinValue));
			Console.WriteLine("integers.Mode().ToString(\"|\")".PadRight(50) + " => " + integers.Mode().ToString("|"));
			Console.WriteLine("strings.ToString(\", \")".PadRight(50) + " => " + strings.ToString(", "));
			Console.WriteLine(reallyLongString.Truncate(7, "...", Truncator.FixedNumberOfWords));
			Console.WriteLine(reallyLongString.Truncate(8, "...", Truncator.FixedLength));
			Console.WriteLine(reallyLongString.Truncate(8, "...", Truncator.FixedNumberOfCharacters));
			Console.WriteLine((charD + ".ToHex()").PadRight(50) + " => " + 'a'.ToHex());
			Console.ReadLine();
		}

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

		

	}

}
