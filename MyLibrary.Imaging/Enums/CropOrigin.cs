#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/16/2018
// Filename: MyLibrary:MyLibrary.Imaging:CropOrigin.cs
// Usage:          
#endregion

namespace MyLibrary.Imaging.Enums
{
	/// <summary>
	/// Where in the original image the cropping should begin
	/// </summary>
	public enum CropOrigin
	{
		Default,
		TopLeft,
		TopCenter,
		TopRight,
		MiddleLeft,
		MiddleCenter,
		MiddleRight,
		BottomLeft,
		BottomCenter,
		BottomRight
	}
}
