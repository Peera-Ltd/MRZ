namespace MRZParser.Tests.ExceptionMRZSamples
{
    public static class FailingTD2Samples
    {
        public static string TD2DocumentType { get; } = Constants.MRZSamples.TD2.Replace("I", "Q");

        public static string TD2FirstName { get; } = Constants.MRZSamples.TD2.Replace("<<", "QQ");

        public static string TD2LastName { get; } = Constants.MRZSamples.TD2.Replace("<<", "QQ");
    }
}