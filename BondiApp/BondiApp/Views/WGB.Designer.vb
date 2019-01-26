<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WGB
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.txtHarvestingIP = New System.Windows.Forms.TextBox()
        Me.txtHarvestingClientId = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.txtHarvestingPort = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.lstErrorResponses = New System.Windows.Forms.ListBox()
        Me.lstServerResponses = New System.Windows.Forms.ListBox()
        Me.btnGetStockPrice = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnGetOptionPrice = New System.Windows.Forms.Button()
        Me.btnStartWillie = New System.Windows.Forms.Button()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.lblLastPrice = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBTOMovePrice = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTickSymbol = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblOpenOrder = New System.Windows.Forms.Label()
        Me.btnSendStockOrder = New System.Windows.Forms.Button()
        Me.btnSendOptionOrder = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblBid = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblAsk = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblOpen = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblhigh = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbllow = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.txtTestPrice = New System.Windows.Forms.TextBox()
        Me.ckTest = New System.Windows.Forms.CheckBox()
        Me.lstConnectionResponses = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(537, 402)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(292, 24)
        Me.Label3.TabIndex = 240
        Me.Label3.Text = "Resignation Trading - Willie Gene"
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(506, 9)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(108, 27)
        Me.btnDisconnect.TabIndex = 301
        Me.btnDisconnect.Text = "Disconnect TWS"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(392, 9)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(108, 27)
        Me.btnConnect.TabIndex = 300
        Me.btnConnect.Text = "Connect TWS"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'txtHarvestingIP
        '
        Me.txtHarvestingIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHarvestingIP.Location = New System.Drawing.Point(59, 528)
        Me.txtHarvestingIP.Name = "txtHarvestingIP"
        Me.txtHarvestingIP.Size = New System.Drawing.Size(90, 26)
        Me.txtHarvestingIP.TabIndex = 299
        Me.txtHarvestingIP.Text = "127.0.0.1"
        Me.txtHarvestingIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHarvestingIP.Visible = False
        '
        'txtHarvestingClientId
        '
        Me.txtHarvestingClientId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHarvestingClientId.Location = New System.Drawing.Point(334, 525)
        Me.txtHarvestingClientId.Name = "txtHarvestingClientId"
        Me.txtHarvestingClientId.Size = New System.Drawing.Size(32, 26)
        Me.txtHarvestingClientId.TabIndex = 294
        Me.txtHarvestingClientId.Text = "0"
        Me.txtHarvestingClientId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHarvestingClientId.Visible = False
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.Location = New System.Drawing.Point(257, 529)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(71, 20)
        Me.Label75.TabIndex = 295
        Me.Label75.Text = "Client Id:"
        Me.Label75.Visible = False
        '
        'txtHarvestingPort
        '
        Me.txtHarvestingPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHarvestingPort.Location = New System.Drawing.Point(203, 528)
        Me.txtHarvestingPort.Name = "txtHarvestingPort"
        Me.txtHarvestingPort.Size = New System.Drawing.Size(43, 26)
        Me.txtHarvestingPort.TabIndex = 296
        Me.txtHarvestingPort.Text = "7497"
        Me.txtHarvestingPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHarvestingPort.Visible = False
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.Location = New System.Drawing.Point(159, 529)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(42, 20)
        Me.Label76.TabIndex = 297
        Me.Label76.Text = "Port:"
        Me.Label76.Visible = False
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.Location = New System.Drawing.Point(11, 529)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(47, 20)
        Me.Label77.TabIndex = 298
        Me.Label77.Text = "Host:"
        Me.Label77.Visible = False
        '
        'lstErrorResponses
        '
        Me.lstErrorResponses.FormattingEnabled = True
        Me.lstErrorResponses.Location = New System.Drawing.Point(162, 347)
        Me.lstErrorResponses.Margin = New System.Windows.Forms.Padding(2)
        Me.lstErrorResponses.Name = "lstErrorResponses"
        Me.lstErrorResponses.Size = New System.Drawing.Size(452, 43)
        Me.lstErrorResponses.TabIndex = 303
        '
        'lstServerResponses
        '
        Me.lstServerResponses.FormattingEnabled = True
        Me.lstServerResponses.Location = New System.Drawing.Point(162, 144)
        Me.lstServerResponses.Margin = New System.Windows.Forms.Padding(2)
        Me.lstServerResponses.Name = "lstServerResponses"
        Me.lstServerResponses.Size = New System.Drawing.Size(452, 199)
        Me.lstServerResponses.TabIndex = 302
        '
        'btnGetStockPrice
        '
        Me.btnGetStockPrice.BackColor = System.Drawing.Color.Ivory
        Me.btnGetStockPrice.Location = New System.Drawing.Point(10, 264)
        Me.btnGetStockPrice.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetStockPrice.Name = "btnGetStockPrice"
        Me.btnGetStockPrice.Size = New System.Drawing.Size(106, 27)
        Me.btnGetStockPrice.TabIndex = 304
        Me.btnGetStockPrice.Text = "Get Stock Price"
        Me.btnGetStockPrice.UseVisualStyleBackColor = False
        Me.btnGetStockPrice.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(443, 402)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(89, 23)
        Me.btnClear.TabIndex = 305
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnGetOptionPrice
        '
        Me.btnGetOptionPrice.BackColor = System.Drawing.Color.Ivory
        Me.btnGetOptionPrice.Location = New System.Drawing.Point(340, 474)
        Me.btnGetOptionPrice.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetOptionPrice.Name = "btnGetOptionPrice"
        Me.btnGetOptionPrice.Size = New System.Drawing.Size(106, 27)
        Me.btnGetOptionPrice.TabIndex = 306
        Me.btnGetOptionPrice.Text = "Get Option Price"
        Me.btnGetOptionPrice.UseVisualStyleBackColor = False
        '
        'btnStartWillie
        '
        Me.btnStartWillie.Location = New System.Drawing.Point(506, 48)
        Me.btnStartWillie.Name = "btnStartWillie"
        Me.btnStartWillie.Size = New System.Drawing.Size(108, 27)
        Me.btnStartWillie.TabIndex = 309
        Me.btnStartWillie.Text = "START WILLIE"
        Me.btnStartWillie.UseVisualStyleBackColor = True
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Location = New System.Drawing.Point(12, 407)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(165, 13)
        Me.lblWelcome.TabIndex = 311
        Me.lblWelcome.Text = "Welcome to Resignation Trading!"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label47.Location = New System.Drawing.Point(492, 85)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(44, 20)
        Me.Label47.TabIndex = 313
        Me.Label47.Text = "Last:"
        '
        'lblLastPrice
        '
        Me.lblLastPrice.AutoSize = True
        Me.lblLastPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblLastPrice.Location = New System.Drawing.Point(545, 85)
        Me.lblLastPrice.Name = "lblLastPrice"
        Me.lblLastPrice.Size = New System.Drawing.Size(49, 20)
        Me.lblLastPrice.TabIndex = 312
        Me.lblLastPrice.Text = "$0.00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(494, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 20)
        Me.Label2.TabIndex = 317
        Me.Label2.Text = "Trail:"
        '
        'lblBTOMovePrice
        '
        Me.lblBTOMovePrice.AutoSize = True
        Me.lblBTOMovePrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBTOMovePrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblBTOMovePrice.Location = New System.Drawing.Point(547, 115)
        Me.lblBTOMovePrice.Name = "lblBTOMovePrice"
        Me.lblBTOMovePrice.Size = New System.Drawing.Size(49, 20)
        Me.lblBTOMovePrice.TabIndex = 316
        Me.lblBTOMovePrice.Text = "$0.00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(14, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 20)
        Me.Label4.TabIndex = 319
        Me.Label4.Text = "Stock:"
        '
        'lblTickSymbol
        '
        Me.lblTickSymbol.AutoSize = True
        Me.lblTickSymbol.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTickSymbol.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTickSymbol.Location = New System.Drawing.Point(76, 50)
        Me.lblTickSymbol.Name = "lblTickSymbol"
        Me.lblTickSymbol.Size = New System.Drawing.Size(41, 20)
        Me.lblTickSymbol.TabIndex = 318
        Me.lblTickSymbol.Text = "XYZ"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(7, 372)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 17)
        Me.Label6.TabIndex = 324
        Me.Label6.Text = "Open Order?"
        '
        'lblOpenOrder
        '
        Me.lblOpenOrder.AutoSize = True
        Me.lblOpenOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpenOrder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblOpenOrder.Location = New System.Drawing.Point(103, 372)
        Me.lblOpenOrder.Name = "lblOpenOrder"
        Me.lblOpenOrder.Size = New System.Drawing.Size(29, 17)
        Me.lblOpenOrder.TabIndex = 323
        Me.lblOpenOrder.Text = "NO"
        '
        'btnSendStockOrder
        '
        Me.btnSendStockOrder.BackColor = System.Drawing.Color.Ivory
        Me.btnSendStockOrder.Location = New System.Drawing.Point(230, 474)
        Me.btnSendStockOrder.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSendStockOrder.Name = "btnSendStockOrder"
        Me.btnSendStockOrder.Size = New System.Drawing.Size(106, 27)
        Me.btnSendStockOrder.TabIndex = 325
        Me.btnSendStockOrder.Text = "Send Stock Order"
        Me.btnSendStockOrder.UseVisualStyleBackColor = False
        '
        'btnSendOptionOrder
        '
        Me.btnSendOptionOrder.BackColor = System.Drawing.Color.Ivory
        Me.btnSendOptionOrder.Location = New System.Drawing.Point(450, 474)
        Me.btnSendOptionOrder.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSendOptionOrder.Name = "btnSendOptionOrder"
        Me.btnSendOptionOrder.Size = New System.Drawing.Size(106, 27)
        Me.btnSendOptionOrder.TabIndex = 326
        Me.btnSendOptionOrder.Text = "Send Option Order"
        Me.btnSendOptionOrder.UseVisualStyleBackColor = False
        '
        'btnTest
        '
        Me.btnTest.BackColor = System.Drawing.Color.Ivory
        Me.btnTest.Location = New System.Drawing.Point(10, 474)
        Me.btnTest.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(106, 27)
        Me.btnTest.TabIndex = 327
        Me.btnTest.Text = "calc willie price"
        Me.btnTest.UseVisualStyleBackColor = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(189, 407)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 328
        Me.lblStatus.Text = "Status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(32, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 20)
        Me.Label5.TabIndex = 330
        Me.Label5.Text = "Bid:"
        '
        'lblBid
        '
        Me.lblBid.AutoSize = True
        Me.lblBid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblBid.Location = New System.Drawing.Point(77, 115)
        Me.lblBid.Name = "lblBid"
        Me.lblBid.Size = New System.Drawing.Size(49, 20)
        Me.lblBid.TabIndex = 329
        Me.lblBid.Text = "$0.00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(145, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 20)
        Me.Label7.TabIndex = 332
        Me.Label7.Text = "Ask:"
        '
        'lblAsk
        '
        Me.lblAsk.AutoSize = True
        Me.lblAsk.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAsk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblAsk.Location = New System.Drawing.Point(194, 115)
        Me.lblAsk.Name = "lblAsk"
        Me.lblAsk.Size = New System.Drawing.Size(49, 20)
        Me.lblAsk.TabIndex = 331
        Me.lblAsk.Text = "$0.00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(16, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 20)
        Me.Label8.TabIndex = 334
        Me.Label8.Text = "Open:"
        '
        'lblOpen
        '
        Me.lblOpen.AutoSize = True
        Me.lblOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblOpen.Location = New System.Drawing.Point(77, 85)
        Me.lblOpen.Name = "lblOpen"
        Me.lblOpen.Size = New System.Drawing.Size(49, 20)
        Me.lblOpen.TabIndex = 333
        Me.lblOpen.Text = "$0.00"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(139, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 20)
        Me.Label9.TabIndex = 336
        Me.Label9.Text = "High:"
        '
        'lblhigh
        '
        Me.lblhigh.AutoSize = True
        Me.lblhigh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhigh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblhigh.Location = New System.Drawing.Point(194, 85)
        Me.lblhigh.Name = "lblhigh"
        Me.lblhigh.Size = New System.Drawing.Size(49, 20)
        Me.lblhigh.TabIndex = 335
        Me.lblhigh.Text = "$0.00"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(256, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 20)
        Me.Label10.TabIndex = 338
        Me.Label10.Text = "Low:"
        '
        'lbllow
        '
        Me.lbllow.AutoSize = True
        Me.lbllow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllow.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbllow.Location = New System.Drawing.Point(307, 85)
        Me.lbllow.Name = "lbllow"
        Me.lbllow.Size = New System.Drawing.Size(49, 20)
        Me.lbllow.TabIndex = 337
        Me.lbllow.Text = "$0.00"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(369, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 20)
        Me.Label11.TabIndex = 340
        Me.Label11.Text = "Close:"
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblClose.Location = New System.Drawing.Point(430, 85)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(49, 20)
        Me.lblClose.TabIndex = 339
        Me.lblClose.Text = "$0.00"
        '
        'txtTestPrice
        '
        Me.txtTestPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTestPrice.Location = New System.Drawing.Point(10, 326)
        Me.txtTestPrice.Name = "txtTestPrice"
        Me.txtTestPrice.Size = New System.Drawing.Size(98, 24)
        Me.txtTestPrice.TabIndex = 341
        Me.txtTestPrice.Text = "0"
        Me.txtTestPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTestPrice.Visible = False
        '
        'ckTest
        '
        Me.ckTest.AutoSize = True
        Me.ckTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckTest.Location = New System.Drawing.Point(10, 296)
        Me.ckTest.Name = "ckTest"
        Me.ckTest.Size = New System.Drawing.Size(98, 24)
        Me.ckTest.TabIndex = 342
        Me.ckTest.Text = "Test Price"
        Me.ckTest.UseVisualStyleBackColor = True
        Me.ckTest.Visible = False
        '
        'lstConnectionResponses
        '
        Me.lstConnectionResponses.BackColor = System.Drawing.SystemColors.Control
        Me.lstConnectionResponses.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstConnectionResponses.FormattingEnabled = True
        Me.lstConnectionResponses.Location = New System.Drawing.Point(15, 434)
        Me.lstConnectionResponses.Margin = New System.Windows.Forms.Padding(2)
        Me.lstConnectionResponses.Name = "lstConnectionResponses"
        Me.lstConnectionResponses.Size = New System.Drawing.Size(597, 26)
        Me.lstConnectionResponses.TabIndex = 343
        '
        'WGB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(638, 466)
        Me.Controls.Add(Me.lstConnectionResponses)
        Me.Controls.Add(Me.ckTest)
        Me.Controls.Add(Me.txtTestPrice)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblClose)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lbllow)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblhigh)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblOpen)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblAsk)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblBid)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.btnSendOptionOrder)
        Me.Controls.Add(Me.btnSendStockOrder)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblOpenOrder)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblTickSymbol)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblBTOMovePrice)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.lblLastPrice)
        Me.Controls.Add(Me.lblWelcome)
        Me.Controls.Add(Me.btnStartWillie)
        Me.Controls.Add(Me.btnGetOptionPrice)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnGetStockPrice)
        Me.Controls.Add(Me.lstErrorResponses)
        Me.Controls.Add(Me.lstServerResponses)
        Me.Controls.Add(Me.btnDisconnect)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.txtHarvestingIP)
        Me.Controls.Add(Me.txtHarvestingClientId)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.txtHarvestingPort)
        Me.Controls.Add(Me.Label76)
        Me.Controls.Add(Me.Label77)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(660, 505)
        Me.Name = "WGB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Willie - Automated Trading System"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnDisconnect As Button
    Friend WithEvents btnConnect As Button
    Friend WithEvents txtHarvestingIP As TextBox
    Friend WithEvents txtHarvestingClientId As TextBox
    Friend WithEvents Label75 As Label
    Friend WithEvents txtHarvestingPort As TextBox
    Friend WithEvents Label76 As Label
    Friend WithEvents Label77 As Label
    Friend WithEvents lstErrorResponses As ListBox
    Friend WithEvents lstServerResponses As ListBox
    Friend WithEvents btnGetStockPrice As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnGetOptionPrice As Button
    Friend WithEvents btnStartWillie As Button
    Friend WithEvents lblWelcome As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents lblLastPrice As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblBTOMovePrice As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTickSymbol As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblOpenOrder As Label
    Friend WithEvents btnSendStockOrder As Button
    Friend WithEvents btnSendOptionOrder As Button
    Friend WithEvents btnTest As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblBid As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblAsk As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblOpen As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblhigh As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lbllow As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblClose As Label
    Friend WithEvents txtTestPrice As TextBox
    Friend WithEvents ckTest As CheckBox
    Friend WithEvents lstConnectionResponses As ListBox
End Class
