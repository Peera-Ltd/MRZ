using System;
using System.Collections.Generic;
using System.Linq;
using MRZParser.Constants;

namespace MRZParser
{
    public class Program
    {
        private static void Main()
        {
            var samples = new List<string>
            {
                MRZSamples.TD1,
                MRZSamples.TD2,
                MRZSamples.TD3,
                MRZSamples.MRVA,
                MRZSamples.MRVB,
            };

            foreach (var model in samples.Select(MRZParser.Parse))
            {
                Console.WriteLine($"Document Type: {model?.DocumentType}");
                Console.WriteLine($"Country Code: {model?.CountryCode}");
                Console.WriteLine($"Document Number: {model?.DocumentNumber}");
                Console.WriteLine($"Date of Birth: {model?.DateOfBirth}");
                Console.WriteLine($"Sex: {model?.Sex}");
                Console.WriteLine($"Expiry Date: {model?.ExpiryDate}");
                Console.WriteLine($"Last Name: {model?.LastName}");
                Console.WriteLine($"First Name: {model?.FirstName}");
                Console.WriteLine();
            }
        }
    }
}