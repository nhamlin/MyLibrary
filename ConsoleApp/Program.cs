using System;
using System.Collections.Generic;
using System.Linq;
using Humanizer;
using MyLibrary.Extensions;

namespace ConsoleApp
{
	class Program
	{
		static void Main()
		{
			string number = "28";
			
			Console.WriteLine("number.To<int>() => " + number.ConvertTo(-1));
			Console.WriteLine("number.To<double>() => " + number.ConvertTo(-1D));
			Console.WriteLine("number.To<decimal>() => " + number.ConvertTo<decimal>(-1));
			Console.WriteLine("number.To<DateTime>() => " + number.ConvertTo(DateTime.MinValue));
			Console.WriteLine(new[] {1, 1, 2, 3, 3, 6}.Mode().ToString("|"));
			Console.WriteLine(new[]{"a", "b", "d", "z"}.ToString(","));
			Console.WriteLine("Some really really really long line to parse and truncate".Truncate(5, "...", Truncator.FixedNumberOfWords));
			Console.ReadLine();
		}
	}
}
