using System;
using MRZParser.Exceptions;
using MRZParser.Models;

namespace MRZParser.Services
{
    // TODO: - Needs some exception handling

    /// <summary>
    /// TD1 Format has 3 lines of 30 characters.
    /// </summary>
    public class TD1Parser : BaseParser
    {
        public override MRZModel Parse(string mrz)
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
                FirstName = FirstName(mrz),
            };
        }

        protected override string DocumentType(string mrz)
            => mrz[0] is 'A' or 'C' or 'I'
                ? "Other"
                : throw new UnsupportedMRZException(
                    $"A TD1 (3 lines of 30 characters) MRZ should start with either A, C or I, but it was {mrz[0]}.");

        protected override string? DocumentNumber(string mrz)
        {
            var potentialDocNumber = mrz[5..].Split('<')[0];
            if (potentialDocNumber.Length <= 9)
            {
                return potentialDocNumber;
            }

            var docNumber = potentialDocNumber.Remove(potentialDocNumber.Length - 1);
            return docNumber.Length <= 9 ? docNumber : null;
        }

        protected override DateTime? DateOfBirth(string mrz)
            => ParseDate($"{mrz[34]}{mrz[35]}", $"{mrz[32]}{mrz[33]}", $"{mrz[30]}{mrz[31]}");

        protected override string Sex(string mrz)
        {
            return mrz[37] switch
            {
                'F' => "Female",
                'M' => "Male",
                _ => "Other"
            };
        }

        protected override DateTime? ExpiryDate(string mrz)
            => ParseDate($"{mrz[42]}{mrz[43]}", $"{mrz[40]}{mrz[41]}", $"{mrz[38]}{mrz[39]}");

        protected override string Nationality(string mrz) => $"{mrz[45]}{mrz[46]}{mrz[47]}";

        protected override string LastName(string mrz)
        {
            try
            {
                var lastName = mrz[60..].Split("<<")[0];
                return lastName.Replace("<", " ");
            }
            catch (Exception e)
            {
                throw new UnsupportedMRZException(
                    "Could not parse a Last Name from the MRZ. The given MRZ may be invalid." +
                    " The pattern '<<' is required in order to find a Last Name." +
                    $" The given MRZ was {mrz}. Inner exception: ", e);
            }
        }

        protected override string FirstName(string mrz)
        {
            try
            {
                var firstName = mrz[60..]
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
    }
}