using System;
using System.Collections.Generic;
using System.Text;

namespace Sentence.Checker.Core.Services.CustomSentenceFormatter
{
    public interface ICustomSentenceFormatter
    {
        string FormatWordsInSentence(string sentence);
    }
}
