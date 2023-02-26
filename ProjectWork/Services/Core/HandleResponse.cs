using ProjectWork.Utilities;
using System.Text.Json;

namespace ProjectWork.Services.Core
{
    internal class HandleResponse
    {
        internal static async Task<T> Responded<T>(HttpResponseMessage tempMessage)
        {
            try
            {
                if (tempMessage.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<T>(await tempMessage.Content.ReadAsStringAsync());
                }
                throw new Exception("Error: " + tempMessage.StatusCode.ToString() + " Contact Shinigami \n " + tempMessage.Content);
            }
            catch (Exception e)
            {
                await UtilyToolkit.CreateToast(e.Message);
                return default;
            }
        }
        internal static async Task Responded(HttpResponseMessage tempMessage)
        {
            try
            {
                if (tempMessage.IsSuccessStatusCode)
                {
                    throw new NotImplementedException();
                }
                throw new Exception("Error: " + tempMessage.StatusCode.ToString() + " Contact Shinigami \n " + tempMessage.Content);
            }
            catch (Exception e)
            {
                await UtilyToolkit.CreateToast(e.Message);
            }
        }
    }
}