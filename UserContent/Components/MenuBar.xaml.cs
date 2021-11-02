using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ModernGUI_Surveilia.UserContent.ViewModels;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace ModernGUI_Surveilia.UserContent.Components
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        int index = 0;

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

            timeLabel.Content = index;
            index++;
        }
        //exit the application
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //minimize the window
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.Height = 50;
            
        }

        private void Screenshot_Click(object sender, RoutedEventArgs e)
        {
            Screenshot(this);
        }

        private void Screenshot(FrameworkElement element)
        { 
            String filename = "C:/Users/Ethan Pyle/Desktop/Screenshots/" + DateTime.Now.ToString("ddMMyyyy-hhmmss") +".png";
            //get screenshot of the element
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)element.ActualWidth, (int)element.ActualHeight, 96, 96, PixelFormats.Pbgra32);
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
