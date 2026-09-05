using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudyPlanner.App.Components;
using System.Windows;

namespace StudyPlanner.App;

/// <summary>
/// Точка входа WPF-приложения. Инициализирует Generic Host с Autofac-контейнером
/// и разрешает главное окно через DI.
/// </summary>
public partial class App : Application
{
    private IHost? _host;

    /// <summary>
    /// Запускается при старте приложения: строит и запускает Generic Host с Autofac,
    /// затем показывает главное окно, разрешённое из контейнера.
    /// </summary>
    /// <remarks>
    /// Используется классический <see cref="Host.CreateDefaultBuilder(string[])"/> (возвращает <see cref="IHostBuilder"/>),
    /// так как в net10.0 у <c>HostApplicationBuilder</c> нет перегрузки <c>ConfigureContainer</c>, принимающей фабрику провайдера.
    /// </remarks>
    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _host = Host.CreateDefaultBuilder(e.Args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(ConfigureContainer)
            .Build();

        await _host.StartAsync();

        MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    /// <summary>
    /// Запускается при выходе: сохраняет состояние, корректно останавливает и освобождает хост.
    /// </summary>
    protected override async void OnExit(ExitEventArgs e)
    {
        if (_host is not null)
        {
            await _host.Services.GetRequiredService<TaskViewModel>().SaveTasksAsync();
            await _host.StopAsync();
            _host.Dispose();
        }

        base.OnExit(e);
    }

    /// <summary>
    /// Регистрирует компоненты приложения в Autofac-контейнере.
    /// </summary>
    /// <param name="builder">Построитель Autofac-контейнера.</param>
    private static void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterType<TaskViewModel>()
            .AsSelf()
            .SingleInstance();

        builder.RegisterType<MainWindow>()
            .AsSelf()
            .SingleInstance();
    }
}
