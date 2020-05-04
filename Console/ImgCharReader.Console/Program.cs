using System;
using ImgCharReader.Domain;
using ImgCharReader.Domain.GoogleVision;

namespace ImgCharReader.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
            System.Console.WriteLine(value);

            IOcr ocr = new ImageReaderService();
            string text = ocr.GetText("/home/paulo/projetos/orm/testImg/example.jpeg");
            System.Console.WriteLine(text);
        }
    }
}
