Imports System.Runtime.CompilerServices
Imports Inventor
Public Module DrawingViewExtension

#Region "视图包络盒位置"

    ''' <summary>
    ''' 视图左上角
    ''' </summary>
    ''' <param name="view"><see cref="DrawingView"/> interface</param>
    ''' <returns>视图左上角<see cref="Point2d"/></returns>
    <Extension>
    Public Function LeftTop(ByRef view As DrawingView) As Point2d

        Return GetViewBoxPoint(view, -view.Width / 2, view.Height / 2)

    End Function

    ''' <summary>
    ''' 视图左下角
    ''' </summary>
    ''' <param name="view"></param>
    ''' <returns></returns>
    <Extension>
    Public Function LeftDown(ByRef view As DrawingView) As Point2d

        Return GetViewBoxPoint(view, -view.Width / 2, -view.Height / 2)

    End Function

    ''' <summary>
    ''' 视图右上角的点
    ''' </summary>
    ''' <param name="view"><see cref="DrawingView"/></param>
    ''' <returns></returns>
    <Extension>
    Public Function RightTop(ByRef view As DrawingView) As Point2d

        Return GetViewBoxPoint(view, view.Width / 2, view.Height / 2)

    End Function

    <Extension>
    Public Function RightDown(ByRef view As DrawingView) As Point2d

        Return GetViewBoxPoint(view, view.Width / 2, -view.Height / 2)

    End Function

    ''' <summary>
    ''' 包络盒左边中心位置
    ''' </summary>
    ''' <param name="view"></param>
    ''' <returns></returns>
    <Extension>
    Public Function LeftCenter(ByRef view As DrawingView) As Point2d

        Return GetViewBoxPoint(view, -view.Width / 2, 0)

    End Function

    ''' <summary>
    ''' 包络盒右边中心位置
    ''' </summary>
    ''' <param name="view"></param>
    ''' <returns></returns>
    <Extension>
    Public Function RightCenter(ByRef view As DrawingView) As Point2d

        Return GetViewBoxPoint(view, view.Width / 2, 0)

    End Function

    ''' <summary>
    ''' 包络盒顶部中心位置
    ''' </summary>
    ''' <param name="view"></param>
    ''' <returns></returns>
    <Extension>
    Public Function TopCenter(ByRef view As DrawingView) As Point2d

        Return GetViewBoxPoint(view, 0, view.Height / 2)

    End Function

    ''' <summary>
    ''' 包络盒顶部中心位置
    ''' </summary>
    ''' <param name="view"></param>
    ''' <returns><see cref="Point2d"/></returns>
    <Extension>
    Public Function DownCenter(ByRef view As DrawingView) As Point2d

        Return GetViewBoxPoint(view, 0, -view.Height / 2)

    End Function

    ''' <summary>
    ''' 获取从视图中心便宜的距离
    ''' </summary>
    ''' <param name="view"><see cref="View"/> interface</param>
    ''' <param name="x">水平方向偏移距离</param>
    ''' <param name="y">竖直方向偏移距离</param>
    ''' <returns><see cref="Point2d"/></returns>
    Public Function GetViewBoxPoint(ByRef view As DrawingView, ByVal x As Double, ByVal y As Double)

        Dim centerpoint = view.Center.Copy()
        centerpoint.X += x
        centerpoint.Y += y

        Return centerpoint

    End Function

#End Region

    ''' <summary>
    ''' 判断点在视图左边还是右边,返回左中心点或者右中心点
    ''' </summary>
    ''' <param name="view"></param>
    ''' <param name="centerPoint"></param>
    ''' <returns></returns>
    <Extension>
    Public Function GetLeftOrRightPoint(ByRef view As DrawingView, ByVal centerPoint As Point2d, ByRef direc As Direction_e) As Point2d

        direc = IIf(centerPoint.X > view.Center.X, Direction_e.Right, Direction_e.Left)

        Return IIf(direc = Direction_e.Right, view.RightCenter, view.LeftCenter)

    End Function

    ''' <summary>
    ''' 判断点在视图上方还是下方,返回视图上方或者下方中心点
    ''' </summary>
    ''' <param name="view"></param>
    ''' <param name="centerPoint"></param>
    ''' <returns></returns>
    <Extension>
    Public Function GetTopOrDownPoint(ByRef view As DrawingView, ByVal centerPoint As Point2d, ByRef direc As Direction_e) As Point2d

        direc = IIf(centerPoint.Y > view.Center.Y, Direction_e.Top, Direction_e.Down)

        Return IIf(direc = Direction_e.Top, view.TopCenter, view.DownCenter)

    End Function

End Module

Public Enum Direction_e

    Top
    Down
    Left
    Right

End Enum
