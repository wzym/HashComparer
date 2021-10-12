using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashComparerTests
{
    public class HashComparerTestsFixture
    {
        private const string _TEST_FILES_DIR = "testFiles";
        internal const string _SHA_256 = "sha256";
        internal const string _SHA_1 = "sha1";

        private readonly Dictionary<string, string> _testFiles;

        public HashComparerTestsFixture()
        {
            var testFilesDir = Path.Combine(Directory.GetCurrentDirectory(), _TEST_FILES_DIR);
            var files = Directory.GetFiles(testFilesDir);
            _testFiles = files.ToDictionary(
                keySelector: f => Path.GetFileNameWithoutExtension(f).ToLower(),
                elementSelector: f => f);
            var file = files.Where(f => Path.GetFileName(f) == "1").FirstOrDefault();
        }

        internal string GetTestFile()
        {            
            return _testFiles["1"];
        }

        internal string GetSha256(string filePath)
        {
            return File.ReadAllLines(_testFiles[_SHA_256])[0];
        }

        internal string GetSha1(string filePath)
        {
            return File.ReadAllLines(_testFiles[_SHA_1])[0];
        }
    }
}