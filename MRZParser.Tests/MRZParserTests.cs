using MRZParser.Constants;
using Xunit;

namespace MRZParser.Tests
{
    public class MRZParserTests
    {
        [Theory(DisplayName = "Parse should determine the format of the MRZ and call it's corresponding parse class")]
        [InlineData(MRZSamples.TD1, "Other")]
        [InlineData(MRZSamples.TD2, "Other")]
        [InlineData(MRZSamples.TD3, "Passport")]
        [InlineData(MRZSamples.MRVA, "Visa")]
        [InlineData(MRZSamples.MRVB, "Visa")]
        [InlineData("An Invalid MRZ", null)]
        public void MRZParser_ShouldParseAGivenMRZ(string mrz, string expectedResult)
        {
            // Act
            var result = MRZParser.Parse(mrz);

            // Assert
            Assert.True(result?.DocumentType == expectedResult);
        }
    }
}