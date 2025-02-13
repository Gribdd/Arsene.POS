using Arsene.POS.UI.ViewModel;

namespace Arsene.POS.UI
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _vm;
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = _vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _vm.LoadTodoItems();
        }


    }

}
