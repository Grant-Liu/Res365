using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res365.BusinessLogic
{
    public abstract class StringParser: IStringParser
    {
        public abstract List<int> Numbers { get; set; }
        public abstract List<int> NegativeNumbers { get; set; }
        public abstract List<int> IgnoredNumbers { get; set; }
        public abstract bool AllowNegative { get; set; }
        public abstract int UpBound { get; set; }

        public abstract void ParseString(string input);
        protected abstract void ColloctNumbers(int myNumber, bool isNegative);
        protected abstract string HandleMultiLengthDelimiter(string input);
    }
}
