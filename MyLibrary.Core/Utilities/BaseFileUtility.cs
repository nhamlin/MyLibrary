#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/12/2018
// Filename: MyLibrary:MyLibrary:BaseFileImporter.cs
// Usage:

#endregion header

using System;
using System.IO;
using System.Net;
using System.Web.Hosting;
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
		public virtual void Create(T stream, string path)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public virtual Stream Read(T stream, string path)
		{
			if (new Uri(path, UriKind.RelativeOrAbsolute).IsAbsoluteUri)
			{
				try
				{
					using (WebClient webClient = new WebClient())
						return webClient.OpenRead(path);
				}
				catch
				{
					//TODO: Implement Exception Handling
				}
			}

			try
			{
				return HostingEnvironment.VirtualPathProvider.GetFile(path).Open();
			}
			catch
			{
				// TODO: Implement Exception Handling
			}
			return null;
		}

		/// <inheritdoc />
		public virtual void Update(T stream, string path)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public virtual void Delete(T stream, string path)
		{
			throw new NotImplementedException();
		}
	}
}