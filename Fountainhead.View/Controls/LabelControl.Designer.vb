Namespace Controls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class LabelControl
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lblText = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.lblText)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(3, 3)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(221, 99)
            Me.Panel1.TabIndex = 4
            '
            'lblText
            '
            Me.lblText.AutoSize = True
            Me.lblText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblText.Location = New System.Drawing.Point(114, 40)
            Me.lblText.Name = "lblText"
            Me.lblText.Size = New System.Drawing.Size(63, 20)
            Me.lblText.TabIndex = 5
            Me.lblText.Text = "Label2"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(24, 40)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(48, 13)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "My Text:"
            '
            'LabelControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.Panel1)
            Me.Name = "LabelControl"
            Me.Size = New System.Drawing.Size(225, 104)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents lblText As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label

    End Class
End Namespace