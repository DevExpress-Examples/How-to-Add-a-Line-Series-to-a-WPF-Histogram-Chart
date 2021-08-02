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

			RandomDistribution = New ObservableCollection(Of DataPoint)()
			NormalDistribution = New ObservableCollection(Of DataPoint)()
			Histogram = New ObservableCollection(Of DataPoint)()

			UpdateData()

			Spline.ArgumentDataMember = "XValue"
			Spline.ValueDataMember = "YValue"
			Spline.DataSource = NormalDistribution

			Bars.ArgumentDataMember = "XValue"
			Bars.ValueDataMember = "YValue"
			Bars.DataSource = Histogram
		End Sub

		Public Property RandomDistribution() As ObservableCollection(Of DataPoint)
		Public Property NormalDistribution() As ObservableCollection(Of DataPoint)
		Public Property Histogram() As ObservableCollection(Of DataPoint)

		Private Sub UpdateData()
			NormalDistribution.Clear()
			RandomDistribution.Clear()
			Histogram.Clear()

			Dim mean As Double = 5
			Dim std As Double = 1.5

			For x As Integer = 0 To 10
				RandomDistribution.Add(New DataPoint(x, GetNormalDistribution(x, mean, std)))
			Next x

			For x As Integer = 0 To 99
				NormalDistribution.Add(New DataPoint(x/10.0, GetNormalDistribution(x/10.0, mean, std)))
			Next x

			For x As Integer = 0 To 10
				Histogram.Add(New DataPoint(x, random.Next(10)))
			Next x
		End Sub

		Private Function GetNormalDistribution(ByVal x As Double, ByVal mean As Double, ByVal std As Double) As Double
'INSTANT VB WARNING: Instant VB cannot determine whether both operands of this division are integer types - if they are then you should use the VB integer division operator:
			Dim tmp As Double = 1 / ((Math.Sqrt(2 * Math.PI) * std))
			Return Math.Exp(-Math.Pow((x - mean), 2) / (2 * Math.Pow(std, 2))) * tmp
		End Function
	End Class
End Namespace
