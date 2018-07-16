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
        Me.btnBSBC = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, -2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1592, 67)
        Me.Panel1.TabIndex = 86
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(36, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(353, 42)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Willie Trading Robot"
        '
        'cmbWillie
        '
        Me.cmbWillie.FormattingEnabled = True
        Me.cmbWillie.Location = New System.Drawing.Point(30, 319)
        Me.cmbWillie.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cmbWillie.Name = "cmbWillie"
        Me.cmbWillie.Size = New System.Drawing.Size(314, 33)
        Me.cmbWillie.TabIndex = 90
        '
        'lstOHLC
        '
        Me.lstOHLC.FormattingEnabled = True
        Me.lstOHLC.ItemHeight = 25
        Me.lstOHLC.Location = New System.Drawing.Point(876, 290)
        Me.lstOHLC.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.lstOHLC.Name = "lstOHLC"
        Me.lstOHLC.Size = New System.Drawing.Size(458, 354)
        Me.lstOHLC.TabIndex = 91
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(36, 92)
        Me.Label16.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(437, 42)
        Me.Label16.TabIndex = 92
        Me.Label16.Text = "Back Test Control Center"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblStatus)
        Me.Panel5.Location = New System.Drawing.Point(0, 713)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1592, 60)
        Me.Panel5.TabIndex = 93
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(24, 19)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(163, 25)
        Me.lblStatus.TabIndex = 68
        Me.lblStatus.Text = "status message"
        '
        'btnClearList
        '
        Me.btnClearList.Location = New System.Drawing.Point(30, 660)
        Me.btnClearList.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnClearList.Name = "btnClearList"
        Me.btnClearList.Size = New System.Drawing.Size(162, 44)
        Me.btnClearList.TabIndex = 94
        Me.btnClearList.Text = "Clear "
        Me.btnClearList.UseVisualStyleBackColor = True
        '
        'btnReadBacktest
        '
        Me.btnReadBacktest.Location = New System.Drawing.Point(370, 165)
        Me.btnReadBacktest.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnReadBacktest.Name = "btnReadBacktest"
        Me.btnReadBacktest.Size = New System.Drawing.Size(234, 38)
        Me.btnReadBacktest.TabIndex = 95
        Me.btnReadBacktest.Text = "Load Data"
        Me.btnReadBacktest.UseVisualStyleBackColor = True
        '
        'dtpBackDate
        '
        Me.dtpBackDate.Location = New System.Drawing.Point(412, 610)
        Me.dtpBackDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpBackDate.Name = "dtpBackDate"
        Me.dtpBackDate.Size = New System.Drawing.Size(346, 31)
        Me.dtpBackDate.TabIndex = 96
        Me.dtpBackDate.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(212, 660)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(162, 44)
        Me.btnClose.TabIndex = 97
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnStartBackTest
        '
        Me.btnStartBackTest.Location = New System.Drawing.Point(370, 315)
        Me.btnStartBackTest.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnStartBackTest.Name = "btnStartBackTest"
        Me.btnStartBackTest.Size = New System.Drawing.Size(178, 44)
        Me.btnStartBackTest.TabIndex = 99
        Me.btnStartBackTest.Text = "Run Test"
        Me.btnStartBackTest.UseVisualStyleBackColor = True
        '
        'txtSymbol
        '
        Me.txtSymbol.Location = New System.Drawing.Point(172, 269)
        Me.txtSymbol.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.Size = New System.Drawing.Size(172, 31)
        Me.txtSymbol.TabIndex = 100
        '
        'txtLoadSymbol
        '
        Me.txtLoadSymbol.Location = New System.Drawing.Point(172, 165)
        Me.txtLoadSymbol.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtLoadSymbol.Name = "txtLoadSymbol"
        Me.txtLoadSymbol.Size = New System.Drawing.Size(172, 31)
        Me.txtLoadSymbol.TabIndex = 101
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 171)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 25)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Load Symbol:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 275)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 25)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Test Symbol:"
        '
        'btnBSBC
        '
        Me.btnBSBC.Location = New System.Drawing.Point(370, 410)
        Me.btnBSBC.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnBSBC.Name = "btnBSBC"
        Me.btnBSBC.Size = New System.Drawing.Size(178, 44)
        Me.btnBSBC.TabIndex = 104
        Me.btnBSBC.Text = "BSBC Excel"
        Me.btnBSBC.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(1354, 113)
        Me.btnTest.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(178, 44)
        Me.btnTest.TabIndex = 105
        Me.btnTest.Text = "Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'dlgHarvestBacktest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1584, 771)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.btnBSBC)
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
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
    Friend WithEvents btnBSBC As Button
    Friend WithEvents btnTest As Button
End Class
