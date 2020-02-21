using System;
using System.ComponentModel;

namespace NN.Standard.Common.Extensions
{
    public static class EnumExtension
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            if (fi == null) return string.Empty;
            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static string GetDisplayName(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            if (fi == null) return string.Empty;
            var attributes =
                (DisplayNameAttribute[])fi.GetCustomAttributes(
                    typeof(DisplayNameAttribute),
                    false);

            return attributes.Length > 0 ? attributes[0].DisplayName : value.ToString();
        }
    }
}
