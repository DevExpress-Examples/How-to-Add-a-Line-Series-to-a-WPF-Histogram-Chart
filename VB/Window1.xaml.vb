Imports System
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace SideBySideBar2DChart

    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub
    End Class

    Public Class ViewModel

        Private _NormalDistribution As ObservableCollection(Of SideBySideBar2DChart.DataPoint), _Histogram As ObservableCollection(Of SideBySideBar2DChart.DataPoint)

        Const HistogramPointsCount As Integer = 1000

        Const DistributionPointsCount As Integer = 100

        Const Mean As Double = 0.5

        Const StdDev As Double = 0.15

        Const Max As Double = 10

        Private random As Random = New Random()

        Public Property NormalDistribution As ObservableCollection(Of DataPoint)
            Get
                Return _NormalDistribution
            End Get

            Private Set(ByVal value As ObservableCollection(Of DataPoint))
                _NormalDistribution = value
            End Set
        End Property

        Public Property Histogram As ObservableCollection(Of DataPoint)
            Get
                Return _Histogram
            End Get

            Private Set(ByVal value As ObservableCollection(Of DataPoint))
                _Histogram = value
            End Set
        End Property

        Public ReadOnly Property MinValue As Double
            Get
                Return 0
            End Get
        End Property

        Public ReadOnly Property MaxValue As Double
            Get
                Return Max
            End Get
        End Property

        Public ReadOnly Property BinCount As Double
            Get
                Return 20
            End Get
        End Property

        Public Sub New()
            CreateDataSource()
        End Sub

        Private Sub CreateDataSource()
            NormalDistribution = New ObservableCollection(Of DataPoint)()
            For i As Integer = 0 To DistributionPointsCount - 1
                Dim x As Double = i * Max / DistributionPointsCount
                NormalDistribution.Add(New DataPoint(x, GetNormalDistribution(x, Mean * Max, StdDev * Max)))
            Next

            Histogram = New ObservableCollection(Of DataPoint)()
            For x As Integer = 0 To HistogramPointsCount - 1
                Histogram.Add(New DataPoint(GenerateHistogramPoint(Mean * Max, StdDev * Max)))
            Next
        End Sub

        Private Function GetNormalDistribution(ByVal x As Double, ByVal mean As Double, ByVal stdDev As Double) As Double
            Dim tmp As Double = 1 / (Math.Sqrt(2 * Math.PI) * stdDev)
            Return Math.Exp(-Math.Pow(x - mean, 2) / (2 * Math.Pow(stdDev, 2))) * tmp
        End Function

        Private Function GenerateHistogramPoint(ByVal mean As Double, ByVal stdDev As Double) As Double
            Return Math.Sqrt(-2 * Math.Log(random.NextDouble())) * Math.Cos(2 * Math.PI * random.NextDouble()) * stdDev + mean
        End Function
    End Class
End Namespace
