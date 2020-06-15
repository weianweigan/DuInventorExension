Imports Inventor
''' <summary>
''' 选择相关的模块
''' </summary>
Public Class clsSelect
    Private bStillSelecting As Boolean
    Private WithEvents oInteractEvents As InteractionEvents
    Private WithEvents oSelectEvents As SelectEvents

    ''' <summary>
    ''' 拾取
    ''' </summary>
    ''' <param name="filter">类型</param>
    ''' <returns></returns>
    Public Function Pick(filter As SelectionFilterEnum) As Object

        bStillSelecting = True
        oInteractEvents = OApp.CommandManager.CreateInteractionEvents
        oInteractEvents.InteractionDisabled = False
        oSelectEvents = oInteractEvents.SelectEvents
        oSelectEvents.AddSelectionFilter(filter)
        oInteractEvents.Start()
        Do While bStillSelecting
            OApp.UserInterfaceManager.DoEvents()
        Loop
        Dim oSelectedEnts As ObjectsEnumerator
        oSelectedEnts = oSelectEvents.SelectedEntities
        If oSelectedEnts.Count > 0 Then
            Pick = oSelectedEnts.Item(1)
        Else
            Pick = Nothing
        End If
        oInteractEvents.Stop()
        oSelectEvents = Nothing
        oInteractEvents = Nothing
        Return Pick
    End Function

    Public Function PiclLst(filter As SelectionFilterEnum) As List(Of Object)
        Dim cc As List(Of Object) = New List(Of Object)

        For i = 1 To 5
            cc.Add(Pick(filter))
        Next

        Return cc
    End Function

    Private Sub aOnTerminate() Handles oInteractEvents.OnTerminate
        bStillSelecting = False
    End Sub

    Private Sub aOnSelect(JustSelectedEntities As ObjectsEnumerator, SelectionDevice As SelectionDeviceEnum,
          ModelPosition As Point, ViewPosition As Point2d, View As Inventor.View) Handles oSelectEvents.OnSelect
        bStillSelecting = False
    End Sub


End Class      '选择模型的类模块
