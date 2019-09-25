using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res365.BusinessLogic
{
    public class StringIntegerCalculator
    {
        protected StringIntegerParser _StringIntegerParser;

        public StringIntegerCalculator()
        {
            _StringIntegerParser = new StringIntegerParser();
        }
        /// <summary>
        /// Calculator string values
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int CalculatorString(string input)
        {
            int result = 0;

            _StringIntegerParser.ParseString(input);

            foreach (int number in _StringIntegerParser.Numbers)
            {
                result += number;
            }

            if (_StringIntegerParser.NegativeNumbers.Count > 0)
            {                
                throw new Exception($"Negative numbers: {String.Join(", ", _StringIntegerParser.NegativeNumbers)}");
            }           

            return result;
        }
    }
}
