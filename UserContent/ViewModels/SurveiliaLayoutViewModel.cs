using System;
using System.Collections.Generic;
using System.Text;

namespace ModernGUI_Surveilia.UserContent.ViewModels
{
    public class SurveiliaLayoutViewModel : ViewModelBase
    {
        public MenuBarViewModel MenuBarViewModel { get; }
        public ViewModelBase ContentViewModel { get; }

        public SurveiliaLayoutViewModel(MenuBarViewModel menuBarViewModel, ViewModelBase contentViewModel)
        {
            MenuBarViewModel = menuBarViewModel;
            ContentViewModel = contentViewModel;
        }

        public override void Dispose()
        {
            MenuBarViewModel.Dispose();
            ContentViewModel.Dispose();

            base.Dispose();
        }
    }
}
