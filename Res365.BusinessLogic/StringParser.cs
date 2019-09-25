using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res365.BusinessLogic
{
    public abstract class StringParser: IStringParser
    {
        public List<int> Numbers;
        public List<int> NegativeNumbers;
        public List<int> IgnoredNumbers;
        public abstract void ParseString(string input);
        protected abstract void ColloctNumbers(int myNumber, bool isNegative);
        protected abstract string HandleMultiLengthDelimiter(string input);
    }
}
