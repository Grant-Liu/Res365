using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res365.BusinessLogic
{
    public interface IStringCalculator
    {
        string Formular { get; set; }
        int CalculatorString(string input, int upBound = 1000,bool allowNegative = false);
        int CalculatorSubtraction(string input, int upBound= 1000, bool allowNegative = false);
        int CalculatorMultiplication(string input, int upBound= 1000, bool allowNegative = false);
        int CalculatorDivision(string input, int upBound= 1000, bool allowNegative = false);
    }
}
