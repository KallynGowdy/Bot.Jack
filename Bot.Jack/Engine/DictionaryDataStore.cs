using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot.Jack.Engine
{
    [Serializable]
    public class DictionaryDataStore
    {
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();

        public int? GetInteger(string key)
        {
            object i;
            if (Data.TryGetValue(key, out i))
            {
                return (int?)i;
            }
            else
            {
                return null;
            }
        }

        public string GetString(string key)
        {
            object i;
            if (Data.TryGetValue(key, out i))
            {
                return (string)i;
            }
            else
            {
                return null;
            }
        }

        public bool? GetBoolean(string key)
        {
            object i;
            if (Data.TryGetValue(key, out i))
            {
                return (bool?)i;
            }
            else
            {
                return null;
            }
        }

        public bool GetBoolean(string key, bool defaultValue)
        {
            object i;
            if (Data.TryGetValue(key, out i))
            {
                if (i != null)
                {
                    return (bool)i;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        public void SetValue(string key, object value)
        {
            if (Data.ContainsKey(key))
            {
                Data[key] = value;
            }
            else
            {
                Data.Add(key, value);
            }
        }
    }
}