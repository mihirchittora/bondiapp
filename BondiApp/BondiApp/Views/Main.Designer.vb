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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.lblConStatus = New System.Windows.Forms.Label()
        Me.btnReqNextValidId = New System.Windows.Forms.Button()
        Me.HarvestIndexBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OptionwavesdbDataSet = New BondiApp.optionwavesdbDataSet()
        Me.HarvestIndexTableAdapter = New BondiApp.optionwavesdbDataSetTableAdapters.HarvestIndexTableAdapter()
        Me.btnSendOrder = New System.Windows.Forms.Button()
        Me.lbldatastring = New System.Windows.Forms.Label()
        Me.cmbIndexes = New System.Windows.Forms.ComboBox()
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
        Me.Label16 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.lblBacktestStatus = New System.Windows.Forms.Label()
        Me.btnReadBacktest = New System.Windows.Forms.Button()
        Me.lblRecordsProcessed = New System.Windows.Forms.Label()
        Me.lstOHLC = New System.Windows.Forms.ListBox()
        Me.txtClientId = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnGetPrice = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtGetPriceSymbol = New System.Windows.Forms.TextBox()
        Me.cmbWillie = New System.Windows.Forms.ComboBox()
        Me.btnckprice = New System.Windows.Forms.Button()
        Me.bntlistclear = New System.Windows.Forms.Button()
        Me.Timer60Sec = New System.Windows.Forms.Timer(Me.components)
        Me.TimerAtTime = New System.Windows.Forms.Timer(Me.components)
        Me.ckRobotOn = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.btnClearList = New System.Windows.Forms.Button()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
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
        CType(Me.HarvestIndexBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionwavesdbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionwavesdbDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(432, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host"
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(466, 46)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(59, 20)
        Me.txtHost.TabIndex = 1
        Me.txtHost.Text = "127.0.0.1"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(572, 46)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(38, 20)
        Me.txtPort.TabIndex = 3
        Me.txtPort.Text = "7497"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(540, 53)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(26, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Port"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(724, 40)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(72, 23)
        Me.btnConnect.TabIndex = 4
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(802, 40)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(81, 23)
        Me.btnDisconnect.TabIndex = 5
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'lblConStatus
        '
        Me.lblConStatus.AutoSize = True
        Me.lblConStatus.Location = New System.Drawing.Point(336, 484)
        Me.lblConStatus.Name = "lblConStatus"
        Me.lblConStatus.Size = New System.Drawing.Size(44, 13)
        Me.lblConStatus.TabIndex = 7
        Me.lblConStatus.Text = "Off Line"
        '
        'btnReqNextValidId
        '
        Me.btnReqNextValidId.Location = New System.Drawing.Point(802, 106)
        Me.btnReqNextValidId.Name = "btnReqNextValidId"
        Me.btnReqNextValidId.Size = New System.Drawing.Size(81, 23)
        Me.btnReqNextValidId.TabIndex = 8
        Me.btnReqNextValidId.Text = "New Order Id"
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
        Me.btnSendOrder.Location = New System.Drawing.Point(802, 193)
        Me.btnSendOrder.Name = "btnSendOrder"
        Me.btnSendOrder.Size = New System.Drawing.Size(81, 23)
        Me.btnSendOrder.TabIndex = 11
        Me.btnSendOrder.Text = "Stock Order"
        Me.btnSendOrder.UseVisualStyleBackColor = True
        '
        'lbldatastring
        '
        Me.lbldatastring.AutoSize = True
        Me.lbldatastring.Location = New System.Drawing.Point(332, 343)
        Me.lbldatastring.Name = "lbldatastring"
        Me.lbldatastring.Size = New System.Drawing.Size(122, 13)
        Me.lbldatastring.TabIndex = 12
        Me.lbldatastring.Text = "Order Datastring Results"
        '
        'cmbIndexes
        '
        Me.cmbIndexes.FormattingEnabled = True
        Me.cmbIndexes.Location = New System.Drawing.Point(12, 45)
        Me.cmbIndexes.Name = "cmbIndexes"
        Me.cmbIndexes.Size = New System.Drawing.Size(172, 21)
        Me.cmbIndexes.TabIndex = 14
        '
        'OptionwavesdbDataSet1
        '
        Me.OptionwavesdbDataSet1.DataSetName = "optionwavesdbDataSet"
        Me.OptionwavesdbDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtOrderId
        '
        Me.txtOrderId.Location = New System.Drawing.Point(442, 196)
        Me.txtOrderId.Name = "txtOrderId"
        Me.txtOrderId.Size = New System.Drawing.Size(41, 20)
        Me.txtOrderId.TabIndex = 16
        Me.txtOrderId.Text = "0"
        Me.txtOrderId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancelOrder
        '
        Me.btnCancelOrder.Location = New System.Drawing.Point(800, 281)
        Me.btnCancelOrder.Name = "btnCancelOrder"
        Me.btnCancelOrder.Size = New System.Drawing.Size(81, 23)
        Me.btnCancelOrder.TabIndex = 19
        Me.btnCancelOrder.Text = "Cancel Order"
        Me.btnCancelOrder.UseVisualStyleBackColor = True
        '
        'btnModOrder
        '
        Me.btnModOrder.Location = New System.Drawing.Point(802, 235)
        Me.btnModOrder.Name = "btnModOrder"
        Me.btnModOrder.Size = New System.Drawing.Size(81, 23)
        Me.btnModOrder.TabIndex = 21
        Me.btnModOrder.Text = "Modify Order"
        Me.btnModOrder.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(440, 181)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "OrderID"
        '
        'lblSymbol
        '
        Me.lblSymbol.AutoSize = True
        Me.lblSymbol.Location = New System.Drawing.Point(498, 181)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.Size = New System.Drawing.Size(41, 13)
        Me.lblSymbol.TabIndex = 25
        Me.lblSymbol.Text = "Symbol"
        '
        'txtSymbol
        '
        Me.txtSymbol.Location = New System.Drawing.Point(500, 196)
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.Size = New System.Drawing.Size(41, 20)
        Me.txtSymbol.TabIndex = 24
        Me.txtSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(558, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Action"
        '
        'txtAction
        '
        Me.txtAction.Location = New System.Drawing.Point(562, 196)
        Me.txtAction.Name = "txtAction"
        Me.txtAction.Size = New System.Drawing.Size(41, 20)
        Me.txtAction.TabIndex = 26
        Me.txtAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(622, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Type"
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(626, 196)
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(41, 20)
        Me.txtType.TabIndex = 28
        Me.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(744, 181)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Quantity"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(746, 196)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(41, 20)
        Me.txtQty.TabIndex = 32
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(680, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Price"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(682, 196)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(41, 20)
        Me.txtPrice.TabIndex = 30
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(744, 268)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "OrderID"
        '
        'txtCancelId
        '
        Me.txtCancelId.Location = New System.Drawing.Point(746, 284)
        Me.txtCancelId.Name = "txtCancelId"
        Me.txtCancelId.Size = New System.Drawing.Size(41, 20)
        Me.txtCancelId.TabIndex = 34
        Me.txtCancelId.Text = "0"
        Me.txtCancelId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(744, 222)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Quantity"
        '
        'txtModifyQty
        '
        Me.txtModifyQty.Location = New System.Drawing.Point(746, 236)
        Me.txtModifyQty.Name = "txtModifyQty"
        Me.txtModifyQty.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyQty.TabIndex = 46
        Me.txtModifyQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(680, 222)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Price"
        '
        'txtModifyPrice
        '
        Me.txtModifyPrice.Location = New System.Drawing.Point(682, 236)
        Me.txtModifyPrice.Name = "txtModifyPrice"
        Me.txtModifyPrice.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyPrice.TabIndex = 44
        Me.txtModifyPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(622, 222)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Type"
        '
        'txtModifyType
        '
        Me.txtModifyType.Location = New System.Drawing.Point(626, 236)
        Me.txtModifyType.Name = "txtModifyType"
        Me.txtModifyType.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyType.TabIndex = 42
        Me.txtModifyType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(558, 222)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Action"
        '
        'txtModifyAction
        '
        Me.txtModifyAction.Location = New System.Drawing.Point(562, 236)
        Me.txtModifyAction.Name = "txtModifyAction"
        Me.txtModifyAction.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyAction.TabIndex = 40
        Me.txtModifyAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(498, 222)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "Symbol"
        '
        'txtModifySymbol
        '
        Me.txtModifySymbol.Location = New System.Drawing.Point(500, 236)
        Me.txtModifySymbol.Name = "txtModifySymbol"
        Me.txtModifySymbol.Size = New System.Drawing.Size(41, 20)
        Me.txtModifySymbol.TabIndex = 38
        Me.txtModifySymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(440, 222)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "OrderID"
        '
        'txtModifyOrderId
        '
        Me.txtModifyOrderId.Location = New System.Drawing.Point(442, 236)
        Me.txtModifyOrderId.Name = "txtModifyOrderId"
        Me.txtModifyOrderId.Size = New System.Drawing.Size(41, 20)
        Me.txtModifyOrderId.TabIndex = 36
        Me.txtModifyOrderId.Text = "4"
        Me.txtModifyOrderId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lstServerResponses
        '
        Me.lstServerResponses.FormattingEnabled = True
        Me.lstServerResponses.Location = New System.Drawing.Point(335, 358)
        Me.lstServerResponses.Margin = New System.Windows.Forms.Padding(2)
        Me.lstServerResponses.Name = "lstServerResponses"
        Me.lstServerResponses.Size = New System.Drawing.Size(546, 121)
        Me.lstServerResponses.TabIndex = 48
        '
        'btnWillie
        '
        Me.btnWillie.Location = New System.Drawing.Point(802, 76)
        Me.btnWillie.Name = "btnWillie"
        Me.btnWillie.Size = New System.Drawing.Size(81, 23)
        Me.btnWillie.TabIndex = 49
        Me.btnWillie.Text = "Start Willie"
        Me.btnWillie.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(804, 484)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 50
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(218, 24)
        Me.Label16.TabIndex = 51
        Me.Label16.Text = "Back Test Control Center"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(99, 452)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(81, 23)
        Me.btnOpenFile.TabIndex = 52
        Me.btnOpenFile.Text = "Load File"
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'lblBacktestStatus
        '
        Me.lblBacktestStatus.AutoSize = True
        Me.lblBacktestStatus.Location = New System.Drawing.Point(9, 174)
        Me.lblBacktestStatus.Name = "lblBacktestStatus"
        Me.lblBacktestStatus.Size = New System.Drawing.Size(127, 13)
        Me.lblBacktestStatus.TabIndex = 53
        Me.lblBacktestStatus.Text = "Backtest Records Read: "
        '
        'btnReadBacktest
        '
        Me.btnReadBacktest.Location = New System.Drawing.Point(198, 43)
        Me.btnReadBacktest.Name = "btnReadBacktest"
        Me.btnReadBacktest.Size = New System.Drawing.Size(85, 23)
        Me.btnReadBacktest.TabIndex = 54
        Me.btnReadBacktest.Text = "Run Backtest"
        Me.btnReadBacktest.UseVisualStyleBackColor = True
        '
        'lblRecordsProcessed
        '
        Me.lblRecordsProcessed.AutoSize = True
        Me.lblRecordsProcessed.Location = New System.Drawing.Point(13, 116)
        Me.lblRecordsProcessed.Name = "lblRecordsProcessed"
        Me.lblRecordsProcessed.Size = New System.Drawing.Size(0, 13)
        Me.lblRecordsProcessed.TabIndex = 55
        '
        'lstOHLC
        '
        Me.lstOHLC.FormattingEnabled = True
        Me.lstOHLC.Location = New System.Drawing.Point(12, 75)
        Me.lstOHLC.Name = "lstOHLC"
        Me.lstOHLC.Size = New System.Drawing.Size(310, 95)
        Me.lstOHLC.TabIndex = 56
        '
        'txtClientId
        '
        Me.txtClientId.Location = New System.Drawing.Point(674, 44)
        Me.txtClientId.Name = "txtClientId"
        Me.txtClientId.Size = New System.Drawing.Size(38, 20)
        Me.txtClientId.TabIndex = 60
        Me.txtClientId.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(624, 50)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 13)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Client Id"
        '
        'btnGetPrice
        '
        Me.btnGetPrice.Location = New System.Drawing.Point(802, 135)
        Me.btnGetPrice.Name = "btnGetPrice"
        Me.btnGetPrice.Size = New System.Drawing.Size(81, 23)
        Me.btnGetPrice.TabIndex = 61
        Me.btnGetPrice.Text = "Get Price"
        Me.btnGetPrice.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(674, 145)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 13)
        Me.Label19.TabIndex = 63
        Me.Label19.Text = "Symbol:"
        '
        'txtGetPriceSymbol
        '
        Me.txtGetPriceSymbol.Location = New System.Drawing.Point(724, 138)
        Me.txtGetPriceSymbol.Name = "txtGetPriceSymbol"
        Me.txtGetPriceSymbol.Size = New System.Drawing.Size(59, 20)
        Me.txtGetPriceSymbol.TabIndex = 62
        Me.txtGetPriceSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbWillie
        '
        Me.cmbWillie.FormattingEnabled = True
        Me.cmbWillie.Location = New System.Drawing.Point(464, 77)
        Me.cmbWillie.Name = "cmbWillie"
        Me.cmbWillie.Size = New System.Drawing.Size(175, 21)
        Me.cmbWillie.TabIndex = 64
        '
        'btnckprice
        '
        Me.btnckprice.Location = New System.Drawing.Point(802, 164)
        Me.btnckprice.Name = "btnckprice"
        Me.btnckprice.Size = New System.Drawing.Size(81, 23)
        Me.btnckprice.TabIndex = 67
        Me.btnckprice.Text = "ck price"
        Me.btnckprice.UseVisualStyleBackColor = True
        '
        'bntlistclear
        '
        Me.bntlistclear.Location = New System.Drawing.Point(718, 484)
        Me.bntlistclear.Name = "bntlistclear"
        Me.bntlistclear.Size = New System.Drawing.Size(81, 23)
        Me.bntlistclear.TabIndex = 68
        Me.bntlistclear.Text = "Clear "
        Me.bntlistclear.UseVisualStyleBackColor = True
        '
        'Timer60Sec
        '
        Me.Timer60Sec.Interval = 60000
        '
        'TimerAtTime
        '
        Me.TimerAtTime.Interval = 30000
        '
        'ckRobotOn
        '
        Me.ckRobotOn.AutoSize = True
        Me.ckRobotOn.Location = New System.Drawing.Point(658, 82)
        Me.ckRobotOn.Name = "ckRobotOn"
        Me.ckRobotOn.Size = New System.Drawing.Size(78, 17)
        Me.ckRobotOn.TabIndex = 69
        Me.ckRobotOn.Text = "Run Robot"
        Me.ckRobotOn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(430, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(178, 24)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Willie Harvest Robot"
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(12, 452)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(81, 23)
        Me.btnTest.TabIndex = 71
        Me.btnTest.Text = "Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'btnClearList
        '
        Me.btnClearList.Location = New System.Drawing.Point(241, 172)
        Me.btnClearList.Name = "btnClearList"
        Me.btnClearList.Size = New System.Drawing.Size(81, 23)
        Me.btnClearList.TabIndex = 57
        Me.btnClearList.Text = "Clear "
        Me.btnClearList.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(744, 309)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 84
        Me.Label17.Text = "Quantity"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(746, 324)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(41, 20)
        Me.TextBox1.TabIndex = 83
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(680, 309)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 82
        Me.Label20.Text = "Price"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(682, 324)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(41, 20)
        Me.TextBox2.TabIndex = 81
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(622, 309)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 13)
        Me.Label21.TabIndex = 80
        Me.Label21.Text = "Type"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(626, 324)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(41, 20)
        Me.TextBox3.TabIndex = 79
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(558, 309)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(37, 13)
        Me.Label22.TabIndex = 78
        Me.Label22.Text = "Action"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(562, 324)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(41, 20)
        Me.TextBox4.TabIndex = 77
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(498, 309)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(41, 13)
        Me.Label23.TabIndex = 76
        Me.Label23.Text = "Symbol"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(500, 324)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(41, 20)
        Me.TextBox5.TabIndex = 75
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(440, 309)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(44, 13)
        Me.Label24.TabIndex = 74
        Me.Label24.Text = "OrderID"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(442, 324)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(41, 20)
        Me.TextBox6.TabIndex = 73
        Me.TextBox6.Text = "0"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSendOption
        '
        Me.btnSendOption.Location = New System.Drawing.Point(802, 321)
        Me.btnSendOption.Name = "btnSendOption"
        Me.btnSendOption.Size = New System.Drawing.Size(81, 23)
        Me.btnSendOption.TabIndex = 72
        Me.btnSendOption.Text = "Option Order"
        Me.btnSendOption.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 526)
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
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ckRobotOn)
        Me.Controls.Add(Me.bntlistclear)
        Me.Controls.Add(Me.btnckprice)
        Me.Controls.Add(Me.cmbWillie)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtGetPriceSymbol)
        Me.Controls.Add(Me.btnGetPrice)
        Me.Controls.Add(Me.txtClientId)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.btnClearList)
        Me.Controls.Add(Me.lstOHLC)
        Me.Controls.Add(Me.lblRecordsProcessed)
        Me.Controls.Add(Me.btnReadBacktest)
        Me.Controls.Add(Me.lblBacktestStatus)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnWillie)
        Me.Controls.Add(Me.lstServerResponses)
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
        Me.Controls.Add(Me.cmbIndexes)
        Me.Controls.Add(Me.lbldatastring)
        Me.Controls.Add(Me.btnSendOrder)
        Me.Controls.Add(Me.btnReqNextValidId)
        Me.Controls.Add(Me.lblConStatus)
        Me.Controls.Add(Me.btnDisconnect)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Main"
        Me.Text = "Main"
        CType(Me.HarvestIndexBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptionwavesdbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptionwavesdbDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtHost As TextBox
    Friend WithEvents txtPort As TextBox
    Friend WithEvents label2 As Label
    Friend WithEvents btnConnect As Button
    Friend WithEvents btnDisconnect As Button
    Friend WithEvents lblConStatus As Label
    Friend WithEvents btnReqNextValidId As Button
    Friend WithEvents OptionwavesdbDataSet As optionwavesdbDataSet
    Friend WithEvents HarvestIndexBindingSource As BindingSource
    Friend WithEvents HarvestIndexTableAdapter As optionwavesdbDataSetTableAdapters.HarvestIndexTableAdapter
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents btnSendOrder As Button
    Friend WithEvents lbldatastring As Label
    Friend WithEvents cmbIndexes As ComboBox
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
    Friend WithEvents Label16 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnOpenFile As Button
    Friend WithEvents lblBacktestStatus As Label
    Friend WithEvents btnReadBacktest As Button
    Friend WithEvents lblRecordsProcessed As Label
    Friend WithEvents lstOHLC As ListBox
    Friend WithEvents txtClientId As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents btnGetPrice As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents txtGetPriceSymbol As TextBox
    Friend WithEvents cmbWillie As ComboBox
    Friend WithEvents btnckprice As Button
    Friend WithEvents bntlistclear As Button
    Friend WithEvents Timer60Sec As Timer
    Friend WithEvents TimerAtTime As Timer
    Friend WithEvents ckRobotOn As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnTest As Button
    Friend WithEvents btnClearList As Button
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
End Class
