using System.Collections.ObjectModel;
using System.Text.Json;
using Arsene.POS.ApiClient;
using Arsene.POS.UI.Model;
using Arsene.POS.UI.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

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

        [RelayCommand]
        async Task NavigateToAddTodoPage()
        {
            await Shell.Current.GoToAsync(nameof(AddTodoItem));
        }

        [RelayCommand]  
        private void ManipulatePdf()
        {

            string dest = Path.Combine(FileSystem.Current.AppDataDirectory, "SalesInvoice.pdf");
            using (PdfWriter writer = new PdfWriter(dest))
            using (PdfDocument pdf = new PdfDocument(writer))
            using (Document document = new Document(pdf))
            {
                List topLevel = new List();
                ListItem topLevelItem = new ListItem();
                topLevelItem.Add(new Paragraph().Add("Item 1"));
                topLevel.Add(topLevelItem);

                List secondLevel = new List();
                secondLevel.Add("Sub Item 1");
                ListItem secondLevelItem = new ListItem();
                secondLevelItem.Add(new Paragraph("Sub Item 2"));
                secondLevel.Add(secondLevelItem);
                topLevelItem.Add(secondLevel);

                List thirdLevel = new List();
                thirdLevel.Add("Sub Sub Item 1");
                thirdLevel.Add("Sub Sub Item 2");
                secondLevelItem.Add(thirdLevel);

                document.Add(topLevel);
            }

            // Show success message
            Shell.Current.DisplayAlert("Success", $"PDF saved at {dest}", "OK");
        }
    }
}
