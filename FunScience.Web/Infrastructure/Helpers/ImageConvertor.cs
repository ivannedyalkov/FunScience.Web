namespace FunScience.Web.Infrastructure.Helpers
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IO;

    public static class ImageConvertor
    {
        public static byte[] ConvertToBytes(IFormFile file)
        {
            Stream stream = file.OpenReadStream();

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public static string ConvertToImage(byte[] array)
        {
            string mimeType = "image";

            if (array != null)
            {
                string base64 = Convert.ToBase64String(array);
                return string.Format("data:{0};base64,{1}", mimeType, base64);
            }

            return string.Empty;
        }
    }
}
