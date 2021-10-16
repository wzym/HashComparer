using HashComparerInterfaces;

namespace HashComparer
{
    public class ParametersParser : IParametersParser
    {
        public Tuple<bool, string> ParseHashString(string hash, SupportedHashAlgorithms hashType)
        {
            if (string.IsNullOrWhiteSpace(hash)) return Tuple.Create(false, string.Empty);

            // TODO maybe check number of not empty symbols specified for the hash type
            return Tuple.Create(true, hash);
        }

        /// <summary>
        /// Maybe add normalization: relative to absolute
        /// </summary>
        /// <param name="path"></param>
        /// <returns>(is valid, normalized absolute path)</returns>
        public Tuple<bool, string> ParseStartPath(string path)
        {
            if (File.Exists(path))
            {
                return Tuple.Create(true, path);
            }
            else if (Directory.Exists(path))
            {
                return Tuple.Create(true, path);
            }
            else
            {
                return Tuple.Create(false, string.Empty);
            }
        }

        public Tuple<bool, SupportedHashAlgorithms> ParseHashType(string hashType)
        {
            var parsedType = Identify(GetPreparedStringRepresentation(hashType));
            return Tuple.Create(parsedType != SupportedHashAlgorithms.NotDefined, parsedType);
            
            static string GetPreparedStringRepresentation(string hashTypeString)
            {
                var result = hashTypeString.Trim();
                result = result.ToLower();
                return result;
            }

            static SupportedHashAlgorithms Identify(string preparedStringRepresentation)
            {
                return preparedStringRepresentation switch
                {
                    Sha1HashChecker.NameRepresentation => SupportedHashAlgorithms.Sha1,
                    Sha256HashChecker.NameRepresentation => SupportedHashAlgorithms.Sha256,
                    Sha512HashChecker.NameRepresentation => SupportedHashAlgorithms.Sha512,
                    _ => SupportedHashAlgorithms.NotDefined
                };
            }
        }
    }
}