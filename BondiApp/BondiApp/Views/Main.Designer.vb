﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.lblMaxCap = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.lblCurrentCapital = New System.Windows.Forms.Label()
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
        Me.Label42 = New System.Windows.Forms.Label()
        Me.lblTransactions = New System.Windows.Forms.Label()
        Me.lblclosedSTCs = New System.Windows.Forms.Label()
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
        Me.pnlManual = New System.Windows.Forms.Panel()
        Me.Button77 = New System.Windows.Forms.Button()
        Me.Button78 = New System.Windows.Forms.Button()
        Me.Button79 = New System.Windows.Forms.Button()
        Me.Button68 = New System.Windows.Forms.Button()
        Me.Button69 = New System.Windows.Forms.Button()
        Me.Button70 = New System.Windows.Forms.Button()
        Me.Button71 = New System.Windows.Forms.Button()
        Me.Button72 = New System.Windows.Forms.Button()
        Me.Button73 = New System.Windows.Forms.Button()
        Me.Button64 = New System.Windows.Forms.Button()
        Me.Button65 = New System.Windows.Forms.Button()
        Me.Button66 = New System.Windows.Forms.Button()
        Me.Button67 = New System.Windows.Forms.Button()
        Me.Button56 = New System.Windows.Forms.Button()
        Me.Button57 = New System.Windows.Forms.Button()
        Me.Button58 = New System.Windows.Forms.Button()
        Me.Button59 = New System.Windows.Forms.Button()
        Me.Button60 = New System.Windows.Forms.Button()
        Me.Button61 = New System.Windows.Forms.Button()
        Me.Button50 = New System.Windows.Forms.Button()
        Me.Button51 = New System.Windows.Forms.Button()
        Me.Button52 = New System.Windows.Forms.Button()
        Me.Button53 = New System.Windows.Forms.Button()
        Me.Button54 = New System.Windows.Forms.Button()
        Me.Button55 = New System.Windows.Forms.Button()
        Me.Button44 = New System.Windows.Forms.Button()
        Me.Button45 = New System.Windows.Forms.Button()
        Me.Button46 = New System.Windows.Forms.Button()
        Me.Button47 = New System.Windows.Forms.Button()
        Me.Button48 = New System.Windows.Forms.Button()
        Me.Button49 = New System.Windows.Forms.Button()
        Me.Button38 = New System.Windows.Forms.Button()
        Me.Button39 = New System.Windows.Forms.Button()
        Me.Button40 = New System.Windows.Forms.Button()
        Me.Button41 = New System.Windows.Forms.Button()
        Me.Button42 = New System.Windows.Forms.Button()
        Me.Button43 = New System.Windows.Forms.Button()
        Me.Button32 = New System.Windows.Forms.Button()
        Me.Button33 = New System.Windows.Forms.Button()
        Me.Button34 = New System.Windows.Forms.Button()
        Me.Button35 = New System.Windows.Forms.Button()
        Me.Button36 = New System.Windows.Forms.Button()
        Me.Button37 = New System.Windows.Forms.Button()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.Button27 = New System.Windows.Forms.Button()
        Me.Button28 = New System.Windows.Forms.Button()
        Me.Button29 = New System.Windows.Forms.Button()
        Me.Button30 = New System.Windows.Forms.Button()
        Me.Button31 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.BtnManualClear = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.btnGetOpenOrders = New System.Windows.Forms.Button()
        Me.btnGetPrice = New System.Windows.Forms.Button()
        Me.txtPriceSymbol = New System.Windows.Forms.TextBox()
        Me.btnCloseManual = New System.Windows.Forms.Button()
        Me.Label63 = New System.Windows.Forms.Label()
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
        Me.btnCloseApp = New System.Windows.Forms.Button()
        Me.btnBackTesting = New System.Windows.Forms.Button()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.btnShowManual = New System.Windows.Forms.Button()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnlBacktest = New System.Windows.Forms.Panel()
        Me.btnBacktestClear = New System.Windows.Forms.Button()
        Me.lblHarvestKey = New System.Windows.Forms.Label()
        Me.btnStartBackTest = New System.Windows.Forms.Button()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.cmbBackTestIndexes = New System.Windows.Forms.ComboBox()
        Me.btnAssembleDataFileDIrectPull = New System.Windows.Forms.Button()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDatafileSymbol = New System.Windows.Forms.Label()
        Me.txtLoadSymbol = New System.Windows.Forms.TextBox()
        Me.btnAssembleDataFile = New System.Windows.Forms.Button()
        Me.btnHideBackTesting = New System.Windows.Forms.Button()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        CType(Me.HarvestIndexBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionwavesdbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionwavesdbDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlMan.SuspendLayout()
        CType(Me.grdContracts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlManual.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBacktest.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblConStatus
        '
        Me.lblConStatus.AutoSize = True
        Me.lblConStatus.Location = New System.Drawing.Point(165, 496)
        Me.lblConStatus.Name = "lblConStatus"
        Me.lblConStatus.Size = New System.Drawing.Size(44, 13)
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
        Me.lbldatastring.Location = New System.Drawing.Point(707, 496)
        Me.lbldatastring.Name = "lbldatastring"
        Me.lbldatastring.Size = New System.Drawing.Size(122, 13)
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
        Me.lstServerResponses.Location = New System.Drawing.Point(165, 511)
        Me.lstServerResponses.Margin = New System.Windows.Forms.Padding(2)
        Me.lstServerResponses.Name = "lstServerResponses"
        Me.lstServerResponses.Size = New System.Drawing.Size(804, 69)
        Me.lstServerResponses.TabIndex = 48
        '
        'btnWillie
        '
        Me.btnWillie.Location = New System.Drawing.Point(1573, 800)
        Me.btnWillie.Name = "btnWillie"
        Me.btnWillie.Size = New System.Drawing.Size(151, 32)
        Me.btnWillie.TabIndex = 49
        Me.btnWillie.Text = "Start Willie"
        Me.btnWillie.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(1573, 740)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(81, 23)
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
        Me.bntlistclear.Location = New System.Drawing.Point(1571, 769)
        Me.bntlistclear.Name = "bntlistclear"
        Me.bntlistclear.Size = New System.Drawing.Size(81, 23)
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
        Me.ckRobotOn.Location = New System.Drawing.Point(1674, 715)
        Me.ckRobotOn.Name = "ckRobotOn"
        Me.ckRobotOn.Size = New System.Drawing.Size(52, 17)
        Me.ckRobotOn.TabIndex = 69
        Me.ckRobotOn.Text = "Timer"
        Me.ckRobotOn.UseVisualStyleBackColor = True
        '
        'btnBackTest
        '
        Me.btnBackTest.Location = New System.Drawing.Point(14, 429)
        Me.btnBackTest.Name = "btnBackTest"
        Me.btnBackTest.Size = New System.Drawing.Size(67, 23)
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
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1219, 52)
        Me.Panel1.TabIndex = 85
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Location = New System.Drawing.Point(1135, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 23)
        Me.Button1.TabIndex = 73
        Me.Button1.Text = "SETTINGS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(8, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(292, 24)
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
        Me.Panel3.Location = New System.Drawing.Point(150, 56)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(688, 31)
        Me.Panel3.TabIndex = 87
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(526, 5)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(72, 23)
        Me.btnConnect.TabIndex = 66
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(604, 5)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(72, 23)
        Me.btnDisconnect.TabIndex = 65
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(4, 4)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(186, 24)
        Me.Label25.TabIndex = 90
        Me.Label25.Text = "Robot Control Center"
        '
        'txtClientId
        '
        Me.txtClientId.Location = New System.Drawing.Point(470, 7)
        Me.txtClientId.Name = "txtClientId"
        Me.txtClientId.Size = New System.Drawing.Size(38, 20)
        Me.txtClientId.TabIndex = 64
        Me.txtClientId.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(418, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 13)
        Me.Label18.TabIndex = 63
        Me.Label18.Text = "Client Id"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(374, 6)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(38, 20)
        Me.txtPort.TabIndex = 62
        Me.txtPort.Text = "7497"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(338, 8)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(26, 13)
        Me.label2.TabIndex = 61
        Me.label2.Text = "Port"
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(273, 6)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(59, 20)
        Me.txtHost.TabIndex = 3
        Me.txtHost.Text = "127.0.0.1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(240, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Host"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblBuild)
        Me.Panel5.Controls.Add(Me.Label32)
        Me.Panel5.Controls.Add(Me.lstConnectionResponses)
        Me.Panel5.Location = New System.Drawing.Point(159, 670)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(810, 31)
        Me.Panel5.TabIndex = 89
        '
        'lblBuild
        '
        Me.lblBuild.AutoSize = True
        Me.lblBuild.Location = New System.Drawing.Point(601, 10)
        Me.lblBuild.Name = "lblBuild"
        Me.lblBuild.Size = New System.Drawing.Size(66, 13)
        Me.lblBuild.TabIndex = 94
        Me.lblBuild.Text = "build version"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(9, 10)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(97, 13)
        Me.Label32.TabIndex = 123
        Me.Label32.Text = "Connection Status:"
        '
        'lstConnectionResponses
        '
        Me.lstConnectionResponses.BackColor = System.Drawing.SystemColors.MenuBar
        Me.lstConnectionResponses.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstConnectionResponses.FormattingEnabled = True
        Me.lstConnectionResponses.Location = New System.Drawing.Point(111, 10)
        Me.lstConnectionResponses.Margin = New System.Windows.Forms.Padding(2)
        Me.lstConnectionResponses.Name = "lstConnectionResponses"
        Me.lstConnectionResponses.Size = New System.Drawing.Size(324, 13)
        Me.lstConnectionResponses.TabIndex = 122
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(162, 655)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(165, 13)
        Me.lblStatus.TabIndex = 68
        Me.lblStatus.Text = "Welcome to Resignation Trading!"
        '
        'cmbWillie
        '
        Me.cmbWillie.FormattingEnabled = True
        Me.cmbWillie.Location = New System.Drawing.Point(1430, 711)
        Me.cmbWillie.Name = "cmbWillie"
        Me.cmbWillie.Size = New System.Drawing.Size(206, 21)
        Me.cmbWillie.TabIndex = 91
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(1304, 714)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(120, 13)
        Me.Label26.TabIndex = 92
        Me.Label26.Text = "Select Harvest Product:"
        '
        'lstErrorResponses
        '
        Me.lstErrorResponses.FormattingEnabled = True
        Me.lstErrorResponses.Location = New System.Drawing.Point(165, 584)
        Me.lstErrorResponses.Margin = New System.Windows.Forms.Padding(2)
        Me.lstErrorResponses.Name = "lstErrorResponses"
        Me.lstErrorResponses.Size = New System.Drawing.Size(804, 69)
        Me.lstErrorResponses.TabIndex = 124
        '
        'btnAnalysis
        '
        Me.btnAnalysis.Location = New System.Drawing.Point(14, 400)
        Me.btnAnalysis.Name = "btnAnalysis"
        Me.btnAnalysis.Size = New System.Drawing.Size(67, 23)
        Me.btnAnalysis.TabIndex = 125
        Me.btnAnalysis.Text = "Analysis"
        Me.btnAnalysis.UseVisualStyleBackColor = True
        '
        'btnSendOrders
        '
        Me.btnSendOrders.Location = New System.Drawing.Point(1300, 741)
        Me.btnSendOrders.Name = "btnSendOrders"
        Me.btnSendOrders.Size = New System.Drawing.Size(83, 25)
        Me.btnSendOrders.TabIndex = 132
        Me.btnSendOrders.Text = "Send Order"
        Me.btnSendOrders.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(14, 501)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(117, 33)
        Me.Button3.TabIndex = 134
        Me.Button3.Text = "Analysis"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(14, 458)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(117, 33)
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
        Me.Label38.Location = New System.Drawing.Point(14, 9)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(166, 17)
        Me.Label38.TabIndex = 136
        Me.Label38.Text = "Real-Time Dashboard"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(51, 60)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(43, 17)
        Me.Label39.TabIndex = 137
        Me.Label39.Text = "Open"
        '
        'lblopenBTOs
        '
        Me.lblopenBTOs.AutoSize = True
        Me.lblopenBTOs.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblopenBTOs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblopenBTOs.Location = New System.Drawing.Point(63, 92)
        Me.lblopenBTOs.Name = "lblopenBTOs"
        Me.lblopenBTOs.Size = New System.Drawing.Size(18, 20)
        Me.lblopenBTOs.TabIndex = 138
        Me.lblopenBTOs.Text = "0"
        '
        'lblopenSTCs
        '
        Me.lblopenSTCs.AutoSize = True
        Me.lblopenSTCs.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblopenSTCs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblopenSTCs.Location = New System.Drawing.Point(63, 182)
        Me.lblopenSTCs.Name = "lblopenSTCs"
        Me.lblopenSTCs.Size = New System.Drawing.Size(18, 20)
        Me.lblopenSTCs.TabIndex = 140
        Me.lblopenSTCs.Text = "0"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(98, 126)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(35, 17)
        Me.Label41.TabIndex = 139
        Me.Label41.Text = "STC"
        '
        'lblMaxCap
        '
        Me.lblMaxCap.AutoSize = True
        Me.lblMaxCap.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblMaxCap.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaxCap.Location = New System.Drawing.Point(161, 452)
        Me.lblMaxCap.Name = "lblMaxCap"
        Me.lblMaxCap.Size = New System.Drawing.Size(80, 17)
        Me.lblMaxCap.TabIndex = 142
        Me.lblMaxCap.Text = "000,000.00"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(22, 452)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(84, 17)
        Me.Label43.TabIndex = 141
        Me.Label43.Text = "Max Capital:"
        '
        'lblCurrentCapital
        '
        Me.lblCurrentCapital.AutoSize = True
        Me.lblCurrentCapital.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblCurrentCapital.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentCapital.Location = New System.Drawing.Point(161, 480)
        Me.lblCurrentCapital.Name = "lblCurrentCapital"
        Me.lblCurrentCapital.Size = New System.Drawing.Size(80, 17)
        Me.lblCurrentCapital.TabIndex = 144
        Me.lblCurrentCapital.Text = "000,000.00"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(22, 480)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(106, 17)
        Me.Label45.TabIndex = 143
        Me.Label45.Text = "Current Capital:"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(204, 508)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(16, 17)
        Me.Label46.TabIndex = 146
        Me.Label46.Text = "0"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(22, 508)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(162, 17)
        Me.Label47.TabIndex = 145
        Me.Label47.Text = "Hedge Positions Closed:"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(204, 537)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(16, 17)
        Me.Label48.TabIndex = 148
        Me.Label48.Text = "0"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(22, 537)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(119, 17)
        Me.Label49.TabIndex = 147
        Me.Label49.Text = "Daily Stock Profit:"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(204, 564)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(16, 17)
        Me.Label50.TabIndex = 150
        Me.Label50.Text = "0"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(22, 564)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(126, 17)
        Me.Label51.TabIndex = 149
        Me.Label51.Text = "Daily Hedge Profit:"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(204, 590)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(16, 17)
        Me.Label52.TabIndex = 152
        Me.Label52.Text = "0"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(22, 590)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(116, 17)
        Me.Label53.TabIndex = 151
        Me.Label53.Text = "Daily Total Profit:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel2.Controls.Add(Me.Label42)
        Me.Panel2.Controls.Add(Me.lblTransactions)
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
        Me.Panel2.Controls.Add(Me.lblMaxCap)
        Me.Panel2.Controls.Add(Me.Label45)
        Me.Panel2.Controls.Add(Me.Label52)
        Me.Panel2.Controls.Add(Me.lblCurrentCapital)
        Me.Panel2.Controls.Add(Me.Label53)
        Me.Panel2.Controls.Add(Me.Label47)
        Me.Panel2.Controls.Add(Me.Label50)
        Me.Panel2.Controls.Add(Me.Label46)
        Me.Panel2.Controls.Add(Me.Label51)
        Me.Panel2.Controls.Add(Me.Label49)
        Me.Panel2.Controls.Add(Me.Label48)
        Me.Panel2.Location = New System.Drawing.Point(974, 53)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(245, 648)
        Me.Panel2.TabIndex = 153
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(3, 425)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(130, 17)
        Me.Label42.TabIndex = 159
        Me.Label42.Text = "Total Transactions:"
        '
        'lblTransactions
        '
        Me.lblTransactions.AutoSize = True
        Me.lblTransactions.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTransactions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactions.Location = New System.Drawing.Point(136, 425)
        Me.lblTransactions.Name = "lblTransactions"
        Me.lblTransactions.Size = New System.Drawing.Size(88, 17)
        Me.lblTransactions.TabIndex = 160
        Me.lblTransactions.Text = "000,000,000"
        '
        'lblclosedSTCs
        '
        Me.lblclosedSTCs.AutoSize = True
        Me.lblclosedSTCs.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblclosedSTCs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclosedSTCs.Location = New System.Drawing.Point(157, 182)
        Me.lblclosedSTCs.Name = "lblclosedSTCs"
        Me.lblclosedSTCs.Size = New System.Drawing.Size(18, 20)
        Me.lblclosedSTCs.TabIndex = 158
        Me.lblclosedSTCs.Text = "0"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(132, 150)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(51, 17)
        Me.Label66.TabIndex = 157
        Me.Label66.Text = "Closed"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(51, 150)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(43, 17)
        Me.Label67.TabIndex = 156
        Me.Label67.Text = "Open"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(132, 60)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(51, 17)
        Me.Label64.TabIndex = 154
        Me.Label64.Text = "Closed"
        '
        'lblclosedBTOs
        '
        Me.lblclosedBTOs.AutoSize = True
        Me.lblclosedBTOs.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblclosedBTOs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclosedBTOs.Location = New System.Drawing.Point(157, 92)
        Me.lblclosedBTOs.Name = "lblclosedBTOs"
        Me.lblclosedBTOs.Size = New System.Drawing.Size(18, 20)
        Me.lblclosedBTOs.TabIndex = 155
        Me.lblclosedBTOs.Text = "0"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(95, 38)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(37, 17)
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
        Me.pnlMan.Location = New System.Drawing.Point(158, 714)
        Me.pnlMan.Name = "pnlMan"
        Me.pnlMan.Size = New System.Drawing.Size(696, 294)
        Me.pnlMan.TabIndex = 154
        Me.pnlMan.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(124, 103)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(170, 13)
        Me.Label29.TabIndex = 204
        Me.Label29.Text = "Additional Controls Here If Needed"
        '
        'grdContracts
        '
        Me.grdContracts.AllowUserToAddRows = False
        Me.grdContracts.AllowUserToDeleteRows = False
        Me.grdContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdContracts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSymbol, Me.colExpDate, Me.colStrike, Me.colRight, Me.colConId})
        Me.grdContracts.Location = New System.Drawing.Point(25, 184)
        Me.grdContracts.Name = "grdContracts"
        Me.grdContracts.ReadOnly = True
        Me.grdContracts.Size = New System.Drawing.Size(393, 96)
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
        Me.btnSpreadOrder.Location = New System.Drawing.Point(309, 153)
        Me.btnSpreadOrder.Name = "btnSpreadOrder"
        Me.btnSpreadOrder.Size = New System.Drawing.Size(100, 23)
        Me.btnSpreadOrder.TabIndex = 202
        Me.btnSpreadOrder.Text = "Send Spread "
        Me.btnSpreadOrder.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(116, 132)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(79, 13)
        Me.Label31.TabIndex = 201
        Me.Label31.Text = "Expiration Date"
        '
        'txtSpreadExp
        '
        Me.txtSpreadExp.Location = New System.Drawing.Point(201, 129)
        Me.txtSpreadExp.Name = "txtSpreadExp"
        Me.txtSpreadExp.Size = New System.Drawing.Size(98, 20)
        Me.txtSpreadExp.TabIndex = 200
        Me.txtSpreadExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(118, 158)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(36, 13)
        Me.Label34.TabIndex = 199
        Me.Label34.Text = "P or C"
        '
        'txtSpreadRight
        '
        Me.txtSpreadRight.Location = New System.Drawing.Point(154, 155)
        Me.txtSpreadRight.Name = "txtSpreadRight"
        Me.txtSpreadRight.Size = New System.Drawing.Size(41, 20)
        Me.txtSpreadRight.TabIndex = 198
        Me.txtSpreadRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(22, 158)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(34, 13)
        Me.Label35.TabIndex = 197
        Me.Label35.Text = "Strike"
        '
        'txtSpreadStrike
        '
        Me.txtSpreadStrike.Location = New System.Drawing.Point(69, 155)
        Me.txtSpreadStrike.Name = "txtSpreadStrike"
        Me.txtSpreadStrike.Size = New System.Drawing.Size(41, 20)
        Me.txtSpreadStrike.TabIndex = 196
        Me.txtSpreadStrike.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(22, 132)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(41, 13)
        Me.Label36.TabIndex = 195
        Me.Label36.Text = "Symbol"
        '
        'txtSpreadSymbol
        '
        Me.txtSpreadSymbol.Location = New System.Drawing.Point(69, 129)
        Me.txtSpreadSymbol.Name = "txtSpreadSymbol"
        Me.txtSpreadSymbol.Size = New System.Drawing.Size(41, 20)
        Me.txtSpreadSymbol.TabIndex = 194
        Me.txtSpreadSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAddLeg
        '
        Me.btnAddLeg.Location = New System.Drawing.Point(202, 155)
        Me.btnAddLeg.Name = "btnAddLeg"
        Me.btnAddLeg.Size = New System.Drawing.Size(92, 23)
        Me.btnAddLeg.TabIndex = 193
        Me.btnAddLeg.Text = "Add Leg"
        Me.btnAddLeg.UseVisualStyleBackColor = True
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(309, 103)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(100, 23)
        Me.btnOpenFile.TabIndex = 192
        Me.btnOpenFile.Text = "Load File"
        Me.btnOpenFile.UseVisualStyleBackColor = True
        Me.btnOpenFile.Visible = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(531, 118)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(67, 13)
        Me.Label37.TabIndex = 190
        Me.Label37.Text = "Tick Type Id"
        '
        'txtTickId
        '
        Me.txtTickId.Location = New System.Drawing.Point(606, 115)
        Me.txtTickId.Name = "txtTickId"
        Me.txtTickId.Size = New System.Drawing.Size(41, 20)
        Me.txtTickId.TabIndex = 189
        Me.txtTickId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(534, 151)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(67, 13)
        Me.Label33.TabIndex = 188
        Me.Label33.Text = "App Controls"
        '
        'btnGetPrice2
        '
        Me.btnGetPrice2.Location = New System.Drawing.Point(614, 146)
        Me.btnGetPrice2.Name = "btnGetPrice2"
        Me.btnGetPrice2.Size = New System.Drawing.Size(67, 23)
        Me.btnGetPrice2.TabIndex = 185
        Me.btnGetPrice2.Text = "Get Price"
        Me.btnGetPrice2.UseVisualStyleBackColor = True
        '
        'btnckprice
        '
        Me.btnckprice.Location = New System.Drawing.Point(614, 175)
        Me.btnckprice.Name = "btnckprice"
        Me.btnckprice.Size = New System.Drawing.Size(67, 23)
        Me.btnckprice.TabIndex = 187
        Me.btnckprice.Text = "Price"
        Me.btnckprice.UseVisualStyleBackColor = True
        '
        'txtGetPriceSymbol
        '
        Me.txtGetPriceSymbol.Location = New System.Drawing.Point(491, 177)
        Me.txtGetPriceSymbol.Name = "txtGetPriceSymbol"
        Me.txtGetPriceSymbol.Size = New System.Drawing.Size(42, 20)
        Me.txtGetPriceSymbol.TabIndex = 186
        Me.txtGetPriceSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnTickPrice
        '
        Me.btnTickPrice.Location = New System.Drawing.Point(538, 86)
        Me.btnTickPrice.Name = "btnTickPrice"
        Me.btnTickPrice.Size = New System.Drawing.Size(100, 23)
        Me.btnTickPrice.TabIndex = 191
        Me.btnTickPrice.Text = "Get Tick"
        Me.btnTickPrice.UseVisualStyleBackColor = True
        '
        'btnReqNextValidId
        '
        Me.btnReqNextValidId.Location = New System.Drawing.Point(540, 174)
        Me.btnReqNextValidId.Name = "btnReqNextValidId"
        Me.btnReqNextValidId.Size = New System.Drawing.Size(67, 23)
        Me.btnReqNextValidId.TabIndex = 184
        Me.btnReqNextValidId.Text = "OrderId"
        Me.btnReqNextValidId.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(111, 57)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(79, 13)
        Me.Label30.TabIndex = 182
        Me.Label30.Text = "Expiration Date"
        '
        'txtOptionExpirationDate
        '
        Me.txtOptionExpirationDate.Location = New System.Drawing.Point(194, 54)
        Me.txtOptionExpirationDate.Name = "txtOptionExpirationDate"
        Me.txtOptionExpirationDate.Size = New System.Drawing.Size(98, 20)
        Me.txtOptionExpirationDate.TabIndex = 181
        Me.txtOptionExpirationDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(468, 57)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(17, 13)
        Me.Label28.TabIndex = 180
        Me.Label28.Text = "IV"
        '
        'txtOptionIV
        '
        Me.txtOptionIV.Location = New System.Drawing.Point(522, 54)
        Me.txtOptionIV.Name = "txtOptionIV"
        Me.txtOptionIV.Size = New System.Drawing.Size(41, 20)
        Me.txtOptionIV.TabIndex = 179
        Me.txtOptionIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(382, 57)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(36, 13)
        Me.Label27.TabIndex = 178
        Me.Label27.Text = "P or C"
        '
        'txtOptionRight
        '
        Me.txtOptionRight.Location = New System.Drawing.Point(418, 54)
        Me.txtOptionRight.Name = "txtOptionRight"
        Me.txtOptionRight.Size = New System.Drawing.Size(41, 20)
        Me.txtOptionRight.TabIndex = 177
        Me.txtOptionRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOptionStrike
        '
        Me.lblOptionStrike.AutoSize = True
        Me.lblOptionStrike.Location = New System.Drawing.Point(298, 57)
        Me.lblOptionStrike.Name = "lblOptionStrike"
        Me.lblOptionStrike.Size = New System.Drawing.Size(34, 13)
        Me.lblOptionStrike.TabIndex = 176
        Me.lblOptionStrike.Text = "Strike"
        '
        'txtOptionStrike
        '
        Me.txtOptionStrike.Location = New System.Drawing.Point(334, 54)
        Me.txtOptionStrike.Name = "txtOptionStrike"
        Me.txtOptionStrike.Size = New System.Drawing.Size(41, 20)
        Me.txtOptionStrike.TabIndex = 175
        Me.txtOptionStrike.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(4, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 174
        Me.Label16.Text = "Symbol"
        '
        'txtOptionSymbol
        '
        Me.txtOptionSymbol.Location = New System.Drawing.Point(59, 54)
        Me.txtOptionSymbol.Name = "txtOptionSymbol"
        Me.txtOptionSymbol.Size = New System.Drawing.Size(41, 20)
        Me.txtOptionSymbol.TabIndex = 173
        Me.txtOptionSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnOpPrice
        '
        Me.btnOpPrice.Location = New System.Drawing.Point(570, 52)
        Me.btnOpPrice.Name = "btnOpPrice"
        Me.btnOpPrice.Size = New System.Drawing.Size(101, 23)
        Me.btnOpPrice.TabIndex = 172
        Me.btnOpPrice.Text = "Opt Price"
        Me.btnOpPrice.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(468, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 171
        Me.Label17.Text = "Quantity"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(522, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(41, 20)
        Me.TextBox1.TabIndex = 170
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(382, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 169
        Me.Label20.Text = "Price"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(418, 9)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(41, 20)
        Me.TextBox2.TabIndex = 168
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(297, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 13)
        Me.Label21.TabIndex = 167
        Me.Label21.Text = "Type"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(335, 9)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(41, 20)
        Me.TextBox3.TabIndex = 166
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(207, 16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(37, 13)
        Me.Label22.TabIndex = 165
        Me.Label22.Text = "Action"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(250, 13)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(41, 20)
        Me.TextBox4.TabIndex = 164
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(111, 12)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(41, 13)
        Me.Label23.TabIndex = 163
        Me.Label23.Text = "Symbol"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(158, 13)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(41, 20)
        Me.TextBox5.TabIndex = 162
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 16)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(44, 13)
        Me.Label24.TabIndex = 161
        Me.Label24.Text = "OrderID"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(59, 9)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(41, 20)
        Me.TextBox6.TabIndex = 160
        Me.TextBox6.Text = "0"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSendOption
        '
        Me.btnSendOption.Location = New System.Drawing.Point(570, 12)
        Me.btnSendOption.Name = "btnSendOption"
        Me.btnSendOption.Size = New System.Drawing.Size(102, 23)
        Me.btnSendOption.TabIndex = 159
        Me.btnSendOption.Text = "Option Order"
        Me.btnSendOption.UseVisualStyleBackColor = True
        '
        'btnHideManual
        '
        Me.btnHideManual.Location = New System.Drawing.Point(540, 234)
        Me.btnHideManual.Name = "btnHideManual"
        Me.btnHideManual.Size = New System.Drawing.Size(141, 46)
        Me.btnHideManual.TabIndex = 132
        Me.btnHideManual.Text = "Close Manual"
        Me.btnHideManual.UseVisualStyleBackColor = True
        '
        'pnlManual
        '
        Me.pnlManual.Controls.Add(Me.Button77)
        Me.pnlManual.Controls.Add(Me.Button78)
        Me.pnlManual.Controls.Add(Me.Button79)
        Me.pnlManual.Controls.Add(Me.Button68)
        Me.pnlManual.Controls.Add(Me.Button69)
        Me.pnlManual.Controls.Add(Me.Button70)
        Me.pnlManual.Controls.Add(Me.Button71)
        Me.pnlManual.Controls.Add(Me.Button72)
        Me.pnlManual.Controls.Add(Me.Button73)
        Me.pnlManual.Controls.Add(Me.Button64)
        Me.pnlManual.Controls.Add(Me.Button65)
        Me.pnlManual.Controls.Add(Me.Button66)
        Me.pnlManual.Controls.Add(Me.Button67)
        Me.pnlManual.Controls.Add(Me.Button56)
        Me.pnlManual.Controls.Add(Me.Button57)
        Me.pnlManual.Controls.Add(Me.Button58)
        Me.pnlManual.Controls.Add(Me.Button59)
        Me.pnlManual.Controls.Add(Me.Button60)
        Me.pnlManual.Controls.Add(Me.Button61)
        Me.pnlManual.Controls.Add(Me.Button50)
        Me.pnlManual.Controls.Add(Me.Button51)
        Me.pnlManual.Controls.Add(Me.Button52)
        Me.pnlManual.Controls.Add(Me.Button53)
        Me.pnlManual.Controls.Add(Me.Button54)
        Me.pnlManual.Controls.Add(Me.Button55)
        Me.pnlManual.Controls.Add(Me.Button44)
        Me.pnlManual.Controls.Add(Me.Button45)
        Me.pnlManual.Controls.Add(Me.Button46)
        Me.pnlManual.Controls.Add(Me.Button47)
        Me.pnlManual.Controls.Add(Me.Button48)
        Me.pnlManual.Controls.Add(Me.Button49)
        Me.pnlManual.Controls.Add(Me.Button38)
        Me.pnlManual.Controls.Add(Me.Button39)
        Me.pnlManual.Controls.Add(Me.Button40)
        Me.pnlManual.Controls.Add(Me.Button41)
        Me.pnlManual.Controls.Add(Me.Button42)
        Me.pnlManual.Controls.Add(Me.Button43)
        Me.pnlManual.Controls.Add(Me.Button32)
        Me.pnlManual.Controls.Add(Me.Button33)
        Me.pnlManual.Controls.Add(Me.Button34)
        Me.pnlManual.Controls.Add(Me.Button35)
        Me.pnlManual.Controls.Add(Me.Button36)
        Me.pnlManual.Controls.Add(Me.Button37)
        Me.pnlManual.Controls.Add(Me.Button26)
        Me.pnlManual.Controls.Add(Me.Button27)
        Me.pnlManual.Controls.Add(Me.Button28)
        Me.pnlManual.Controls.Add(Me.Button29)
        Me.pnlManual.Controls.Add(Me.Button30)
        Me.pnlManual.Controls.Add(Me.Button31)
        Me.pnlManual.Controls.Add(Me.Button20)
        Me.pnlManual.Controls.Add(Me.Button21)
        Me.pnlManual.Controls.Add(Me.Button22)
        Me.pnlManual.Controls.Add(Me.Button23)
        Me.pnlManual.Controls.Add(Me.Button24)
        Me.pnlManual.Controls.Add(Me.Button25)
        Me.pnlManual.Controls.Add(Me.BtnManualClear)
        Me.pnlManual.Controls.Add(Me.Button17)
        Me.pnlManual.Controls.Add(Me.Button18)
        Me.pnlManual.Controls.Add(Me.Button15)
        Me.pnlManual.Controls.Add(Me.Button16)
        Me.pnlManual.Controls.Add(Me.Button14)
        Me.pnlManual.Controls.Add(Me.Button13)
        Me.pnlManual.Controls.Add(Me.btnGetPrice)
        Me.pnlManual.Controls.Add(Me.txtPriceSymbol)
        Me.pnlManual.Controls.Add(Me.btnCloseManual)
        Me.pnlManual.Controls.Add(Me.Label63)
        Me.pnlManual.Location = New System.Drawing.Point(150, 89)
        Me.pnlManual.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlManual.Name = "pnlManual"
        Me.pnlManual.Size = New System.Drawing.Size(831, 381)
        Me.pnlManual.TabIndex = 168
        '
        'Button77
        '
        Me.Button77.Location = New System.Drawing.Point(687, 319)
        Me.Button77.Margin = New System.Windows.Forms.Padding(2)
        Me.Button77.Name = "Button77"
        Me.Button77.Size = New System.Drawing.Size(132, 27)
        Me.Button77.TabIndex = 227
        Me.Button77.Text = "XX Cancel Tick-By-Tick"
        Me.Button77.UseVisualStyleBackColor = True
        '
        'Button78
        '
        Me.Button78.Location = New System.Drawing.Point(551, 319)
        Me.Button78.Margin = New System.Windows.Forms.Padding(2)
        Me.Button78.Name = "Button78"
        Me.Button78.Size = New System.Drawing.Size(132, 27)
        Me.Button78.TabIndex = 226
        Me.Button78.Text = "XX Req Tick-By-Tick"
        Me.Button78.UseVisualStyleBackColor = True
        '
        'Button79
        '
        Me.Button79.Location = New System.Drawing.Point(7, 350)
        Me.Button79.Margin = New System.Windows.Forms.Padding(2)
        Me.Button79.Name = "Button79"
        Me.Button79.Size = New System.Drawing.Size(132, 27)
        Me.Button79.TabIndex = 225
        Me.Button79.Text = "XX Req Historical Ticks"
        Me.Button79.UseVisualStyleBackColor = True
        '
        'Button68
        '
        Me.Button68.Location = New System.Drawing.Point(687, 287)
        Me.Button68.Margin = New System.Windows.Forms.Padding(2)
        Me.Button68.Name = "Button68"
        Me.Button68.Size = New System.Drawing.Size(132, 27)
        Me.Button68.TabIndex = 224
        Me.Button68.Text = "Cancel PnL Single"
        Me.Button68.UseVisualStyleBackColor = True
        '
        'Button69
        '
        Me.Button69.Location = New System.Drawing.Point(551, 287)
        Me.Button69.Margin = New System.Windows.Forms.Padding(2)
        Me.Button69.Name = "Button69"
        Me.Button69.Size = New System.Drawing.Size(132, 27)
        Me.Button69.TabIndex = 223
        Me.Button69.Text = "Req PnL Single"
        Me.Button69.UseVisualStyleBackColor = True
        '
        'Button70
        '
        Me.Button70.Location = New System.Drawing.Point(415, 319)
        Me.Button70.Margin = New System.Windows.Forms.Padding(2)
        Me.Button70.Name = "Button70"
        Me.Button70.Size = New System.Drawing.Size(132, 27)
        Me.Button70.TabIndex = 222
        Me.Button70.Text = "Cancel Acct Summary"
        Me.Button70.UseVisualStyleBackColor = True
        '
        'Button71
        '
        Me.Button71.Location = New System.Drawing.Point(279, 319)
        Me.Button71.Margin = New System.Windows.Forms.Padding(2)
        Me.Button71.Name = "Button71"
        Me.Button71.Size = New System.Drawing.Size(132, 27)
        Me.Button71.TabIndex = 221
        Me.Button71.Text = "Req Account Summary"
        Me.Button71.UseVisualStyleBackColor = True
        '
        'Button72
        '
        Me.Button72.Location = New System.Drawing.Point(143, 319)
        Me.Button72.Margin = New System.Windows.Forms.Padding(2)
        Me.Button72.Name = "Button72"
        Me.Button72.Size = New System.Drawing.Size(132, 27)
        Me.Button72.TabIndex = 220
        Me.Button72.Text = "XX Cancel Place Order"
        Me.Button72.UseVisualStyleBackColor = True
        '
        'Button73
        '
        Me.Button73.Location = New System.Drawing.Point(7, 319)
        Me.Button73.Margin = New System.Windows.Forms.Padding(2)
        Me.Button73.Name = "Button73"
        Me.Button73.Size = New System.Drawing.Size(132, 27)
        Me.Button73.TabIndex = 219
        Me.Button73.Text = "XX Place Order"
        Me.Button73.UseVisualStyleBackColor = True
        '
        'Button64
        '
        Me.Button64.Location = New System.Drawing.Point(415, 287)
        Me.Button64.Margin = New System.Windows.Forms.Padding(2)
        Me.Button64.Name = "Button64"
        Me.Button64.Size = New System.Drawing.Size(132, 27)
        Me.Button64.TabIndex = 216
        Me.Button64.Text = "XX Cancel Positions"
        Me.Button64.UseVisualStyleBackColor = True
        '
        'Button65
        '
        Me.Button65.Location = New System.Drawing.Point(279, 287)
        Me.Button65.Margin = New System.Windows.Forms.Padding(2)
        Me.Button65.Name = "Button65"
        Me.Button65.Size = New System.Drawing.Size(132, 27)
        Me.Button65.TabIndex = 215
        Me.Button65.Text = "XX Req Positions"
        Me.Button65.UseVisualStyleBackColor = True
        '
        'Button66
        '
        Me.Button66.Location = New System.Drawing.Point(143, 287)
        Me.Button66.Margin = New System.Windows.Forms.Padding(2)
        Me.Button66.Name = "Button66"
        Me.Button66.Size = New System.Drawing.Size(132, 27)
        Me.Button66.TabIndex = 214
        Me.Button66.Text = "Req Family Codes"
        Me.Button66.UseVisualStyleBackColor = True
        '
        'Button67
        '
        Me.Button67.Location = New System.Drawing.Point(7, 287)
        Me.Button67.Margin = New System.Windows.Forms.Padding(2)
        Me.Button67.Name = "Button67"
        Me.Button67.Size = New System.Drawing.Size(132, 27)
        Me.Button67.TabIndex = 213
        Me.Button67.Text = "What If..."
        Me.Button67.UseVisualStyleBackColor = True
        '
        'Button56
        '
        Me.Button56.Location = New System.Drawing.Point(687, 256)
        Me.Button56.Margin = New System.Windows.Forms.Padding(2)
        Me.Button56.Name = "Button56"
        Me.Button56.Size = New System.Drawing.Size(132, 27)
        Me.Button56.TabIndex = 212
        Me.Button56.Text = "Cancel PnL"
        Me.Button56.UseVisualStyleBackColor = True
        '
        'Button57
        '
        Me.Button57.Location = New System.Drawing.Point(551, 256)
        Me.Button57.Margin = New System.Windows.Forms.Padding(2)
        Me.Button57.Name = "Button57"
        Me.Button57.Size = New System.Drawing.Size(132, 27)
        Me.Button57.TabIndex = 211
        Me.Button57.Text = "Req PnL"
        Me.Button57.UseVisualStyleBackColor = True
        '
        'Button58
        '
        Me.Button58.Location = New System.Drawing.Point(415, 256)
        Me.Button58.Margin = New System.Windows.Forms.Padding(2)
        Me.Button58.Name = "Button58"
        Me.Button58.Size = New System.Drawing.Size(132, 27)
        Me.Button58.TabIndex = 210
        Me.Button58.Text = "Req Sec DepOptParam"
        Me.Button58.UseVisualStyleBackColor = True
        '
        'Button59
        '
        Me.Button59.Location = New System.Drawing.Point(279, 256)
        Me.Button59.Margin = New System.Windows.Forms.Padding(2)
        Me.Button59.Name = "Button59"
        Me.Button59.Size = New System.Drawing.Size(132, 27)
        Me.Button59.TabIndex = 209
        Me.Button59.Text = "XX Req Mkt Data Type"
        Me.Button59.UseVisualStyleBackColor = True
        '
        'Button60
        '
        Me.Button60.Location = New System.Drawing.Point(143, 256)
        Me.Button60.Margin = New System.Windows.Forms.Padding(2)
        Me.Button60.Name = "Button60"
        Me.Button60.Size = New System.Drawing.Size(132, 27)
        Me.Button60.TabIndex = 208
        Me.Button60.Text = "XX Cancel Calc Opt Price"
        Me.Button60.UseVisualStyleBackColor = True
        '
        'Button61
        '
        Me.Button61.Location = New System.Drawing.Point(7, 256)
        Me.Button61.Margin = New System.Windows.Forms.Padding(2)
        Me.Button61.Name = "Button61"
        Me.Button61.Size = New System.Drawing.Size(132, 27)
        Me.Button61.TabIndex = 207
        Me.Button61.Text = "XX Calc. Option Price"
        Me.Button61.UseVisualStyleBackColor = True
        '
        'Button50
        '
        Me.Button50.Location = New System.Drawing.Point(687, 225)
        Me.Button50.Margin = New System.Windows.Forms.Padding(2)
        Me.Button50.Name = "Button50"
        Me.Button50.Size = New System.Drawing.Size(132, 27)
        Me.Button50.TabIndex = 206
        Me.Button50.Text = "Req Market Rule"
        Me.Button50.UseVisualStyleBackColor = True
        '
        'Button51
        '
        Me.Button51.Location = New System.Drawing.Point(551, 225)
        Me.Button51.Margin = New System.Windows.Forms.Padding(2)
        Me.Button51.Name = "Button51"
        Me.Button51.Size = New System.Drawing.Size(132, 27)
        Me.Button51.TabIndex = 205
        Me.Button51.Text = "Req Historgram Data"
        Me.Button51.UseVisualStyleBackColor = True
        '
        'Button52
        '
        Me.Button52.Location = New System.Drawing.Point(415, 225)
        Me.Button52.Margin = New System.Windows.Forms.Padding(2)
        Me.Button52.Name = "Button52"
        Me.Button52.Size = New System.Drawing.Size(132, 27)
        Me.Button52.TabIndex = 204
        Me.Button52.Text = "XX Global Cancel"
        Me.Button52.UseVisualStyleBackColor = True
        '
        'Button53
        '
        Me.Button53.Location = New System.Drawing.Point(279, 225)
        Me.Button53.Margin = New System.Windows.Forms.Padding(2)
        Me.Button53.Name = "Button53"
        Me.Button53.Size = New System.Drawing.Size(132, 27)
        Me.Button53.TabIndex = 203
        Me.Button53.Text = "Financial Advisor"
        Me.Button53.UseVisualStyleBackColor = True
        '
        'Button54
        '
        Me.Button54.Location = New System.Drawing.Point(143, 225)
        Me.Button54.Margin = New System.Windows.Forms.Padding(2)
        Me.Button54.Name = "Button54"
        Me.Button54.Size = New System.Drawing.Size(132, 27)
        Me.Button54.TabIndex = 202
        Me.Button54.Text = "XX Cancel Calc. Implied Vol"
        Me.Button54.UseVisualStyleBackColor = True
        '
        'Button55
        '
        Me.Button55.Location = New System.Drawing.Point(7, 225)
        Me.Button55.Margin = New System.Windows.Forms.Padding(2)
        Me.Button55.Name = "Button55"
        Me.Button55.Size = New System.Drawing.Size(132, 27)
        Me.Button55.TabIndex = 201
        Me.Button55.Text = "XX Calc. Implied Vol."
        Me.Button55.UseVisualStyleBackColor = True
        '
        'Button44
        '
        Me.Button44.Location = New System.Drawing.Point(687, 194)
        Me.Button44.Margin = New System.Windows.Forms.Padding(2)
        Me.Button44.Name = "Button44"
        Me.Button44.Size = New System.Drawing.Size(132, 27)
        Me.Button44.TabIndex = 200
        Me.Button44.Text = "Req Head Time Stamp"
        Me.Button44.UseVisualStyleBackColor = True
        '
        'Button45
        '
        Me.Button45.Location = New System.Drawing.Point(551, 194)
        Me.Button45.Margin = New System.Windows.Forms.Padding(2)
        Me.Button45.Name = "Button45"
        Me.Button45.Size = New System.Drawing.Size(132, 27)
        Me.Button45.TabIndex = 199
        Me.Button45.Text = "Req Historical News"
        Me.Button45.UseVisualStyleBackColor = True
        '
        'Button46
        '
        Me.Button46.Location = New System.Drawing.Point(415, 194)
        Me.Button46.Margin = New System.Windows.Forms.Padding(2)
        Me.Button46.Name = "Button46"
        Me.Button46.Size = New System.Drawing.Size(132, 27)
        Me.Button46.TabIndex = 198
        Me.Button46.Text = "Req Accounts"
        Me.Button46.UseVisualStyleBackColor = True
        '
        'Button47
        '
        Me.Button47.Location = New System.Drawing.Point(279, 194)
        Me.Button47.Margin = New System.Windows.Forms.Padding(2)
        Me.Button47.Name = "Button47"
        Me.Button47.Size = New System.Drawing.Size(132, 27)
        Me.Button47.TabIndex = 197
        Me.Button47.Text = "Log Configuration"
        Me.Button47.UseVisualStyleBackColor = True
        '
        'Button48
        '
        Me.Button48.Location = New System.Drawing.Point(143, 194)
        Me.Button48.Margin = New System.Windows.Forms.Padding(2)
        Me.Button48.Name = "Button48"
        Me.Button48.Size = New System.Drawing.Size(132, 27)
        Me.Button48.TabIndex = 196
        Me.Button48.Text = "Market Scanner"
        Me.Button48.UseVisualStyleBackColor = True
        '
        'Button49
        '
        Me.Button49.Location = New System.Drawing.Point(7, 194)
        Me.Button49.Margin = New System.Windows.Forms.Padding(2)
        Me.Button49.Name = "Button49"
        Me.Button49.Size = New System.Drawing.Size(132, 27)
        Me.Button49.TabIndex = 195
        Me.Button49.Text = "XX Current Time"
        Me.Button49.UseVisualStyleBackColor = True
        '
        'Button38
        '
        Me.Button38.Location = New System.Drawing.Point(687, 163)
        Me.Button38.Margin = New System.Windows.Forms.Padding(2)
        Me.Button38.Name = "Button38"
        Me.Button38.Size = New System.Drawing.Size(132, 27)
        Me.Button38.TabIndex = 194
        Me.Button38.Text = "Req News Article"
        Me.Button38.UseVisualStyleBackColor = True
        '
        'Button39
        '
        Me.Button39.Location = New System.Drawing.Point(551, 163)
        Me.Button39.Margin = New System.Windows.Forms.Padding(2)
        Me.Button39.Name = "Button39"
        Me.Button39.Size = New System.Drawing.Size(132, 27)
        Me.Button39.TabIndex = 193
        Me.Button39.Text = "Req Smart Components"
        Me.Button39.UseVisualStyleBackColor = True
        '
        'Button40
        '
        Me.Button40.Location = New System.Drawing.Point(415, 163)
        Me.Button40.Margin = New System.Windows.Forms.Padding(2)
        Me.Button40.Name = "Button40"
        Me.Button40.Size = New System.Drawing.Size(132, 27)
        Me.Button40.TabIndex = 192
        Me.Button40.Text = "Req News Bulletins"
        Me.Button40.UseVisualStyleBackColor = True
        '
        'Button41
        '
        Me.Button41.Location = New System.Drawing.Point(279, 163)
        Me.Button41.Margin = New System.Windows.Forms.Padding(2)
        Me.Button41.Name = "Button41"
        Me.Button41.Size = New System.Drawing.Size(132, 27)
        Me.Button41.TabIndex = 191
        Me.Button41.Text = "XX Req Next Id"
        Me.Button41.UseVisualStyleBackColor = True
        '
        'Button42
        '
        Me.Button42.Location = New System.Drawing.Point(143, 163)
        Me.Button42.Margin = New System.Windows.Forms.Padding(2)
        Me.Button42.Name = "Button42"
        Me.Button42.Size = New System.Drawing.Size(132, 27)
        Me.Button42.TabIndex = 190
        Me.Button42.Text = "Cancel Real Time Bars"
        Me.Button42.UseVisualStyleBackColor = True
        '
        'Button43
        '
        Me.Button43.Location = New System.Drawing.Point(7, 163)
        Me.Button43.Margin = New System.Windows.Forms.Padding(2)
        Me.Button43.Name = "Button43"
        Me.Button43.Size = New System.Drawing.Size(132, 27)
        Me.Button43.TabIndex = 189
        Me.Button43.Text = "Real Time Bars"
        Me.Button43.UseVisualStyleBackColor = True
        '
        'Button32
        '
        Me.Button32.Location = New System.Drawing.Point(687, 132)
        Me.Button32.Margin = New System.Windows.Forms.Padding(2)
        Me.Button32.Name = "Button32"
        Me.Button32.Size = New System.Drawing.Size(132, 27)
        Me.Button32.TabIndex = 188
        Me.Button32.Text = "Req News Providers"
        Me.Button32.UseVisualStyleBackColor = True
        '
        'Button33
        '
        Me.Button33.Location = New System.Drawing.Point(551, 132)
        Me.Button33.Margin = New System.Windows.Forms.Padding(2)
        Me.Button33.Name = "Button33"
        Me.Button33.Size = New System.Drawing.Size(132, 27)
        Me.Button33.TabIndex = 187
        Me.Button33.Text = "Req Mkt Depth Exch"
        Me.Button33.UseVisualStyleBackColor = True
        '
        'Button34
        '
        Me.Button34.Location = New System.Drawing.Point(415, 132)
        Me.Button34.Margin = New System.Windows.Forms.Padding(2)
        Me.Button34.Name = "Button34"
        Me.Button34.Size = New System.Drawing.Size(132, 27)
        Me.Button34.TabIndex = 186
        Me.Button34.Text = "Req Executions"
        Me.Button34.UseVisualStyleBackColor = True
        '
        'Button35
        '
        Me.Button35.Location = New System.Drawing.Point(279, 132)
        Me.Button35.Margin = New System.Windows.Forms.Padding(2)
        Me.Button35.Name = "Button35"
        Me.Button35.Size = New System.Drawing.Size(132, 27)
        Me.Button35.TabIndex = 185
        Me.Button35.Text = "XX Req Acct Data"
        Me.Button35.UseVisualStyleBackColor = True
        '
        'Button36
        '
        Me.Button36.Location = New System.Drawing.Point(143, 132)
        Me.Button36.Margin = New System.Windows.Forms.Padding(2)
        Me.Button36.Name = "Button36"
        Me.Button36.Size = New System.Drawing.Size(132, 27)
        Me.Button36.TabIndex = 184
        Me.Button36.Text = "XX Cancel Fund. Data..."
        Me.Button36.UseVisualStyleBackColor = True
        '
        'Button37
        '
        Me.Button37.Location = New System.Drawing.Point(7, 132)
        Me.Button37.Margin = New System.Windows.Forms.Padding(2)
        Me.Button37.Name = "Button37"
        Me.Button37.Size = New System.Drawing.Size(132, 27)
        Me.Button37.TabIndex = 183
        Me.Button37.Text = "XX Fundamental Data"
        Me.Button37.UseVisualStyleBackColor = True
        '
        'Button26
        '
        Me.Button26.Location = New System.Drawing.Point(687, 101)
        Me.Button26.Margin = New System.Windows.Forms.Padding(2)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(132, 27)
        Me.Button26.TabIndex = 182
        Me.Button26.Text = "Cancel Acct Updt Multi"
        Me.Button26.UseVisualStyleBackColor = True
        '
        'Button27
        '
        Me.Button27.Location = New System.Drawing.Point(551, 101)
        Me.Button27.Margin = New System.Windows.Forms.Padding(2)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(132, 27)
        Me.Button27.TabIndex = 181
        Me.Button27.Text = "Req Acct Updt Multi"
        Me.Button27.UseVisualStyleBackColor = True
        '
        'Button28
        '
        Me.Button28.Location = New System.Drawing.Point(415, 101)
        Me.Button28.Margin = New System.Windows.Forms.Padding(2)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New System.Drawing.Size(132, 27)
        Me.Button28.TabIndex = 180
        Me.Button28.Text = "Req Auto Open Orders"
        Me.Button28.UseVisualStyleBackColor = True
        '
        'Button29
        '
        Me.Button29.Location = New System.Drawing.Point(279, 101)
        Me.Button29.Margin = New System.Windows.Forms.Padding(2)
        Me.Button29.Name = "Button29"
        Me.Button29.Size = New System.Drawing.Size(132, 27)
        Me.Button29.TabIndex = 179
        Me.Button29.Text = "Req All Open Orders"
        Me.Button29.UseVisualStyleBackColor = True
        '
        'Button30
        '
        Me.Button30.Location = New System.Drawing.Point(143, 101)
        Me.Button30.Margin = New System.Windows.Forms.Padding(2)
        Me.Button30.Name = "Button30"
        Me.Button30.Size = New System.Drawing.Size(132, 27)
        Me.Button30.TabIndex = 178
        Me.Button30.Text = "XX Cancel Historical Data"
        Me.Button30.UseVisualStyleBackColor = True
        '
        'Button31
        '
        Me.Button31.Location = New System.Drawing.Point(7, 101)
        Me.Button31.Margin = New System.Windows.Forms.Padding(2)
        Me.Button31.Name = "Button31"
        Me.Button31.Size = New System.Drawing.Size(132, 27)
        Me.Button31.TabIndex = 177
        Me.Button31.Text = "XX Historical Data"
        Me.Button31.UseVisualStyleBackColor = True
        '
        'Button20
        '
        Me.Button20.Location = New System.Drawing.Point(687, 70)
        Me.Button20.Margin = New System.Windows.Forms.Padding(2)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(132, 27)
        Me.Button20.TabIndex = 176
        Me.Button20.Text = "Cancel Positions Multi"
        Me.Button20.UseVisualStyleBackColor = True
        '
        'Button21
        '
        Me.Button21.Location = New System.Drawing.Point(551, 70)
        Me.Button21.Margin = New System.Windows.Forms.Padding(2)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(132, 27)
        Me.Button21.TabIndex = 175
        Me.Button21.Text = "Req Positions Multi"
        Me.Button21.UseVisualStyleBackColor = True
        '
        'Button22
        '
        Me.Button22.Location = New System.Drawing.Point(415, 70)
        Me.Button22.Margin = New System.Windows.Forms.Padding(2)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(132, 27)
        Me.Button22.TabIndex = 174
        Me.Button22.Text = "XX Req Open Orders"
        Me.Button22.UseVisualStyleBackColor = True
        '
        'Button23
        '
        Me.Button23.Location = New System.Drawing.Point(279, 70)
        Me.Button23.Margin = New System.Windows.Forms.Padding(2)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(132, 27)
        Me.Button23.TabIndex = 173
        Me.Button23.Text = "XX Req Contract Data"
        Me.Button23.UseVisualStyleBackColor = True
        '
        'Button24
        '
        Me.Button24.Location = New System.Drawing.Point(143, 70)
        Me.Button24.Margin = New System.Windows.Forms.Padding(2)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(132, 27)
        Me.Button24.TabIndex = 172
        Me.Button24.Text = "XX Cancel Mkt Depth"
        Me.Button24.UseVisualStyleBackColor = True
        '
        'Button25
        '
        Me.Button25.Location = New System.Drawing.Point(7, 70)
        Me.Button25.Margin = New System.Windows.Forms.Padding(2)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(132, 27)
        Me.Button25.TabIndex = 171
        Me.Button25.Text = "XX Req. Mkt. Depth"
        Me.Button25.UseVisualStyleBackColor = True
        '
        'BtnManualClear
        '
        Me.BtnManualClear.Location = New System.Drawing.Point(551, 350)
        Me.BtnManualClear.Name = "BtnManualClear"
        Me.BtnManualClear.Size = New System.Drawing.Size(132, 27)
        Me.BtnManualClear.TabIndex = 170
        Me.BtnManualClear.Text = "Clear"
        Me.BtnManualClear.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.Location = New System.Drawing.Point(687, 39)
        Me.Button17.Margin = New System.Windows.Forms.Padding(2)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(132, 27)
        Me.Button17.TabIndex = 169
        Me.Button17.Text = "Req Matching Symbols"
        Me.Button17.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.Location = New System.Drawing.Point(551, 39)
        Me.Button18.Margin = New System.Windows.Forms.Padding(2)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(132, 27)
        Me.Button18.TabIndex = 168
        Me.Button18.Text = "Groups"
        Me.Button18.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(415, 39)
        Me.Button15.Margin = New System.Windows.Forms.Padding(2)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(132, 27)
        Me.Button15.TabIndex = 167
        Me.Button15.Text = "Extended..."
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(279, 39)
        Me.Button16.Margin = New System.Windows.Forms.Padding(2)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(132, 27)
        Me.Button16.TabIndex = 166
        Me.Button16.Text = "Exercise Options"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(143, 39)
        Me.Button14.Margin = New System.Windows.Forms.Padding(2)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(132, 27)
        Me.Button14.TabIndex = 165
        Me.Button14.Text = "XX Cancel Mkt Data..."
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(7, 39)
        Me.Button13.Margin = New System.Windows.Forms.Padding(2)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(132, 27)
        Me.Button13.TabIndex = 164
        Me.Button13.Text = "XX Req. Mkt. Data..."
        Me.Button13.UseVisualStyleBackColor = True
        '
        'btnGetOpenOrders
        '
        Me.btnGetOpenOrders.Location = New System.Drawing.Point(870, 57)
        Me.btnGetOpenOrders.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetOpenOrders.Name = "btnGetOpenOrders"
        Me.btnGetOpenOrders.Size = New System.Drawing.Size(86, 27)
        Me.btnGetOpenOrders.TabIndex = 163
        Me.btnGetOpenOrders.Text = "Open Orders"
        Me.btnGetOpenOrders.UseVisualStyleBackColor = True
        '
        'btnGetPrice
        '
        Me.btnGetPrice.Location = New System.Drawing.Point(214, 7)
        Me.btnGetPrice.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetPrice.Name = "btnGetPrice"
        Me.btnGetPrice.Size = New System.Drawing.Size(86, 27)
        Me.btnGetPrice.TabIndex = 162
        Me.btnGetPrice.Text = "Get Price"
        Me.btnGetPrice.UseVisualStyleBackColor = True
        '
        'txtPriceSymbol
        '
        Me.txtPriceSymbol.Location = New System.Drawing.Point(152, 12)
        Me.txtPriceSymbol.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPriceSymbol.Name = "txtPriceSymbol"
        Me.txtPriceSymbol.Size = New System.Drawing.Size(52, 20)
        Me.txtPriceSymbol.TabIndex = 161
        '
        'btnCloseManual
        '
        Me.btnCloseManual.Location = New System.Drawing.Point(687, 350)
        Me.btnCloseManual.Name = "btnCloseManual"
        Me.btnCloseManual.Size = New System.Drawing.Size(132, 27)
        Me.btnCloseManual.TabIndex = 160
        Me.btnCloseManual.Text = "Close"
        Me.btnCloseManual.UseVisualStyleBackColor = True
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(16, 9)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(118, 20)
        Me.Label63.TabIndex = 159
        Me.Label63.Text = "Manual Actions"
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
        Me.Panel4.Location = New System.Drawing.Point(870, 808)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(412, 85)
        Me.Panel4.TabIndex = 155
        Me.Panel4.Visible = False
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(14, 4)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(129, 20)
        Me.Label54.TabIndex = 167
        Me.Label54.Text = "New Stock Order"
        '
        'btnSendOrder
        '
        Me.btnSendOrder.Location = New System.Drawing.Point(328, 55)
        Me.btnSendOrder.Name = "btnSendOrder"
        Me.btnSendOrder.Size = New System.Drawing.Size(81, 23)
        Me.btnSendOrder.TabIndex = 153
        Me.btnSendOrder.Text = "Send"
        Me.btnSendOrder.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(214, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 152
        Me.Label7.Text = "Quantity"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(271, 56)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(41, 20)
        Me.txtQty.TabIndex = 151
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(122, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 150
        Me.Label8.Text = "Price"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(169, 56)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(41, 20)
        Me.txtPrice.TabIndex = 149
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "Type"
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(71, 57)
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(41, 20)
        Me.txtType.TabIndex = 147
        Me.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(223, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "Action"
        '
        'txtAction
        '
        Me.txtAction.Location = New System.Drawing.Point(271, 28)
        Me.txtAction.Name = "txtAction"
        Me.txtAction.Size = New System.Drawing.Size(41, 20)
        Me.txtAction.TabIndex = 145
        Me.txtAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSymbol
        '
        Me.lblSymbol.AutoSize = True
        Me.lblSymbol.Location = New System.Drawing.Point(122, 33)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.Size = New System.Drawing.Size(41, 13)
        Me.lblSymbol.TabIndex = 144
        Me.lblSymbol.Text = "Symbol"
        '
        'txtSymbol
        '
        Me.txtSymbol.Location = New System.Drawing.Point(169, 28)
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.Size = New System.Drawing.Size(41, 20)
        Me.txtSymbol.TabIndex = 143
        Me.txtSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "Order ID"
        '
        'txtOrderId
        '
        Me.txtOrderId.Location = New System.Drawing.Point(70, 28)
        Me.txtOrderId.Name = "txtOrderId"
        Me.txtOrderId.Size = New System.Drawing.Size(41, 20)
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
        Me.Panel6.Location = New System.Drawing.Point(870, 910)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(412, 85)
        Me.Panel6.TabIndex = 156
        Me.Panel6.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(14, 5)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 20)
        Me.Label19.TabIndex = 166
        Me.Label19.Text = "Modify Order"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(219, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 165
        Me.Label10.Text = "Quantity"
        '
        'txtModifyQty
        '
        Me.txtModifyQty.Location = New System.Drawing.Point(271, 56)
        Me.txtModifyQty.Name = "txtModifyQty"
        Me.txtModifyQty.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyQty.TabIndex = 164
        Me.txtModifyQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(128, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 163
        Me.Label11.Text = "Price"
        '
        'txtModifyPrice
        '
        Me.txtModifyPrice.Location = New System.Drawing.Point(169, 56)
        Me.txtModifyPrice.Name = "txtModifyPrice"
        Me.txtModifyPrice.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyPrice.TabIndex = 162
        Me.txtModifyPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 161
        Me.Label12.Text = "Type"
        '
        'txtModifyType
        '
        Me.txtModifyType.Location = New System.Drawing.Point(71, 57)
        Me.txtModifyType.Name = "txtModifyType"
        Me.txtModifyType.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyType.TabIndex = 160
        Me.txtModifyType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnModOrder
        '
        Me.btnModOrder.Location = New System.Drawing.Point(329, 54)
        Me.btnModOrder.Name = "btnModOrder"
        Me.btnModOrder.Size = New System.Drawing.Size(81, 23)
        Me.btnModOrder.TabIndex = 159
        Me.btnModOrder.Text = "Send"
        Me.btnModOrder.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(219, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 158
        Me.Label13.Text = "Action"
        '
        'txtModifyAction
        '
        Me.txtModifyAction.Location = New System.Drawing.Point(271, 28)
        Me.txtModifyAction.Name = "txtModifyAction"
        Me.txtModifyAction.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyAction.TabIndex = 157
        Me.txtModifyAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(123, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 156
        Me.Label14.Text = "Symbol"
        '
        'txtModifySymbol
        '
        Me.txtModifySymbol.Location = New System.Drawing.Point(169, 28)
        Me.txtModifySymbol.Name = "txtModifySymbol"
        Me.txtModifySymbol.Size = New System.Drawing.Size(41, 20)
        Me.txtModifySymbol.TabIndex = 155
        Me.txtModifySymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 154
        Me.Label15.Text = "OrderID"
        '
        'txtModifyOrderId
        '
        Me.txtModifyOrderId.Location = New System.Drawing.Point(71, 28)
        Me.txtModifyOrderId.Name = "txtModifyOrderId"
        Me.txtModifyOrderId.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyOrderId.TabIndex = 153
        Me.txtModifyOrderId.Text = "4"
        Me.txtModifyOrderId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1300, 771)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(83, 25)
        Me.Button2.TabIndex = 157
        Me.Button2.Text = "Modify Order"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(164, 472)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 20)
        Me.Label9.TabIndex = 158
        Me.Label9.Text = "System Messages"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(1300, 802)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(83, 25)
        Me.Button5.TabIndex = 159
        Me.Button5.Text = "Get Info."
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(1389, 802)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(83, 25)
        Me.Button6.TabIndex = 162
        Me.Button6.Text = "Modify Order"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(1389, 771)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(83, 25)
        Me.Button7.TabIndex = 161
        Me.Button7.Text = "Modify Order"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(1389, 741)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(83, 25)
        Me.Button8.TabIndex = 160
        Me.Button8.Text = "Send Order"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(1478, 802)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(83, 25)
        Me.Button9.TabIndex = 165
        Me.Button9.Text = "Modify Order"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(1478, 771)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(83, 25)
        Me.Button10.TabIndex = 164
        Me.Button10.Text = "Modify Order"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(1478, 741)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(83, 25)
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
        Me.Panel7.Location = New System.Drawing.Point(870, 714)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(412, 85)
        Me.Panel7.TabIndex = 166
        Me.Panel7.Visible = False
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(14, 4)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(135, 20)
        Me.Label55.TabIndex = 167
        Me.Label55.Text = "New Option Order"
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(327, 55)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(81, 23)
        Me.Button12.TabIndex = 153
        Me.Button12.Text = "Send"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(214, 60)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(46, 13)
        Me.Label56.TabIndex = 152
        Me.Label56.Text = "Quantity"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(266, 57)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(41, 20)
        Me.TextBox7.TabIndex = 151
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(122, 60)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(31, 13)
        Me.Label57.TabIndex = 150
        Me.Label57.Text = "Price"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(169, 56)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(41, 20)
        Me.TextBox8.TabIndex = 149
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(15, 58)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(31, 13)
        Me.Label58.TabIndex = 148
        Me.Label58.Text = "Type"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(70, 54)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(41, 20)
        Me.TextBox9.TabIndex = 147
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(223, 33)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(37, 13)
        Me.Label59.TabIndex = 146
        Me.Label59.Text = "Action"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(266, 28)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(41, 20)
        Me.TextBox10.TabIndex = 145
        Me.TextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(122, 33)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(41, 13)
        Me.Label60.TabIndex = 144
        Me.Label60.Text = "Symbol"
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(169, 28)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(41, 20)
        Me.TextBox11.TabIndex = 143
        Me.TextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(14, 33)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(47, 13)
        Me.Label61.TabIndex = 142
        Me.Label61.Text = "Order ID"
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(70, 28)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(41, 20)
        Me.TextBox12.TabIndex = 141
        Me.TextBox12.Text = "0"
        Me.TextBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel8.Controls.Add(Me.btnCloseApp)
        Me.Panel8.Controls.Add(Me.btnBackTesting)
        Me.Panel8.Controls.Add(Me.Button4)
        Me.Panel8.Controls.Add(Me.Button3)
        Me.Panel8.Controls.Add(Me.Label62)
        Me.Panel8.Controls.Add(Me.btnAnalysis)
        Me.Panel8.Controls.Add(Me.btnShowManual)
        Me.Panel8.Controls.Add(Me.btnBackTest)
        Me.Panel8.Location = New System.Drawing.Point(0, 53)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(147, 648)
        Me.Panel8.TabIndex = 167
        '
        'btnCloseApp
        '
        Me.btnCloseApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseApp.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCloseApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCloseApp.Location = New System.Drawing.Point(3, 557)
        Me.btnCloseApp.Name = "btnCloseApp"
        Me.btnCloseApp.Size = New System.Drawing.Size(141, 42)
        Me.btnCloseApp.TabIndex = 137
        Me.btnCloseApp.Text = "Close"
        Me.btnCloseApp.UseVisualStyleBackColor = True
        '
        'btnBackTesting
        '
        Me.btnBackTesting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBackTesting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBackTesting.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnBackTesting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBackTesting.Location = New System.Drawing.Point(3, 340)
        Me.btnBackTesting.Name = "btnBackTesting"
        Me.btnBackTesting.Size = New System.Drawing.Size(141, 42)
        Me.btnBackTesting.TabIndex = 136
        Me.btnBackTesting.Text = "BACKTEST"
        Me.btnBackTesting.UseVisualStyleBackColor = True
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label62.Location = New System.Drawing.Point(8, 11)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(126, 24)
        Me.Label62.TabIndex = 91
        Me.Label62.Text = "NAVIGATION"
        '
        'btnShowManual
        '
        Me.btnShowManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowManual.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnShowManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShowManual.Location = New System.Drawing.Point(3, 45)
        Me.btnShowManual.Name = "btnShowManual"
        Me.btnShowManual.Size = New System.Drawing.Size(141, 42)
        Me.btnShowManual.TabIndex = 74
        Me.btnShowManual.Text = " MANUAL ACTIONS"
        Me.btnShowManual.UseVisualStyleBackColor = True
        '
        'pnlBacktest
        '
        Me.pnlBacktest.Controls.Add(Me.btnBacktestClear)
        Me.pnlBacktest.Controls.Add(Me.lblHarvestKey)
        Me.pnlBacktest.Controls.Add(Me.btnStartBackTest)
        Me.pnlBacktest.Controls.Add(Me.Label70)
        Me.pnlBacktest.Controls.Add(Me.cmbBackTestIndexes)
        Me.pnlBacktest.Controls.Add(Me.btnAssembleDataFileDIrectPull)
        Me.pnlBacktest.Controls.Add(Me.Label69)
        Me.pnlBacktest.Controls.Add(Me.dtpStartDate)
        Me.pnlBacktest.Controls.Add(Me.lblDatafileSymbol)
        Me.pnlBacktest.Controls.Add(Me.txtLoadSymbol)
        Me.pnlBacktest.Controls.Add(Me.btnAssembleDataFile)
        Me.pnlBacktest.Controls.Add(Me.btnHideBackTesting)
        Me.pnlBacktest.Controls.Add(Me.Label68)
        Me.pnlBacktest.Controls.Add(Me.Label65)
        Me.pnlBacktest.Location = New System.Drawing.Point(1402, 205)
        Me.pnlBacktest.Name = "pnlBacktest"
        Me.pnlBacktest.Size = New System.Drawing.Size(685, 346)
        Me.pnlBacktest.TabIndex = 168
        Me.pnlBacktest.Visible = False
        '
        'btnBacktestClear
        '
        Me.btnBacktestClear.Location = New System.Drawing.Point(504, 318)
        Me.btnBacktestClear.Name = "btnBacktestClear"
        Me.btnBacktestClear.Size = New System.Drawing.Size(89, 23)
        Me.btnBacktestClear.TabIndex = 175
        Me.btnBacktestClear.Text = "Clear"
        Me.btnBacktestClear.UseVisualStyleBackColor = True
        '
        'lblHarvestKey
        '
        Me.lblHarvestKey.AutoSize = True
        Me.lblHarvestKey.Location = New System.Drawing.Point(351, 96)
        Me.lblHarvestKey.Name = "lblHarvestKey"
        Me.lblHarvestKey.Size = New System.Drawing.Size(59, 13)
        Me.lblHarvestKey.TabIndex = 174
        Me.lblHarvestKey.Text = "harvestkey"
        '
        'btnStartBackTest
        '
        Me.btnStartBackTest.Location = New System.Drawing.Point(225, 91)
        Me.btnStartBackTest.Name = "btnStartBackTest"
        Me.btnStartBackTest.Size = New System.Drawing.Size(89, 23)
        Me.btnStartBackTest.TabIndex = 173
        Me.btnStartBackTest.Text = "Run Test"
        Me.btnStartBackTest.UseVisualStyleBackColor = True
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(12, 72)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(152, 16)
        Me.Label70.TabIndex = 172
        Me.Label70.Text = "Select Index to back test"
        '
        'cmbBackTestIndexes
        '
        Me.cmbBackTestIndexes.FormattingEnabled = True
        Me.cmbBackTestIndexes.Location = New System.Drawing.Point(12, 93)
        Me.cmbBackTestIndexes.Name = "cmbBackTestIndexes"
        Me.cmbBackTestIndexes.Size = New System.Drawing.Size(149, 21)
        Me.cmbBackTestIndexes.TabIndex = 171
        '
        'btnAssembleDataFileDIrectPull
        '
        Me.btnAssembleDataFileDIrectPull.Location = New System.Drawing.Point(602, 25)
        Me.btnAssembleDataFileDIrectPull.Name = "btnAssembleDataFileDIrectPull"
        Me.btnAssembleDataFileDIrectPull.Size = New System.Drawing.Size(72, 25)
        Me.btnAssembleDataFileDIrectPull.TabIndex = 170
        Me.btnAssembleDataFileDIrectPull.Text = "Build DP"
        Me.btnAssembleDataFileDIrectPull.UseVisualStyleBackColor = True
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(351, 32)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(58, 13)
        Me.Label69.TabIndex = 169
        Me.Label69.Text = "Start Date:"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(418, 30)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(88, 20)
        Me.dtpStartDate.TabIndex = 168
        '
        'lblDatafileSymbol
        '
        Me.lblDatafileSymbol.AutoSize = True
        Me.lblDatafileSymbol.Location = New System.Drawing.Point(222, 32)
        Me.lblDatafileSymbol.Name = "lblDatafileSymbol"
        Me.lblDatafileSymbol.Size = New System.Drawing.Size(44, 13)
        Me.lblDatafileSymbol.TabIndex = 165
        Me.lblDatafileSymbol.Text = "Symbol:"
        '
        'txtLoadSymbol
        '
        Me.txtLoadSymbol.Location = New System.Drawing.Point(271, 30)
        Me.txtLoadSymbol.Name = "txtLoadSymbol"
        Me.txtLoadSymbol.Size = New System.Drawing.Size(59, 20)
        Me.txtLoadSymbol.TabIndex = 164
        '
        'btnAssembleDataFile
        '
        Me.btnAssembleDataFile.Location = New System.Drawing.Point(524, 25)
        Me.btnAssembleDataFile.Name = "btnAssembleDataFile"
        Me.btnAssembleDataFile.Size = New System.Drawing.Size(72, 25)
        Me.btnAssembleDataFile.TabIndex = 163
        Me.btnAssembleDataFile.Text = "Build QQ"
        Me.btnAssembleDataFile.UseVisualStyleBackColor = True
        '
        'btnHideBackTesting
        '
        Me.btnHideBackTesting.Location = New System.Drawing.Point(599, 318)
        Me.btnHideBackTesting.Name = "btnHideBackTesting"
        Me.btnHideBackTesting.Size = New System.Drawing.Size(75, 23)
        Me.btnHideBackTesting.TabIndex = 162
        Me.btnHideBackTesting.Text = "Close"
        Me.btnHideBackTesting.UseVisualStyleBackColor = True
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(9, 35)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(140, 13)
        Me.Label68.TabIndex = 161
        Me.Label68.Text = "Assemble data file (If neeed)"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(2, 5)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(131, 20)
        Me.Label65.TabIndex = 160
        Me.Label65.Text = "Harvest Backtest"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2132, 1090)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlManual)
        Me.Controls.Add(Me.pnlBacktest)
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
        Me.Controls.Add(Me.btnGetOpenOrders)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
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
        Me.pnlManual.ResumeLayout(False)
        Me.pnlManual.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBacktest.ResumeLayout(False)
        Me.pnlBacktest.PerformLayout()
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
    Friend WithEvents lblMaxCap As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents lblCurrentCapital As Label
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
    Friend WithEvents pnlBacktest As Panel
    Friend WithEvents Label65 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents btnHideBackTesting As Button
    Friend WithEvents btnBackTesting As Button
    Friend WithEvents lblDatafileSymbol As Label
    Friend WithEvents txtLoadSymbol As TextBox
    Friend WithEvents btnAssembleDataFile As Button
    Friend WithEvents btnCloseApp As Button
    Friend WithEvents Label69 As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents btnAssembleDataFileDIrectPull As Button
    Friend WithEvents cmbBackTestIndexes As ComboBox
    Friend WithEvents Label70 As Label
    Friend WithEvents btnStartBackTest As Button
    Friend WithEvents lblHarvestKey As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents lblTransactions As Label
    Friend WithEvents btnBacktestClear As Button
    Friend WithEvents Button17 As Button
    Friend WithEvents Button18 As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents BtnManualClear As Button
    Friend WithEvents Button20 As Button
    Friend WithEvents Button21 As Button
    Friend WithEvents Button22 As Button
    Friend WithEvents Button23 As Button
    Friend WithEvents Button24 As Button
    Friend WithEvents Button25 As Button
    Friend WithEvents Button38 As Button
    Friend WithEvents Button39 As Button
    Friend WithEvents Button40 As Button
    Friend WithEvents Button41 As Button
    Friend WithEvents Button42 As Button
    Friend WithEvents Button43 As Button
    Friend WithEvents Button32 As Button
    Friend WithEvents Button33 As Button
    Friend WithEvents Button34 As Button
    Friend WithEvents Button35 As Button
    Friend WithEvents Button36 As Button
    Friend WithEvents Button37 As Button
    Friend WithEvents Button26 As Button
    Friend WithEvents Button27 As Button
    Friend WithEvents Button28 As Button
    Friend WithEvents Button29 As Button
    Friend WithEvents Button30 As Button
    Friend WithEvents Button31 As Button
    Friend WithEvents Button50 As Button
    Friend WithEvents Button51 As Button
    Friend WithEvents Button52 As Button
    Friend WithEvents Button53 As Button
    Friend WithEvents Button54 As Button
    Friend WithEvents Button55 As Button
    Friend WithEvents Button44 As Button
    Friend WithEvents Button45 As Button
    Friend WithEvents Button46 As Button
    Friend WithEvents Button47 As Button
    Friend WithEvents Button48 As Button
    Friend WithEvents Button49 As Button
    Friend WithEvents Button56 As Button
    Friend WithEvents Button57 As Button
    Friend WithEvents Button58 As Button
    Friend WithEvents Button59 As Button
    Friend WithEvents Button60 As Button
    Friend WithEvents Button61 As Button
    Friend WithEvents Button64 As Button
    Friend WithEvents Button65 As Button
    Friend WithEvents Button66 As Button
    Friend WithEvents Button67 As Button
    Friend WithEvents Button68 As Button
    Friend WithEvents Button69 As Button
    Friend WithEvents Button70 As Button
    Friend WithEvents Button71 As Button
    Friend WithEvents Button72 As Button
    Friend WithEvents Button73 As Button
    Friend WithEvents Button77 As Button
    Friend WithEvents Button78 As Button
    Friend WithEvents Button79 As Button
End Class
