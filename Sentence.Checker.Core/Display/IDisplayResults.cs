using System;
using System.Collections.Generic;
using System.Text;

namespace Sentence.Checker.Core.Display
{
    public interface IDisplayResults
    {
        public void CheckDuplicates(string sentence);

        public void CheckVowelCount(string sentence);

        public void CheckCompareVowelWithNonVowel(string sentence);

        public void CheckDuplicateAndCountOfVowels(string sentence);

        public void CheckAllConditions(string sentence);
    }
}
