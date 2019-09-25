﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Res365.BusinessLogic
{
    public class StringIntegerParser
    {
        public List<int> Numbers;
        public List<int> NegativeNumbers;
        public List<int> IgnoredNumbers;

        protected string HandleMultiLengthDelimiter(string input)
        {
            string pattern = "\\[.+]";

            Regex r1 = new Regex(pattern);

            // C
            // Match the input and write results
            Match match = r1.Match(input);
            if (match.Success)
            {
                if (match.Groups.Count > 0)
                {
                    for(int i=0;i< match.Groups.Count;i++)
                    {
                        string v = match.Groups[i].Value;
                        v = v.Replace("][", "|").Replace("[", "").Replace("]","");

                        string[] delimiters = v.Split('|');
                        foreach(string s in delimiters.OrderByDescending(x=>x.Length).ToArray())
                        {
                            input = input.Replace(s, "|");
                        }
                        
                    }
                }                
            }

            return input;
        }
        /// <summary>
        /// Parse string to integer list
        /// </summary>
        /// <param name="input"></param>
        public void ParseString(string input)
        {
            input=HandleMultiLengthDelimiter(input);

            Numbers = new List<int>();
            NegativeNumbers = new List<int>();
            IgnoredNumbers = new List<int>();

            int myNumber = 0;
            int position = 0;
            bool isNegative = false;

            if (input.Length > 0)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '-')
                    {
                        isNegative = true;
                    }
                    else if (input[i] >= '0' && input[i] <= '9')
                    {
                        myNumber = myNumber * ((int)Math.Pow(10, position > 0 ? 1 : 0)) + int.Parse(input[i].ToString());
                        position++;
                    }
                    else if (position > 0)
                    {
                        //not a number,it must be delimited string
                        ColloctNumbers(myNumber, isNegative);

                        myNumber = 0;
                        position = 0;
                        isNegative = false;
                    }
                }
                //handle the last one
                if (position > 0)
                {
                    ColloctNumbers(myNumber, isNegative);
                }
            }
        }
        /// <summary>
        /// Collect numbers
        /// </summary>
        /// <param name="myNumber"></param>
        /// <param name="isNegative"></param>
        private void ColloctNumbers(int myNumber, bool isNegative)
        {
            if (isNegative)
            {
                NegativeNumbers.Add(myNumber * -1);
            }
            else if (myNumber <= 1000)
            {
                Numbers.Add(myNumber);
            }
            else
            {
                IgnoredNumbers.Add(myNumber);
            }
        }
    }
}