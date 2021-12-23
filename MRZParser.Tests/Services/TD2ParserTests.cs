using System;
using MRZParser.Constants;
using MRZParser.Exceptions;
using MRZParser.Models;
using MRZParser.Services;
using MRZParser.Tests.ExceptionMRZSamples;
using Xunit;

namespace MRZParser.Tests.Services
{
    public class TD2ParserTests
    {
        private const string Mrz = MRZSamples.TD2;

        private const string InvalidSexMaleMrz = "I<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<" +
                                                 "D231458907UTO7408122M1204159<<<<<<<6";

        private const string InvalidSexOtherMrz = "I<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<" +
                                                  "D231458907UTO7408122X1204159<<<<<<<6";

        private readonly TD2Parser _subject = new ();

        private readonly MRZModel expectedModel = new ()
        {
            DocumentType = "Other",
            CountryCode = "UTO",
            LastName = "ERIKSSON",
            FirstName = "ANNA MARIA",
            DocumentNumber = "D23145890",
            DateOfBirth = new DateTime(1974, 08, 12),
            Sex = "Female",
            ExpiryDate = new DateTime(2012, 04, 15),
            Nationality = "UTO",
        };

        #region DocumentType

        [Fact(DisplayName = "Document Type should be 'Other'")]
        public void Test_ParseTD2Mrz_ReturnsCorrectDocumentType()
        {
            // Act
            var result = _subject.Parse(Mrz);

            // Assert
            Assert.True(expectedModel.DocumentType == result.DocumentType);
        }

        [Fact(DisplayName = "Document Type should throw UnsupportedMRZException when an invalid MRZ is passed")]
        public void Test_ParseTD2Mrz_DocumentTypeThrowsException()
        {
            try
            {
                // Act
                _subject.Parse(FailingTD2Samples.TD2DocumentType);
            }
            catch (Exception e)
            {
                // Assert
                Assert.IsType<UnsupportedMRZException>(e);
            }
        }

        #endregion

        [Fact(DisplayName = "Country Code should be 'UTO'")]
        public void Test_ParseTD2Mrz_ReturnsCorrectCountryCode()
        {
            // Act
            var result = _subject.Parse(Mrz);

            // Assert
            Assert.True(expectedModel.CountryCode == result.CountryCode);
        }

        #region LastName

        [Fact(DisplayName = "Last Name should be 'ERIKSSON'")]
        public void Test_ParseTD2Mrz_ReturnsLastName()
        {
            // Act
            var result = _subject.Parse(Mrz);

            // Assert
            Assert.True(expectedModel.LastName == result.LastName);
        }

        [Fact(DisplayName = "Last Name should throw an UnsupportedMRZException")]
        public void Test_ParseTD2Mrz_LastNameThrowsException()
        {
            try
            {
                // Act
                _subject.Parse(FailingTD2Samples.TD2LastName);
            }
            catch (Exception e)
            {
                // Assert
                Assert.IsType<UnsupportedMRZException>(e);
            }
        }

        #endregion

        #region FirstName

        [Fact(DisplayName = "First Name should be 'ANNA MARIA'")]
        public void Test_ParseTD2Mrz_ReturnsFirstName()
        {
            // Act
            var result = _subject.Parse(Mrz);

            // Assert
            Assert.True(expectedModel.FirstName == result.FirstName);
        }

        [Fact(DisplayName = "First Name should throw an UnsupportedMRZException")]
        public void Test_ParseTD2Mrz_FirstNameThrowsException()
        {
            try
            {
                // Act
                _subject.Parse(FailingTD2Samples.TD2FirstName);
            }
            catch (Exception e)
            {
                // Assert
                Assert.IsType<UnsupportedMRZException>(e);
            }
        }

        #endregion

        [Fact(DisplayName = "Document Number should be 'D23145890'")]
        public void Test_ParseTD2Mrz_ReturnsCorrectDocumentNumber()
        {
            // Act
            var result = _subject.Parse(Mrz);

            // Assert
            Assert.True(expectedModel.DocumentNumber == result.DocumentNumber);
        }

        [Fact(DisplayName = "Nationality should be 'UTO'")]
        public void Test_ParseTD2Mrz_ReturnsNationality()
        {
            // Act
            var result = _subject.Parse(Mrz);

            // Assert
            Assert.True(expectedModel.Nationality == result.Nationality);
        }

        [Fact(DisplayName = "Date Of Birth should be '12 August 1974'")]
        public void Test_ParseTD2Mrz_ReturnsCorrectDateOfBirth()
        {
            // Act
            var result = _subject.Parse(Mrz);

            // Assert
            Assert.True(expectedModel.DateOfBirth == result.DateOfBirth);
        }

        [Theory(DisplayName = "Sex should return the correct sex")]
        [InlineData(MRZSamples.TD2, "Female")]
        [InlineData(InvalidSexMaleMrz, "Male")]
        [InlineData(InvalidSexOtherMrz, "Other")]
        public void Test_ParseTD2Mrz_ReturnsCorrectSex(string mrzWithDifferentSex, string sex)
        {
            // Act
            var result = _subject.Parse(mrzWithDifferentSex);

            // Assert
            Assert.True(sex == result.Sex);
        }

        [Fact(DisplayName = "Expiry Date should be '15 April 2012'")]
        public void Test_ParseTD2Mrz_ReturnsExpiryDate()
        {
            // Act
            var result = _subject.Parse(Mrz);

            // Assert
            Assert.True(expectedModel.ExpiryDate == result.ExpiryDate);
        }
    }
}