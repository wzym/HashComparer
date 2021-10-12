using HashComparerInterfaces;
using System.Security.Cryptography;
using System.Text;

namespace HashComparer
{
    internal abstract class HashChecker : IHashChecker
    {
        private readonly string _comparedHash;
        private readonly IFilesListCreator _filesListCreator;
        protected abstract HashAlgorithm Algorithm { get; }

        protected HashChecker(IArgsStorage argsStorage, IFilesListCreator filesListCreator)
        {
            _comparedHash = argsStorage.ComparedHash;
            _filesListCreator = filesListCreator;
        }
        
        public IReadOnlyList<FileInfo> FindMatches()
        {
            // TO DO : -> linq (maybe)
            var files = _filesListCreator.GetFiles();
            var result = new List<FileInfo>();
            foreach(var file in files)
            {
                try
                {
                    var currentHash = GetCheckedHash(file);
                    if(string.Compare(currentHash, _comparedHash, StringComparison.Ordinal) == 0)
                        result.Add(file);
                }
                catch (Exception)
                {
                    // TO DO
                }
            }

            return result.ToArray();
        }

        private string GetCheckedHash(FileInfo file)
        {
            using var fs = file.Open(FileMode.Open);
            fs.Position = 0;
            var hashValue = Algorithm.ComputeHash(fs);
            return GetStringRepresentation(hashValue);
        }

        private static string GetStringRepresentation(IEnumerable<byte> hashValue)
        {
            var sb = new StringBuilder();
            foreach(var letter in hashValue)
                sb.Append(letter.ToString("X2"));

            return sb.ToString();
        }

        public void Dispose()
        {
            Algorithm.Dispose();
        }
    }
}