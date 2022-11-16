using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Drawing;
using System.Diagnostics;
using System.Web;
using System.Web.Script.Serialization;

namespace ScreenOCR
{
       
    class Network
    {
        static HttpClient client = new HttpClient {BaseAddress = new Uri("https://glyph.api.overfitted.io")};

        public static OcrData queryOcrService(Bitmap bmp, String lang, String apiKey)
        {
            ImageConverter converter = new ImageConverter();
            byte[] byteBmp = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

            ByteArrayContent byteArrayBmp = new ByteArrayContent(byteBmp);

            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Add(byteArrayBmp, "img", "img");
            content.Add(new StringContent(lang), "lang");
            content.Add(new StringContent(apiKey), "api_key");


            OcrData ocrResponse = new OcrData();
            try
            {
                var response = client.PostAsync("/process", content).Result;
                String responseContent = response.Content.ReadAsStringAsync().Result;

                ocrResponse.isError = true;
                ocrResponse.message = responseContent;

                if (response.IsSuccessStatusCode)
                {
                    dynamic data = new JavaScriptSerializer().Deserialize<Object>(responseContent);
                    
                    ocrResponse.message = data["text"];
                    ocrResponse.isError = false;

                    return ocrResponse;
                }

                return ocrResponse;
            }
            catch (Exception ex)
            {
                ocrResponse.isError = true;
                ocrResponse.message = "Couldn't connect to the API :(";
                return ocrResponse;
            }
        }
    }
}
