using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ImgCharReader.Test
{

    public class ImageReaderServiceNSOCR
    {
        [Theory]
        [InlineData("54NCN", ".\\images\\example.jpeg")]
        public void TestNSOCRExampleImage(string expectedText, string filePath)
        {
            try
            {
                ImgCharReader.Domain.NSOCR.ImgReaderService service = new ImgCharReader.Domain.NSOCR.ImgReaderService();
                string text = service.GetText(filePath);
                Assert.Equal(text, expectedText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
