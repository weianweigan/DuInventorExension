
Imports Inventor
Imports XCHF.InventorExtension

''' <summary>
''' 代表了有向直线 也可能代表了圆弧
''' </summary>
Public Class VectorLine
    Public Sub New(startPoint As Func(Of DrawingCurve, Point2d), endPoint As Func(Of DrawingCurve, Point2d), pointFrom As Func(Of DrawingCurve, Point2d), semgent As DrawingCurve)
        Me.StartPoint = startPoint
        Me.EndPoint = endPoint
        Me.Segment = semgent
        Me.ContactPointFrom = pointFrom
    End Sub

    ''' <summary>
    ''' 起点
    ''' </summary>
    ''' <returns></returns>
    Public Property StartPoint As Func(Of DrawingCurve, Point2d)

    ''' <summary>
    ''' 终点
    ''' </summary>
    ''' <returns></returns>
    Public Property EndPoint As Func(Of DrawingCurve, Point2d)

    ''' <summary>
    ''' 此条直线与其他直线的连接点
    ''' </summary>
    ''' <returns></returns>
    Public Property ContactPointFrom As Func(Of DrawingCurve, Point2d)

    ''' <summary>
    ''' 实体
    ''' </summary>
    ''' <returns></returns>
    Public Property Segment As DrawingCurve

    ''' <summary>
    ''' 从终点指向起点的向量
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property LineDirection As Vector2d
        Get
            Return StartPoint?.Invoke(Segment).Copy().VectorTo(EndPoint?.Invoke(Segment))
        End Get
    End Property

    ''' <summary>
    ''' 获取绘制直线
    ''' </summary>
    ''' <param name="width">宽度,单位为cm,默认为16mm</param>
    ''' <returns>起点到终点的元组</returns>
    Public Function GetCutLinePoint(ByVal viewScale As Double, Optional ByVal width As Double = 1.6) As Tuple(Of Point2d, Point2d)

        If Segment.CurveType = CurveTypeEnum.kLineSegmentCurve Or Segment.CurveType = CurveTypeEnum.kLineCurve Then

            '终点作为起点
            Dim sPoint = EndPoint.Invoke(Segment)

            Dim ePoint As Point2d = sPoint.Copy()

            Dim direction = LineDirection

            Dim horLine = direction.Copy()
            horLine.X = 1
            horLine.Y = 0

            '计算投影长度,解算延长线
            Dim angle = direction.AsUnitVector().AngleTo(horLine.AsUnitVector())
            width = Math.Abs(width / Math.Cos(angle))

            direction.Normalize()
            direction.ScaleBy(width * viewScale)

            ePoint.X = sPoint.X + direction.X
            ePoint.Y = sPoint.Y + direction.Y

            Return New Tuple(Of Point2d, Point2d)(sPoint, ePoint)

        Else

            Throw New InvalidOperationException($"类型错误,当前类型为{Segment.CurveType},不是{CurveTypeEnum.kLineCurve}")

        End If

    End Function

    ''' <summary>
    ''' 获取三点圆弧
    ''' </summary>
    ''' <param name="viewScale">视图比例</param>
    ''' <param name="width">剪裁宽度</param>
    ''' <returns><see cref="Tuple(Of T1, T2, T3)"/> Item1 startpoint,Item2 endPoint,Item3 centerPoint</returns>
    Public Function GetCutArcThreePoint(ByVal viewScale As Double, Optional width As Double = 1.6) As Tuple(Of Point2d, Point2d, Point2d)

        If Segment.CurveType = CurveTypeEnum.kCircularArcCurve Then

            '圆心
            Dim center = Segment.CenterPoint
            '半径
            Dim radius = Segment.GetRadius()
            '终点作为起点
            Dim sPoint = EndPoint.Invoke(Segment)

            Dim ePoint As Point2d = sPoint.Copy()

            Dim direction = LineDirection

            Dim horLineDirection = direction.Copy()
            If StartPoint.Invoke(Segment).X > EndPoint.Invoke(Segment).X Then
                horLineDirection.X = -1
                horLineDirection.Y = 0
            Else
                horLineDirection.X = 1
                horLineDirection.Y = 0
            End If

            '往向量方向移动宽度为x值
            horLineDirection.ScaleBy(width * viewScale)
            ePoint.X = sPoint.X + horLineDirection.X

            ePoint.Y = Math.Sqrt(Math.Pow(radius, 2) - Math.Pow((ePoint.X - center.X), 2)) + center.Y



            Return New Tuple(Of Point2d, Point2d, Point2d)(sPoint, ePoint, center)


        Else

            Throw New InvalidOperationException($"类型错误,当前类型为{Segment.CurveType},不是{CurveTypeEnum.kCircularArcCurve}")

        End If

    End Function

End Class
