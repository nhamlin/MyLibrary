#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/06/2018
// Filename: MyLibrary:EpiServer:Constants.cs
// Usage:          

#endregion

using System.ComponentModel;

namespace EpiServer
{
	public static class Constants
	{
		public static class LinkTargets
		{
			[Description("Current Window")]
			public const string CurrentWindow = "_self";

			[Description("New Window")]
			public const string NewWindow = "_blank";
		}
	}
}
