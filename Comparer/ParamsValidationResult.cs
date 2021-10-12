using HashComparerInterfaces;

namespace HashComparer
{
    public record ParamsValidationResult : IParamsValidationResult
    {
        public bool IsStartPathValid { get; init; }

        public bool IsComparedHashValid { get; init; }

        public bool IsHashTypeValid { get; init; }
    }
}