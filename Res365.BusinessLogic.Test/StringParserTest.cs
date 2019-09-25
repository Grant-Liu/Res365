using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Res365.BusinessLogic.Test
{
    [TestClass]
    public class StringParserTest
    {
        protected StringIntegerParser _StringIntegerParser;
        [TestInitialize]
        public void InitilizeTest()
        {
            _StringIntegerParser = new StringIntegerParser();
        }
        [TestMethod]
        public void StringIntegerParser_one_number_test()
        {
            string input = "2";
            _StringIntegerParser.ParseString(input);
            Assert.IsTrue(_StringIntegerParser.Numbers.Count == 1);

            input = "asdfe2";
            _StringIntegerParser.ParseString(input);
            Assert.IsTrue(_StringIntegerParser.Numbers.Count == 1);            
        }
        [TestMethod]
        public void StringIntegerParser_two_number_test()
        {
            string input = "1,1000";
            _StringIntegerParser.ParseString(input);
            Assert.IsTrue(_StringIntegerParser.Numbers.Count == 2);

            input = "1,1001";
            _StringIntegerParser.ParseString(input);
            Assert.IsTrue(_StringIntegerParser.Numbers.Count == 1);

            input = "0; 5,tytyt";
            _StringIntegerParser.ParseString(input);
            Assert.IsTrue(_StringIntegerParser.Numbers.Count == 2);

            input = "//;\n2;5";
            _StringIntegerParser.ParseString(input);
            Assert.IsTrue(_StringIntegerParser.Numbers.Count == 2);

        }
        [TestMethod]
        public void StringIntegerParser_one_delimiter_test()
        {
            string input = "1\n2,3,4,5,6,7,8,9,10,11,12";           
            _StringIntegerParser.ParseString(input);
            Assert.IsTrue(_StringIntegerParser.Numbers.Count == 12);

            input = "1\n2,3,4,5,6,7,8,9,10,11,-12";
            _StringIntegerParser.ParseString(input);
            Assert.IsTrue(_StringIntegerParser.Numbers.Count == 11);
            Assert.IsTrue(_StringIntegerParser.NegativeNumbers.Count == 1);

            input = "//[***]\n11***22***33";
            _StringIntegerParser.ParseString(input);
            Assert.IsTrue(_StringIntegerParser.Numbers.Count == 3);

            input = "//[*][!!][r9r]\n11r9r22*33!!44";
            _StringIntegerParser.ParseString(input);
            Assert.IsTrue(_StringIntegerParser.Numbers.Count == 4);
        }
    }
}
