using ModernGUI_Surveilia.UserContent.Commands;
using ModernGUI_Surveilia.UserContent.Services;
using ModernGUI_Surveilia.UserContent.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ModernGUI_Surveilia.UserContent.ViewModels
{
    public class StatsViewModel : ViewModelBase
    {
        private readonly StatsStore _statsStore;

        public ICommand NavigateMenuCommand { get; }

        public StatsViewModel(StatsStore statsStore, INavigationService menuNavigationService)
        {
            _statsStore = statsStore;

            NavigateMenuCommand = new UpdateViewCommand(menuNavigationService);
        }
    }
}
