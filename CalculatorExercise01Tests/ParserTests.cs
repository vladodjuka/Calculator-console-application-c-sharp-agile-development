using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorExercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CalculatorExercise01.Tests
{
    [TestClass()]
    public class ParserTests
    {

        // single operator - correct
        [TestMethod()]
        public void parseTest1()
        {
            Parser parser = new Parser();
            string input = "2+2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(3, tokens.Count); // three tokens
            Assert.AreEqual("2", tokens[0]); // 2
            Assert.AreEqual("+", tokens[1]); // +
            Assert.AreEqual("2", tokens[2]); // 2
        }

        [TestMethod()]
        public void parseTest2()
        {
            Parser parser = new Parser();
            string input = "2-2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(3, tokens.Count); // three tokens
            Assert.AreEqual("2", tokens[0]); // 2
            Assert.AreEqual("-", tokens[1]); // -
            Assert.AreEqual("2", tokens[2]); // 2
        }

        [TestMethod()]
        public void parseTest3()
        {
            Parser parser = new Parser();
            string input = "2*2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(3, tokens.Count); // three tokens
            Assert.AreEqual("2", tokens[0]); // 2
            Assert.AreEqual("*", tokens[1]); // *
            Assert.AreEqual("2", tokens[2]); // 2
        }

        [TestMethod()]
        public void parseTest4()
        {
            Parser parser = new Parser();
            string input = "2/2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(3, tokens.Count); // three tokens
            Assert.AreEqual("2", tokens[0]); // 2
            Assert.AreEqual("/", tokens[1]); // /
            Assert.AreEqual("2", tokens[2]); // 2
        }

        [TestMethod()]
        public void parseTest5()
        {
            Parser parser = new Parser();
            string input = "-2+-2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(3, tokens.Count); // three tokens
            Assert.AreEqual("-2", tokens[0]); // -2
            Assert.AreEqual("+", tokens[1]); // +
            Assert.AreEqual("-2", tokens[2]); // -2
        }

        [TestMethod()]
        public void parseTest6()
        {
            Parser parser = new Parser();
            string input = "-2--2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(3, tokens.Count); // three tokens
            Assert.AreEqual("-2", tokens[0]); // -2
            Assert.AreEqual("-", tokens[1]); // -
            Assert.AreEqual("-2", tokens[2]); // -2
        }

        [TestMethod()]
        public void parseTest7()
        {
            Parser parser = new Parser();
            string input = "-2*-2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(3, tokens.Count); // three tokens
            Assert.AreEqual("-2", tokens[0]); // -2
            Assert.AreEqual("*", tokens[1]); // *
            Assert.AreEqual("-2", tokens[2]); // -2
        }

        [TestMethod()]
        public void parseTest8()
        {
            Parser parser = new Parser();
            string input = "-2/-2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(3, tokens.Count); // three tokens
            Assert.AreEqual("-2", tokens[0]); // -2
            Assert.AreEqual("/", tokens[1]); // /
            Assert.AreEqual("-2", tokens[2]); // -2
        }

        // multiple operator - correct
        [TestMethod()]
        public void parseTest9()
        {
            Parser parser = new Parser();
            string input = "2+2+2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(5, tokens.Count); // five tokens
            Assert.AreEqual("2", tokens[0]); // 2
            Assert.AreEqual("+", tokens[1]); // +
            Assert.AreEqual("2", tokens[2]); // 2
            Assert.AreEqual("+", tokens[3]); // +
            Assert.AreEqual("2", tokens[4]); // 2
        }

        [TestMethod()]
        public void parseTest10()
        {
            Parser parser = new Parser();
            string input = "2-2-2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(5, tokens.Count); // five tokens
            Assert.AreEqual("2", tokens[0]); // 2
            Assert.AreEqual("-", tokens[1]); // -
            Assert.AreEqual("2", tokens[2]); // 2
            Assert.AreEqual("-", tokens[3]); // -
            Assert.AreEqual("2", tokens[4]); // 2
        }

        [TestMethod()]
        public void parseTest11()
        {
            Parser parser = new Parser();
            string input = "2*2*2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(5, tokens.Count); // five tokens
            Assert.AreEqual("2", tokens[0]); // 2
            Assert.AreEqual("*", tokens[1]); // *
            Assert.AreEqual("2", tokens[2]); // 2
            Assert.AreEqual("*", tokens[3]); // *
            Assert.AreEqual("2", tokens[4]); // 2
        }

        [TestMethod()]
        public void parseTest12()
        {
            Parser parser = new Parser();
            string input = "2/2/2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(5, tokens.Count); // five tokens
            Assert.AreEqual("2", tokens[0]); // 2
            Assert.AreEqual("/", tokens[1]); // /
            Assert.AreEqual("2", tokens[2]); // 2
            Assert.AreEqual("/", tokens[3]); // /
            Assert.AreEqual("2", tokens[4]); // 2
        }

        [TestMethod()]
        public void parseTest13()
        {
            Parser parser = new Parser();
            string input = "-2+-2+-2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(5, tokens.Count); // three tokens
            Assert.AreEqual("-2", tokens[0]); // -2
            Assert.AreEqual("+", tokens[1]); // +
            Assert.AreEqual("-2", tokens[2]); // -2
            Assert.AreEqual("+", tokens[3]); // +
            Assert.AreEqual("-2", tokens[4]); // -2
        }

        [TestMethod()]
        public void parseTest14()
        {
            Parser parser = new Parser();
            string input = "-2--2--2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(5, tokens.Count); // five tokens
            Assert.AreEqual("-2", tokens[0]); // -2
            Assert.AreEqual("-", tokens[1]); // -
            Assert.AreEqual("-2", tokens[2]); // -2
            Assert.AreEqual("-", tokens[3]); // -
            Assert.AreEqual("-2", tokens[4]); // -2
        }

        [TestMethod()]
        public void parseTest15()
        {
            Parser parser = new Parser();
            string input = "-2*-2*-2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(5, tokens.Count); // five tokens
            Assert.AreEqual("-2", tokens[0]); // -2
            Assert.AreEqual("*", tokens[1]); // *
            Assert.AreEqual("-2", tokens[2]); // -2
            Assert.AreEqual("*", tokens[3]); // *
            Assert.AreEqual("-2", tokens[4]); // -2
        }

        [TestMethod()]
        public void parseTest16()
        {
            Parser parser = new Parser();
            string input = "-2/-2/-2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(5, tokens.Count); // five tokens
            Assert.AreEqual("-2", tokens[0]); // -2
            Assert.AreEqual("/", tokens[1]); // /
            Assert.AreEqual("-2", tokens[2]); // -2
            Assert.AreEqual("/", tokens[3]); // /
            Assert.AreEqual("-2", tokens[4]); // -2
        }

        // parentheses - correct
        [TestMethod()]
        public void parseTest17()
        {
            Parser parser = new Parser();
            string input = "()";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(2, tokens.Count); // two tokens
            Assert.AreEqual("(", tokens[0]); // (
            Assert.AreEqual(")", tokens[1]); // )
        }

        [TestMethod()]
        public void parseTest18()
        {
            Parser parser = new Parser();
            string input = "(2-2)";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(5, tokens.Count); // five tokens
            Assert.AreEqual("(", tokens[0]); // (
            Assert.AreEqual("2", tokens[1]); // 2
            Assert.AreEqual("-", tokens[2]); // -
            Assert.AreEqual("2", tokens[3]); // 2
            Assert.AreEqual(")", tokens[4]); // )
        }

        [TestMethod()]
        public void parseTest19()
        {
            Parser parser = new Parser();
            string input = "(2*2)/(2+2)";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(11, tokens.Count); // eleven tokens
            Assert.AreEqual("(", tokens[0]); // (
            Assert.AreEqual("2", tokens[1]); // 2
            Assert.AreEqual("*", tokens[2]); // *
            Assert.AreEqual("2", tokens[3]); // 2
            Assert.AreEqual(")", tokens[4]); // )
            Assert.AreEqual("/", tokens[5]); // /
            Assert.AreEqual("(", tokens[6]); // (
            Assert.AreEqual("2", tokens[7]); // 2
            Assert.AreEqual("+", tokens[8]); // +
            Assert.AreEqual("2", tokens[9]); // 2
            Assert.AreEqual(")", tokens[10]); // )
        }

        [TestMethod()]
        public void parseTest20()
        {
            Parser parser = new Parser();
            string input = "log(2)";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(4, tokens.Count); // four tokens
            Assert.AreEqual("log", tokens[0]); // log
            Assert.AreEqual("(", tokens[1]); // (
            Assert.AreEqual("2", tokens[2]); // 2
            Assert.AreEqual(")", tokens[3]); // )
        }

        [TestMethod()]
        public void parseTest21()
        {
            Parser parser = new Parser();
            string input = "log(log(2))";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(7, tokens.Count); // three tokens
            Assert.AreEqual("log", tokens[0]); // log
            Assert.AreEqual("(", tokens[1]); // (
            Assert.AreEqual("log", tokens[2]); // log
            Assert.AreEqual("(", tokens[3]); // (
            Assert.AreEqual("2", tokens[4]); // 2
            Assert.AreEqual(")", tokens[5]); // )
            Assert.AreEqual(")", tokens[6]); // )
        }

        [TestMethod()]
        public void parseTest22()
        {
            Parser parser = new Parser();
            string input = "(-2)";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(3, tokens.Count); // three tokens
            Assert.AreEqual("(", tokens[0]); // (
            Assert.AreEqual("-2", tokens[1]); // -2
            Assert.AreEqual(")", tokens[2]); // )
        }

        // built-in functions - correct
        [TestMethod()]
        public void parseTest23()
        {
            Parser parser = new Parser();
            string input = "log(1)";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(4, tokens.Count); // four tokens
            Assert.AreEqual("log", tokens[0]); // log
            Assert.AreEqual("(", tokens[1]); // (
            Assert.AreEqual("1", tokens[2]); // 1
            Assert.AreEqual(")", tokens[3]); // )
        }

        [TestMethod()]
        public void parseTest24()
        {
            Parser parser = new Parser();
            string input = "log(log(2))";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(7, tokens.Count); // seven tokens
            Assert.AreEqual("log", tokens[0]); // log
            Assert.AreEqual("(", tokens[1]); // (
            Assert.AreEqual("log", tokens[2]); // log
            Assert.AreEqual("(", tokens[3]); // (
            Assert.AreEqual("2", tokens[4]); // 2
            Assert.AreEqual(")", tokens[5]); // )
            Assert.AreEqual(")", tokens[6]); // )
        }

        [TestMethod()]
        public void parseTest25()
        {
            Parser parser = new Parser();
            string input = "sin(1)";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(4, tokens.Count); // four tokens
            Assert.AreEqual("sin", tokens[0]); // log
            Assert.AreEqual("(", tokens[1]); // (
            Assert.AreEqual("1", tokens[2]); // 1
            Assert.AreEqual(")", tokens[3]); // )
        }

        [TestMethod()]
        public void parseTest26()
        {
            Parser parser = new Parser();
            string input = "sin(sin(2))";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(7, tokens.Count); // seven tokens
            Assert.AreEqual("sin", tokens[0]); // sin
            Assert.AreEqual("(", tokens[1]); // (
            Assert.AreEqual("sin", tokens[2]); // sin
            Assert.AreEqual("(", tokens[3]); // (
            Assert.AreEqual("2", tokens[4]); // 2
            Assert.AreEqual(")", tokens[5]); // )
            Assert.AreEqual(")", tokens[6]); // )
        }
        [TestMethod()]
        public void parseTest27()
        {
            Parser parser = new Parser();
            string input = "cos(1)";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(4, tokens.Count); // four tokens
            Assert.AreEqual("cos", tokens[0]); // cos
            Assert.AreEqual("(", tokens[1]); // (
            Assert.AreEqual("1", tokens[2]); // 1
            Assert.AreEqual(")", tokens[3]); // )
        }

        [TestMethod()]
        public void parseTest28()
        {
            Parser parser = new Parser();
            string input = "sqrt(tan(2))";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(7, tokens.Count); // seven tokens
            Assert.AreEqual("sqrt", tokens[0]); // sqrt
            Assert.AreEqual("(", tokens[1]); // (
            Assert.AreEqual("tan", tokens[2]); // tan
            Assert.AreEqual("(", tokens[3]); // (
            Assert.AreEqual("2", tokens[4]); // 2
            Assert.AreEqual(")", tokens[5]); // )
            Assert.AreEqual(")", tokens[6]); // )
        }
        [TestMethod()]
        public void parseTest29()
        {
            Parser parser = new Parser();
            string input = "arcot(1)";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(4, tokens.Count); // four tokens
            Assert.AreEqual("arcot", tokens[0]); // arcot
            Assert.AreEqual("(", tokens[1]); // (
            Assert.AreEqual("1", tokens[2]); // 1
            Assert.AreEqual(")", tokens[3]); // )
        }

        [TestMethod()]
        public void parseTest30()
        {
            Parser parser = new Parser();
            string input = "2^(log(2))";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(8, tokens.Count); // eight tokens
            Assert.AreEqual("2", tokens[0]); // 2
            Assert.AreEqual("^", tokens[1]); // ^
            Assert.AreEqual("(", tokens[2]); // (
            Assert.AreEqual("log", tokens[3]); // log
            Assert.AreEqual("(", tokens[4]); // (
            Assert.AreEqual("2", tokens[5]); // 2
            Assert.AreEqual(")", tokens[6]); // )
            Assert.AreEqual(")", tokens[7]); // )
        }

        // variables

        [TestMethod()]
        public void parseTest31() {
            Parser parser = new Parser();
            string input = "x = log+2";
            List<string> tokens = parser.parse(input);
            Assert.AreEqual(5, tokens.Count); 
            Assert.AreEqual("x", tokens[0]); 
            Assert.AreEqual("=", tokens[1]); 
            Assert.AreEqual("log", tokens[2]); 
            Assert.AreEqual("+", tokens[3]); 
            Assert.AreEqual("2", tokens[4]); 
        }
    }
}