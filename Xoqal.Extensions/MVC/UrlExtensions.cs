using System.Text.RegularExpressions;

namespace Xoqal.Extensions.MVC
{
    /// <summary>
    /// Provide some helpers extensions method toward of URL.
    /// </summary>
    public static class UrlExtensions
    {
        private static readonly Regex Feet = new Regex(@"([0-9]\s?)'([^'])", RegexOptions.Compiled);
        private static readonly Regex Inch1 = new Regex(@"([0-9]\s?)''", RegexOptions.Compiled);
        private static readonly Regex Inch2 = new Regex(@"([0-9]\s?)""", RegexOptions.Compiled);
        private static readonly Regex Num = new Regex(@"#([0-9]+)", RegexOptions.Compiled);
        private static readonly Regex Dollar = new Regex(@"[$]([0-9]+)", RegexOptions.Compiled);
        private static readonly Regex Percent = new Regex(@"([0-9]+)%", RegexOptions.Compiled);
        private static readonly Regex Sep = new Regex(@"[\s_/\\+:.]", RegexOptions.Compiled);

        // included Persian char(s)
        private static readonly Regex Empty = new Regex(@"[^-A-Za-z0-9\u0600-\u06FF]", RegexOptions.Compiled);
        private static readonly Regex Extra = new Regex(@"[-]+", RegexOptions.Compiled);

        /// <summary>
        /// Gets readable encoded URL from the specified raw URL.
        /// </summary>
        /// <param name="rawUrl"></param>
        /// <returns></returns>
        /// <remarks>Persian characters included.</remarks>
        public static string GetReadableEncodedUrl(this string rawUrl)
        {
            if (string.IsNullOrWhiteSpace(rawUrl)) return rawUrl;

            rawUrl = rawUrl.Trim().ToLower();
            rawUrl = rawUrl.Replace("&", "and");

            rawUrl = Feet.Replace(rawUrl, "$1-ft-");
            rawUrl = Inch1.Replace(rawUrl, "$1-in-");
            rawUrl = Inch2.Replace(rawUrl, "$1-in-");
            rawUrl = Num.Replace(rawUrl, "num-$1");

            rawUrl = Dollar.Replace(rawUrl, "$1-dollar-");
            rawUrl = Percent.Replace(rawUrl, "$1-percent-");

            rawUrl = Sep.Replace(rawUrl, "-");

            rawUrl = Empty.Replace(rawUrl, string.Empty);
            rawUrl = Extra.Replace(rawUrl, "-");

            rawUrl = rawUrl.Trim('-');

            return rawUrl;
        }
    }
}
