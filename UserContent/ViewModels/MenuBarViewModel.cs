using System;
using System.Collections.Generic;
using System.Text;
using ModernGUI_Surveilia.UserContent.Commands;
using ModernGUI_Surveilia.UserContent.Services;
using System.Windows.Input;

namespace ModernGUI_Surveilia.UserContent.ViewModels
{
    public class MenuBarViewModel : ViewModelBase
    {
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateHelpCommand { get; }
        public ICommand NavigateStatsCommand { get; }
        public ICommand NavigateUserMenuCommand { get; }

        public MenuBarViewModel(
            INavigationService menuNavigationService,
            INavigationService helpNavigationService,
            INavigationService statsNavigationService,
            INavigationService userMenuNavigationService
            )
        {
            NavigateMenuCommand = new UpdateViewCommand(menuNavigationService);
            NavigateHelpCommand = new UpdateViewCommand(helpNavigationService);
            NavigateStatsCommand = new UpdateViewCommand(statsNavigationService);
            NavigateUserMenuCommand = new UpdateViewCommand(userMenuNavigationService);
        }

    }
}
