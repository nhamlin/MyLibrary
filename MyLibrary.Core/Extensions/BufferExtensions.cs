using System.IO;
using System.Text;
using log4net;

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	/// Extension methods for Buffers
	/// </summary>
	public static class BufferExtensions
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(BufferExtensions));

        /// <summary>
        ///     Converts a byte array to a string, using its byte order mark to convert it to the right encoding.
        ///     http://www.shrinkrays.net/code-snippets/csharp/an-extension-method-for-converting-a-byte-array-to-a-string.aspx
        /// https://weblog.west-wind.com/posts/2007/Nov/28/Detecting-Text-Encoding-for-StreamReader
        /// http://www.anotherchris.net/csharp/an-extension-method-for-converting-a-byte-array-to-a-string-reading-its-bom/
        /// </summary>
        /// <param name="source">An array of bytes to convert</param>
        /// <returns>The byte as a string.</returns>
        public static string AsString(this byte[] source)
		{
		    if (source == null || source.Length == 0)
		        return "";

		    // Ansi as default
		    Encoding encoding = Encoding.Default;

		    /*
            EF BB BF        UTF-8
            FF FE UTF-16    little endian
            FE FF UTF-16    big endian
            FF FE 00 00     UTF-32, little endian
            00 00 FE FF     UTF-32, big-endian
            */
		    if (source[0] == 0xef && source[1] == 0xbb && source[2] == 0xbf)
		        encoding = Encoding.UTF8;
		    else if (source[0] == 0xfe && source[1] == 0xff)
		        encoding = Encoding.Unicode;
		    else if (source[0] == 0xfe && source[1] == 0xff)
		        encoding = Encoding.BigEndianUnicode; // utf-16be
		    else if (source[0] == 0 && source[1] == 0 && source[2] == 0xfe && source[3] == 0xff)
		        encoding = Encoding.UTF32;
		    else if (source[0] == 0x2b && source[1] == 0x2f && source[2] == 0x76)
		        encoding = Encoding.UTF7;
		    using (MemoryStream stream = new MemoryStream())
		    {
		        stream.Write(source, 0, source.Length);
		        stream.Seek(0, SeekOrigin.Begin);
		        using (StreamReader reader = new StreamReader(stream, encoding))
		        {
		            return reader.ReadToEnd();
		        }
		    }
        }
	}
}
