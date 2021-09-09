﻿using APK2.Data;
using APK2.Interfaces;
using APK2.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using APK2.ViewModel;

namespace APK2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        private static IHost __Hosting;

        public static IHost Hosting => __Hosting
            ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration(opt => opt.AddJsonFile("appsettings.json", false, true))
               .ConfigureServices(ConfigureServices);


        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {

            services.AddTransient<Connection>();
          
            var connectionString = host.Configuration.GetConnectionString("MySqlServer");
            var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

            services.AddDbContext<DataContext>(
           dbContextOptions => dbContextOptions
               .UseMySql(connectionString, serverVersion)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors()
       );
            services.AddSingleton<AutentificationViewModel>();
            services.AddSingleton<IndividualsViewModel>();
            services.AddSingleton<StatusesViewModel>();
                        

            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));


        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (var scope = Services.CreateScope()) {
                var initializer = scope.ServiceProvider.GetRequiredService<Connection>();
                initializer.InitializeAsync().Wait();
                var st =initializer.Status();

                          }


            base.OnStartup(e);
        }

    }
}
