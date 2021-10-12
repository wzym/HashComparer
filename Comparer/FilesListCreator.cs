using HashComparerInterfaces;

namespace HashComparer
{
    public class FilesListCreator : IFilesListCreator
    {
        private readonly IArgsStorage _argsStorage;

        public FilesListCreator(IArgsStorage argsStorage)
        {
            _argsStorage = argsStorage;
        }

        public IEnumerable<FileInfo> GetFiles()
        {
            if (File.Exists(_argsStorage.StartPath))//TODO check while the parameters are parsed
                return new[] {new FileInfo(_argsStorage.StartPath)};
            
            var files = Directory.GetFiles(_argsStorage.StartPath, "*.*", SearchOption.AllDirectories)
                .Select(p => new FileInfo(p))
                .ToArray();

            return files;
        }
    }
}