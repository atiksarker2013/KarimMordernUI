using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Shared
{
    public static class Ext
    {
        /// <summary>
        /// returns property value from an object.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        public static object GetPropertyVal(this object obj, string propName)
        {
            if (obj != null)
                return obj.GetType().GetProperty(propName).GetValue(obj, null);
            return "";
        }

        /// <summary>
        /// Returns Trimmed string; empty string for null
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string TrimWithNull(this string txt)
        {
            string val = string.Empty;

            if (String.IsNullOrWhiteSpace(txt))
            {
                val = string.Empty;
            }
            else
            {
                val = txt.Trim();
            }

            return val;
        }

        /// <summary>
        /// Returns the string; empty string for null. It does not trancate white spaces
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string HandleNull(this string txt)
        {
            return txt ?? "";
        }

        /// <summary>
        /// Converts a string to int. 0 in case of any excepttion
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static int ToInt32(this string txt)
        {
            int i = 0;
            int.TryParse(txt.TrimWithNull(), out i);
            return i;
        }

        public static decimal ToDecimal(this string txt, int decimalPlace)
        {
            decimal d = 0;
            decimal.TryParse(txt.TrimWithNull(), out d);
            return Math.Round(d, decimalPlace);
        }

        /// <summary>
        ///  Resturns left substring of specified length. same as foxpro Left function
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left(this string txt, int length)
        {
            if (txt != null && txt.Length > 0 && length > 0)
            {
                return txt.Length >= length ? txt.Substring(0, length) : txt;
            }
            return "";
        }

        /// <summary>
        /// Resturns right substring of specified length. same as foxpro Right function
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right(this string txt, int length)
        {
            if (txt != null && txt.Length > 0 && length > 0)
            {
                return txt.Length >= length ? txt.Substring(txt.Length - length) : txt;
            }
            return "";
        }

        /// <summary>
        /// Returns Substring same as in foxpro substring
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubstringFox(this string txt, int length)
        {
            return txt.Left(length);
        }

        /// <summary>
        /// Returns Substring same as in foxpro substring
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="startPosition"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubstringFox(this string txt, int startPosition, int length)
        {
            if (txt != null && txt.Length > 0 && length > 0)
            {
                if (startPosition < txt.Length - 1)
                {
                    string s = txt.Substring(startPosition, txt.Length - startPosition);
                    return s.Left(length);
                }
            }

            return "";
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<TSource> DistinctBy2<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            return source.Where(element => seenKeys.Add(keySelector(element)));
        }
        public static int IndexOfOccurence(this string target, string value, int n)
        {
            Match m = Regex.Match(target, "((" + Regex.Escape(value) + ").*?){" + n + "}");

            if (m.Success)
                return m.Groups[2].Captures[n - 1].Index;
            else
                return -1;
        }

        public static bool IsInt(this string value)
        {
            int intValue = 0;
            return int.TryParse(value, out intValue);
        }
        public static int IndexOfNull(this string txt, string txt2)
        {
            if (txt != null)
            {
                return txt.IndexOf(txt2);
            }
            return -1;
        }

        public static bool IsDateEmpty(this DateTime? date)
        {
            if (date.HasValue == false)
                return true;
            else if (date.Value.Year == 1899)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns true if this string is not null, empty or whitespace(s).
        /// </summary>
        public static bool HasValue(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// Returns true if this string is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// Returns true if this string is null, empty or whitespace(s).
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }
    }
}