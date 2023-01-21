# Case Number Parser Core
## Framework version: .NET Core 6.0
Case number parser core is a .NET 6.0 library with long term support. 

## What is it? 
Case number parser is a simple library that can be used to parse North Carolina judicial system case numbers into a standardized format. Note: This library is designed to support trial court level case numbers only. Modifications will be required for appellate divisions. 

## Supported case number types
### Single digit case types
1. E - Estates
2. R - Registrations
3. M - Miscellaneous
4. T - Transcript

### Single digit case output format
1. Two digit year: 00 X 000000
2. Four digit year: 0000 X 000000

### Two digit case types
1. SP - Special Proceedings
2. JA - Juvenile Abuse/Neglect/Dependency
3. JB - Juvenile Delinquency
4. JT - Juvenile Termination of Parental Rights
5. JR - Judicial Review - Responsible individuals list
6. JW - Judicial Waiver
7. JE - Emancipation
8. EO - Estate Other
9. CR - Criminal District
10. IF - Infraction

### Two digit case output format
1. Two digit year: 00 XX 000000
2. Four digit year: 0000 XX 000000

### Three digit case types
1. CVD - Civil District
2. CVS - Civil Superior
3. CRS - Criminal Superior
4. CVM - Civil District - Magistrate Division
5. CVR - Civil Revocation

### Three digit case output format
1. Two digit year: 00 XXX 000000
2. Four digit year: 0000 XXX 000000

# Package Install
Add nuget package to project by using the nuget package manager UI. Add:
```
MoleculeSoftware.Packages.CaseNumberParser.Core
```
or from the dotnet CLI use the command:
```
dotnet add package MoleculeSoftware.Packages.CaseNumberParser.Core
```

# Usage
1. Import the appropriate namespace

```C#
using CaseNumberParser;
```

2. Use the ParseEngine to parse your case number

```C#
public void SomeFunction(string caseNumber)
{
    // ... other logic

    // Parse Case Number

    // NOTES:
    If a case number fails to parse you will receive an empty string in response. This method handles all exceptions by returning an empty string. Please see the formatting requirements below to achieve proper parsing. 
    var parsedCaseNumber = ParseEngine.ReturneParsed(caseNumber, CaseNumberFormat.TwoDigitCaseType, YearFormat.TwoDigit); 

    // ... other logic
}
```

# Pre-Parse format requirements
1. Case number must at least have a two digit year at positions 0 and 1 of the string's char[]. Optionally, the developer can use the full year, Ex: 2023, instead of a two digit year, Ex. 23. In this case the four digit year will be at positions 0-3 of the string's char[]. 
2. A single space after the case number at either position 2 or position 4. 
3. When calling the ParseEngine.ReturnParsed method you will specify the expected input year format. 
4. NOTE: The year section of a case number requires proper input to function properly. Any deviation from the two or four digit year will result in a failed parse. 
5. Case type must at least contain a single digit at positions 3 or position 5. The case type can contain up to three digits depending on the case type. 
6. A single space after the case type at either position 4, 5, or 6 for two digit year formats. or 6, 7, or 8 for four digit year formats. 
7. Case type will automatically correct for character casing. Therefore, if the input for case type is "aa" it will be corrected to "AA" after parsing. 
8. Case sequence must contain at least a single integer digit at positions 5, 6, or 7 for two digit year types, or 7, 8, or 9 for four digit year types. 
9. Case sequence supports up to 999,999 cases within a specific type. It is highly unlikely that this ceiling will ever be reached within a single year in any of the 100 N.C. counties. 
10. Case sequence will be parsed as follows. Examples are not exhaustive
    1.  Ex: 00 AA 1 parses to 00 AA 000001
    2.  Ex: 00 A 01 parses to 00 A 000001
    3.  Ex: 00 CVD 2715 parses to 00 CVD 002715
    4.  Ex: 23 ja 27 parses to 23 JA 000027
    5.  Ex: 1 ja 27 parses to an empty string because case year is invalid. 
    6.  Ex: 23  ja 27 parses to an empty string because an extra space exists between the case year and case type sections. 
    7.  Ex: 23 JA parses to an empty string because the sequence is missing. 
