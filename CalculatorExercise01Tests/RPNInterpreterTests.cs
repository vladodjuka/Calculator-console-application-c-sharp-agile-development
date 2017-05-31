using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorExercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorExercise01.Tests
{
    [TestClass()]
    public class RPNInterpreterTests
    {
        [TestMethod()]
        /// ///////////////////////////////////ADDITION///////////////////////////////////////////////////////////
        public void RPNInterpreterTest1()
        {
            //test
            //addition of 2 positive numbers
            string expression = "1+2";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(3, result);


        }
        public void RPNInterpreterTest2()
        {
            //addition of 2 negative numbers
            string expression = "-1-2";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(-3, result);


        }
        public void RPNInterpreterTest3()
        {
            //addition of 1 negative 1 positive
            string expression = "-1+2";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(1, result);


        }
        /// ///////////////////////////////////SUBSTRACT///////////////////////////////////////////////////////////
        public void RPNInterpreterTest4()
        {
            //substraction of 2 positive numbers
            string expression = "1-2";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            foreach (string s in parsedValues)
            {
                Console.WriteLine(s);
            }
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(-1, result);


        }
        public void RPNInterpreterTest5()
        {
            //substraction of 2 negative numbers
            string expression = "-1-(-2)";  //check if no parantheses is illegal
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(1, result);


        }
        public void RPNInterpreterTest6()
        {
            //substraction of 1 negative 1 positive
            string expression = "-1-2";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(-3, result);


        }
        /// ///////////////////////////////////MULTIPLICATION///////////////////////////////////////////////////////////
        public void RPNInterpreterTest7()
        {
            //multiplication of 2 positive numbers
            string expression = "1*2";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(2, result);


        }
        public void RPNInterpreterTest8()
        {
            //multiplication of 2 negative numbers
            string expression = "-1*(-2)";  //check if no parantheses is illegal
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(2, result);


        }
        public void RPNInterpreterTest9()
        {
            //multiplication of 1 negative 1 positive
            string expression = "-1*2";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(-2, result);


        }

        /// ///////////////////////////////////DIVISION///////////////////////////////////////////////////////////

        public void RPNInterpreterTest10()
        {
            //division of 2 positive numbers
            string expression = "1/2";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(0.5, result);


        }
        public void RPNInterpreterTest11()
        {
            //division of 2 negative numbers
            string expression = "-1/(-2)";  //check if no parantheses is illegal
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(0.5, result);


        }
        public void RPNInterpreterTest12()
        {
            //division of 1 negative 1 positive
            string expression = "-1/2";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(-0.5, result);


        }

        /// ///////////////////////////////////////////////////// SPECIAL CASES //////////////////////////////////////

        public void RPNInterpreterTest13()
        {
            //test
            //null string
            string expression = "";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (ArgumentException) { }
        }

        public void RPNInterpreterTest14()
        {
            //test
            //divide by 0
            string expression = "10/0";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (ArgumentException) { }
        }


        public void RPNInterpreterTest15()
        {
            //test
            //mul by 0
            string expression = "10*0";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(0, result);
        }

        /// ///////////////////////////////////////////////////// POWER FUNCTIONS //////////////////////////////////////


        public void RPNInterpreterTest16()
        {
            //test
            //squrae of a neg num
            string expression = "-2^2";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(4, result);
        }

        public void RPNInterpreterTest17()
        {
            //test
            //squrae of a positive num
            string expression = "5^2";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(25, result);
        }
        public void RPNInterpreterTest18()
        {
            //test
            //square root of a positive num
            string expression = "25^(1/2)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(5, result);
        }
        public void RPNInterpreterTest19()
        {
            //test
            //square root of a negative num
            string expression = "-25^(1/2)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (ArgumentException) { }
        }

        public void RPNInterpreterTest20()
        {
            //test
            //power of a positive num
            string expression = "2^(4)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(16, result);
        }

        public void RPNInterpreterTest21()
        {
            //test
            //power of a negative positive num
            string expression = "-3^3";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(-27, result);
        }

        public void RPNInterpreterTest22()
        {
            //test
            //negative power of a negative positive num
            string expression = "-2^(-2)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(0.25, result);
        }


        public void RPNInterpreterTest29()
        {
            //test
            //trignomatery 
            string expression = "0^0";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(1, result);
        }

        public void RPNInterpreterTest30()
        {
            //test
            //trignomatery 
            string expression = "5^0";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(1, result);
        }
        public void RPNInterpreterTest31()
        {
            //test
            //trignomatery 
            string expression = "0^10";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(0, result);
        }
        public void RPNInterpreterTest32()
        {
            //test
            //trignomatery 
            string expression = "-1^0";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(1, result);
        }


        ///////////////////////////////////////////////////////////////////////SERIALIZED OPERATIONS/////////////////////////////////////////////

        public void RPNInterpreterSerialx()
        {
            //test

            //multiple expression
            string expression = "1-2*8-3";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(-18, result);
        }
        public void RPNInterpreterSerial1()
        {
            //test

            //multiple expression
            string expression = "1+2*8-3";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(14, result);
        }
        public void RPNInterpreterSerial2()
        {
            //test
            //multiple expression
            string expression = "1+2*2*3";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(13, result);
        }

        public void RPNInterpreterSerial3()
        {
            //test

            //multiple expression
            string expression = "1-2*2*3";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(-11, result);
        }
        public void RPNInterpreterSerial4()
        {
            //test
            //multiple expression
            string expression = "2*2*3+1";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(13, result);
        }
        public void RPNInterpreterSerial5()
        {
            //test
            //multiple expression
            string expression = "2/2*3+1";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void RPNInterpreterSerial6()
        {
            //test
            //invalid expression 
            string expression = "(1+3)/";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (InvalidOperationException) { }

        }
        public void RPNInterpreterSerial7()
        {
            //test
            //multiple  expressions
            string expression = " 1  * 24 + \n\npi";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (ArgumentException) { }
        }

        public void RPNInterpreterSerial8()
        {
            //test
            //multiple  expressions
            string expression = " 1 +6/2+-*";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();

            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (ArgumentException) { }
        }
        public void RPNInterpreterSerial9()
        {
            //test
            //multiple  expressions
            string expression = "+1+1+1+1*0-1/-1/1";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();

            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (InvalidOperationException) { }
        }

        public void RPNInterpreterSerial20()
        {
            //test
            //multiple  expressions
            string expression = "20^0+0^-1";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (ArgumentException) { }
        }

        public void RPNInterpreterSerial21()
        {
            //test
            //multiple  expressions
            string expression = "20^0+k";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (ArgumentException) { }
        }

        public void RPNInterpreterSerial22()
        {
            //test
            //multiple  expressions
            string expression = "10+a-90";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (ArgumentException) { }
        }

        public void RPNInterpreterSerial23()
        {
            //test
            //multiple  expressions
            string expression = "1*+3+2*";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (InvalidOperationException) { }
        }

        public void RPNInterpreterSerial24()
        {
            //test
            //multiple  expressions
            string expression = "10/jhiuh";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (ArgumentException) { }
        }

        public void RPNInterpreterSerial25()
        {
            //test
            //multiple  expressions
            string expression = "1hh";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (ArgumentException) { }
        }
        ////////////////////////// //////////////////////////////////////////////////////////////LOGARITHMS///////////////////////////////////////////////

        public void RPNInterpreterLogarithm0()
        {
            //test
            //log functions
            string expression = " log(10)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(1, result);
        }
        public void RPNInterpreterLogarithm1()
        {
            //test
            //log functions
            string expression = " log(100)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(2, result);
        }

        public void RPNInterpreterLogarithm2()
        {
            //test
            //log functions
            string expression = " (log(100))^2";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(4, result);
        }
        public void RPNInterpreterLogarithm3()
        {
            //test
            //log functions
            string expression = " (log(100)^-2)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(0.25, result);
        }

        public void RPNInterpreterLogarithm4()
        {
            //test
            //log functions
            string expression = " (log(1))";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(0, result);
        }
        public void RPNInterpreterLogarithm5()
        {
            //test
            //log functions
            string expression = " (log(0))";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (ArgumentException) { }
        }
        public void RPNInterpreterLogarithm6()
        {
            //test
            //log functions
            string expression = " (log(10*100)+3)/(2*3)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(1, result);
        }

        public void RPNInterpreterLogarithm7()
        {
            //test
            //log functions
            string expression = " (log(-10))";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (ArgumentException) { }
        }
        public void RPNInterpreterLogarithm8()
        {
            //test
            //log functions
            string expression = " log(100)/(log(10)*2)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(1, result);
        }
        public void RPNInterpreterLogarithm9()
        {
            //test
            //log functions
            string expression = " (log(100)/*2)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            try
            {
                double result = RPN.compute(parsedValues);
                Assert.Fail("Expected exception");
            }
            catch (InvalidOperationException) { }
        }
        public void RPNInterpreterLogarithm10()
        {
            //test
            //log functions
            string expression = " (log(100/10)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(1, result);
        }

        /// ////////////////////////////////////////////////////////////////////TRIGONOMETRY/////////////////////////////////////////


        public void RPNInterpreterTest28()
        {
            //test
            //trignomatery 
            string expression = " sin(0)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Assert.AreEqual(0, result);
        }
        public void RPNInterpreterTrig01()
        {
            //test
            //trignomatery 
            string expression = " sin(1.0472)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Boolean boolx = false;
            double acceptableDifference = 0.1;
            if (Math.Abs(result - 0.866) <= acceptableDifference)
            {
                boolx = true;

            }
            Assert.IsTrue(boolx);
        }
        public void RPNInterpreterTrig02()
        {
            //test
            //trignomatery 
            string expression = " cos(1.0472)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Boolean boolx = false;
            double acceptableDifference = 0.1;
            if (Math.Abs(result - 0.5) <= acceptableDifference)
            {
                boolx = true;

            }
            Assert.IsTrue(boolx);
        }

        public void RPNInterpreterTrig03()
        {
            //test
            //trignomatery 
            string expression = " tan(cos(1.0472))";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Boolean boolx = false;
            double acceptableDifference = 0.1;
            if (Math.Abs(result - 0.54630) <= acceptableDifference)
            {
                boolx = true;

            }
            Assert.IsTrue(boolx);
        }
        public void RPNInterpreterTrig04()
        {
            //test
            //trignomatery 
            string expression = " sin(tan(cos(1.0472)))";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Boolean boolx = false;
            double acceptableDifference = 0.1;
            if (Math.Abs(result - 0.519) <= acceptableDifference)
            {
                boolx = true;

            }
            Assert.IsTrue(boolx);
        }

        public void RPNInterpreterTrig05()
        {
            //test
            //trignomatery 
            string expression = " sin(tan(cos(1.0472)^-1))";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Boolean boolx = false;
            double acceptableDifference = 0.1;
            if (Math.Abs(result - (-0.817)) <= acceptableDifference)
            {
                boolx = true;

            }
            //Assert.IsTrue(boolx);
            Assert.AreEqual(-0.817, result);
        }

        public void RPNInterpreterTrig06()
        {
            //test
            //trignomatery 
            string expression = " log(100+100)*((cos(1.0472)^2)^-2)";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Boolean boolx = false;
            double acceptableDifference = 0.1;
            if (Math.Abs(result - 83.0539) <= acceptableDifference)
            {
                boolx = true;

            }
            //Assert.IsTrue(boolx);
            Assert.AreEqual(83.0539, result);
        }
        public void RPNInterpreterTrig07()
        {
            //test
            //trignomatery 
            string expression = " log(100+100) /25";
            Parser parser = new Parser();
            List<string> parsedValues = parser.parse(expression);
            RPNInterpreter RPN = new RPNInterpreter();
            double result = RPN.compute(parsedValues);
            Boolean boolx = false;
            double acceptableDifference = 0.1;
            if (Math.Abs(result - 83.0539) <= acceptableDifference)
            {
                boolx = true;

            }
            //Assert.IsTrue(boolx);
            Assert.AreEqual(-0.817, result);
        }




        [TestMethod()]
        public void computeTest()
        {
            Assert.Fail();
        }
    }
}