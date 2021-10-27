using System;
using System.Collections.Generic;
using ModernGUI_Surveilia.UserContent.Stores;
using ModernGUI_Surveilia.UserContent.ViewModels;
using System.Text;

namespace ModernGUI_Surveilia.UserContent.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<MenuBarViewModel> _createMenuBarViewModel;

        public LayoutNavigationService(NavigationStore navigationStore,
        Func<TViewModel> createViewModel,
        Func<MenuBarViewModel> createMenuBarViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createMenuBarViewModel = createMenuBarViewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new SurveiliaLayoutViewModel(_createMenuBarViewModel(), _createViewModel());
        }
    }
}
