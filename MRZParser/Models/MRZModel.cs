using System;

namespace MRZParser.Models
{
    public class MRZModel
    {
        public string? DocumentType { get; set; }

        public string? CountryCode { get; set; }

        public string? DocumentNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Sex { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Nationality { get; set; }
    }
}