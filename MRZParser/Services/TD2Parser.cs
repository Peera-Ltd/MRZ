using System;
using System.Globalization;
using MRZParser.Models;

namespace MRZParser.Services
{
    /// <summary>
    /// TD2 Format has 2 lines of 36 characters
    /// </summary>
    public class TD2Parser : IParser
    {
        public MRZModel Parse(string mrz)
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
        
        private static string? DocumentType(string mrz) => mrz[0] is 'A' or 'C' or 'I' ? "Other" : null;
        
        private static string CountryCode(string mrz) => $"{mrz[2]}{mrz[3]}{mrz[4]}";

        private static string LastName(string mrz)
        {
            var lastName = mrz[5..].Split("<<")[0];
            return lastName.Replace("<", " ");
        }

        private static string FirstName(string mrz)
        {
            var firstName = mrz[5..]
                .Split("<<")[1]
                .Split("<<")[0];

            return firstName.Replace("<", " ");
        }
        
        private static string DocumentNumber(string mrz)
        {
            var potentialDocNumber = mrz[36..45];
            return potentialDocNumber.Replace("<", "");
        }
        
        private static string Nationality(string mrz) => $"{mrz[46]}{mrz[47]}{mrz[48]}";
        
        private static DateTime? DateOfBirth(string mrz)
            => ParseDate($"{mrz[53]}{mrz[54]}", $"{mrz[51]}{mrz[52]}", $"{mrz[49]}{mrz[50]}");

        private static string Sex(string mrz)
        {
            return (mrz[56]) switch
            {
                'F' => "Female",
                'M' => "Male",
                _ => "Undefined"
            };
        }
        
        private static DateTime? ExpiryDate(string mrz) 
            => ParseDate($"{mrz[61]}{mrz[62]}", $"{mrz[59]}{mrz[60]}", $"{mrz[57]}{mrz[58]}");

        private static DateTime? ParseDate(string day, string month, string year)
        {
            if (DateTime.TryParseExact(
                $"{day}/{month}/{year}",
                "dd/MM/yy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var expiryDate))
            {
                return expiryDate;
            }

            return null;
        }
    }
}