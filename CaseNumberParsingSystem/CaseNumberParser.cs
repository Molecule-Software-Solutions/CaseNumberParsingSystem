using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseNumberParsingSystem
{
    public static class CaseNumberParser
    {
        /// <summary>
        /// Establishes a default case type that will override all others
        /// </summary>
        public static string DefaultCaseType { get; set; }

        public static string ParseCaseNumber(ICaseNumber caseNumber, bool forceDefault)
        {
            throw new NotImplementedException();
        }

        public static string ParseCaseNumber(ICaseNumber caseNumber, bool forceDefault, bool fullYear)
        {
            throw new NotImplementedException();
        }

        public static string ParseCaseNumber(ICaseNumber caseNumber, bool forceDefault, bool fullYear, bool ForceSixDigitSequence)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks to see if case number (Case Type) matches the default
        /// </summary>
        /// <param name="caseNumber"></param>
        /// <returns></returns>
        private static bool CheckCaseTypeAgainstDefault(ICaseNumber caseNumber)
        {
            if (string.IsNullOrEmpty(DefaultCaseType))
                return true;

            if (caseNumber.CaseType.Length > 3)
                return false;

            return caseNumber.CaseType.Equals(DefaultCaseType, StringComparison.InvariantCultureIgnoreCase);
        }

        private static string ReturnLongYear(int year)
        {
            // Error default to this year if data cannot be properly read
            if (year < 10)
                return DateTime.Today.Year.ToString();
            if (year >= 100 && year < 1000)
                return DateTime.Today.Year.ToString();
            if (year > 2200)
                return DateTime.Today.Year.ToString(); 

            if(year >= 10 && year < 100)
            {
                if (year > 60)
                    return (year + 1900).ToString();
                else return (year + 2000).ToString(); 
            }
            
            return year.ToString(); 
        }

        private static string ForceSequence(int sequence)
        {
            return sequence.ToString().PadLeft(6, '0');
        }
    }
}
