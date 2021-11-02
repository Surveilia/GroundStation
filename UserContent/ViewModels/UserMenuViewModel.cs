using ModernGUI_Surveilia.UserContent.Commands;
using ModernGUI_Surveilia.UserContent.Services;
using ModernGUI_Surveilia.UserContent.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ModernGUI_Surveilia.UserContent.ViewModels
{
    public class UserMenuViewModel : ViewModelBase
    {
        private readonly UserMenuStore _userMenuStore;

        public ICommand NavigateMenuCommand { get; }

        public UserMenuViewModel(UserMenuStore userMenuStore, INavigationService menuNavigationService)
        {
            _userMenuStore = userMenuStore;

            NavigateMenuCommand = new UpdateViewCommand(menuNavigationService);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
