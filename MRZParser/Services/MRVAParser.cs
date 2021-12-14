using MRZParser.Models;

namespace MRZParser.Services
{
    public class MRVAParser : IParser
    {
        public MRZModel Parse(string mrz)
        {
            return new MRZModel
            {
                DocumentType = "Visa"
            };
        }
    }
}