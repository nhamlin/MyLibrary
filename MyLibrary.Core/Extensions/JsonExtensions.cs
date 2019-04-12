using System;
using System.Diagnostics.Contracts;
using log4net;
using Newtonsoft.Json;

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	///     Extension methods for JSON objects
	/// </summary>
	public static class JsonExtensions
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(JsonExtensions));

		/// <summary>
		///     Deserializes a JSON string (with optional settings) into a desired object type.
		/// </summary>
		/// <param name="source">JSON string</param>
		/// <param name="settings">Optional serializer settings</param>
		/// <typeparam name="T">Resulting object type</typeparam>
		/// <returns></returns>
		public static T FromJson<T>(this string source, JsonSerializerSettings settings = null)
			where T : class
		{
            Contract.Requires<ArgumentNullException>(source != null);

			try
			{
				var resultingObject = JsonConvert.DeserializeObject<T>(source, settings);
				_logger.Info($"Deserialized object of type {typeof(T)}.");
				return resultingObject;
			}
			catch (Exception ex)
			{
				_logger.Error("Could not deserialize the object from JSON format to the desired type.", ex);
			}

			return null;
		}

		/// <summary>
		///     Converts any object into a JSON-formatted string
		/// </summary>
		/// <param name="source">Object to be converted</param>
		/// <param name="formatting">Optional <see cref="Newtonsoft.Json.Formatting" /></param>
		/// <returns>
		///     <see cref="string" />
		/// </returns>
		public static string ToJson(this object source, Formatting formatting = Formatting.Indented)
		{
            Contract.Requires<ArgumentNullException>(source != null);

			try
			{
				string json = JsonConvert.SerializeObject(source, formatting);
				_logger.Info($"Converted {source.GetType()} into {json}");
				return json;
			}
			catch (Exception ex)
			{
				_logger.Error("Could not serialize the object into JSON format.", ex);
			}

			return null;
		}
	}
}
