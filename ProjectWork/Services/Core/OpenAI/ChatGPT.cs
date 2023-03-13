using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

namespace ProjectWork.Services.Core.OpenAI
{
    internal class ChatGpt
    {
        public static string output = "";
        public static string input = "";

        public static async Task gen()
        {
            string apiUrl = "https://api.openai.com/v1/chat/completions";
            string apiKey = "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";

            Request request = new Request();
            request.Messages = new RequestMessage[]
            {
                new RequestMessage()
                {
                     Role = "system",
                     Content = "You are a helpful assistant."
                },
                new RequestMessage()
                {
                     Role = "user",
                     Content = input

                }
            };

            string requestData = System.Text.Json.JsonSerializer.Serialize(request);
            StringContent content = new StringContent(requestData, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(apiUrl, content);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                    Response response = System.Text.Json.JsonSerializer.Deserialize<Response>(responseString);
                    output = response.Choices[0].Message.Content;
                }
                else
                {
                    output = "Error: {httpResponseMessage.StatusCode} - {httpResponseMessage.ReasonPhrase}";
                }

                
            }
        }

    }

    //JSON structure for GPT message
    public class Request
    {
        [JsonPropertyName("model")]
        public string Model { get; set; } = "gpt-3.5-turbo";
        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; } = 4000;
        [JsonPropertyName("messages")]
        public RequestMessage[] Messages { get; set; }
    }

    public class RequestMessage
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class Response
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("created")]
        public int Created { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("usage")]
        public ResponseUsage Usage { get; set; }
        [JsonPropertyName("choices")]
        public ResponseChoice[] Choices { get; set; }
    }

    public class ResponseUsage
    {
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }
        [JsonPropertyName("completion_tokens")]
        public int CompletionTokens { get; set; }
        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }

    public class ResponseChoice
    {
        [JsonPropertyName("message")]
        public ResponseMessage Message { get; set; }
        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; set; }
        [JsonPropertyName("index")]
        public int Index { get; set; }
    }

    public class ResponseMessage
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

}
