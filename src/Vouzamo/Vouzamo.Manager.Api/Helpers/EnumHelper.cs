using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Vouzamo.Manager.Api.Helpers
{
    public static class EnumHelper
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            try
            {
                return enumValue.GetType()
                    .GetMember(enumValue.ToString())
                    .First()
                    .GetCustomAttribute<DisplayAttribute>()
                    .GetName();
            }
            catch
            {
                return enumValue.ToString();
            }
        }

        public static IList<T> ToList<T>()
        {
            var values = Enum.GetValues(typeof(T)).Cast<T>();

            return values.ToList();
        }

        public static IDictionary<int, string> ToDictionary<T>()
        {
            var dictionary = new Dictionary<int, string>();

            var values = Enum.GetValues(typeof(T));

            foreach(var value in values)
            {
                var key = (int)value;

                if(!dictionary.ContainsKey(key))
                {
                    dictionary.Add(key, GetDisplayName(value as Enum));
                }
            }

            return dictionary;
        }
    }
}
