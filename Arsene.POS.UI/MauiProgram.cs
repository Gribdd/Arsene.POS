using Microsoft.Extensions.Logging;
using Arsene.POS.ApiClient.IoC;
using Arsene.POS.UI.ViewModel;
namespace Arsene.POS.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddApiClientService(options =>
            {
                options.ApiBaseAddress = "https://ebisx.com/";
            });
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<AddTodoItemViewModel>();
            return builder.Build();
        }
    }
}
