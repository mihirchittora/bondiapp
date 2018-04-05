'Option Strict Off
'Option Explicit On
Imports System.Threading
Imports System.Xml
Imports System.Collections.Generic
Imports System.Data
Imports System.Configuration
Imports System.IO
Imports System.Data.SqlClient
Imports IBApi
Imports BondiApp.Tws


Friend Class Main
    Inherits System.Windows.Forms.Form

    'Private WithEvents tws As New Tws                                                                                                          ' COMMENTED OUT WAS NOT WORKING

    Dim indexselected As String = ""
    Private m_utils As New Utils                                                                                                                ' CREATES A NEW INSTANCE OF UTILS TO BE USED IN THIS FORM 
    Private m_dlgAcctData As New dlgAcctData
    Private m_dlgConnect As New dlgConnect
    Private m_dlgHarvest As New dlgHarvest
    Private m_faAcctsList As String
    Private m_faAccount, faError As Boolean                                                                                                     ' VARIABLE TO HOLD FINACIAL ADVISOR STATUS SETTINGS
    Public backprices As List(Of backPrice)                                                                                                     ' CLASS DEFINITION TO HOUSE                         
    Public orderdetails As List(Of OrderDetail)
    Public fileNameRead As String
    Public currentorderid As Integer = 0                                                                                                        ' PUBLIC VARIABLE TO HOLD CURRENTORDERID - TO BE USED TO SET THE NEXTVALIDID FOR ORDERS
    Public PriceTest As Double = 0
    Public cntr As Integer = 1

    Public Sub New()
        MyBase.New()

        Tws1 = New Tws(Me)
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call m_utils.init(Me, Nothing, Nothing)                                                                                                 ' INITIALIZES THE UTILS TO SEND AND READ MESSAGES FROM THE API
        Call m_dlgAcctData.init(m_utils)                                                                                                        ' INITIALIZES THE ACCOUNT DATA DIALOGUE TO PROCESS ACCOUNT LEVEL MESSAGES

        'TODO: This line of code loads data into the 'OptionwavesdbDataSet.HarvestIndex' table. You can move, or remove it, as needed.

        Using _entity As BondiModel = New BondiModel()
            Dim _lstHarvestindex As List(Of HarvestIndex) = New List(Of HarvestIndex)()
            _lstHarvestindex = _entity.HarvestIndexes.AsEnumerable.[Select](Function(x) New HarvestIndex With {.harvestKey = x.harvestKey, .name = x.name}).ToList()
            cmbIndexes.DataSource = _lstHarvestindex
            cmbIndexes.DisplayMember = "name"
            cmbIndexes.ValueMember = "harvestKey"
            cmbIndexes.SelectedIndex = 0

            cmbWillie.DataSource = _lstHarvestindex
            cmbWillie.DisplayMember = "name"
            cmbWillie.ValueMember = "harvestkey"
            cmbWillie.SelectedIndex = 0

        End Using


    End Sub

    Private Sub btnConnect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnConnect.Click
        Dim connected As String = ""                                                                                                ' VARIABLE HOLDING THE CONNECTED STATUS STRING
        m_faAccount = False                                                                                                         ' THIS IS NOT A FINANCIAL ADVISORS ACCOUNT
        Dim msg As String

        ' The connection settings will be established in the USER SETTINGS and populated based on the login process.
        ' The only setting that the user will be able to change here is the client id in the event they are running two instances of the app.  Need to make sure I want that to be able to happen.

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "Connecting to TWS using clientId " & txtClientId.Text & "...")                   ' ADD DESCRIPTION TO THE LIST BOX TO INDICATE STATUS

        Tws1.connect(txtHost.Text, txtPort.Text, txtClientId.Text, False, "")

        If (Tws1.serverVersion() > 0) Then

            msg = "Connected to Tws server version " & Tws1.serverVersion() &
                                  " at " & Tws1.TwsConnectionTime()
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, msg)
        End If

        ' Determine what the next order id should be.

        lblConStatus.Text = " " & connected & " at " & Tws1.TwsConnectionTime

    End Sub




    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click
        Dim connected As String = ""

        Tws1.disconnect()

        If (Tws1.serverVersion() > 0) Then
            connected = "On Line"
        Else
            connected = "Off Line"
        End If

        lblConStatus.Text = " " & connected

    End Sub

    Private Sub btnReqNextValidId_Click(sender As Object, e As EventArgs) Handles btnReqNextValidId.Click

        MsgBox(currentorderid)

        'If (Tws1.serverVersion() > 1) Then
        '    Call Tws1.reqIds(1)

        'Else
        'End If

    End Sub


    Private Sub btnSendOrder_Click(sender As Object, e As EventArgs) Handles btnSendOrder.Click

        Dim datastring As String = ""                                                                                                         ' SETS THE INITIAL DATASTRING VALUE - REWRITTEN WHEN THE CODE EXECUTES

        Dim contract As IBApi.Contract = New IBApi.Contract()
        contract.Symbol = txtSymbol.Text
        contract.SecType = "STK"
        contract.Currency = "USD"
        contract.Exchange = "SMART"
        Dim order As IBApi.Order = New IBApi.Order()

        order.OrderId = txtOrderId.Text

        order.Action = txtAction.Text.ToUpper()
        order.OrderType = txtType.Text.ToUpper()
        order.LmtPrice = txtPrice.Text
        order.TotalQuantity = txtQty.Text

        Call Tws1.placeOrderEx(order.OrderId, contract, order)


        datastring = DateTime.Parse(Now()).ToShortTimeString() & " Order Id:" & order.OrderId & " Symbol: " & contract.Symbol & " Total Shares: " & order.TotalQuantity & " Price: " & order.LmtPrice '& " Order Status:" & Tws1.Status

        'Tws1.disconnect()
        lbldatastring.Text = datastring

    End Sub

    ' Use this one to test db connections and get data
    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        Using _entity As BondiModel = New BondiModel()
            Dim _lstHarvestindex As List(Of HarvestIndex) = New List(Of HarvestIndex)()
            _lstHarvestindex = _entity.HarvestIndexes.AsEnumerable.[Select](Function(x) New HarvestIndex).Where(Function(s) s.harvestKey = cmbIndexes.SelectedValue).ToList()
            cmbIndexes.DataSource = _lstHarvestindex
            cmbIndexes.DisplayMember = "name"
            cmbIndexes.ValueMember = "harvestKey"
        End Using



    End Sub









    Private Sub cmbIndexes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIndexes.SelectedIndexChanged
        indexselected = cmbIndexes.SelectedValue.ToString()




    End Sub

    Private Sub btnModOrder_Click(sender As Object, e As EventArgs) Handles btnModOrder.Click
        Dim datastring As String = ""                                                                                                         ' SETS THE INITIAL DATASTRING VALUE - REWRITTEN WHEN THE CODE EXECUTES

        Dim contract As IBApi.Contract = New IBApi.Contract()
        contract.Symbol = txtModifySymbol.Text
        contract.SecType = "STK"
        contract.Currency = "USD"
        contract.Exchange = "SMART"
        Dim order As IBApi.Order = New IBApi.Order()

        order.OrderId = txtModifyOrderId.Text

        order.Action = txtModifyAction.Text.ToUpper()
        order.OrderType = txtModifyType.Text.ToUpper()
        order.LmtPrice = txtModifyPrice.Text
        order.TotalQuantity = txtModifyQty.Text

        Call Tws1.placeOrderEx(order.OrderId, contract, order)


        datastring = "Order Modified: " & DateTime.Parse(Now()).ToShortTimeString() & " Order Id:" & order.OrderId & " Symbol: " & contract.Symbol & " Total Shares: " & order.TotalQuantity & " Price: " & order.LmtPrice '& " Order Status:" & Tws1.Status

        'Tws1.disconnect()
        lbldatastring.Text = datastring
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    ' BACKTEST SUBPROCESSES HERE
    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click

        Dim csvdata As String = ""                                                                                                                                                      ' STRING TO HOLD THE DATA FROM EACH CSV FILE READ INTO MEMORY
        Dim filedate As String = "20160104"                                                                                                                                             ' STRING TO HOLD THE FILE DATE FOR THE CSV FILE TO BE READ THIS WILL INCREMENT FROM DB
        Dim symbol As String = "vxx"                                                                                                                                                    ' STRING TO HOLD THE SYMBOL OF THE PRODUCT BEING TESTED

        Dim path As String = "C:\Users\Troy Belden\Desktop\stockprices\allstocks_"                                                                                                      ' GENERIC PATH FOR READING THE CSV FILES - WILL NEED TO SET TO USER INPUT FOR PRODUCTION

        Try
            Using textReader As New System.IO.StreamReader(path & filedate & "\table_" & symbol & ".csv")                                                                               ' TEXT READER READS THE CSV FILE INTO MEMORY
                csvdata = textReader.ReadToEnd                                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING.
                backprices = ParseBackData(csvdata)                                                                                                                                     ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.                        
                lblBacktestRecRead.Text = lblBacktestRecRead.Text & " " & backprices.Count                                                                                              ' LABEL INDICATOR SHOWING THAT PROCESSING IS COMPLETE
            End Using
        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)                                                                                                ' IF THERE IS AN ERROR READING THE FILE DISPLAY THE ERROR MESSAGE
        Finally

        End Try

    End Sub


    Private Sub btnReadBacktest_Click(sender As Object, e As EventArgs) Handles btnReadBacktest.Click
        Dim csvdata As String = ""                                                                                                                                                      ' STRING TO HOLD THE DATA FROM EACH CSV FILE READ INTO MEMORY
        Dim filedate As String = "20160104"                                                                                                                                             ' STRING TO HOLD THE FILE DATE FOR THE CSV FILE TO BE READ THIS WILL INCREMENT FROM DB
        Dim symbol As String = ""                                                                                                                                                       ' STRING TO HOLD THE SYMBOL OF THE PRODUCT BEING TESTED
        Dim priceint As Integer = 0
        Dim currentprice As Double = 0
        Dim checksum As Double = 0
        Dim opentrigger As Double = 0

        Using _entity As BondiModel = New BondiModel()
            Dim _lstHarvestindex As List(Of HarvestIndex) = New List(Of HarvestIndex)()
            _lstHarvestindex = _entity.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbIndexes.SelectedValue).ToList()
            symbol = _lstHarvestindex.FirstOrDefault().product
            opentrigger = _lstHarvestindex.FirstOrDefault().opentrigger
        End Using
        Dim path As String = "C:\Users\Troy Belden\Desktop\stockprices\allstocks_"                                                                                                      ' GENERIC PATH FOR READING THE CSV FILES - WILL NEED TO SET TO USER INPUT FOR PRODUCTION

        Try
            Using textReader As New System.IO.StreamReader(path & filedate & "\table_" & symbol & ".csv")                                                                               ' TEXT READER READS THE CSV FILE INTO MEMORY
                csvdata = textReader.ReadToEnd                                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING.
                backprices = ParseBackData(csvdata)                                                                                                                                     ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.                        
                'Stop

                lstOHLC.Items.Add("Interval" & vbTab & "Time" & vbTab & "Open" & vbTab & "High" & vbTab & "Low" & vbTab & "Close")
                For Each price As backPrice In backprices

                    If price.interval = 0 Then

                        priceint = Int(price.OpenPrice)                                                                                                                                 ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
                        checksum = price.OpenPrice - priceint                                                                                                                           ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
                        currentprice = (Int(checksum / opentrigger) * opentrigger + priceint)                                                                                         ' CALCULATE THE NEAREST MARK PRICE TO SET THE LIMIT ORDER AGAINST                    

                        MsgBox(String.Format("{0:C}", currentprice))

                    End If

                    lstOHLC.Items.Add(price.interval & vbTab & price.MarketTime & vbTab & (String.Format("{0:C}", price.OpenPrice)) &
                                      vbTab & (String.Format("{0:C}", price.HighPrice)) & vbTab & (String.Format("{0:C}", price.LowPrice)) &
                                      vbTab & (String.Format("{0:C}", price.ClosePrice)))

                Next

                lblRecordsProcessed.Text = "Records Processed: " & backprices.Count                                                                                            ' LABEL INDICATOR SHOWING THAT PROCESSING IS COMPLETE
            End Using
        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)                                                                                                ' IF THERE IS AN ERROR READING THE FILE DISPLAY THE ERROR MESSAGE
        Finally

        End Try
    End Sub

    Private Sub btnClearList_Click(sender As Object, e As EventArgs) Handles btnClearList.Click
        lstOHLC.Items.Clear()
        lblRecordsProcessed.Text = ""
    End Sub

    ' FORWARD TEST SUBPROCESSES HERE - USING TWS

    'Private Sub Tws1_managedAccounts(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_managedAccountsEvent) Handles Tws1.OnmanagedAccounts
    '    Dim msg As String

    '    msg = "Connected : The list of managed accounts are : [" & eventArgs.accountsList & "]"
    '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, msg)

    '    m_faAccount = True
    '    m_faAcctsList = eventArgs.accountsList

    'End Sub

    Private Sub btnCancelOrder_Click(sender As Object, e As EventArgs) Handles btnCancelOrder.Click
        Call Tws1.cancelOrder(txtCancelId.Text)
    End Sub



    ' ROBOT CODE USED IN APPLICATION

    Private Sub btnWillie_Click(sender As Object, e As EventArgs) Handles btnWillie.Click
        Dim priceint As Double = 0
        Dim Symbol As String = ""
        Dim opentrigger As Double = 0
        Dim contract As IBApi.Contract = New IBApi.Contract()
        Dim order As IBApi.Order = New IBApi.Order()
        cntr = 1
        Using _entity As BondiModel = New BondiModel()
            Dim _lstHarvestindex As List(Of HarvestIndex) = New List(Of HarvestIndex)()
            _lstHarvestindex = _entity.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbIndexes.SelectedValue).ToList()
            contract.Symbol = _lstHarvestindex.FirstOrDefault().product.ToUpper()
            contract.SecType = _lstHarvestindex.FirstOrDefault().stocksectype.ToUpper()
            contract.Currency = _lstHarvestindex.FirstOrDefault().currencytype.ToUpper()
            contract.Exchange = _lstHarvestindex.FirstOrDefault().exchange.ToUpper()

            order.OrderType = _lstHarvestindex.FirstOrDefault().ordertype.ToUpper()
            order.TotalQuantity = _lstHarvestindex.FirstOrDefault().shares
            order.Tif = _lstHarvestindex.FirstOrDefault().inforce.ToUpper()

        End Using

        Dim datastring As String = ""                                                                                                         ' SETS THE INITIAL DATASTRING VALUE - REWRITTEN WHEN THE CODE EXECUTES

        order.OrderId = currentorderid
        order.Action = "BUY"
        order.LmtPrice = txtOpeningPrice.Text

        Call Tws1.placeOrderEx(order.OrderId, contract, order)


        ' CODE TO SAVE THIS FIRST ORDER TO THE DATABASE GOES HERE.



        datastring = DateTime.Parse(Now()).ToShortTimeString() & " Order Id:" & order.OrderId & " Symbol: " & contract.Symbol & " Total Shares: " & order.TotalQuantity & " Price: " & order.LmtPrice '& " Order Status:" & Tws1.Status

        lbldatastring.Text = datastring

    End Sub



    ' TWS FUNCTIONS USED IN APPLICATION HERE

    Private Sub Tws1_managedAccounts(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_managedAccountsEvent) Handles Tws1.OnmanagedAccounts
        Dim msg As String

        msg = "Connected : The list of managed accounts are : [" & eventArgs.accountsList & "]"
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, msg)

        m_faAccount = True
        m_faAcctsList = eventArgs.accountsList

    End Sub

    Private Function DblMaxStr(ByRef dblVal As Double) As String
        If dblVal = Double.MaxValue Then
            DblMaxStr = ""
        Else
            DblMaxStr = CStr(dblVal)
        End If
    End Function

    Private Function IntMaxStr(ByRef intVal As Integer) As String
        If intVal = Integer.MaxValue Then
            IntMaxStr = ""
        Else
            IntMaxStr = CStr(intVal)
        End If
    End Function

    Private Sub Tws1_contractDetailsEx(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_contractDetailsExEvent) Handles Tws1.OncontractDetailsEx

        Dim reqId As Long
        reqId = eventArgs.reqId

        Dim contractDetails As IBApi.ContractDetails
        contractDetails = eventArgs.contractDetails

        Dim contract As IBApi.Contract
        contract = contractDetails.Summary

        Dim offset As Long
        offset = lstServerResponses.Items.Count

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "reqId = " & reqId & " ===================================")

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ---- Contract Details Begin ----")
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "Contract:")
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  conId = " & contract.ConId)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  symbol = " & contract.Symbol)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  secType = " & contract.SecType)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  lastTradeDate = " & contract.LastTradeDateOrContractMonth)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  strike = " & contract.Strike)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  right = " & contract.Right)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  multiplier = " & contract.Multiplier)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  exchange = " & contract.Exchange)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  primaryExchange = " & contract.PrimaryExch)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  currency = " & contract.Currency)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  localSymbol = " & contract.LocalSymbol)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  tradingClass = " & contract.TradingClass)

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "Details:")
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  marketName = " & contractDetails.MarketName)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  minTick = " & contractDetails.MinTick)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  priceMagnifier = " & contractDetails.PriceMagnifier)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  orderTypes = " & contractDetails.OrderTypes)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  validExchanges = " & contractDetails.ValidExchanges)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  underConId = " & contractDetails.UnderConId)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  longName = " & contractDetails.LongName)

        If (contract.SecType <> "BOND") Then
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  contractMonth = " & contractDetails.ContractMonth)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  industry = " & contractDetails.Industry)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  category = " & contractDetails.Category)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  subcategory = " & contractDetails.Subcategory)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  timeZoneId = " & contractDetails.TimeZoneId)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  tradingHours = " & contractDetails.TradingHours)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  liquidHours = " & contractDetails.LiquidHours)
        End If
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  evRule = " & contractDetails.EvRule)
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  evMultiplier = " & contractDetails.EvMultiplier)

        If (contract.SecType = "BOND") Then

            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "Bond Details:")
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  cusip = " & contractDetails.Cusip)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  ratings = " & contractDetails.Ratings)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  descAppend = " & contractDetails.DescAppend)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  bondType = " & contractDetails.BondType)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  couponType = " & contractDetails.CouponType)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  callable = " & contractDetails.Callable)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  putable = " & contractDetails.Putable)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  coupon = " & contractDetails.Coupon)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  convertible = " & contractDetails.Convertible)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  maturity = " & contractDetails.Maturity)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  issueDate = " & contractDetails.IssueDate)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  nextOptionDate = " & contractDetails.NextOptionDate)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  nextOptionType = " & contractDetails.NextOptionType)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  nextOptionPartial = " & contractDetails.NextOptionPartial)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  notes = " & contractDetails.Notes)


        End If

        ' CUSIP/ISIN/etc.
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  secIdList={")
        Dim secIdList As List(Of IBApi.TagValue)
        secIdList = contractDetails.SecIdList
        If (Not secIdList Is Nothing) Then
            Dim secIdListCount As Long
            secIdListCount = secIdList.Count
            Dim iLoop As Long
            For iLoop = 0 To secIdListCount - 1
                Dim param As IBApi.TagValue
                param = secIdList.Item(iLoop)
                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "    " & param.Tag & "=" & param.Value)
            Next iLoop
        End If
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  }")

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ---- Contract Details End ----")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    Private Sub Tws1_contractDetailsEnd(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_contractDetailsEndEvent) Handles Tws1.OncontractDetailsEnd

        Dim reqId As Long
        reqId = eventArgs.reqId

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "reqId = " & reqId & " =============== end ===============")

        ' move into view
        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1

    End Sub

    Private Sub Tws1_nextValidId(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_nextValidIdEvent) Handles Tws1.OnNextValidId
        currentorderid = eventArgs.Id



        'm_dlgOrder.orderId = eventArgs.Id 'Set Order Id Here

    End Sub

    Private Sub Tws1_orderStatus(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_orderStatusEvent) Handles Tws1.OnorderStatus

        ' ANY CHANGE IN ORDER STATUS WILL HAPPEN HERE - SAVE THE VARS TO THE CLASS HERE FOR USE BEYOND THIS SUB

        Dim msg As String

        msg = "Order Status: Order Id: " & eventArgs.orderId & " Client Id: " & eventArgs.clientId & " Perm Id: " & eventArgs.permId &
              " Status: " & eventArgs.status & " Filled: " & eventArgs.filled & " Fill Price: " & String.Format("{0:C}", eventArgs.lastFillPrice)
        ' & " parentId=" & eventArgs.parentId & " whyHeld=" & eventArgs.whyHeld  & " avgFillPrice=" & eventArgs.avgFillPrice & remaining=" & eventArgs.remaining &

        '
        ' ADD CODE HERE TO WRITE ORDER STATUS TO DATABASE OPENED AND FILLED.
        Select Case eventArgs.status.ToLower()
            Case "submitted"
                MsgBox(msg)
            Case "presubmitted"
                MsgBox(msg)
            Case "filled"
                If cntr = 1 Then
                    MsgBox(msg)
                    cntr = cntr + 1
                End If
            Case "cancelled"
                MsgBox(msg)
        End Select


        'If eventArgs.status = "Submitted" Then
        '    MsgBox(msg)
        'End If

        'If eventArgs.status = "Filled" Then
        '    If cntr = 1 Then
        '        MsgBox(msg)
        '        cntr = cntr + 1
        '    End If

        'End If

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, msg)

        ' move into view
        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1
    End Sub

    Private Sub Tws1_openOrderEx(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_openOrderExEvent) Handles Tws1.OnopenOrderEx

        ' NOTE:  KEEP ALL THIS CODE AS REFERENCE FOR LISTBOX MESSAGING AND USE THIS TO ASSIGN VALUES TO THE ORDER AND CONTRACT CLASSES.
        ' WILL NEED TO USE SOME OF THESE ADDITIONAL ITEMS AS OPTIONS ARE ADDED ETC.

        Dim ordermsg As String = ""
        Dim contractmsg As String = ""
        Dim orderstatemsg As String = ""

        Dim contract As IBApi.Contract
        contract = eventArgs.contract


        Dim order As IBApi.Order
        order = eventArgs.order

        Dim orderState As IBApi.OrderState
        orderState = eventArgs.orderState

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "OpenOrderEx called, orderId= " & eventArgs.orderId)

        ' Change the responses to single line with data needed at this time - If needed in the future add items to each line.

        ordermsg = "Order Details: Id: " & order.OrderId & " Client Id: " & order.ClientId & " PermId: " & order.PermId & " Action: " & order.Action &
            " Qty: " & order.TotalQuantity & " Type: " & order.OrderType & " Price: " & String.Format("{0:C}", order.LmtPrice) &
            " Tif: " & order.Tif 

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)

        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "Order:")
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  orderId=" & order.OrderId)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  clientId=" & order.ClientId)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  permId=" & order.PermId)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  action=" & order.Action)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  quantity=" & order.TotalQuantity)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  orderType=" & order.OrderType)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  lmtPrice=" & DblMaxStr(order.LmtPrice))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  auxPrice=" & DblMaxStr(order.AuxPrice))

        contractmsg = "Contract Details: Id: " & contract.ConId & " Symbol: " & contract.Symbol & " Security Type: " & contract.SecType &
            "Exchange: " & contract.Exchange & " Currency: " & contract.Currency

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, contractmsg)

        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "Contract:")
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  conId=" & contract.ConId)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  symbol=" & contract.Symbol)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  secType=" & contract.SecType)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  lastTradeDate=" & contract.LastTradeDateOrContractMonth)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  strike=" & contract.Strike)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  right=" & contract.Right)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  multiplier=" & contract.Multiplier)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  exchange=" & contract.Exchange)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  primaryExchange=" & contract.PrimaryExch)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  currency=" & contract.Currency)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  localSymbol=" & contract.LocalSymbol)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  tradingClass=" & contract.TradingClass)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  comboLegsDescrip=" & contract.ComboLegsDescription)

        ' combo legs
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  comboLegs={")

        If Not contract.ComboLegs Is Nothing Then
            Dim comboLegsCount As Long
            Dim orderComboLegsCount As Long
            comboLegsCount = contract.ComboLegs.Count
            orderComboLegsCount = 0

            If Not order.OrderComboLegs Is Nothing Then
                orderComboLegsCount = order.OrderComboLegs.Count()
            End If

            Dim iLoop As Long
            For iLoop = 0 To comboLegsCount - 1
                Dim comboLeg As IBApi.ComboLeg
                comboLeg = contract.ComboLegs.Item(iLoop)
                Dim orderComboLegPriceStr As String
                orderComboLegPriceStr = ""

                If comboLegsCount = orderComboLegsCount Then
                    Dim orderComboLeg As IBApi.OrderComboLeg
                    orderComboLeg = order.OrderComboLegs.Item(iLoop)
                    orderComboLegPriceStr = " price=" & DblMaxStr(orderComboLeg.Price)
                End If

                'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "    leg " & (iLoop + 1) &
                '": conId=" & comboLeg.ConId & " ratio=" & comboLeg.Ratio & " action=" & comboLeg.Action &
                '" exchange = " & comboLeg.Exchange & " openClose=" & comboLeg.OpenClose &
                '" shortSaleSlot=" & comboLeg.ShortSaleSlot & " designatedLocation=" & comboLeg.DesignatedLocation &
                '" exemptCode=" & comboLeg.ExemptCode & orderComboLegPriceStr)
            Next iLoop
        End If
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  }")

        Dim underComp As IBApi.UnderComp
        underComp = contract.UnderComp

        If (Not underComp Is Nothing) Then
            With underComp
                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  underComp.conId=" & .ConId)
                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  underComp.delta=" & .Delta)
                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  underComp.delta=" & .Price)
            End With
        End If


        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "Order (extended):")
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  timeInForce=" & order.Tif)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  ocaGroup=" & order.OcaGroup)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  ocaType=" & order.OcaType)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  orderRef=" & order.OrderRef)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  transmit=" & order.Transmit)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  parentId=" & order.ParentId)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  blockOrder=" & order.BlockOrder)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  sweepToFill=" & order.SweepToFill)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  displaySize=" & order.DisplaySize)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  triggerMethod=" & order.TriggerMethod)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  outsideRth=" & order.OutsideRth)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  hidden=" & order.Hidden)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  goodAfterTime=" & order.GoodAfterTime)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  goodTillDate=" & order.GoodTillDate)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  overridePercentageConstraints=" & order.OverridePercentageConstraints)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  rule80A=" & order.Rule80A)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  allOrNone=" & order.AllOrNone)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  minQty=" & IntMaxStr(order.MinQty))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  percentOffset=" & DblMaxStr(order.PercentOffset))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  trailStopPrice=" & DblMaxStr(order.TrailStopPrice))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  trailingPercent=" & DblMaxStr(order.TrailingPercent))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  whatIf=" & order.WhatIf)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  notHeld=" & order.NotHeld)

        ' Financial advisors only
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  faGroup=" & order.FaGroup)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  faProfile=" & order.FaProfile)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  faMethod=" & order.FaMethod)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  faPercentage=" & order.FaPercentage)

        ' Clearing info
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  account=" & order.Account)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  modelCode=" & order.ModelCode)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  settlingFirm=" & order.SettlingFirm)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  clearingAccount=" & order.ClearingAccount)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  clearingIntent=" & order.ClearingIntent)

        ' Institutional orders only
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  openClose=" & order.OpenClose)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  origin=" & order.Origin)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  shortSaleSlot=" & order.ShortSaleSlot)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  designatedLocation=" & order.DesignatedLocation)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  exemptCode=" & order.ExemptCode)

        ' SMART routing only
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  discretionaryAmt=" & order.DiscretionaryAmt)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  eTradeOnly=" & order.ETradeOnly)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  firmQuoteOnly=" & order.FirmQuoteOnly)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  nbboPriceCap=" & DblMaxStr(order.NbboPriceCap))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  optOutSmartRouting=" & order.OptOutSmartRouting)

        ' BOX or VOL orders only
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  auctionStrategy=" & order.AuctionStrategy)

        ' BOX order only
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  startingPrice=" & DblMaxStr(order.StartingPrice))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  stockRefPrice=" & DblMaxStr(order.StockRefPrice))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  delta=" & DblMaxStr(order.Delta))

        ' pegged to stock or VOL orders
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  stockRangeLower=" & DblMaxStr(order.StockRangeLower))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  stockRangeUpper=" & DblMaxStr(order.StockRangeUpper))

        ' VOLATILITY orders only
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  volatility=" & DblMaxStr(order.Volatility))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  volatilityType=" & order.VolatilityType)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  continuousUpdate=" & order.ContinuousUpdate)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  referencePriceType=" & order.ReferencePriceType)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  deltaNeutralOrderType=" & order.DeltaNeutralOrderType)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  deltaNeutralAuxPrice=" & DblMaxStr(order.DeltaNeutralAuxPrice))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  deltaNeutralConId=" & order.DeltaNeutralConId)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  deltaNeutralSettlingFirm=" & order.DeltaNeutralSettlingFirm)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  deltaNeutralClearingAccount=" & order.DeltaNeutralClearingAccount)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  deltaNeutralClearingIntent=" & order.DeltaNeutralClearingIntent)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  deltaNeutralOpenClose=" & order.DeltaNeutralOpenClose)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  deltaNeutralShortSale=" & order.DeltaNeutralShortSale)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  deltaNeutralShortSaleSlot=" & order.DeltaNeutralShortSaleSlot)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  deltaNeutralDesignatedlocation=" & order.DeltaNeutralDesignatedLocation)

        ' COMBO orders only
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  basisPoints=" & DblMaxStr(order.BasisPoints))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  basisPointsType=" & IntMaxStr(order.BasisPointsType))

        ' SCALE orders only
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  scaleInitLevelSize=" & IntMaxStr(order.ScaleInitLevelSize))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  scaleSubsLevelSize=" & IntMaxStr(order.ScaleSubsLevelSize))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  scalePriceIncrement=" & DblMaxStr(order.ScalePriceIncrement))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  scalePriceAdjustValue=" & DblMaxStr(order.ScalePriceAdjustValue))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  scalePriceAdjustInterval=" & IntMaxStr(order.ScalePriceAdjustInterval))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  scaleProfitOffset=" & DblMaxStr(order.ScaleProfitOffset))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  scaleAutoReset=" & order.ScaleAutoReset)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  scaleInitPosition=" & IntMaxStr(order.ScaleInitPosition))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  scaleInitFillQty=" & IntMaxStr(order.ScaleInitFillQty))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  scaleRandomPercent=" & IntMaxStr(order.ScaleRandomPercent))

        ' HEDGE orders only
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  hedgeType=" & order.HedgeType)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  hedgeParam=" & order.HedgeParam)

        ' Solicited orders only
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  solicited=" & order.Solicited)

        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  randomize size=" & order.RandomizeSize)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  randomize price=" & order.RandomizePrice)

        ' ALGO orders only
        Dim algoStrategy As String
        algoStrategy = order.AlgoStrategy
        If (algoStrategy <> "") Then
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  algoStrategy=" & algoStrategy)
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  algoParams={")
            Dim algoParams As List(Of IBApi.TagValue)
            algoParams = order.AlgoParams
            If (Not algoParams Is Nothing) Then
                Dim algoParamsCount As Long
                algoParamsCount = algoParams.Count
                Dim iLoop As Long
                For iLoop = 0 To algoParamsCount - 1
                    Dim param As IBApi.TagValue
                    param = algoParams.Item(iLoop)
                    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "    " & param.Tag & "=" & param.Value)
                Next iLoop
            End If
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  }")
        End If

        ' Smart combo routing params
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  smartComboRoutingParams={")
        Dim smartComboRoutingParams As List(Of IBApi.TagValue)
        smartComboRoutingParams = order.SmartComboRoutingParams
        If (Not smartComboRoutingParams Is Nothing) Then
            Dim smartComboRoutingParamsCount As Long
            smartComboRoutingParamsCount = smartComboRoutingParams.Count
            Dim iLoop As Long
            For iLoop = 0 To smartComboRoutingParamsCount - 1
                Dim param As IBApi.TagValue
                param = smartComboRoutingParams.Item(iLoop)
                'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "    " & param.Tag & "=" & param.Value)
            Next iLoop
        End If
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  }")

        orderstatemsg = "Order Status: " & orderState.Status

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, orderstatemsg)

        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "OrderState:")
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  status=" & orderState.Status)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  initMargin=" & orderState.InitMargin)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  maintMargin=" & orderState.MaintMargin)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  equityWithLoan=" & orderState.EquityWithLoan)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  commission=" & DblMaxStr(orderState.Commission))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  minCommission=" & DblMaxStr(orderState.MinCommission))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  maxCommission=" & DblMaxStr(orderState.MaxCommission))
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  comissionCurrency=" & orderState.CommissionCurrency)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  warningText=" & orderState.WarningText)

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")

    End Sub

    Public WithEvents Tws1 As Tws





    ' MIHIR - 04/06/18 SPRINT IS TO GET A SINGLE TICK PRICE WHEN btn

    Private Sub Tws1_tickPrice(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickPriceEvent) Handles Tws1.OnTickPrice
        Dim mktDataStr As String

        mktDataStr = "id=" & eventArgs.id & " =" & eventArgs.price

        'MsgBox("id=" & eventArgs.id & " VXX" & m_utils.getField(eventArgs.tickType) & "=" & eventArgs.price)
        Thread.Sleep(1000)

        'If (eventArgs.canAutoExecute <> 0) Then
        '    mktDataStr = mktDataStr & " canAutoExecute"
        'Else
        '    mktDataStr = mktDataStr & " noAutoExecute"
        'End If
        Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)
        Exit Sub
        ' move into view
        'lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    ' MIHIR THIS IS THE GET TICKPRICE BUTTON THAT SHOULD INITIATE GETTING A SINGLE TICKPRICE FOR THE SYMBOL SELECTED

    Private Sub btnGetPrice_Click(sender As Object, e As EventArgs) Handles btnGetPrice.Click

        Dim currentprice As Double = 0                                                                                                  ' VALUE RETURNED FROM THIS FUNCTION BEING CALLED
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                           ' ESTABLISH A NEW CONTRACT CLASS

        If txtGetPriceSymbol.Text <> "" Then
            contract.Symbol = txtGetPriceSymbol.Text                                                                                    ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
        Else
            MsgBox("Please enter a symbol.")
            Exit Sub
        End If

        contract.SecType = "STK"                                                                                                        ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Currency = "USD"                                                                                                       ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Exchange = "SMART"                                                                                                     ' INITIALIZE EXCHANGE USED FOR THE CONTRACT


        Tws1.reqMarketDataType(3)                                                                                                       ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(1, contract, "", False, Nothing)                                                                              ' API CALL TO GET THE PRODUCTS TICK PRICE                       

        currentprice = Tws1.StockTickPrice                                                                                             ' SET CURRENT PRICE TO STOCKTICKPRICE TO BE PASSED TO CALLING FUNCTION
        'Stop

    End Sub






    ' CLASSES USED IN THE APPLICATION
    Public Class backPrice

        Private m_Date As String
        Public Property MarketDate As String
            Get
                Return m_Date
            End Get
            Set(value As String)
                m_Date = value
            End Set
        End Property

        Private m_Time As String
        Public Property MarketTime As String
            Get
                Return m_Time
            End Get
            Set(value As String)
                m_Time = value
            End Set
        End Property

        Private m_OpenPrice As Decimal
        Public Property OpenPrice() As Decimal
            Get
                Return m_OpenPrice
            End Get
            Set(value As Decimal)
                m_OpenPrice = value
            End Set
        End Property

        Private m_HighPrice As Decimal
        Public Property HighPrice() As Decimal
            Get
                Return m_HighPrice
            End Get
            Set(value As Decimal)
                m_HighPrice = value
            End Set
        End Property

        Private m_LowPrice As Decimal
        Public Property LowPrice() As Decimal
            Get
                Return m_LowPrice
            End Get
            Set(value As Decimal)
                m_LowPrice = value
            End Set
        End Property

        Private m_AdjClosePrice As Decimal
        Public Property AdjClosePrice() As Decimal
            Get
                Return m_AdjClosePrice
            End Get
            Set(value As Decimal)
                m_AdjClosePrice = value
            End Set
        End Property

        Private m_ClosePrice As Decimal
        Public Property ClosePrice() As Decimal
            Get
                Return m_ClosePrice
            End Get
            Set(value As Decimal)
                m_ClosePrice = value
            End Set
        End Property

        Private m_Volume As Integer
        Public Property Volume() As Integer
            Get
                Return m_Volume
            End Get
            Set(value As Integer)
                m_Volume = value
            End Set
        End Property

        Private m_Interval As Integer
        Public Property interval() As Integer
            Get
                Return m_Interval
            End Get
            Set(value As Integer)
                m_Interval = value
            End Set
        End Property



    End Class

    Public Class OrderDetail                                                                                                          ' CLASS USED TO STORE ORDER STATUS DATA RECEIVED FROM THE TWS API

        Private m_OrderId As Integer
        Public Property orderid() As Integer
            Get
                Return m_OrderId
            End Get
            Set(value As Integer)
                m_OrderId = value
            End Set
        End Property


    End Class

    ' CALLED FUNCTIONS USED IN THE APPLICATION
    Private Function ParseBackData(csvData As String) As List(Of backPrice)                                                                                                             ' THIS FUNCTION WILL PARSE THE INTERVAL PRICES FROM THE CSV FILE.
        Dim rowcntr As Integer = 0                                                                                                                                                      ' INITALIZE THE ROW COUNTER.
        Dim backprices As New List(Of backPrice)()                                                                                                                                      ' INITIALIZE THE BACKPRICES LIST
        Dim marketdatetime As DateTime                                                                                                                                                  ' INITIALIZE THE MARKET DATE BEING PROCESSED    

        Dim rows As String() = csvData.Replace(vbCr, "").Split(ControlChars.Lf)                                                                                                         ' LOADS EACH LINE INTO ROWS TO BE PARSED

        For Each row As String In rows                                                                                                                                                  ' ROW LOOPS

            If String.IsNullOrEmpty(row) Then                                                                                                                                           ' IF THE LINE IS NULL OR EMPTY MOVE TO NEXT ROW
                Continue For                                                                                                                                                            ' MOVE FORWARD IN THE LOOP
            End If

            Dim cols As String() = row.Split(","c)                                                                                                                                      ' SPLIT ROWS INTO FIELDS BASED ON , 

            If cols(0) = "Date" Then                                                                                                                                                    ' CHECK FOR THE DATE ROW. USED IN YAHOO FINANCE
                Continue For
            End If

            Dim p As New backPrice()                                                                                                                                                    ' INITIALIZE A NEW BACKPRICE 
            p.MarketDate = cols(0).Substring(4, 2) & "/" & cols(0).Substring(6, 2) & "/" & cols(0).Substring(0, 4)                                                                      ' SET COLUMN 0 TO MARKET DATE
            If Len(cols(1)) < 4 Then
                p.MarketTime = cols(1).Substring(0, 1) & ":" & cols(1).Substring(1, 2)                                                                                                  ' SET COLUMN 1 TO MARKET TIME
            ElseIf Len(cols(1)) = 4 Then
                p.MarketTime = cols(1).Substring(0, 2) & ":" & cols(1).Substring(2, 2)                                                                                                  ' SET COLUMN 1 TO MARKET TIME                
            End If

            p.OpenPrice = Convert.ToDecimal(cols(2))                                                                                                                                    ' SET COLUMN 2 TO OPEN PRICE    
            p.HighPrice = Convert.ToDecimal(cols(3))                                                                                                                                    ' SET COLUMN 3 TO HIGH PRICE
            p.LowPrice = Convert.ToDecimal(cols(4))                                                                                                                                     ' SET COLUMN 4 TO LOW PRICE
            p.ClosePrice = Convert.ToDecimal(cols(5))                                                                                                                                   ' SET COLUMN 5 TO CLOSE PRICE            

            marketdatetime = p.MarketDate & " " & p.MarketTime

            '' ONLY ADD ROWS WHERE THE MARKET IS OPEN.
            If marketdatetime.ToShortTimeString() > #9:29:00 AM# Then                                                                                                                   ' CHECK IF MARKET TIME IS AFTER MARKET OPENS                
                If marketdatetime.ToShortTimeString() < #4:01:00 PM# Then                                                                                                               ' CHECK IF MARKET TIME IS BEFORE MARKET CLOSES CHANGE BACK TO 4:01:00 PM                    
                    p.interval = rowcntr                                                                                                                                                ' SET INTERVAL FIELD IN PRICE TO CURRENT ROW
                    backprices.Add(p)                                                                                                                                                   ' ADD P TO BACKPRICES
                    rowcntr = rowcntr + 1                                                                                                                                               ' INCREMENT THE ROW COUNTER
                End If
            End If

        Next

        Return backprices                                                                                                                                                               ' RETURN TO CALLING FUNCTION WITH BACKPRICES MODEL POPULATED
    End Function

    ' FUNCTION NOT USED AS OF 4.3.18
    Function getdatetime(ByVal marketdate As String, ByVal markettime As String) As String
        Dim dateandtime As String = ""
        Dim dte As String = ""
        Dim tme As String = ""

        If markettime.Length < 4 Then
            'dateandtime = DateTime.Parse(marketdate & " " & Left(markettime, 1) & ":" & Right(markettime, 2))
            dte = marketdate.Substring(4, 2) & "/" & marketdate.Substring(6, 2) & "/" & marketdate.Substring(0, 4)
            tme = (markettime.Substring(0, 1) & ":" & markettime.Substring(1, 2))
            dateandtime = dte & " " & tme
        Else
            'dateandtime = DateTime.Parse(marketdate & " " & Left(markettime, 2) & ":" & Right(markettime, 2))
        End If
        Return dateandtime
    End Function

End Class
