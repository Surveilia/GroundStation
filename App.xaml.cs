using Microsoft.Extensions.DependencyInjection;
using ModernGUI_Surveilia.UserContent.Services;
using ModernGUI_Surveilia.UserContent.Stores;
using ModernGUI_Surveilia.UserContent.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ModernGUI_Surveilia
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            //stores
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();
            services.AddSingleton<HelpStore>();
            services.AddSingleton<StatsStore>();
            services.AddSingleton<UserMenuStore>();

            services.AddSingleton<INavigationService>(s => CreateMenuNavigationService(s));
            services.AddSingleton<CloseModalNavigationService>();

            //////////////
            services.AddTransient<MenuViewModel>(s => new MenuViewModel(CreateStartNavigationService(s)));
            
            //HELP
            services.AddTransient<HelpViewModel>(s => new HelpViewModel(
                s.GetRequiredService<HelpStore>(),
                CreateMenuNavigationService(s)));
            //USERMENU
            services.AddTransient<UserMenuViewModel>(s => new UserMenuViewModel(
                s.GetRequiredService<UserMenuStore>(),
                CreateMenuNavigationService(s)));
            //STATS
            services.AddTransient<StatsViewModel>(s => new StatsViewModel(
                s.GetRequiredService<StatsStore>(),
                CreateMenuNavigationService(s)));

            services.AddTransient<MenuBarViewModel>(CreateMenuBarViewModel);
            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainWindowViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
        private INavigationService CreateMenuNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<MenuViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<MenuViewModel>(),
                () => serviceProvider.GetRequiredService<MenuBarViewModel>());
        }

        //to be adjusted / moved
        private INavigationService CreateStartNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<MenuViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<MenuViewModel>());
        }
        private INavigationService CreateStatsNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<StatsViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<StatsViewModel>(),
                () => serviceProvider.GetRequiredService<MenuBarViewModel>());
        }
        private INavigationService CreateHelpNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HelpViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HelpViewModel>(),
                () => serviceProvider.GetRequiredService<MenuBarViewModel>());
        }
        private INavigationService CreateUserMenuNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<UserMenuViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<UserMenuViewModel>(),
                () => serviceProvider.GetRequiredService<MenuBarViewModel>());
        }
        private MenuBarViewModel CreateMenuBarViewModel(IServiceProvider serviceProvider)
        {
            //orientation is key here
            return new MenuBarViewModel(
                CreateMenuNavigationService(serviceProvider),
                CreateHelpNavigationService(serviceProvider),
                CreateStatsNavigationService(serviceProvider),
                CreateUserMenuNavigationService(serviceProvider));
        }
    }
}
