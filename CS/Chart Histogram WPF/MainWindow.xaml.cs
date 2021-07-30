using DevExpress.Xpf.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Chart_Histogram_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow {
        public MainWindow() {
            InitializeComponent();
        }    
    }
    public class ViewModel {
        public ObservableCollection<Point> PointsCollection { get; private set; }

        public ViewModel() {
            PointsCollection = CreatePointsCollection(20);
        }
        ObservableCollection<Point> CreatePointsCollection(int count) {
            ObservableCollection<Point> seriesData = new ObservableCollection<Point>();
            Random random = new Random();
            for (int i = 0; i < count; i++) {
                int x = random.Next(1, 20);
                int y = random.Next(1, 20);
                seriesData.Add(new Point(x, y));
            }
            return seriesData;
        }
    }
}

