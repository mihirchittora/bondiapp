<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgHarvestBacktest
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbWillie = New System.Windows.Forms.ComboBox()
        Me.lstOHLC = New System.Windows.Forms.ListBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnClearList = New System.Windows.Forms.Button()
        Me.btnReadBacktest = New System.Windows.Forms.Button()
        Me.dtpBackDate = New System.Windows.Forms.DateTimePicker()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnStartBackTest = New System.Windows.Forms.Button()
        Me.txtSymbol = New System.Windows.Forms.TextBox()
        Me.txtLoadSymbol = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(796, 35)
        Me.Panel1.TabIndex = 86
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(18, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(180, 24)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Willie Trading Robot"
        '
        'cmbWillie
        '
        Me.cmbWillie.FormattingEnabled = True
        Me.cmbWillie.Location = New System.Drawing.Point(15, 166)
        Me.cmbWillie.Name = "cmbWillie"
        Me.cmbWillie.Size = New System.Drawing.Size(159, 21)
        Me.cmbWillie.TabIndex = 90
        '
        'lstOHLC
        '
        Me.lstOHLC.FormattingEnabled = True
        Me.lstOHLC.Location = New System.Drawing.Point(438, 151)
        Me.lstOHLC.Name = "lstOHLC"
        Me.lstOHLC.Size = New System.Drawing.Size(231, 186)
        Me.lstOHLC.TabIndex = 91
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(18, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(218, 24)
        Me.Label16.TabIndex = 92
        Me.Label16.Text = "Back Test Control Center"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblStatus)
        Me.Panel5.Location = New System.Drawing.Point(0, 371)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(796, 31)
        Me.Panel5.TabIndex = 93
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(12, 10)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(80, 13)
        Me.lblStatus.TabIndex = 68
        Me.lblStatus.Text = "status message"
        '
        'btnClearList
        '
        Me.btnClearList.Location = New System.Drawing.Point(15, 343)
        Me.btnClearList.Name = "btnClearList"
        Me.btnClearList.Size = New System.Drawing.Size(81, 23)
        Me.btnClearList.TabIndex = 94
        Me.btnClearList.Text = "Clear "
        Me.btnClearList.UseVisualStyleBackColor = True
        '
        'btnReadBacktest
        '
        Me.btnReadBacktest.Location = New System.Drawing.Point(185, 86)
        Me.btnReadBacktest.Name = "btnReadBacktest"
        Me.btnReadBacktest.Size = New System.Drawing.Size(117, 20)
        Me.btnReadBacktest.TabIndex = 95
        Me.btnReadBacktest.Text = "Load Data"
        Me.btnReadBacktest.UseVisualStyleBackColor = True
        '
        'dtpBackDate
        '
        Me.dtpBackDate.Location = New System.Drawing.Point(206, 317)
        Me.dtpBackDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpBackDate.Name = "dtpBackDate"
        Me.dtpBackDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpBackDate.TabIndex = 96
        Me.dtpBackDate.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(106, 343)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(81, 23)
        Me.btnClose.TabIndex = 97
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnStartBackTest
        '
        Me.btnStartBackTest.Location = New System.Drawing.Point(185, 164)
        Me.btnStartBackTest.Name = "btnStartBackTest"
        Me.btnStartBackTest.Size = New System.Drawing.Size(89, 23)
        Me.btnStartBackTest.TabIndex = 99
        Me.btnStartBackTest.Text = "Run Test"
        Me.btnStartBackTest.UseVisualStyleBackColor = True
        '
        'txtSymbol
        '
        Me.txtSymbol.Location = New System.Drawing.Point(86, 140)
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.Size = New System.Drawing.Size(88, 20)
        Me.txtSymbol.TabIndex = 100
        '
        'txtLoadSymbol
        '
        Me.txtLoadSymbol.Location = New System.Drawing.Point(86, 86)
        Me.txtLoadSymbol.Name = "txtLoadSymbol"
        Me.txtLoadSymbol.Size = New System.Drawing.Size(88, 20)
        Me.txtLoadSymbol.TabIndex = 101
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Load Symbol:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Test Symbol:"
        '
        'dlgHarvestBacktest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 401)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLoadSymbol)
        Me.Controls.Add(Me.txtSymbol)
        Me.Controls.Add(Me.btnStartBackTest)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dtpBackDate)
        Me.Controls.Add(Me.btnReadBacktest)
        Me.Controls.Add(Me.btnClearList)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.lstOHLC)
        Me.Controls.Add(Me.cmbWillie)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "dlgHarvestBacktest"
        Me.Text = "Harvest Backtest"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbWillie As ComboBox
    Friend WithEvents lstOHLC As ListBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnClearList As Button
    Friend WithEvents btnReadBacktest As Button
    Friend WithEvents dtpBackDate As DateTimePicker
    Friend WithEvents btnClose As Button
    Friend WithEvents btnStartBackTest As Button
    Friend WithEvents txtSymbol As TextBox
    Friend WithEvents txtLoadSymbol As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
