﻿#pragma checksum "..\..\..\..\..\UserContent\Views\HelpView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "929C81E545C3BF55D07E86A041ABEC979147462C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ModernGUI_Surveilia.UserContent.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ModernGUI_Surveilia.UserContent.Views {
    
    
    /// <summary>
    /// HelpView
    /// </summary>
    public partial class HelpView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\..\UserContent\Views\HelpView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label HelpWindowLabel;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\UserContent\Views\HelpView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock HelpWindowInfo;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\UserContent\Views\HelpView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Instructions;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ModernGUI_Surveilia;component/usercontent/views/helpview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UserContent\Views\HelpView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.HelpWindowLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.HelpWindowInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Instructions = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            
            #line 49 "..\..\..\..\..\UserContent\Views\HelpView.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.Hyperlink_RequestNavigate);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

