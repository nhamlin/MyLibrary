#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/06/2018
// Filename: MyLibrary:EpiServer:FileUtility.cs
// Usage:

#endregion header

using EPiServer.Framework.Blobs;

namespace EpiServer.Utilities
{
	public static class FileUtility
	{
		public static string FormatFilesize(double fileLength)
		{
			string[] sizes = { "B", "KB", "MB", "GB", "TB", "PB" };
			double len = fileLength;
			int order = 0;

			while (len >= 1024 && order < sizes.Length - 1)
			{
				order++;
				len = len / 1024;
			}

			return $"{len:0.#} {sizes[order]}";
		}

		public static string GetFormattedFilesize(Blob binaryData)
		{
			if (binaryData == null)
			{
				return string.Empty;
			}

			using (var binaryStream = binaryData.OpenRead())
			{
				return FormatFilesize(binaryStream.Length);
			}
		}
	}
}
