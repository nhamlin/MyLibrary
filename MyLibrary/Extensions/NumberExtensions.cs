using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Extensions
{
    public static class NumberExtensions
    {
	    public static ICollection<T> Mode<T>(this IEnumerable<T> sources)
	    {
		    var charGroups = (from c in testString
		                      group c by c into g
		                      select new
		                             {
			                             c = g.Key,
			                             count = g.Count(),
		                             }).OrderByDescending(c => c.count);
		    foreach (var group in charGroups)
		    {
			    Console.WriteLine(group.c + ": " + group.count);
		    }
		}
    }
}
