#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/19/2018
// Filename: MyLibrary:MyLibrary.Imaging:ControllerRoutedTempFileRepository.cs
// Usage:          
#endregion

using System.IO;
using MyLibrary.Imaging.Interfaces;

namespace MyLibrary.Imaging.Models
{
	/// <summary>
	/// Implementation of a <see cref="T:MyLibrary.Imaging.Interfaces.ITempFileRepository" />.
	/// </summary>
	public abstract class TempFileRepository : ITempFileRepository
	{
		/// <summary>
		/// Open a <see cref="T:System.IO.Stream" /> for reading the file.
		/// </summary>
		public virtual Stream Open(string filePath)
		{
			byte[] buffer = this.Get(filePath);
			if (buffer != null)
				return new MemoryStream(buffer);
			return null;
		}

		/// <summary>Returns the contents of the file as a byte array.</summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public abstract byte[] Get(string filePath);

		/// <summary>Returns wether the file exists (in this repository).</summary>
		public abstract bool Exists(string filePath);

		/// <summary>Add a file to the repository.</summary>
		/// <returns>A string with the full external path to the file</returns>
		public abstract string Add(string filePath, byte[] data);

		/// <summary>Returns the external, accessable, url for the file.</summary>
		public virtual string GetExternalUrl(string filePath)
		{
			return Path.Combine("/", "tempfiles/", filePath);
		}

		/// <summary>
		/// Clean up old temp files. The specifics of what to remove is left to the implementation.
		/// </summary>
		/// <returns>A report stating what was done.</returns>
		public virtual string Cleanup()
		{
			return this.Cleanup(false);
		}

		/// <summary>
		/// Clean up old temp files. The specifics of what to remove is left to the implementation.
		/// </summary>
		/// <returns>A report stating what was done.</returns>
		public abstract string Cleanup(bool force);
	}
}
