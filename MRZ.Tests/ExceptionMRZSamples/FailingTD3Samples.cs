using MRZ.Tests.Constants;

namespace MRZ.Tests.ExceptionMRZSamples
{
    public static class FailingTD3Samples
    {
        public static string TD3DocumentType { get; } = MRZSamples.TD3.Replace("P", "Q");

        public static string TD3FirstName { get; } = MRZSamples.TD3.Replace("<<", "QQ");

        public static string TD3LastName { get; } = MRZSamples.TD3.Replace("<<", "QQ");
    }
}