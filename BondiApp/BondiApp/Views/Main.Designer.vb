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
        Me.btnReqNextValidId = New System.Windows.Forms.Button()
        Me.HarvestIndexBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OptionwavesdbDataSet = New BondiApp.optionwavesdbDataSet()
        Me.HarvestIndexTableAdapter = New BondiApp.optionwavesdbDataSetTableAdapters.HarvestIndexTableAdapter()
        Me.btnSendOrder = New System.Windows.Forms.Button()
        Me.lbldatastring = New System.Windows.Forms.Label()
        Me.OptionwavesdbDataSet1 = New BondiApp.optionwavesdbDataSet()
        Me.txtOrderId = New System.Windows.Forms.TextBox()
        Me.btnCancelOrder = New System.Windows.Forms.Button()
        Me.btnModOrder = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSymbol = New System.Windows.Forms.Label()
        Me.txtSymbol = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAction = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCancelId = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtModifyQty = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtModifyPrice = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtModifyType = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtModifyAction = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtModifySymbol = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtModifyOrderId = New System.Windows.Forms.TextBox()
        Me.lstServerResponses = New System.Windows.Forms.ListBox()
        Me.btnWillie = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.btnGetPrice = New System.Windows.Forms.Button()
        Me.txtGetPriceSymbol = New System.Windows.Forms.TextBox()
        Me.btnckprice = New System.Windows.Forms.Button()
        Me.bntlistclear = New System.Windows.Forms.Button()
        Me.Timer60Sec = New System.Windows.Forms.Timer(Me.components)
        Me.TimerAtTime = New System.Windows.Forms.Timer(Me.components)
        Me.ckRobotOn = New System.Windows.Forms.CheckBox()
        Me.btnBackTest = New System.Windows.Forms.Button()
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
        Me.Panel1 = New System.Windows.Forms.Panel()
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
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbWillie = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btnOpPrice = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtOptionSymbol = New System.Windows.Forms.TextBox()
        Me.lblOptionStrike = New System.Windows.Forms.Label()
        Me.txtOptionStrike = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtOptionRight = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtOptionIV = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtOptionExpirationDate = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtSpreadExp = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtSpreadRight = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtSpreadStrike = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtSpreadSymbol = New System.Windows.Forms.TextBox()
        Me.btnAddLeg = New System.Windows.Forms.Button()
        Me.btnSpreadOrder = New System.Windows.Forms.Button()
        Me.grdContracts = New System.Windows.Forms.DataGridView()
        Me.colSymbol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStrike = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lstConnectionResponses = New System.Windows.Forms.ListBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lstErrorResponses = New System.Windows.Forms.ListBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnAnalysis = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtTickId = New System.Windows.Forms.TextBox()
        Me.btnTickPrice = New System.Windows.Forms.Button()
        CType(Me.HarvestIndexBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionwavesdbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionwavesdbDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grdContracts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblConStatus
        '
        Me.lblConStatus.AutoSize = True
        Me.lblConStatus.Location = New System.Drawing.Point(10, 609)
        Me.lblConStatus.Name = "lblConStatus"
        Me.lblConStatus.Size = New System.Drawing.Size(44, 13)
        Me.lblConStatus.TabIndex = 7
        Me.lblConStatus.Text = "Off Line"
        '
        'btnReqNextValidId
        '
        Me.btnReqNextValidId.Location = New System.Drawing.Point(209, 745)
        Me.btnReqNextValidId.Name = "btnReqNextValidId"
        Me.btnReqNextValidId.Size = New System.Drawing.Size(67, 23)
        Me.btnReqNextValidId.TabIndex = 8
        Me.btnReqNextValidId.Text = "OrderId"
        Me.btnReqNextValidId.UseVisualStyleBackColor = True
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
        'btnSendOrder
        '
        Me.btnSendOrder.Location = New System.Drawing.Point(573, 162)
        Me.btnSendOrder.Name = "btnSendOrder"
        Me.btnSendOrder.Size = New System.Drawing.Size(103, 23)
        Me.btnSendOrder.TabIndex = 11
        Me.btnSendOrder.Text = "Send Stock Order"
        Me.btnSendOrder.UseVisualStyleBackColor = True
        '
        'lbldatastring
        '
        Me.lbldatastring.AutoSize = True
        Me.lbldatastring.Location = New System.Drawing.Point(505, 609)
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
        'txtOrderId
        '
        Me.txtOrderId.Location = New System.Drawing.Point(63, 165)
        Me.txtOrderId.Name = "txtOrderId"
        Me.txtOrderId.Size = New System.Drawing.Size(41, 20)
        Me.txtOrderId.TabIndex = 16
        Me.txtOrderId.Text = "0"
        Me.txtOrderId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancelOrder
        '
        Me.btnCancelOrder.Location = New System.Drawing.Point(575, 316)
        Me.btnCancelOrder.Name = "btnCancelOrder"
        Me.btnCancelOrder.Size = New System.Drawing.Size(101, 23)
        Me.btnCancelOrder.TabIndex = 19
        Me.btnCancelOrder.Text = "Cancel Order"
        Me.btnCancelOrder.UseVisualStyleBackColor = True
        '
        'btnModOrder
        '
        Me.btnModOrder.Location = New System.Drawing.Point(573, 199)
        Me.btnModOrder.Name = "btnModOrder"
        Me.btnModOrder.Size = New System.Drawing.Size(102, 23)
        Me.btnModOrder.TabIndex = 21
        Me.btnModOrder.Text = "Modify Order"
        Me.btnModOrder.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Order ID"
        '
        'lblSymbol
        '
        Me.lblSymbol.AutoSize = True
        Me.lblSymbol.Location = New System.Drawing.Point(115, 170)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.Size = New System.Drawing.Size(41, 13)
        Me.lblSymbol.TabIndex = 25
        Me.lblSymbol.Text = "Symbol"
        '
        'txtSymbol
        '
        Me.txtSymbol.Location = New System.Drawing.Point(162, 165)
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.Size = New System.Drawing.Size(41, 20)
        Me.txtSymbol.TabIndex = 24
        Me.txtSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(211, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Action"
        '
        'txtAction
        '
        Me.txtAction.Location = New System.Drawing.Point(254, 165)
        Me.txtAction.Name = "txtAction"
        Me.txtAction.Size = New System.Drawing.Size(41, 20)
        Me.txtAction.TabIndex = 26
        Me.txtAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(301, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Type"
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(338, 165)
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(41, 20)
        Me.txtType.TabIndex = 28
        Me.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(472, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Quantity"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(526, 167)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(41, 20)
        Me.txtQty.TabIndex = 32
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(385, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Price"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(422, 167)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(41, 20)
        Me.txtPrice.TabIndex = 30
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(472, 325)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "OrderID"
        '
        'txtCancelId
        '
        Me.txtCancelId.Location = New System.Drawing.Point(526, 318)
        Me.txtCancelId.Name = "txtCancelId"
        Me.txtCancelId.Size = New System.Drawing.Size(41, 20)
        Me.txtCancelId.TabIndex = 34
        Me.txtCancelId.Text = "0"
        Me.txtCancelId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(472, 209)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Quantity"
        '
        'txtModifyQty
        '
        Me.txtModifyQty.Location = New System.Drawing.Point(526, 204)
        Me.txtModifyQty.Name = "txtModifyQty"
        Me.txtModifyQty.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyQty.TabIndex = 46
        Me.txtModifyQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(385, 207)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Price"
        '
        'txtModifyPrice
        '
        Me.txtModifyPrice.Location = New System.Drawing.Point(422, 206)
        Me.txtModifyPrice.Name = "txtModifyPrice"
        Me.txtModifyPrice.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyPrice.TabIndex = 44
        Me.txtModifyPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(301, 207)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Type"
        '
        'txtModifyType
        '
        Me.txtModifyType.Location = New System.Drawing.Point(338, 206)
        Me.txtModifyType.Name = "txtModifyType"
        Me.txtModifyType.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyType.TabIndex = 42
        Me.txtModifyType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(211, 207)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Action"
        '
        'txtModifyAction
        '
        Me.txtModifyAction.Location = New System.Drawing.Point(254, 204)
        Me.txtModifyAction.Name = "txtModifyAction"
        Me.txtModifyAction.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyAction.TabIndex = 40
        Me.txtModifyAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(115, 207)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "Symbol"
        '
        'txtModifySymbol
        '
        Me.txtModifySymbol.Location = New System.Drawing.Point(161, 204)
        Me.txtModifySymbol.Name = "txtModifySymbol"
        Me.txtModifySymbol.Size = New System.Drawing.Size(41, 20)
        Me.txtModifySymbol.TabIndex = 38
        Me.txtModifySymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 209)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "OrderID"
        '
        'txtModifyOrderId
        '
        Me.txtModifyOrderId.Location = New System.Drawing.Point(63, 204)
        Me.txtModifyOrderId.Name = "txtModifyOrderId"
        Me.txtModifyOrderId.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyOrderId.TabIndex = 36
        Me.txtModifyOrderId.Text = "4"
        Me.txtModifyOrderId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lstServerResponses
        '
        Me.lstServerResponses.FormattingEnabled = True
        Me.lstServerResponses.Location = New System.Drawing.Point(8, 624)
        Me.lstServerResponses.Margin = New System.Windows.Forms.Padding(2)
        Me.lstServerResponses.Name = "lstServerResponses"
        Me.lstServerResponses.Size = New System.Drawing.Size(668, 69)
        Me.lstServerResponses.TabIndex = 48
        '
        'btnWillie
        '
        Me.btnWillie.Location = New System.Drawing.Point(339, 101)
        Me.btnWillie.Name = "btnWillie"
        Me.btnWillie.Size = New System.Drawing.Size(117, 33)
        Me.btnWillie.TabIndex = 49
        Me.btnWillie.Text = "Start Willie"
        Me.btnWillie.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(589, 745)
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
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(575, 378)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(100, 23)
        Me.btnOpenFile.TabIndex = 52
        Me.btnOpenFile.Text = "Load File"
        Me.btnOpenFile.UseVisualStyleBackColor = True
        Me.btnOpenFile.Visible = False
        '
        'btnGetPrice
        '
        Me.btnGetPrice.Location = New System.Drawing.Point(89, 745)
        Me.btnGetPrice.Name = "btnGetPrice"
        Me.btnGetPrice.Size = New System.Drawing.Size(67, 23)
        Me.btnGetPrice.TabIndex = 61
        Me.btnGetPrice.Text = "Get Price"
        Me.btnGetPrice.UseVisualStyleBackColor = True
        '
        'txtGetPriceSymbol
        '
        Me.txtGetPriceSymbol.Location = New System.Drawing.Point(160, 748)
        Me.txtGetPriceSymbol.Name = "txtGetPriceSymbol"
        Me.txtGetPriceSymbol.Size = New System.Drawing.Size(42, 20)
        Me.txtGetPriceSymbol.TabIndex = 62
        Me.txtGetPriceSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnckprice
        '
        Me.btnckprice.Location = New System.Drawing.Point(283, 746)
        Me.btnckprice.Name = "btnckprice"
        Me.btnckprice.Size = New System.Drawing.Size(67, 23)
        Me.btnckprice.TabIndex = 67
        Me.btnckprice.Text = "Price"
        Me.btnckprice.UseVisualStyleBackColor = True
        '
        'bntlistclear
        '
        Me.bntlistclear.Location = New System.Drawing.Point(502, 745)
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
        Me.ckRobotOn.Location = New System.Drawing.Point(470, 110)
        Me.ckRobotOn.Name = "ckRobotOn"
        Me.ckRobotOn.Size = New System.Drawing.Size(52, 17)
        Me.ckRobotOn.TabIndex = 69
        Me.ckRobotOn.Text = "Timer"
        Me.ckRobotOn.UseVisualStyleBackColor = True
        '
        'btnBackTest
        '
        Me.btnBackTest.Location = New System.Drawing.Point(356, 746)
        Me.btnBackTest.Name = "btnBackTest"
        Me.btnBackTest.Size = New System.Drawing.Size(67, 23)
        Me.btnBackTest.TabIndex = 71
        Me.btnBackTest.Text = "BackTest"
        Me.btnBackTest.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(472, 248)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 84
        Me.Label17.Text = "Quantity"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(526, 245)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(41, 20)
        Me.TextBox1.TabIndex = 83
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(386, 248)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 82
        Me.Label20.Text = "Price"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(422, 241)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(41, 20)
        Me.TextBox2.TabIndex = 81
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(301, 248)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 13)
        Me.Label21.TabIndex = 80
        Me.Label21.Text = "Type"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(339, 241)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(41, 20)
        Me.TextBox3.TabIndex = 79
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(211, 248)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(37, 13)
        Me.Label22.TabIndex = 78
        Me.Label22.Text = "Action"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(254, 245)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(41, 20)
        Me.TextBox4.TabIndex = 77
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(115, 244)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(41, 13)
        Me.Label23.TabIndex = 76
        Me.Label23.Text = "Symbol"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(162, 245)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(41, 20)
        Me.TextBox5.TabIndex = 75
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(7, 248)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(44, 13)
        Me.Label24.TabIndex = 74
        Me.Label24.Text = "OrderID"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(63, 241)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(41, 20)
        Me.TextBox6.TabIndex = 73
        Me.TextBox6.Text = "0"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSendOption
        '
        Me.btnSendOption.Location = New System.Drawing.Point(574, 244)
        Me.btnSendOption.Name = "btnSendOption"
        Me.btnSendOption.Size = New System.Drawing.Size(102, 23)
        Me.btnSendOption.TabIndex = 72
        Me.btnSendOption.Text = "Option Order"
        Me.btnSendOption.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(696, 35)
        Me.Panel1.TabIndex = 85
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(4, 7)
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
        Me.Panel3.Location = New System.Drawing.Point(0, 36)
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
        Me.btnDisconnect.Location = New System.Drawing.Point(604, 4)
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
        Me.Panel5.Controls.Add(Me.lblStatus)
        Me.Panel5.Location = New System.Drawing.Point(-3, 773)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(679, 31)
        Me.Panel5.TabIndex = 89
        '
        'lblBuild
        '
        Me.lblBuild.AutoSize = True
        Me.lblBuild.Location = New System.Drawing.Point(403, 10)
        Me.lblBuild.Name = "lblBuild"
        Me.lblBuild.Size = New System.Drawing.Size(66, 13)
        Me.lblBuild.TabIndex = 94
        Me.lblBuild.Text = "build version"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(12, 10)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(165, 13)
        Me.lblStatus.TabIndex = 68
        Me.lblStatus.Text = "Welcome to Resignation Trading!"
        '
        'cmbWillie
        '
        Me.cmbWillie.FormattingEnabled = True
        Me.cmbWillie.Location = New System.Drawing.Point(470, 75)
        Me.cmbWillie.Name = "cmbWillie"
        Me.cmbWillie.Size = New System.Drawing.Size(206, 21)
        Me.cmbWillie.TabIndex = 91
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(336, 78)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(120, 13)
        Me.Label26.TabIndex = 92
        Me.Label26.Text = "Select Harvest Product:"
        '
        'btnOpPrice
        '
        Me.btnOpPrice.Location = New System.Drawing.Point(574, 284)
        Me.btnOpPrice.Name = "btnOpPrice"
        Me.btnOpPrice.Size = New System.Drawing.Size(101, 23)
        Me.btnOpPrice.TabIndex = 93
        Me.btnOpPrice.Text = "Opt Price"
        Me.btnOpPrice.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 289)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 95
        Me.Label16.Text = "Symbol"
        '
        'txtOptionSymbol
        '
        Me.txtOptionSymbol.Location = New System.Drawing.Point(63, 286)
        Me.txtOptionSymbol.Name = "txtOptionSymbol"
        Me.txtOptionSymbol.Size = New System.Drawing.Size(41, 20)
        Me.txtOptionSymbol.TabIndex = 94
        Me.txtOptionSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOptionStrike
        '
        Me.lblOptionStrike.AutoSize = True
        Me.lblOptionStrike.Location = New System.Drawing.Point(302, 289)
        Me.lblOptionStrike.Name = "lblOptionStrike"
        Me.lblOptionStrike.Size = New System.Drawing.Size(34, 13)
        Me.lblOptionStrike.TabIndex = 97
        Me.lblOptionStrike.Text = "Strike"
        '
        'txtOptionStrike
        '
        Me.txtOptionStrike.Location = New System.Drawing.Point(338, 286)
        Me.txtOptionStrike.Name = "txtOptionStrike"
        Me.txtOptionStrike.Size = New System.Drawing.Size(41, 20)
        Me.txtOptionStrike.TabIndex = 96
        Me.txtOptionStrike.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(386, 289)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(36, 13)
        Me.Label27.TabIndex = 99
        Me.Label27.Text = "P or C"
        '
        'txtOptionRight
        '
        Me.txtOptionRight.Location = New System.Drawing.Point(422, 286)
        Me.txtOptionRight.Name = "txtOptionRight"
        Me.txtOptionRight.Size = New System.Drawing.Size(41, 20)
        Me.txtOptionRight.TabIndex = 98
        Me.txtOptionRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(472, 289)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(17, 13)
        Me.Label28.TabIndex = 101
        Me.Label28.Text = "IV"
        '
        'txtOptionIV
        '
        Me.txtOptionIV.Location = New System.Drawing.Point(526, 286)
        Me.txtOptionIV.Name = "txtOptionIV"
        Me.txtOptionIV.Size = New System.Drawing.Size(41, 20)
        Me.txtOptionIV.TabIndex = 100
        Me.txtOptionIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(115, 289)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(79, 13)
        Me.Label30.TabIndex = 105
        Me.Label30.Text = "Expiration Date"
        '
        'txtOptionExpirationDate
        '
        Me.txtOptionExpirationDate.Location = New System.Drawing.Point(198, 286)
        Me.txtOptionExpirationDate.Name = "txtOptionExpirationDate"
        Me.txtOptionExpirationDate.Size = New System.Drawing.Size(98, 20)
        Me.txtOptionExpirationDate.TabIndex = 104
        Me.txtOptionExpirationDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(115, 354)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(79, 13)
        Me.Label31.TabIndex = 118
        Me.Label31.Text = "Expiration Date"
        '
        'txtSpreadExp
        '
        Me.txtSpreadExp.Location = New System.Drawing.Point(198, 351)
        Me.txtSpreadExp.Name = "txtSpreadExp"
        Me.txtSpreadExp.Size = New System.Drawing.Size(98, 20)
        Me.txtSpreadExp.TabIndex = 117
        Me.txtSpreadExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(386, 354)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(36, 13)
        Me.Label34.TabIndex = 112
        Me.Label34.Text = "P or C"
        '
        'txtSpreadRight
        '
        Me.txtSpreadRight.Location = New System.Drawing.Point(422, 351)
        Me.txtSpreadRight.Name = "txtSpreadRight"
        Me.txtSpreadRight.Size = New System.Drawing.Size(41, 20)
        Me.txtSpreadRight.TabIndex = 111
        Me.txtSpreadRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(302, 354)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(34, 13)
        Me.Label35.TabIndex = 110
        Me.Label35.Text = "Strike"
        '
        'txtSpreadStrike
        '
        Me.txtSpreadStrike.Location = New System.Drawing.Point(338, 351)
        Me.txtSpreadStrike.Name = "txtSpreadStrike"
        Me.txtSpreadStrike.Size = New System.Drawing.Size(41, 20)
        Me.txtSpreadStrike.TabIndex = 109
        Me.txtSpreadStrike.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(8, 354)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(41, 13)
        Me.Label36.TabIndex = 108
        Me.Label36.Text = "Symbol"
        '
        'txtSpreadSymbol
        '
        Me.txtSpreadSymbol.Location = New System.Drawing.Point(63, 351)
        Me.txtSpreadSymbol.Name = "txtSpreadSymbol"
        Me.txtSpreadSymbol.Size = New System.Drawing.Size(41, 20)
        Me.txtSpreadSymbol.TabIndex = 107
        Me.txtSpreadSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAddLeg
        '
        Me.btnAddLeg.Location = New System.Drawing.Point(475, 349)
        Me.btnAddLeg.Name = "btnAddLeg"
        Me.btnAddLeg.Size = New System.Drawing.Size(92, 23)
        Me.btnAddLeg.TabIndex = 106
        Me.btnAddLeg.Text = "Add Leg"
        Me.btnAddLeg.UseVisualStyleBackColor = True
        '
        'btnSpreadOrder
        '
        Me.btnSpreadOrder.Location = New System.Drawing.Point(575, 349)
        Me.btnSpreadOrder.Name = "btnSpreadOrder"
        Me.btnSpreadOrder.Size = New System.Drawing.Size(100, 23)
        Me.btnSpreadOrder.TabIndex = 120
        Me.btnSpreadOrder.Text = "Send Spread "
        Me.btnSpreadOrder.UseVisualStyleBackColor = True
        '
        'grdContracts
        '
        Me.grdContracts.AllowUserToAddRows = False
        Me.grdContracts.AllowUserToDeleteRows = False
        Me.grdContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdContracts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSymbol, Me.colExpDate, Me.colStrike, Me.colRight, Me.colConId})
        Me.grdContracts.Location = New System.Drawing.Point(8, 378)
        Me.grdContracts.Name = "grdContracts"
        Me.grdContracts.ReadOnly = True
        Me.grdContracts.Size = New System.Drawing.Size(559, 96)
        Me.grdContracts.TabIndex = 121
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
        'lstConnectionResponses
        '
        Me.lstConnectionResponses.BackColor = System.Drawing.SystemColors.MenuBar
        Me.lstConnectionResponses.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstConnectionResponses.FormattingEnabled = True
        Me.lstConnectionResponses.Location = New System.Drawing.Point(8, 96)
        Me.lstConnectionResponses.Margin = New System.Windows.Forms.Padding(2)
        Me.lstConnectionResponses.Name = "lstConnectionResponses"
        Me.lstConnectionResponses.Size = New System.Drawing.Size(324, 39)
        Me.lstConnectionResponses.TabIndex = 122
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(5, 78)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(97, 13)
        Me.Label32.TabIndex = 123
        Me.Label32.Text = "Connection Status:"
        '
        'lstErrorResponses
        '
        Me.lstErrorResponses.FormattingEnabled = True
        Me.lstErrorResponses.Location = New System.Drawing.Point(8, 697)
        Me.lstErrorResponses.Margin = New System.Windows.Forms.Padding(2)
        Me.lstErrorResponses.Name = "lstErrorResponses"
        Me.lstErrorResponses.Size = New System.Drawing.Size(668, 43)
        Me.lstErrorResponses.TabIndex = 124
        '
        'btnAnalysis
        '
        Me.btnAnalysis.Location = New System.Drawing.Point(429, 746)
        Me.btnAnalysis.Name = "btnAnalysis"
        Me.btnAnalysis.Size = New System.Drawing.Size(67, 23)
        Me.btnAnalysis.TabIndex = 125
        Me.btnAnalysis.Text = "Analysis"
        Me.btnAnalysis.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(9, 750)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(67, 13)
        Me.Label33.TabIndex = 126
        Me.Label33.Text = "App Controls"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(5, 149)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(116, 13)
        Me.Label19.TabIndex = 127
        Me.Label19.Text = "Manual Order Handling"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(240, 537)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(170, 13)
        Me.Label29.TabIndex = 128
        Me.Label29.Text = "Additional Controls Here If Needed"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(13, 488)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(40, 13)
        Me.Label37.TabIndex = 130
        Me.Label37.Text = "Tick Id"
        '
        'txtTickId
        '
        Me.txtTickId.Location = New System.Drawing.Point(68, 485)
        Me.txtTickId.Name = "txtTickId"
        Me.txtTickId.Size = New System.Drawing.Size(41, 20)
        Me.txtTickId.TabIndex = 129
        Me.txtTickId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnTickPrice
        '
        Me.btnTickPrice.Location = New System.Drawing.Point(118, 483)
        Me.btnTickPrice.Name = "btnTickPrice"
        Me.btnTickPrice.Size = New System.Drawing.Size(100, 23)
        Me.btnTickPrice.TabIndex = 131
        Me.btnTickPrice.Text = "Get Tick"
        Me.btnTickPrice.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 749)
        Me.Controls.Add(Me.btnTickPrice)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.txtTickId)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.btnAnalysis)
        Me.Controls.Add(Me.lstErrorResponses)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.lstConnectionResponses)
        Me.Controls.Add(Me.grdContracts)
        Me.Controls.Add(Me.btnSpreadOrder)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtSpreadExp)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txtSpreadRight)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.txtSpreadStrike)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txtSpreadSymbol)
        Me.Controls.Add(Me.btnAddLeg)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtOptionExpirationDate)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtOptionIV)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txtOptionRight)
        Me.Controls.Add(Me.lblOptionStrike)
        Me.Controls.Add(Me.txtOptionStrike)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtOptionSymbol)
        Me.Controls.Add(Me.btnOpPrice)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.cmbWillie)
        Me.Controls.Add(Me.lstServerResponses)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.btnSendOption)
        Me.Controls.Add(Me.btnBackTest)
        Me.Controls.Add(Me.ckRobotOn)
        Me.Controls.Add(Me.bntlistclear)
        Me.Controls.Add(Me.btnckprice)
        Me.Controls.Add(Me.txtGetPriceSymbol)
        Me.Controls.Add(Me.btnGetPrice)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnWillie)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtModifyQty)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtModifyPrice)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtModifyType)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtModifyAction)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtModifySymbol)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtModifyOrderId)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCancelId)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAction)
        Me.Controls.Add(Me.lblSymbol)
        Me.Controls.Add(Me.txtSymbol)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnModOrder)
        Me.Controls.Add(Me.btnCancelOrder)
        Me.Controls.Add(Me.txtOrderId)
        Me.Controls.Add(Me.lbldatastring)
        Me.Controls.Add(Me.btnSendOrder)
        Me.Controls.Add(Me.btnReqNextValidId)
        Me.Controls.Add(Me.lblConStatus)
        Me.Name = "Main"
        Me.Text = "Main"
        CType(Me.HarvestIndexBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptionwavesdbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptionwavesdbDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.grdContracts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblConStatus As Label
    Friend WithEvents btnReqNextValidId As Button
    Friend WithEvents OptionwavesdbDataSet As optionwavesdbDataSet
    Friend WithEvents HarvestIndexBindingSource As BindingSource
    Friend WithEvents HarvestIndexTableAdapter As optionwavesdbDataSetTableAdapters.HarvestIndexTableAdapter
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents btnSendOrder As Button
    Friend WithEvents lbldatastring As Label
    Friend WithEvents OptionwavesdbDataSet1 As optionwavesdbDataSet
    Friend WithEvents txtOrderId As TextBox
    Friend WithEvents btnCancelOrder As Button
    Friend WithEvents btnModOrder As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents lblSymbol As Label
    Friend WithEvents txtSymbol As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAction As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtType As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCancelId As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtModifyQty As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtModifyPrice As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtModifyType As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtModifyAction As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtModifySymbol As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtModifyOrderId As TextBox
    Friend WithEvents lstServerResponses As ListBox
    Friend WithEvents btnWillie As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnOpenFile As Button
    Friend WithEvents btnGetPrice As Button
    Friend WithEvents txtGetPriceSymbol As TextBox
    Friend WithEvents btnckprice As Button
    Friend WithEvents bntlistclear As Button
    Friend WithEvents Timer60Sec As Timer
    Friend WithEvents TimerAtTime As Timer
    Friend WithEvents ckRobotOn As CheckBox
    Friend WithEvents btnBackTest As Button
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
    Friend WithEvents btnOpPrice As Button
    Friend WithEvents lblBuild As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtOptionSymbol As TextBox
    Friend WithEvents lblOptionStrike As Label
    Friend WithEvents txtOptionStrike As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents txtOptionRight As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtOptionIV As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtOptionExpirationDate As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtSpreadExp As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents txtSpreadRight As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents txtSpreadStrike As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents txtSpreadSymbol As TextBox
    Friend WithEvents btnAddLeg As Button
    Friend WithEvents btnSpreadOrder As Button
    Friend WithEvents grdContracts As DataGridView
    Friend WithEvents colSymbol As DataGridViewTextBoxColumn
    Friend WithEvents colExpDate As DataGridViewTextBoxColumn
    Friend WithEvents colStrike As DataGridViewTextBoxColumn
    Friend WithEvents colRight As DataGridViewTextBoxColumn
    Friend WithEvents colConId As DataGridViewTextBoxColumn
    Friend WithEvents lstConnectionResponses As ListBox
    Friend WithEvents Label32 As Label
    Friend WithEvents lstErrorResponses As ListBox
    Friend WithEvents btnAnalysis As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents txtTickId As TextBox
    Friend WithEvents btnTickPrice As Button
End Class
