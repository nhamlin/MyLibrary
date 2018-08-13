#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/16/2018
// Filename: MyLibrary:MyLibrary.Imaging:CropOriginSettings.cs
// Usage:

#endregion header

using System;
using System.Drawing;
using MyLibrary.Imaging.Enums;
using MyLibrary.Imaging.Interfaces;

namespace MyLibrary.Imaging.Models
{
	public class CropOriginSettings : ICropOriginSettings
	{
		public static CropOriginSettings TopLeft => new CropOriginSettings
		{
			Top = 0.0,
			Left = 0.0,
			CropOrigin = CropOrigin.TopLeft
		};

		public static CropOriginSettings TopCenter => new CropOriginSettings
		{
			Top = 0.0,
			Left = 0.5,
			CropOrigin = CropOrigin.TopCenter
		};

		public static CropOriginSettings TopRight => new CropOriginSettings
		{
			Top = 0.0,
			Left = -1.0,
			CropOrigin = CropOrigin.TopRight
		};

		public static CropOriginSettings MiddleLeft => new CropOriginSettings
		{
			Top = 0.5,
			Left = 0.0,
			CropOrigin = CropOrigin.MiddleLeft
		};

		public static CropOriginSettings MiddleCenter => new CropOriginSettings
		{
			Top = 0.5,
			Left = 0.5,
			CropOrigin = CropOrigin.MiddleCenter
		};

		public static CropOriginSettings MiddleRight => new CropOriginSettings
		{
			Top = 0.5,
			Left = -1.0,
			CropOrigin = CropOrigin.MiddleRight
		};

		public static CropOriginSettings BottomLeft => new CropOriginSettings
		{
			Top = -1.0,
			Left = 0.0,
			CropOrigin = CropOrigin.BottomLeft
		};

		public static CropOriginSettings BottomCenter => new CropOriginSettings
		{
			Top = -1.0,
			Left = 0.5,
			CropOrigin = CropOrigin.BottomCenter
		};

		public static CropOriginSettings BottomRight => new CropOriginSettings
		{
			Top = -1.0,
			Left = -1.0,
			CropOrigin = CropOrigin.BottomRight
		};

		public double Top { get; set; }
		public double Left { get; set; }
		public CropOrigin CropOrigin { get; set; }

		public int GetSettingId()
		{
			return (Top + Left + CropOrigin.ToString()).GetHashCode();
		}

		public int GetStartingPoint(uint origLength, uint newLength, double offsetFactor)
		{
			// TODO: Consider what happens if the user wants to enter an relative value rather than an absolute one
			// TODO: What if they put in -100 px or even 90% or -10% 
			if (origLength <= newLength)
			{
				return 0;
			}

			double num1 = offsetFactor <= 0.0 ? origLength * offsetFactor : (origLength - newLength) * offsetFactor;
			double num2 = num1 + newLength;
			num1 = Math.Abs(num1);
			num2 = Math.Abs(num2);
			return num1 > num2 ? (int)num2 : (int)num1;
		}

		public Rectangle GetRectangle(uint origWidth, uint origHeight, uint newWidth, uint newHeight)
		{
			int startPointX = GetStartingPoint(origWidth, newWidth, Left);
			int startPointY = GetStartingPoint(origHeight, newHeight, Top);
			int width = (int)(newWidth > origWidth ? origWidth : newWidth);
			int height = (int)(newHeight > origHeight ? origHeight : newHeight);
			return new Rectangle(startPointX, startPointY, width, height);
		}

		public static CropOriginSettings GetSettings(CropOrigin origin)
		{
			switch (origin)
			{
				case CropOrigin.TopLeft:
					return TopLeft;

				case CropOrigin.TopCenter:
					return TopCenter;

				case CropOrigin.TopRight:
					return TopRight;

				case CropOrigin.MiddleLeft:
					return MiddleLeft;

				case CropOrigin.MiddleCenter:
					return MiddleCenter;

				case CropOrigin.MiddleRight:
					return MiddleRight;

				case CropOrigin.BottomLeft:
					return BottomLeft;

				case CropOrigin.BottomCenter:
					return BottomCenter;

				case CropOrigin.BottomRight:
					return BottomRight;

				case CropOrigin.Default:
				default:
					return MiddleCenter;
			}
		}
	}
}
