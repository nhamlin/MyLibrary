#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/12/2018
// Filename: MyLibrary:MyLibrary:ExcelUtilities.cs
// Usage:          

#endregion

using System;
using System.Data;
using System.IO;
using ExcelDataReader;

namespace MyLibrary.Core.Utilities
{
	/// <summary>
	///     Utilities for CRUD operations of Excel files
	/// </summary>
	public abstract class ExcelUtilities<T> : BaseFileUtility<T>
	{
		private string _excelWorksheetName;
		private DataRowCollection _rows;

		/// <summary>
		///     Constructor for Excel Utilities
		/// </summary>
		/// <param name="rows"></param>
		protected ExcelUtilities(DataRowCollection rows)
		{
			_rows = rows;
		}

		/// <summary>
		///     Gets data from an Excel file
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="fileName"></param>
		/// <exception cref="Exception"></exception>
		protected void Import(Stream stream, string fileName)
		{
			IExcelDataReader excelReader;

			if (fileName.EndsWith(".xlsx"))
			{
				excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
			}
			else if (fileName.EndsWith(".xls"))
			{
				excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
			}
			else
			{
				throw new Exception($"{nameof(ExcelUtilities<T>)} is unable to process file {fileName}");
			}

			var conf = new ExcelDataSetConfiguration
			{
				ConfigureDataTable = _ => new ExcelDataTableConfiguration
				{
					UseHeaderRow = true
				}
			};
			DataSet result = excelReader.AsDataSet(conf);
			excelReader.Close();
			_rows = GetDataRowCollectionFromDataSet(result);
			_rows.InsertAt(_rows[0].Table.NewRow(), 0);
		}

		private DataRowCollection GetDataRowCollectionFromDataSet(DataSet result)
		{
			if (!string.IsNullOrWhiteSpace(_excelWorksheetName))
			{
				return result.Tables[_excelWorksheetName].Rows;
			}

			return result.Tables[0].Rows;
		}
	}
}
