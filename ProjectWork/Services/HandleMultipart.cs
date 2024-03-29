﻿using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using System.Text.Json;
using ProjectWork.Utilities;

namespace ProjectWork.Services.Core
{
    internal class HandleMultipart
    {
        private static MultipartFormDataContent _multipartFormDataContent;
        internal static async Task<MultipartFormDataContent> Build<K>(K item, IBrowserFile file, ImageOptions imageOptions)
        {
            try
            {
                _multipartFormDataContent = new MultipartFormDataContent();
                var parameters = JsonSerializer.Deserialize<Dictionary<string, object>>(JsonSerializer.Serialize(item));

                if (file is not null)
                {
                    var ms = new MemoryStream();
                    await file.OpenReadStream(imageOptions.FileMaxSize).CopyToAsync(ms);
                    ms.Position = 0;
                    var fileStream = new StreamContent(ms);
                    fileStream.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                    _multipartFormDataContent.Add(fileStream, imageOptions.FileName, file.Name);
                }
                parameters.Remove(imageOptions.FileName);
                foreach (var entry in parameters)
                {
                    _multipartFormDataContent.Add(new StringContent(entry.Value.ToString()), entry.Key);
                }
                return _multipartFormDataContent;
            }
            catch (Exception e)
            {
                await UtilityToolkit.CreateToast(e.Message);
                throw;
            }
        }
    }
}