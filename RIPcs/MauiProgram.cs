using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using RIPcs.Service;
using RIPcs.View;
using RIPcs.ViewModel;

namespace RIPcs
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .RegisterContainer()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
          
#if DEBUG
    		builder.Logging.AddDebug();
            
#endif
            return builder.Build();
        }

        public static MauiAppBuilder RegisterContainer(this MauiAppBuilder app)
        {
            app.Services.AddScoped<IPhonewordTranslatorService, PhonewordTranslatorService>();
            app.Services.AddTransient<PhonewordTranslatorViewModel>();
            app.Services.AddTransient<PhonewordTranslatorView>();
            app.Services.AddTransient<IDialogService, DialogService>();

            return app;
        }

    }
}
