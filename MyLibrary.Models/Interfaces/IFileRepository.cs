#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/12/2018
// Filename: MyLibrary:MyLibrary:IFileRepository.cs
// Usage:          

#endregion

namespace MyLibrary.Interfaces
{
	/// <summary>
	///     Interface of the Repository Pattern for File CRUD Operations
	/// </summary>
	public interface IFileRepository<T>
	{
		/// <summary>
		///     Inserts a record
		/// </summary>
		/// <param name="stream">Datastream</param>
		/// <param name="fileName">Name of the file to create</param>
		void Create(T stream, string fileName);

		/// <summary>
		///     Gets a record by the primary id
		/// </summary>
		/// <param name="stream">Datastream</param>
		/// <param name="fileName">Name of the file to read</param>
		/// <returns></returns>
		T Read(T stream, string fileName);

		/// <summary>
		///     Updates a record
		/// </summary>
		/// <param name="stream">Datastream</param>
		/// <param name="fileName">Name of the file to update</param>
		void Update(T stream, string fileName);

		/// <summary>
		///     Deletes a record
		/// </summary>
		/// <param name="stream">Datastream</param>
		/// <param name="fileName">Name of the file to delete</param>
		void Delete(T stream, string fileName);
	}
}
