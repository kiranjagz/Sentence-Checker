using Sentence.Checker.Core.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentence.Checker.Core.Services
{
    public interface ISentenceService
    {
        public ISentenceModel CheckForDuplicates(string sentence);
    }
}
