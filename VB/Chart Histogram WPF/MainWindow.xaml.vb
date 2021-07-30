Imports DevExpress.Xpf.Core
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace Chart_Histogram_WPF
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits ThemedWindow

		Public Sub New()
			InitializeComponent()
		End Sub
	End Class
	Public Class ViewModel
		Private privatePointsCollection As ObservableCollection(Of Point)
		Public Property PointsCollection() As ObservableCollection(Of Point)
			Get
				Return privatePointsCollection
			End Get
			Private Set(ByVal value As ObservableCollection(Of Point))
				privatePointsCollection = value
			End Set
		End Property
		Public Sub New()
			PointsCollection = CreatePointsCollection(20)
		End Sub
		Private Function CreatePointsCollection(ByVal count As Integer) As ObservableCollection(Of Point)
			Dim seriesData As New ObservableCollection(Of Point)()
			Dim random As New Random()
			For i As Integer = 0 To count - 1
				Dim x As Integer = random.Next(1, 20)
				Dim y As Integer = random.Next(1, 20)
				seriesData.Add(New Point(x, y))
			Next i
			Return seriesData
		End Function
	End Class
End Namespace

