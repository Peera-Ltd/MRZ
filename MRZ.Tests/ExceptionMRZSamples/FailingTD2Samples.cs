using MRZ.Tests.Constants;

namespace MRZ.Tests.ExceptionMRZSamples
{
    public static class FailingTD2Samples
    {
        public static string TD2DocumentType { get; } = MRZSamples.TD2.Replace("I", "Q");

        public static string TD2FirstName { get; } = MRZSamples.TD2.Replace("<<", "QQ");

        public static string TD2LastName { get; } = MRZSamples.TD2.Replace("<<", "QQ");
    }
}