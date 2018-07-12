#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/06/2018
// Filename: MyLibrary:EpiServer:FileUtility.cs
// Usage:

#endregion header

namespace MyLibrary.Formatters
{
	/// <summary>
	/// Utilities for file management
	/// </summary>
	public static class FilesizeFormatter
	{
		/// <summary>
		/// Returns the filesize in a human-readable string
		/// </summary>
		/// <param name="fileLength"></param>
		/// <returns></returns>
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
	}
}
