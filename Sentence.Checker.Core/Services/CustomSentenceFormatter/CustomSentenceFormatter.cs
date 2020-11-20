using System;
using System.Collections.Generic;
using System.Text;

namespace Sentence.Checker.Core.Services.CustomSentenceFormatter
{
    public class CustomSentenceFormatter : ICustomSentenceFormatter
    {
        public string FormatWordsInSentence(string sentence)
        {
            return sentence.Replace(" ", string.Empty).ToLower();
        }
    }
}
