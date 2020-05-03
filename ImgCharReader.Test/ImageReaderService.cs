using System;
using Xunit;

namespace ImgCharReader.Test
{
    public class ImageReaderService
    {
        [Theory]
        [InlineData("54NCN", ".\\images\\example.jpeg")]
        public void TestExampleImage(string expectedText, string filePath)
        {
            try
            {
                ImgCharReader.Domain.ImageReaderService service = new ImgCharReader.Domain.ImageReaderService();
                string text = service.GetText(filePath);
                Assert.Equal(text, expectedText);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
