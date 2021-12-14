using System;
using System.Collections.Generic;
using System.Linq;
using MRZParser.Models;
using MRZParser.Tests.Helpers;

namespace MRZParser
{
    class Program
    {
        static void Main(string[] args)
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
                Console.WriteLine(model?.DocumentType);
                Console.WriteLine(model?.CountryCode);
                Console.WriteLine(model?.DocumentNumber);
                Console.WriteLine(model?.DateOfBirth);
                Console.WriteLine(model?.Sex);
                Console.WriteLine(model?.ExpiryDate);
                Console.WriteLine(model?.LastName);
                Console.WriteLine(model?.FirstName);
                Console.WriteLine();
            }
        }
    }
}