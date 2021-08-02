Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace SideBySideBar2DChart
	Public Class DataPoint
		Public Property XValue() As Double
		Public Property YValue() As Double

		Public Sub New(ByVal x As Double, ByVal y As Double)
			XValue = x
			YValue = y
		End Sub
	End Class
End Namespace
