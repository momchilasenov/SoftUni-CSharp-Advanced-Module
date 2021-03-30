using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionsSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            //note: expression doesn't work with negative numbers
            string expression = "2*2^3";

            //we start going through the expression symbol by symbol
            //we use a different method to divide the responsibilities
            // the main method job is to print the result
            double result = Evaluate(expression);
            Console.WriteLine(result);

        }

        static double Evaluate(string expression)
        {
            string specialSymbols = "+-*/^";
            Stack<double> numbers = new Stack<double>(); //stack for all the numbers (operands)
            Stack<char> operators = new Stack<char>(); //stack for all the operators + - * /   

            for (int i = 0; i < expression.Length; i++)
            {
                char currentChar = expression[i];

                if (currentChar == '(')
                {
                    operators.Push(currentChar);
                }
                else if (currentChar == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        var op = operators.Pop();
                        var param2 = numbers.Pop();
                        var param1 = numbers.Pop();
                        var newValue = ApplyOperation(op, param1, param2);
                        numbers.Push(newValue);
                    }

                    operators.Pop(); //remove the '('
                }
                else if (specialSymbols.Contains(currentChar))
                {
                    //first we add the operators with higher priority
                    while (operators.Count > 0 && Priority(operators.Peek()) >= Priority(currentChar))
                    {
                        var op = operators.Pop();
                        var param2 = numbers.Pop();
                        var param1 = numbers.Pop();
                        var newValue = ApplyOperation(op, param1, param2);
                        numbers.Push(newValue);
                    }

                    operators.Push(currentChar);
                }
                else if (char.IsDigit(currentChar) || currentChar == '.')
                {
                    StringBuilder number = new StringBuilder();
                    while (char.IsDigit(currentChar) || currentChar == '.')
                    {
                        number.Append(currentChar);
                        i++; //manually go to the next symbol if it's a digit
                        if (i == expression.Length)
                        {
                            break;
                        }
                        currentChar = expression[i];

                    }
                    i--;
                    numbers.Push(double.Parse(number.ToString()));
                }

            }

            while (operators.Count > 0) //if some extra expression is left in the stack
            {
                var op = operators.Pop();
                var param2 = numbers.Pop();
                var param1 = numbers.Pop();
                var newValue = ApplyOperation(op, param1, param2);
                numbers.Push(newValue);
            }
            return numbers.Pop();
        }

        static double ApplyOperation(char operation, double operand1, double operand2)
        {
            switch (operation)
            {
                case '+': return operand1 + operand2;
                case '-': return operand1 - operand2;
                case '*': return operand1 * operand2;
                case '/': return operand1 / operand2;
                case '^': return Math.Pow(operand1,operand2);
                default: return 0.0;

            }
        }

        static int Priority(char operation)
        {
            switch (operation)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                case '^': return 3;
                default: return 0;
            }
        }

    }
}
