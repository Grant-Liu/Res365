using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res365.BusinessLogic
{
    public abstract class StringCalculator : IStringCalculator
    {
        public abstract int CalculatorString(string input);
    }
}
