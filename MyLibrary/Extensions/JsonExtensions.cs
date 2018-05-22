using Newtonsoft.Json;

namespace MyLibrary.Extensions
{
	public static class JsonExtensions
	{
		public static T DeepCopy<T>(this T a)
		{
			return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(a));
		}
	}
}
