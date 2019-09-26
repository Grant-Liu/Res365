using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res365.BusinessLogic
{
    public class StringIntegerCalculator : StringCalculator, IStringIntegerCalculator
    {
        protected IStringIntegerParser _StringIntegerParser;
        public override string Formular { get; set; }

        public StringIntegerCalculator(IStringIntegerParser stringIntegerParser)
        {
            _StringIntegerParser = stringIntegerParser;
        }

        public override int CalculatorSubtraction(string input, int upBound = 1000, bool allowNegative = false)
        {
            int result = 0;
            _StringIntegerParser.UpBound = upBound;
            _StringIntegerParser.AllowNegative = allowNegative;

            _StringIntegerParser.ParseString(input);
            StringBuilder sb = new StringBuilder();

            foreach (int number in _StringIntegerParser.Numbers)
            {
                if (result == 0)
                {
                    result = number;
                }
                else
                {
                    result -= number;
                }

                if (string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append($"{number}");
                }
                else
                {
                    sb.Append($"-{number}");
                }
            }
            sb.Append($" = {result}");
            Formular = sb.ToString();

            if (_StringIntegerParser.NegativeNumbers.Count > 0 && !allowNegative)
            {
                throw new Exception($"Negative numbers: {String.Join(", ", _StringIntegerParser.NegativeNumbers)}");
            }

            return result;
        }
        public override int CalculatorMultiplication(string input, int upBound = 1000, bool allowNegative = false)
        {
            int result = 1;
            _StringIntegerParser.UpBound = upBound;
            _StringIntegerParser.AllowNegative = allowNegative;

            _StringIntegerParser.ParseString(input);
            StringBuilder sb = new StringBuilder();

            foreach (int number in _StringIntegerParser.Numbers)
            {
                result *= number;

                if (string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append($"{number}");
                }
                else
                {
                    sb.Append($"*{number}");
                }
            }
            sb.Append($" = {result}");
            Formular = sb.ToString();

            if (_StringIntegerParser.NegativeNumbers.Count > 0 && !allowNegative)
            {
                throw new Exception($"Negative numbers: {String.Join(", ", _StringIntegerParser.NegativeNumbers)}");
            }

            return result;
        }
        public override int CalculatorDivision(string input, int upBound = 1000, bool allowNegative = false)
        {
            int result = 0;
            _StringIntegerParser.UpBound = upBound;
            _StringIntegerParser.AllowNegative = allowNegative;

            _StringIntegerParser.ParseString(input);
            StringBuilder sb = new StringBuilder();

            foreach (int number in _StringIntegerParser.Numbers)
            {
                if (number == 0)
                    continue;

                if (result == 0)
                {
                    result = number;
                }
                else
                {
                    result /= number;
                }

                if (string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append($"{number}");
                }
                else
                {
                    sb.Append($"/{number}");
                }
            }
            sb.Append($" = {result}");
            Formular = sb.ToString();

            if (_StringIntegerParser.NegativeNumbers.Count > 0 && !allowNegative)
            {
                throw new Exception($"Negative numbers: {String.Join(", ", _StringIntegerParser.NegativeNumbers)}");
            }

            return result;
        }
        /// <summary>
        /// Calculator string values
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override int CalculatorString(string input, int upBound = 1000, bool allowNegative = false)
        {
            int result = 0;
            _StringIntegerParser.UpBound = upBound;
            _StringIntegerParser.AllowNegative = allowNegative;

            _StringIntegerParser.ParseString(input);
            StringBuilder sb = new StringBuilder();

            foreach (int number in _StringIntegerParser.Numbers)
            {
                result += number;

                if (string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append($"{number}");
                }
                else
                {
                    if (number >= 0)
                        sb.Append($"+{number}");
                    else
                        sb.Append($"{number}");
                }
            }
            sb.Append($" = {result}");
            Formular = sb.ToString();

            if (_StringIntegerParser.NegativeNumbers.Count > 0 && !allowNegative)
            {
                throw new Exception($"Negative numbers: {String.Join(", ", _StringIntegerParser.NegativeNumbers)}");
            }

            return result;
        }
    }
}
