using System;
using System.Collections.Generic;
using System.Text.RegularExpressions; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorExercise01
{
    public class Parser
    {

        private static string OP = "^[+|\\-|*|/|\\136|=]$";
        private static string NUMBER = "^-?(?:(?:0|[1-9][0-9]*)(?:[\\.][0-9]+)?|[1-9][0-9]{1,2}(?:[\\.][0-9]{3})+)$";
        private static string BUILTIN = "^(log|sqrt|sin|cos|tan|cot|arcot)$";
        private static string BRACKET = "^(\\(|\\))$";
        private static string VARIABLE = "[A-Za-z][A-Za-z0-9]*";
        //private static string NAME = "[a-zA-Z0-9]+\\(\\)"; // name()

        public List<string> parse(string line)
        {
            if (String.IsNullOrEmpty(line)) return new List<string>();
            // if count of equals > 2 -> empty list
            // split on the equal
            // if the split size == 2
            // [0] -> variable name 
            // [1] -> expression
            // split size == 1
            // ends with = -> empty list
            // otherwise we keep going on


            // result tokens
            List<string> tokens = new List<string>();
            List<string> secondTokens = new List<string>();
            // remove whitespaces
            // line = line.Trim();
            line = Regex.Replace(line, @"\s+", "");

            // string[] lineElements = line.Split(new String[] {"="}, StringSplitOptions.None);
            string[] lineElements = line.Split('=');
            int lineElementsNumber = lineElements.Count<string>();
            if (lineElementsNumber > 2 || (lineElementsNumber == 1 && line.EndsWith("=")))
            {
                return new List<string>();
            }
            else if (lineElementsNumber > 1)
            {
                if (!Regex.IsMatch(lineElements[0], @VARIABLE)) return new List<string>();
                secondTokens.Add(lineElements[0]);
                secondTokens.Add("=");
                line = lineElements[1];
            }

            // current token
            string token = "";

            // first iteration : operators extraction
            foreach (char character in line)
            {
                if (!Regex.IsMatch(character.ToString(), @OP))
                {
                    token += character;
                }
                else
                {
                    if (token.Length > 0)
                    {
                        tokens.Add(token); // operator
                        token = "";
                    }
                    if (
                        ((tokens.Count == 0) ||
                        (tokens.Count > 0
                        && (Regex.IsMatch(tokens.Last<string>(), @OP) 
                            || (tokens.Last<string>().Length > 0 && Regex.IsMatch(tokens.Last<string>()[tokens.Last<string>().Length - 1].ToString(), @BRACKET)))))
                        && character.ToString().Equals("-"))
                    {
                        token += character;
                        continue;
                    }
                    tokens.Add(character.ToString());

                }
            }
            tokens.Add(token);
            // "(log(10))", "+", "(1", "+", "2)"

            // second iteration
            foreach (string currentToken in tokens)
            {
                if (!Regex.IsMatch(currentToken, @OP))
                {
                    string tempToken = currentToken.Replace("(", "~(~");
                    tempToken = tempToken.Replace(")", "~)~");
                    List<string> splitTokens = tempToken.Split('~').ToList<string>();
                    splitTokens.RemoveAll(element => string.IsNullOrEmpty(element));
                    foreach (string splitToken in splitTokens)
                    {
                        if (Regex.IsMatch(splitToken, @NUMBER) || Regex.IsMatch(splitToken, @BUILTIN) || 
                            Regex.IsMatch(splitToken, @BRACKET) || Regex.IsMatch(splitToken, @VARIABLE))
                        {
                            // number
                            secondTokens.Add(splitToken);
                        }
                        else
                        {
                            return new List<string>();
                        }
                    }
                }
                else
                {
                    secondTokens.Add(currentToken);
                }
            }
            if (secondTokens.Count >= 1) return secondTokens;
            else return new List<string>();
        }
    }
}
