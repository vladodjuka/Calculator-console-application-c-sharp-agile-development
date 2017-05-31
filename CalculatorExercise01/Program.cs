using System;
using System.Collections.Generic;

namespace CalculatorExercise01
{
    class Program
    {

        private static void start(string initialInput) {

            Parser parser = new Parser();
            RPNInterpreter interpreter = new RPNInterpreter();
            string input = initialInput;
            do
            {
                if (String.IsNullOrEmpty(initialInput))
                {
                    Console.Write("> ");
                    input = Console.ReadLine();
                }
                else
                {
                    initialInput = "";
                }
                switch (input)
                {
                    case "q":
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        try
                        {
                            List<string> tokens = parser.parse(input);
                            double value = interpreter.compute(tokens);
                            if (value > Double.MaxValue) value = Double.MaxValue;
                            Console.WriteLine(value);
                        }
                        catch (Exception e){
                            Console.WriteLine("Illegal Expression!");
                        }
                        break;
                }
            } while (!input.Equals("q"));
        }

        static void Main(string[] args)
        {
            System.Media.SystemSounds.Beep.Play();
            Console.WriteLine("Aloha Friend. Write down your computation, please.");
            Console.WriteLine("Insert \"q\" to quit.");
            Console.Write("> ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "q":
                    Console.WriteLine("Bye!");
                    return;
                default:
                    start(input);
                    return;
            }
        }

        static void lala(string[] args)
        {
            string s = "a=5*2";
            Parser p = new Parser();
            List<string> tokens = p.parse(s);
            RPNInterpreter rpn = new RPNInterpreter();
            double result = rpn.compute(tokens);
            Console.WriteLine(result);
            result = rpn.compute(tokens);
            Console.WriteLine(result);
        }
    }
}
