using System.Text;

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	/// Extension methods for Buffers
	/// </summary>
	public static class BufferExtensions
	{
		/// <summary>
		///     Converts a byte array to a string, using its byte order mark to convert it to the right encoding.
		///     http://www.shrinkrays.net/code-snippets/csharp/an-extension-method-for-converting-a-byte-array-to-a-string.aspx
		/// </summary>
		/// <param name="source">An array of bytes to convert</param>
		/// <returns>The byte as a string.</returns>
		public static string AsString(this byte[] source)
		{
			return source == null ? "" : Encoding.UTF8.GetString(source, 0, source.Length);
		}
	}
}
