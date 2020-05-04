using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Vision.V1;

namespace ImgCharReader.Domain.GoogleVision
{
    public class ImageReaderService: IOcr
    {
        public string GetText(string fileName)
        {
            // Definir essa variável no ambiente (linux ou windows) com base na conta de serviço criada no Google
            //https://cloud.google.com/docs/authentication/production#linux-or-macos
            string value = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
            
            Image img = Image.FromFile(fileName); 

            var result = string.Empty;
            ImageAnnotatorClient client = ImageAnnotatorClient.Create();
            
            IReadOnlyList<EntityAnnotation> textAnnotations = client.DetectText(img);
            foreach(EntityAnnotation text in textAnnotations)
            {
                result += text.Description;
            }
            return result;
        }
    }
}
