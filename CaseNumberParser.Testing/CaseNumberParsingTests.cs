using Xunit;

namespace CaseNumberParser.Testing;

public class CaseNumberParsingTests
{
    [Fact]
    public void TestTwoDigitYearOneDigitCaseType()
    {
        Assert.Equal("08 M 000114", ParseEngine.ReturnParsed(CreateMockValidCaseNumber(YearFormat.TwoDigit, CaseNumberFormat.OneDigitCaseType), CaseNumberFormat.OneDigitCaseType, YearFormat.TwoDigit));
        Assert.Equal(string.Empty, ParseEngine.ReturnParsed(CreateMockInvalidCaseNumber(YearFormat.TwoDigit, CaseNumberFormat.OneDigitCaseType), CaseNumberFormat.OneDigitCaseType, YearFormat.TwoDigit));
    }

    [Fact]
    public void TestTwoDigitYearTwoDigitCaseType()
    {
        Assert.Equal("15 JA 000615", ParseEngine.ReturnParsed(CreateMockValidCaseNumber(YearFormat.TwoDigit, CaseNumberFormat.TwoDigitCaseType), CaseNumberFormat.TwoDigitCaseType, YearFormat.TwoDigit)); 
        Assert.Equal(string.Empty, ParseEngine.ReturnParsed(CreateMockInvalidCaseNumber(YearFormat.TwoDigit, CaseNumberFormat.TwoDigitCaseType), CaseNumberFormat.TwoDigitCaseType, YearFormat.TwoDigit)); 
    }

    [Fact]
    public void TestTwoDigitYearThreeDigitCaseType()
    {
        Assert.Equal("19 CVM 000441", ParseEngine.ReturnParsed(CreateMockValidCaseNumber(YearFormat.TwoDigit, CaseNumberFormat.ThreeDigitCaseType), CaseNumberFormat.ThreeDigitCaseType, YearFormat.TwoDigit)); 
        Assert.Equal(string.Empty, ParseEngine.ReturnParsed(CreateMockInvalidCaseNumber(YearFormat.TwoDigit, CaseNumberFormat.ThreeDigitCaseType), CaseNumberFormat.ThreeDigitCaseType, YearFormat.TwoDigit)); 

    }

    [Fact]
    public void TestFourDigitYearOneDigitCaseType()
    {
        Assert.Equal("2008 M 000114", ParseEngine.ReturnParsed(CreateMockValidCaseNumber(YearFormat.FourDigit, CaseNumberFormat.OneDigitCaseType), CaseNumberFormat.OneDigitCaseType, YearFormat.FourDigit)); 
        Assert.Equal(string.Empty, ParseEngine.ReturnParsed(CreateMockInvalidCaseNumber(YearFormat.FourDigit, CaseNumberFormat.OneDigitCaseType), CaseNumberFormat.OneDigitCaseType, YearFormat.FourDigit)); 
    }

    [Fact]
    public void TestFourDigitYearTwoDigitCaseType()
    {
        Assert.Equal("2015 JA 000615", ParseEngine.ReturnParsed(CreateMockValidCaseNumber(YearFormat.FourDigit, CaseNumberFormat.TwoDigitCaseType), CaseNumberFormat.TwoDigitCaseType, YearFormat.FourDigit)); 
        Assert.Equal(string.Empty, ParseEngine.ReturnParsed(CreateMockInvalidCaseNumber(YearFormat.FourDigit, CaseNumberFormat.TwoDigitCaseType), CaseNumberFormat.TwoDigitCaseType, YearFormat.FourDigit)); 
    }

    [Fact]
    public void TestFourDigitYearThreeDigitCaseType()
    {
        Assert.Equal("2019 CVM 000441", ParseEngine.ReturnParsed(CreateMockValidCaseNumber(YearFormat.FourDigit, CaseNumberFormat.ThreeDigitCaseType), CaseNumberFormat.ThreeDigitCaseType, YearFormat.FourDigit)); 
        Assert.Equal(string.Empty, ParseEngine.ReturnParsed(CreateMockInvalidCaseNumber(YearFormat.FourDigit, CaseNumberFormat.ThreeDigitCaseType), CaseNumberFormat.ThreeDigitCaseType, YearFormat.FourDigit)); 
    }

    [Fact]
    public void TestInvalidStringAgainstParser()
    {
        Assert.Equal(string.Empty, ParseEngine.ReturnParsed(CreateMockBadlyMalformedCaseNumber(), CaseNumberFormat.OneDigitCaseType, YearFormat.TwoDigit));
        Assert.Equal(string.Empty, ParseEngine.ReturnParsed(CreateMockBadlyMalformedCaseNumber(), CaseNumberFormat.TwoDigitCaseType, YearFormat.TwoDigit));
        Assert.Equal(string.Empty, ParseEngine.ReturnParsed(CreateMockBadlyMalformedCaseNumber(), CaseNumberFormat.ThreeDigitCaseType, YearFormat.TwoDigit));
        Assert.Equal(string.Empty, ParseEngine.ReturnParsed(CreateMockBadlyMalformedCaseNumber(), CaseNumberFormat.OneDigitCaseType, YearFormat.FourDigit));
        Assert.Equal(string.Empty, ParseEngine.ReturnParsed(CreateMockBadlyMalformedCaseNumber(), CaseNumberFormat.TwoDigitCaseType, YearFormat.FourDigit));
        Assert.Equal(string.Empty, ParseEngine.ReturnParsed(CreateMockBadlyMalformedCaseNumber(), CaseNumberFormat.ThreeDigitCaseType, YearFormat.FourDigit));
    }

    private string CreateMockValidCaseNumber(YearFormat yearFormat, CaseNumberFormat caseTypeFormat)
    {
        if(yearFormat == YearFormat.TwoDigit)
        {
            switch (caseTypeFormat)
            {
                case CaseNumberFormat.OneDigitCaseType:
                    return "08 M 114";
                case CaseNumberFormat.TwoDigitCaseType:
                    return "15 JA 615";
                case CaseNumberFormat.ThreeDigitCaseType:
                    return "19 CVM 441";
                default:
                    return string.Empty; 
            }
        }
        else
        {
            switch (caseTypeFormat)
            {
                case CaseNumberFormat.OneDigitCaseType:
                    return "2008 M 114";
                case CaseNumberFormat.TwoDigitCaseType:
                    return "2015 JA 615";
                case CaseNumberFormat.ThreeDigitCaseType:
                    return "2019 CVM 441";
                default:
                    return string.Empty; 
            }
        }
    }

    private string CreateMockInvalidCaseNumber(YearFormat yearFormat, CaseNumberFormat caseTypeFormat)
    {
        if(yearFormat != YearFormat.TwoDigit)
        {
            switch (caseTypeFormat)
            {
                case CaseNumberFormat.OneDigitCaseType:
                    return "08 MM 114";
                case CaseNumberFormat.TwoDigitCaseType:
                    return "15 CVM 615";
                case CaseNumberFormat.ThreeDigitCaseType:
                    return "19 M 441";
                default:
                    return string.Empty; 
            }
        }
        else
        {
            switch (caseTypeFormat)
            {
                case CaseNumberFormat.OneDigitCaseType:
                    return "20085 R 11";
                case CaseNumberFormat.TwoDigitCaseType:
                    return "JA 16";
                case CaseNumberFormat.ThreeDigitCaseType:
                    return "2015 R"; 
                default:
                    return string.Empty; 
            }
        }
    }

    private string CreateMockBadlyMalformedCaseNumber()
    {
        Random rdm = new Random(0);
        var randomValue = rdm.Next(0, 8);
        switch (randomValue)
        {
            case 0:
                return "asdflkjakls;djoifpfjekljaa;ksldjfkl";
            case 1:
                return "";
            case 3:
                return "10    14";
            case 4:
                return "JA 221";
            case 5:
                return "225";
            case 6:
                return "          ";
            case 7:
                return "114 JA 21";
            case 8:
                return "1"; 
            default:
                return string.Empty;
        }
    }
}
