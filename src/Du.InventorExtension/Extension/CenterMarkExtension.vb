Imports System.Runtime.CompilerServices
Imports Inventor

Public Module CenterMarkExtension

    ''' <summary>
    ''' 创建几何对象
    ''' </summary>
    ''' <param name="centerMark"><see cref="Centermark"/> interface</param>
    ''' <param name="Sheet"><see cref="Sheet"/> interface</param>
    ''' <returns></returns>
    <Extension>
    Public Function GetGeometryIntent(ByRef centerMark As Centermark, ByRef Sheet As Sheet)

        Return Sheet.CreateGeometryIntent(centerMark)

    End Function

    ''' <summary>
    ''' 创建几何对象
    ''' </summary>
    ''' <param name="centerMark"><see cref="Centermark"/> interface</param>
    ''' <returns></returns>
    <Extension>
    Public Function GetGeometryIntent(ByRef centerMark As Centermark)

        Return centerMark.Parent.CreateGeometryIntent(centerMark)

    End Function

End Module
