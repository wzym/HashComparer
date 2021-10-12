using Xunit;

namespace HashComparerTests
{    
    public class UnitTest1 : IClassFixture<HashComparerTestsFixture>
    {        
        private readonly HashComparerTestsFixture _fixture;

        public UnitTest1(HashComparerTestsFixture fixture)
        {            
            _fixture = fixture;
        }

        [Fact]
        public void Sha256CorrectHash()
        {
            var filePath = _fixture.GetTestFile();
            var expectedHash = _fixture.GetSha256(filePath);            

            var result = HashComparer.HashComparer.Compare(
                expectedHash, filePath, HashComparerTestsFixture._SHA_256);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Sha256IncorrectHash()
        {
            var filePath = _fixture.GetTestFile();
            const string expectedHash = "Something wrong.";

            var result = HashComparer.HashComparer.Compare(
                expectedHash, filePath, HashComparerTestsFixture._SHA_256);
            Assert.Empty(result);
        }

        [Fact]
        public void Sha1CorrectHash()
        {
            var filePath = _fixture.GetTestFile();
            var expectedHash = _fixture.GetSha1(filePath);

            var result = HashComparer.HashComparer.Compare(
                expectedHash, filePath, HashComparerTestsFixture._SHA_1);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Sha1IncorrectHash()
        {
            var filePath = _fixture.GetTestFile();
            var expectedHash = "Something wrong.";

            var result = HashComparer.HashComparer.Compare(
                expectedHash, filePath, HashComparerTestsFixture._SHA_1);
            Assert.Empty(result);
        }

        [Fact]
        public void Sha256IncorrectType()
        {
            var filePath = _fixture.GetTestFile();
            var expectedHash = _fixture.GetSha1(filePath);

            var result = HashComparer.HashComparer.Compare(
                expectedHash, filePath, HashComparerTestsFixture._SHA_256);
            Assert.Empty(result);
        }

        [Fact]
        public void Sha1IncorrectType()
        {
            var filePath = _fixture.GetTestFile();
            var expectedHash = _fixture.GetSha1(filePath);

            var result = HashComparer.HashComparer.Compare(
                expectedHash, filePath, HashComparerTestsFixture._SHA_256);
            Assert.Empty(result);
        }
    }
}