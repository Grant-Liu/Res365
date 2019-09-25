using System;
using CommonServiceLocator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Res365.Global;
using Unity;
using Unity.ServiceLocation;

namespace Res365.BusinessLogic.Test
{
    [TestClass]
    public class StringIntegerCalculatorTest: Res365TestBase
    {
        protected IStringIntegerCalculator _StringIntegerCalculator;
        [TestInitialize]
        public void InitilizeTest()
        {
            InitializeIoC();
            _StringIntegerCalculator = Res365Container.Instance.Resolve <IStringIntegerCalculator> ();
        }       

        [TestMethod]
        public void Fomular_Test()
        {
            string input = "2,4,rrrr,1001,6";
            string result = "2+4+0+0+6 = 12";
            _StringIntegerCalculator.CalculatorString(input);            
            Assert.IsTrue(_StringIntegerCalculator.Formular == result);
        }

        [TestMethod]
        public void Two_number_sub_test()
        {
            string input = "20,10";
            int result = _StringIntegerCalculator.CalculatorSubtraction(input);
            Assert.IsTrue(result == 10);
        }
        [TestMethod]
        public void Two_number_Multiply_test()
        {
            string input = "2,10";
            int result = _StringIntegerCalculator.CalculatorMultiplication(input);
            Assert.IsTrue(result == 20);
        }

        [TestMethod]
        public void Two_number_Divided_test()
        {
            string input = "10,2";
            int result = _StringIntegerCalculator.CalculatorDivision(input);
            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void One_number_test()
        {
            string input = "20";
            int result = _StringIntegerCalculator.CalculatorString(input);
            Assert.IsTrue(result==20);          
        }

        [TestMethod]
        public void Two_number_test()
        {
            string input = "1,5000";
            int result = _StringIntegerCalculator.CalculatorString(input);
            Assert.IsTrue(result == 1);

            input = "0; 5,tytyt";
            result = _StringIntegerCalculator.CalculatorString(input);
            Assert.IsTrue(result == 5);           
        }

        [TestMethod]
        public void Multi_number_test()
        {
            string input = "1,2,3,4,5,6,7,8,9,10,11,12";
            int result = _StringIntegerCalculator.CalculatorString(input);
            Assert.IsTrue(result == 78);
            try
            {
                input = "1,2,3,4,5,6,7,8,9,10,11,-12";
                result = _StringIntegerCalculator.CalculatorString(input);
                Assert.IsTrue(result == 66);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Negative numbers"));
            }
            

            input = "1\n2,3";
            result = _StringIntegerCalculator.CalculatorString(input);
            Assert.IsTrue(result == 6);
        }
        [TestMethod]
        public void Multi_number_allow_negative_test()
        {
            string input = "2,-2,6";
            int result = _StringIntegerCalculator.CalculatorString(input, upBound: 2000,allowNegative:true);
            Assert.IsTrue(result == 6);
        }
        [TestMethod]
        public void Multi_number_2000_test()
        {
            string input = "2,1001,6";
            int result = _StringIntegerCalculator.CalculatorString(input,upBound:2000);
            Assert.IsTrue(result == 1009);
        }
        [TestMethod]
        public void Multi_number_1000_test()
        {
            string input = "2,1001,6";
            int result = _StringIntegerCalculator.CalculatorString(input);
            Assert.IsTrue(result == 8);          
        }
        [TestMethod]
        public void Multi_number_single_delimiter_test()
        {
            string input = "//;\n2;5";
            int result = _StringIntegerCalculator.CalculatorString(input);
            Assert.IsTrue(result == 7);

        }

        [TestMethod]
        public void Multi_number_single_delimiter_anylength_test()
        {
            string input = "//[***]\n11***22***33";
            int result = _StringIntegerCalculator.CalculatorString(input);
            Assert.IsTrue(result == 66);
        }
        [TestMethod]
        public void Multi_number_multi_delimiter_anylength_test()
        {
            string input = "//[*][!!][r9r]\n11r9r22*33!!44";
            int result = _StringIntegerCalculator.CalculatorString(input);
            Assert.IsTrue(result == 110);
        }       

    }
}
