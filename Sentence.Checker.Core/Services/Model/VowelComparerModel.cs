using System;
using System.Collections.Generic;
using System.Text;

namespace Sentence.Checker.Core.Services.Model
{
    public class VowelComparerModel : SentenceModel
    {
        public int VowelCount { get; set; }
        public int NonVowelCount { get; set; }
    }
}
