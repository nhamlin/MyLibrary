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
		public virtual void Create(T stream, string fileName)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public virtual T Read(T stream, string fileName)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public virtual void Update(T entity, string fileName)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public virtual void Delete(T entity, string fileName)
		{
			throw new NotImplementedException();
		}
	}
}
