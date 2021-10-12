namespace HashComparerInterfaces
{
    public interface IArgsStorage
    {
        string ComparedHash { get; }
        string StartPath { get; }
        SupportedHashAlgorithms HashType { get; }
        IParamsValidationResult ValidationResult { get; }
        bool TryParse(string comparedHash, string startPath, string hashType);
    }
}