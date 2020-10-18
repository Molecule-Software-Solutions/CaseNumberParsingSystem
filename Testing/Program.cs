using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseNumberParser; 

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "20 JA 1_____";
            string test2 = "2020 JA 1_____";
            Console.WriteLine("Testing two digit year and two digit case type"); 
            Console.WriteLine(new ParseEngine().ReturnParsed(test.Replace("_",""), CaseNumberFormat.TwoDigitCaseType, YearFormat.TwoDigit));

            Console.WriteLine("Testing Four digit year and two digit case type");
            Console.WriteLine(new ParseEngine().ReturnParsed(test2.Replace("_",""), CaseNumberFormat.TwoDigitCaseType, YearFormat.FourDigit)); 
            Console.ReadLine(); 
        }
    }
}
