using System;
using System.Linq;

namespace Xoqal.Utilities.Text
{
    public static class TextExtensions
    {
        /// <summary>
        /// Gets the summary.
        /// </summary>
        /// <param name="text"> The text. </param>
        /// <param name="wordCount"> The word count. </param>
        /// <returns> </returns>
        public static string GetSummary(this string text, int wordCount)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var parts = text.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            return string.Join(" ", parts.Take(wordCount).ToArray());
        }
    }
}
