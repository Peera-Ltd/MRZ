using System;
using System.Globalization;
using MRZParser.Models;

namespace MRZParser.Services
{
    // TODO: - Needs some exception handling
    
    /// <summary>
    /// TD1 Format has 3 lines of 30 characters
    /// </summary>
    public class TD1Parser : IParser
    {
        public MRZModel Parse(string mrz)
        {
            return new MRZModel
            {
                DocumentType = DocumentType(mrz),
                CountryCode = CountryCode(mrz),
                DocumentNumber = DocumentNumber(mrz),
                DateOfBirth = DateOfBirth(mrz),
                Sex = Sex(mrz),
                ExpiryDate = ExpiryDate(mrz),
                Nationality = Nationality(mrz),
                LastName = LastName(mrz),
                FirstName = FirstName(mrz)
            };
        }

        // The second character can also be part of the doc type, but I don't know if I want to do anything with it.
        private static string? DocumentType(string mrz) => mrz[0] is 'A' or 'C' or 'I' ? "Other" : null;

        // Could potentially parse a list of country codes and return a string.
        private static string CountryCode(string mrz) => $"{mrz[2]}{mrz[3]}{mrz[4]}";

        private static string? DocumentNumber(string mrz)
        {
            var potentialDocNumber = mrz[5..].Split('<')[0];
            if (potentialDocNumber.Length <= 9)
            {
                return potentialDocNumber;
            }
            
            var docNumber = potentialDocNumber.Remove(potentialDocNumber.Length - 1);
            return docNumber.Length <= 9 ? docNumber : null;
        }
        
        private static DateTime? DateOfBirth(string mrz)
            => ParseDate($"{mrz[34]}{mrz[35]}", $"{mrz[32]}{mrz[33]}", $"{mrz[30]}{mrz[31]}");

        private static string Sex(string mrz)
        {
            return (mrz[37]) switch
            {
                'F' => "Female",
                'M' => "Male",
                _ => "Undefined"
            };
        }

        private static DateTime? ExpiryDate(string mrz) 
            => ParseDate($"{mrz[42]}{mrz[43]}", $"{mrz[40]}{mrz[41]}", $"{mrz[38]}{mrz[39]}");

        private static string Nationality(string mrz) => $"{mrz[45]}{mrz[46]}{mrz[47]}";
        
        private static string LastName(string mrz)
        {
            var lastName = mrz[60..].Split("<<")[0];
            return lastName.Replace("<", " ");
        }

        private static string FirstName(string mrz)
        {
            var firstName = mrz[60..]
                .Split("<<")[1]
                .Split("<<")[0];

            return firstName.Replace("<", " ");
        }
        
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