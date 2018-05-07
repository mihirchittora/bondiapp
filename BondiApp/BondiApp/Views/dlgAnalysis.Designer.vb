<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAnalysis
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(927, 354)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(182, 54)
        Me.Cancel.TabIndex = 0
        Me.Cancel.Text = "Close"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'dlgAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 450)
        Me.Controls.Add(Me.Cancel)
        Me.Name = "dlgAnalysis"
        Me.Text = "dlgAnalysis"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Cancel As Button
End Class
