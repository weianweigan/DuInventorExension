
Imports System.Runtime.CompilerServices
Imports Inventor

Public Module PlanarSketchExtension

    ''' <summary>
    ''' 编辑草图,绘制
    ''' </summary>
    ''' <param name="sketch"><see cref="PlanarSketch"/></param>
    ''' <param name="action">需要做的操作</param>
    ''' <param name="isExitWhenFinished">绘制完成后是否关闭草图</param>
    <Extension>
    Public Sub EditFor(ByRef sketch As PlanarSketch, action As Action(Of PlanarSketch), Optional isExitWhenFinished As Boolean = True)

        sketch.Edit()

        action?.Invoke(sketch)

        If isExitWhenFinished Then
            sketch.ExitEdit()
        End If

    End Sub


End Module
