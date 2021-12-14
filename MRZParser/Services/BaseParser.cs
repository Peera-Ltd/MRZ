using System;
using System.Globalization;
using MRZParser.Models;

namespace MRZParser.Services
{
    public class BaseParser : IParser
    {
        public virtual MRZModel Parse(string mrz)
        {
            throw new NotImplementedException();
        }
        
        protected static DateTime? ParseDate(string day, string month, string year)
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

        protected virtual string? DocumentType(string mrz)
        {
            throw new NotImplementedException();
        }

        protected static string CountryCode(string mrz) => $"{mrz[2]}{mrz[3]}{mrz[4]}";

        protected virtual string? DocumentNumber(string mrz)
        {
            throw new NotImplementedException();
        }
        
        protected virtual string FirstName(string mrz)
        {
            var firstName = mrz[5..]
                .Split("<<")[1]
                .Split("<<")[0];

            return firstName.Replace("<", " ");
        }
        
        protected virtual string LastName(string mrz)
        {
            var lastName = mrz[5..].Split("<<")[0];
            return lastName.Replace("<", " ");
        }
        
        protected virtual DateTime? DateOfBirth(string mrz)
        {
            throw new NotImplementedException();
        }
        
        protected virtual DateTime? ExpiryDate(string mrz)
        {
            throw new NotImplementedException();
        }
        
        protected virtual string Sex(string mrz)
        {
            throw new NotImplementedException();
        }
        
        protected virtual string? Nationality(string mrz)
        {
            throw new NotImplementedException();
        }
    }
}