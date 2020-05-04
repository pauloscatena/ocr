using Tesseract;

namespace ImgCharReader.Domain.Tesseract
{
    public class ImageReaderService: IOcr
    {
        public string GetText(string fileName)
        {
            
            string result = string.Empty;
            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default)) 
            {
                var pix = Pix.LoadFromFile(fileName);
                using(var page = engine.Process(pix))
                {
                    result = page.GetText();
                }
            }

            return result;
        }
    }
}
