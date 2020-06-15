Imports System.Runtime.CompilerServices
Imports Inventor
Public Module DrawingCurveExtension

    ''' <summary>
    ''' 创建几何对象
    ''' </summary>
    ''' <param name="drawingCurve"><see cref="DrawingCurve"/> interface</param>
    ''' <param name="Sheet"><see cref="Sheet"/> interface</param>
    ''' <returns></returns>
    <Extension>
    Public Function GetGeometryIntent(ByRef drawingCurve As DrawingCurve, ByRef Sheet As Sheet)


        Return Sheet.CreateGeometryIntent(drawingCurve)

    End Function

    ''' <summary>
    ''' 获取直线上的一点的几何对象
    ''' </summary>
    ''' <param name="drawingCurve"></param>
    ''' <param name="Sheet"></param>
    ''' <param name="Intent"></param>
    ''' <returns></returns>
    <Extension>
    Public Function GetGeometryIntent(ByRef drawingCurve As DrawingCurve, ByRef Sheet As Sheet, Intent As Point2d)

        Return Sheet.CreateGeometryIntent(drawingCurve, Intent)

    End Function

    ''' <summary>
    ''' 创建几何对象
    ''' </summary>
    ''' <param name="drawingCurve"><see cref="DrawingCurve"/> interface</param>
    ''' <returns></returns>
    <Extension>
    Public Function GetGeometryIntent(ByRef drawingCurve As DrawingCurve)

        Return drawingCurve.Parent.Parent.CreateGeometryIntent(drawingCurve)

    End Function


    ''' <summary>
    ''' 作为扩展方法求半径
    ''' </summary>
    ''' <param name="dw"><see cref="DrawingCurve"/></param>
    ''' <returns></returns>
    <Extension>
    Public Function GetRadius(ByRef dw As DrawingCurve) As Double

        If dw.CurveType <> CurveTypeEnum.kCircularArcCurve Then
            Throw New InvalidOperationException($"类型:{dw.CurveType.ToString()} 不是圆弧,无法求直径")
        End If

        Return PointVertor2dHelper.GetRadius(dw.StartPoint, dw.MidPoint, dw.EndPoint)

    End Function

    <Extension>
    Public Function GetLineCenterPoint(ByRef dw As DrawingCurve) As Point2d

        If dw.CenterPoint Is Nothing Then

            Dim centeP = dw.StartPoint.Copy
            centeP.X = (dw.StartPoint.X + dw.EndPoint.X) / 2
            centeP.Y = (dw.StartPoint.Y + dw.EndPoint.Y) / 2

            Return centeP
        Else

            Return dw.CenterPoint

        End If



    End Function

End Module
