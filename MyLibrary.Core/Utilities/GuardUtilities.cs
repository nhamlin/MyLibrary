using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Core.Extensions;

namespace MyLibrary.Core.Utilities
{
    /// <summary>
    /// Guard Clauses. Inspired by: https://github.com/ardalis/GuardClauses
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// [Guard Clause] Quick check whether the argument is null and throws an exception if so. Use at beginning of methods.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="sourceName"></param>
        public static void AgainstNull(object source, string sourceName)
        {
            Contract.Requires<ArgumentNullException>(source != null, $"{sourceName} is null.");            
        }

        /// <summary>
        /// [Guard Clause] Quick check that the string is valid but empty.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="sourceName"></param>
        public static void AgainstEmptyString(string source, string sourceName)
        {
            Contract.Requires<ArgumentException>(source != string.Empty, $"{sourceName} is not valid.");
        }

        /// <summary>
        /// [Guard Clause] Quick check that the string is not null or empty.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="sourceName"></param>
        public static void AgainstNullOrEmpty(string source, string sourceName)
        {
            Guard.AgainstNull(source, sourceName);
            Guard.AgainstEmptyString(source, sourceName);
        }

        /// <summary>
        /// [Guard Clause] Quick check that a generic enumerable is not null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="sourceName"></param>
        public static void AgainstNullOrEmpty<T>(IEnumerable<T> source, string sourceName)
        {
            Guard.AgainstNull(source, sourceName);
            Contract.Requires<ArgumentException>(source.Any(), $"{sourceName} is empty.");
        }

        /// <summary>
        /// [Guard Clause] Validates that a string is not null or empty or simply white space.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="sourceName"></param>
        public static void AgainstNullOrWhiteSpace(string source, string sourceName)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(source), $"{sourceName} is not valid.");
        }

        /// <summary>
        /// [Guard Clause] Validates that a variable has a value that falls within a range.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="sourceName"></param>
        public static void AgainstOutOfRange(int source, int min, int max, string sourceName)
        {
            AgainstOutOfRange<int>(source, sourceName, min, max);
        }

        public static void AgainstOutOfRange(DateTime source, string sourceName, DateTime min, DateTime max)
        {
            AgainstOutOfRange<DateTime>(source, sourceName, min, max);
        }

        public static void AgainstOutOfSQLDateRange(DateTime source, string sourceName)
        {
            //// System.Data is unavailable in .NET Standard so we can't use SqlDateTime.
            //const long sqlMinDateTicks = 552877920000000000;
            //const long sqlMaxDateTicks = 3155378975999970000;
            AgainstOutOfRange<SqlDateTime>(source, sourceName, SqlDateTime.MinValue, SqlDateTime.MaxValue);
        }
        
        public static void AgainstOutOfRange(decimal source, string sourceName, decimal min, decimal max)
        {
            AgainstOutOfRange<decimal>(source, sourceName, min, max);
        }

        public static void AgainstOutOfRange(short source, string sourceName, short min, short max)
        {
            AgainstOutOfRange<short>(source, sourceName, min, max);
        }

        public static void AgainstOutOfRange(float source, string sourceName, float min, float max)
        {
            AgainstOutOfRange<float>(source, sourceName, min, max);
        }

        /// <summary>
        /// [Guard Clause] Validates that a variable has a value that falls within a range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="sourceName"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static void AgainstOutOfRange<T>(T source, string sourceName, T min, T max)
        {
            var comparer = Comparer<T>.Default;
            Contract.Requires<ArgumentException>(comparer.Compare(min, max) < 0, $"{nameof(min)} should be less or equal than {nameof(max)}");
            Contract.Requires<ArgumentOutOfRangeException>(comparer.Compare(source, min) > 0 && comparer.Compare(source, max) < 0, $"{sourceName} was out of range.");
        }
    }
}
