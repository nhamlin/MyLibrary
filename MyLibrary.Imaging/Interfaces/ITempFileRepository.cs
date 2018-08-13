#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/19/2018
// Filename: MyLibrary:MyLibrary.Imaging:ITempFileRepository.cs
// Usage:          
#endregion

using System.IO;

namespace MyLibrary.Imaging.Interfaces
{
	/// <summary>
	/// describes a repository holding temp files, these are not meant to be accessed directly and there is no assurance they exist at any given time
	/// </summary>
	public interface ITempFileRepository
	{
		/// <summary>
		/// Open a <see cref="T:System.IO.Stream" /> for reading the file.
		/// </summary>
		Stream Open(string filePath);

		/// <summary>Returns the contents of the file as a byte array.</summary>
		byte[] Get(string filePath);

		/// <summary>Returns wether the file exists (in this repository).</summary>
		bool Exists(string filePath);

		/// <summary>Add a file to the repository.</summary>
		/// <returns>A string with the full external path to the file</returns>
		string Add(string filePath, byte[] data);

		/// <summary>Returns the external, accessable, url for the file.</summary>
		string GetExternalUrl(string filePath);

		/// <summary>
		/// Clean up old temp files. The specifics of what to remove is left to the implementation.
		/// </summary>
		/// <remarks>
		/// Not all implementations support cleanup, if so, they do nothing when this method is called.
		/// </remarks>
		/// <returns>A report stating what was done.</returns>
		string Cleanup();

		/// <summary>
		/// Clean up old temp files. The specifics of what to remove is left to the implementation.
		/// </summary>
		/// <param name="force">If true, all temp files will be removed, regardless if they are too old or not, if the provider support it.</param>
		/// <remarks>
		/// Not all implementations support a full cleanup, or even any cleanup.
		/// </remarks>
		/// <returns>A report stating what was done.</returns>
		string Cleanup(bool force);
	}
}
