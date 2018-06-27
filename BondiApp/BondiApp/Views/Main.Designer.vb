<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
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
        Me.components = New System.ComponentModel.Container()
        Me.lblConStatus = New System.Windows.Forms.Label()
        Me.HarvestIndexBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OptionwavesdbDataSet = New BondiApp.optionwavesdbDataSet()
        Me.HarvestIndexTableAdapter = New BondiApp.optionwavesdbDataSetTableAdapters.HarvestIndexTableAdapter()
        Me.lbldatastring = New System.Windows.Forms.Label()
        Me.OptionwavesdbDataSet1 = New BondiApp.optionwavesdbDataSet()
        Me.lstServerResponses = New System.Windows.Forms.ListBox()
        Me.btnWillie = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.bntlistclear = New System.Windows.Forms.Button()
        Me.Timer60Sec = New System.Windows.Forms.Timer(Me.components)
        Me.TimerAtTime = New System.Windows.Forms.Timer(Me.components)
        Me.ckRobotOn = New System.Windows.Forms.CheckBox()
        Me.btnBackTest = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtClientId = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblBuild = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lstConnectionResponses = New System.Windows.Forms.ListBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbWillie = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lstErrorResponses = New System.Windows.Forms.ListBox()
        Me.btnAnalysis = New System.Windows.Forms.Button()
        Me.btnSendOrders = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.lblopenBTOs = New System.Windows.Forms.Label()
        Me.lblopenSTCs = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.lblclosedBTOs = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.pnlMan = New System.Windows.Forms.Panel()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.grdContracts = New System.Windows.Forms.DataGridView()
        Me.colSymbol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStrike = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSpreadOrder = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtSpreadExp = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtSpreadRight = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtSpreadStrike = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtSpreadSymbol = New System.Windows.Forms.TextBox()
        Me.btnAddLeg = New System.Windows.Forms.Button()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtTickId = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.btnGetPrice2 = New System.Windows.Forms.Button()
        Me.btnckprice = New System.Windows.Forms.Button()
        Me.txtGetPriceSymbol = New System.Windows.Forms.TextBox()
        Me.btnTickPrice = New System.Windows.Forms.Button()
        Me.btnReqNextValidId = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtOptionExpirationDate = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtOptionIV = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtOptionRight = New System.Windows.Forms.TextBox()
        Me.lblOptionStrike = New System.Windows.Forms.Label()
        Me.txtOptionStrike = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtOptionSymbol = New System.Windows.Forms.TextBox()
        Me.btnOpPrice = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.btnSendOption = New System.Windows.Forms.Button()
        Me.btnHideManual = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.btnSendOrder = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAction = New System.Windows.Forms.TextBox()
        Me.lblSymbol = New System.Windows.Forms.Label()
        Me.txtSymbol = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOrderId = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtModifyQty = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtModifyPrice = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtModifyType = New System.Windows.Forms.TextBox()
        Me.btnModOrder = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtModifyAction = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtModifySymbol = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtModifyOrderId = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.btnShowManual = New System.Windows.Forms.Button()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnlManual = New System.Windows.Forms.Panel()
        Me.btnGetOpenOrders = New System.Windows.Forms.Button()
        Me.btnGetPrice = New System.Windows.Forms.Button()
        Me.txtPriceSymbol = New System.Windows.Forms.TextBox()
        Me.btnCloseManual = New System.Windows.Forms.Button()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.lblclosedSTCs = New System.Windows.Forms.Label()
        CType(Me.HarvestIndexBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionwavesdbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionwavesdbDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlMan.SuspendLayout()
        CType(Me.grdContracts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlManual.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblConStatus
        '
        Me.lblConStatus.AutoSize = True
        Me.lblConStatus.Location = New System.Drawing.Point(328, 899)
        Me.lblConStatus.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblConStatus.Name = "lblConStatus"
        Me.lblConStatus.Size = New System.Drawing.Size(87, 25)
        Me.lblConStatus.TabIndex = 7
        Me.lblConStatus.Text = "Off Line"
        '
        'HarvestIndexBindingSource
        '
        Me.HarvestIndexBindingSource.DataMember = "HarvestIndex"
        Me.HarvestIndexBindingSource.DataSource = Me.OptionwavesdbDataSet
        '
        'OptionwavesdbDataSet
        '
        Me.OptionwavesdbDataSet.DataSetName = "optionwavesdbDataSet"
        Me.OptionwavesdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'HarvestIndexTableAdapter
        '
        Me.HarvestIndexTableAdapter.ClearBeforeFill = True
        '
        'lbldatastring
        '
        Me.lbldatastring.AutoSize = True
        Me.lbldatastring.Location = New System.Drawing.Point(1411, 899)
        Me.lbldatastring.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbldatastring.Name = "lbldatastring"
        Me.lbldatastring.Size = New System.Drawing.Size(248, 25)
        Me.lbldatastring.TabIndex = 12
        Me.lbldatastring.Text = "Order Datastring Results"
        '
        'OptionwavesdbDataSet1
        '
        Me.OptionwavesdbDataSet1.DataSetName = "optionwavesdbDataSet"
        Me.OptionwavesdbDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lstServerResponses
        '
        Me.lstServerResponses.FormattingEnabled = True
        Me.lstServerResponses.ItemHeight = 25
        Me.lstServerResponses.Location = New System.Drawing.Point(327, 927)
        Me.lstServerResponses.Margin = New System.Windows.Forms.Padding(4)
        Me.lstServerResponses.Name = "lstServerResponses"
        Me.lstServerResponses.Size = New System.Drawing.Size(1332, 129)
        Me.lstServerResponses.TabIndex = 48
        '
        'btnWillie
        '
        Me.btnWillie.Location = New System.Drawing.Point(2766, 233)
        Me.btnWillie.Margin = New System.Windows.Forms.Padding(6)
        Me.btnWillie.Name = "btnWillie"
        Me.btnWillie.Size = New System.Drawing.Size(302, 62)
        Me.btnWillie.TabIndex = 49
        Me.btnWillie.Text = "Start Willie"
        Me.btnWillie.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(2766, 118)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(162, 44)
        Me.btnClose.TabIndex = 50
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'bntlistclear
        '
        Me.bntlistclear.Location = New System.Drawing.Point(2762, 174)
        Me.bntlistclear.Margin = New System.Windows.Forms.Padding(6)
        Me.bntlistclear.Name = "bntlistclear"
        Me.bntlistclear.Size = New System.Drawing.Size(162, 44)
        Me.bntlistclear.TabIndex = 68
        Me.bntlistclear.Text = "Clear "
        Me.bntlistclear.UseVisualStyleBackColor = True
        '
        'Timer60Sec
        '
        Me.Timer60Sec.Interval = 5000
        '
        'TimerAtTime
        '
        Me.TimerAtTime.Interval = 30000
        '
        'ckRobotOn
        '
        Me.ckRobotOn.AutoSize = True
        Me.ckRobotOn.Location = New System.Drawing.Point(2967, 69)
        Me.ckRobotOn.Margin = New System.Windows.Forms.Padding(6)
        Me.ckRobotOn.Name = "ckRobotOn"
        Me.ckRobotOn.Size = New System.Drawing.Size(98, 29)
        Me.ckRobotOn.TabIndex = 69
        Me.ckRobotOn.Text = "Timer"
        Me.ckRobotOn.UseVisualStyleBackColor = True
        '
        'btnBackTest
        '
        Me.btnBackTest.Location = New System.Drawing.Point(27, 1122)
        Me.btnBackTest.Margin = New System.Windows.Forms.Padding(6)
        Me.btnBackTest.Name = "btnBackTest"
        Me.btnBackTest.Size = New System.Drawing.Size(134, 44)
        Me.btnBackTest.TabIndex = 71
        Me.btnBackTest.Text = "BackTest"
        Me.btnBackTest.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(2175, 100)
        Me.Panel1.TabIndex = 85
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Location = New System.Drawing.Point(2002, 29)
        Me.Button1.Margin = New System.Windows.Forms.Padding(6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(142, 44)
        Me.Button1.TabIndex = 73
        Me.Button1.Text = "SETTINGS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(15, 24)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(575, 42)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Resignation Trading - Willie Gene"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnConnect)
        Me.Panel3.Controls.Add(Me.btnDisconnect)
        Me.Panel3.Controls.Add(Me.Label25)
        Me.Panel3.Controls.Add(Me.txtClientId)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.txtPort)
        Me.Panel3.Controls.Add(Me.label2)
        Me.Panel3.Controls.Add(Me.txtHost)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(301, 108)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1376, 60)
        Me.Panel3.TabIndex = 87
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(1052, 10)
        Me.btnConnect.Margin = New System.Windows.Forms.Padding(6)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(144, 44)
        Me.btnConnect.TabIndex = 66
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(1208, 10)
        Me.btnDisconnect.Margin = New System.Windows.Forms.Padding(6)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(144, 44)
        Me.btnDisconnect.TabIndex = 65
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(8, 8)
        Me.Label25.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(370, 42)
        Me.Label25.TabIndex = 90
        Me.Label25.Text = "Robot Control Center"
        '
        'txtClientId
        '
        Me.txtClientId.Location = New System.Drawing.Point(940, 13)
        Me.txtClientId.Margin = New System.Windows.Forms.Padding(6)
        Me.txtClientId.Name = "txtClientId"
        Me.txtClientId.Size = New System.Drawing.Size(72, 31)
        Me.txtClientId.TabIndex = 64
        Me.txtClientId.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(836, 15)
        Me.Label18.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(90, 25)
        Me.Label18.TabIndex = 63
        Me.Label18.Text = "Client Id"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(748, 12)
        Me.txtPort.Margin = New System.Windows.Forms.Padding(6)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(72, 31)
        Me.txtPort.TabIndex = 62
        Me.txtPort.Text = "7497"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(676, 15)
        Me.label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(51, 25)
        Me.label2.TabIndex = 61
        Me.label2.Text = "Port"
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(546, 12)
        Me.txtHost.Margin = New System.Windows.Forms.Padding(6)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(114, 31)
        Me.txtHost.TabIndex = 3
        Me.txtHost.Text = "127.0.0.1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(480, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Host"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblBuild)
        Me.Panel5.Controls.Add(Me.Label32)
        Me.Panel5.Controls.Add(Me.lstConnectionResponses)
        Me.Panel5.Location = New System.Drawing.Point(316, 1233)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1361, 60)
        Me.Panel5.TabIndex = 89
        '
        'lblBuild
        '
        Me.lblBuild.AutoSize = True
        Me.lblBuild.Location = New System.Drawing.Point(1028, 19)
        Me.lblBuild.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblBuild.Name = "lblBuild"
        Me.lblBuild.Size = New System.Drawing.Size(134, 25)
        Me.lblBuild.TabIndex = 94
        Me.lblBuild.Text = "build version"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(18, 19)
        Me.Label32.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(194, 25)
        Me.Label32.TabIndex = 123
        Me.Label32.Text = "Connection Status:"
        '
        'lstConnectionResponses
        '
        Me.lstConnectionResponses.BackColor = System.Drawing.SystemColors.MenuBar
        Me.lstConnectionResponses.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstConnectionResponses.FormattingEnabled = True
        Me.lstConnectionResponses.ItemHeight = 25
        Me.lstConnectionResponses.Location = New System.Drawing.Point(222, 19)
        Me.lstConnectionResponses.Margin = New System.Windows.Forms.Padding(4)
        Me.lstConnectionResponses.Name = "lstConnectionResponses"
        Me.lstConnectionResponses.Size = New System.Drawing.Size(648, 0)
        Me.lstConnectionResponses.TabIndex = 122
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(322, 1204)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(330, 25)
        Me.lblStatus.TabIndex = 68
        Me.lblStatus.Text = "Welcome to Resignation Trading!"
        '
        'cmbWillie
        '
        Me.cmbWillie.FormattingEnabled = True
        Me.cmbWillie.Location = New System.Drawing.Point(2479, 61)
        Me.cmbWillie.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbWillie.Name = "cmbWillie"
        Me.cmbWillie.Size = New System.Drawing.Size(408, 33)
        Me.cmbWillie.TabIndex = 91
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(2229, 67)
        Me.Label26.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(238, 25)
        Me.Label26.TabIndex = 92
        Me.Label26.Text = "Select Harvest Product:"
        '
        'lstErrorResponses
        '
        Me.lstErrorResponses.FormattingEnabled = True
        Me.lstErrorResponses.ItemHeight = 25
        Me.lstErrorResponses.Location = New System.Drawing.Point(327, 1068)
        Me.lstErrorResponses.Margin = New System.Windows.Forms.Padding(4)
        Me.lstErrorResponses.Name = "lstErrorResponses"
        Me.lstErrorResponses.Size = New System.Drawing.Size(1332, 129)
        Me.lstErrorResponses.TabIndex = 124
        '
        'btnAnalysis
        '
        Me.btnAnalysis.Location = New System.Drawing.Point(27, 1043)
        Me.btnAnalysis.Margin = New System.Windows.Forms.Padding(6)
        Me.btnAnalysis.Name = "btnAnalysis"
        Me.btnAnalysis.Size = New System.Drawing.Size(134, 44)
        Me.btnAnalysis.TabIndex = 125
        Me.btnAnalysis.Text = "Analysis"
        Me.btnAnalysis.UseVisualStyleBackColor = True
        '
        'btnSendOrders
        '
        Me.btnSendOrders.Location = New System.Drawing.Point(2220, 120)
        Me.btnSendOrders.Margin = New System.Windows.Forms.Padding(6)
        Me.btnSendOrders.Name = "btnSendOrders"
        Me.btnSendOrders.Size = New System.Drawing.Size(166, 48)
        Me.btnSendOrders.TabIndex = 132
        Me.btnSendOrders.Text = "Send Order"
        Me.btnSendOrders.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(27, 963)
        Me.Button3.Margin = New System.Windows.Forms.Padding(6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(234, 63)
        Me.Button3.TabIndex = 134
        Me.Button3.Text = "Analysis"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(27, 880)
        Me.Button4.Margin = New System.Windows.Forms.Padding(6)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(234, 63)
        Me.Button4.TabIndex = 135
        Me.Button4.Text = "Back Testing"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label38.Location = New System.Drawing.Point(29, 18)
        Me.Label38.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(298, 31)
        Me.Label38.TabIndex = 136
        Me.Label38.Text = "Real-Time Dashboard"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(102, 116)
        Me.Label39.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(80, 31)
        Me.Label39.TabIndex = 137
        Me.Label39.Text = "Open"
        '
        'lblopenBTOs
        '
        Me.lblopenBTOs.AutoSize = True
        Me.lblopenBTOs.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblopenBTOs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblopenBTOs.Location = New System.Drawing.Point(126, 176)
        Me.lblopenBTOs.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblopenBTOs.Name = "lblopenBTOs"
        Me.lblopenBTOs.Size = New System.Drawing.Size(35, 37)
        Me.lblopenBTOs.TabIndex = 138
        Me.lblopenBTOs.Text = "0"
        '
        'lblopenSTCs
        '
        Me.lblopenSTCs.AutoSize = True
        Me.lblopenSTCs.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblopenSTCs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblopenSTCs.Location = New System.Drawing.Point(126, 350)
        Me.lblopenSTCs.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblopenSTCs.Name = "lblopenSTCs"
        Me.lblopenSTCs.Size = New System.Drawing.Size(35, 37)
        Me.lblopenSTCs.TabIndex = 140
        Me.lblopenSTCs.Text = "0"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(196, 242)
        Me.Label41.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(69, 31)
        Me.Label41.TabIndex = 139
        Me.Label41.Text = "STC"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(409, 870)
        Me.Label42.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(29, 31)
        Me.Label42.TabIndex = 142
        Me.Label42.Text = "0"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(43, 870)
        Me.Label43.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(302, 31)
        Me.Label43.TabIndex = 141
        Me.Label43.Text = "Hedge Positions Active:"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(409, 924)
        Me.Label44.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(29, 31)
        Me.Label44.TabIndex = 144
        Me.Label44.Text = "0"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(43, 924)
        Me.Label45.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(301, 31)
        Me.Label45.TabIndex = 143
        Me.Label45.Text = "Stock Positions Closed:"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(409, 976)
        Me.Label46.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(29, 31)
        Me.Label46.TabIndex = 146
        Me.Label46.Text = "0"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(43, 976)
        Me.Label47.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(312, 31)
        Me.Label47.TabIndex = 145
        Me.Label47.Text = "Hedge Positions Closed:"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(409, 1032)
        Me.Label48.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(29, 31)
        Me.Label48.TabIndex = 148
        Me.Label48.Text = "0"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(43, 1032)
        Me.Label49.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(230, 31)
        Me.Label49.TabIndex = 147
        Me.Label49.Text = "Daily Stock Profit:"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(409, 1084)
        Me.Label50.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(29, 31)
        Me.Label50.TabIndex = 150
        Me.Label50.Text = "0"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(43, 1084)
        Me.Label51.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(241, 31)
        Me.Label51.TabIndex = 149
        Me.Label51.Text = "Daily Hedge Profit:"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(409, 1135)
        Me.Label52.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(29, 31)
        Me.Label52.TabIndex = 152
        Me.Label52.Text = "0"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(43, 1135)
        Me.Label53.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(222, 31)
        Me.Label53.TabIndex = 151
        Me.Label53.Text = "Daily Total Profit:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel2.Controls.Add(Me.lblclosedSTCs)
        Me.Panel2.Controls.Add(Me.Label66)
        Me.Panel2.Controls.Add(Me.Label67)
        Me.Panel2.Controls.Add(Me.Label64)
        Me.Panel2.Controls.Add(Me.lblclosedBTOs)
        Me.Panel2.Controls.Add(Me.Label40)
        Me.Panel2.Controls.Add(Me.Label38)
        Me.Panel2.Controls.Add(Me.Label39)
        Me.Panel2.Controls.Add(Me.lblopenBTOs)
        Me.Panel2.Controls.Add(Me.Label41)
        Me.Panel2.Controls.Add(Me.lblopenSTCs)
        Me.Panel2.Controls.Add(Me.Label43)
        Me.Panel2.Controls.Add(Me.Label42)
        Me.Panel2.Controls.Add(Me.Label45)
        Me.Panel2.Controls.Add(Me.Label52)
        Me.Panel2.Controls.Add(Me.Label44)
        Me.Panel2.Controls.Add(Me.Label53)
        Me.Panel2.Controls.Add(Me.Label47)
        Me.Panel2.Controls.Add(Me.Label50)
        Me.Panel2.Controls.Add(Me.Label46)
        Me.Panel2.Controls.Add(Me.Label51)
        Me.Panel2.Controls.Add(Me.Label49)
        Me.Panel2.Controls.Add(Me.Label48)
        Me.Panel2.Location = New System.Drawing.Point(1685, 102)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(490, 1191)
        Me.Panel2.TabIndex = 153
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(265, 288)
        Me.Label66.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(99, 31)
        Me.Label66.TabIndex = 157
        Me.Label66.Text = "Closed"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(102, 288)
        Me.Label67.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(80, 31)
        Me.Label67.TabIndex = 156
        Me.Label67.Text = "Open"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(265, 116)
        Me.Label64.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(99, 31)
        Me.Label64.TabIndex = 154
        Me.Label64.Text = "Closed"
        '
        'lblclosedBTOs
        '
        Me.lblclosedBTOs.AutoSize = True
        Me.lblclosedBTOs.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblclosedBTOs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclosedBTOs.Location = New System.Drawing.Point(314, 176)
        Me.lblclosedBTOs.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblclosedBTOs.Name = "lblclosedBTOs"
        Me.lblclosedBTOs.Size = New System.Drawing.Size(35, 37)
        Me.lblclosedBTOs.TabIndex = 155
        Me.lblclosedBTOs.Text = "0"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(190, 73)
        Me.Label40.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(70, 31)
        Me.Label40.TabIndex = 153
        Me.Label40.Text = "BTO"
        '
        'pnlMan
        '
        Me.pnlMan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMan.Controls.Add(Me.Label29)
        Me.pnlMan.Controls.Add(Me.grdContracts)
        Me.pnlMan.Controls.Add(Me.btnSpreadOrder)
        Me.pnlMan.Controls.Add(Me.Label31)
        Me.pnlMan.Controls.Add(Me.txtSpreadExp)
        Me.pnlMan.Controls.Add(Me.Label34)
        Me.pnlMan.Controls.Add(Me.txtSpreadRight)
        Me.pnlMan.Controls.Add(Me.Label35)
        Me.pnlMan.Controls.Add(Me.txtSpreadStrike)
        Me.pnlMan.Controls.Add(Me.Label36)
        Me.pnlMan.Controls.Add(Me.txtSpreadSymbol)
        Me.pnlMan.Controls.Add(Me.btnAddLeg)
        Me.pnlMan.Controls.Add(Me.btnOpenFile)
        Me.pnlMan.Controls.Add(Me.Label37)
        Me.pnlMan.Controls.Add(Me.txtTickId)
        Me.pnlMan.Controls.Add(Me.Label33)
        Me.pnlMan.Controls.Add(Me.btnGetPrice2)
        Me.pnlMan.Controls.Add(Me.btnckprice)
        Me.pnlMan.Controls.Add(Me.txtGetPriceSymbol)
        Me.pnlMan.Controls.Add(Me.btnTickPrice)
        Me.pnlMan.Controls.Add(Me.btnReqNextValidId)
        Me.pnlMan.Controls.Add(Me.Label30)
        Me.pnlMan.Controls.Add(Me.txtOptionExpirationDate)
        Me.pnlMan.Controls.Add(Me.Label28)
        Me.pnlMan.Controls.Add(Me.txtOptionIV)
        Me.pnlMan.Controls.Add(Me.Label27)
        Me.pnlMan.Controls.Add(Me.txtOptionRight)
        Me.pnlMan.Controls.Add(Me.lblOptionStrike)
        Me.pnlMan.Controls.Add(Me.txtOptionStrike)
        Me.pnlMan.Controls.Add(Me.Label16)
        Me.pnlMan.Controls.Add(Me.txtOptionSymbol)
        Me.pnlMan.Controls.Add(Me.btnOpPrice)
        Me.pnlMan.Controls.Add(Me.Label17)
        Me.pnlMan.Controls.Add(Me.TextBox1)
        Me.pnlMan.Controls.Add(Me.Label20)
        Me.pnlMan.Controls.Add(Me.TextBox2)
        Me.pnlMan.Controls.Add(Me.Label21)
        Me.pnlMan.Controls.Add(Me.TextBox3)
        Me.pnlMan.Controls.Add(Me.Label22)
        Me.pnlMan.Controls.Add(Me.TextBox4)
        Me.pnlMan.Controls.Add(Me.Label23)
        Me.pnlMan.Controls.Add(Me.TextBox5)
        Me.pnlMan.Controls.Add(Me.Label24)
        Me.pnlMan.Controls.Add(Me.TextBox6)
        Me.pnlMan.Controls.Add(Me.btnSendOption)
        Me.pnlMan.Controls.Add(Me.btnHideManual)
        Me.pnlMan.Location = New System.Drawing.Point(2234, 881)
        Me.pnlMan.Margin = New System.Windows.Forms.Padding(6)
        Me.pnlMan.Name = "pnlMan"
        Me.pnlMan.Size = New System.Drawing.Size(1390, 564)
        Me.pnlMan.TabIndex = 154
        Me.pnlMan.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(248, 198)
        Me.Label29.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(343, 25)
        Me.Label29.TabIndex = 204
        Me.Label29.Text = "Additional Controls Here If Needed"
        '
        'grdContracts
        '
        Me.grdContracts.AllowUserToAddRows = False
        Me.grdContracts.AllowUserToDeleteRows = False
        Me.grdContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdContracts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSymbol, Me.colExpDate, Me.colStrike, Me.colRight, Me.colConId})
        Me.grdContracts.Location = New System.Drawing.Point(50, 354)
        Me.grdContracts.Margin = New System.Windows.Forms.Padding(6)
        Me.grdContracts.Name = "grdContracts"
        Me.grdContracts.ReadOnly = True
        Me.grdContracts.Size = New System.Drawing.Size(786, 185)
        Me.grdContracts.TabIndex = 203
        '
        'colSymbol
        '
        Me.colSymbol.HeaderText = "Symbol"
        Me.colSymbol.Name = "colSymbol"
        Me.colSymbol.ReadOnly = True
        '
        'colExpDate
        '
        Me.colExpDate.HeaderText = "Exp Date"
        Me.colExpDate.Name = "colExpDate"
        Me.colExpDate.ReadOnly = True
        '
        'colStrike
        '
        Me.colStrike.HeaderText = "Strike"
        Me.colStrike.Name = "colStrike"
        Me.colStrike.ReadOnly = True
        '
        'colRight
        '
        Me.colRight.HeaderText = "Right"
        Me.colRight.Name = "colRight"
        Me.colRight.ReadOnly = True
        '
        'colConId
        '
        Me.colConId.HeaderText = "ConId"
        Me.colConId.Name = "colConId"
        Me.colConId.ReadOnly = True
        '
        'btnSpreadOrder
        '
        Me.btnSpreadOrder.Location = New System.Drawing.Point(618, 294)
        Me.btnSpreadOrder.Margin = New System.Windows.Forms.Padding(6)
        Me.btnSpreadOrder.Name = "btnSpreadOrder"
        Me.btnSpreadOrder.Size = New System.Drawing.Size(200, 44)
        Me.btnSpreadOrder.TabIndex = 202
        Me.btnSpreadOrder.Text = "Send Spread "
        Me.btnSpreadOrder.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(232, 254)
        Me.Label31.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(159, 25)
        Me.Label31.TabIndex = 201
        Me.Label31.Text = "Expiration Date"
        '
        'txtSpreadExp
        '
        Me.txtSpreadExp.Location = New System.Drawing.Point(402, 248)
        Me.txtSpreadExp.Margin = New System.Windows.Forms.Padding(6)
        Me.txtSpreadExp.Name = "txtSpreadExp"
        Me.txtSpreadExp.Size = New System.Drawing.Size(192, 31)
        Me.txtSpreadExp.TabIndex = 200
        Me.txtSpreadExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(236, 304)
        Me.Label34.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(72, 25)
        Me.Label34.TabIndex = 199
        Me.Label34.Text = "P or C"
        '
        'txtSpreadRight
        '
        Me.txtSpreadRight.Location = New System.Drawing.Point(308, 298)
        Me.txtSpreadRight.Margin = New System.Windows.Forms.Padding(6)
        Me.txtSpreadRight.Name = "txtSpreadRight"
        Me.txtSpreadRight.Size = New System.Drawing.Size(78, 31)
        Me.txtSpreadRight.TabIndex = 198
        Me.txtSpreadRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(44, 304)
        Me.Label35.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(67, 25)
        Me.Label35.TabIndex = 197
        Me.Label35.Text = "Strike"
        '
        'txtSpreadStrike
        '
        Me.txtSpreadStrike.Location = New System.Drawing.Point(138, 298)
        Me.txtSpreadStrike.Margin = New System.Windows.Forms.Padding(6)
        Me.txtSpreadStrike.Name = "txtSpreadStrike"
        Me.txtSpreadStrike.Size = New System.Drawing.Size(78, 31)
        Me.txtSpreadStrike.TabIndex = 196
        Me.txtSpreadStrike.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(44, 254)
        Me.Label36.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(83, 25)
        Me.Label36.TabIndex = 195
        Me.Label36.Text = "Symbol"
        '
        'txtSpreadSymbol
        '
        Me.txtSpreadSymbol.Location = New System.Drawing.Point(138, 248)
        Me.txtSpreadSymbol.Margin = New System.Windows.Forms.Padding(6)
        Me.txtSpreadSymbol.Name = "txtSpreadSymbol"
        Me.txtSpreadSymbol.Size = New System.Drawing.Size(78, 31)
        Me.txtSpreadSymbol.TabIndex = 194
        Me.txtSpreadSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAddLeg
        '
        Me.btnAddLeg.Location = New System.Drawing.Point(404, 298)
        Me.btnAddLeg.Margin = New System.Windows.Forms.Padding(6)
        Me.btnAddLeg.Name = "btnAddLeg"
        Me.btnAddLeg.Size = New System.Drawing.Size(184, 44)
        Me.btnAddLeg.TabIndex = 193
        Me.btnAddLeg.Text = "Add Leg"
        Me.btnAddLeg.UseVisualStyleBackColor = True
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(618, 198)
        Me.btnOpenFile.Margin = New System.Windows.Forms.Padding(6)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(200, 44)
        Me.btnOpenFile.TabIndex = 192
        Me.btnOpenFile.Text = "Load File"
        Me.btnOpenFile.UseVisualStyleBackColor = True
        Me.btnOpenFile.Visible = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(1062, 227)
        Me.Label37.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(129, 25)
        Me.Label37.TabIndex = 190
        Me.Label37.Text = "Tick Type Id"
        '
        'txtTickId
        '
        Me.txtTickId.Location = New System.Drawing.Point(1212, 221)
        Me.txtTickId.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTickId.Name = "txtTickId"
        Me.txtTickId.Size = New System.Drawing.Size(78, 31)
        Me.txtTickId.TabIndex = 189
        Me.txtTickId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(1068, 290)
        Me.Label33.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(136, 25)
        Me.Label33.TabIndex = 188
        Me.Label33.Text = "App Controls"
        '
        'btnGetPrice2
        '
        Me.btnGetPrice2.Location = New System.Drawing.Point(1228, 281)
        Me.btnGetPrice2.Margin = New System.Windows.Forms.Padding(6)
        Me.btnGetPrice2.Name = "btnGetPrice2"
        Me.btnGetPrice2.Size = New System.Drawing.Size(134, 44)
        Me.btnGetPrice2.TabIndex = 185
        Me.btnGetPrice2.Text = "Get Price"
        Me.btnGetPrice2.UseVisualStyleBackColor = True
        '
        'btnckprice
        '
        Me.btnckprice.Location = New System.Drawing.Point(1228, 337)
        Me.btnckprice.Margin = New System.Windows.Forms.Padding(6)
        Me.btnckprice.Name = "btnckprice"
        Me.btnckprice.Size = New System.Drawing.Size(134, 44)
        Me.btnckprice.TabIndex = 187
        Me.btnckprice.Text = "Price"
        Me.btnckprice.UseVisualStyleBackColor = True
        '
        'txtGetPriceSymbol
        '
        Me.txtGetPriceSymbol.Location = New System.Drawing.Point(982, 340)
        Me.txtGetPriceSymbol.Margin = New System.Windows.Forms.Padding(6)
        Me.txtGetPriceSymbol.Name = "txtGetPriceSymbol"
        Me.txtGetPriceSymbol.Size = New System.Drawing.Size(80, 31)
        Me.txtGetPriceSymbol.TabIndex = 186
        Me.txtGetPriceSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnTickPrice
        '
        Me.btnTickPrice.Location = New System.Drawing.Point(1076, 165)
        Me.btnTickPrice.Margin = New System.Windows.Forms.Padding(6)
        Me.btnTickPrice.Name = "btnTickPrice"
        Me.btnTickPrice.Size = New System.Drawing.Size(200, 44)
        Me.btnTickPrice.TabIndex = 191
        Me.btnTickPrice.Text = "Get Tick"
        Me.btnTickPrice.UseVisualStyleBackColor = True
        '
        'btnReqNextValidId
        '
        Me.btnReqNextValidId.Location = New System.Drawing.Point(1080, 335)
        Me.btnReqNextValidId.Margin = New System.Windows.Forms.Padding(6)
        Me.btnReqNextValidId.Name = "btnReqNextValidId"
        Me.btnReqNextValidId.Size = New System.Drawing.Size(134, 44)
        Me.btnReqNextValidId.TabIndex = 184
        Me.btnReqNextValidId.Text = "OrderId"
        Me.btnReqNextValidId.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(222, 110)
        Me.Label30.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(159, 25)
        Me.Label30.TabIndex = 182
        Me.Label30.Text = "Expiration Date"
        '
        'txtOptionExpirationDate
        '
        Me.txtOptionExpirationDate.Location = New System.Drawing.Point(388, 104)
        Me.txtOptionExpirationDate.Margin = New System.Windows.Forms.Padding(6)
        Me.txtOptionExpirationDate.Name = "txtOptionExpirationDate"
        Me.txtOptionExpirationDate.Size = New System.Drawing.Size(192, 31)
        Me.txtOptionExpirationDate.TabIndex = 181
        Me.txtOptionExpirationDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(936, 110)
        Me.Label28.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(31, 25)
        Me.Label28.TabIndex = 180
        Me.Label28.Text = "IV"
        '
        'txtOptionIV
        '
        Me.txtOptionIV.Location = New System.Drawing.Point(1044, 104)
        Me.txtOptionIV.Margin = New System.Windows.Forms.Padding(6)
        Me.txtOptionIV.Name = "txtOptionIV"
        Me.txtOptionIV.Size = New System.Drawing.Size(78, 31)
        Me.txtOptionIV.TabIndex = 179
        Me.txtOptionIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(764, 110)
        Me.Label27.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(72, 25)
        Me.Label27.TabIndex = 178
        Me.Label27.Text = "P or C"
        '
        'txtOptionRight
        '
        Me.txtOptionRight.Location = New System.Drawing.Point(836, 104)
        Me.txtOptionRight.Margin = New System.Windows.Forms.Padding(6)
        Me.txtOptionRight.Name = "txtOptionRight"
        Me.txtOptionRight.Size = New System.Drawing.Size(78, 31)
        Me.txtOptionRight.TabIndex = 177
        Me.txtOptionRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOptionStrike
        '
        Me.lblOptionStrike.AutoSize = True
        Me.lblOptionStrike.Location = New System.Drawing.Point(596, 110)
        Me.lblOptionStrike.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblOptionStrike.Name = "lblOptionStrike"
        Me.lblOptionStrike.Size = New System.Drawing.Size(67, 25)
        Me.lblOptionStrike.TabIndex = 176
        Me.lblOptionStrike.Text = "Strike"
        '
        'txtOptionStrike
        '
        Me.txtOptionStrike.Location = New System.Drawing.Point(668, 104)
        Me.txtOptionStrike.Margin = New System.Windows.Forms.Padding(6)
        Me.txtOptionStrike.Name = "txtOptionStrike"
        Me.txtOptionStrike.Size = New System.Drawing.Size(78, 31)
        Me.txtOptionStrike.TabIndex = 175
        Me.txtOptionStrike.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 110)
        Me.Label16.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 25)
        Me.Label16.TabIndex = 174
        Me.Label16.Text = "Symbol"
        '
        'txtOptionSymbol
        '
        Me.txtOptionSymbol.Location = New System.Drawing.Point(118, 104)
        Me.txtOptionSymbol.Margin = New System.Windows.Forms.Padding(6)
        Me.txtOptionSymbol.Name = "txtOptionSymbol"
        Me.txtOptionSymbol.Size = New System.Drawing.Size(78, 31)
        Me.txtOptionSymbol.TabIndex = 173
        Me.txtOptionSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnOpPrice
        '
        Me.btnOpPrice.Location = New System.Drawing.Point(1140, 100)
        Me.btnOpPrice.Margin = New System.Windows.Forms.Padding(6)
        Me.btnOpPrice.Name = "btnOpPrice"
        Me.btnOpPrice.Size = New System.Drawing.Size(202, 44)
        Me.btnOpPrice.TabIndex = 172
        Me.btnOpPrice.Text = "Opt Price"
        Me.btnOpPrice.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(936, 31)
        Me.Label17.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(92, 25)
        Me.Label17.TabIndex = 171
        Me.Label17.Text = "Quantity"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1044, 25)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(78, 31)
        Me.TextBox1.TabIndex = 170
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(764, 31)
        Me.Label20.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 25)
        Me.Label20.TabIndex = 169
        Me.Label20.Text = "Price"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(836, 17)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(78, 31)
        Me.TextBox2.TabIndex = 168
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(594, 31)
        Me.Label21.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 25)
        Me.Label21.TabIndex = 167
        Me.Label21.Text = "Type"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(670, 17)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(78, 31)
        Me.TextBox3.TabIndex = 166
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(414, 31)
        Me.Label22.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 25)
        Me.Label22.TabIndex = 165
        Me.Label22.Text = "Action"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(500, 25)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(78, 31)
        Me.TextBox4.TabIndex = 164
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(222, 23)
        Me.Label23.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 25)
        Me.Label23.TabIndex = 163
        Me.Label23.Text = "Symbol"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(316, 25)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(78, 31)
        Me.TextBox5.TabIndex = 162
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 31)
        Me.Label24.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(86, 25)
        Me.Label24.TabIndex = 161
        Me.Label24.Text = "OrderID"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(118, 17)
        Me.TextBox6.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(78, 31)
        Me.TextBox6.TabIndex = 160
        Me.TextBox6.Text = "0"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSendOption
        '
        Me.btnSendOption.Location = New System.Drawing.Point(1140, 23)
        Me.btnSendOption.Margin = New System.Windows.Forms.Padding(6)
        Me.btnSendOption.Name = "btnSendOption"
        Me.btnSendOption.Size = New System.Drawing.Size(204, 44)
        Me.btnSendOption.TabIndex = 159
        Me.btnSendOption.Text = "Option Order"
        Me.btnSendOption.UseVisualStyleBackColor = True
        '
        'btnHideManual
        '
        Me.btnHideManual.Location = New System.Drawing.Point(1080, 450)
        Me.btnHideManual.Margin = New System.Windows.Forms.Padding(6)
        Me.btnHideManual.Name = "btnHideManual"
        Me.btnHideManual.Size = New System.Drawing.Size(282, 88)
        Me.btnHideManual.TabIndex = 132
        Me.btnHideManual.Text = "Close Manual"
        Me.btnHideManual.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label54)
        Me.Panel4.Controls.Add(Me.btnSendOrder)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.txtQty)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.txtPrice)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.txtType)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.txtAction)
        Me.Panel4.Controls.Add(Me.lblSymbol)
        Me.Panel4.Controls.Add(Me.txtSymbol)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.txtOrderId)
        Me.Panel4.Location = New System.Drawing.Point(2220, 307)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(824, 163)
        Me.Panel4.TabIndex = 155
        Me.Panel4.Visible = False
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(28, 8)
        Me.Label54.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(261, 37)
        Me.Label54.TabIndex = 167
        Me.Label54.Text = "New Stock Order"
        '
        'btnSendOrder
        '
        Me.btnSendOrder.Location = New System.Drawing.Point(656, 106)
        Me.btnSendOrder.Margin = New System.Windows.Forms.Padding(6)
        Me.btnSendOrder.Name = "btnSendOrder"
        Me.btnSendOrder.Size = New System.Drawing.Size(162, 44)
        Me.btnSendOrder.TabIndex = 153
        Me.btnSendOrder.Text = "Send"
        Me.btnSendOrder.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(428, 115)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 25)
        Me.Label7.TabIndex = 152
        Me.Label7.Text = "Quantity"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(542, 108)
        Me.txtQty.Margin = New System.Windows.Forms.Padding(6)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(78, 31)
        Me.txtQty.TabIndex = 151
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(244, 115)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 25)
        Me.Label8.TabIndex = 150
        Me.Label8.Text = "Price"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(338, 108)
        Me.txtPrice.Margin = New System.Windows.Forms.Padding(6)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(78, 31)
        Me.txtPrice.TabIndex = 149
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 112)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 25)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "Type"
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(142, 110)
        Me.txtType.Margin = New System.Windows.Forms.Padding(6)
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(78, 31)
        Me.txtType.TabIndex = 147
        Me.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(446, 63)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 25)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "Action"
        '
        'txtAction
        '
        Me.txtAction.Location = New System.Drawing.Point(542, 54)
        Me.txtAction.Margin = New System.Windows.Forms.Padding(6)
        Me.txtAction.Name = "txtAction"
        Me.txtAction.Size = New System.Drawing.Size(78, 31)
        Me.txtAction.TabIndex = 145
        Me.txtAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSymbol
        '
        Me.lblSymbol.AutoSize = True
        Me.lblSymbol.Location = New System.Drawing.Point(244, 63)
        Me.lblSymbol.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.Size = New System.Drawing.Size(83, 25)
        Me.lblSymbol.TabIndex = 144
        Me.lblSymbol.Text = "Symbol"
        '
        'txtSymbol
        '
        Me.txtSymbol.Location = New System.Drawing.Point(338, 54)
        Me.txtSymbol.Margin = New System.Windows.Forms.Padding(6)
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.Size = New System.Drawing.Size(78, 31)
        Me.txtSymbol.TabIndex = 143
        Me.txtSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 63)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 25)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "Order ID"
        '
        'txtOrderId
        '
        Me.txtOrderId.Location = New System.Drawing.Point(140, 54)
        Me.txtOrderId.Margin = New System.Windows.Forms.Padding(6)
        Me.txtOrderId.Name = "txtOrderId"
        Me.txtOrderId.Size = New System.Drawing.Size(78, 31)
        Me.txtOrderId.TabIndex = 141
        Me.txtOrderId.Text = "0"
        Me.txtOrderId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label19)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.Controls.Add(Me.txtModifyQty)
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Controls.Add(Me.txtModifyPrice)
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Controls.Add(Me.txtModifyType)
        Me.Panel6.Controls.Add(Me.btnModOrder)
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Controls.Add(Me.txtModifyAction)
        Me.Panel6.Controls.Add(Me.Label14)
        Me.Panel6.Controls.Add(Me.txtModifySymbol)
        Me.Panel6.Controls.Add(Me.Label15)
        Me.Panel6.Controls.Add(Me.txtModifyOrderId)
        Me.Panel6.Location = New System.Drawing.Point(2220, 495)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(6)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(824, 163)
        Me.Panel6.TabIndex = 156
        Me.Panel6.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(28, 10)
        Me.Label19.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(201, 37)
        Me.Label19.TabIndex = 166
        Me.Label19.Text = "Modify Order"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(438, 113)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 25)
        Me.Label10.TabIndex = 165
        Me.Label10.Text = "Quantity"
        '
        'txtModifyQty
        '
        Me.txtModifyQty.Location = New System.Drawing.Point(542, 108)
        Me.txtModifyQty.Margin = New System.Windows.Forms.Padding(6)
        Me.txtModifyQty.Name = "txtModifyQty"
        Me.txtModifyQty.Size = New System.Drawing.Size(78, 31)
        Me.txtModifyQty.TabIndex = 164
        Me.txtModifyQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(256, 115)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 25)
        Me.Label11.TabIndex = 163
        Me.Label11.Text = "Price"
        '
        'txtModifyPrice
        '
        Me.txtModifyPrice.Location = New System.Drawing.Point(338, 108)
        Me.txtModifyPrice.Margin = New System.Windows.Forms.Padding(6)
        Me.txtModifyPrice.Name = "txtModifyPrice"
        Me.txtModifyPrice.Size = New System.Drawing.Size(78, 31)
        Me.txtModifyPrice.TabIndex = 162
        Me.txtModifyPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(30, 113)
        Me.Label12.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 25)
        Me.Label12.TabIndex = 161
        Me.Label12.Text = "Type"
        '
        'txtModifyType
        '
        Me.txtModifyType.Location = New System.Drawing.Point(142, 110)
        Me.txtModifyType.Margin = New System.Windows.Forms.Padding(6)
        Me.txtModifyType.Name = "txtModifyType"
        Me.txtModifyType.Size = New System.Drawing.Size(78, 31)
        Me.txtModifyType.TabIndex = 160
        Me.txtModifyType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnModOrder
        '
        Me.btnModOrder.Location = New System.Drawing.Point(658, 104)
        Me.btnModOrder.Margin = New System.Windows.Forms.Padding(6)
        Me.btnModOrder.Name = "btnModOrder"
        Me.btnModOrder.Size = New System.Drawing.Size(162, 44)
        Me.btnModOrder.TabIndex = 159
        Me.btnModOrder.Text = "Send"
        Me.btnModOrder.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(438, 60)
        Me.Label13.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 25)
        Me.Label13.TabIndex = 158
        Me.Label13.Text = "Action"
        '
        'txtModifyAction
        '
        Me.txtModifyAction.Location = New System.Drawing.Point(542, 54)
        Me.txtModifyAction.Margin = New System.Windows.Forms.Padding(6)
        Me.txtModifyAction.Name = "txtModifyAction"
        Me.txtModifyAction.Size = New System.Drawing.Size(78, 31)
        Me.txtModifyAction.TabIndex = 157
        Me.txtModifyAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(246, 60)
        Me.Label14.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 25)
        Me.Label14.TabIndex = 156
        Me.Label14.Text = "Symbol"
        '
        'txtModifySymbol
        '
        Me.txtModifySymbol.Location = New System.Drawing.Point(338, 54)
        Me.txtModifySymbol.Margin = New System.Windows.Forms.Padding(6)
        Me.txtModifySymbol.Name = "txtModifySymbol"
        Me.txtModifySymbol.Size = New System.Drawing.Size(78, 31)
        Me.txtModifySymbol.TabIndex = 155
        Me.txtModifySymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(30, 63)
        Me.Label15.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 25)
        Me.Label15.TabIndex = 154
        Me.Label15.Text = "OrderID"
        '
        'txtModifyOrderId
        '
        Me.txtModifyOrderId.Location = New System.Drawing.Point(142, 54)
        Me.txtModifyOrderId.Margin = New System.Windows.Forms.Padding(6)
        Me.txtModifyOrderId.Name = "txtModifyOrderId"
        Me.txtModifyOrderId.Size = New System.Drawing.Size(78, 31)
        Me.txtModifyOrderId.TabIndex = 153
        Me.txtModifyOrderId.Text = "4"
        Me.txtModifyOrderId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(2220, 176)
        Me.Button2.Margin = New System.Windows.Forms.Padding(6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(166, 48)
        Me.Button2.TabIndex = 157
        Me.Button2.Text = "Modify Order"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(326, 847)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(275, 37)
        Me.Label9.TabIndex = 158
        Me.Label9.Text = "System Messages"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(2220, 236)
        Me.Button5.Margin = New System.Windows.Forms.Padding(6)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(166, 48)
        Me.Button5.TabIndex = 159
        Me.Button5.Text = "Get Info."
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(2398, 236)
        Me.Button6.Margin = New System.Windows.Forms.Padding(6)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(166, 48)
        Me.Button6.TabIndex = 162
        Me.Button6.Text = "Modify Order"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(2398, 176)
        Me.Button7.Margin = New System.Windows.Forms.Padding(6)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(166, 48)
        Me.Button7.TabIndex = 161
        Me.Button7.Text = "Modify Order"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(2398, 120)
        Me.Button8.Margin = New System.Windows.Forms.Padding(6)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(166, 48)
        Me.Button8.TabIndex = 160
        Me.Button8.Text = "Send Order"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(2576, 236)
        Me.Button9.Margin = New System.Windows.Forms.Padding(6)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(166, 48)
        Me.Button9.TabIndex = 165
        Me.Button9.Text = "Modify Order"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(2576, 176)
        Me.Button10.Margin = New System.Windows.Forms.Padding(6)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(166, 48)
        Me.Button10.TabIndex = 164
        Me.Button10.Text = "Modify Order"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(2576, 120)
        Me.Button11.Margin = New System.Windows.Forms.Padding(6)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(166, 48)
        Me.Button11.TabIndex = 163
        Me.Button11.Text = "Send Order"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label55)
        Me.Panel7.Controls.Add(Me.Button12)
        Me.Panel7.Controls.Add(Me.Label56)
        Me.Panel7.Controls.Add(Me.TextBox7)
        Me.Panel7.Controls.Add(Me.Label57)
        Me.Panel7.Controls.Add(Me.TextBox8)
        Me.Panel7.Controls.Add(Me.Label58)
        Me.Panel7.Controls.Add(Me.TextBox9)
        Me.Panel7.Controls.Add(Me.Label59)
        Me.Panel7.Controls.Add(Me.TextBox10)
        Me.Panel7.Controls.Add(Me.Label60)
        Me.Panel7.Controls.Add(Me.TextBox11)
        Me.Panel7.Controls.Add(Me.Label61)
        Me.Panel7.Controls.Add(Me.TextBox12)
        Me.Panel7.Location = New System.Drawing.Point(2234, 696)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(6)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(824, 163)
        Me.Panel7.TabIndex = 166
        Me.Panel7.Visible = False
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(28, 8)
        Me.Label55.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(276, 37)
        Me.Label55.TabIndex = 167
        Me.Label55.Text = "New Option Order"
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(654, 106)
        Me.Button12.Margin = New System.Windows.Forms.Padding(6)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(162, 44)
        Me.Button12.TabIndex = 153
        Me.Button12.Text = "Send"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(428, 115)
        Me.Label56.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(92, 25)
        Me.Label56.TabIndex = 152
        Me.Label56.Text = "Quantity"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(532, 110)
        Me.TextBox7.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(78, 31)
        Me.TextBox7.TabIndex = 151
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(244, 115)
        Me.Label57.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(61, 25)
        Me.Label57.TabIndex = 150
        Me.Label57.Text = "Price"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(338, 108)
        Me.TextBox8.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(78, 31)
        Me.TextBox8.TabIndex = 149
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(30, 112)
        Me.Label58.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(60, 25)
        Me.Label58.TabIndex = 148
        Me.Label58.Text = "Type"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(140, 104)
        Me.TextBox9.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(78, 31)
        Me.TextBox9.TabIndex = 147
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(446, 63)
        Me.Label59.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(72, 25)
        Me.Label59.TabIndex = 146
        Me.Label59.Text = "Action"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(532, 54)
        Me.TextBox10.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(78, 31)
        Me.TextBox10.TabIndex = 145
        Me.TextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(244, 63)
        Me.Label60.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(83, 25)
        Me.Label60.TabIndex = 144
        Me.Label60.Text = "Symbol"
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(338, 54)
        Me.TextBox11.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(78, 31)
        Me.TextBox11.TabIndex = 143
        Me.TextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(28, 63)
        Me.Label61.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(92, 25)
        Me.Label61.TabIndex = 142
        Me.Label61.Text = "Order ID"
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(140, 54)
        Me.TextBox12.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(78, 31)
        Me.TextBox12.TabIndex = 141
        Me.TextBox12.Text = "0"
        Me.TextBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel8.Controls.Add(Me.Button4)
        Me.Panel8.Controls.Add(Me.Button3)
        Me.Panel8.Controls.Add(Me.Label62)
        Me.Panel8.Controls.Add(Me.btnAnalysis)
        Me.Panel8.Controls.Add(Me.btnShowManual)
        Me.Panel8.Controls.Add(Me.btnBackTest)
        Me.Panel8.Location = New System.Drawing.Point(0, 102)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(294, 1191)
        Me.Panel8.TabIndex = 167
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label62.Location = New System.Drawing.Point(15, 21)
        Me.Label62.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(246, 42)
        Me.Label62.TabIndex = 91
        Me.Label62.Text = "NAVIGATION"
        '
        'btnShowManual
        '
        Me.btnShowManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowManual.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnShowManual.Image = Global.BondiApp.My.Resources.Resources.Farmer_2
        Me.btnShowManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShowManual.Location = New System.Drawing.Point(6, 87)
        Me.btnShowManual.Margin = New System.Windows.Forms.Padding(6)
        Me.btnShowManual.Name = "btnShowManual"
        Me.btnShowManual.Size = New System.Drawing.Size(282, 80)
        Me.btnShowManual.TabIndex = 74
        Me.btnShowManual.Text = "       MANUAL ACTIONS"
        Me.btnShowManual.UseVisualStyleBackColor = True
        '
        'pnlManual
        '
        Me.pnlManual.Controls.Add(Me.btnGetOpenOrders)
        Me.pnlManual.Controls.Add(Me.btnGetPrice)
        Me.pnlManual.Controls.Add(Me.txtPriceSymbol)
        Me.pnlManual.Controls.Add(Me.btnCloseManual)
        Me.pnlManual.Controls.Add(Me.Label63)
        Me.pnlManual.Location = New System.Drawing.Point(301, 175)
        Me.pnlManual.Name = "pnlManual"
        Me.pnlManual.Size = New System.Drawing.Size(1376, 669)
        Me.pnlManual.TabIndex = 168
        Me.pnlManual.Visible = False
        '
        'btnGetOpenOrders
        '
        Me.btnGetOpenOrders.Location = New System.Drawing.Point(603, 309)
        Me.btnGetOpenOrders.Name = "btnGetOpenOrders"
        Me.btnGetOpenOrders.Size = New System.Drawing.Size(171, 51)
        Me.btnGetOpenOrders.TabIndex = 163
        Me.btnGetOpenOrders.Text = "Open Orders"
        Me.btnGetOpenOrders.UseVisualStyleBackColor = True
        '
        'btnGetPrice
        '
        Me.btnGetPrice.Location = New System.Drawing.Point(427, 29)
        Me.btnGetPrice.Name = "btnGetPrice"
        Me.btnGetPrice.Size = New System.Drawing.Size(171, 51)
        Me.btnGetPrice.TabIndex = 162
        Me.btnGetPrice.Text = "Get Price"
        Me.btnGetPrice.UseVisualStyleBackColor = True
        '
        'txtPriceSymbol
        '
        Me.txtPriceSymbol.Location = New System.Drawing.Point(305, 39)
        Me.txtPriceSymbol.Name = "txtPriceSymbol"
        Me.txtPriceSymbol.Size = New System.Drawing.Size(100, 31)
        Me.txtPriceSymbol.TabIndex = 161
        '
        'btnCloseManual
        '
        Me.btnCloseManual.Location = New System.Drawing.Point(1190, 612)
        Me.btnCloseManual.Margin = New System.Windows.Forms.Padding(6)
        Me.btnCloseManual.Name = "btnCloseManual"
        Me.btnCloseManual.Size = New System.Drawing.Size(162, 44)
        Me.btnCloseManual.TabIndex = 160
        Me.btnCloseManual.Text = "Close"
        Me.btnCloseManual.UseVisualStyleBackColor = True
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(31, 33)
        Me.Label63.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(237, 37)
        Me.Label63.TabIndex = 159
        Me.Label63.Text = "Manual Actions"
        '
        'lblclosedSTCs
        '
        Me.lblclosedSTCs.AutoSize = True
        Me.lblclosedSTCs.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblclosedSTCs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclosedSTCs.Location = New System.Drawing.Point(314, 350)
        Me.lblclosedSTCs.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblclosedSTCs.Name = "lblclosedSTCs"
        Me.lblclosedSTCs.Size = New System.Drawing.Size(35, 37)
        Me.lblclosedSTCs.TabIndex = 158
        Me.lblclosedSTCs.Text = "0"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2182, 1298)
        Me.Controls.Add(Me.pnlManual)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.pnlMan)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnSendOrders)
        Me.Controls.Add(Me.lstErrorResponses)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.cmbWillie)
        Me.Controls.Add(Me.lstServerResponses)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ckRobotOn)
        Me.Controls.Add(Me.bntlistclear)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnWillie)
        Me.Controls.Add(Me.lbldatastring)
        Me.Controls.Add(Me.lblConStatus)
        Me.Controls.Add(Me.Panel2)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "Main"
        Me.Text = "Willie"
        CType(Me.HarvestIndexBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptionwavesdbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptionwavesdbDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlMan.ResumeLayout(False)
        Me.pnlMan.PerformLayout()
        CType(Me.grdContracts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlManual.ResumeLayout(False)
        Me.pnlManual.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblConStatus As Label
    Friend WithEvents OptionwavesdbDataSet As optionwavesdbDataSet
    Friend WithEvents HarvestIndexBindingSource As BindingSource
    Friend WithEvents HarvestIndexTableAdapter As optionwavesdbDataSetTableAdapters.HarvestIndexTableAdapter
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents lbldatastring As Label
    Friend WithEvents OptionwavesdbDataSet1 As optionwavesdbDataSet
    Friend WithEvents lstServerResponses As ListBox
    Friend WithEvents btnWillie As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents bntlistclear As Button
    Friend WithEvents Timer60Sec As Timer
    Friend WithEvents TimerAtTime As Timer
    Friend WithEvents ckRobotOn As CheckBox
    Friend WithEvents btnBackTest As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnDisconnect As Button
    Friend WithEvents txtClientId As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents label2 As Label
    Friend WithEvents txtHost As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnConnect As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents cmbWillie As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents lblBuild As Label
    Friend WithEvents lstConnectionResponses As ListBox
    Friend WithEvents Label32 As Label
    Friend WithEvents lstErrorResponses As ListBox
    Friend WithEvents btnAnalysis As Button
    Friend WithEvents btnSendOrders As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents lblopenBTOs As Label
    Friend WithEvents lblopenSTCs As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlMan As Panel
    Friend WithEvents btnHideManual As Button
    Friend WithEvents Label30 As Label
    Friend WithEvents txtOptionExpirationDate As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtOptionIV As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents txtOptionRight As TextBox
    Friend WithEvents lblOptionStrike As Label
    Friend WithEvents txtOptionStrike As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtOptionSymbol As TextBox
    Friend WithEvents btnOpPrice As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents btnSendOption As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents grdContracts As DataGridView
    Friend WithEvents colSymbol As DataGridViewTextBoxColumn
    Friend WithEvents colExpDate As DataGridViewTextBoxColumn
    Friend WithEvents colStrike As DataGridViewTextBoxColumn
    Friend WithEvents colRight As DataGridViewTextBoxColumn
    Friend WithEvents colConId As DataGridViewTextBoxColumn
    Friend WithEvents btnSpreadOrder As Button
    Friend WithEvents Label31 As Label
    Friend WithEvents txtSpreadExp As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents txtSpreadRight As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents txtSpreadStrike As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents txtSpreadSymbol As TextBox
    Friend WithEvents btnAddLeg As Button
    Friend WithEvents btnOpenFile As Button
    Friend WithEvents Label37 As Label
    Friend WithEvents txtTickId As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents btnGetPrice2 As Button
    Friend WithEvents btnckprice As Button
    Friend WithEvents txtGetPriceSymbol As TextBox
    Friend WithEvents btnTickPrice As Button
    Friend WithEvents btnReqNextValidId As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnSendOrder As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtType As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAction As TextBox
    Friend WithEvents lblSymbol As Label
    Friend WithEvents txtSymbol As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtOrderId As TextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents txtModifyQty As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtModifyPrice As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtModifyType As TextBox
    Friend WithEvents btnModOrder As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents txtModifyAction As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtModifySymbol As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtModifyOrderId As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Label54 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label55 As Label
    Friend WithEvents Button12 As Button
    Friend WithEvents Label56 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label57 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label58 As Label
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label59 As Label
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents Label60 As Label
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents Label61 As Label
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label62 As Label
    Friend WithEvents btnShowManual As Button
    Friend WithEvents pnlManual As Panel
    Friend WithEvents btnCloseManual As Button
    Friend WithEvents Label63 As Label
    Friend WithEvents btnGetPrice As Button
    Friend WithEvents txtPriceSymbol As TextBox
    Friend WithEvents btnGetOpenOrders As Button
    Friend WithEvents Label64 As Label
    Friend WithEvents lblclosedBTOs As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents Label67 As Label
    Friend WithEvents lblclosedSTCs As Label
End Class
