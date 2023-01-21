using System;

namespace CaseNumberParser;

/// <summary>
/// Static utility for parsing north carolina judicial system standardized case numbers
/// </summary>
public static class ParseEngine
{
    /// <summary>
    /// Return a case number fully parsed. 
    /// </summary>
    /// <param name="input">Case number to be parsed</param>
    /// <param name="caseFormat">Format of the case type. Either A, AA, or AAA representing the type digits of a case number</param>
    /// <param name="yearFormat">Format of the year type. Either 00 or 0000 representing a two or four digit year</param>
    /// <returns></returns>
    public static string ReturnParsed(string input, CaseNumberFormat caseFormat, YearFormat yearFormat)
    {
        try
        {
            string year = ReturnYear(input, yearFormat);
            string caseType = ReturnCaseType(input, yearFormat, caseFormat);
            string sequence = ReturnSequence(input, yearFormat, caseFormat);
            if (string.IsNullOrEmpty(year) || string.IsNullOrEmpty(caseType) || string.IsNullOrEmpty(sequence))
                return string.Empty;

            return $"{year} {caseType} {sequence}";
        }
        catch (Exception)
        {
            return string.Empty; 
        }

    }

    private static string ReturnYear(string input, YearFormat format)
    {
        switch (format)
        {
            case YearFormat.TwoDigit:
                {
                    if (input[2] != 32)
                        return string.Empty; 

                    for(int i = 0; i < 2; i++)
                    {
                        if (input[i] < 48 || input[i] > 57)
                        {
                            return string.Empty;
                        }
                    }
                    return input.Substring(0, 2); 
                }
            case YearFormat.FourDigit:
                {
                    if (input[4] != 32)
                        return string.Empty;

                    for (int i = 0; i < 4; i++)
                    {
                        if (input[i] < 48 || input[i] > 57)
                        {
                            return string.Empty;
                        }
                    }
                    return input.Substring(0, 4); 
                }
            default:
                return string.Empty; 
        }
    }

    private static string ReturnCaseType(string input, YearFormat yearFormat, CaseNumberFormat caseNumberFormat)
    {
        switch (yearFormat)
        {
            case YearFormat.FourDigit:
                switch (caseNumberFormat)
                {
                    case CaseNumberFormat.OneDigitCaseType:
                        {
                            if (input[6] != 32)
                                return string.Empty;

                            if(input.Substring(5, 1)[0] < 97 && input.Substring(5, 1)[0] > 122 && 
                                input.Substring(5, 1)[0] < 65 && input.Substring(5, 1)[0] > 90)
                            {
                                return string.Empty;
                            }
                            return input.Substring(5, 1).ToUpper();
                        }
                    case CaseNumberFormat.TwoDigitCaseType:
                        {
                            if (input[7] != 32)
                                return string.Empty;

                            for (int i = 5; i < 7; i++)
                            {
                                if (input[i] < 97 && input[i] > 122 && 
                                    input[i] < 65 && input[i] > 90)
                                {
                                    return string.Empty; 
                                }
                            }
                            return input.Substring(5, 2).ToUpper(); 
                        }
                    case CaseNumberFormat.ThreeDigitCaseType:
                        {
                            if (input[8] != 32)
                                return string.Empty;

                            for (int i = 5; i < 8; i++)
                            {
                                if (input[i] < 97 && input[i] > 122 &&
                                    input[i] < 65 && input[i] > 90)
                                {
                                    return string.Empty;
                                }
                            }
                            return input.Substring(5, 3).ToUpper();
                        }
                    default:
                        return string.Empty;
                }
            case YearFormat.TwoDigit:
                switch (caseNumberFormat)
                    {
                        case CaseNumberFormat.OneDigitCaseType:
                        {
                            if (input[4] != 32)
                                return string.Empty;

                            if (input.Substring(3, 1)[0] < 97 && input.Substring(3, 1)[0] > 122 &&
                                input.Substring(3, 1)[0] < 65 && input.Substring(3, 1)[0] > 90)
                            {
                                return string.Empty;
                            }
                            return input.Substring(3, 1).ToUpper();
                        }
                        case CaseNumberFormat.TwoDigitCaseType:
                        {
                            if (input[5] != 32)
                                return string.Empty;

                            for (int i = 3; i < 5; i++)
                            {
                                if (input[i] < 97 && input[i] > 122 &&
                                    input[i] < 65 && input[i] > 90)
                                {
                                    return string.Empty;
                                }
                            }
                            return input.Substring(3, 2);
                        }
                        case CaseNumberFormat.ThreeDigitCaseType:
                        {
                            if (input[6] != 32)
                                return string.Empty;

                            for (int i = 3; i < 6; i++)
                            {
                                if (input[i] < 97 && input[i] > 122 &&
                                    input[i] < 65 && input[i] > 90)
                                {
                                    return string.Empty;
                                }
                            }
                            return input.Substring(3, 3);
                        }
                        default:
                            return string.Empty; 
                    }
            default:
                return string.Empty; 
        }
    }

    private static string ReturnSequence(string input, YearFormat yearFormat, CaseNumberFormat caseNumberFormat)
    {
        switch (yearFormat)
        {
            case YearFormat.TwoDigit:
                switch (caseNumberFormat)
                {
                    case CaseNumberFormat.OneDigitCaseType:
                        return input.Substring(5).PadLeft(6, '0'); 
                    case CaseNumberFormat.TwoDigitCaseType:
                        return input.Substring(6).PadLeft(6, '0');
                    case CaseNumberFormat.ThreeDigitCaseType:
                        return input.Substring(7).PadLeft(6, '0');
                    default:
                        return string.Empty; 
                }
            case YearFormat.FourDigit:
                switch (caseNumberFormat)
                {
                    case CaseNumberFormat.OneDigitCaseType:
                        return input.Substring(7).PadLeft(6, '0'); 
                    case CaseNumberFormat.TwoDigitCaseType:
                        return input.Substring(8).PadLeft(6, '0');
                    case CaseNumberFormat.ThreeDigitCaseType:
                        return input.Substring(9).PadLeft(6, '0');
                    default:
                        return string.Empty; 
                }
            default:
                return string.Empty; 
        }
    }
}
