Namespace SideBySideBar2DChart
	Public Class DataPoint
		Public Property XValue() As Double
		Public Property YValue() As Double

		Public Sub New(ByVal x As Double, ByVal y As Double)
			XValue = x
			YValue = y
		End Sub
		Public Sub New(ByVal value As Double)
			Me.New(value, value)
		End Sub
	End Class
End Namespace
