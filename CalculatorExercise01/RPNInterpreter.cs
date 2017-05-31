using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorExercise01
{
    public class RPNInterpreter
    {
        public delegate double OperationDelegate(double[] ops);
        Dictionary<string, int> priorities;
        Dictionary<string, string> vars;
        Dictionary<string, OperationDelegate> operations;
        Dictionary<string, int> numOfOperands;

        public RPNInterpreter()
        {
            priorities = new Dictionary<string, int>();
            operations = new Dictionary<string, OperationDelegate>();
            vars = new Dictionary<string, string>();
            vars.Add("M", "0.0");

            addPriorities();
            addMathOperations();
            addOperationOperands();
        }

        private void addOperationOperands()
        {
            numOfOperands.Add("+", 2);
            numOfOperands.Add("-", 2);
            numOfOperands.Add("*", 2);
            numOfOperands.Add("/", 2);
            numOfOperands.Add("^", 2);
            numOfOperands.Add("log", 1);
            numOfOperands.Add("sqrt", 1);
            numOfOperands.Add("sin", 1);
            numOfOperands.Add("cos", 1);
            numOfOperands.Add("tan", 1);
            numOfOperands.Add("cot", 1);
        }

        private void addMathOperations()
        {
            operations.Add("log", new OperationDelegate(ops => { if (ops[0] <= 0) { throw new ArgumentException(); } return Math.Log10(ops[0]); }));
            operations.Add("+", new OperationDelegate(ops => ops[0] + ops[1]));
            operations.Add("-", new OperationDelegate(ops => ops[0] - ops[1]));
            operations.Add("*", new OperationDelegate(ops => ops[0] * ops[1]));
            operations.Add("^", new OperationDelegate(ops => Math.Pow(ops[0], ops[1])));
            operations.Add("/", new OperationDelegate(ops => { if (ops[1] == 0) { throw new ArgumentException(); } return ops[0] / ops[1]; }));
            operations.Add("sqrt", new OperationDelegate(ops => { if (ops[0] < 0) { throw new ArgumentException(); } return Math.Sqrt(ops[0]); }));
            operations.Add("sin", new OperationDelegate(ops => { return Math.Sin(ops[0]); }));
            operations.Add("cos", new OperationDelegate(ops => { return Math.Cos(ops[0]); }));
            operations.Add("tan", new OperationDelegate(ops => { return Math.Tan(ops[0]); }));
            operations.Add("cot", new OperationDelegate(ops => { return 1.0 / Math.Tan(ops[0]); }));
            //operations.Add("arcot", new OperationDelegate(ops => { if (ops[0] <= 0) { throw new ArgumentException(); } return Math.Log10(ops[0]); }));
        }

        private void addPriorities()
        {
            numOfOperands = new Dictionary<string, int>();
            priorities.Add(")", -1);
            priorities.Add("(", 0);
            priorities.Add("+", 1);
            priorities.Add("-", 1);
            priorities.Add("*", 2);
            priorities.Add("/", 2);
            priorities.Add("^", 3);
            priorities.Add("log", 0);
            priorities.Add("sqrt", 0);
            priorities.Add("sin", 0);
            priorities.Add("cos", 0);
            priorities.Add("tan", 0);
            priorities.Add("cot", 0);
           //priorities.Add("arcot", 0);
        }

        string operators =  "+-*/";

        bool checkPriority(string op1, string op2)
        {
            return priorities[op1] >= priorities[op2];
        }

        public void addMathFunction(string name, int size, OperationDelegate od, int priority = 0)
        {
            priorities.Add(name, priority);
            operations.Add(name, od);
            numOfOperands.Add(name, size);
        }
        double performOperation(double[] ops, string operation)
        {
            OperationDelegate op = operations[operation];
            return op(ops);
        }

        double computeResult(List<string> expressions)
        {
            Stack<double> results = new Stack<double>();

            foreach(string exp in expressions)
            {
                double value;
                if(getDoubleValue(exp, out value))
                {
                    results.Push(value);
                }
                else
                {
                    int size = numOfOperands[exp];
                    
                    double[] ops = new double[size];
                    if(size > results.Count)
                    {
                        throw new ArgumentException("math expression malformed");
                    }
                    for (int i = ops.Length - 1; i >= 0; i--)
                    {   
                        ops[i] = results.Pop();
                    }
                    double opResult = performOperation(ops, exp);
                    results.Push(opResult);
                }
            }

            return results.Pop();
        }

        public bool getDoubleValue(string s, out double result)
        {

            if(Double.TryParse(s, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                return true;
            }

            return false;
        }

        public List<string> generatePostfixNotation(List<string> tokens)
        {
            List<string> postFix = new List<string>();
            Stack<string> operators = new Stack<string>();
            string poped = "";
            foreach(string token in tokens)
            {
                double result = 0;
                if(getDoubleValue(token, out result))
                {
                    postFix.Add(token);
                }
                else if(vars.ContainsKey(token))
                {
                    postFix.Add(vars[token]);
                }
                else if (priorities[token] == 0)
                {
                    operators.Push(token);
                }
                else if (token.Equals(")"))
                {
                    poped = operators.Pop();
                    while (!poped.Contains("("))
                    {
                        postFix.Add(poped);
                        poped = operators.Pop();                    
                    }
                    if (operators.Count > 0 && priorities[operators.Peek()] == 0 && !operators.Peek().Equals("("))
                    {
                        postFix.Add(operators.Pop());
                    }
                }
                else
                {
                    if (operators.Count > 0 && checkPriority(operators.Peek(), token))
                    {                       
                        while (checkPriority(operators.Peek(), token))
                        {
                            poped = operators.Pop();
                            postFix.Add(poped);

                            if (operators.Count == 0)
                            {
                                break;
                            }
                        }

                        operators.Push(token);
                    }
                    else
                    {
                        operators.Push(token);
                    }
                }
            }

            while(operators.Count > 0)
            {
                postFix.Add(operators.Pop());
            }

            return postFix;

        }

        public double compute(List<string> tokens)
        {
            string var = "";
            if(tokens.Count > 2 && tokens[1].Equals("="))
            {
                var = tokens[0];
                tokens.RemoveRange(0, 2);
            }

            if (tokens.Count == 0)
            {
                throw new ArgumentException("provded list has no elements");
            }

            List<string> postfixTokens = generatePostfixNotation(tokens);
            foreach(string sp in postfixTokens)
            {
                Console.WriteLine(sp);
            }
            double result = computeResult(postfixTokens);
            vars["M"] = result.ToString(CultureInfo.InvariantCulture);

            if(!var.Equals(""))
            {
                if (!vars.ContainsKey(var))
                {
                    vars.Add(var, vars["M"]);
                }
                else
                {
                    vars[var] = vars["M"];
                }
            }

            return result;
        }
    }
}
