
Imports System.Runtime.CompilerServices
Imports Inventor

Public Module SketchLineExtension

    ''' <summary>
    ''' 创建几何对象
    ''' </summary>
    ''' <param name="skeLine"><see cref="SketchLine"/></param>
    ''' <param name="Sheet"><see cref="Sheet"/></param>
    ''' <returns><see cref="GeometryIntent"/></returns>
    <Extension>
    Public Function GetGeometryIntent(ByRef skeLine As SketchLine, ByRef Sheet As Sheet) As GeometryIntent

        Return Sheet.CreateGeometryIntent(skeLine)

    End Function


End Module
