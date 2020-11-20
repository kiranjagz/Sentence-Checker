using System;
using System.Collections.Generic;
using System.Text;

namespace Sentence.Checker.Core.Services.CustomSentenceFormatter
{
    /// <summary>
    /// This is just an example to simulate connecting to an external resource, like an api or database to perform this logic.
    /// </summary>
    public class CustomSentenceFormatter : ICustomSentenceFormatter
    {
        public string FormatWordsInSentence(string sentence)
        {
            return sentence.Replace(" ", string.Empty).ToLower();
        }
    }
}
