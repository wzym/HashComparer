﻿using HashComparerInterfaces;
using System.Security.Cryptography;

namespace HashComparer
{
    internal class Sha256HashChecker : HashChecker
    {
        private readonly SHA256 _algorithm = SHA256.Create();
        protected override HashAlgorithm Algorithm => _algorithm;

        public Sha256HashChecker(IArgsStorage argsStorage, IFilesListCreator filesListCreator) : 
            base(argsStorage, filesListCreator) { }
    }
}