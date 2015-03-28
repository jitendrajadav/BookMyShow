using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Common
{
	public static class SerializeDeserialize
	{
		#region Serialize Deserialize

		/// <summary>
		/// Deserialize string object 
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="json">String Json object</param>
		/// <returns></returns>
		public static T Deserialize<T>(string json)
		{
			try
			{
				var _Bytes = Encoding.Unicode.GetBytes(json);
				using (MemoryStream _Stream = new MemoryStream(_Bytes))
				{
					var _Serializer = new DataContractJsonSerializer(typeof(T));
					return (T)_Serializer.ReadObject(_Stream);
				}
			}
			catch (System.Exception)
			{
				object a = null;
				return (T)a;
			}
		}

		/// <summary>
		/// Serialize Json object
		/// </summary>
		/// <param name="instance">Json Object</param>
		/// <returns></returns>
		public static string Serialize(object instance)
		{
			try
			{
				using (MemoryStream _Stream = new MemoryStream())
				{
					var _Serializer = new DataContractJsonSerializer(instance.GetType());
					_Serializer.WriteObject(_Stream, instance);
					_Stream.Position = 0;
					using (StreamReader _Reader = new StreamReader(_Stream))
					{ return _Reader.ReadToEnd(); }
				}
			}
			catch (System.Exception)
			{
				return string.Empty;
			}
		}

		#endregion
	}
}
