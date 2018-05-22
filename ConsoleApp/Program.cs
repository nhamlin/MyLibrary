﻿using System;
using Humanizer;
using MyLibrary.Extensions;

namespace ConsoleApp
{
	class Program
	{
		static void Main()
		{
			string number = "28";
			Console.WriteLine("number.To<int>() => " + number.To(-1));
			Console.WriteLine("number.To<double>() => " + number.To(-1D));
			Console.WriteLine("number.To<decimal>() => " + number.To<decimal>(-1));
			Console.WriteLine("number.To<DateTime>() => " + number.To(DateTime.MinValue));
			Console.WriteLine("Some really really really long line to parse and truncate".Truncate(5, "...", Truncator.FixedNumberOfWords));
			Console.ReadLine();
		}
	}
}
