using System;
using ModernGUI_Surveilia.UserContent.ViewModels;
using ModernGUI_Surveilia.UserContent.Stores;
using System.Collections.Generic;
using System.Text;

namespace ModernGUI_Surveilia.UserContent.Services
{
    public class UpdateViewService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public UpdateViewService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
