using MRZParser.Models;

namespace MRZParser.Services
{
    public class TD3Parser: IParser
    {
        public MRZModel Parse(string mrz)
        {
            return new MRZModel
            {
                DocumentType = "Passport"
            };
        }
    }
}