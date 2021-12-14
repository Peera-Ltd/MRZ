using System;
using MRZParser.Models;

namespace MRZParser.Services
{
    public interface IParser
    {
        public MRZModel Parse(string mrz);
    }
}