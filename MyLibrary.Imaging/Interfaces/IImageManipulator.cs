#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/19/2018
// Filename: MyLibrary:MyLibrary.Imaging:IImageManipulator.cs
// Usage:          
#endregion

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using MyLibrary.Imaging.Models;

namespace MyLibrary.Imaging.Interfaces
{
	/// <summary>Describes methods for manipulating images</summary>
	public interface IImageManipulator
	{
		/// <summary>
		/// General manipulation method where the correct actions are derived from the supplied <see cref="T:MyLibrary.Imaging.Models.ImageResizeSettings" />.
		/// </summary>
		/// <param name="source">The source <see cref="T:System.Drawing.Bitmap" /> to manipulate</param>
		/// <param name="settings">The <see cref="T:MyLibrary.Imaging.Models.ImageResizeSettings" /> settings to use when manipulating.</param>
		/// <returns>A manipulated <see cref="T:System.Drawing.Bitmap" />, or the <paramref name="source" /> if no manipulation was neccesary or possible.</returns>
		Bitmap Manipulate(Bitmap source, ImageResizeSettings settings);

		/// <summary>
		/// Crop an image using provided <see cref="T:MyLibrary.Imaging.Models.CropOriginSettings" />
		/// </summary>
		Bitmap Crop(Bitmap source, int width, int height, CropOriginSettings cropOriginSettings);

		/// <summary>
		/// Crop an image with the target top and left origin being defined in pixels.
		/// </summary>
		Bitmap Crop(Bitmap source, int width, int height, int top, int left);

		/// <summary>
		/// Scale an image to the target values, but keeping proportions, meaning the iamge can get larger than the original
		/// </summary>
		Bitmap Scale(Bitmap source, int targetWidth, int targetHeight);

		/// <summary>
		/// Constrain the size of an image as to not be bigger than any of the provided dimensions
		/// </summary>
		Bitmap Constrain(Bitmap source, int maxWidth, int maxHeight);

		/// <summary>Resize an image, disregarding proportions</summary>
		Bitmap Resize(Bitmap source, int width, int height);

		/// <summary>Try to open an image from a stream</summary>
		bool TryOpen(Stream imageStream, out Bitmap image);

		/// <summary>Write an image to a byte array</summary>
		byte[] WriteImage(Bitmap image, ImageFormat format);
	}
}
