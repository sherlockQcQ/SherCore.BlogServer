using System;
using System.Collections.Generic;
using System.Linq;

namespace SherCore.BlogServer
{
    /// <summary>
    ///  string扩展
    /// </summary>
    public static class BlogServerStringExtensions
    {
        /// <summary>
        ///  根据逗号分隔
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> SplitByComma(this string str)
        {
            if (str.IsNullOrWhiteSpace())
            {
                return new List<string>();
            }
            return new List<string>(str.Split(",").Select(t => t.Trim()));
        }
    }
}