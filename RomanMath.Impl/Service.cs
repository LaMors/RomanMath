using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanMath.Impl
{
	public static class Service
	{
        private static readonly List<char> AllowedСharacters = new List<char>
        {
            'M', 'D', 'C', 'L', 'X', 'V', 'I',
            '+', '-', '*'
        };
        /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>

        public static int Evaluate(string expression)
        {
            //Removing white space between characters
            expression = expression.Replace(" ", "");

            if (IsValid(expression))
            {

                // Slice a string into an array of Roman numbers in string format and convert them to Arabic
                var resultExpression = expression
                            .Split(new char[] { '+', '-', '*', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => new {
                                              romanNumber = s,
                                              arabicNumber = new RomanNumerals(s).ArabicEquivalent
                                                                                 .ToString()
                            });

                // Slice a string into an array of roman numbers
                var substings = expression.Split(new char[] { '+', '-', '*', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // For convenient replacement of sections of text, we will use the class "StringBuilder"
                var tempExpression = new StringBuilder(expression);
                foreach (var substing in substings)
                {
                    var t = tempExpression.ToString().IndexOf(substing);
                    tempExpression = tempExpression.Replace(substing, resultExpression.First(s => s.romanNumber.Equals(substing))
                                                                                                   .arabicNumber, 0, tempExpression.ToString()
                                                                                                                                   .IndexOf(substing) + substing.Length);
                }

                expression = tempExpression.ToString();
                return MathParser.Parse(expression);
            }

            else
                return 0;
        }

        /// <summary>
        /// Checks incoming string for compliance
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static bool IsValid(string expression)
        {
            if (expression == "")
            {
                Console.WriteLine("You entered an empty line");
                return false;
            }

            if (expression[0] == '*')
            {
                Console.WriteLine("A mathematical expression cannot start with a multiplication sign");
                return false;
            }

            if (expression.Length == 1 && new char[] { '+', '-', '*', ' ' }.Contains(expression[0]))
            {
                Console.WriteLine("A mathematical expression cannot consist of only one symbol");
                return false;
            }

            foreach (var character in from character in expression
                                      where !AllowedСharacters.Contains(character)
                                      select character)
            {
                Console.WriteLine($"You entered an invalid character \"{character}\"");
                return false;
            }

            return true;
        }
    }
}
