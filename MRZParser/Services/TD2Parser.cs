using MRZParser.Models;

namespace MRZParser.Services
{
    public class TD2Parser : IParser
    {
        public MRZModel Parse(string mrz)
        {
            return new MRZModel
            {
                DocumentType = "Other"
            };
        }
    }
}