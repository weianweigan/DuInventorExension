Public Class DoubleComparer
    Implements IEqualityComparer(Of Double)

#Disable Warning BC40005 ' 成员隐藏基类型中的可重写的方法

    Public Function Equals(x As Double, y As Double) As Boolean Implements IEqualityComparer(Of Double).Equals

        Return DoubeleEqual(x, y)

    End Function

    Public Function GetHashCode(obj As Double) As Integer Implements IEqualityComparer(Of Double).GetHashCode

        Return obj.GetHashCode()

    End Function

#Enable Warning BC40005 ' 成员隐藏基类型中的可重写的方法

End Class
