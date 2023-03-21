using System.Net;
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

                var msg = await tempMessage.Content.ReadAsStringAsync();
                var temp = JsonSerializer.Deserialize<Dictionary<string, object>>(msg);
                var msgString = temp.Aggregate(string.Empty,
                    (current, key) => current + key.Key + " " +
                                      new string((key.Value.ToString() ?? "something goes wrong")
                                          .Where((x) => char.IsWhiteSpace(x) || char.IsLetterOrDigit(x)).ToArray()) +
                                      "\n");
                throw new Exception("Error: " + msgString);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        internal static async Task<HttpStatusCode> Responded(HttpResponseMessage tempMessage)
        {
            try
            {
                if (tempMessage.IsSuccessStatusCode)
                {
                    return tempMessage.StatusCode;
                }
                var msg = await tempMessage.Content.ReadAsStringAsync();
                var temp = JsonSerializer.Deserialize<Dictionary<string, object>>(msg);
                var msgString = temp.Aggregate(string.Empty,
                    (current, key) => current + key.Key + " " +
                                      new string((key.Value.ToString() ?? "something goes wrong")
                                          .Where((x) => char.IsWhiteSpace(x) || char.IsLetterOrDigit(x)).ToArray()) +
                                      "\n");
                throw new Exception("Error: " + msgString);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}