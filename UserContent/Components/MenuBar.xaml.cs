using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ModernGUI_Surveilia.UserContent.ViewModels;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.IO;
using System.Text;

namespace ModernGUI_Surveilia.UserContent.Components
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        int index = 0;

        //If not minimized, false.
        private bool Minimzed = false;

        public static MenuBar instance;
        public MenuBar()
        {
            //initialize the user control
            InitializeComponent();
            //internal timer, used for screengrab and update purposes
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            //instantiate the MenuBar for use in other windows, specifically for operator name
            instance = this;
        }

        //This function continuously updates the timer. 
        //This function can be used to control updates to GUI on a timed basis.
        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToString("HH:mm:ss");

            index++;
        }

        //exit the application
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //shutdown the application if the exit button is pressed
            Application.Current.Shutdown();
        }

        //minimize/maximize the window
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            if(Minimzed == false)
            {
                //sets window height and width
                Application.Current.MainWindow.Height = 50;
                Application.Current.MainWindow.Width = 800;

                //sets the symbol in the min/max button if action to a square is true
                Minimzed = true;
                Minimize.Content = "\u0560";
            }
            else
            {
                //sets window height and width
                Application.Current.MainWindow.Height = 450;
                Application.Current.MainWindow.Width = 800;

                //sets the symbol in the min/max button to a minus bar if action is false
                Minimzed = false;
                Minimize.Content = "_";
            }
        }
        
        //button action
        private void Screenshot_Click(object sender, RoutedEventArgs e)
        {
            Screenshot(Application.Current.MainWindow);
        }

        //activated upon click of the camera button , saves the screencapture of the MainWindow to a Screenshot folder in the C drive
        private void Screenshot(FrameworkElement element)
        {  
            //sets directory if the path exists, must be created before it can save, does not currently auto generate a folder, could be a possible future addition
            string path = @"C:\Surveilia\Screenshots\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //sets the string name for the photo file with the string name 
            String filename = path + DateTime.Now.ToString("Surveilia ScreenGrab - " + " ddMMyyyy-hhmmss") +".png";
            
            //get screenshot of the element
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)element.Width, (int)element.Height, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(element);
            //create encoder
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            //save it
            FileStream fs = new FileStream(filename, FileMode.Create);
            encoder.Save(fs);
            fs.Close();
        }
    }
}
