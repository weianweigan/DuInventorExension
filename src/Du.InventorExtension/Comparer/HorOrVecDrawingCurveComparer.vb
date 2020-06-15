Imports Inventor

''' <summary>
''' 比较线条是否在同一位置
''' </summary>
''' 
Public Class HorOrVecDrawingCurveComparer
    Implements IEqualityComparer(Of Point2d)

    Private _state As Line2dState_e

    Public Sub New(ByVal state As Line2dState_e)
        _state = state
    End Sub

#Disable Warning BC40005 ' 成员隐藏基类型中的可重写的方法
    Public Function Equals(x As Point2d, y As Point2d) As Boolean Implements IEqualityComparer(Of Point2d).Equals

        If x Is Nothing Or y Is Nothing Then
            Return False
        End If

        Return IIf(_state = Line2dState_e.Hor, DoubeleEqual(x.Y, y.Y, 0.00001), DoubeleEqual(x.X, y.X, 1))

    End Function

    Public Function GetHashCode(obj As Point2d) As Integer Implements IEqualityComparer(Of Point2d).GetHashCode

        If obj Is Nothing Then
            Return 0
        End If

        Return IIf(_state = Line2dState_e.Hor, obj.Y, obj.X)

    End Function

#Enable Warning BC40005 ' 成员隐藏基类型中的可重写的方法

End Class

