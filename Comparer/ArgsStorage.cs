using HashComparerInterfaces;

namespace HashComparer
{
    public class ArgsStorage : IArgsStorage
    {
        private readonly IParametersParser _parser;

        public string ComparedHash { get; private set; } = string.Empty;
        public string StartPath { get; private set; } = string.Empty;
        public SupportedHashAlgorithms HashType { get; private set; } = SupportedHashAlgorithms.NotDefined;
        public IParamsValidationResult ValidationResult { get; private set; } = new ParamsValidationResult();

        public ArgsStorage(IParametersParser parser)
        {
            _parser = parser;
        }               

        public bool TryParse(string comparedHash, string startPath, string hashType)
        {
            (var isHashTypeValid, HashType) = _parser.ParseHashType(hashType);
            (var isHashValid, ComparedHash) = _parser.ParseHashString(comparedHash, HashType);
            (var isPathValid, StartPath) = _parser.ParseStartPath(startPath);
            ValidationResult = new ParamsValidationResult
            {
                IsComparedHashValid = isHashValid,
                IsStartPathValid = isPathValid,
                IsHashTypeValid = isHashTypeValid
            };

            return ValidationResult.AreAllParametersValid();
        }
    }
}