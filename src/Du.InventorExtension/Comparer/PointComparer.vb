Imports Inventor

''' <summary>
''' 比较坐标是否相等
''' </summary>
Public Class PointComparer
    Implements IEqualityComparer(Of Point2d)

    Private _eplison As Double = 0.000001

    Public Sub New(Optional ByVal eplison As Double = 0.000001)

    End Sub

#Disable Warning BC40005 ' 成员隐藏基类型中的可重写的方法

    Public Function Equals(x As Point2d, y As Point2d) As Boolean Implements IEqualityComparer(Of Point2d).Equals

        If x Is Nothing Or y Is Nothing Then
            Return False
        End If

        Return DoubeleEqual(x.X, y.X, _eplison) And DoubeleEqual(x.Y, y.Y, _eplison)

    End Function

    Public Function GetHashCode(obj As Point2d) As Integer Implements IEqualityComparer(Of Point2d).GetHashCode

        If obj Is Nothing Then
            Return 0
        End If

        Return obj.GetHashCode()

    End Function

#Enable Warning BC40005 ' 成员隐藏基类型中的可重写的方法

End Class
