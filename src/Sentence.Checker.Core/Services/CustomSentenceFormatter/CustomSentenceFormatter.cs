using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sentence.Checker.Core.Services.CustomSentenceFormatter
{
    public class CustomSentenceFormatter : ICustomSentenceFormatter
    {
        public string FormatWordsInSentence(string sentence)
        {
            var sb = new StringBuilder();

            if (string.IsNullOrEmpty(sentence))
            {
                throw new ArgumentException("Empty string provided.");
            }

            var removeEmptySpaces = sentence
               .Replace(" ", string.Empty)
               .ToLower();

            foreach (char c in removeEmptySpaces)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
