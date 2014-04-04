Imports System.ComponentModel

Namespace Properties

    <DefaultPropertyAttribute("Text"), _
DescriptionAttribute("Control Properties")> _
    Public Class LabelControlProperties
        Implements INotifyPropertyChanged

#Region "Properties"
        Private _text As String
        <CategoryAttribute("Control"), _
           Browsable(True), _
           [ReadOnly](False), _
           BindableAttribute(False), _
           DefaultValueAttribute(""), _
           DesignOnly(False), _
           DescriptionAttribute("Enter Text value for Control")> _
        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
                RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("Left"))
            End Set
        End Property

        Private leftValue As Integer
        <CategoryAttribute("Control"), _
           Browsable(True), _
           [ReadOnly](False), _
           BindableAttribute(False), _
           DefaultValueAttribute(""), _
           DesignOnly(False), _
           DescriptionAttribute("Enter Left position")> _
        Public Property Left() As Integer
            Get
                Return leftValue
            End Get
            Set(ByVal value As Integer)
                leftValue = value
                RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("Left"))
            End Set
        End Property

#End Region

#Region "Events"
        Private Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
#End Region
    End Class

End Namespace