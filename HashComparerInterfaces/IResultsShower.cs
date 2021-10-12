namespace HashComparerInterfaces
{//может, и не нужен
    public interface IResultsShower
    {
        void Show(IEnumerable<string> matchingFiles);
    }
}