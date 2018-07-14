#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/12/2018
// Filename: MyLibrary:MyLibrary:BaseFileImporter.cs
// Usage:

#endregion header

using System;
using MyLibrary.Interfaces;

namespace MyLibrary.Core.Utilities
{
	/// <inheritdoc />
	/// <summary>
	///     Base class for all file utility classes
	/// </summary>
	public abstract class BaseFileUtility<T> : IFileRepository<T>
	{
		/// <inheritdoc />
		public virtual T GetById(object id)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public T Get(object id)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public void Insert(T entity)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public void Update(T entity)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public void Delete(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
