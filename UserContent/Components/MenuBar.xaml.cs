using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.IO;
using System.Linq;

namespace ModernGUI_Surveilia.UserContent.Components
{

    public partial class MenuBar : UserControl
    {
        //bool accFlag = true;

        //Critical variables for loading text data for chart:
        int chartIndex = 1;
        string accPath = @"C:\Surveilia\Data\AccData.txt";
        //string gyroPath = @"C:\Surveilia\Data\gyroData.txt";

        int[] accData = new int[22];
        //int[] gyroData = new int[22];


        //Index used to track points in time
        int timeIndex = 0;

        static int packetLength = 7;

        //Packet content
        string[] Packet = new string[packetLength];

        //If not minimized, false.
        private bool Minimzed = false;

        public static MenuBar instance;
        public MenuBar()
        {
            InitializeComponent();

            Loaded += MenuBar_Loaded;
        }

        private void MenuBar_Loaded(object sender, RoutedEventArgs e)
        {
            //Load data into the accelerometer & gyroscope handling
            loadData();
            chartIndex++;

            //timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            instance = this;
        }


        //This function continuously updates the timer and displays current time to GUI. 
        //This function can be used to control updates to GUI on a timed basis.
        //Index is used to mark moments in time to update certain parameters
        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToString("HH:mm:ss");

            if (timeIndex % 1 == 0)
            {
                setPacket();
                loadDataArray();
                loadData();
            }
            timeIndex++;
        }

        /****************************************** CHART DATA BEGIN **********************************************************************/
        private void loadDataArray()
        {
            //Ensures that the chartIndex will not exceed the data array length, resets periodically 
            if(chartIndex == 20)
            {
                chartIndex = 1;
            }
            accData[chartIndex] = int.Parse(Packet[5]);
            chartIndex++;
            //If the accelerometer is to be loaded, load acc data
            /*if (accFlag == true)
            {
                accData[chartIndex] = int.Parse(Packet[5]);
                accFlag = false;
            }
            //if not accelerometer dat, load gyroscope data. Increments on this step due to the procedural basis. 
            //If index were to be incremented elsewhere, the gyroscope and accelerometer would not load synchronously. Gyro would lag acc
            else
            {
                gyroData[chartIndex] = int.Parse(Packet[6]);
                chartIndex++;
                accFlag = true;
            }*/
        }

        private void loadData()
        {
            //This conditional clears the data acquired over the life time of collection (max out at 20 index) and resets chartIndex.
            if(chartIndex == 20)
            {
                //CreateFile clears the text file of data and restarts data cycle for the chart
                createFile(accPath);
                //createFile(gyroPath);
                //Clears data in the array to not exceed length of array.

                Array.Clear(accData, 0, accData.Length);

                
                //Array.Clear(gyroData, 22, gyroData.Length);
                chartIndex = 1;
            }
            //Checks if file exists, creates file if not.
            else if (!File.Exists(accPath))
            {
                createFile(accPath);
                //createFile(gyroPath);
            }
            //Loads data into text files for array to view
            else
            {
                using (StreamWriter data = new StreamWriter(accPath))
                {
                    for (int i = 0; i < chartIndex; i++)
                    {
                        if (i == 0)
                        {
                            data.WriteLine(chartIndex);
                            chartIndex++;
                        }
                        else if(i != 0)
                        {
                            data.WriteLine(accData[i]);
                        }
                    }
                }
                //Subtracts index by one to reflect the same operation in the gyroscope path, as what happened with the index in the accPath
                /*chartIndex -= 1;
                using (StreamWriter data = new StreamWriter(gyroPath))
                {
                    for (int i = 0; i < chartIndex; i++)
                    {
                        if (i == 0)
                        {
                            data.WriteLine(chartIndex);
                            chartIndex++;    
                        }
                        else if (i != 0)
                        {
                            data.WriteLine(gyroData[i]);
                        }
                    }
                }*/
                //increments chart index to accurately represent for next loading
                chartIndex++; 
            }
        }

        //This creates file if files do not exist. Checks accFlag
        private void createFile(string path)
        {
            using (StreamWriter create = new StreamWriter(path))
            {
                create.WriteLine(0);
            }
            /*if (accFlag == true)
            {
                accFlag = false;
            }
            else if(accFlag == false)
            {
                chartIndex = 1;
                accFlag = true;
            }*/
        }

        //*************************************************** CHART DATA END ***************************************************************************



        /*Sets the new packet data, can be accessed consistently across the ground station windows
            # Packet contains in order:
            # - Check sum
            # - personFlag
            # - # of people
            # - humidity
            # - Temp
            # - accelerometer
            # - gyroscope
        */
        private void setPacket()
        {
            string path = @"C:\Surveilia\UDP\Data";
            var file = new DirectoryInfo(path).GetFiles().OrderByDescending(o => o.LastWriteTime).FirstOrDefault();

            if (IsFileLocked(file) == false)
            {
                using (StreamReader PacketHandle = new StreamReader(Convert.ToString(file)))
                {
                    for (int i = 0; i < packetLength; i++)
                    {
                        Packet[i] = PacketHandle.ReadLine();
                    }
                }
            }
        }

        //returns packet value for the index specified anywhere in the Ground Station
        public string getPacket(int index)
        {
            return Packet[index];
        }

        public string getTick()
        {
            return timeIndex.ToString();
        }

        //exit the application
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        //minimize/maximize the window
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            //Checks if not minimized. If not minimized; minimizes, changes flag value, and changes minimize button icon
            if(Minimzed == false)
            {
                Application.Current.MainWindow.Height = 50;
                Minimzed = true;
                Minimize.Content = "\u0560";
            }

            //If minimzed; maximizes, changes flag value, changes minimize button icon
            else
            {
                Application.Current.MainWindow.Height = 415;
                Minimzed = false;
                Minimize.Content = "_";
            }
        }
        
        //Takes screenshot on click
        private void Screenshot_Click(object sender, RoutedEventArgs e)
        {
            Screenshot(Application.Current.MainWindow);
        }

        //Screen shot function. Screenshot is save to C:\Surveilia\ScreenShots\, and the file is named after the exact time in .png format
        private void Screenshot(FrameworkElement element)
        {
            //If path doesn't exist, creates path 
            string path = @"C:\Surveilia\ScreenShots\";
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
