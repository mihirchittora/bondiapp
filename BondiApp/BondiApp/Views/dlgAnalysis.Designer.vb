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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnGetFile = New System.Windows.Forms.Button()
        Me.lblstatus = New System.Windows.Forms.Label()
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
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnGetFile
        '
        Me.btnGetFile.Location = New System.Drawing.Point(43, 42)
        Me.btnGetFile.Name = "btnGetFile"
        Me.btnGetFile.Size = New System.Drawing.Size(182, 54)
        Me.btnGetFile.TabIndex = 1
        Me.btnGetFile.Text = "Get File"
        Me.btnGetFile.UseVisualStyleBackColor = True
        '
        'lblstatus
        '
        Me.lblstatus.AutoSize = True
        Me.lblstatus.Location = New System.Drawing.Point(38, 198)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(107, 25)
        Me.lblstatus.TabIndex = 2
        Me.lblstatus.Text = "Last 300: "
        '
        'dlgAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 450)
        Me.Controls.Add(Me.lblstatus)
        Me.Controls.Add(Me.btnGetFile)
        Me.Controls.Add(Me.Cancel)
        Me.Name = "dlgAnalysis"
        Me.Text = "dlgAnalysis"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Cancel As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnGetFile As Button
    Friend WithEvents lblstatus As Label
End Class
