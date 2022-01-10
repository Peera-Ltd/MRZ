using MRZ.Tests.Constants;
using Xunit;

namespace MRZ.Tests
{
    public class MRZTests
    {
        [Theory(DisplayName = "Parse should determine the format of the MRZ and call it's corresponding parse class")]
        [InlineData(MRZSamples.TD1, "Other")]
        [InlineData(MRZSamples.TD2, "Other")]
        [InlineData(MRZSamples.TD3, "Passport")]
        [InlineData(MRZSamples.MRVA, "Visa")]
        [InlineData(MRZSamples.MRVB, "Visa")]
        public void Parser_ShouldParseAGivenMRZ(string mrz, string expectedResult)
        {
            // Act
            var result = Parser.Parse(mrz);

            // Assert
            Assert.True(result.DocumentType == expectedResult);
        }
    }
}