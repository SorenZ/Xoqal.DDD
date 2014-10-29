using System.Globalization;

namespace Xoqal.Globalization.Text
{
    public static class PersianTextExtension
    {
        /// <summary>
        /// Gets the Arabic format.
        /// </summary>
        /// <param name="txt"> The Text. </param>
        /// <returns> </returns>
        public static string GetArabicsFormat(this string txt)
        {
            return !string.IsNullOrEmpty(txt) ? txt.Replace("ی", "ي").Replace("ک", "ك") : txt;
        }

        /// <summary>
        /// Gets the Persian format.
        /// </summary>
        /// <param name="txt"> The Text. </param>
        /// <returns> </returns>
        public static string GetPersianFormat(this string txt)
        {
            return !string.IsNullOrEmpty(txt) ? txt.Replace("ي", "ی").Replace("ك", "ک") : txt;
        }

        /// <summary>
        /// Converts all digits in the given string to the Persian digits.
        /// </summary>
        /// <param name="source"> </param>
        /// <returns> </returns>
        public static string ConvertToPersianDigit(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return source;

            var nums = new[] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            
            for (var i = 0; i <= 9; i++)
                source = source.Replace(i.ToString(CultureInfo.InvariantCulture), nums[i]);

            return source;
        }
    }
}
