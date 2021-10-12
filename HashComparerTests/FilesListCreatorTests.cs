using System;
using System.IO;
using System.Linq;
using HashComparer;
using HashComparerInterfaces;
using Moq;
using Xunit;

namespace HashComparerTests
{
    public class FilesListCreatorTests
    {
        private const string WithInnerDirsDirectoryName = "0_withInnerDirectories";
        private const string WithOutInnerDirsDirectoryName = "0_withoutInnerDirectories";

        [Fact]
        public void StartPathIsRequestedOnce()
        {
            var mock = GetArgsStorageMock(WithInnerDirsDirectoryName);
            var filesListCreator = new FilesListCreator(mock.Object);
            filesListCreator.GetFiles();
            mock.Verify(ias => ias.StartPath, Times.Once);
        }

        [Fact]
        public void CorrectFilesNumberWithInners()
        {
            var mock = GetArgsStorageMock(WithInnerDirsDirectoryName);
            var filesListCreator = new FilesListCreator(mock.Object);
            var resFiles = filesListCreator.GetFiles();
            Assert.Equal(12, resFiles.Count());
        }
        
        [Fact]
        public void CorrectFilesNumberWithoutInners()
        {
            var mock = GetArgsStorageMock(WithOutInnerDirsDirectoryName);
            var filesListCreator = new FilesListCreator(mock.Object);
            var resFiles = filesListCreator.GetFiles();
            Assert.Equal(3, resFiles.Count());
        }

        [Fact]
        public void NotValidPath()
        {
            var mock = GetArgsStorageMock("notvaliddirectoryname");
            var filesListCreator = new FilesListCreator(mock.Object);
            Assert.ThrowsAny<Exception>(() => filesListCreator.GetFiles());
        }

        private static Mock<IArgsStorage> GetArgsStorageMock(string directoryName)
        {
            var mock = new Mock<IArgsStorage>();
            mock.Setup(ias => ias.StartPath).Returns(GetPathWith(directoryName));
            return mock;
        }
        
        private static string GetPathWith(string folderName)
            => Path.Combine(Directory.GetCurrentDirectory(), folderName);
    }
}