using CommunityToolkit.Mvvm.ComponentModel;

namespace Arsene.POS.UI.Model
{
    public partial class TodoItem : ObservableObject
    {
        [ObservableProperty]
        private string? _id;

        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        private string? _notes;

        [ObservableProperty]
        private string? _done;
    }
}
