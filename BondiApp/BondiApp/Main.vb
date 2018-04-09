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
    Dim tickId As Integer = 0

    Private m_utils As New Utils                                                                                                                ' CREATES A NEW INSTANCE OF UTILS TO BE USED IN THIS FORM 
    Private m_dlgAcctData As New dlgAcctData
    Private m_dlgConnect As New dlgConnect
    Private m_dlgHarvest As New dlgHarvest
    Private m_faAcctsList As String
    Private m_faAccount, faError As Boolean                                                                                                     ' VARIABLE TO HOLD FINACIAL ADVISOR STATUS SETTINGS
    Dim connecting As Boolean = True
    Public backprices As List(Of backPrice)                                                                                                     ' CLASS DEFINITION TO HOUSE                         
    Public orderdetails As List(Of OrderDetail)
    Public fileNameRead As String
    Public nextValidOrderId As Integer = 0                                                                                                        ' PUBLIC VARIABLE TO HOLD CURRENTORDERID - TO BE USED TO SET THE NEXTVALIDID FOR ORDERS
    Public PriceTest As Double = 0
    Public currentprice As Double = 0                                                                                                              ' VALUE RETURNED FROM THIS FUNCTION BEING CALLED
    Public cntr As Integer = 1
    Public datastring As String = ""
    Public RobotOn As Boolean = False                                                                                                           ' INDICATES THAT THE ROBOT IS RUNNING IN THE OPENORDEREX SUB TO ADD ORDERS
    Public UpdateBuy As Boolean = False
    Public matchid As Integer

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

    ' INDIVIDUAL BUTTONS TO TEST EACH COMPONENT WITHIN THE API

    Private Sub btnConnect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnConnect.Click

        datastring = "Connected to TWS " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "
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
        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)
        lblConStatus.Text = datastring


    End Sub

    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click

        Dim datastring As String = "Disconnected from TWS " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "
        Dim connected As String = ""

        Tws1.disconnect()

        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)
        lblConStatus.Text = datastring

    End Sub

    Private Sub btnReqNextValidId_Click(sender As Object, e As EventArgs) Handles btnReqNextValidId.Click

        Dim datastring = "Next Valid Order Id: " & nextValidOrderId & "  " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "
        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)
        lblConStatus.Text = datastring

    End Sub

    Private Sub cmbIndexes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIndexes.SelectedIndexChanged

        ' if connected to TWS get the symbol from the database and get current price.
        ' used to establish the first price for the harvest robot
        Dim product As String = ""
        indexselected = cmbIndexes.SelectedValue.ToString()

        If (Tws1.serverVersion() > 0) Then

            Dim contract As IBApi.Contract = New IBApi.Contract()                                                                           ' ESTABLISH A NEW CONTRACT CLASS

            Using db As BondiModel = New BondiModel()                                                                      ' DATABASE MODEL USING ENTITY FRAMEWORK

                Dim indexlist As List(Of HarvestIndex) = New List(Of HarvestIndex)()
                indexlist = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbIndexes.SelectedValue).ToList()
                product = indexlist.FirstOrDefault().product

                contract.Symbol = product                                                                                    ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT

                contract.SecType = "STK"                                                                                                        ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
                contract.Currency = "USD"                                                                                                       ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
                contract.Exchange = "SMART"                                                                                                     ' INITIALIZE EXCHANGE USED FOR THE CONTRACT

                Tws1.reqMarketDataType(3)                                                                                                       ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
                Tws1.reqMktDataEx(tickId + 1, contract, "", False, Nothing)
                Tws1.tickCount = 0

            End Using

        End If


    End Sub

    Private Sub btnSendOrder_Click(sender As Object, e As EventArgs) Handles btnSendOrder.Click

        Dim datastring As String = ""                                                                                                         ' SETS THE INITIAL DATASTRING VALUE - REWRITTEN WHEN THE CODE EXECUTES

        Dim order As IBApi.Order = New IBApi.Order()
        Dim contract As IBApi.Contract = New IBApi.Contract()
        contract.Symbol = txtSymbol.Text
        contract.SecType = "STK"
        contract.Currency = "USD"
        contract.Exchange = "SMART"


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
    Private Sub btnGetData_Click(sender As Object, e As EventArgs)
        Dim symbol As String = ""
        Using db As BondiModel = New BondiModel()
            'Dim _lstHarvestindex As List(Of HarvestIndex) = New List(Of HarvestIndex)()
            '_lstHarvestindex = _entity.HarvestIndexes.AsEnumerable.[Select](Function(x) New HarvestIndex).Where(Function(s) s.harvestKey = cmbIndexes.SelectedValue).ToList()
            'cmbIndexes.DataSource = _lstHarvestindex
            'cmbIndexes.DisplayMember = "name"
            'cmbIndexes.ValueMember = "harvestKey"

            Dim _lstHarvestindex As List(Of HarvestIndex) = New List(Of HarvestIndex)()
            _lstHarvestindex = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbIndexes.SelectedValue).ToList()
            symbol = _lstHarvestindex.FirstOrDefault().product

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
            Tws1.reqMktDataEx(tickId + 1, contract, "", False, Nothing)
            Tws1.tickCount = 0

        End Using



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
                lblBacktestStatus.Text = lblBacktestStatus.Text & " " & backprices.Count                                                                                              ' LABEL INDICATOR SHOWING THAT PROCESSING IS COMPLETE
            End Using
        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)                                                                                                ' IF THERE IS AN ERROR READING THE FILE DISPLAY THE ERROR MESSAGE
        Finally

        End Try

    End Sub


    Private Sub btnReadBacktest_Click(sender As Object, e As EventArgs) Handles btnReadBacktest.Click

        Dim datastring As String = "Backtest Run: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "
        Dim csvdata As String = ""                                                                                                                                                      ' STRING TO HOLD THE DATA FROM EACH CSV FILE READ INTO MEMORY
        Dim filedate As String = "20160104"                                                                                                                                             ' STRING TO HOLD THE FILE DATE FOR THE CSV FILE TO BE READ THIS WILL INCREMENT FROM DB
        Dim symbol As String = ""                                                                                                                                                       ' STRING TO HOLD THE SYMBOL OF THE PRODUCT BEING TESTED
        Dim priceint As Integer = 0
        Dim currentprice As Double = 0
        Dim checksum As Double = 0
        Dim opentrigger As Double = 0

        Using db As BondiModel = New BondiModel()
            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()
            hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbIndexes.SelectedValue).ToList()
            symbol = hi.FirstOrDefault().product
            opentrigger = hi.FirstOrDefault().opentrigger
        End Using
        Dim path As String = "C:\Users\Troy Belden\Desktop\stockprices\allstocks_"                                                                                                      ' GENERIC PATH FOR READING THE CSV FILES - WILL NEED TO SET TO USER INPUT FOR PRODUCTION

        Try
            Using textReader As New System.IO.StreamReader(path & filedate & "\table_" & symbol & ".csv")                                                                               ' TEXT READER READS THE CSV FILE INTO MEMORY
                csvdata = textReader.ReadToEnd                                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING.
                backprices = ParseBackData(csvdata)                                                                                                                                     ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.                        
                'Stop

                lstOHLC.Items.Add("Row" & vbTab & "Time" & vbTab & "Open" & vbTab & "High" & vbTab & "Low" & vbTab & "Close")
                For Each price As backPrice In backprices

                    If price.interval = 0 Then

                        priceint = Int(price.OpenPrice)                                                                                                                                 ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
                        checksum = price.OpenPrice - priceint                                                                                                                           ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
                        currentprice = (Int(checksum / opentrigger) * opentrigger + priceint)                                                                                         ' CALCULATE THE NEAREST MARK PRICE TO SET THE LIMIT ORDER AGAINST                    

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

        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)
        lblBacktestStatus.Text = datastring

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

        Dim datastring As String = "Willie Initiated: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "             ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP
        Dim priceint As Double = 0                                                                                                  ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        Dim checksum As Double = 0                                                                                                  ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        Dim cprice As Double = 0                                                                                                    ' VARIABLE USED TO HOLD THE STARTING OPEN TO BUY PRICE FOR EACH USER & INDEX
        Dim Symbol As String = ""                                                                                                   ' VARIABLE USED TO HOLD THE SYMBOL FOR THE USER & INDEX
        Dim opentrigger As Double = 0                                                                                               ' VARIABLE USED TO HOLD THE TRIGGER FOR THE BUY TO OPEN POSITIONS
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                       ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                                ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

        Dim userid As Guid                                                                                                          ' VARIABLE USED TO HOLD THE CURRENT USERS USERID (NEED TO DETERMINE IF I NEED TO KEEP THIS OR NOT)

        connecting = False                                                                                                          ' FLAG USED TO INDICATE THAT THIS CALL IS NOT DUE TO CONNECTING TO TWS
        cntr = 1                                                                                                                    ' COUNTER FLAG USED TO ELIMINATE THE TWO CYCLES THROUGH THE ORDER PROCESSING 

        Using db As BondiModel = New BondiModel()                                                                                   ' DATABASE MODEL USED TO CAPTURE THE ROBOTS DATA

            ' NEED TO DETERMINE WHAT IS NEEDED TO ADDRESS A GAP UP AND GAP DOWN HERE AS WELL
            ' NEED TO ADDRESS A RUN UP - WHEN YOU HAVE A BUY ORDER OPEN AND THE PRODUCTS PRICE RUNS UP NOT 
            ' ALLOWING A CHANCE TO FILL THE BUY.  NEED CODE TO ASSESS THE TICKPRICE AND IF GREATER THAN THE OPENTRIGGER 
            ' ABOVE MODIFY THE CURRENT BUY TO OPEN ORDER TO TRAIL THE RUN-UP UNTIL FILLED.  

            Dim ul As List(Of User) = New List(Of User)()                                                                           ' GET THE USERID OF THE USER TO CHECK FOR ORDERS FOR THIS ID AS WELL AS THE INDEX
            ul = db.Users.AsEnumerable.Where(Function(u) u.UserName = "boss").ToList()                                              ' BUILD THE LIST OF USERS BASED ON THIS USERNAME
            userid = ul.FirstOrDefault().UserId                                                                                     ' SET THE USERID EQUAL TO THE USERS USERID - CONSIDER DOING THIS IN A PUBLIC VAR AT LOGIN

            Dim so As List(Of stockorder) = New List(Of stockorder)()
            'so = db.stockorders.AsEnumerable.Where(Function(s) s.userid = userid And  = "boss").ToList()                           ' BUILD THE LIST OF USERS BASED ON THIS USERNAME
            so = db.stockorders.AsEnumerable.Where(Function(s) s.roboIndex = cmbIndexes.SelectedValue).ToList()                     ' BUILD THE LIST OF USERS BASED ON THIS USERNAME

            If so.Count = 0 Then                                                                                                    ' INDICATES THAT THIS IS THE FIRST ORDER CALC OPEN PRICE AND SEND FIRST BUY TO OPEN ORDER

                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                       ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
                hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbIndexes.SelectedValue).ToList()             ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

                priceint = Int(currentprice)                                                                                        ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
                checksum = currentprice - priceint                                                                                  ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
                cprice = (Int(checksum / hi.FirstOrDefault.opentrigger) * hi.FirstOrDefault.opentrigger + priceint)                 ' CALCULATE THE STARTING BUY TO OPEN PRICE 

                contract.Symbol = hi.FirstOrDefault().product.ToUpper()                                                             ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
                contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                                       ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
                contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                                      ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
                contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                                          ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE 

                order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                                           ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
                order.TotalQuantity = hi.FirstOrDefault().shares                                                                    ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
                order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                                                   ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)

                order.OrderId = nextValidOrderId                                                                                    ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
                order.Action = "BUY"                                                                                                ' SET THE ORDER ACTION TO BUY
                order.LmtPrice = cprice                                                                                             ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

                Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

            End If

        End Using

        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                             ' ADD THE CURRENT FINISH TIME TO THE DATASTRING TO GET THE FULL CYCLE TIME
        lblConStatus.Text = datastring                                                                                              ' DISPLAY THE DATASTRING TO THE USER

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

        nextValidOrderId = eventArgs.Id
        'm_dlgOrder.orderId = eventArgs.Id 'Set Order Id Here

    End Sub

    Private Sub Tws1_orderStatus(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_orderStatusEvent) Handles Tws1.OnorderStatus

        ' ANY CHANGE IN ORDER STATUS WILL HAPPEN HERE - SAVE THE VARS TO THE CLASS HERE FOR USE BEYOND THIS SUB

        Dim msg As String                                                                                                           ' MESSAGE VARIABLE USED TO HOLD THE MESSAGE DATA TO PRESENT TO THE USER

        msg = "Order Status: Order Id: " & eventArgs.orderId & " Client Id: " &
            eventArgs.clientId & " Perm Id: " & eventArgs.permId & " Status: " & eventArgs.status &
            " Filled: " & eventArgs.filled & " Fill Price: " & String.Format("{0:C}", eventArgs.lastFillPrice)                      ' SETS THE MESSAGE BASED ON ACTIONS THAT OCCURRED IN THE ORDER STATUS FUNCTION
        ' & " parentId=" & eventArgs.parentId & " whyHeld=" & eventArgs.whyHeld  & " avgFillPrice=" & 
        'eventArgs.avgFillPrice & remaining=" & eventArgs.remaining &

        '
        ' ADD CODE HERE TO WRITE ORDER STATUS TO DATABASE OPENED AND FILLED.
        Select Case eventArgs.status.ToLower()                                                                                      ' DETERMINE HOW TO PROCESS THE ORDER STATE CHANGE

            Case "submitted"

                ' Submitted orders occur when an order is placed and the market is open.  
                If cntr = 1 Then                                                                                                    ' CNTR FLAG INDICATES WHETHER THIS IS THE FIRST ORDER SUBMITTED FOR THIS USER AND INDEX IF IT IS THEN PROCESS THE ORDER
                    Using db As BondiModel = New BondiModel()                                                                       ' DATABASE MODEL USING ENTITY FRAMEWORK
                        Dim ordersexist = (From q In db.stockorders Where q.OrderId = eventArgs.orderId Select q)                   ' QUERY TO SEE IF THERE IS AN ORDER THAT ALREADY EXISTS

                        If ordersexist.Count > 0 Then                                                                               ' IF THERE IS AN ORDER DO NOTHING
                        Else
                            msg = msg & " Order Added to db."                                                                       ' ADD MESSAGE TO THE DATASTRING TO ALERT THE USER
                            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, msg)                                        ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER
                        End If

                    End Using

                    cntr = cntr + 1                                                                                                 ' INCREMENT THE CNTR FLAG TO INDICATE THAT SYSTEM IS BEYOND THE FIRST ORDER
                End If

            Case "presubmitted"

                ' Presubmitted occurs when an order exists or is sent when the market is not open.                
                If cntr = 1 Then                                                                                                    ' CNTR FLAG INDICATES WHETHER THIS IS THE FIRST ORDER SUBMITTED FOR THIS USER AND INDEX IF IT IS THEN PROCESS THE ORDER
                    Using db As BondiModel = New BondiModel()                                                                       ' DATABASE MODEL USING ENTITY FRAMEWORK
                        Dim ordersexist = (From q In db.stockorders Where q.OrderId = eventArgs.orderId Select q)                   ' QUERY TO SEE IF THERE IS AN ORDER THAT ALREADY EXISTS

                        If ordersexist.Count > 0 Then                                                                               ' IF THERE IS AN ORDER DO NOTHING
                        Else
                            msg = msg & " Order Added to db."                                                                       ' ADD MESSAGE TO THE DATASTRING TO ALERT THE USER
                            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, msg)                                        ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER
                        End If

                    End Using

                    cntr = cntr + 1                                                                                                 ' INCREMENT THE CNTR FLAG TO INDICATE THAT SYSTEM IS BEYOND THE FIRST ORDER
                End If

            Case "filled"
                If cntr = 1 Then

                    ' MOVE THIS CODE TO FILLED ORDERS FOR TESTING WHEN MARKET IS OPEN 4.09.18

                    Dim contract As IBApi.Contract = New IBApi.Contract()                                                               ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
                    Dim order As IBApi.Order = New IBApi.Order()                                                                        ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

                    Using db As BondiModel = New BondiModel()                                                                           ' DATABASE MODEL USING ENTITY FRAMEWORK

                        Dim ordersexist = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q)                         ' QUERY TO SEE IF THERE IS AN ORDER THAT ALREADY EXISTS

                        If ordersexist.Count > 0 Then                                                                                   ' IF THE ORDER FOR THIS PERMID EXISTS
                            'Simulate BUY TO OPEN order filled.  
                            ' Update the database record.

                            Dim ou = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q).FirstOrDefault()             ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED

                            If ou.Action = "BUY" Then                                                                                   ' IF THE ACTION IS SET TO BUY THEN PROCESS THE BUY TO OPEN FILLED STEPS

                                matchid = ou.matchID                                                                                    ' SET THE MATCHID FOR THE SELL TO CLOSE ORDER TO MATCH THE BUY TO OPEN ORDER
                                ou.OrderStatus = "Filled"   ' eventArgs.status                                                          ' SET THE ORDERSTATUS OF THE RECORD TO THE EVENT STATUS RESULT
                                ou.Status = "Closed"                                                                                    ' SET THE STATUS OF THE RECORD TO CLOSED
                                ou.TickPrice = 49.5         'eventArgs.lastFillPrice                                                    ' SET THE TICK PRICE TO THE FILLED PRICE TO CAPTURE THE PRICE THE ORDER WAS FILLED AT
                                db.SaveChanges()                                                                                        ' SAVE THE CHANGES TO THE DATABASE

                                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                           ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD
                                hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = ou.roboIndex).ToList()             ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

                                contract.Symbol = hi.FirstOrDefault().product.ToUpper()                                                 ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
                                contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                           ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
                                contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                          ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
                                contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                              ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE 

                                order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                               ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
                                order.TotalQuantity = hi.FirstOrDefault().shares                                                        ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
                                order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                                       ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)

                                order.OrderId = nextValidOrderId                                                                        ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ID NUMBER
                                order.Action = "SELL"                                                                                   ' SET THE ACTION OF THE ORDER TO SELL
                                order.LmtPrice = ou.LimitPrice + hi.FirstOrDefault().width                                              ' SET THE LIMIT PRICE OF THE ORDER TO THE LIMIT PRICE OF THE RECORD PLUS THE WIDTH VALUE IN THE INDEX

                                RobotOn = True                                                                                          ' FLAG TO INDICATE THAT THE ROBOT IS ON - HANDLED DURING ORDER PLACEMENT
                                UpdateBuy = False                                                                                       ' FLAG TO INDICATE THAT THE BUY ORDER IS NOT NEEDED TO BE UPDATED (stc order was not filled)

                                Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                  ' CALL THE PLACEORDER FUNCTION TO SEND THE ORDER CREATED TO TWS

                                ' AFTER THE SELL ORDER WAS SENT TO COMPLETE THE ROUND TRIP 
                                ' OF THE FILLED BUY TO OPEN ORDER SEND ANOTHER BUY TO OPEN ORDER

                                order.OrderId = nextValidOrderId                                                                        ' SET THE ORDER ID OF THE ORDER TO THE NEXT AVAILABLE ORDER ID
                                order.Action = "BUY"                                                                                    ' SET THE ACTION OF THE ORDER TO BUY
                                order.LmtPrice = ou.LimitPrice - hi.FirstOrDefault().width                                              ' SET THE LIMIT PRICE OF THE ORDER TO THE LIMIT PRICE OF THE RECORD MINUS THE WIDTH VALUE IN THE INDEX

                                Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                  ' CALL THE PLACEORDER FUNCTION TO SEND THE ORDER CREATED TO TWS

                            ElseIf ou.Action = "SELL" Then                                                                              ' IF THE ACTION IS SET TO SELL THEN PROCESS THE SELL TO CLOSE FILLED STEPS

                                ' When the SELL TO CLOSE order is filled modify the BUY TO OPEN below it raising it up one width.

                                ' EDIT CODE WHEN IT IS MOVED TO FILLED STATUS - TEST TO MAKE SURE THAT IT WORKS WITH WHAT IS EXPECTED AS AN OUTCOME

                                ou.OrderStatus = "Filled"   ' eventArgs.status                                                          ' SET ORDER STATUS OF THE RECORD TO UPDATE TO EVENTARGS STATUS
                                ou.Status = "Closed"                                                                                    ' SET STATUS OF THE RECORD TO UPDATE TO CLOSED
                                ou.TickPrice = 49.75         'eventArgs.lastFillPrice                                                   ' SET THE TICKPRICE OF THE RECORD TO UPDATE TO THE LASTFILLPRICE 
                                ou.timestamp = DateTime.Parse(Now).ToUniversalTime()                                                    ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME
                                db.SaveChanges()                                                                                        ' SAVE THE CHANGES TO THE DATABASE

                                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                           ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD
                                hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = ou.roboIndex).ToList()             ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

                                Dim sl As List(Of stockorder) = New List(Of stockorder)()                                               ' INITIALIZE THE STOCKORDER LIST TO BE USED TO GET THE STOCK ORDER RECORD TO UPDATE
                                sl = db.stockorders.AsEnumerable.Where(Function(s) s.LimitPrice =
                                (ou.LimitPrice - (hi.FirstOrDefault().width * 2)) And s.OrderStatus = "Open").ToList()              ' PULL THE STOCKORDER RECORD STRANDED BUY TO OPEN ORDER BASED ON LIMITPRICE AND OPEN STATUS

                                contract.Symbol = sl.FirstOrDefault().Symbol.ToUpper()                                                  ' SET THE CONTRACT SYMBOL TO THE STOCK ORDER UPDATED SYMBOL
                                contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                           ' SET THE CONTRACT SECURITY TYPE TO THE INDEX STOCK SECURITY TYPE
                                contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                          ' SET THE CONTRACT CURRENCY TYPE TO THE INDEX CURRENCY TYPE
                                contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                              ' SET THE CONTRACT EXCHANGE TYPE TO THE INDEX EXCHANGE TYPE

                                order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                               ' SET THE ORDER ORDER TYPE TO THE INDEX ORDER TYPE (lmt OR mkt)
                                order.TotalQuantity = hi.FirstOrDefault().shares                                                        ' SET THE ORDER NUMBER OF SHARES TO THE INDEX NUMBER OF SHARES - CONSIDER SETTING TO THE UPDATED ORDER SHARES VALUE
                                order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                                       ' SET THE ORDER TRADE IN FORCE TO THE INDEX TRADE IN FORCE (day OR gtc)

                                order.OrderId = sl.FirstOrDefault().OrderId                                                             ' SET THE ORDER ORDER ID TO THE UPDATED RECORD ORDER ID
                                order.Action = "BUY"                                                                                    ' SET THE ORDER ACTION TO BUY
                                order.LmtPrice = sl.FirstOrDefault().LimitPrice + hi.FirstOrDefault().width                             ' SET THE ORDER LIMIT PRICE TO THE UPDATED RECORD LIMIT PRICE PLUS THE INDEX WIDTH VALUE

                                RobotOn = True                                                                                          ' FLAG TO INDICATE THAT THE ROBOT IS ON - HANDLED DURING ORDER PLACEMENT
                                UpdateBuy = True                                                                                       ' FLAG TO INDICATE THAT THE BUY ORDER IS NOT NEEDED TO BE UPDATED (stc order was not filled)

                                Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                  ' CALL THE PLACEORDER FUNCTION TO SEND THE ORDER CREATED TO TWS

                            End If

                        End If
                    End Using

                    cntr = cntr + 1
                End If

            Case "cancelled"                                                                                                        ' TODO: BUILD THE PROCESS TO HANDLE CANCELLED ORDERS FROM THE TWS PLATFORM

                ' Use Cancelled to build the FILLED status mode start with BUY TO OPEN filled.
                ' 1. Get the db record for the filled order to update it.



        End Select

        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1                                                            ' SETS THE FOCUS OF THE LISTBOX TO THE LATEST DETAIL SENT TO IT
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

        contractmsg = "Contract Details: Id: " & contract.ConId & " Symbol: " & contract.Symbol & " Security Type: " & contract.SecType &
            "Exchange: " & contract.Exchange & " Currency: " & contract.Currency

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, contractmsg)

        orderstatemsg = "Order Status: " & orderState.Status

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, orderstatemsg)

        If connecting = False Then

            ' FIRST ORDER ADD SHOULD GO HERE.
            Using db As BondiModel = New BondiModel()                                                                      ' DATABASE MODEL USING ENTITY FRAMEWORK
                ' ADD USERID SEARCH TO THIS AS WELL TO REFINE THE SEARCH. 
                ' CHECK WITH MIHIR ON HOW TO UPDATE THE BONDIMODEL 

                Dim ordersexist = (From q In db.stockorders Where q.roboIndex = indexselected Select q) 'eventArgs.orderId Select q)

                If ordersexist.Count = 0 Then

                    Dim newStockOrder As New stockorder                                                                                                                                     ' OPEN NEW STRUCTURE FOR RECORD IN STOCK PRODUCTION TABLE.
                    'TryUpdateModel(newStockOrder)                                                                                                                                           ' TEST CONNECTION TO DATABASE TABLES.

                    ' TODO:  CHANGE THE MODEL AND CODE BELOW TO SWAP STATUS AND ORDERSTATUS FIELD SIZES 

                    Dim newindex As New stockorder With {
                                                            .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                            .OrderId = order.OrderId,
                                                            .PermID = order.PermId,
                                                            .Symbol = contract.Symbol.ToUpper(),
                                                            .Action = order.Action,
                                                            .TickPrice = currentprice,
                                                            .LimitPrice = order.LmtPrice,
                                                            .Status = orderState.Status,
                                                            .Quantity = order.TotalQuantity,
                                                            .OrderStatus = "Open",
                                                            .roboIndex = indexselected,
                                                            .matchID = order.OrderId,
                                                            .OrderTimestamp = DateTime.Parse(Now).ToUniversalTime()
                                                        }                                                                                                                               ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                    db.stockorders.Add(newindex)                                                                                                                                 ' INSERT THE NEW RECORD TO BE ADDED.
                    db.SaveChanges()

                End If

                If RobotOn = True Then

                    If order.Action = "SELL" Then

                    Else
                        matchid = order.OrderId
                    End If

                    If UpdateBuy = False Then

                        Dim newStockOrder As New stockorder                                                                                                                                     ' OPEN NEW STRUCTURE FOR RECORD IN STOCK PRODUCTION TABLE.
                        'TryUpdateModel(newStockOrder)                                                                                                                                           ' TEST CONNECTION TO DATABASE TABLES.
                        Dim newindex As New stockorder With {
                                                            .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                            .OrderId = order.OrderId,
                                                            .PermID = order.PermId,
                                                            .Symbol = contract.Symbol.ToUpper(),
                                                            .Action = order.Action,
                                                            .TickPrice = currentprice,
                                                            .LimitPrice = order.LmtPrice,
                                                            .Status = orderState.Status,
                                                            .Quantity = order.TotalQuantity,
                                                            .OrderStatus = "Open",
                                                            .roboIndex = indexselected,
                                                            .matchID = matchid,
                                                            .OrderTimestamp = DateTime.Parse(Now).ToUniversalTime()
                                                        }                                                                                                                               ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                        db.stockorders.Add(newindex)                                                                                                                                 ' INSERT THE NEW RECORD TO BE ADDED.
                        db.SaveChanges()

                    Else

                        Dim ou = (From q In db.stockorders Where q.OrderId = order.OrderId Select q).FirstOrDefault()

                        ou.Status = "Updated"
                        ou.LimitPrice = order.LmtPrice
                        ou.TickPrice = currentprice
                        ou.timestamp = DateTime.Parse(Now).ToUniversalTime()
                        db.SaveChanges()
                        UpdateBuy = False
                    End If
                End If

            End Using
        End If

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")

    End Sub

    Public WithEvents Tws1 As Tws

    Function gettickprice(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickPriceEvent) As Double

        MsgBox(eventArgs.price)
        If eventArgs.tickCount = 1 Then
            'Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)
            currentprice = eventArgs.price
        End If

        Return currentprice
    End Function

    Private Sub Tws1_tickPrice(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickPriceEvent) Handles Tws1.OnTickPrice

        Dim mktDataStr As String
        mktDataStr = "Tick Type: " & eventArgs.tickType & " Current Price: " & String.Format("{0:C}", eventArgs.price)

        If eventArgs.tickCount = 1 Then
            Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)                                                             ' WRITES THE CURRENT PRICE TO THE LISTBOX
            currentprice = eventArgs.price

        End If

    End Sub

    Private Sub btnGetPrice_Click(sender As Object, e As EventArgs) Handles btnGetPrice.Click

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
        Tws1.reqMktDataEx(tickId + 1, contract, "", False, Nothing)
        Tws1.tickCount = 0
        'currentprice = Tws1_tickPrice()                                                                                             ' SET CURRENT PRICE TO STOCKTICKPRICE TO BE PASSED TO CALLING FUNCTION


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

    Private Sub btnckprice_Click(sender As Object, e As EventArgs) Handles btnckprice.Click
        MsgBox(currentprice.ToString())
    End Sub

    Private Sub bntlistclear_Click(sender As Object, e As EventArgs) Handles bntlistclear.Click
        lstServerResponses.Items.Clear()
    End Sub



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
