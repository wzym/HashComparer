namespace HashComparerInterfaces
{
    public interface IHashChecker : IDisposable
    {
        IReadOnlyList<FileInfo> FindMatches();
    }
}