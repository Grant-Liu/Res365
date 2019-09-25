using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res365.BusinessLogic
{
    public abstract class StringCalculator : IStringCalculator
    {
        public abstract string Formular { get; set; }
        public abstract int CalculatorString(string input, int upBound = 1000, bool allowNegative = false);
        public abstract int CalculatorSubtraction(string input, int upBound= 1000, bool allowNegative = false);
        public abstract int CalculatorMultiplication(string input, int upBound= 1000, bool allowNegative = false);
        public abstract int CalculatorDivision(string input, int upBound= 1000, bool allowNegative = false);

    }
}
