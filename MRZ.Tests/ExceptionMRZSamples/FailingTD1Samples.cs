using MRZ.Tests.Constants;

namespace MRZ.Tests.ExceptionMRZSamples
{
    public static class FailingTD1Samples
    {
        public static string TD1DocumentType { get; } = MRZSamples.TD1.Replace("I", "Q");

        public static string TD1FirstName { get; } = MRZSamples.TD1.Replace(
            "ERIKSSON<<ANNA<MARIA<<<<<<<<<<",
            "ERIKSSON<ANNA<MARIA<0123456789");

        public static string TD1LastName { get; } = MRZSamples.TD1.Replace(
            "ERIKSSON<<ANNA<MARIA<<<<<<<<<<",
            "ERIKSSON<<ANNA<MARIA<123456789");

        public static string TD1DocumentNumber { get; } = MRZSamples.TD1.Replace(
            "<<<<<<<<<<<<<<<",
            "QWERTQWERTQWERT");

        public static string TD1DateOfBirth { get; } = MRZSamples.TD1.Replace("740812", "Q<9999");
    }
}