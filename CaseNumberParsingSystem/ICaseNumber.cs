namespace CaseNumberParsingSystem
{
    public interface ICaseNumber
    {
        int Year { get; set; }
        string CaseType { get; set; }
        int Sequence { get; set; }
    }
}
