Imports System.Runtime.InteropServices
Imports Inventor

Public Module InventorAppHelper

    Private _oApp As Application

    Public ReadOnly Property OApp As Application
        Get

            If _oApp Is Nothing Then

                _oApp = Marshal.GetActiveObject("Inventor.Application")

            End If

            Return _oApp

        End Get
    End Property

End Module
