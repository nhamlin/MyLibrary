using System.IO;

namespace MyLibrary.Extensions
{
	/// <summary>
	/// Extension methods for Streams
	/// </summary>
	public static class StreamExtensions
	{
		/// <summary>Copies bytes from one stream to another</summary>
		/// <param name="source">The input stream</param>
		/// <param name="destination">The output stream</param>
		public static void CopyTo(this Stream source, Stream destination)
		{
			byte[] buffer = new byte[32768]; // Set buffer to 32K 
			while (true)
			{
				int count = source.Read(buffer, 0, buffer.Length);
				if (count > 0)
				{
					destination.Write(buffer, 0, count);
				}
				else
				{
					break;
				}
			}
		}

		/// <summary>Read a stream into a byte array</summary>
		/// <param name="source">Stream to read</param>
		/// <returns>byte[]</returns>
		public static byte[] ReadAsBytes(this Stream source)
		{
			byte[] buffer = new byte[16384]; // Set buffer to 16K
			using (MemoryStream memoryStream = new MemoryStream())
			{
				int count;
				while ((count = source.Read(buffer, 0, buffer.Length)) > 0)
				{
					memoryStream.Write(buffer, 0, count);
				}

				return memoryStream.ToArray();
			}
		}

		/// <summary>Save a byte array to a file</summary>
		/// <param name="source">Bytes to save</param>
		/// <param name="path">Full path to save file to</param>
		public static void SaveAs(this byte[] source, string path)
		{
			File.WriteAllBytes(path, source);
		}
	}
}
