using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace RomanMath.Impl
{
    /// <summary>
    /// Parser of math strings
    /// </summary>
    public class MathParser
    {
        /// <summary>
        /// Solves a mathematical expression in the form of a string
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static int Parse(string expression)
        {
            return CSharpScript.EvaluateAsync<int>(expression).Result;
        }
    }
      
}
