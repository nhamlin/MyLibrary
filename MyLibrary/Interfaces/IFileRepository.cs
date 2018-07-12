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
	/// Interface of the Repository Pattern for File CRUD Operations
	/// </summary>
	public interface IFileRepository<T>
	{
		/// <summary>
		/// Gets a record by the primary id
		/// </summary>
		/// <param name="id">Object that represents the primary id</param>
		/// <returns></returns>
		T GetById(object id);
		/// <summary>
		/// Gets a record by the primary id
		/// </summary>
		/// <param name="id">Object that represents the primary id</param>
		/// <returns></returns>
		T Get(object id);
		/// <summary>
		/// Inserts a record
		/// </summary>
		/// <param name="entity">Entity object to be inserted into the repository</param>
		void Insert(T entity);
		/// <summary>
		/// Updates a record
		/// </summary>
		/// <param name="entity">Entity object to be updated in the repository</param>
		void Update(T entity);
		/// <summary>
		/// Deletes a record
		/// </summary>
		/// <param name="entity">Entity object to be deleted from the repository</param>
		void Delete(T entity);

	}
}
