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


namespace ModernGUI_Surveilia.UserContent.Views
{
    /*
     *  Written By:     Chase Westlake
     *  
     *  Description:    This code currently reads an image in a directory and updates the former image to the new one.
     *  
     *                  This needs to be able to respond to UDP flags and upload variable images (newest) from the Surveilia UDP images. 
     * 
     * This documentation is used to upload new images to the GUI
     * https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.imaging.bitmapimage?redirectedfrom=MSDN&view=windowsdesktop-5.0 
     * 
     */
    public partial class MenuView : UserControl
    {

        public MenuView()
        {
            InitializeComponent();
        }


        private void ViewImg_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bi = new BitmapImage();

            bi.BeginInit();
            
            //This is the Directory, change it**********************************
            bi.UriSource = new Uri(@"D:\School\Year3\GroundStation\GUIupD\GUI_UpdatedFM-main\Images\Surveilia.jpg");
            
            
            bi.EndInit();

            HumanRecogImg.Source = bi;

        }
    }
}
