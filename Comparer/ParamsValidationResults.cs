using HashComparerInterfaces;

namespace HashComparer
{
    public record ParamsValidationResults : IParamsValidationResult
    {
        public bool IsStartPathValid { get; }
        public bool IsComparedHashValid { get; }
        public bool IsHashTypeValid { get; }
    }
}