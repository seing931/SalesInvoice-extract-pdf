using SalesInvoiceExtPdf.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SalesInvoiceExtPdf.Services
{
    public class InvAIService
    {
        private readonly string _apiKey;
        private readonly HttpClient _http;

        public InvAIService(IConfiguration config, HttpClient http)
        {
            _apiKey = config["OpenAI:ApiKey"];
            _http = http;
        }

        public async Task<string> ExtractInvoiceAsync(string text)
        {
            var prompt = $@"
You are an invoice extraction system.

Extract invoice data and return ONLY valid JSON.

Return in this exact structure:

{{
  ""orderID"": """",
  ""billTo"": """",
  ""shipTo"": """",
  ""invDate"": ""2024-01-01"",
  ""shipMode"": """",
  ""discPrc"": 0,
  ""shipping"": 0,
  ""items"": [
    {{
      ""itemName"": """",
      ""itemDesc"": """",
      ""qty"": 0,
      ""rate"": 0,
      ""amt"": 0
    }}
  ]
}}

RULES:
- Return ONLY JSON
- No explanation
- No markdown
- If value missing, use empty or 0

TEXT:{text}";

            var requestBody = new
            {
                model = "gpt-4.1-mini",
                messages = new[]
                {
                new
                {
                    role = "system",
                    content = "Extract invoice data and return ONLY valid JSON."
                },
                new
                {
                    role = "user",
                    content = prompt
                }
            }
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                "https://api.openai.com/v1/chat/completions"
            );

            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", _apiKey);

            request.Content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(json);

            return doc.RootElement
                      .GetProperty("choices")[0]
                      .GetProperty("message")
                      .GetProperty("content")
                      .GetString();
        }
    }
}
