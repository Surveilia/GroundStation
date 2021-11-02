using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

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
            int[] dataArray = new int[20];
            int Index = 20;
            string Directory = @"C:/Users/Ethan Pyle/Desktop/Test/Test1.txt";
            //array 2
            int[] dataArray2 = new int[20];
            string Directory2 = @"C:/Users/Ethan Pyle/Desktop/Test/Test2.txt";

            using (StreamReader x = new StreamReader(Directory))
            {
                for (int i = 0; i < Index; i++)
                {
                    dataArray[i] = int.Parse(x.ReadLine());
                }
            }

            using (StreamReader x = new StreamReader(Directory2))
            {
                for (int i = 0; i < Index; i++)
                {
                    dataArray2[i] = int.Parse(x.ReadLine());
                }
            }

            SeriesCollection = new SeriesCollection {};

            Labels = new[] { "Timestamp?" };
            YFormatter = value => value.ToString("C");

            //modifying the series collection will animate and update the chart
            SeriesCollection.Add(new LineSeries
            {
                Title = "Drone Data",
                Values = new ChartValues<int> { dataArray[0], dataArray[1], dataArray[2], dataArray[3], dataArray[4], dataArray[5], dataArray[6], dataArray[7], dataArray[8], dataArray[9], dataArray[10], dataArray[11], dataArray[12], dataArray[13], dataArray[14], dataArray[15], dataArray[16], dataArray[17], dataArray[18], dataArray[19]},
                LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                //PointGeometry = Geometry.Parse(),
                PointGeometrySize = 10,
                PointForeground = Brushes.Black
            });

            SeriesCollection.Add(new LineSeries
            {
                Title = "Drone Data 2",
                Values = new ChartValues<int> { dataArray2[0], dataArray2[1], dataArray2[2], dataArray2[3], dataArray2[4], dataArray2[5], dataArray2[6], dataArray2[7], dataArray2[8], dataArray2[9], dataArray2[10], dataArray2[11], dataArray2[12], dataArray2[13], dataArray2[14], dataArray2[15], dataArray2[16], dataArray2[17], dataArray2[18], dataArray2[19] },
                LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                //PointGeometry = Geometry.Parse(),
                PointGeometrySize = 10,
                PointForeground = Brushes.Black
            });

            //modifying any series values will also animate and update the chart
            //SeriesCollection[3].Values.Add(5d);

            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    }
}
