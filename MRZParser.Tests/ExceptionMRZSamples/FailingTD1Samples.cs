namespace MRZParser.Tests.ExceptionMRZSamples
{
    public static class FailingTD1Samples
    {
        public static string TD1DocumentType { get; } = Constants.MRZSamples.TD1.Replace("I", "Q");

        public static string TD1FirstName { get; } = Constants.MRZSamples.TD1.Replace("<<", "QQ");

        public static string TD1LastName { get; } = Constants.MRZSamples.TD1.Replace("<<", "QQ");

        public static string TD1DocumentNumber { get; } = Constants.MRZSamples.TD1.Replace(
            "<<<<<<<<<<<<<<<", "QWERTQWERTQWERT");

        public static string TD1DateOfBirth { get; } = Constants.MRZSamples.TD1.Replace("740812", "Q<9999");
    }
}