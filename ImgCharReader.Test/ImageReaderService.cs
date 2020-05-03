using System;
using Xunit;

namespace ImgCharReader.Test
{
    public class ImageReaderService
    {
        [Theory]
        [InlineData("54NCN", "../testing/example.jpeg")]
        public void TestExampleImage(string expectedText, string filePath)
        {
            ImgCharReader.Domain.ImageReaderService service = new ImgCharReader.Domain.ImageReaderService();
            string text = service.GetText(filePath);
            Assert.Equal(text, expectedText);
        }
    }
}
