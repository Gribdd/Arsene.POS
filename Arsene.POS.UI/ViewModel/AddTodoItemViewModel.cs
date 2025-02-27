using Arsene.POS.ApiClient;
using Arsene.POS.ApiClient.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Arsene.POS.UI.ViewModel
{
    public partial class AddTodoItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private TodoItem _todoItem = new();

        private readonly ApiClientService _apiClientService;

        public AddTodoItemViewModel(ApiClientService apiClientService)
        {
            _apiClientService = apiClientService;
        }

        [RelayCommand]  
        async Task AddTodoItem()
        {
            bool isAdded = await _apiClientService.AddTodoItem(TodoItem);
        }
    }
}
