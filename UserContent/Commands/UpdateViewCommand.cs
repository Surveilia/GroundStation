using System;
using System.Collections.Generic;
using System.Text;
using ModernGUI_Surveilia.UserContent.Services;

namespace ModernGUI_Surveilia.UserContent.Commands
{
    public class UpdateViewCommand : CommandBase
    {
        private readonly INavigationService _navigationService;
        public UpdateViewCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
