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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Timer60Sec = New System.Windows.Forms.Timer(Me.components)
        Me.TimerAtTime = New System.Windows.Forms.Timer(Me.components)
        Me.ckRobotOn = New System.Windows.Forms.CheckBox()
        Me.btnBackTest = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCloseMe = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnProfile = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblBuild = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lstErrorResponses = New System.Windows.Forms.ListBox()
        Me.btnAnalysis = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
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
        Me.btnckprice = New System.Windows.Forms.Button()
        Me.txtGetPriceSymbol = New System.Windows.Forms.TextBox()
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
        Me.btnGetPrice2 = New System.Windows.Forms.Button()
        Me.btnTickPrice = New System.Windows.Forms.Button()
        Me.btnOpPrice = New System.Windows.Forms.Button()
        Me.Button78 = New System.Windows.Forms.Button()
        Me.Button46 = New System.Windows.Forms.Button()
        Me.Button71 = New System.Windows.Forms.Button()
        Me.btnPlaceOrder = New System.Windows.Forms.Button()
        Me.btnGetPositions = New System.Windows.Forms.Button()
        Me.btnReqNextId = New System.Windows.Forms.Button()
        Me.btnReqExecutions = New System.Windows.Forms.Button()
        Me.Button35 = New System.Windows.Forms.Button()
        Me.btnReqAllOpenOrders = New System.Windows.Forms.Button()
        Me.Button31 = New System.Windows.Forms.Button()
        Me.btnReqOpenOrders = New System.Windows.Forms.Button()
        Me.btnReqContractDetails = New System.Windows.Forms.Button()
        Me.btnCancelMarketData = New System.Windows.Forms.Button()
        Me.btnReqMktData = New System.Windows.Forms.Button()
        Me.btnGetPrice = New System.Windows.Forms.Button()
        Me.txtPriceSymbol = New System.Windows.Forms.TextBox()
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
        Me.Label9 = New System.Windows.Forms.Label()
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
        Me.btnHarvesting = New System.Windows.Forms.Button()
        Me.btnBackTesting = New System.Windows.Forms.Button()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.btnShowManual = New System.Windows.Forms.Button()
        Me.pnlBacktest = New System.Windows.Forms.Panel()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.txtStartYear = New System.Windows.Forms.TextBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.txtDays = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.txtMonths = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtYears = New System.Windows.Forms.TextBox()
        Me.Button19 = New System.Windows.Forms.Button()
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
        Me.pnlHarvesting = New System.Windows.Forms.Panel()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.BTOExists = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.lblSellOrderExists = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.lbloLast = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.lbloLowToday = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.lbloHighToday = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.lbloOpenToday = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.lblOprior = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.lbloAskPrice = New System.Windows.Forms.Label()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.lbloBidPrice = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.lblbtoMove = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lblNextBTO = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.lblCurrentMark = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.lblLastPrice = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.lblTodaysLow = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.lblTodaysHigh = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblTodaysOpen = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lblPClose = New System.Windows.Forms.Label()
        Me.lblPriorClose = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.lblAskPrice = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.lblBidPrice = New System.Windows.Forms.Label()
        Me.ckSnapshot = New System.Windows.Forms.CheckBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.cmbHarvestIndex = New System.Windows.Forms.ComboBox()
        Me.btnHarvestingStartWillie = New System.Windows.Forms.Button()
        Me.lblBuyOrderExists = New System.Windows.Forms.Label()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.txtHarvestingIP = New System.Windows.Forms.TextBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.txtHarvestingPort = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.txtHarvestingClientId = New System.Windows.Forms.TextBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnPlaceOptionOrder = New System.Windows.Forms.Button()
        Me.btnGetOptionPrice = New System.Windows.Forms.Button()
        Me.btnGetStockPrice = New System.Windows.Forms.Button()
        CType(Me.HarvestIndexBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionwavesdbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionwavesdbDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlMan.SuspendLayout()
        CType(Me.grdContracts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.pnlBacktest.SuspendLayout()
        Me.pnlHarvesting.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblConStatus
        '
        Me.lblConStatus.AutoSize = True
        Me.lblConStatus.Location = New System.Drawing.Point(153, 497)
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
        Me.lbldatastring.Location = New System.Drawing.Point(695, 497)
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
        Me.lstServerResponses.Location = New System.Drawing.Point(149, 515)
        Me.lstServerResponses.Margin = New System.Windows.Forms.Padding(2)
        Me.lstServerResponses.Name = "lstServerResponses"
        Me.lstServerResponses.Size = New System.Drawing.Size(804, 95)
        Me.lstServerResponses.TabIndex = 48
        '
        'btnWillie
        '
        Me.btnWillie.Location = New System.Drawing.Point(463, 298)
        Me.btnWillie.Name = "btnWillie"
        Me.btnWillie.Size = New System.Drawing.Size(70, 25)
        Me.btnWillie.TabIndex = 49
        Me.btnWillie.Text = "Start Willie"
        Me.btnWillie.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
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
        Me.ckRobotOn.Location = New System.Drawing.Point(748, 275)
        Me.ckRobotOn.Name = "ckRobotOn"
        Me.ckRobotOn.Size = New System.Drawing.Size(52, 17)
        Me.ckRobotOn.TabIndex = 69
        Me.ckRobotOn.Text = "Timer"
        Me.ckRobotOn.UseVisualStyleBackColor = True
        '
        'btnBackTest
        '
        Me.btnBackTest.Location = New System.Drawing.Point(1339, 239)
        Me.btnBackTest.Name = "btnBackTest"
        Me.btnBackTest.Size = New System.Drawing.Size(67, 23)
        Me.btnBackTest.TabIndex = 71
        Me.btnBackTest.Text = "BackTest"
        Me.btnBackTest.UseVisualStyleBackColor = True
        Me.btnBackTest.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Controls.Add(Me.btnClear)
        Me.Panel1.Controls.Add(Me.btnCloseMe)
        Me.Panel1.Controls.Add(Me.btnSettings)
        Me.Panel1.Controls.Add(Me.btnProfile)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(969, 52)
        Me.Panel1.TabIndex = 85
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.SlateGray
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClear.Location = New System.Drawing.Point(773, 13)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(71, 23)
        Me.btnClear.TabIndex = 294
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnCloseMe
        '
        Me.btnCloseMe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCloseMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseMe.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCloseMe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCloseMe.Location = New System.Drawing.Point(848, 13)
        Me.btnCloseMe.Name = "btnCloseMe"
        Me.btnCloseMe.Size = New System.Drawing.Size(71, 24)
        Me.btnCloseMe.TabIndex = 141
        Me.btnCloseMe.Text = "CLOSE"
        Me.btnCloseMe.UseVisualStyleBackColor = True
        '
        'btnSettings
        '
        Me.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSettings.Location = New System.Drawing.Point(623, 13)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(71, 23)
        Me.btnSettings.TabIndex = 74
        Me.btnSettings.Text = "SETTINGS"
        Me.btnSettings.UseVisualStyleBackColor = True
        Me.btnSettings.Visible = False
        '
        'btnProfile
        '
        Me.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProfile.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnProfile.Location = New System.Drawing.Point(698, 13)
        Me.btnProfile.Name = "btnProfile"
        Me.btnProfile.Size = New System.Drawing.Size(71, 23)
        Me.btnProfile.TabIndex = 73
        Me.btnProfile.Text = "PROFILE"
        Me.btnProfile.UseVisualStyleBackColor = True
        Me.btnProfile.Visible = False
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
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblBuild)
        Me.Panel5.Controls.Add(Me.lblStatus)
        Me.Panel5.Location = New System.Drawing.Point(150, 660)
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
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(10, 10)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(165, 13)
        Me.lblStatus.TabIndex = 68
        Me.lblStatus.Text = "Welcome to Resignation Trading!"
        '
        'lstErrorResponses
        '
        Me.lstErrorResponses.FormattingEnabled = True
        Me.lstErrorResponses.Location = New System.Drawing.Point(149, 614)
        Me.lstErrorResponses.Margin = New System.Windows.Forms.Padding(2)
        Me.lstErrorResponses.Name = "lstErrorResponses"
        Me.lstErrorResponses.Size = New System.Drawing.Size(804, 43)
        Me.lstErrorResponses.TabIndex = 124
        '
        'btnAnalysis
        '
        Me.btnAnalysis.Location = New System.Drawing.Point(1339, 266)
        Me.btnAnalysis.Name = "btnAnalysis"
        Me.btnAnalysis.Size = New System.Drawing.Size(67, 23)
        Me.btnAnalysis.TabIndex = 125
        Me.btnAnalysis.Text = "Analysis"
        Me.btnAnalysis.UseVisualStyleBackColor = True
        Me.btnAnalysis.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1289, 163)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(117, 33)
        Me.Button3.TabIndex = 134
        Me.Button3.Text = "Analysis"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1288, 200)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(117, 33)
        Me.Button4.TabIndex = 135
        Me.Button4.Text = "Back Testing"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
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
        Me.pnlMan.Controls.Add(Me.btnckprice)
        Me.pnlMan.Controls.Add(Me.txtGetPriceSymbol)
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
        Me.pnlMan.Location = New System.Drawing.Point(1546, 382)
        Me.pnlMan.Name = "pnlMan"
        Me.pnlMan.Size = New System.Drawing.Size(664, 228)
        Me.pnlMan.TabIndex = 154
        Me.pnlMan.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(19, 64)
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
        Me.grdContracts.Location = New System.Drawing.Point(10, 119)
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
        Me.btnSpreadOrder.Location = New System.Drawing.Point(473, 123)
        Me.btnSpreadOrder.Name = "btnSpreadOrder"
        Me.btnSpreadOrder.Size = New System.Drawing.Size(92, 23)
        Me.btnSpreadOrder.TabIndex = 202
        Me.btnSpreadOrder.Text = "Send Spread "
        Me.btnSpreadOrder.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(102, 96)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(79, 13)
        Me.Label31.TabIndex = 201
        Me.Label31.Text = "Expiration Date"
        '
        'txtSpreadExp
        '
        Me.txtSpreadExp.Location = New System.Drawing.Point(187, 93)
        Me.txtSpreadExp.Name = "txtSpreadExp"
        Me.txtSpreadExp.Size = New System.Drawing.Size(98, 20)
        Me.txtSpreadExp.TabIndex = 200
        Me.txtSpreadExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(389, 96)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(36, 13)
        Me.Label34.TabIndex = 199
        Me.Label34.Text = "P or C"
        '
        'txtSpreadRight
        '
        Me.txtSpreadRight.Location = New System.Drawing.Point(425, 93)
        Me.txtSpreadRight.Name = "txtSpreadRight"
        Me.txtSpreadRight.Size = New System.Drawing.Size(41, 20)
        Me.txtSpreadRight.TabIndex = 198
        Me.txtSpreadRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(293, 96)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(34, 13)
        Me.Label35.TabIndex = 197
        Me.Label35.Text = "Strike"
        '
        'txtSpreadStrike
        '
        Me.txtSpreadStrike.Location = New System.Drawing.Point(340, 93)
        Me.txtSpreadStrike.Name = "txtSpreadStrike"
        Me.txtSpreadStrike.Size = New System.Drawing.Size(41, 20)
        Me.txtSpreadStrike.TabIndex = 196
        Me.txtSpreadStrike.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(8, 96)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(41, 13)
        Me.Label36.TabIndex = 195
        Me.Label36.Text = "Symbol"
        '
        'txtSpreadSymbol
        '
        Me.txtSpreadSymbol.Location = New System.Drawing.Point(55, 93)
        Me.txtSpreadSymbol.Name = "txtSpreadSymbol"
        Me.txtSpreadSymbol.Size = New System.Drawing.Size(41, 20)
        Me.txtSpreadSymbol.TabIndex = 194
        Me.txtSpreadSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAddLeg
        '
        Me.btnAddLeg.Location = New System.Drawing.Point(473, 93)
        Me.btnAddLeg.Name = "btnAddLeg"
        Me.btnAddLeg.Size = New System.Drawing.Size(92, 23)
        Me.btnAddLeg.TabIndex = 193
        Me.btnAddLeg.Text = "Add Leg"
        Me.btnAddLeg.UseVisualStyleBackColor = True
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(204, 64)
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
        Me.Label37.Location = New System.Drawing.Point(312, 41)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(67, 13)
        Me.Label37.TabIndex = 190
        Me.Label37.Text = "Tick Type Id"
        '
        'txtTickId
        '
        Me.txtTickId.Location = New System.Drawing.Point(387, 38)
        Me.txtTickId.Name = "txtTickId"
        Me.txtTickId.Size = New System.Drawing.Size(41, 20)
        Me.txtTickId.TabIndex = 189
        Me.txtTickId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(469, 40)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(67, 13)
        Me.Label33.TabIndex = 188
        Me.Label33.Text = "App Controls"
        '
        'btnckprice
        '
        Me.btnckprice.Location = New System.Drawing.Point(473, 64)
        Me.btnckprice.Name = "btnckprice"
        Me.btnckprice.Size = New System.Drawing.Size(67, 23)
        Me.btnckprice.TabIndex = 187
        Me.btnckprice.Text = "Price"
        Me.btnckprice.UseVisualStyleBackColor = True
        '
        'txtGetPriceSymbol
        '
        Me.txtGetPriceSymbol.Location = New System.Drawing.Point(426, 66)
        Me.txtGetPriceSymbol.Name = "txtGetPriceSymbol"
        Me.txtGetPriceSymbol.Size = New System.Drawing.Size(42, 20)
        Me.txtGetPriceSymbol.TabIndex = 186
        Me.txtGetPriceSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(549, 17)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(25, 13)
        Me.Label30.TabIndex = 182
        Me.Label30.Text = "Exp"
        '
        'txtOptionExpirationDate
        '
        Me.txtOptionExpirationDate.Location = New System.Drawing.Point(574, 14)
        Me.txtOptionExpirationDate.Name = "txtOptionExpirationDate"
        Me.txtOptionExpirationDate.Size = New System.Drawing.Size(70, 20)
        Me.txtOptionExpirationDate.TabIndex = 181
        Me.txtOptionExpirationDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(114, 38)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(17, 13)
        Me.Label28.TabIndex = 180
        Me.Label28.Text = "IV"
        '
        'txtOptionIV
        '
        Me.txtOptionIV.Location = New System.Drawing.Point(137, 36)
        Me.txtOptionIV.Name = "txtOptionIV"
        Me.txtOptionIV.Size = New System.Drawing.Size(41, 20)
        Me.txtOptionIV.TabIndex = 179
        Me.txtOptionIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(500, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(26, 13)
        Me.Label27.TabIndex = 178
        Me.Label27.Text = "P/C"
        '
        'txtOptionRight
        '
        Me.txtOptionRight.Location = New System.Drawing.Point(527, 13)
        Me.txtOptionRight.Name = "txtOptionRight"
        Me.txtOptionRight.Size = New System.Drawing.Size(21, 20)
        Me.txtOptionRight.TabIndex = 177
        Me.txtOptionRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOptionStrike
        '
        Me.lblOptionStrike.AutoSize = True
        Me.lblOptionStrike.Location = New System.Drawing.Point(186, 45)
        Me.lblOptionStrike.Name = "lblOptionStrike"
        Me.lblOptionStrike.Size = New System.Drawing.Size(34, 13)
        Me.lblOptionStrike.TabIndex = 176
        Me.lblOptionStrike.Text = "Strike"
        '
        'txtOptionStrike
        '
        Me.txtOptionStrike.Location = New System.Drawing.Point(226, 41)
        Me.txtOptionStrike.Name = "txtOptionStrike"
        Me.txtOptionStrike.Size = New System.Drawing.Size(41, 20)
        Me.txtOptionStrike.TabIndex = 175
        Me.txtOptionStrike.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 35)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 174
        Me.Label16.Text = "Symbol"
        '
        'txtOptionSymbol
        '
        Me.txtOptionSymbol.Location = New System.Drawing.Point(48, 32)
        Me.txtOptionSymbol.Name = "txtOptionSymbol"
        Me.txtOptionSymbol.Size = New System.Drawing.Size(41, 20)
        Me.txtOptionSymbol.TabIndex = 173
        Me.txtOptionSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(425, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(23, 13)
        Me.Label17.TabIndex = 171
        Me.Label17.Text = "Qty"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(454, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(41, 20)
        Me.TextBox1.TabIndex = 170
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(346, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 169
        Me.Label20.Text = "Price"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(378, 12)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(41, 20)
        Me.TextBox2.TabIndex = 168
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(266, 15)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 13)
        Me.Label21.TabIndex = 167
        Me.Label21.Text = "Type"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(298, 12)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(41, 20)
        Me.TextBox3.TabIndex = 166
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(182, 16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(37, 13)
        Me.Label22.TabIndex = 165
        Me.Label22.Text = "Action"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(219, 12)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(41, 20)
        Me.TextBox4.TabIndex = 164
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(94, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(41, 13)
        Me.Label23.TabIndex = 163
        Me.Label23.Text = "Symbol"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(135, 13)
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
        Me.TextBox6.Location = New System.Drawing.Point(48, 12)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(41, 20)
        Me.TextBox6.TabIndex = 160
        Me.TextBox6.Text = "0"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSendOption
        '
        Me.btnSendOption.Location = New System.Drawing.Point(317, 64)
        Me.btnSendOption.Name = "btnSendOption"
        Me.btnSendOption.Size = New System.Drawing.Size(102, 23)
        Me.btnSendOption.TabIndex = 159
        Me.btnSendOption.Text = "Option Order"
        Me.btnSendOption.UseVisualStyleBackColor = True
        '
        'btnHideManual
        '
        Me.btnHideManual.Location = New System.Drawing.Point(411, 169)
        Me.btnHideManual.Name = "btnHideManual"
        Me.btnHideManual.Size = New System.Drawing.Size(141, 46)
        Me.btnHideManual.TabIndex = 132
        Me.btnHideManual.Text = "Close Manual"
        Me.btnHideManual.UseVisualStyleBackColor = True
        '
        'btnGetPrice2
        '
        Me.btnGetPrice2.Location = New System.Drawing.Point(195, 10)
        Me.btnGetPrice2.Name = "btnGetPrice2"
        Me.btnGetPrice2.Size = New System.Drawing.Size(67, 23)
        Me.btnGetPrice2.TabIndex = 185
        Me.btnGetPrice2.Text = "Get Price"
        Me.btnGetPrice2.UseVisualStyleBackColor = True
        '
        'btnTickPrice
        '
        Me.btnTickPrice.Location = New System.Drawing.Point(112, 301)
        Me.btnTickPrice.Name = "btnTickPrice"
        Me.btnTickPrice.Size = New System.Drawing.Size(100, 23)
        Me.btnTickPrice.TabIndex = 191
        Me.btnTickPrice.Text = "Get Tick"
        Me.btnTickPrice.UseVisualStyleBackColor = True
        '
        'btnOpPrice
        '
        Me.btnOpPrice.Location = New System.Drawing.Point(5, 301)
        Me.btnOpPrice.Name = "btnOpPrice"
        Me.btnOpPrice.Size = New System.Drawing.Size(101, 23)
        Me.btnOpPrice.TabIndex = 172
        Me.btnOpPrice.Text = "Opt Price"
        Me.btnOpPrice.UseVisualStyleBackColor = True
        '
        'Button78
        '
        Me.Button78.BackColor = System.Drawing.Color.LawnGreen
        Me.Button78.Location = New System.Drawing.Point(564, 453)
        Me.Button78.Margin = New System.Windows.Forms.Padding(2)
        Me.Button78.Name = "Button78"
        Me.Button78.Size = New System.Drawing.Size(132, 27)
        Me.Button78.TabIndex = 226
        Me.Button78.Text = "XX Req Tick-By-Tick"
        Me.Button78.UseVisualStyleBackColor = False
        '
        'Button46
        '
        Me.Button46.BackColor = System.Drawing.Color.LawnGreen
        Me.Button46.Location = New System.Drawing.Point(428, 453)
        Me.Button46.Margin = New System.Windows.Forms.Padding(2)
        Me.Button46.Name = "Button46"
        Me.Button46.Size = New System.Drawing.Size(132, 27)
        Me.Button46.TabIndex = 198
        Me.Button46.Text = "Req Accounts"
        Me.Button46.UseVisualStyleBackColor = False
        '
        'Button71
        '
        Me.Button71.BackColor = System.Drawing.Color.LawnGreen
        Me.Button71.Location = New System.Drawing.Point(700, 453)
        Me.Button71.Margin = New System.Windows.Forms.Padding(2)
        Me.Button71.Name = "Button71"
        Me.Button71.Size = New System.Drawing.Size(132, 27)
        Me.Button71.TabIndex = 221
        Me.Button71.Text = "Req Account Summary"
        Me.Button71.UseVisualStyleBackColor = False
        '
        'btnPlaceOrder
        '
        Me.btnPlaceOrder.BackColor = System.Drawing.Color.Ivory
        Me.btnPlaceOrder.Location = New System.Drawing.Point(700, 423)
        Me.btnPlaceOrder.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPlaceOrder.Name = "btnPlaceOrder"
        Me.btnPlaceOrder.Size = New System.Drawing.Size(132, 27)
        Me.btnPlaceOrder.TabIndex = 219
        Me.btnPlaceOrder.Text = "Place Stock Order"
        Me.btnPlaceOrder.UseVisualStyleBackColor = False
        '
        'btnGetPositions
        '
        Me.btnGetPositions.BackColor = System.Drawing.Color.LawnGreen
        Me.btnGetPositions.Location = New System.Drawing.Point(564, 423)
        Me.btnGetPositions.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetPositions.Name = "btnGetPositions"
        Me.btnGetPositions.Size = New System.Drawing.Size(132, 27)
        Me.btnGetPositions.TabIndex = 215
        Me.btnGetPositions.Text = "XX Req Positions"
        Me.btnGetPositions.UseVisualStyleBackColor = False
        '
        'btnReqNextId
        '
        Me.btnReqNextId.BackColor = System.Drawing.Color.Ivory
        Me.btnReqNextId.Location = New System.Drawing.Point(428, 423)
        Me.btnReqNextId.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReqNextId.Name = "btnReqNextId"
        Me.btnReqNextId.Size = New System.Drawing.Size(132, 27)
        Me.btnReqNextId.TabIndex = 191
        Me.btnReqNextId.Text = "Req Next Id"
        Me.btnReqNextId.UseVisualStyleBackColor = False
        '
        'btnReqExecutions
        '
        Me.btnReqExecutions.BackColor = System.Drawing.Color.LawnGreen
        Me.btnReqExecutions.Location = New System.Drawing.Point(156, 423)
        Me.btnReqExecutions.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReqExecutions.Name = "btnReqExecutions"
        Me.btnReqExecutions.Size = New System.Drawing.Size(132, 27)
        Me.btnReqExecutions.TabIndex = 186
        Me.btnReqExecutions.Text = "Req Executions"
        Me.btnReqExecutions.UseVisualStyleBackColor = False
        '
        'Button35
        '
        Me.Button35.BackColor = System.Drawing.Color.LawnGreen
        Me.Button35.Location = New System.Drawing.Point(835, 394)
        Me.Button35.Margin = New System.Windows.Forms.Padding(2)
        Me.Button35.Name = "Button35"
        Me.Button35.Size = New System.Drawing.Size(132, 27)
        Me.Button35.TabIndex = 185
        Me.Button35.Text = "XX Req Acct Data"
        Me.Button35.UseVisualStyleBackColor = False
        '
        'btnReqAllOpenOrders
        '
        Me.btnReqAllOpenOrders.BackColor = System.Drawing.Color.Ivory
        Me.btnReqAllOpenOrders.Location = New System.Drawing.Point(700, 394)
        Me.btnReqAllOpenOrders.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReqAllOpenOrders.Name = "btnReqAllOpenOrders"
        Me.btnReqAllOpenOrders.Size = New System.Drawing.Size(132, 27)
        Me.btnReqAllOpenOrders.TabIndex = 179
        Me.btnReqAllOpenOrders.Text = "Req All Open Orders"
        Me.btnReqAllOpenOrders.UseVisualStyleBackColor = False
        '
        'Button31
        '
        Me.Button31.BackColor = System.Drawing.Color.LawnGreen
        Me.Button31.Location = New System.Drawing.Point(292, 423)
        Me.Button31.Margin = New System.Windows.Forms.Padding(2)
        Me.Button31.Name = "Button31"
        Me.Button31.Size = New System.Drawing.Size(132, 27)
        Me.Button31.TabIndex = 177
        Me.Button31.Text = "XX Historical Data"
        Me.Button31.UseVisualStyleBackColor = False
        '
        'btnReqOpenOrders
        '
        Me.btnReqOpenOrders.BackColor = System.Drawing.Color.Ivory
        Me.btnReqOpenOrders.Location = New System.Drawing.Point(428, 394)
        Me.btnReqOpenOrders.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReqOpenOrders.Name = "btnReqOpenOrders"
        Me.btnReqOpenOrders.Size = New System.Drawing.Size(132, 27)
        Me.btnReqOpenOrders.TabIndex = 174
        Me.btnReqOpenOrders.Text = "Req Open Orders"
        Me.btnReqOpenOrders.UseVisualStyleBackColor = False
        '
        'btnReqContractDetails
        '
        Me.btnReqContractDetails.BackColor = System.Drawing.Color.Ivory
        Me.btnReqContractDetails.Location = New System.Drawing.Point(292, 394)
        Me.btnReqContractDetails.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReqContractDetails.Name = "btnReqContractDetails"
        Me.btnReqContractDetails.Size = New System.Drawing.Size(132, 27)
        Me.btnReqContractDetails.TabIndex = 173
        Me.btnReqContractDetails.Text = "Req Contract Data"
        Me.btnReqContractDetails.UseVisualStyleBackColor = False
        '
        'btnCancelMarketData
        '
        Me.btnCancelMarketData.BackColor = System.Drawing.Color.Ivory
        Me.btnCancelMarketData.Location = New System.Drawing.Point(564, 394)
        Me.btnCancelMarketData.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancelMarketData.Name = "btnCancelMarketData"
        Me.btnCancelMarketData.Size = New System.Drawing.Size(132, 27)
        Me.btnCancelMarketData.TabIndex = 165
        Me.btnCancelMarketData.Text = "Cancel Mkt Data..."
        Me.btnCancelMarketData.UseVisualStyleBackColor = False
        '
        'btnReqMktData
        '
        Me.btnReqMktData.BackColor = System.Drawing.Color.Ivory
        Me.btnReqMktData.Location = New System.Drawing.Point(156, 394)
        Me.btnReqMktData.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReqMktData.Name = "btnReqMktData"
        Me.btnReqMktData.Size = New System.Drawing.Size(132, 27)
        Me.btnReqMktData.TabIndex = 164
        Me.btnReqMktData.Text = "Req. Mkt. Data..."
        Me.btnReqMktData.UseVisualStyleBackColor = False
        '
        'btnGetPrice
        '
        Me.btnGetPrice.Location = New System.Drawing.Point(327, 45)
        Me.btnGetPrice.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetPrice.Name = "btnGetPrice"
        Me.btnGetPrice.Size = New System.Drawing.Size(68, 27)
        Me.btnGetPrice.TabIndex = 162
        Me.btnGetPrice.Text = "Get Price"
        Me.btnGetPrice.UseVisualStyleBackColor = True
        '
        'txtPriceSymbol
        '
        Me.txtPriceSymbol.Location = New System.Drawing.Point(271, 49)
        Me.txtPriceSymbol.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPriceSymbol.Name = "txtPriceSymbol"
        Me.txtPriceSymbol.Size = New System.Drawing.Size(52, 20)
        Me.txtPriceSymbol.TabIndex = 161
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
        Me.Panel4.Location = New System.Drawing.Point(972, 341)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(351, 85)
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
        Me.btnSendOrder.Location = New System.Drawing.Point(152, 4)
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
        Me.Panel6.Location = New System.Drawing.Point(970, 163)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(313, 85)
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
        Me.btnModOrder.Location = New System.Drawing.Point(140, 5)
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(152, 473)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 20)
        Me.Label9.TabIndex = 158
        Me.Label9.Text = "System Messages"
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
        Me.Panel7.Location = New System.Drawing.Point(970, 250)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(312, 85)
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
        Me.Button12.Location = New System.Drawing.Point(154, 1)
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
        Me.Panel8.BackColor = System.Drawing.Color.SlateGray
        Me.Panel8.Controls.Add(Me.btnHarvesting)
        Me.Panel8.Controls.Add(Me.btnBackTesting)
        Me.Panel8.Controls.Add(Me.Label62)
        Me.Panel8.Controls.Add(Me.btnShowManual)
        Me.Panel8.Location = New System.Drawing.Point(0, 53)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(147, 638)
        Me.Panel8.TabIndex = 167
        '
        'btnHarvesting
        '
        Me.btnHarvesting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHarvesting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHarvesting.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnHarvesting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHarvesting.Location = New System.Drawing.Point(3, 38)
        Me.btnHarvesting.Name = "btnHarvesting"
        Me.btnHarvesting.Size = New System.Drawing.Size(141, 42)
        Me.btnHarvesting.TabIndex = 138
        Me.btnHarvesting.Text = "HARVESTING"
        Me.btnHarvesting.UseVisualStyleBackColor = True
        Me.btnHarvesting.Visible = False
        '
        'btnBackTesting
        '
        Me.btnBackTesting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBackTesting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBackTesting.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnBackTesting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBackTesting.Location = New System.Drawing.Point(3, 287)
        Me.btnBackTesting.Name = "btnBackTesting"
        Me.btnBackTesting.Size = New System.Drawing.Size(141, 42)
        Me.btnBackTesting.TabIndex = 136
        Me.btnBackTesting.Text = "BACKTEST"
        Me.btnBackTesting.UseVisualStyleBackColor = True
        Me.btnBackTesting.Visible = False
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
        Me.Label62.Visible = False
        '
        'btnShowManual
        '
        Me.btnShowManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowManual.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnShowManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShowManual.Location = New System.Drawing.Point(3, 240)
        Me.btnShowManual.Name = "btnShowManual"
        Me.btnShowManual.Size = New System.Drawing.Size(141, 42)
        Me.btnShowManual.TabIndex = 74
        Me.btnShowManual.Text = " MANUAL ACTIONS"
        Me.btnShowManual.UseVisualStyleBackColor = True
        Me.btnShowManual.Visible = False
        '
        'pnlBacktest
        '
        Me.pnlBacktest.Controls.Add(Me.Label73)
        Me.pnlBacktest.Controls.Add(Me.txtStartYear)
        Me.pnlBacktest.Controls.Add(Me.Label72)
        Me.pnlBacktest.Controls.Add(Me.txtDays)
        Me.pnlBacktest.Controls.Add(Me.Label71)
        Me.pnlBacktest.Controls.Add(Me.txtMonths)
        Me.pnlBacktest.Controls.Add(Me.Label44)
        Me.pnlBacktest.Controls.Add(Me.txtYears)
        Me.pnlBacktest.Controls.Add(Me.Button19)
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
        Me.pnlBacktest.Location = New System.Drawing.Point(970, 0)
        Me.pnlBacktest.Name = "pnlBacktest"
        Me.pnlBacktest.Size = New System.Drawing.Size(402, 159)
        Me.pnlBacktest.TabIndex = 168
        Me.pnlBacktest.Visible = False
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(268, 34)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(57, 13)
        Me.Label73.TabIndex = 184
        Me.Label73.Text = "Start Year:"
        '
        'txtStartYear
        '
        Me.txtStartYear.Location = New System.Drawing.Point(329, 31)
        Me.txtStartYear.Name = "txtStartYear"
        Me.txtStartYear.Size = New System.Drawing.Size(59, 20)
        Me.txtStartYear.TabIndex = 1
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(282, 116)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(34, 13)
        Me.Label72.TabIndex = 182
        Me.Label72.Text = "Days:"
        '
        'txtDays
        '
        Me.txtDays.Location = New System.Drawing.Point(317, 112)
        Me.txtDays.Name = "txtDays"
        Me.txtDays.Size = New System.Drawing.Size(43, 20)
        Me.txtDays.TabIndex = 4
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(273, 89)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(45, 13)
        Me.Label71.TabIndex = 180
        Me.Label71.Text = "Months:"
        '
        'txtMonths
        '
        Me.txtMonths.Location = New System.Drawing.Point(318, 86)
        Me.txtMonths.Name = "txtMonths"
        Me.txtMonths.Size = New System.Drawing.Size(42, 20)
        Me.txtMonths.TabIndex = 3
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(275, 64)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(37, 13)
        Me.Label44.TabIndex = 178
        Me.Label44.Text = "Years:"
        '
        'txtYears
        '
        Me.txtYears.Location = New System.Drawing.Point(318, 60)
        Me.txtYears.Name = "txtYears"
        Me.txtYears.Size = New System.Drawing.Size(42, 20)
        Me.txtYears.TabIndex = 2
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(80, 97)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(75, 23)
        Me.Button19.TabIndex = 176
        Me.Button19.Text = "test"
        Me.Button19.UseVisualStyleBackColor = True
        '
        'btnBacktestClear
        '
        Me.btnBacktestClear.Location = New System.Drawing.Point(145, 5)
        Me.btnBacktestClear.Name = "btnBacktestClear"
        Me.btnBacktestClear.Size = New System.Drawing.Size(89, 23)
        Me.btnBacktestClear.TabIndex = 175
        Me.btnBacktestClear.Text = "Clear"
        Me.btnBacktestClear.UseVisualStyleBackColor = True
        '
        'lblHarvestKey
        '
        Me.lblHarvestKey.AutoSize = True
        Me.lblHarvestKey.Location = New System.Drawing.Point(15, 104)
        Me.lblHarvestKey.Name = "lblHarvestKey"
        Me.lblHarvestKey.Size = New System.Drawing.Size(59, 13)
        Me.lblHarvestKey.TabIndex = 174
        Me.lblHarvestKey.Text = "harvestkey"
        '
        'btnStartBackTest
        '
        Me.btnStartBackTest.Location = New System.Drawing.Point(167, 71)
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
        Me.Label70.Location = New System.Drawing.Point(12, 52)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(152, 16)
        Me.Label70.TabIndex = 172
        Me.Label70.Text = "Select Index to back test"
        '
        'cmbBackTestIndexes
        '
        Me.cmbBackTestIndexes.FormattingEnabled = True
        Me.cmbBackTestIndexes.Location = New System.Drawing.Point(12, 73)
        Me.cmbBackTestIndexes.Name = "cmbBackTestIndexes"
        Me.cmbBackTestIndexes.Size = New System.Drawing.Size(149, 21)
        Me.cmbBackTestIndexes.TabIndex = 171
        '
        'btnAssembleDataFileDIrectPull
        '
        Me.btnAssembleDataFileDIrectPull.Location = New System.Drawing.Point(193, 123)
        Me.btnAssembleDataFileDIrectPull.Name = "btnAssembleDataFileDIrectPull"
        Me.btnAssembleDataFileDIrectPull.Size = New System.Drawing.Size(72, 25)
        Me.btnAssembleDataFileDIrectPull.TabIndex = 170
        Me.btnAssembleDataFileDIrectPull.Text = "Build DP"
        Me.btnAssembleDataFileDIrectPull.UseVisualStyleBackColor = True
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(17, 125)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(58, 13)
        Me.Label69.TabIndex = 169
        Me.Label69.Text = "Start Date:"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(84, 123)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(88, 20)
        Me.dtpStartDate.TabIndex = 168
        '
        'lblDatafileSymbol
        '
        Me.lblDatafileSymbol.AutoSize = True
        Me.lblDatafileSymbol.Location = New System.Drawing.Point(157, 34)
        Me.lblDatafileSymbol.Name = "lblDatafileSymbol"
        Me.lblDatafileSymbol.Size = New System.Drawing.Size(44, 13)
        Me.lblDatafileSymbol.TabIndex = 165
        Me.lblDatafileSymbol.Text = "Symbol:"
        '
        'txtLoadSymbol
        '
        Me.txtLoadSymbol.Location = New System.Drawing.Point(206, 32)
        Me.txtLoadSymbol.Name = "txtLoadSymbol"
        Me.txtLoadSymbol.Size = New System.Drawing.Size(59, 20)
        Me.txtLoadSymbol.TabIndex = 0
        '
        'btnAssembleDataFile
        '
        Me.btnAssembleDataFile.Location = New System.Drawing.Point(278, 132)
        Me.btnAssembleDataFile.Name = "btnAssembleDataFile"
        Me.btnAssembleDataFile.Size = New System.Drawing.Size(72, 25)
        Me.btnAssembleDataFile.TabIndex = 5
        Me.btnAssembleDataFile.Text = "Build QQ"
        Me.btnAssembleDataFile.UseVisualStyleBackColor = True
        '
        'btnHideBackTesting
        '
        Me.btnHideBackTesting.Location = New System.Drawing.Point(237, 5)
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
        Me.Label68.Size = New System.Drawing.Size(146, 13)
        Me.Label68.TabIndex = 161
        Me.Label68.Text = "Assemble data file (If needed)"
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
        'pnlHarvesting
        '
        Me.pnlHarvesting.BackColor = System.Drawing.SystemColors.Control
        Me.pnlHarvesting.Controls.Add(Me.Label83)
        Me.pnlHarvesting.Controls.Add(Me.BTOExists)
        Me.pnlHarvesting.Controls.Add(Me.Label81)
        Me.pnlHarvesting.Controls.Add(Me.lblSellOrderExists)
        Me.pnlHarvesting.Controls.Add(Me.Label51)
        Me.pnlHarvesting.Controls.Add(Me.lbloLast)
        Me.pnlHarvesting.Controls.Add(Me.Label82)
        Me.pnlHarvesting.Controls.Add(Me.lbloLowToday)
        Me.pnlHarvesting.Controls.Add(Me.Label84)
        Me.pnlHarvesting.Controls.Add(Me.lbloHighToday)
        Me.pnlHarvesting.Controls.Add(Me.Label86)
        Me.pnlHarvesting.Controls.Add(Me.lbloOpenToday)
        Me.pnlHarvesting.Controls.Add(Me.Label88)
        Me.pnlHarvesting.Controls.Add(Me.lblOprior)
        Me.pnlHarvesting.Controls.Add(Me.Label90)
        Me.pnlHarvesting.Controls.Add(Me.lbloAskPrice)
        Me.pnlHarvesting.Controls.Add(Me.Label92)
        Me.pnlHarvesting.Controls.Add(Me.lbloBidPrice)
        Me.pnlHarvesting.Controls.Add(Me.Label79)
        Me.pnlHarvesting.Controls.Add(Me.ckRobotOn)
        Me.pnlHarvesting.Controls.Add(Me.Label80)
        Me.pnlHarvesting.Controls.Add(Me.Label66)
        Me.pnlHarvesting.Controls.Add(Me.Label67)
        Me.pnlHarvesting.Controls.Add(Me.Label63)
        Me.pnlHarvesting.Controls.Add(Me.Label64)
        Me.pnlHarvesting.Controls.Add(Me.Label52)
        Me.pnlHarvesting.Controls.Add(Me.Label53)
        Me.pnlHarvesting.Controls.Add(Me.Label50)
        Me.pnlHarvesting.Controls.Add(Me.lblbtoMove)
        Me.pnlHarvesting.Controls.Add(Me.Label32)
        Me.pnlHarvesting.Controls.Add(Me.Label49)
        Me.pnlHarvesting.Controls.Add(Me.lblNextBTO)
        Me.pnlHarvesting.Controls.Add(Me.Label48)
        Me.pnlHarvesting.Controls.Add(Me.Label46)
        Me.pnlHarvesting.Controls.Add(Me.lblCurrentMark)
        Me.pnlHarvesting.Controls.Add(Me.Label43)
        Me.pnlHarvesting.Controls.Add(Me.Label47)
        Me.pnlHarvesting.Controls.Add(Me.lblLastPrice)
        Me.pnlHarvesting.Controls.Add(Me.Label45)
        Me.pnlHarvesting.Controls.Add(Me.lblTodaysLow)
        Me.pnlHarvesting.Controls.Add(Me.Label42)
        Me.pnlHarvesting.Controls.Add(Me.lblTodaysHigh)
        Me.pnlHarvesting.Controls.Add(Me.Label41)
        Me.pnlHarvesting.Controls.Add(Me.btnWillie)
        Me.pnlHarvesting.Controls.Add(Me.lblTodaysOpen)
        Me.pnlHarvesting.Controls.Add(Me.Label40)
        Me.pnlHarvesting.Controls.Add(Me.lblPClose)
        Me.pnlHarvesting.Controls.Add(Me.lblPriorClose)
        Me.pnlHarvesting.Controls.Add(Me.Label38)
        Me.pnlHarvesting.Controls.Add(Me.btnGetPrice2)
        Me.pnlHarvesting.Controls.Add(Me.lblAskPrice)
        Me.pnlHarvesting.Controls.Add(Me.Label39)
        Me.pnlHarvesting.Controls.Add(Me.lblBidPrice)
        Me.pnlHarvesting.Controls.Add(Me.btnTickPrice)
        Me.pnlHarvesting.Controls.Add(Me.ckSnapshot)
        Me.pnlHarvesting.Controls.Add(Me.Label78)
        Me.pnlHarvesting.Controls.Add(Me.cmbHarvestIndex)
        Me.pnlHarvesting.Controls.Add(Me.btnHarvestingStartWillie)
        Me.pnlHarvesting.Controls.Add(Me.btnGetPrice)
        Me.pnlHarvesting.Controls.Add(Me.txtPriceSymbol)
        Me.pnlHarvesting.Controls.Add(Me.btnOpPrice)
        Me.pnlHarvesting.Controls.Add(Me.lblBuyOrderExists)
        Me.pnlHarvesting.Location = New System.Drawing.Point(1533, 31)
        Me.pnlHarvesting.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlHarvesting.Name = "pnlHarvesting"
        Me.pnlHarvesting.Size = New System.Drawing.Size(814, 336)
        Me.pnlHarvesting.TabIndex = 170
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label83.Location = New System.Drawing.Point(400, 52)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(94, 13)
        Me.Label83.TabIndex = 291
        Me.Label83.Text = "BTO Order Exists?"
        '
        'BTOExists
        '
        Me.BTOExists.AutoSize = True
        Me.BTOExists.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTOExists.Location = New System.Drawing.Point(544, 52)
        Me.BTOExists.Name = "BTOExists"
        Me.BTOExists.Size = New System.Drawing.Size(0, 13)
        Me.BTOExists.TabIndex = 290
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label81.Location = New System.Drawing.Point(139, 281)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(59, 13)
        Me.Label81.TabIndex = 289
        Me.Label81.Text = "Sell Order?"
        '
        'lblSellOrderExists
        '
        Me.lblSellOrderExists.AutoSize = True
        Me.lblSellOrderExists.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblSellOrderExists.Location = New System.Drawing.Point(214, 281)
        Me.lblSellOrderExists.Name = "lblSellOrderExists"
        Me.lblSellOrderExists.Size = New System.Drawing.Size(32, 13)
        Me.lblSellOrderExists.TabIndex = 288
        Me.lblSellOrderExists.Text = "False"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label51.Location = New System.Drawing.Point(275, 210)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(57, 13)
        Me.Label51.TabIndex = 287
        Me.Label51.Text = "Last Price:"
        '
        'lbloLast
        '
        Me.lbloLast.AutoSize = True
        Me.lbloLast.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbloLast.Location = New System.Drawing.Point(350, 210)
        Me.lbloLast.Name = "lbloLast"
        Me.lbloLast.Size = New System.Drawing.Size(34, 13)
        Me.lbloLast.TabIndex = 286
        Me.lbloLast.Text = "$0.00"
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label82.Location = New System.Drawing.Point(275, 186)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(70, 13)
        Me.Label82.TabIndex = 285
        Me.Label82.Text = "Today's Low:"
        '
        'lbloLowToday
        '
        Me.lbloLowToday.AutoSize = True
        Me.lbloLowToday.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbloLowToday.Location = New System.Drawing.Point(350, 185)
        Me.lbloLowToday.Name = "lbloLowToday"
        Me.lbloLowToday.Size = New System.Drawing.Size(34, 13)
        Me.lbloLowToday.TabIndex = 284
        Me.lbloLowToday.Text = "$0.00"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label84.Location = New System.Drawing.Point(275, 162)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(72, 13)
        Me.Label84.TabIndex = 283
        Me.Label84.Text = "Today's High:"
        '
        'lbloHighToday
        '
        Me.lbloHighToday.AutoSize = True
        Me.lbloHighToday.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbloHighToday.Location = New System.Drawing.Point(350, 162)
        Me.lbloHighToday.Name = "lbloHighToday"
        Me.lbloHighToday.Size = New System.Drawing.Size(34, 13)
        Me.lbloHighToday.TabIndex = 282
        Me.lbloHighToday.Text = "$0.00"
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label86.Location = New System.Drawing.Point(275, 139)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(76, 13)
        Me.Label86.TabIndex = 281
        Me.Label86.Text = "Today's Open:"
        '
        'lbloOpenToday
        '
        Me.lbloOpenToday.AutoSize = True
        Me.lbloOpenToday.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbloOpenToday.Location = New System.Drawing.Point(350, 139)
        Me.lbloOpenToday.Name = "lbloOpenToday"
        Me.lbloOpenToday.Size = New System.Drawing.Size(34, 13)
        Me.lbloOpenToday.TabIndex = 280
        Me.lbloOpenToday.Text = "$0.00"
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label88.Location = New System.Drawing.Point(275, 116)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(60, 13)
        Me.Label88.TabIndex = 279
        Me.Label88.Text = "Prior Close:"
        '
        'lblOprior
        '
        Me.lblOprior.AutoSize = True
        Me.lblOprior.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblOprior.Location = New System.Drawing.Point(350, 116)
        Me.lblOprior.Name = "lblOprior"
        Me.lblOprior.Size = New System.Drawing.Size(34, 13)
        Me.lblOprior.TabIndex = 278
        Me.lblOprior.Text = "$0.00"
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label90.Location = New System.Drawing.Point(275, 256)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(55, 13)
        Me.Label90.TabIndex = 277
        Me.Label90.Text = "Ask Price:"
        '
        'lbloAskPrice
        '
        Me.lbloAskPrice.AutoSize = True
        Me.lbloAskPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbloAskPrice.Location = New System.Drawing.Point(350, 256)
        Me.lbloAskPrice.Name = "lbloAskPrice"
        Me.lbloAskPrice.Size = New System.Drawing.Size(34, 13)
        Me.lbloAskPrice.TabIndex = 276
        Me.lbloAskPrice.Text = "$0.00"
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label92.Location = New System.Drawing.Point(275, 234)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(52, 13)
        Me.Label92.TabIndex = 275
        Me.Label92.Text = "Bid Price:"
        '
        'lbloBidPrice
        '
        Me.lbloBidPrice.AutoSize = True
        Me.lbloBidPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbloBidPrice.Location = New System.Drawing.Point(350, 234)
        Me.lbloBidPrice.Name = "lbloBidPrice"
        Me.lbloBidPrice.Size = New System.Drawing.Size(34, 13)
        Me.lbloBidPrice.TabIndex = 274
        Me.lbloBidPrice.Text = "$0.00"
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label79.Location = New System.Drawing.Point(139, 139)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(57, 13)
        Me.Label79.TabIndex = 273
        Me.Label79.Text = "Next BTO:"
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label80.Location = New System.Drawing.Point(214, 162)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(32, 13)
        Me.Label80.TabIndex = 272
        Me.Label80.Text = "False"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label66.Location = New System.Drawing.Point(139, 256)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(57, 13)
        Me.Label66.TabIndex = 271
        Me.Label66.Text = "Next BTO:"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label67.Location = New System.Drawing.Point(214, 256)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(32, 13)
        Me.Label67.TabIndex = 270
        Me.Label67.Text = "False"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label63.Location = New System.Drawing.Point(139, 234)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(57, 13)
        Me.Label63.TabIndex = 269
        Me.Label63.Text = "Next BTO:"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label64.Location = New System.Drawing.Point(214, 234)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(32, 13)
        Me.Label64.TabIndex = 268
        Me.Label64.Text = "False"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label52.Location = New System.Drawing.Point(139, 210)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(57, 13)
        Me.Label52.TabIndex = 267
        Me.Label52.Text = "Next BTO:"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label53.Location = New System.Drawing.Point(214, 210)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(32, 13)
        Me.Label53.TabIndex = 266
        Me.Label53.Text = "False"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label50.Location = New System.Drawing.Point(139, 185)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(62, 13)
        Me.Label50.TabIndex = 265
        Me.Label50.Text = "BTO Move:"
        '
        'lblbtoMove
        '
        Me.lblbtoMove.AutoSize = True
        Me.lblbtoMove.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblbtoMove.Location = New System.Drawing.Point(214, 185)
        Me.lblbtoMove.Name = "lblbtoMove"
        Me.lblbtoMove.Size = New System.Drawing.Size(32, 13)
        Me.lblbtoMove.TabIndex = 264
        Me.lblbtoMove.Text = "False"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label32.Location = New System.Drawing.Point(274, 84)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(125, 20)
        Me.Label32.TabIndex = 263
        Me.Label32.Text = "Option Statistics"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label49.Location = New System.Drawing.Point(139, 162)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(58, 13)
        Me.Label49.TabIndex = 262
        Me.Label49.Text = "STC Price:"
        '
        'lblNextBTO
        '
        Me.lblNextBTO.AutoSize = True
        Me.lblNextBTO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblNextBTO.Location = New System.Drawing.Point(214, 139)
        Me.lblNextBTO.Name = "lblNextBTO"
        Me.lblNextBTO.Size = New System.Drawing.Size(32, 13)
        Me.lblNextBTO.TabIndex = 261
        Me.lblNextBTO.Text = "False"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label48.Location = New System.Drawing.Point(7, 281)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(60, 13)
        Me.Label48.TabIndex = 260
        Me.Label48.Text = "Buy Order?"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label46.Location = New System.Drawing.Point(139, 116)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(69, 13)
        Me.Label46.TabIndex = 259
        Me.Label46.Text = "Current BTO:"
        '
        'lblCurrentMark
        '
        Me.lblCurrentMark.AutoSize = True
        Me.lblCurrentMark.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCurrentMark.Location = New System.Drawing.Point(214, 116)
        Me.lblCurrentMark.Name = "lblCurrentMark"
        Me.lblCurrentMark.Size = New System.Drawing.Size(34, 13)
        Me.lblCurrentMark.TabIndex = 258
        Me.lblCurrentMark.Text = "$0.00"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label43.Location = New System.Drawing.Point(138, 84)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(122, 20)
        Me.Label43.TabIndex = 257
        Me.Label43.Text = "Robot Statistics"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label47.Location = New System.Drawing.Point(10, 210)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(57, 13)
        Me.Label47.TabIndex = 256
        Me.Label47.Text = "Last Price:"
        '
        'lblLastPrice
        '
        Me.lblLastPrice.AutoSize = True
        Me.lblLastPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblLastPrice.Location = New System.Drawing.Point(85, 210)
        Me.lblLastPrice.Name = "lblLastPrice"
        Me.lblLastPrice.Size = New System.Drawing.Size(34, 13)
        Me.lblLastPrice.TabIndex = 255
        Me.lblLastPrice.Text = "$0.00"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label45.Location = New System.Drawing.Point(10, 186)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(70, 13)
        Me.Label45.TabIndex = 254
        Me.Label45.Text = "Today's Low:"
        '
        'lblTodaysLow
        '
        Me.lblTodaysLow.AutoSize = True
        Me.lblTodaysLow.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTodaysLow.Location = New System.Drawing.Point(85, 185)
        Me.lblTodaysLow.Name = "lblTodaysLow"
        Me.lblTodaysLow.Size = New System.Drawing.Size(34, 13)
        Me.lblTodaysLow.TabIndex = 253
        Me.lblTodaysLow.Text = "$0.00"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label42.Location = New System.Drawing.Point(10, 162)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(72, 13)
        Me.Label42.TabIndex = 252
        Me.Label42.Text = "Today's High:"
        '
        'lblTodaysHigh
        '
        Me.lblTodaysHigh.AutoSize = True
        Me.lblTodaysHigh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTodaysHigh.Location = New System.Drawing.Point(85, 162)
        Me.lblTodaysHigh.Name = "lblTodaysHigh"
        Me.lblTodaysHigh.Size = New System.Drawing.Size(34, 13)
        Me.lblTodaysHigh.TabIndex = 251
        Me.lblTodaysHigh.Text = "$0.00"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label41.Location = New System.Drawing.Point(10, 139)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(76, 13)
        Me.Label41.TabIndex = 250
        Me.Label41.Text = "Today's Open:"
        '
        'lblTodaysOpen
        '
        Me.lblTodaysOpen.AutoSize = True
        Me.lblTodaysOpen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTodaysOpen.Location = New System.Drawing.Point(85, 139)
        Me.lblTodaysOpen.Name = "lblTodaysOpen"
        Me.lblTodaysOpen.Size = New System.Drawing.Size(34, 13)
        Me.lblTodaysOpen.TabIndex = 249
        Me.lblTodaysOpen.Text = "$0.00"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label40.Location = New System.Drawing.Point(9, 84)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(119, 20)
        Me.Label40.TabIndex = 248
        Me.Label40.Text = "Stock Statistics"
        '
        'lblPClose
        '
        Me.lblPClose.AutoSize = True
        Me.lblPClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPClose.Location = New System.Drawing.Point(10, 116)
        Me.lblPClose.Name = "lblPClose"
        Me.lblPClose.Size = New System.Drawing.Size(60, 13)
        Me.lblPClose.TabIndex = 247
        Me.lblPClose.Text = "Prior Close:"
        '
        'lblPriorClose
        '
        Me.lblPriorClose.AutoSize = True
        Me.lblPriorClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPriorClose.Location = New System.Drawing.Point(85, 116)
        Me.lblPriorClose.Name = "lblPriorClose"
        Me.lblPriorClose.Size = New System.Drawing.Size(34, 13)
        Me.lblPriorClose.TabIndex = 246
        Me.lblPriorClose.Text = "$0.00"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label38.Location = New System.Drawing.Point(10, 256)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(55, 13)
        Me.Label38.TabIndex = 245
        Me.Label38.Text = "Ask Price:"
        '
        'lblAskPrice
        '
        Me.lblAskPrice.AutoSize = True
        Me.lblAskPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblAskPrice.Location = New System.Drawing.Point(85, 256)
        Me.lblAskPrice.Name = "lblAskPrice"
        Me.lblAskPrice.Size = New System.Drawing.Size(34, 13)
        Me.lblAskPrice.TabIndex = 244
        Me.lblAskPrice.Text = "$0.00"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label39.Location = New System.Drawing.Point(10, 234)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(52, 13)
        Me.Label39.TabIndex = 243
        Me.Label39.Text = "Bid Price:"
        '
        'lblBidPrice
        '
        Me.lblBidPrice.AutoSize = True
        Me.lblBidPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblBidPrice.Location = New System.Drawing.Point(85, 234)
        Me.lblBidPrice.Name = "lblBidPrice"
        Me.lblBidPrice.Size = New System.Drawing.Size(34, 13)
        Me.lblBidPrice.TabIndex = 242
        Me.lblBidPrice.Text = "$0.00"
        '
        'ckSnapshot
        '
        Me.ckSnapshot.AutoSize = True
        Me.ckSnapshot.Location = New System.Drawing.Point(218, 307)
        Me.ckSnapshot.Name = "ckSnapshot"
        Me.ckSnapshot.Size = New System.Drawing.Size(97, 17)
        Me.ckSnapshot.TabIndex = 241
        Me.ckSnapshot.Text = "Snapshot Data"
        Me.ckSnapshot.UseVisualStyleBackColor = True
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(10, 52)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(109, 13)
        Me.Label78.TabIndex = 240
        Me.Label78.Text = "Select Harvest Index:"
        '
        'cmbHarvestIndex
        '
        Me.cmbHarvestIndex.FormattingEnabled = True
        Me.cmbHarvestIndex.Location = New System.Drawing.Point(125, 49)
        Me.cmbHarvestIndex.Name = "cmbHarvestIndex"
        Me.cmbHarvestIndex.Size = New System.Drawing.Size(138, 21)
        Me.cmbHarvestIndex.TabIndex = 239
        '
        'btnHarvestingStartWillie
        '
        Me.btnHarvestingStartWillie.Location = New System.Drawing.Point(321, 298)
        Me.btnHarvestingStartWillie.Name = "btnHarvestingStartWillie"
        Me.btnHarvestingStartWillie.Size = New System.Drawing.Size(132, 27)
        Me.btnHarvestingStartWillie.TabIndex = 238
        Me.btnHarvestingStartWillie.Text = "Start Willie"
        Me.btnHarvestingStartWillie.UseVisualStyleBackColor = True
        '
        'lblBuyOrderExists
        '
        Me.lblBuyOrderExists.AutoSize = True
        Me.lblBuyOrderExists.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblBuyOrderExists.Location = New System.Drawing.Point(82, 281)
        Me.lblBuyOrderExists.Name = "lblBuyOrderExists"
        Me.lblBuyOrderExists.Size = New System.Drawing.Size(32, 13)
        Me.lblBuyOrderExists.TabIndex = 229
        Me.lblBuyOrderExists.Text = "False"
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(551, 64)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(108, 27)
        Me.btnDisconnect.TabIndex = 293
        Me.btnDisconnect.Text = "Disconnect TWS"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(437, 64)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(108, 27)
        Me.btnConnect.TabIndex = 292
        Me.btnConnect.Text = "Connect TWS"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'txtHarvestingIP
        '
        Me.txtHarvestingIP.Location = New System.Drawing.Point(200, 68)
        Me.txtHarvestingIP.Name = "txtHarvestingIP"
        Me.txtHarvestingIP.Size = New System.Drawing.Size(59, 20)
        Me.txtHarvestingIP.TabIndex = 237
        Me.txtHarvestingIP.Text = "127.0.0.1"
        Me.txtHarvestingIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(164, 71)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(29, 13)
        Me.Label77.TabIndex = 236
        Me.Label77.Text = "Host"
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(265, 70)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(26, 13)
        Me.Label76.TabIndex = 235
        Me.Label76.Text = "Port"
        '
        'txtHarvestingPort
        '
        Me.txtHarvestingPort.Location = New System.Drawing.Point(297, 67)
        Me.txtHarvestingPort.Name = "txtHarvestingPort"
        Me.txtHarvestingPort.Size = New System.Drawing.Size(41, 20)
        Me.txtHarvestingPort.TabIndex = 234
        Me.txtHarvestingPort.Text = "7497"
        Me.txtHarvestingPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(348, 71)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(45, 13)
        Me.Label75.TabIndex = 232
        Me.Label75.Text = "Client Id"
        '
        'txtHarvestingClientId
        '
        Me.txtHarvestingClientId.Location = New System.Drawing.Point(399, 67)
        Me.txtHarvestingClientId.Name = "txtHarvestingClientId"
        Me.txtHarvestingClientId.Size = New System.Drawing.Size(32, 20)
        Me.txtHarvestingClientId.TabIndex = 231
        Me.txtHarvestingClientId.Text = "0"
        Me.txtHarvestingClientId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnPlaceOptionOrder
        '
        Me.btnPlaceOptionOrder.BackColor = System.Drawing.SystemColors.Control
        Me.btnPlaceOptionOrder.Location = New System.Drawing.Point(835, 423)
        Me.btnPlaceOptionOrder.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPlaceOptionOrder.Name = "btnPlaceOptionOrder"
        Me.btnPlaceOptionOrder.Size = New System.Drawing.Size(132, 27)
        Me.btnPlaceOptionOrder.TabIndex = 227
        Me.btnPlaceOptionOrder.Text = "Place Option Order"
        Me.btnPlaceOptionOrder.UseVisualStyleBackColor = False
        '
        'btnGetOptionPrice
        '
        Me.btnGetOptionPrice.BackColor = System.Drawing.Color.Ivory
        Me.btnGetOptionPrice.Location = New System.Drawing.Point(292, 453)
        Me.btnGetOptionPrice.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetOptionPrice.Name = "btnGetOptionPrice"
        Me.btnGetOptionPrice.Size = New System.Drawing.Size(132, 27)
        Me.btnGetOptionPrice.TabIndex = 228
        Me.btnGetOptionPrice.Text = "Get Option Price"
        Me.btnGetOptionPrice.UseVisualStyleBackColor = False
        '
        'btnGetStockPrice
        '
        Me.btnGetStockPrice.BackColor = System.Drawing.Color.Ivory
        Me.btnGetStockPrice.Location = New System.Drawing.Point(156, 453)
        Me.btnGetStockPrice.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetStockPrice.Name = "btnGetStockPrice"
        Me.btnGetStockPrice.Size = New System.Drawing.Size(132, 27)
        Me.btnGetStockPrice.TabIndex = 294
        Me.btnGetStockPrice.Text = "Get Stock Price"
        Me.btnGetStockPrice.UseVisualStyleBackColor = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1442, 699)
        Me.Controls.Add(Me.btnGetStockPrice)
        Me.Controls.Add(Me.btnDisconnect)
        Me.Controls.Add(Me.btnGetOptionPrice)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.btnPlaceOptionOrder)
        Me.Controls.Add(Me.pnlHarvesting)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button78)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.pnlBacktest)
        Me.Controls.Add(Me.btnAnalysis)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnBackTest)
        Me.Controls.Add(Me.Button71)
        Me.Controls.Add(Me.pnlMan)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.btnPlaceOrder)
        Me.Controls.Add(Me.lstErrorResponses)
        Me.Controls.Add(Me.btnGetPositions)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.lstServerResponses)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Button46)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbldatastring)
        Me.Controls.Add(Me.lblConStatus)
        Me.Controls.Add(Me.btnReqNextId)
        Me.Controls.Add(Me.btnReqExecutions)
        Me.Controls.Add(Me.Button35)
        Me.Controls.Add(Me.Button31)
        Me.Controls.Add(Me.btnReqMktData)
        Me.Controls.Add(Me.btnReqAllOpenOrders)
        Me.Controls.Add(Me.btnReqContractDetails)
        Me.Controls.Add(Me.btnReqOpenOrders)
        Me.Controls.Add(Me.btnCancelMarketData)
        Me.Controls.Add(Me.txtHarvestingIP)
        Me.Controls.Add(Me.txtHarvestingClientId)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.txtHarvestingPort)
        Me.Controls.Add(Me.Label76)
        Me.Controls.Add(Me.Label77)
        Me.Name = "Main"
        Me.Text = "Willie"
        CType(Me.HarvestIndexBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptionwavesdbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptionwavesdbDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
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
        Me.pnlBacktest.ResumeLayout(False)
        Me.pnlBacktest.PerformLayout()
        Me.pnlHarvesting.ResumeLayout(False)
        Me.pnlHarvesting.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Timer60Sec As Timer
    Friend WithEvents TimerAtTime As Timer
    Friend WithEvents ckRobotOn As CheckBox
    Friend WithEvents btnBackTest As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblBuild As Label
    Friend WithEvents lstErrorResponses As ListBox
    Friend WithEvents btnAnalysis As Button
    Friend WithEvents btnProfile As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
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
    Friend WithEvents Label9 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label54 As Label
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
    Friend WithEvents btnGetPrice As Button
    Friend WithEvents txtPriceSymbol As TextBox
    Friend WithEvents pnlBacktest As Panel
    Friend WithEvents Label65 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents btnHideBackTesting As Button
    Friend WithEvents btnBackTesting As Button
    Friend WithEvents lblDatafileSymbol As Label
    Friend WithEvents txtLoadSymbol As TextBox
    Friend WithEvents btnAssembleDataFile As Button
    Friend WithEvents Label69 As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents btnAssembleDataFileDIrectPull As Button
    Friend WithEvents cmbBackTestIndexes As ComboBox
    Friend WithEvents Label70 As Label
    Friend WithEvents btnStartBackTest As Button
    Friend WithEvents lblHarvestKey As Label
    Friend WithEvents btnBacktestClear As Button
    Friend WithEvents btnCancelMarketData As Button
    Friend WithEvents btnReqMktData As Button
    Friend WithEvents btnReqOpenOrders As Button
    Friend WithEvents btnReqContractDetails As Button
    Friend WithEvents btnReqNextId As Button
    Friend WithEvents btnReqExecutions As Button
    Friend WithEvents Button35 As Button
    Friend WithEvents btnReqAllOpenOrders As Button
    Friend WithEvents Button31 As Button
    Friend WithEvents Button46 As Button
    Friend WithEvents btnGetPositions As Button
    Friend WithEvents Button71 As Button
    Friend WithEvents btnPlaceOrder As Button
    Friend WithEvents Button78 As Button
    Friend WithEvents Button19 As Button
    Friend WithEvents Label72 As Label
    Friend WithEvents txtDays As TextBox
    Friend WithEvents Label71 As Label
    Friend WithEvents txtMonths As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents txtYears As TextBox
    Friend WithEvents Label73 As Label
    Friend WithEvents txtStartYear As TextBox
    Friend WithEvents btnHarvesting As Button
    Friend WithEvents pnlHarvesting As Panel
    Friend WithEvents lblBuyOrderExists As Label
    Friend WithEvents btnSettings As Button
    Friend WithEvents txtHarvestingIP As TextBox
    Friend WithEvents Label77 As Label
    Friend WithEvents Label76 As Label
    Friend WithEvents txtHarvestingPort As TextBox
    Friend WithEvents Label75 As Label
    Friend WithEvents txtHarvestingClientId As TextBox
    Friend WithEvents btnHarvestingStartWillie As Button
    Friend WithEvents Label78 As Label
    Friend WithEvents cmbHarvestIndex As ComboBox
    Friend WithEvents ckSnapshot As CheckBox
    Friend WithEvents Label39 As Label
    Friend WithEvents lblBidPrice As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents lblAskPrice As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents lblPClose As Label
    Friend WithEvents lblPriorClose As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents lblTodaysOpen As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents lblLastPrice As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents lblTodaysLow As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents lblTodaysHigh As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents lblCurrentMark As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents lblNextBTO As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents Label67 As Label
    Friend WithEvents Label63 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents lblbtoMove As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label79 As Label
    Friend WithEvents Label80 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents lbloLast As Label
    Friend WithEvents Label82 As Label
    Friend WithEvents lbloLowToday As Label
    Friend WithEvents Label84 As Label
    Friend WithEvents lbloHighToday As Label
    Friend WithEvents Label86 As Label
    Friend WithEvents lbloOpenToday As Label
    Friend WithEvents Label88 As Label
    Friend WithEvents lblOprior As Label
    Friend WithEvents Label90 As Label
    Friend WithEvents lbloAskPrice As Label
    Friend WithEvents Label92 As Label
    Friend WithEvents lbloBidPrice As Label
    Friend WithEvents Label81 As Label
    Friend WithEvents lblSellOrderExists As Label
    Friend WithEvents btnPlaceOptionOrder As Button
    Friend WithEvents btnGetOptionPrice As Button
    Friend WithEvents Label83 As Label
    Friend WithEvents BTOExists As Label
    Friend WithEvents btnConnect As Button
    Friend WithEvents btnDisconnect As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCloseMe As Button
    Friend WithEvents btnGetStockPrice As Button
End Class
