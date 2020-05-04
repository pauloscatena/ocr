using System;

namespace ImgCharReader.Domain
{
    public interface IOcr
    {
        string GetText(string fileName);
    }
}
