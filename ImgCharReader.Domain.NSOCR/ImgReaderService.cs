using System;
using NSOCRLib;

namespace ImgCharReader.Domain.NSOCR
{
	public class ImgReaderService
	{
		public string GetText(string fileName)
		{
			string result = string.Empty;
			int CfgObj, OcrObj, ImgObj, res;
			NSOCRClass nsOCR = new NSOCRClassClass();
			try
			{
				nsOCR.Engine_InitializeAdvanced(out CfgObj, out OcrObj, out ImgObj);
				res = nsOCR.Img_LoadFile(ImgObj, fileName);
				if (res > TNSOCR.ERROR_FIRST)
				{
					throw new Exception("File not found");
				};
			    
				//nsOCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "Languages/German", "0"); //unselect German language
				nsOCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "Languages/English", "1"); //select English language
				res = nsOCR.Img_OCR(ImgObj, TNSOCR.OCRSTEP_FIRST, TNSOCR.OCRSTEP_LAST, TNSOCR.OCRFLAG_NONE); //perform OCR
				if (res > TNSOCR.ERROR_FIRST) { }; //insert error handler here
				nsOCR.Img_GetImgText(ImgObj, out result, TNSOCR.FMT_EXACTCOPY); //get text
			}
			finally
			{
				nsOCR.Engine_Uninitialize(); //release all created objects and uninitialize OCR engine
			}
			return result;
		}
	}
}
