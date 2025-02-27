using Arsene.POS.UI.View;

namespace Arsene.POS.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddTodoItem), typeof(AddTodoItem));

        }
    }
}
