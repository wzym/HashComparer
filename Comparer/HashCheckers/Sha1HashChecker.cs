using HashComparerInterfaces;
using System.Security.Cryptography;

namespace HashComparer
{
    internal class Sha1HashChecker : HashChecker
    {
        private readonly SHA1 _algorithm = SHA1.Create();
        protected override HashAlgorithm Algorithm => _algorithm;

        internal const string NameRepresentation = "sha1";

        public Sha1HashChecker(IArgsStorage argsStorage, IFilesListCreator filesListCreator) : 
            base(argsStorage, filesListCreator) { }
    }
}