using Hangfire.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanMath.Impl
{
    /// <summary>
    /// Contains a number in Roman and Arabic notation, performs operations on Roman numbers
    /// </summary>
    public class RomanNumerals
    {

        public static readonly Dictionary<char, int> ArabicFromRoman = new Dictionary<char, int>
         { 
            { 'M', 1000}, { 'D' , 500 }, 
            { 'C', 100 }, { 'L' , 50 }, 
            { 'X', 10 },  { 'V' , 5 },  
            { 'I', 1 } 
         };


        private string romanNumber;
       

        public string RomanNumber 
        {
            get => romanNumber;

            set 
            {
                foreach (var symbol in value
                                        .ToCharArray()
                                        .Where(symbol => !ArabicFromRoman
                                                         .ContainsKey(symbol)))
                {
                    throw new Exception($"Is symbol \"{symbol}\" in the number \"{value}\" not a roman letter");
                };

                romanNumber = value;
            }
        }

        public int ArabicEquivalent
        {
            get => ToArabic(RomanNumber);
        }


        public RomanNumerals(string _romanNumber)
        {
            RomanNumber = _romanNumber ?? "default";
        }

        /// <summary>
        /// Converts a Roman number in the form of a string to Arabic
        /// </summary>
        /// <param name="substring"></param>
        /// <returns></returns>
        public static int ToArabic(string substring)
        {
            var arabicNumber = 0;
            for (int i = 0; i < substring.Length - 1; i++)
            {
                if (ToArabic(substring[i]) < ToArabic(substring[i + 1]))
                    arabicNumber -= ToArabic(substring[i]);
                else
                    arabicNumber += ToArabic(substring[i]);
            }
            
            return arabicNumber += ToArabic(substring[substring.Length - 1]); ;
        }

        /// <summary>
        /// Converts a Roman number in the form of a char to Arabic
        /// </summary>
        /// <param name="substring"></param>
        /// <returns></returns>
        public static int ToArabic(char number) => ArabicFromRoman
                                                   .Where(d => d.Key == number)
                                                   .Select(d => d.Value)
                                                   .First();

    }

}
