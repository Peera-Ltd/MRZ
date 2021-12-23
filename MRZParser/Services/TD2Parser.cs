using System;
using MRZParser.Exceptions;
using MRZParser.Models;

namespace MRZParser.Services
{
    /// <summary>
    /// TD2 format has 2 lines of 36 characters.
    /// If the first character is a V, it is of MRV-B format.
    /// </summary>
    public class TD2Parser : BaseParser
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

        protected override string DocumentType(string mrz)
        {
            return mrz[0] switch
            {
                'V' => "Visa",
                'A' or 'C' or 'I' => "Other",
                _ => throw new UnsupportedMRZException(
                    $"A TD2 (2 lines of 36 characters) MRZ should start with either V, A, C or I, but it was {mrz[0]}.")
            };
        }

        protected override string DocumentNumber(string mrz)
        {
            var potentialDocNumber = mrz[36..45];
            return potentialDocNumber.Replace("<", string.Empty);
        }

        protected override string Nationality(string mrz) => $"{mrz[46]}{mrz[47]}{mrz[48]}";

        protected override DateTime? DateOfBirth(string mrz)
            => ParseDate($"{mrz[53]}{mrz[54]}", $"{mrz[51]}{mrz[52]}", $"{mrz[49]}{mrz[50]}");

        protected override string Sex(string mrz)
        {
            return mrz[56] switch
            {
                'F' => "Female",
                'M' => "Male",
                _ => "Other"
            };
        }

        protected override DateTime? ExpiryDate(string mrz)
            => ParseDate($"{mrz[61]}{mrz[62]}", $"{mrz[59]}{mrz[60]}", $"{mrz[57]}{mrz[58]}");
    }
}