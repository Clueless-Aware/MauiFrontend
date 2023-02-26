using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectWork.Services.Core
{
    internal class HandleMultipart
    {
        private const long MaxSize = 223372036854775807L;
        private static MultipartFormDataContent _multipartFormDataContent;
        internal static async Task<MultipartFormDataContent> Build<K>(K item, IBrowserFile file)
        {
            _multipartFormDataContent = new MultipartFormDataContent();
            try
            {
            var parameters = JsonSerializer.Deserialize<Dictionary<string,object>>(JsonSerializer.Serialize(item));

                if (file is not null)
                {
                    var ms = new MemoryStream();
                    await file.OpenReadStream(MaxSize).CopyToAsync(ms);
                    ms.Position = 0;
                    var fileStream = new StreamContent(ms);
                    fileStream.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                    _multipartFormDataContent.Add(fileStream, "image_url", file.Name);
                    parameters.Remove("image_url");
                }
                foreach (KeyValuePair<string, object> entry in parameters)
                {
                    _multipartFormDataContent.Add(new StringContent(entry.Value.ToString()), entry.Key);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            return _multipartFormDataContent;
        }
    }
}