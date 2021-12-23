using System;
using System.Globalization;
using MRZParser.Exceptions;
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

        protected static string CountryCode(string mrz) => $"{mrz[2]}{mrz[3]}{mrz[4]}";

        protected virtual string DocumentType(string mrz)
        {
            throw new NotImplementedException();
        }

        protected virtual string? DocumentNumber(string mrz)
        {
            throw new NotImplementedException();
        }

        protected virtual string FirstName(string mrz)
        {
            try
            {
                var firstName = mrz[5..]
                    .Split("<<")[1]
                    .Split("<<")[0];

                return firstName.Replace("<", " ");
            }
            catch (Exception e)
            {
                throw new UnsupportedMRZException(
                    "Could not parse a First Name from the MRZ. The given MRZ may be invalid." +
                    " The pattern '<<' is required in order to find a First Name." +
                    $" The given MRZ was {mrz}. Inner exception: ", e);
            }
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

        protected virtual string Nationality(string mrz)
        {
            throw new NotImplementedException();
        }
    }
}