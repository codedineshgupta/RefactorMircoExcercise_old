

namespace RefactorMircoExcercise.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverterTests
    {
        [Fact]
        public void ConvertToHtml_ShouldConvertUnicodeFileToHtml()
        {
            // Arrange
            string sampleFileContent = "Line 1\nLine 2\nLine 3";
            string expectedHtml = "Line 1<br />Line 2<br />Line 3<br />";
            string fakeFilePath = "fake-file-path";

            // Create a mock IFileReader with the sample file content
            var mockFileReader = new Mock<IFileReader>();
            mockFileReader.Setup(reader => reader.OpenText()).Returns(new StringReader(sampleFileContent));

            // Create an instance of the UnicodeFileToHtmlTextConverter with the mock IFileReader
            var converter = new UnicodeFileToHtmlTextConverter(mockFileReader.Object);

            // Act
            string actualHtml = converter.ConvertToHtml();

            // Assert
            Assert.Equal(expectedHtml, actualHtml);
        }

        [Fact]
        public void ConvertToHtml_ShouldHandleEmptyFile()
        {
            // Arrange
            string sampleFileContent = string.Empty;
            string expectedHtml = string.Empty;
            string fakeFilePath = "fake-file-path";

            // Create a mock IFileReader with an empty file
            var mockFileReader = new Mock<IFileReader>();
            mockFileReader.Setup(reader => reader.OpenText()).Returns(new StringReader(sampleFileContent));

            // Create an instance of the UnicodeFileToHtmlTextConverter with the mock IFileReader
            var converter = new UnicodeFileToHtmlTextConverter(mockFileReader.Object);

            // Act
            string actualHtml = converter.ConvertToHtml();

            // Assert
            Assert.Equal(expectedHtml, actualHtml);
        }
        
    }
}
