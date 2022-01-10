using MRZ.Models;

namespace MRZ.Services
{
    public interface IParser
    {
        public MRZModel Parse(string mrz);
    }
}