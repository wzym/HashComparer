using HashComparerInterfaces;

namespace HashComparer
{
    internal class HashCheckerFactory : IHashCheckerFactory
    {
        private readonly IArgsStorage _argsStorage;
        private readonly IFilesListCreator _filesListCreator;

        public HashCheckerFactory(IArgsStorage argsStorage, IFilesListCreator filesListCreator)
        {
            _argsStorage = argsStorage;
            _filesListCreator = filesListCreator;
        }
        public IHashChecker GetHashChecker()
        {
            return _argsStorage.HashType switch
            {
                SupportedHashAlgorithms.Sha1 => new Sha1HashChecker(_argsStorage, _filesListCreator),
                SupportedHashAlgorithms.Sha256 => new Sha256HashChecker(_argsStorage, _filesListCreator),
                SupportedHashAlgorithms.Sha512 => new Sha512HashChecker(_argsStorage, _filesListCreator),
                SupportedHashAlgorithms.NotDefined => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}