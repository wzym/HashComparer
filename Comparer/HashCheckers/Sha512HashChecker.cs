using System.Security.Cryptography;
using HashComparerInterfaces;

namespace HashComparer
{
    internal class Sha512HashChecker : HashChecker
    {
        private readonly SHA512 _algorithm = SHA512.Create();
        protected override HashAlgorithm Algorithm => _algorithm;

        public Sha512HashChecker(IArgsStorage argsStorage, IFilesListCreator filesListCreator) : 
            base(argsStorage, filesListCreator) { }
    }
}