namespace HashComparerInterfaces
{
    public interface IFilesListCreator
    {
        IEnumerable<FileInfo> GetFiles();
    }
}