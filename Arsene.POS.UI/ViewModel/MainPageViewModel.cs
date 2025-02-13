using System.Collections.ObjectModel;
using System.Text.Json;
using Arsene.POS.ApiClient;
using Arsene.POS.UI.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Arsene.POS.UI.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly ApiClientService _apiClientService;

        [ObservableProperty]
        private ObservableCollection<TodoItem> _todoItems = new();

        public MainPageViewModel(ApiClientService apiClientService)
        {
            _apiClientService = apiClientService;
        }

        public async void LoadTodoItems()
        {
            var json = await _apiClientService.GetTodoItems();
            var todoItems = JsonSerializer.Deserialize<ObservableCollection<TodoItem>>(json);
            TodoItems = todoItems!;
        }
    }
}
