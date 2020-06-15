Imports System.Runtime.CompilerServices
Imports Inventor

Public Module PointVertor2dHelper

    ''' <summary>
    ''' 获取中点
    ''' </summary>
    ''' <param name="startPoint">起点 <see cref="Point2d"/></param>
    ''' <param name="endPoint">终点 <see cref="Point2d"/></param>
    ''' <returns>中点 <see cref="Point2d"/></returns>
    <Extension>
    Public Function GetMiddlePoint(ByVal startPoint As Point2d, ByVal endPoint As Point2d) As Point2d

        Dim midPoint = startPoint.Copy()

        midPoint.X = (startPoint.X + endPoint.X) / 2
        midPoint.Y = (startPoint.Y + endPoint.Y) / 2

        Return midPoint
    End Function

    ''' <summary>
    ''' 判断水平还是垂直
    ''' </summary>
    ''' <param name="startPoint">起点 <see cref="Point2d"/></param>
    ''' <param name="endPoint">终点 <see cref="Point2d"/></param>
    ''' <returns>水平 竖直 或者不是 <see cref="Line2dState_e"/></returns>
    <Extension>
    Public Function HorOrVec(ByRef startPoint As Point2d, ByRef endPoint As Point2d) As Line2dState_e

        Dim x = startPoint.X - endPoint.X
        Dim y = startPoint.Y - endPoint.Y

        If DoubeleEqual(x, 0) Then
            Return Line2dState_e.Vec
        End If

        If DoubeleEqual(y, 0) Then
            Return Line2dState_e.Hor
        End If

        Return Line2dState_e.None

    End Function

    ''' <summary>
    ''' 根据 <see cref="DrawingCurve"/> 判断直线水平还是竖直
    ''' </summary>
    ''' <param name="draCurve"><see cref="DrawingCurve"/></param>
    ''' <returns><see cref="Line2dState_e"/></returns>
    <Extension>
    Public Function HorOrVec(ByRef draCurve As DrawingCurve) As Line2dState_e

        If draCurve.CurveType <> CurveTypeEnum.kLineSegmentCurve Then
            Throw New InvalidOperationException($"不能在非直线曲线中使用此方法")
        End If

        Return HorOrVec(draCurve.StartPoint, draCurve.EndPoint)

    End Function

    ''' <summary>
    ''' 判断Double值是否相等
    ''' </summary>
    ''' <param name="first">第一个值</param>
    ''' <param name="second">第二个值</param>
    ''' <param name="e">精度 默认为 0.000001</param>
    ''' <returns></returns>
    Public Function DoubeleEqual(ByVal first As Double, ByVal second As Double, Optional ByVal e As Double = 0.000001) As Boolean

        Return IIf(Math.Abs(first - second) < e, True, False)

    End Function

    ''' <summary>
    ''' 三点求圆心
    ''' </summary>
    ''' <param name="one">第一点</param>
    ''' <param name="two">第二点</param>
    ''' <param name="three">第三点</param>
    ''' <returns></returns>
    Public Function GetRadius(ByVal one As Point2d, ByVal two As Point2d, three As Point2d) As Double

        Dim a = one.X - two.X
        Dim b = one.Y - two.Y
        Dim c = one.X - three.X
        Dim d = one.Y - three.Y
        Dim e = ((one.X * one.X - two.X * two.X) + (one.Y * one.Y - two.Y * two.Y)) / 2
        Dim f = ((one.X * one.X - three.X * three.X) + (one.Y * one.Y - three.Y * three.Y)) / 2
        Dim det = b * c - a * d

        If DoubeleEqual(Math.Abs(det), 0) Then
            Throw New InvalidOperationException($"当前三点共线,无法求出半径")
        End If

        Dim x0 = -(d * e - b * f) / det
        Dim y0 = -(a * f - c * e) / det

        Dim circle = one.Copy()
        circle.X = x0
        circle.Y = y0

        Return one.DistanceTo(circle)

    End Function



End Module

Public Enum Line2dState_e

    Hor
    Vec
    None

End Enum