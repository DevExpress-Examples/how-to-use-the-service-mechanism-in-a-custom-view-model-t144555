﻿Imports DevExpress.Mvvm
Imports System.Windows.Input

Namespace Example.ViewModel
    Public Class MainViewModel
        Implements ISupportServices


        Private serviceContainer_Renamed As IServiceContainer = Nothing
        Protected ReadOnly Property ServiceContainer() As IServiceContainer
            Get
                If serviceContainer_Renamed Is Nothing Then
                    serviceContainer_Renamed = New ServiceContainer(Me)
                End If
                Return serviceContainer_Renamed
            End Get
        End Property
        Private ReadOnly Property ISupportServices_ServiceContainer() As IServiceContainer Implements ISupportServices.ServiceContainer
            Get
                Return ServiceContainer
            End Get
        End Property
        Private ReadOnly Property MessageBoxService() As IMessageBoxService
            Get
                Return ServiceContainer.GetService(Of IMessageBoxService)()
            End Get
        End Property

        Private privateShowMessageCommand As ICommand
        Public Property ShowMessageCommand() As ICommand
            Get
                Return privateShowMessageCommand
            End Get
            Private Set(ByVal value As ICommand)
                privateShowMessageCommand = value
            End Set
        End Property
        Public Sub New()
            ShowMessageCommand = New DelegateCommand(AddressOf ShowMessage)
        End Sub
        Private Sub ShowMessage()
            MessageBoxService.Show("This is MainView!")
        End Sub
    End Class
End Namespace
