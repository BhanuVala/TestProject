using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbum.Helper
{
    public static class JsonHelper
    {
        /// <summary>
        /// ReturnJsonSerializerSettings.
        /// </summary>
        /// <returns>JsonSerializerSettings</returns>
        public static JsonSerializerSettings ReturnJsonSerializerSettings()
        {
            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "MM/dd/yyyy" });
            serializeSettings.NullValueHandling = NullValueHandling.Ignore;
            serializeSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
            return serializeSettings;
        }

        /// <summary>
        /// Json Serializes
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>string</returns>
        public static string JsonSerialize(object request)
        {
            return JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        /// <summary>
        /// Helper class to Serialize & Deserialize
        /// </summary>
        /// <param name="jsonString">jsonString</param>
        /// <returns>Object</returns>
        public static T JsonDeserialize<T>(string jsonString)
        {
            //var _logRepository = new LogRepository();
            try
            {
                if (!string.IsNullOrWhiteSpace(jsonString))
                {
                    return JsonConvert.DeserializeObject<T>(jsonString, ReturnJsonSerializerSettings());
                }
                return default;
            }
            catch (System.Exception ex)
            {
               // _logRepository.Error("JsonDeserialize - Error - JSON String : " + jsonString);
               // _logRepository.Error("JsonDeserialize - Error: ", ex);
                return default;
            }
        }
    }
}
