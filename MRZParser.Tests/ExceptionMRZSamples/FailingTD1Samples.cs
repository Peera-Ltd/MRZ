namespace MRZParser.Tests.ExceptionMRZSamples
{
    public static class FailingTD1Samples
    {
        public static string TD1DocumentNumber = "I<UTOD231458907QWERTQWERTQWERT" +
                                                 "7408122F1204159UTO<<<<<<<<<<<6" +
                                                 "ERIKSSON<<ANNA<MARIA<<<<<<<<<<";

        public static string TD1DocumentType { get; } = Constants.MRZSamples.TD1.Replace("I", "Q");

        public static string TD1FirstName { get; } = Constants.MRZSamples.TD1.Replace("<<", "QQ");

        public static string TD1LastName { get; } = Constants.MRZSamples.TD1.Replace("<<", "QQ");
    }
}