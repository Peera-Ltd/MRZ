using MRZParser.Models;

namespace MRZParser.Services
{
    public class MRVBParser : IParser
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