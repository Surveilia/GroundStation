using ModernGUI_Surveilia.UserContent.Commands;
using ModernGUI_Surveilia.UserContent.Services;
using ModernGUI_Surveilia.UserContent.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ModernGUI_Surveilia.UserContent.ViewModels
{
    public class HelpViewModel : ViewModelBase
    {
        private readonly HelpStore _helpStore;

        public ICommand NavigateMenuCommand { get; }

        public HelpViewModel(HelpStore helpstore, INavigationService menuNavigationService)
        {
            _helpStore = helpstore;

            NavigateMenuCommand = new UpdateViewCommand(menuNavigationService);
        }
    }
}
