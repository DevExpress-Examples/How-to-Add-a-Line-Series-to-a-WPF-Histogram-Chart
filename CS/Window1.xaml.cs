using DevExpress.Xpf.Charts;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SideBySideBar2DChart {
    public partial class Window1 : Window {

        private Random random = new Random();
        public Window1() {
            InitializeComponent();
        }
    }

    public class ViewModel {
        public ObservableCollection<DataPoint> NormalDistribution { get; private set; }
        public ObservableCollection<DataPoint> Histogram { get; private set; }

        public ViewModel() {
            CreateDataSource();
        }

        private void CreateDataSource() {
            Random random = new Random();

            NormalDistribution = new ObservableCollection<DataPoint>();
            for(int x = 0; x < 1000; x++)
                NormalDistribution.Add(new DataPoint(x / 100.0, GetNormalDistribution(x / 100.0, 5, 1.5)));

            Histogram = new ObservableCollection<DataPoint>();
            for(int x = 0; x <= 100; x++)
                Histogram.Add(new DataPoint(x, random.Next(100)));
        }
        double GetNormalDistribution(double x, double mean, double std) {
            double tmp = 1 / ((Math.Sqrt(2 * Math.PI) * std));
            return Math.Exp(-Math.Pow((x - mean), 2) / (2 * Math.Pow(std, 2))) * tmp;
        }
    }
}
