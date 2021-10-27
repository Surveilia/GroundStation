using System;
using System.Collections.Generic;
using ModernGUI_Surveilia.UserContent.Stores;
using ModernGUI_Surveilia.UserContent.ViewModels;
using System.Text;

namespace ModernGUI_Surveilia.UserContent.Services
{
    public class ModalNavigationService<TViewModel> : INavigationService
        where TViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public ModalNavigationService(ModalNavigationStore navigationStore, Func<TViewModel> createViewModel)
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
