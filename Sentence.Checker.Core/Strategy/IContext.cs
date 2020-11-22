using System;
using System.Collections.Generic;
using System.Text;

namespace Sentence.Checker.Core.Strategy
{
    public interface IContext
    {
        void Invoke(string sentence);
    }
}
