using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chart_Histogram_WPF {
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

