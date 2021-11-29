using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Wpf;
using ModernGUI_Surveilia.UserContent.Components;


/*
 * 
 *                                          -------------Graphing--------------
 * Written By: Chase Westlake
 * 
 * References: 
 * 
 * 
 * INDEX::::: 1. & 2. used for DisplayGraph()
 *      ::::: 3. & 4. used for Live Charts
 *      
 *      
 * 1.   StreamReader readline(): https://wellsb.com/csharp/beginners/streamreader-read-specific-line/
 *      Provides information on reading specific line
 * 
 * 2.   How to use StreamReader: https://thedeveloperblog.com/c-sharp/streamreader
 *
 * 
 * 3.  Live Chart Line Graph Sample: https://lvcharts.net/App/examples/v1/Wpf/Line
 * 
 * 4.  Live Chart performance recommendations: https://lvcharts.net/App/examples/v1/Wpf/Performance%20Tips
 *
 *
 *
 *  Description:    This program is the code required for graphing on the Surveilia Ground Station.
 *                  The graph recieves input from a text file specifying the x and y axis. The text file is read into a
 *                  multidimensional array. 
 *                  
 *                  The graph is instantiated at the opening of the program.
 *                  
 *                  
 *                  
 *                  
 *                  
 *              
*                                           -------------Timing--------------
*      Written by:     Chase Westlake
* 
*      Project:        Surveilia
* 
*
*      Description:    Test file for timed updates. Will be used to automatically update
*                      graphs with flight data.
* 
* 
* 
* 
* 
* 
* 
*                                           -------Graphing & Timing-------
* 
*       Written By:     Chase Westlake
*       
*       Project:        Surveilia
*       
*       Description:    Graphing & Timing allows the Surveilia Ground Station software to keep constant track of 
*                       the flight using graphing. The timing has been designed to work with WPF format and ignore
*                       certain conventions of event driven programming.
* 
* 
* 
* 
* 
*                                            ------- Data Handling -------
* 
*       Written by:     Chase Westlake
*       
*       Project:        Surveilia 
*       
*       Description:    Data handling is part of the packet structure. The ground station handles the reception and store to graphical interfaces.
*       
*       
*       Data file:      Must have index counted from the sender on the first line. This means, each time data is added to the text file,
*                       the first line must be incremented. The index must track all lines in the text file. That includes the line of the index.
*                       
*                       A possible solution on the trasmitter end is to used a linked list. Python uses expandable arrays. But if a lower level language
*                       is used, a linked list is advised.
*       
*       
*       
* 
* 
*                                            ---------- Next Steps -------
*                                   
*       TO DO LIST:

*                   - Make Live Chart Real Time https://www.scichart.com/documentation/win/current/Tutorial%2006%20-%20Adding%20Realtime%20Updates.html
*                                               https://stackoverflow.com/questions/40415298/how-do-i-correctly-update-my-chart-values-in-real-time 
*                   - Gyroscope cut from graphing
*       DO ON START:
*       
*                   - Check that all directories are correct
*                   - Check that all indices are correct
*                   
*                   
*/


namespace ModernGUI_Surveilia.UserContent.Views
{
    /// <summary>
    /// Interaction logic for StatsView.xaml
    /// </summary>
    public partial class StatsView : UserControl
    {

        //Directory for data
        string accDir = @"C:\Surveilia\Data\AccData.txt";
        //string gyrDir = @"C:\Surveilia\Data\GyroData.txt";

        public StatsView()
        {
            InitializeComponent();

            Loaded += StatsView_Loaded;
        }

        private void StatsView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //Initialize graphing
            GraphTool();


            //Initialize timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

            //When the timer is initiated, it calls statsTimer_Tick every iteration of it's time span. Currently set to 1 second.
            timer.Tick += statsTimer_Tick;
            timer.Start();
        }



        //Handles timing for stats model. 
        private void statsTimer_Tick(object sender, EventArgs e)
        {
            TickCount.Content = "Tick: " + MenuBar.instance.getTick();
            int currTick = Convert.ToInt16(TickCount.Content.ToString().Trim('T', 'i', 'c', 'k', ':', ' '));

            //updates graph every 30 seconds and increments count of lines for text file to determine the index for graph updates
            if (currTick % 4 == 0)
            {
                //This.DataContext = null refreshes the screen. Very sloppy.
                this.DataContext = null;
                //GraphTool();
                GraphTool();
            }
        }


        //Graphs the data file
        private void GraphTool()
        {

            try
            {
                //array to populate the integer
                int[] AccData = new int[getIndex(accDir)];
                //int[] GyrData = new int[getIndex(gyrDir)];

                //Fill data from text file. Use number generator for simplicity.
                using (StreamReader x = new StreamReader(accDir))
                {
                    x.ReadLine();
                    for (int i = 1; i < getIndex(accDir); i++)
                    {
                        AccData[i] = int.Parse(x.ReadLine());
                    }
                }
                //Fill data from text file. Use number generator for simplicity.
               /* using (StreamReader x = new StreamReader(gyrDir))
                {
                    x.ReadLine();
                    for (int i = 1; i < getIndex(gyrDir); i++)
                    {
                        GyrData[i] = int.Parse(x.ReadLine());
                    }
                }*/

                //Creates a new instance of the live chart. The data is not bound, so it is probably something to look into.
                SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Accelerometer Data",
                    Values = new ChartValues<int>()
                },
            };


                //Fill Graph 1 with text values.
                for (int i = 0; i < getIndex(accDir); i++)
                {
                    SeriesCollection[0].Values.Add(AccData[i]);
                    //SeriesCollection[1].Values.Add(GyrData[i]);
                }

                //Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };
                YFormatter = value => value.ToString("F");

                DataContext = this;
            }
            catch
            {
                
            }
            
        }
        //Gets index from first value in data file. Note, the directory is global
        private int getIndex(string path)
        {
            using (StreamReader index = new StreamReader(path))
            {
                return int.Parse(index.ReadLine());
            } 
        }


        //Not super sure what these do. They are bits of code I picked up along the way. They seem to be object declarations?
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        private Func<double, string> _yFormatter;
        public Func<double, string> YFormatter 
        {
            get { return _yFormatter; }
            set
            {
                _yFormatter = value;
            }
        }

        public Func<double, string> XFormatter { get; set; }
    }
}
