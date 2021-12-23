namespace MRZParser.Tests.ExceptionMRZSamples
{
    public static class FailingTD3Samples
    {
        public static string TD3DocumentType { get; } = Constants.MRZSamples.TD3.Replace("P", "Q");

        public static string TD3FirstName { get; } = Constants.MRZSamples.TD3.Replace("<<", "QQ");
    }
}