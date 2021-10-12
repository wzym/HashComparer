namespace Interfaces
{
    internal interface IFilesListCreator
    {
        IEnumerable<string> GetFiles(string path);
    }
}