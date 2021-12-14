using System;
using MRZParser.Models;

namespace MRZParser.Services
{
    /// <summary>
    /// TD3 format has 2 lines of 44 characters.
    /// If the first character is a V, it is of MRV-A format.
    /// </summary>
    public class TD3Parser: BaseParser
    {
        public override MRZModel Parse(string mrz)
        {
            return new MRZModel
            {
                DocumentType = DocumentType(mrz),
                CountryCode = CountryCode(mrz),
                LastName = LastName(mrz),
                FirstName = FirstName(mrz),
                DocumentNumber = DocumentNumber(mrz),
                Nationality = Nationality(mrz),
                DateOfBirth = DateOfBirth(mrz),
                Sex = Sex(mrz),
                ExpiryDate = ExpiryDate(mrz),
            };
        }

        protected override string? DocumentType(string mrz)
        {
            return mrz[0] switch
            {
                'V' => "Visa",
                'P' => "Passport",
                _ => null
            };
        }
        
        protected override string DocumentNumber(string mrz)
        {
            var potentialDocNumber = mrz[44..53];
            return potentialDocNumber.Replace("<", "");
        }
        
        protected override string Nationality(string mrz) => $"{mrz[54]}{mrz[55]}{mrz[56]}";

        protected override DateTime? DateOfBirth(string mrz)
            => ParseDate($"{mrz[61]}{mrz[62]}", $"{mrz[59]}{mrz[60]}", $"{mrz[57]}{mrz[58]}");
        
        protected override string Sex(string mrz)
        {
            return (mrz[64]) switch
            {
                'F' => "Female",
                'M' => "Male",
                _ => "Other"
            };
        }
        
        protected override DateTime? ExpiryDate(string mrz) 
            => ParseDate($"{mrz[69]}{mrz[70]}", $"{mrz[67]}{mrz[68]}", $"{mrz[65]}{mrz[66]}");
    }
}