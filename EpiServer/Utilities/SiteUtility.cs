#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/06/2018
// Filename: MyLibrary:EpiServer:SiteUtility.cs
// Usage:          

#endregion

using EpiServer.Models;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;

namespace EpiServer.Utilities
{
	public static class SiteUtility
	{
		private static IContentLoader _contentLoader => ServiceLocator.Current.GetInstance<IContentLoader>();

		public static StartPage StartPage => _contentLoader.Get<StartPage>(ContentReference.StartPage);
	}
}
