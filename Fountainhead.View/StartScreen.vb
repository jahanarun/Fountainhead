
Imports System.ComponentModel
Imports FountainHead.Controls
Imports FountainHead.Controls.Interface
Imports FountainHead.ViewModel

Public Class StartScreen
    Implements INotifyPropertyChanged
    Private labelControlCollection() As LabelControlViewModel
    Private labelControlCount As Integer = 0
    Private _left As Integer = 200

#Region "Properties"
    Private designModeValue As Boolean = True
    Public Property IsDesignMode As Boolean
        Get
            Return designModeValue
        End Get
        Set(ByVal value As Boolean)
            designModeValue = value
            RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("DesignMode"))
        End Set
    End Property
#End Region

#Region "Control Common Methods"

    Private Overloads Sub CreateControl(ByVal sender As Type)
        Dim myControl As UserControl

        Select Case sender
            Case GetType(LabelControl)
                ReDim Preserve labelControlCollection(labelControlCount)
                'Adding control to the Array
                labelControlCollection(labelControlCount) = New LabelControlViewModel
                myControl = New LabelControl(labelControlCollection(labelControlCount))
                myControl.Left = _left
                myControl.Top = 200
                _left += 100

                labelControlCount += 1
        End Select

        Me.Controls.Add(myControl)
        ctrlAddHandlers(myControl)
        myControl.BringToFront()
    End Sub

    Private Sub ctrlAddHandlers(ByRef ctrl As IControl)
        AddHandler ctrl.MClick, AddressOf ctrl_Click
        DragControl1.SetDesignMode(IsDesignMode)
    End Sub

    Private Sub ctrl_Click(ByVal sender As Object, ByVal e As MouseEventArgs)
        gridProperty.SelectedObject = sender.Properties
    End Sub
#End Region

#Region "Events Handlers"
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        CreateControl(GetType(LabelControl))
    End Sub

    Private Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Private Sub PropertyChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        Select Case e.PropertyName
            Case "DesignMode"
                DragControl1.SetDesignMode(IsDesignMode)
        End Select
    End Sub

    Private Sub StartScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler PropertyChanged, AddressOf PropertyChangedHandler
        IsDesignMode = True
    End Sub

#End Region



End Class
