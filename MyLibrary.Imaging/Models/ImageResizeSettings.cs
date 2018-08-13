#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/16/2018
// Filename: MyLibrary:MyLibrary.Imaging:ImageResizeSettings.cs
// Usage:          

#endregion

using System;
using System.IO;
using MyLibrary.Imaging.Enums;
using MyLibrary.Imaging.Interfaces;

namespace MyLibrary.Imaging.Models
{
	public class ImageResizeSettings : IImageResizeSettings
	{
		public ImageResizeSettings(Stream source, ImageResizeMethod method, int width, int height, CropOrigin cropOrigin)
			: this(source, method, width, height, Models.CropOriginSettings.GetSettings(cropOrigin))
		{
		}

		public ImageResizeSettings(Stream source, ImageResizeMethod method, int width, int height, ICropOriginSettings cropOriginSettings = null)
		{
			Width = width;
			Height = height;
			Method = method;
			Source = source;
			if (cropOriginSettings == null)
			{
				CropOriginSettings = Models.CropOriginSettings.TopLeft;
			}
		}

		public int Width { get; set; }
		public int Height { get; set; }
		public ImageResizeMethod Method { get; set; }
		public CropOrigin CropOrigin { get; set; }
		public ICropOriginSettings CropOriginSettings { get; set; }
		public string CustomHashSeed { get; set; }
		public Stream Source { get; set; }

		public int GetSettingId()
		{
			throw new NotImplementedException();
		}
	}
}
