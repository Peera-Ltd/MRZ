using System;
using MRZParser.Models;

namespace MRZParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = MRZParser.Parse(
                "IRGBRRJ01225888<<<<<<<<<<<<<<<" +
            "9011252M2109228IDN<<<<<<<<<<<0" +
            "LEWIS<LAIDIN<<<<<<<<<<<<<<<<<<");
            
            Console.WriteLine(model?.DocumentType);
            Console.WriteLine(model?.CountryCode);
            Console.WriteLine(model?.DocumentNumber);
            Console.WriteLine(model?.DateOfBirth);
            Console.WriteLine(model?.Sex);
            Console.WriteLine(model?.ExpiryDate);
            Console.WriteLine(model?.LastName);
            Console.WriteLine(model?.FirstName);
        }
    }
}