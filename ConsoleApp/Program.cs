using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using Humanizer;
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

		public static int GetStartingPoint(uint origLength, uint newLength, double factor)
		{
			if (origLength <= newLength)
			{
				return 0;
			}

			// if factor <= 0.0 then it's right-aligned
			// ex: origLength = 200, newLength = 400, factor = -1 => ans: 0
			// ex: origLength = 400, newLength = 300, factor = -1 => num1 = -400, num2 = -200 => num2 = 400, num1 = 100 ans: 100
			// ex: origLength = 1000, newLength = 100, factor = 0 => num1 = 0, num2 = 100 => num2 = 100, num1 = 0 => ans: 0
			// ex: origLength = 1000, newLength = 100, factor = 0.5 => num1 = 450, num2 = 550 => num2 = 550, num1 = 450 ans: 450
			// ex: origLength = 1000, newLength = 100, factor = -1 => num1 = -1000, num2 = -900 => num2 = 900, num1 = 1000 ans: 1000
			double num1 = factor <= 0.0 ? origLength * factor : (origLength - newLength) * factor;
			double num2 = Math.Abs(num1 + newLength);
			num1 = Math.Abs(num1);
			return num1 > num2 ? (int)num2 : (int)num1;  
			//if (num1 > num2)
			//{
			//	return (int)num2;
			//} 

			//return (int)num1; 
		}
		
		private static void Main()
		{
			Console.OutputEncoding = Encoding.UTF8;
			#region Basic EF Example (BloggingContext.cs)

			//using (var db = new BloggingContext())
			//{
			//	// Create and save a new Blog 
			//	Console.Write("Enter a name for a new Blog: ");
			//	var name = Console.ReadLine();

			//	var blog = new Blog { Name = name };
			//	db.Blogs.Add(blog);
			//	db.SaveChanges();

			//	// Display all Blogs from the database 
			//	var query = from b in db.Blogs
			//				orderby b.Name
			//				select b;

			//	Console.WriteLine("All blogs in the database:");
			//	foreach (var item in query)
			//	{
			//		Console.WriteLine(item.Name);
			//	}

			//}

			#endregion

			#region GetStartingPoint

			//uint o, n;
			//o = 1000;
			//n = 100;
			//Console.WriteLine("o:1000, n:100, TL => " + GetStartingPoint(o, n, 0D));
			//Console.WriteLine("o:1000, n:100, TC => " + GetStartingPoint(o, n, 0.5D));
			//Console.WriteLine("o:1000, n:100, TR => " + GetStartingPoint(1000, 100, -1D));
			//Console.WriteLine("o:500, n:500, TL => " + GetStartingPoint(550, 500, 0D));
			//Console.WriteLine("o:500, n:500, TC => " + GetStartingPoint(550, 500, 0.5D));
			//Console.WriteLine("o:500, n:500, TR => " + GetStartingPoint(550, 500, -1D));
			//Console.WriteLine("o:100, n:500, TL => " + GetStartingPoint(100, 500, 0D));
			//Console.WriteLine("o:100, n:500, TC => " + GetStartingPoint(100, 500, 0.5D));
			//Console.WriteLine("o:100, n:500, TR => " + GetStartingPoint(100, 500, -1D));
			//o = -500; // can't put a negative number here

			//Console.WriteLine("o:100, n:500, TL => " + GetStartingPoint(-500, -100, 0D));
			//Console.WriteLine("o:100, n:500, TC => " + GetStartingPoint(-500, -100, 0.5D));
			//Console.WriteLine("o:100, n:500, TR => " + GetStartingPoint(-500, -100, -1D)); 

			#endregion

			#region Hash vs List Find

			//Random random = new Random();
			//var tmp = new List<string>();
			//var find = new List<string>();
			//var watch = new Stopwatch();

			//Console.WriteLine("Starting...");
			//#region Initialize

			//for (int i = 0; i < 10000; i++)
			//{
			//	tmp.Add("item" + random.Next(10000));
			//}

			//var tmpHash = new HashSet<string>(tmp);

			//for (int i = 0; i < 10000; i++)
			//{
			//	find.Add("item" + random.Next(10000));
			//}

			//Console.WriteLine("TempCount: " + tmp.Count);

			//#endregion Initialize

			//watch.Restart();
			////for (int rpt = 0; rpt < 100000; rpt++)
			////{
			////	tmp.Contains(find[rpt]);
			////}
			//var whereInCount = tmp.WhereIn(find).Count();
			//watch.Stop();
			//Console.WriteLine("Hash: " + watch.ElapsedMilliseconds + " ms elapsed.");
			//Console.WriteLine("Count: " + whereInCount);

			//watch.Restart();
			////for (int rpt = 0; rpt < 100000; rpt++)
			////{
			////	tmpHash.Contains(find[rpt]);
			////}
			//var whereIn2Count = tmp.WhereIn(find).Count();
			//watch.Stop();
			//Console.WriteLine("List: " + watch.ElapsedMilliseconds + " ms elapsed.");
			//Console.WriteLine("Count: " + whereIn2Count); 

			#endregion

			#region StringExtensions (Move to Unit Tests)

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

			#endregion

		    //byte[] source = Encoding.ASCII.GetBytes("My string");
            string[] arrayString = new[] { "yeh		I think it might work!", "will my string work" } ;
		    char[] source = "This is a character array.".ToCharArray();
			string oneString = "This is my string and it's fairly long so that I can test various extensions.";
			string nullString = null;

		    char example = 'ç';
		    char result = example.ToUpperInvariant();

		    Console.WriteLine(System.Text.Encoding.ASCII.GetBytes("Hello World!").HashBy<MD5>());
            Console.WriteLine(result);
		    Console.WriteLine("Done. Press the any key to exit..."); 
			Console.ReadKey(true);  
		}
	}
}
