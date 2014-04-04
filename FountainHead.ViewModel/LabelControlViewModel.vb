
Imports System.ComponentModel
Imports FountainHead.ViewModel.Properties

Public Class LabelControlViewModel
    Implements INotifyPropertyChanged
    Sub New()
        propertiesValue = New LabelControlProperties()
        Me.propertiesValue = propertiesValue

        AddHandler PropertyChanged, AddressOf PropertyChangedHandler
    End Sub

    Private ReadOnly propertiesValue As LabelControlProperties
    Public ReadOnly Property Properties As LabelControlProperties
        Get
            Return propertiesValue
        End Get
    End Property

    Public Shared Instance As New LabelControlViewModel
    Private Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Private Sub PropertyChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        Select Case e.PropertyName
            Case "Left"
                RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("Left"))
        End Select
    End Sub
End Class