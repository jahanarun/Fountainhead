Namespace Controls.Interface
    Public Interface IControl

        ReadOnly Property Properties As Object

        Event MClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        Event MDown(ByVal sender As Object, ByVal e As MouseEventArgs)
    End Interface
End Namespace