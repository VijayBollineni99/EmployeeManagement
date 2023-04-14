using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrjEmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows;

namespace PrjEmployeeManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private readonly IHost _host;

        //public App()
        //{
        //    _host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            ConfigurationServices(services);
        //        }).Build();
        //}

        //private void ConfigurationServices(IServiceCollection services)
        //{
        //    services.AddSingleton<MainWindow>();
        //    services.AddTransient<IEmployeeService, EmployeeService>();
        //}
        //protected override async void OnStartup(StartupEventArgs e)
        //{
        //    await _host.StartAsync();
        //    var mainwindow = _host.Services.GetRequiredService<MainWindow>();
        //    mainwindow.Show();

        //    base.OnStartup(e);
        //}

        //protected override async void OnExit(ExitEventArgs e)
        //{
        //    using (_host)
        //    {
        //        await _host.StopAsync();
        //    }
        //    base.OnExit(e);
        //}
    }
}
