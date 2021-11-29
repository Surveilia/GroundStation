using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using ModernGUI_Surveilia.UserContent.Components;

namespace ModernGUI_Surveilia.UserContent.Views
{
    /*
     *  Written By:     Chase Westlake & Ben Kennedy
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

            //On load, load image
            Loaded += MenuView_Loaded;

            //Initialize timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

            //When the timer is initiated, it calls statsTimer_Tick every iteration of it's time span. Currently set to 1 second.
            timer.Tick += HomeTimer_Tick;
            timer.Start();
        }

        private void HomeTimer_Tick(object sender, EventArgs e)
        {
            //Needs to be changed to check flags from packet eventually.

            //Sets all of the data points from the packet
            setData();
            //Currently is on a timer for testing
            ViewImg();
        }


        private void MenuView_Loaded(object sender, RoutedEventArgs e)
        {
            setData();
            ViewImg();
        }

        private void setData()
        {
            //Tracks flag on if people are spotted in frame
            if (MenuBar.instance.getPacket(1) == "0")
            {
                PeopleTrack.Content = "No one in frame";
            }
            else if (MenuBar.instance.getPacket(1) == "1")
            {
                PeopleTrack.Content = "Spotted in frame!";
            }

            //Tracks number of people from packet
            PplCount.Text = MenuBar.instance.getPacket(2);
            //Tracks humidity from packet
            HumidVal.Text = MenuBar.instance.getPacket(3);
            //Tracks temperature from packet
            TempVal.Text = MenuBar.instance.getPacket(4);
            //Tracks accelerometer onboard drone from packet
            AccVal.Text = MenuBar.instance.getPacket(5);
            //Tracks gyroscope onboard drone from packet
            GyrVal.Text = MenuBar.instance.getPacket(6);
        }

        //ViewImg() goes to the UDP path to extract images. It finds the most recent image uploaded and retrieves it to display on the home page
        private void ViewImg()
        {
            BitmapImage bi = new BitmapImage();

            string path = @"C:\Surveilia\UDP\Image";

            var file = new DirectoryInfo(path).GetFiles().OrderByDescending(o => o.LastWriteTime).FirstOrDefault();

            if (IsFileLocked(file) == false)
            {
                bi.BeginInit();
                //This is the Directory. User must Create this file
                bi.UriSource = new Uri(path + "\\" + file.Name);

                bi.EndInit();

                HumanRecogImg.Source = bi;
            }
        }

        public virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable
                return true;
            }

            //file is not locked
            return false;
        }
    }
}
