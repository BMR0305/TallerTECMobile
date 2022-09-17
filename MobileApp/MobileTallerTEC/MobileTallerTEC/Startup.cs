using Microsoft.Extensions.DependencyInjection;
using System;
using MobileTallerTEC.Services;
using MobileTallerTEC.ViewModels;


namespace MobileTallerTEC
{
    public static class Startup
    {
        private static IServiceProvider serviceProvider;
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();
            //services.AddSingleton<IAppointmentService, InMemoryAppointmentService>();
            //add services
            services.AddHttpClient<IAppointmentService, ApiAppointmentService>(c =>
            {
              c.BaseAddress = new Uri("http://10.0.2.2:9968/");
              c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient<IBillsService, ApiBillsService>(c =>
            {
                c.BaseAddress = new Uri("http://10.0.2.2:9968/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            //add viewmodels
            services.AddTransient<BillingViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegistrationViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
