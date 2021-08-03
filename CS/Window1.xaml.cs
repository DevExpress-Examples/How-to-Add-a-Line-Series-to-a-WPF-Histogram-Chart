using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SideBySideBar2DChart {
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
        }
    }

    public class ViewModel {
        const int HistogramPointsCount = 1000;
        const int DistributionPointsCount = 100;
        const double Mean = 0.5;
        const double StdDev = 0.15;
        const double Max = 10;

        Random random = new Random();

        public ObservableCollection<DataPoint> NormalDistribution { get; private set; }
        public ObservableCollection<DataPoint> Histogram { get; private set; }
        public double MinValue { get { return 0; } }
        public double MaxValue { get { return Max; } }
        public double BinCount { get { return 20; } }

        public ViewModel() {
            CreateDataSource();
        }
        void CreateDataSource() {
            NormalDistribution = new ObservableCollection<DataPoint>();
            for(int i = 0; i < DistributionPointsCount; i++) {
                double x = i * Max / DistributionPointsCount;
                NormalDistribution.Add(new DataPoint(x, GetNormalDistribution(x, Mean * Max, StdDev * Max)));
            }
            Histogram = new ObservableCollection<DataPoint>();
            for(int x = 0; x < HistogramPointsCount; x++)
                Histogram.Add(new DataPoint(GenerateHistogramPoint(Mean * Max, StdDev * Max)));
        }
        double GetNormalDistribution(double x, double mean, double stdDev) {
            double tmp = 1 / (Math.Sqrt(2 * Math.PI) * stdDev);
            return Math.Exp(-Math.Pow(x - mean, 2) / (2 * Math.Pow(stdDev, 2))) * tmp;
        }
        double GenerateHistogramPoint(double mean, double stdDev) {
            return Math.Sqrt(-2 * Math.Log(random.NextDouble())) * Math.Cos(2 * Math.PI * random.NextDouble()) * stdDev + mean;
        }
    }
}
