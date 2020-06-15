Imports Du.InventorExtension
Imports Inventor

Public Class Form1

    Public Property App As Application

    Public Sub New()
        InitializeComponent()
        If App Is Nothing Then
            App = InventorAppHelper.OApp
        End If
    End Sub

End Class
