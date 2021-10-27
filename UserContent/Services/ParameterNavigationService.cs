﻿using ModernGUI_Surveilia.UserContent.Stores;
using ModernGUI_Surveilia.UserContent.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernGUI_Surveilia.UserContent.Services
{
    public class ParameterNavigationService<TParameter, TViewModel>
        where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TParameter, TViewModel> _createViewModel;

        public ParameterNavigationService(NavigationStore navigationStore, Func<TParameter, TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(TParameter parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel(parameter);
        }
    }
}
