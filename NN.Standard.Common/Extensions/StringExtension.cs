using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NN.Standard.Common.Extensions
{
    public static class StringExtension
    {
        public static bool IsEmail(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            var regularExpression =
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            return Regex.IsMatch(value.Trim(), regularExpression, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Parse to int, return default value if cannot parse
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ParseToInt(this string src, int defaultValue = 0)
        {
            var isNumeric = int.TryParse(src, out var value);
            if (isNumeric)
                return value;
            return defaultValue;
        }

        /// <summary>
        /// Parse to short, return default value if cannot parse
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static short ParseToShort(this string src, short defaultValue = 0)
        {
            var isNumeric = short.TryParse(src, out var value);
            return isNumeric ? value : defaultValue;
        }

        /// <summary>
        /// Parse to int, return default value if cannot parse
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ParseToInt(this object src, int defaultValue = 0)
        {
            var isNumeric = int.TryParse(src.ToString(), out var value);
            return isNumeric ? value : defaultValue;
        }

        /// <summary>
        /// Parse to long, return default value if cannot parse
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long ParseToLong(this string source, long defaultValue = 0)
        {
            return long.TryParse(source, out var value) ? value : defaultValue;
        }

        /// <summary>
        /// Parse to long, return default value if cannot parse
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long ParseToLong(this object src, int defaultValue = 0)
        {
            var isNumeric = long.TryParse(src.ToString(), out var value);
            return isNumeric ? value : defaultValue;
        }

        /// <summary>
        /// Parse to decimal, return default value if cannot parse
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ParseToDecimal(this string source, decimal defaultValue = 0)
        {
            return decimal.TryParse(source, out var value) ? value : defaultValue;
        }

        /// <summary>
        /// Parse to double, return default value if cannot parse
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double ParseToDouble(this string source, double defaultValue)
        {
            return double.TryParse(source, out var value) ? value : defaultValue;
        }

        /// <summary>
        /// Get a random characters by length
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandom(int length = 8)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            return new string(Enumerable.Repeat(chars, length).Select(x => x[random.Next(x.Length)]).ToArray());
        }

        /// <summary>
        /// Convert string to stringbase64
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertStringToBase64(this string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            var base64 = Convert.ToBase64String(bytes);
            return base64;
        }

        /// <summary>
        /// Convert stringbase64 to string
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        public static string ConvertBase64ToString(this string base64)
        {
            var bytes = Convert.FromBase64String(base64);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string ReplaceMultiSpaces(this string value)
        {
            var options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            value = regex.Replace(value, " ");
            return value;
        }

        public static string CollapseSpaces(this string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }

        /// <summary>
        /// Get a random value in list
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string Random(this string[] values)
        {
            var random = new Random();
            var valueRandom = random.Next(0, values.Length - 1);
            return values[valueRandom];
        }

        /// <summary>
        /// Generate slug for vietnamese characters. E.x: xin chào -> xin-chao
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string GenerateSlug(this string phrase)
        {
            var value = phrase.ReplaceVietnameseCharacters().RemoveAccent().ToLower();
            value = Regex.Replace(value, @"[^a-z0-9\s-]", "");
            value = Regex.Replace(value, @"\s+", " ").Trim();
            value = value.Substring(0, value.Length <= 45 ? value.Length : 45).Trim();
            value = Regex.Replace(value, @"\s", "-");
            return value;
        }

        private static string RemoveAccent(this string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        private static readonly string[] VietNamChar = {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        private static string ReplaceVietnameseCharacters(this string str)
        {
            for (var i = 1; i < VietNamChar.Length; i++)
            {
                for (var j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }

            return str;
        }

        /// <summary>
        /// Remove html tag in string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveHtmlTag(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return Regex.Replace(input, "<.*?>", string.Empty);
        }

        /// <summary>
        /// Get sub string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <param name="endPrefix"></param>
        /// <returns></returns>
        public static string Sub(this string input, int length, string endPrefix = "")
        {
            if (string.IsNullOrEmpty(input))
                return input;
            if (input.Length < length)
            {
                return input;
            }

            return $"{input.Substring(0, length)}{endPrefix}";
        }
    }
}
