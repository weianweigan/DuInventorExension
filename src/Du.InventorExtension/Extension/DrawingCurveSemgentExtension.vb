Imports System.Runtime.CompilerServices
Imports Inventor
Public Module DrawingCurveSemgentExtension

    ''' <summary>
    ''' 创建标注用几何对象
    ''' </summary>
    ''' <param name="drawingCurveSe"><see cref="DrawingCurveSegment"/> interface</param>
    ''' <param name="sheet"><see cref="Sheet"/> interface</param>
    ''' <returns></returns>
    <Extension>
    Public Function GetGeometryIntent(ByRef drawingCurveSe As DrawingCurveSegment, Optional ByRef sheet As Sheet = Nothing) As GeometryIntent

        sheet = IIf(sheet Is Nothing, drawingCurveSe.Parent.Parent.Parent.Parent, sheet)

        Return sheet.CreateGeometryIntent(drawingCurveSe)

    End Function

End Module
