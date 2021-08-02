using DevExpress.Xpf.Charts;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SideBySideBar2DChart {

    public partial class Window1 : Window {

        private Random random = new Random();
        public Window1() {
            InitializeComponent();

            RandomDistribution = new ObservableCollection<DataPoint>();
            NormalDistribution = new ObservableCollection<DataPoint>();
            Histogram = new ObservableCollection<DataPoint>();

            UpdateData();

            Spline.ArgumentDataMember = "XValue";
            Spline.ValueDataMember = "YValue";
            Spline.DataSource = NormalDistribution;

            Bars.ArgumentDataMember = "XValue";
            Bars.ValueDataMember = "YValue";
            Bars.DataSource = Histogram;
        }

        public ObservableCollection<DataPoint> RandomDistribution { get; set; }
        public ObservableCollection<DataPoint> NormalDistribution { get; set; }
        public ObservableCollection<DataPoint> Histogram { get; set; }

        private void UpdateData() {
            NormalDistribution.Clear();
            RandomDistribution.Clear();
            Histogram.Clear();

            double mean = 5;
            double std = 1.5;

            for (int x = 0; x <= 10; x++) {
                RandomDistribution.Add(new DataPoint(x, GetNormalDistribution(x, mean, std)));
            }

            for (int x = 0; x < 100; x++) {
                NormalDistribution.Add(new DataPoint(x/10.0, GetNormalDistribution(x/10.0, mean, std)));
            }

            for (int x = 0; x <= 10; x++) {
                Histogram.Add(new DataPoint(x, random.Next(10)));
            }
        }

        private double GetNormalDistribution(double x, double mean, double std) {
            double tmp = 1 / ((Math.Sqrt(2 * Math.PI) * std));
            return Math.Exp(-Math.Pow((x - mean), 2) / (2 * Math.Pow(std, 2))) * tmp;
        }
    }
}
