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
            InitializeComponent();
            //timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

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
            Application.Current.Shutdown();
        }
        //minimize/maximize the window
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            if(Minimzed == false)
            {
                Application.Current.MainWindow.Height = 50;
                Minimzed = true;
                Minimize.Content = "\u0560";
            }
            else
            {
                Application.Current.MainWindow.Height = 415;
                Minimzed = false;
                Minimize.Content = "_";
            }
        }
        

        private void Screenshot_Click(object sender, RoutedEventArgs e)
        {
            Screenshot(Application.Current.MainWindow);
        }

        private void Screenshot(FrameworkElement element)
        {
            string path = @"C:\Surveilia\Screenshots\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            String filename = path + DateTime.Now.ToString("ddMMyyyy-hhmmss") +".png";
            
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
