#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/16/2018
// Filename: MyLibrary:MyLibrary.Core:ImageUtilities.cs
// Usage:          

#endregion

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net;
using System.Web.Hosting;
using MyLibrary.Imaging.Interfaces;
using MyLibrary.Imaging.Models;

namespace MyLibrary.Imaging.Utilities
{
	/// <summary>
	///     Utilities for handling Image operations
	/// </summary>
	public class ImageUtilities
	{
		private readonly IImageManipulator _imageManipulator;
		private readonly ITempFileRepository _tempFileRepository;

		// TODO: Add logger

		public ImageUtilities(ITempFileRepository tempFileRepository, IImageManipulator imageManipulator)
		{
			_tempFileRepository = tempFileRepository ?? throw new ArgumentNullException(nameof(tempFileRepository));
			_imageManipulator = imageManipulator ?? throw new ArgumentNullException(nameof(imageManipulator));
		}

		/// <summary>
		///     Gets a modified temporary image using a source image url and
		///     <see cref="T:MyLibrary.Imaging.Models.ImageResizeSettings" />.
		/// </summary>
		public virtual string GetModifiedImage(string sourceImagePath, ImageResizeSettings settings)
		{
			if (settings == null)
			{
				throw new ArgumentException(nameof(settings));
			}

			// TODO: Add logging utilities
			//SystemLog.Log((object)this, string.Format("GetModifiedImage: getting modified image for url '{0}'", (object)sourceImagePath), Level.Debug, (Exception)null);
			string tempFileName = GenerateTempFileName(sourceImagePath, (object)settings.GetSettingId());
			string externalUrl = _tempFileRepository.GetExternalUrl(tempFileName);
			if (_tempFileRepository.Exists(tempFileName))
			{
				//SystemLog.Log((object)this, string.Format("GetModifiedImage: found temp image for url '{0}' at '{1}'", (object)sourceImagePath, (object)externalUrl), Level.Information, (Exception)null);
				return externalUrl;
			}

			using (Stream sourceData = OpenFileStream(sourceImagePath))
			{
				//SystemLog.Log((object)this, string.Format("GetModifiedImage: manipulating source image '{0}'", (object)sourceImagePath), Level.Debug, (Exception)null);
				byte[] data = ModifyImage(sourceData, settings);
				if (data != null)
				{
					_tempFileRepository.Add(tempFileName, data);
					return externalUrl;
				}
			}

			//SystemLog.Log((object)this, string.Format("GetModifiedImage: manipulated image not created, returning original source image '{0}'", (object)sourceImagePath), Level.Debug, (Exception)null);
			return sourceImagePath;
		}

		/// <summary>
		///     Generates a temp file name to use based on input params
		/// </summary>
		protected virtual string GenerateTempFileName(string baseName, params object[] args)
		{
			string path = baseName;
			string str = path;
			int startIndex = path.LastIndexOf('/');
			if (startIndex > -1 && startIndex < path.Length - 1)
			{
				path = path.Substring(startIndex);
			}

			int length = path.IndexOf('?');
			if (length > -1 && length < path.Length - 1)
			{
				path = path.Substring(0, length);
			}

			foreach (char invalidFileNameChar in Path.GetInvalidFileNameChars())
			{
				path = path.Replace(invalidFileNameChar.ToString(CultureInfo.InvariantCulture), "");
			}

			if (args != null && args.Length != 0)
			{
				foreach (object obj in args)
				{
					str += obj.ToString();
				}
			}

			int hashCode = str.GetHashCode();
			return string.Format("{0}{1}{2}", Path.GetFileNameWithoutExtension(path), hashCode, Path.GetExtension(path));
		}

		/// <summary>
		///     Modifies an image <see cref="T:System.IO.Stream" /> according to the supplied
		///     <see cref="T:MyLibrary.Imaging.Models.ImageResizeSettings" />
		/// </summary>
		protected virtual byte[] ModifyImage(Stream sourceData, ImageResizeSettings settings)
		{
			Bitmap image;
			if (_imageManipulator.TryOpen(sourceData, out image))
			{
				try
				{
					if (image.Width == settings.Width && image.Height == settings.Height)
					{
						//SystemLog.Log((object)this, "ModifyImage: source image dimensions matches target dimensions, no manipulation neccesary", Level.Debug, (Exception)null);
						return null;
					}

					ImageFormat format = ImageFormat.Jpeg;
					try
					{
						format = image.RawFormat;
					}
					catch (Exception ex)
					{
						//SystemLog.Log((object)this, "ModifyImage: failed to extract image format from source bitmap, using default 'Jpeg'", Level.Debug, ex);
					}

					if (format.Equals(ImageFormat.MemoryBmp))
					{
						format = ImageFormat.Jpeg;
					}

					//SystemLog.Log((object)this, string.Format("GetModifiedImage: found format '{0}' in source bitmap", (object)format), Level.Debug, (Exception)null);
					using (Bitmap image2 = _imageManipulator.Manipulate(image, settings))
					{
						return _imageManipulator.WriteImage(image2, format);
					}
				}
				catch (ArgumentException ex)
				{
					//SystemLog.Log((object)this, "ModifyImage: failed to source image from data stream", Level.Error, (Exception)ex);
				}
				finally
				{
					if (image != null)
					{
						image.Dispose();
					}
				}
			}
			else
			{
				return null;
			}

			//SystemLog.Log((object)this, "ModifyImage: unable to open source image data stream", Level.Warning, (Exception)null);
			return null;
		}

		/// <summary>
		///     Opens a file stream from the supplied <paramref name="path" />. The path can be both to a
		///     <see cref="T:EPiServer.Core.MediaData" /> entity, or an external link.
		/// </summary>
		protected virtual Stream OpenFileStream(string path)
		{
			if (new Uri(path, UriKind.RelativeOrAbsolute).IsAbsoluteUri)
			{
				try
				{
					using (WebClient webClient = new WebClient())
					{
						return webClient.OpenRead(path);
					}
				}
				catch
				{
				}
			}

			try
			{
				return HostingEnvironment.VirtualPathProvider.GetFile(path).Open();
			}
			catch (ArgumentException ex)
			{
				return null;
			}
		}
	}
}
