using System;

namespace WpfChallenge.Utils
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return String.IsNullOrEmpty(value);
        }

        public static int ToInt(this string value)
        {
            var tmp = 0;
            int.TryParse(value, out tmp);

            return tmp;
        }

        public static int ToInt(this object value)
        {
            var tmp = value + "";

            return tmp.ToInt();
        }
    }
}
