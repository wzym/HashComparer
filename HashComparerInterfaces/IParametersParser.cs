namespace HashComparerInterfaces
{
    public interface IParametersParser
    {        
        Tuple<bool, SupportedHashAlgorithms> ParseHashType(string hashType);
        Tuple<bool, string> ParseHashString(string hash, SupportedHashAlgorithms hashType);
        Tuple<bool, string> ParseStartPath(string hashType);
    }

    public interface IParamsValidationResult
    {
        bool IsStartPathValid { get; }
        bool IsComparedHashValid { get; }
        bool IsHashTypeValid { get; }
    }

    public static class ParamsValidationResultExt
    {
        public static bool AreAllParametersValid(this IParamsValidationResult result)
        {
            return result.IsComparedHashValid
                && result.IsHashTypeValid
                && result.IsStartPathValid;
        }
    }
}