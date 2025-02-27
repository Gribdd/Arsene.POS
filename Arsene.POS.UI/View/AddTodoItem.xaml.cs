using Arsene.POS.UI.ViewModel;

namespace Arsene.POS.UI.View;

public partial class AddTodoItem : ContentPage
{
	public AddTodoItem(AddTodoItemViewModel _vm)
	{
		InitializeComponent();
        BindingContext = _vm;
    }
}