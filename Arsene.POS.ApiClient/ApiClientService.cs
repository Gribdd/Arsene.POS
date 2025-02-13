using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Arsene.POS.ApiClient.Model;

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

    }
}
