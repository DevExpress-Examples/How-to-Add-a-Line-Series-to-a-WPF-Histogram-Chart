Imports DevExpress.Xpf.Charts
Imports System
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace SideBySideBar2DChart
	Partial Public Class Window1
		Inherits Window

		Private random As New Random()
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class

	Public Class ViewModel
		Private privateNormalDistribution As ObservableCollection(Of DataPoint)
		Public Property NormalDistribution() As ObservableCollection(Of DataPoint)
			Get
				Return privateNormalDistribution
			End Get
			Private Set(ByVal value As ObservableCollection(Of DataPoint))
				privateNormalDistribution = value
			End Set
		End Property
		Private privateHistogram As ObservableCollection(Of DataPoint)
		Public Property Histogram() As ObservableCollection(Of DataPoint)
			Get
				Return privateHistogram
			End Get
			Private Set(ByVal value As ObservableCollection(Of DataPoint))
				privateHistogram = value
			End Set
		End Property

		Public Sub New()
			CreateDataSource()
		End Sub

		Private Sub CreateDataSource()
			Dim random As New Random()

			NormalDistribution = New ObservableCollection(Of DataPoint)()
			For x As Integer = 0 To 999
				NormalDistribution.Add(New DataPoint(x / 100.0, GetNormalDistribution(x / 100.0, 5, 1.5)))
			Next x

			Histogram = New ObservableCollection(Of DataPoint)()
			For x As Integer = 0 To 100
				Histogram.Add(New DataPoint(x, random.Next(100)))
			Next x
		End Sub
		Private Function GetNormalDistribution(ByVal x As Double, ByVal mean As Double, ByVal std As Double) As Double
'INSTANT VB WARNING: Instant VB cannot determine whether both operands of this division are integer types - if they are then you should use the VB integer division operator:
			Dim tmp As Double = 1 / ((Math.Sqrt(2 * Math.PI) * std))
			Return Math.Exp(-Math.Pow((x - mean), 2) / (2 * Math.Pow(std, 2))) * tmp
		End Function
	End Class
End Namespace
