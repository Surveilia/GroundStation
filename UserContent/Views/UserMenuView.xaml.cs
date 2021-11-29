using ModernGUI_Surveilia.UserContent.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ModernGUI_Surveilia.UserContent.Models;
using ModernGUI_Surveilia.UserContent.Components;

namespace ModernGUI_Surveilia.UserContent.Views
{
    /// <summary>
    /// Interaction logic for UserMenuView.xaml
    /// </summary>
    public partial class UserMenuView : UserControl
    {
        public static UserMenuView instance;
        
        public UserMenuView()
        {
            InitializeComponent();
            instance = this;
        }

        public object NameTextBlock { get; private set; }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            FullName.Content = Name.Text;
            MenuBar.instance.NameTextBlock.Content = FullName.Content;
            //NameTextBlock.Content = Name.Text;
        }

    }
}
