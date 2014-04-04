Imports System.Windows.Forms
Imports System.ComponentModel
Imports FountainHead.ViewModel
Imports FountainHead.ViewModel.Properties
Imports FountainHead.Controls.Interface

Namespace Controls

    Public Class LabelControl
        Implements IControl
        Implements INotifyPropertyChanged
#Region "Constructors"
        Public Sub New(ByVal vm As LabelControlViewModel)
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            viewModelValue = vm
            BindControl()
            AddHandler PropertyChanged, AddressOf PropertyChangedHandler
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Properties As Object Implements IControl.Properties
            Get
                Return ViewModel.Properties
            End Get
        End Property

        Private viewModelValue As LabelControlViewModel
        Public Property ViewModel() As LabelControlViewModel
            Get
                Return viewModelValue
            End Get
            Set(ByVal value As LabelControlViewModel)
                viewModelValue = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("ViewModel"))
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub BindControl()
            lblText.DataBindings.Clear()
            lblText.DataBindings.Add(New Binding("Text", Me.Properties, "Text", True, DataSourceUpdateMode.OnPropertyChanged))
        End Sub
#End Region

#Region "Events Handlers"

        Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Click
            RaiseEvent MClick(Me, e)
        End Sub

        Private Sub PropertyChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            Select Case e.PropertyName
                Case "ViewModel"
                    BindControl()
                Case "Left"
                    Left = ViewModel.Properties.Left
            End Select
        End Sub

        Private Sub Panel1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
            RaiseEvent MDown(Me, e)
        End Sub

#End Region
        Public Event MClick(ByVal sender As Object, ByVal e As MouseEventArgs) Implements IControl.MClick
        Public Event MDown(ByVal sender As Object, ByVal e As MouseEventArgs) Implements IControl.MDown
        Private Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    End Class
End Namespace