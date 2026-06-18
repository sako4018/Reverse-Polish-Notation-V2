using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Polish_Notation
{
    internal class Program
    {
        static void Main(string[] args)
        { //        Условие: Напишете компютърна програма, която приема като вход низ от символи, представляващ
            //математически израз в Обратен полски запис(където числата и операторите са разделени с интервали).
            //Използвайки структурата от данни Стек, програмата трябва да изчисли и изведе в конзолата крайния
            //резултат от израза.
            // Изискване: Програмата трябва да поддържа четирите основни аритметични операции: събиране(+),
            //изваждане(-), умножение(*) и деление(/).

            while (true)
            {
                var line = Console.ReadLine();
                if (line == null || line.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;
                if (string.IsNullOrWhiteSpace(line)) continue;
                var stack = new Stack<double>();
                var tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                bool error = false;
                foreach (var t in tokens)
                {
                    if (double.TryParse(t, out double number))
                    {
                        stack.Push(number);
                    }
                    else
                    {
                        if (stack.Count < 2)
                        {
                            Console.WriteLine($"Error: insufficient operands for operator '{t}'.");
                            error = true;
                            break;
                        }
                        double b = stack.Pop();
                        double a = stack.Pop();

                        switch (t)
                        {
                            case "+":
                                stack.Push(a + b);
                                break;
                            case "-":
                                stack.Push(a - b);
                                break;
                            case "*":
                                stack.Push(a * b);
                                break;
                            case "/":
                                stack.Push(a / b);
                                break;
                            default:
                                Console.WriteLine($"Error: unknown operator '{t}'.");
                                error = true;
                                break;
                        }
                    }
                }
                //The purpose of this commit is to see the diff in GIT
                if (stack.Count == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(stack.Pop());
                }


                //
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
