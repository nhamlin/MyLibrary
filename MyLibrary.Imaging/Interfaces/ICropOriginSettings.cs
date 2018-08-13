#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/16/2018
// Filename: MyLibrary:MyLibrary.Imaging:ICropOriginSettings.cs
// Usage:          

#endregion

using System.Drawing;
using MyLibrary.Imaging.Enums;

namespace MyLibrary.Imaging.Interfaces
{
	public interface ICropOriginSettings
	{
		double Top { get; set; }
		double Left { get; set; }
		CropOrigin CropOrigin { get; set; }
		Rectangle GetRectangle(uint origWidth, uint origHeight, uint newWidth, uint newHeight);
		int GetSettingId();
		int GetStartingPoint(uint origLength, uint newLength, double factor);
	}
}
