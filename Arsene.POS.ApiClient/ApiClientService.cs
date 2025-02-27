using Arsene.POS.ApiClient.Model;
using System.Text.Json;
using System.Text;

namespace Arsene.POS.ApiClient
{
    public class ApiClientService
    {
        private readonly HttpClient _httpClient;
        private readonly string _todoItemsEndpoint = "asspos/mobileloadtodo.php/";
        public ApiClientService(ApiClientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(apiClientOptions.ApiBaseAddress!);
        }

        public async Task<string> GetTodoItems()
        {
            using HttpResponseMessage response = await _httpClient.GetAsync(_todoItemsEndpoint);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public async Task<bool> AddTodoItem(TodoItem newItem)
        {
            var jsonContent = JsonSerializer.Serialize(newItem);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await _httpClient.PostAsync(_todoItemsEndpoint, content);

            return response.IsSuccessStatusCode;
        }

    }
}
