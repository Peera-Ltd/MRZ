using System;
using System.Linq;
using MRZParser.Models;
using MRZParser.Services;
using MRZParser.Tests.Helpers;
using Xunit;

namespace MRZParser.Tests.Services
{
    public class TD1ParserTests
    {
        private readonly TD1Parser _subject = new ();

        private const string mrz = MRZSamples.TD1;

        private readonly MRZModel expectedModel = new ()
        {
            DocumentType = "Other",
            CountryCode = "UTO",
            DocumentNumber = "D23145890",
            DateOfBirth = new DateTime(1974, 08, 12),
            Sex = "Female",
            ExpiryDate = new DateTime(2012, 04, 15),
            Nationality = "UTO",
            LastName = "ERIKSSON",
            FirstName = "ANNA MARIA",
        };

        [Fact(DisplayName = "Document Type should be 'Other'")]
        public void Test_ParseTD1Mrz_ReturnsCorrectDocumentType()
        {
            // Act
            var result = _subject.Parse(mrz);
            
            // Assert
            Assert.True(expectedModel.DocumentType == result.DocumentType);
        }
        
        [Fact(DisplayName = "Document Type should be 'UTO'")]
        public void Test_ParseTD1Mrz_ReturnsCorrectCountryCode()
        {
            // Act
            var result = _subject.Parse(mrz);
            
            // Assert
            Assert.True(expectedModel.CountryCode == result.CountryCode);
        }
        
        [Fact(DisplayName = "Document Number should be 'D23145890'")]
        public void Test_ParseTD1Mrz_ReturnsCorrectDocumentNumber()
        {
            // Act
            var result = _subject.Parse(mrz);
            
            // Assert
            Assert.True(expectedModel.DocumentNumber == result.DocumentNumber);
        }
        
        [Fact(DisplayName = "Date Of Birth should be '12 August 1974'")]
        public void Test_ParseTD1Mrz_ReturnsCorrectDateOfBirth()
        {
            // Act
            var result = _subject.Parse(mrz);
            
            // Assert
            Assert.True(expectedModel.DateOfBirth == result.DateOfBirth);
        }
        
        [Theory(DisplayName = "Sex should return the correct sex")]
        [InlineData(MRZSamples.TD1, "Female")]
        [InlineData("I<UTOD231458907<<<<<<<<<<<<<<<" + 
                    "7408122M1204159UTO<<<<<<<<<<<6" +
                    "ERIKSSON<<ANNA<MARIA<<<<<<<<<<", "Male")]
        [InlineData("I<UTOD231458907<<<<<<<<<<<<<<<" + 
                    "7408122X1204159UTO<<<<<<<<<<<6" +
                    "ERIKSSON<<ANNA<MARIA<<<<<<<<<<", "Undefined")]
        public void Test_ParseTD1Mrz_ReturnsCorrectSex(string mrzWithDifferentSex, string sex)
        {
            // Act
            var result = _subject.Parse(mrzWithDifferentSex);
            
            // Assert
            Assert.True(sex == result.Sex);
        }
        
        [Fact(DisplayName = "Expiry Date should be '15 April 2012'")]
        public void Test_ParseTD1Mrz_ReturnsExpiryDate()
        {
            // Act
            var result = _subject.Parse(mrz);
            
            // Assert
            Assert.True(expectedModel.ExpiryDate == result.ExpiryDate);
        }
        
        [Fact(DisplayName = "Nationality should be 'UTO'")]
        public void Test_ParseTD1Mrz_ReturnsNationality()
        {
            // Act
            var result = _subject.Parse(mrz);
            
            // Assert
            Assert.True(expectedModel.Nationality == result.Nationality);
        }
        
        [Fact(DisplayName = "Last Name should be 'ERIKSSON'")]
        public void Test_ParseTD1Mrz_ReturnsLastName()
        {
            // Act
            var result = _subject.Parse(mrz);
            
            // Assert
            Assert.True(expectedModel.LastName == result.LastName);
        }
        
        [Fact(DisplayName = "First Name should be 'ANNA MARIA'")]
        public void Test_ParseTD1Mrz_ReturnsFirstName()
        {
            // Act
            var result = _subject.Parse(mrz);
            
            // Assert
            Assert.True(expectedModel.FirstName == result.FirstName);
        }
    }
}