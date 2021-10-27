using ModernGUI_Surveilia.UserContent.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernGUI_Surveilia.UserContent.Services
{
    public class CloseModalNavigationService : INavigationService
    {
        private readonly ModalNavigationStore _navigationStore;

        public CloseModalNavigationService(ModalNavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public void Navigate()
        {
            _navigationStore.Close();
        }
    }
}
