using ModernGUI_Surveilia.UserContent.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernGUI_Surveilia.UserContent.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my application dudes";
        public MenuViewModel(INavigationService loginNavigationService)
        {

        }
    }
}
