Imports System.ComponentModel

Public Class ViewModel
    Implements INotifyPropertyChanged

    Private GameBoard = New Model.Model()

    Public Sub New()
    End Sub

    Public Sub NewGameCommand()

    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler _
        Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(ByVal propertyName As String)

    End Sub

End Class
