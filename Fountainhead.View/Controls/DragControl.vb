Imports System.Drawing.Drawing2D
Imports FountainHead.Controls.Interface

Namespace Controls
    Public Class DragControl
        Private mainForm As Control = Nothing
        Private controlImage As Rectangle
        Private controlDragStarted As Boolean = False
        Private controlUnderDrag As Control = Nothing
        Private mouseOffset As Size

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            mainForm = TopLevelControl
            Me.Hide()
        End Sub

        Public Sub SetDesignMode(ByVal state As Boolean)
            mainForm = TopLevelControl
            Dim ctrl As Control = mainForm.GetNextControl(Nothing, True) 'Get First Control
            Do
                If ctrl.GetType = GetType(LabelControl) Then
                    SetEvent(ctrl, state)
                End If
                ctrl = mainForm.GetNextControl(ctrl, True)
            Loop While ctrl IsNot Nothing

            If state Then
                AddHandler mainForm.Paint, AddressOf mainForm_Paint
                AddHandler mainForm.MouseMove, AddressOf mainForm_MouseMove
                AddHandler mainForm.MouseUp, AddressOf mainForm_MouseUp
            Else
                RemoveHandler mainForm.Paint, AddressOf mainForm_Paint
                RemoveHandler mainForm.MouseMove, AddressOf mainForm_MouseMove
                RemoveHandler mainForm.MouseUp, AddressOf mainForm_MouseUp

            End If
        End Sub

        Private Sub SetEvent(ByVal ctrl As IControl, ByVal state As Boolean)
            If state Then
                AddHandler ctrl.MDown, AddressOf ctrl_MouseDown
            Else
                RemoveHandler ctrl.MDown, AddressOf ctrl_MouseDown
            End If
        End Sub

        Public Sub ctrl_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            If e.Button = MouseButtons.Right Then
                'find out which control is being dragged
                controlUnderDrag = mainForm.GetChildAtPoint(CType(sender, Control).Location + New Size(e.Location.X, e.Location.Y))
                If controlUnderDrag IsNot Nothing Then
                    mainForm.Capture = True ' capture mouse
                    mainForm.Cursor = Cursors.Hand

                    controlImage = New Rectangle(controlUnderDrag.Location, controlUnderDrag.Size)
                    mouseOffset = New Size(e.Location.X, e.Location.Y)

                    Dim tempRectangle As Rectangle = New Rectangle(controlImage.X - 2, controlImage.Y - 2, controlImage.Width + 4, controlImage.Height + 4)
                    Dim myGraphicsPath As GraphicsPath = New GraphicsPath()
                    myGraphicsPath.AddRectangle(tempRectangle)
                    Dim rgn As Region = New Region(myGraphicsPath)
                    mainForm.Invalidate(rgn)

                    controlDragStarted = True

                End If

            End If
        End Sub

        Public Sub mainForm_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
            If controlImage <> Nothing AndAlso controlDragStarted Then
                e.Graphics.DrawRectangle(Pens.Green, controlImage)
            End If
        End Sub

        Public Sub mainForm_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            If controlDragStarted Then

                Dim myGraphicsPath As GraphicsPath = New GraphicsPath()
                Dim tempRectangle As Rectangle = New Rectangle(controlImage.X - 2, controlImage.Y - 2, controlImage.Width + 4, controlImage.Height + 4)
                myGraphicsPath.AddRectangle(tempRectangle)
                Dim rgn = New Region(myGraphicsPath)

                controlImage = New Rectangle(e.Location.X - mouseOffset.Width, e.Location.Y - mouseOffset.Height, controlImage.Width, controlImage.Height)

                mainForm.Invalidate(rgn)

                myGraphicsPath.Dispose()
                myGraphicsPath = New GraphicsPath()
                rgn.Dispose()
                tempRectangle = New Rectangle(controlImage.X - 2, controlImage.Y - 2, controlImage.Width + 4, controlImage.Height + 4)
                rgn = New Region(tempRectangle)
                mainForm.Invalidate(rgn)

            End If
        End Sub

        Public Sub mainForm_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
            If e.Button = MouseButtons.Right AndAlso controlDragStarted Then
                controlDragStarted = False
                mainForm.Capture = False
                mainForm.Cursor = Cursors.Default

                Dim myGraphicsPath = New GraphicsPath()
                Dim tempRectangle = New Rectangle(controlImage.X - 2, controlImage.Y - 2, controlImage.Width + 4, controlImage.Height + 4)
                myGraphicsPath.AddRectangle(tempRectangle)
                Dim rgn = New Region(myGraphicsPath)

                controlUnderDrag.Location = controlImage.Location
                controlImage.Height = 0
                controlImage.Width = 0
                mainForm.Invalidate(rgn)

                controlUnderDrag.Invalidate()

            End If
        End Sub
    End Class
End Namespace