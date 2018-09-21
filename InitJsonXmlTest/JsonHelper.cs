using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InitJsonXmlTest
{
   public  static class JsonHelper
    {
        static JsonHelper()
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            jsonSetting = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            jsonSetting.Converters.Add(timeFormat);
            jsonPropsIgnoreSetting = new JsonSerializerSettings
            {
                ContractResolver = new JsonPropsIgnoreContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
            jsonSetting.Converters.Add(timeFormat);
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        private static JsonSerializerSettings jsonSetting;
        private static JsonSerializerSettings jsonPropsIgnoreSetting;
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject(object obj, bool isJsonPropsIgnore = false)
        {
            if (obj == null)
            {
                return "{}";
            }
            if (isJsonPropsIgnore)
                return JsonConvert.SerializeObject(obj, jsonPropsIgnoreSetting);
            else
                return JsonConvert.SerializeObject(obj, jsonSetting);
        }
        /// <summary>
        /// 复制对象属性，可用于复制对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T CloneObject<T>(object obj)
        {
            return DeserializeObject<T>(SerializeObject(obj));
        }

       
    }
}
