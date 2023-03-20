using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SherCore.BlogServer
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class BlogServerEnumExtensions
    {
        public static List<KeyValuePair<int, string>> ToKeyValuePairs<T>()
        {
            List<KeyValuePair<int, string>> pairs = new List<KeyValuePair<int, string>>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                string value = string.Empty;
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DisplayAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DisplayAttribute da = objArr[0] as DisplayAttribute;
                    value = da.Name;
                }

                pairs.Add(new KeyValuePair<int, string>(Convert.ToInt32(e), value));
            }
            return pairs;
        }

        public static string GetDisplayName(this Enum value)
        {
            if (value == null)
            {
                return null;
            }

            var type = value.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"类型 '{type}' 不是枚举");
            }

            var members = type.GetMember(value.ToString());
            if (members.Length == 0)
            {
                return string.Empty;
            }
            var member = members[0];
            var attributes = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes.Length == 0)
            {
                return value.ToString();
            }

            var attribute = (DisplayAttribute)attributes[0];
            return attribute.GetName();
        }
    }
}