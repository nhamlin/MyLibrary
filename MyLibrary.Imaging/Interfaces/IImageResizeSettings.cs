#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/16/2018
// Filename: MyLibrary:MyLibrary.Models:ImageResizeSettings.cs
// Usage:          

#endregion

using System.IO;
using MyLibrary.Imaging.Enums;

namespace MyLibrary.Imaging.Interfaces
{
	public interface IImageResizeSettings
	{
		int Width { get; set; }
		int Height { get; set; }
		ImageResizeMethod Method { get; set; }
		CropOrigin CropOrigin { set; }
		ICropOriginSettings CropOriginSettings { get; set; }
		string CustomHashSeed { get; set; }
		Stream Source { get; set; }
		int GetSettingId();
	}
}
