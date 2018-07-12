#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/06/2018
// Filename: MyLibrary:EpiServer:FileUtility.cs
// Usage:

#endregion header

using EPiServer.Framework.Blobs;
using MyLibrary.Formatters;

namespace EpiServer.Utilities
{
	public static class EpiFileUtility
	{

		public static string GetFormattedFilesize(Blob binaryData)
		{
			if (binaryData == null)
			{
				return string.Empty;
			}

			using (var binaryStream = binaryData.OpenRead())
			{
				return FilesizeFormatter.FormatFilesize(binaryStream.Length);
			}
		}
	}
}
