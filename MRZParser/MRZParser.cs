using MRZParser.Exceptions;
using MRZParser.Models;
using MRZParser.Services;

namespace MRZParser
{
    public abstract class MRZParser
    {
        /// <summary>
        /// Supports the following MRZ Formats: TD1, TD2, TD3, MRVA, MRVB.
        /// </summary>
        /// <param name="mrz">An MRZ string which should be of length: 90, 72 or 88 without whitespace.</param>
        /// <returns>An MRZ model.</returns>
        public static MRZModel Parse(string mrz)
        {
            return DetermineMRZFormat(mrz) switch
            {
                MRZFormat.TD1 => new TD1Parser().Parse(mrz),
                MRZFormat.TD2 => new TD2Parser().Parse(mrz),
                MRZFormat.TD3 => new TD3Parser().Parse(mrz),
                _ => throw new UnsupportedMRZException(
                    "The given MRZ is not supported. This project supports MRZ of length 90, 88 or 72." +
                    $"The given MRZ was of length {mrz.Length}. MRZ: {mrz}")
            };
        }

        private static MRZFormat DetermineMRZFormat(string mrz)
        {
            return mrz.Length switch
            {
                90 => MRZFormat.TD1,
                72 => MRZFormat.TD2,
                88 => MRZFormat.TD3,
                _ => MRZFormat.Error
            };
        }
    }
}