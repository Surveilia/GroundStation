using System;
using System.IO;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;


/*
 * 
*                                           -------------Graphing--------------
 * Written By: Ben Kennedy & Chase Westlake & Ethan Pyle
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
*       TO DO LIST:
*                   
*                   - Integrate timer and graphing tool
*                   - Ensure that the graph uploads brand new when the stats panel is opened
*                   - Ensure that there are accurate tallies of the length of text files being read to graph
*                   - Ensure that graph 2 can successfully read it's own data (if graph 2 is used)
*                   - Graph the x and y axis with appropriate text files
*       
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

        int listIndex = 10;

        public StatsView()
        {
            InitializeComponent();
            //array to populate the integer

            int[] dataArray = new int[listIndex];
            string Directory = @"D:\School\Year3\GroundStation\GraphingTest\yAxis.txt";
            //array 2
            int[] dataArray2 = new int[listIndex];
            string Directory2 = @"D:\School\Year3\GroundStation\GraphingTest\xAxis.txt";

            using (StreamReader x = new StreamReader(Directory))
            {
                for (int i = 0; i < listIndex; i++)
                {
                    dataArray[i] = int.Parse(x.ReadLine());
                }
            }

            using (StreamReader x = new StreamReader(Directory2))
            {
                for (int i = 0; i < listIndex; i++)
                {
                    dataArray2[i] = int.Parse(x.ReadLine());
                }
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Graph1",
                    Values = new ChartValues<int>()
                },

                new LineSeries
                {
                    Title = "Graph2",
                    Values = new ChartValues<int>(),
                    PointGeometry = null
                },
            };

            for (int i = 0; i < listIndex; i++)
            {
                SeriesCollection[0].Values.Add(dataArray[i]);
            }

            for (int i = 0; i < listIndex; i++)
            {
                SeriesCollection[1].Values.Add(dataArray2[i]);
            }


            Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            YFormatter = value => value.ToString("C");

            //modifying the series collection will animate and update the chart
           /* SeriesCollection.Add(new LineSeries
            {
                Title = "Series 4",
                Values = new ChartValues<double> { 5, 3, 2, 4 },
                LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 50,
                PointForeground = Brushes.Gray
            });
           */





            /*
            //modifying the series collection will animate and update the chart
            SeriesCollection.Add(new LineSeries
            {
                Title = "Drone Data",
                Values = new ChartValues<int>(),
                LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                //PointGeometry = Geometry.Parse(),
                PointGeometrySize = 10,
                PointForeground = Brushes.Black
            });

            SeriesCollection.Add(new LineSeries
            {
                Title = "Drone Data 2",
                Values2 = new ChartValues<int>(),
                
                LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                //PointGeometry = Geometry.Parse(),
                PointGeometrySize = 10,
                PointForeground = Brushes.Black
            });*/
            //modifying any series values will also animate and update the chart
            //SeriesCollection[3].Values.Add(5d);

            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    }
}
