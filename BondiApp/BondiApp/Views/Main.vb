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
    Inherits System.Windows.Forms.Form                                                                                                          ' SYSTEM INHERITANCE FOR WINDOWS FORMS

    Dim indexselected As String = ""                                                                                                            ' INITIALIZE THE INDEXSELECTED AS EMPTY - USED TO GET THE HARVEST INDEX
    Dim tickId As Integer = 0                                                                                                                   ' INITIALIZE THE TICK ID EQUAL TO ZERO - USED IN GATHERING MARKET DATA FOR A PRODUCT

    Private m_utils As New Utils                                                                                                                ' CREATES A NEW INSTANCE OF UTILS TO BE USED IN THIS FORM 
    Private m_dlgConnect As New dlgConnect                                                                                                      ' DEFINE THE CONNECT DIALOG BOX
    Private m_dlgHarvest As New dlgHarvest                                                                                                      ' DEFINE THE HARVEST DIALOG BOX
    Private m_faAcctsList As String                                                                                                             ' VARIABLE TO HOUSE THE FINANCIAL ADVISOR LIST PARAMETERS
    Private m_faAccount, faError As Boolean                                                                                                     ' VARIABLE TO HOLD FINACIAL ADVISOR STATUS SETTINGS

    Public backprices As List(Of backPrice)                                                                                                     ' CLASS DEFINITION TO HOUSE BACKPRICES FROM CSV FILES                             
    Public ticksymbol As String = ""                                                                                                            ' VARIABLE USED TO HOLD THE TICKSYMBOL WITHIN THE APPLICATION

    Public tempHarvestKey As String = ""                                                                                                        ' USED TO HOLD HARVEST INDEX KEYS IN SEARCH FUNCTIONS

    ' VARIABLES USED TO HOLD OPTION DATA
    Public product As String = ""                                                                                                               ' VARIABLE TO REPRESENT A PRODUCT USED IN TRADING (STOCK, OPTION, FUTURE) SYMBOL HOUSED HERE

    Public optionsymbol As String = ""                                                                                                          ' VARIABLE USED TO HOUSE AN OPTION SYMBOL
    Public optionexpirationdate As String = ""                                                                                                  ' VARIABLE USED TO HOUSE THE EXPIRATION DATE OF THE OPTION CONTRACT
    Public optionstrike As String = ""                                                                                                          ' VARIABLE USED TO HOUSE THE STRIKE PRICE OF THE OPTION CONTRACT
    Public optionright As String = ""                                                                                                           ' VARIABLE USED TO HOUSE THE OPTION DIRECTION TYPE (CALL OR PUT) AS C OR P
    Public optionmultiplier As String = ""                                                                                                      ' VARIABLE USED TO HOUSE THE OPTION MULTIPLIER -> TYPICALLY SET AT 100
    Public optionIV As String = ""                                                                                                              ' VARIABLE UESED TO HOUSE THE OPTIONS IMPLIED VOLATILITY (SHOULD BE CALCULATED)

    Public underlying As Double = 0                                                                                                             ' VARIABLE USED TO HOUSE THE PRICE OF THE PRODUCT FOR THE OPTION IN QUESTION
    Public strike As Double                                       ' DO i NEED TO KEEP?                                                                              ' VARIABLE USED TO HOUSE THE STRIKE PRICE OF THE OPTION 
    Public optType As String                                      ' DO i NEED TO KEEP?                                                                              ' VARIABLE USED TO HOUSE THE DIRECTION TYPE OF THE OPTION 

    Public nextValidOrderId As Integer = 0                                                                                                      ' PUBLIC VARIABLE TO HOLD CURRENTORDERID - TO BE USED TO SET THE NEXTVALIDID FOR ORDERS
    Public PriceTest As Double = 0                                                                                                              ' PUBLIC VARIABLE USED IN THE OPENING CALCULATION OF THE PRICE OF THE PRODUCT
    Public currentprice As Double = 0                                                                                                           ' VALUE RETURNED FROM THIS FUNCTION BEING CALLED
    Public cntr As Integer = 1                                                                                                                  ' VARIABLE LOOP COUNTER
    Public loopcounter As Integer                                                                                                               ' VARIABLE LOOP COUNTER
    Public datastring As String = ""                                                                                                            ' VARIABLE USED TO HOLD TEXT TO BE COMMUNICATED TO THE USER FROM THE APPLICATION

    Public UpdateBuy As Boolean = False                         ' DO I NEED TO KEEP?
    Public matchid As Integer                                                                                                                   ' VARIABLE USED TO HOUSE THE ID OF THE CORRESPONDING BUY TO OPEN ORDER FOR SELL TO CLOSE ORDERS

    ' FLAGS USED IN THE ROBOT PROCESSING
    Public ManualOrder As Boolean                                                                                                               ' VARIABLE USED TO INDICATE THAT THE ORDER SENT IS A MANUAL ORDER ALSO USED TO START WILLIE
    Public SendSingleOrder As Boolean                                                                                                           ' PUBLIC VARIABLE INDICAITNG WHETHER THIS IS A SINGLE ORDER OR NOT
    Public RobotOn As Boolean                                                                                                                   ' INDICATES THAT THE ROBOT IS RUNNING IN THE OPENORDEREX SUB TO ADD ORDERS
    Dim connecting As Boolean = True                                                                                                            ' VARIABLE INDICATING THE APP IS CONNECTING TO THE TWS PLATFORM VIA THE API

    Public WithEvents Tws1 As Tws

    ' THE CODE FOR THE APPLICATION IS SET UP IN LOGICAL BLOCKS WITH 5 LINES SPACED BETWEEN THE BLOCKS.
    ' BLOCK 1: APPLICATION & FORM LOAD CODE

    Public Sub New()
        MyBase.New()                                                                                                                            ' SET THE BASE TO A NEW INSTANCE
        Tws1 = New Tws(Me)                                                                                                                      ' INITIALIZE TWS WITHIN THE APPLICATION TO A NEW INSTANCE
        InitializeComponent()                                                                                                                   ' INITIALIZE ALL COMPONENTS
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblBuild.Text = "Build Date: " & String.Format("{0: MM.dd.yy}", #05/01/2018#)                                                           ' DISPLAY THE LATEST BUILD DATE

        Call m_utils.init(Me)                                                                                                                   ' INITIALIZES THE UTILS TO SEND AND READ MESSAGES FROM THE API
        Timer60Sec.Enabled = True                                                                                                               ' INITIALIZES THE 60 SECOND TIME TO REQUEST PRICING 

        Try                                                                                                                                     ' OPEN THE TRY / CATCH PROCESS

            Using db As BondiModel = New BondiModel()                                                                                           ' INITIALIZE THE MODEL TO THE DB VARIABLE FOR USE IN GETTING DATA FROM THE DATATABLES
                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                                   ' ESTABLISH THE LIST TO HOUSE THE HARVEST INDEX RECORDS
                hi = db.HarvestIndexes.Where(Function(s) s.active = True).AsEnumerable.[Select](Function(x) New HarvestIndex With
                                                {.harvestKey = x.harvestKey, .name = x.name}).ToList()                                          ' PULL THE ACTIVE HARVEST INDEX RECORDS AND ADD THEM TO THE LIST 

                cmbWillie.DataSource = hi                                                                                                       ' SET THE DROPDOWN DATASOURCE EQUAL TO THE INDEX LIST
                cmbWillie.DisplayMember = "name"                                                                                                ' DROPDOWN DISPLAYS THE NAME FIELD OF THE LIST
                cmbWillie.ValueMember = "harvestkey"                                                                                            ' DROPDOWN VALUE TIED TO NAME IS THE HARVESTKEY FIELD
                cmbWillie.SelectedIndex = 0                                                                                                     ' SET THE INDEX DISPLAYED AS THE FIRST ONE

                hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()                          ' INITIALIZE THE HARVEST INDEX DATABASE RECORDS TO A LIST
                ticksymbol = hi.FirstOrDefault().product                                                                                        ' ASSIGN THE FIRST HARVEST INDEX PRODUCT SYMBOL TO TICKSYMBOL WITH THE FORM LOAD

            End Using                                                                                                                           ' END USING DB AS THE DATABSE MODEL

        Catch ex As Exception                                                                                                                   ' ANY ERROR CAUGHT HERE AND DISPLAYED TO THE USER
            ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.
            Call m_utils.addListItem(Utils.List_Types.ERRORS, "Form Load Error: " & ex.ToString())                                              ' ADD DESCRIPTION TO THE LIST BOX TO INDICATE ERROR STATUS
            'MsgBox("Load Error " & ex.ToString())
        End Try                                                                                                                                 ' CLOSE THE TRY / CATCH PROCESS 

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()                                                                                                                              ' CLOSE THE APPLICATION
    End Sub






    ' BLOCK 2: CODE INITIATED BY THE VIEW THE INTERACTS WITH TWS VIA THE API CONTROLS AND CODE USED TO CONNECT TO THE TWS API   

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click

        datastring = "Connected to TWS " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                                                ' VARIABLE USED TO SUPPLY MESSAGES TO THE USER ON PROCESSING AND CYCLETIME        
        m_faAccount = False                                                                                                                             ' THIS IS NOT A FINANCIAL ADVISORS ACCOUNT SET THE VARIABLE ACCORDINGLY TO INDICATE NOT A FA ACCOUNT
        Dim msg As String = ""                                                                                                                          ' VARIABLE USED TO SUPPLY DATA TO THE LISTBOX DETERMINE IF I WANT TO KEEP THIS VAR NAME.

        lstConnectionResponses.Items.Clear()                                                                                                            ' CLEAR ANY CONNECTION MESSAGE BEFORE THE NEXT ACTION IS TAKEN

        ' The connection settings will be established in the USER SETTINGS and populated based on the login process.
        ' The only setting that the user will be able to change here is the client id in the event they are running 
        ' two instances of the app.  Need to make sure I want that to be able to happen.

        Try
            Tws1.connect(txtHost.Text, txtPort.Text, txtClientId.Text, False, "")                                                                       ' TWS CALL TO CONNECT THE APPLICATION TO THE TWS PLATFORM USING THE API

            If Tws1.serverVersion() > 0 Then     ' WORK ON SETTING THIS IN THE CONNECTION tws PASS AND USING A GLOBAL VARIABLE TO MAKE MORE EFFICIENT   ' IF THE RESPONSE BACK IS THE SERVER VERSION THAT IS THE INDICATION THAT THE APP IS CONNECTED TO TWS
                msg = "CONNECTING - ClientID: " & txtClientId.Text & " SV: " & Tws1.serverVersion() & " at " & Tws1.TwsConnectionTime()                 ' SET THE MSG TO THE CONNECTION STRING AND TIME OF CONNECTION
                Call m_utils.addListItem(Utils.List_Types.CONNECTION_RESPONSES, msg)                                                                    ' CALL THE ADD LIST ITEM FUNCTION TO ADD THE MESSAGE TO THE LISTBOX                 
                '    'Call m_utils.addListItem(Utils.List_Types.CONNECTION_RESPONSES, "------------------------------")                                 ' CALL THE ADD A BLANK LINE TO THE MESSAGE TO THE LISTBOX 
            End If

            getMarketDataTick(ticksymbol)                                                                                                               ' GET THE TICK PRICE OF THE CURRENT TICKSYMBOL IN THE SYSTEM

            datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                                             ' SET THE DATASTRING TO THE EXIT TIME OF THE SUB TO DISPLAY FULL CYCLE TIME OF THE CONNECTION
            lblStatus.Text = datastring                                                                                                                 ' SEND THE DATASTRING TO THE FORM VIEW 

        Catch ex As Exception                                                                                                                           ' IF THERE IS AN ERROR CATCH IT HERE
            ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.            
            MsgBox("Connection Error: " & ex.ToString())                                                                                                ' MESSAGE WHERE THE ERROR OCCURRED - IN WHICH SUB - THIS CODE MAY BE COMMENTED OUT LATER            
        End Try

    End Sub

    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click

        lstConnectionResponses.Items.Clear()                                                                                                            ' CLEAR ANY CONNECTION MESSAGE BEFORE THE NEXT ACTION IS TAKEN
        datastring = "Disonnected from TWS at " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                                         ' VARIABLE USED TO SUPPLY MESSAGES TO THE USER ON PROCESSING AND CYCLETIME

        Try

            Tws1.disconnect()                                                                                                                           ' CALLED FUNCTION TO DISCONNECT THE APP FROM THE TWS PLATFORM USING THE API

            datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                                             ' INITIALIZE THE DATASTRING WITH THE CURRENT TIME CLOSING THE TIME SPAN LOOP
            Call m_utils.addListItem(Utils.List_Types.CONNECTION_RESPONSES, datastring)                                                                 ' CALL THE ADD LIST ITEM FUNCTION TO ADD THE MESSAGE TO THE LISTBOX 

            lblStatus.Text = datastring                                                                                                                 ' PROVIDE THE USER WITH THE STATUS MESSAGE OF THIS SUBROUTINE
        Catch ex As Exception
            MsgBox("Disconnection Error " & ex.ToString())                                                                                              ' MESSAGE WHERE THE ERROR OCCURRED - IN WHICH SUB - THIS CODE MAY BE COMMENTED OUT LATER  
        End Try

    End Sub

    Private Sub btnSendOrder_Click(sender As Object, e As EventArgs) Handles btnSendOrder.Click

        Dim datastring As String = "Order Sent: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                   ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP
        Dim priceint As Double = 0                                                                                                  ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        Dim checksum As Double = 0                                                                                                  ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        Dim cprice As Double = 0                                                                                                    ' VARIABLE USED TO HOLD THE STARTING OPEN TO BUY PRICE FOR EACH USER & INDEX
        Dim Symbol As String = ""                                                                                                   ' VARIABLE USED TO HOLD THE SYMBOL FOR THE USER & INDEX
        Dim opentrigger As Double = 0                                                                                               ' VARIABLE USED TO HOLD THE TRIGGER FOR THE BUY TO OPEN POSITIONS
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                       ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                                ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA


        'SendSingleOrder = True

        Dim userid As Guid                                                                                                          ' VARIABLE USED TO HOLD THE CURRENT USERS USERID (NEED TO DETERMINE IF I NEED TO KEEP THIS OR NOT)
        'ManualOrder = True                                                                                                         ' SET FLAG TO TRUE AS ORDER IS MANUAL - THIS WILL ADD THE ORDER DETAILS TO THE STOCKORDER TABLE
        'connecting = False                                                                                                         ' FLAG USED TO INDICATE THAT THIS CALL IS NOT DUE TO CONNECTING TO TWS
        'cntr = 1                                                                                                                   ' COUNTER FLAG USED TO ELIMINATE THE TWO CYCLES THROUGH THE ORDER PROCESSING 
        Try

            Using db As BondiModel = New BondiModel()                                                                               ' DATABASE MODEL USED TO CAPTURE THE ROBOTS DATA

                Dim ul As List(Of User) = New List(Of User)()                                                                       ' GET THE USERID OF THE USER TO CHECK FOR ORDERS FOR THIS ID AS WELL AS THE INDEX
                ul = db.Users.AsEnumerable.Where(Function(u) u.UserName = "boss").ToList()                                          ' BUILD THE LIST OF USERS BASED ON THIS USERNAME
                userid = ul.FirstOrDefault().UserId                                                                                 ' SET THE USERID EQUAL TO THE USERS USERID - CONSIDER DOING THIS IN A PUBLIC VAR AT LOGIN

                'Dim so As List(Of stockorder) = New List(Of stockorder)()                                                           ' INITIALIZE THE STOCK ORDER LIST TO BE USED TO GET THE STOCK RECORD     
                'so = db.stockorders.AsEnumerable.Where(Function(s) s.roboIndex = cmbWillie.SelectedValue).ToList()                  ' BUILD THE LIST OF STOCKORDERS FOR THIS USER AND THIS INDEX (MAY NOT NEED TO DO THIS AS INDEXES ARE UNIQUE BY USER. - REFACTOR)

                ' THE ORDER COUNTER DOES NOT NEED TO BE CHECKED HERE AS AN ORDER IS BEING SENT NO MATTER WHAT
                'If so.Count = 0 Then                                                                                               ' INDICATES THAT THIS IS THE FIRST ORDER CALC OPEN PRICE AND SEND FIRST BUY TO OPEN ORDER

                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                       ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
                hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()              ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

                contract.Symbol = hi.FirstOrDefault().product.ToUpper()                                                             ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
                contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                                       ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
                contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                                      ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
                contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                                          ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

                ' THE USER CAN CHOOSE TO ENTER A PRICE OR HAVE THE NEAREST PRICE SET BY THE INDEX AND CALCULATIONS.
                ' If so.Count > 0 Then
                ' ADD A CHECKBOX ON THE FORM TO INDICATE THAT THIS IS THE PRICE THE USER WANTS TO SUBMIT VERSUS IF A RECORD EXISTS OR NOT SEND ORDER ONLY
                cprice = txtPrice.Text
                'Else
                'priceint = Int(currentprice)                                                                                        ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
                'checksum = currentprice - priceint                                                                                  ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
                'cprice = (Int(checksum / hi.FirstOrDefault.opentrigger) * hi.FirstOrDefault.opentrigger + priceint)                 ' CALCULATE THE STARTING BUY TO OPEN PRICE 
                'End If

                order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                                           ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
                order.TotalQuantity = hi.FirstOrDefault().shares                                                                    ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
                order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                                                   ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)
                order.OrderId = nextValidOrderId                                                                                    ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
                order.Action = txtAction.Text.ToUpper()                                                                             ' SET THE ORDER ACTION 
                order.LmtPrice = cprice                                                                                             ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

                Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

                'End If

            End Using
        Catch ex As Exception
            ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.
            Call m_utils.addListItem(Utils.List_Types.ERRORS, "Form Load Error: " & ex.ToString())                                  ' ADD DESCRIPTION TO THE LIST BOX TO INDICATE ERROR STATUS
            'MsgBox("Load Error " & ex.ToString())
        End Try                                                                                                                     ' CLOSE THE TRY / CATCH PROCESS 

        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                         ' ADD THE CURRENT FINISH TIME TO THE DATASTRING TO GET THE FULL CYCLE TIME
        lblStatus.Text = datastring                                                                                             ' DISPLAY THE DATASTRING VALUE TO THE USER USING THE STATUS LABEL

    End Sub

    Private Sub btnModOrder_Click(sender As Object, e As EventArgs) Handles btnModOrder.Click

        ' TODO:  DETERMINE HOW I WANT THE CONTRACT SYMBOL POPULATED.  TAKE FROM USER OR PULL FROM THE DATABASE

        Dim datastring As String = "Order Sent: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "               ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP

        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                   ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                            ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

        contract.Symbol = txtModifySymbol.Text                                                                                  ' SET THE SYMBOL FOR THE CONTRACT TO THE ENTERED SYMBOL BY THE USER
        contract.SecType = "STK"                                                                                                ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE SUPPLIED SECURITY TYPE
        contract.Currency = "USD"                                                                                               ' SET THE CURRENCY TYPE FOR THE CONTRACT TO US DOLLARS
        contract.Exchange = "SMART"                                                                                             ' SET THE EXCHANGE FOR THE CONTRACT TO THE SMART EXCHANGE

        order.OrderId = txtModifyOrderId.Text                                                                                   ' SET THE ORDER ID TO THE SUPPLIED ORDER ID FROM THE USER

        order.Action = txtModifyAction.Text.ToUpper()                                                                           ' SET THE ORDER ACTION TO THE SUPPLIED BUY OR SELL ACTION SUPPLIED BY THE USER
        order.OrderType = txtModifyType.Text.ToUpper()                                                                          ' SET THE ORDER TYPE TO THE SUPPLIED ORDER TYPE BY THE USER
        order.LmtPrice = txtModifyPrice.Text                                                                                    ' SET THE LIMIT PRICE TO THE SUPPLIED LIMIT PRICE BY THE USER
        order.TotalQuantity = txtModifyQty.Text                                                                                 ' SET THE QUANTITY TO THE SUPPLIED QUANTITY BY THE USER

        Try
            Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO PLACE THE ORDER SINCE IT WILL HAVE THE SAME ORDER ID ONLY THE PARAMETERS THAT HAVE CHANGED WILL BE MODIFIED

        Catch ex As Exception
            ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.
            Call m_utils.addListItem(Utils.List_Types.ERRORS, "Form Load Error: " & ex.ToString())                              ' ADD DESCRIPTION TO THE LIST BOX TO INDICATE ERROR STATUS

        End Try

        datastring = "Order Modified: " & DateTime.Parse(Now()).ToShortTimeString() & " Order Id:" &
            order.OrderId & " Symbol: " & contract.Symbol & " Total Shares: " & order.TotalQuantity &
            " Price: " & order.LmtPrice & " " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                           ' ADD PROCESSING DETAILS FOR THE MODIFICATION OF THE ORDER TO THE DATASTRING WITH THE CURRENT TIME OF FINISH 
        lblStatus.Text = datastring                                                                                             ' DISPLAY THE DATASTRING VALUE TO THE USER USING THE STATUS LABEL

    End Sub

    Private Sub btnCancelOrder_Click(sender As Object, e As EventArgs) Handles btnCancelOrder.Click

        Dim datastring As String = "Order Sent: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "               ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP

        Try
            Call Tws1.cancelOrder(txtCancelId.Text)                                                                             ' CALLED FUNCTION TO CANCEL THE ORDER OF THE ORDER NUMBER INPUT IN THE TEXTBOX 
        Catch ex As Exception
            ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.
            Call m_utils.addListItem(Utils.List_Types.ERRORS, "Form Load Error: " & ex.ToString())                              ' ADD DESCRIPTION TO THE LIST BOX TO INDICATE ERROR STATUS

        End Try

        datastring = "Order Cancelled: " & DateTime.Parse(Now()).ToShortTimeString() & " Order Id:" &
            txtCancelId.Text & " " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                      ' ADD PROCESSING DETAILS FOR THE MODIFICATION OF THE ORDER TO THE DATASTRING WITH THE CURRENT TIME OF FINISH 
        lblStatus.Text = datastring                                                                                             ' DISPLAY THE DATASTRING VALUE TO THE USER USING THE STATUS LABEL

    End Sub

    Private Sub btnSendOption_Click(sender As Object, e As EventArgs) Handles btnSendOption.Click

        ' TODO: WORK ON GETTING PARAMETERS DYNAMICALLY FROM THE DATABASE OR THE API - EXAMPLE: OPTION PRICE SHOULD BE SUPPLIED BY THE TICK REQUEST TO GET THE CURRENT OPTION PRICE. DISPLAY FOR USER TO DECIDE TO USE OR SET ANOTHER PRICE TO SEND.

        ' SEND HARD CODED OPTION ORDER
        Dim datastring As String = "Option Order Sent: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "            ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP

        Dim priceint As Double = 0                                                                                                  ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        Dim checksum As Double = 0                                                                                                  ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        Dim cprice As Double = 0                                                                                                    ' VARIABLE USED TO HOLD THE STARTING OPEN TO BUY PRICE FOR EACH USER & INDEX
        Dim Symbol As String = ""                                                                                                   ' VARIABLE USED TO HOLD THE SYMBOL FOR THE USER & INDEX
        Dim opentrigger As Double = 0                                                                                               ' VARIABLE USED TO HOLD THE TRIGGER FOR THE BUY TO OPEN POSITIONS
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                       ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                                ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

        SendSingleOrder = True

        Dim userid As Guid                                                                                                          ' VARIABLE USED TO HOLD THE CURRENT USERS USERID (NEED TO DETERMINE IF I NEED TO KEEP THIS OR NOT)
        ManualOrder = True                                                                                                          ' SET FLAG TO TRUE AS ORDER IS MANUAL - THIS WILL ADD THE ORDER DETAILS TO THE STOCKORDER TABLE
        'connecting = False                                                                                                         ' FLAG USED TO INDICATE THAT THIS CALL IS NOT DUE TO CONNECTING TO TWS
        'cntr = 1                                                                                                                   ' COUNTER FLAG USED TO ELIMINATE THE TWO CYCLES THROUGH THE ORDER PROCESSING 

        Using db As BondiModel = New BondiModel()                                                                                   ' DATABASE MODEL USED TO CAPTURE THE ROBOTS DATA

            Dim ul As List(Of User) = New List(Of User)()                                                                           ' GET THE USERID OF THE USER TO CHECK FOR ORDERS FOR THIS ID AS WELL AS THE INDEX
            ul = db.Users.AsEnumerable.Where(Function(u) u.UserName = "boss").ToList()                                              ' BUILD THE LIST OF USERS BASED ON THIS USERNAME
            userid = ul.FirstOrDefault().UserId                                                                                     ' SET THE USERID EQUAL TO THE USERS USERID - CONSIDER DOING THIS IN A PUBLIC VAR AT LOGIN

            Dim so As List(Of stockorder) = New List(Of stockorder)()                                                               ' INITIALIZE THE STOCK ORDER LIST TO BE USED TO GET THE STOCK RECORD     
            so = db.stockorders.AsEnumerable.Where(Function(s) s.roboIndex = cmbWillie.SelectedValue).ToList()                      ' BUILD THE LIST OF STOCKORDERS FOR THIS USER AND THIS INDEX (MAY NOT NEED TO DO THIS AS INDEXES ARE UNIQUE BY USER. - REFACTOR)

            ' THE ORDER COUNTER DOES NOT NEED TO BE CHECKED HERE AS AN ORDER IS BEING SENT NO MATTER WHAT
            'If so.Count = 0 Then                                                                                                   ' INDICATES THAT THIS IS THE FIRST ORDER CALC OPEN PRICE AND SEND FIRST BUY TO OPEN ORDER

            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                           ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
            hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()                  ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

            contract.Symbol = hi.FirstOrDefault().product.ToUpper()                                                                 ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
            contract.SecType = "OPT"        'hi.FirstOrDefault().stocksectype.ToUpper()                                             ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
            contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                                          ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
            contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                                              ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

            contract.LastTradeDateOrContractMonth = "20180518"
            contract.Strike = 44
            contract.Right = "P"

            ' THE USER CAN CHOOSE TO ENTER A PRICE OR HAVE THE NEAREST PRICE SET BY THE INDEX AND CALCULATIONS.
            ' If so.Count > 0 Then
            ' ADD A CHECKBOX ON THE FORM TO INDICATE THAT THIS IS THE PRICE THE USER WANTS TO SUBMIT VERSUS IF A RECORD EXISTS OR NOT SEND ORDER ONLY
            cprice = 0.88               ' txtPrice.Text
            'Else
            'priceint = Int(currentprice)                                                                                        ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
            'checksum = currentprice - priceint                                                                                  ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
            'cprice = (Int(checksum / hi.FirstOrDefault.opentrigger) * hi.FirstOrDefault.opentrigger + priceint)                 ' CALCULATE THE STARTING BUY TO OPEN PRICE 
            'End If

            order.OrderType = "LMT"                 ' hi.FirstOrDefault().ordertype.ToUpper()                                   ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
            order.TotalQuantity = 1                 ' hi.FirstOrDefault().shares                                                ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
            order.Tif = "GTC"                       ' hi.FirstOrDefault().inforce.ToUpper()                                     ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)
            order.OrderId = nextValidOrderId                                                                                    ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
            order.Action = "BUY"                    ' txtAction.Text.ToUpper()                                                  ' SET THE ORDER ACTION 
            order.LmtPrice = cprice                                                                                             ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

            Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

            'End If

        End Using

        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                         ' ADD THE CURRENT FINISH TIME TO THE DATASTRING TO GET THE FULL CYCLE TIME
        lblConStatus.Text = datastring                                                                                          ' DISPLAY THE DATASTRING VALUE TO THE USER THROUGH THE STATUS LABEL

    End Sub

    ' TODO: COMMECT THESE CODE BLOCKS AND ADD ERROR HANDLING.
    ' TODO: TEST & VALIDATE THESE CODE BLOCKS - INTEGRATE THEM AS TO HOW I WANT TO USE THEM IN THE ROBOT

    Private Sub btnAddLeg_Click(sender As Object, e As EventArgs) Handles btnAddLeg.Click
        Dim contract As Contract = New Contract
        contract.Symbol = txtSpreadSymbol.Text
        contract.SecType = "OPT"
        contract.Exchange = "SMART"
        contract.Currency = "USD"
        contract.LastTradeDateOrContractMonth = txtSpreadExp.Text
        contract.Strike = txtSpreadStrike.Text
        contract.Right = txtSpreadRight.Text
        Tws1.reqContractDetailsEx(1, contract)
    End Sub

    Private Sub btnSpreadOrder_Click(sender As Object, e As EventArgs) Handles btnSpreadOrder.Click
        If (grdContracts.Rows.Count > 0) Then
            Dim order As Order = New Order()
            order.OrderType = "LMT"                                                        ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
            order.TotalQuantity = 1                                                                                           ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)
            order.Action = "BUY"
            order.LmtPrice = 1.2
            order.OrderId = nextValidOrderId
            Dim contract As Contract = New Contract
            contract.Symbol = grdContracts.Rows(0).Cells(0).Value
            contract.SecType = "BAG"
            contract.Exchange = "SMART"
            contract.Currency = "USD"
            contract.LastTradeDateOrContractMonth = grdContracts.Rows(0).Cells(1).Value
            contract.Strike = grdContracts.Rows(0).Cells(2).Value
            contract.Right = grdContracts.Rows(0).Cells(3).Value
            contract.ComboLegs = New List(Of ComboLeg)
            For index = 0 To grdContracts.Rows.Count - 1
                Dim leg1 As ComboLeg = New ComboLeg
                leg1.ConId = grdContracts.Rows(index).Cells(4).Value
                leg1.Ratio = 1
                leg1.Action = "BUY"
                leg1.Exchange = "SMART"
                contract.ComboLegs.Add(leg1)
            Next
            Call Tws1.placeOrderEx(order.OrderId, contract, order)
        End If

    End Sub






    ' BLOCK 3: ROBOT CODE USED IN APPLICATION

    Private Sub cmbWillie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWillie.SelectedIndexChanged

        ' If connected to TWS get the symbol from the database and get current price.

        Dim product As String = ""                                                                                                          ' VARIABLE USED TO HOUSE THE SYMBOL FOR THE INDEX SELECTED
        indexselected = cmbWillie.SelectedValue.ToString()                                                                                  ' SETS INDEXSELECTED TO THE CURRENT VALUE IN THE COMBOBOX

        If (Tws1.serverVersion() > 0) Then                                                                                                  ' CHECK IF TWS IS LOGGED IN AND THE APP IS CONNECTED BY GETTING THE SERVER VERSION

            Dim contract As IBApi.Contract = New IBApi.Contract()                                                                           ' ESTABLISH A NEW CONTRACT CLASS

            Using db As BondiModel = New BondiModel()                                                                                       ' DATABASE MODEL USING ENTITY FRAMEWORK

                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                               ' INITIALIZE A LIST OF THE HARVEST INDEXES
                hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()                      ' GET THE SELECTED INDEX FROM THE DATABASE 
                product = hi.FirstOrDefault().product                                                                                       ' SET THE PRODUCT VARIABLE EQUAL TO THE SYMBOL OF THE INDEX SELECTED

                'POPULATE THE SEND ORDER TEXTBOXES WITH THE INDEX SELECTED DATA.
                txtOrderId.Text = nextValidOrderId                                                                                          ' UPDATE THE ORDER ID TEXTBOX WITH THE NEXT VALID ID
                txtSymbol.Text = hi.FirstOrDefault().product                                                                                ' UPDATE THE SYMBOL TEXTBOX WITH THE INDEX SYMBOL (PRODUCT)
                txtAction.Text = "BUY"                                                                                                      ' UPDATE THE ACTION TEXTBOX WITH THE DEFAULT ACTION OF BUY
                txtType.Text = hi.FirstOrDefault().ordertype                                                                                ' UPDATE THE ORDER TYPE TEXTBOX WIHT THE INDEX ORDER TYPE
                txtQty.Text = hi.FirstOrDefault().shares                                                                                    ' UPDATE THE QUANTITY TEXTBOX WITH THE INDEX QUANTITY VALUE

                txtGetPriceSymbol.Text = product                                                                                            ' UPDATE THE GETPRICE TEXTBOX WITH THE INDEX SYMBOL
                ticksymbol = product                                                                                                        ' SET THE TICKSYMBOL EQUAL TO THE INDEX SYMBOL
                contract.Symbol = product                                                                                                   ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT

                contract.SecType = "STK"                                                                                                    ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
                contract.Currency = "USD"                                                                                                   ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
                contract.Exchange = "SMART"                                                                                                 ' INITIALIZE EXCHANGE USED FOR THE CONTRACT

                Tws1.reqMarketDataType(3)                                                                                                   ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
                Tws1.reqMktDataEx(tickId + 1, contract, "", False, Nothing)                                                                 ' CALL REQUEST MARKET DATA FOR THE INDEX SYMBOL
                Tws1.tickCount = 0                                                                                                          ' INITIALIZE THE TICKCOUNT VARIABLE TO ZERO

            End Using                                                                                                                       ' CLOSE THE ENTITY MODEL FRAMEWORK

        End If                                                                                                                              ' CLOSE THE CHECK ON THE TWS SERVER VERSION

    End Sub

    Private Sub btnWillie_Click(sender As Object, e As EventArgs) Handles btnWillie.Click

        ' TODO:  04.10.18 - DOCUMENT CODE AND ADD ERROR HANDLING


        ' Use this code to test the initial sending of an order to fill with the callback steps to set up for Willie

        Dim datastring As String = "Order Sent: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "               ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP
        Dim priceint As Double = 0                                                                                              ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        Dim checksum As Double = 0                                                                                              ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        Dim cprice As Double = 0                                                                                                ' VARIABLE USED TO HOLD THE STARTING OPEN TO BUY PRICE FOR EACH USER & INDEX
        Dim Symbol As String = ""                                                                                               ' VARIABLE USED TO HOLD THE SYMBOL FOR THE USER & INDEX
        Dim opentrigger As Double = 0                                                                                           ' VARIABLE USED TO HOLD THE TRIGGER FOR THE BUY TO OPEN POSITIONS
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                   ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                            ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA


        SendSingleOrder = True

        Dim userid As Guid                                                                                                      ' VARIABLE USED TO HOLD THE CURRENT USERS USERID (NEED TO DETERMINE IF I NEED TO KEEP THIS OR NOT)
        ManualOrder = True                                                                                                      ' SET FLAG TO TRUE AS ORDER IS MANUAL - THIS WILL ADD THE ORDER DETAILS TO THE STOCKORDER TABLE
        RobotOn = True                                                                                                          ' FLAG USED TO INDICATE THAT THIS CALL IS NOT DUE TO CONNECTING TO TWS
        'cntr = 1                                                                                                               ' COUNTER FLAG USED TO ELIMINATE THE TWO CYCLES THROUGH THE ORDER PROCESSING 

        Using db As BondiModel = New BondiModel()                                                                               ' DATABASE MODEL USED TO CAPTURE THE ROBOTS DATA

            Dim ul As List(Of User) = New List(Of User)()                                                                       ' GET THE USERID OF THE USER TO CHECK FOR ORDERS FOR THIS ID AS WELL AS THE INDEX
            ul = db.Users.AsEnumerable.Where(Function(u) u.UserName = "boss").ToList()                                          ' BUILD THE LIST OF USERS BASED ON THIS USERNAME
            userid = ul.FirstOrDefault().UserId                                                                                 ' SET THE USERID EQUAL TO THE USERS USERID - CONSIDER DOING THIS IN A PUBLIC VAR AT LOGIN

            Dim so As List(Of stockorder) = New List(Of stockorder)()                                                           ' INITIALIZE THE STOCK ORDER LIST TO BE USED TO GET THE STOCK RECORD     
            so = db.stockorders.AsEnumerable.Where(Function(s) s.roboIndex = cmbWillie.SelectedValue).ToList()                 ' BUILD THE LIST OF STOCKORDERS FOR THIS USER AND THIS INDEX (MAY NOT NEED TO DO THIS AS INDEXES ARE UNIQUE BY USER. - REFACTOR)

            ' THE ORDER COUNTER DOES NOT NEED TO BE CHECKED HERE AS AN ORDER IS BEING SENT NO MATTER WHAT
            'If so.Count = 0 Then                                                                                               ' INDICATES THAT THIS IS THE FIRST ORDER CALC OPEN PRICE AND SEND FIRST BUY TO OPEN ORDER

            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                       ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
            hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()             ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

            contract.Symbol = hi.FirstOrDefault().product.ToUpper()                                                             ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
            contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                                       ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
            contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                                      ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
            contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                                          ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

            ' THE USER CAN CHOOSE TO ENTER A PRICE OR HAVE THE NEAREST PRICE SET BY THE INDEX AND CALCULATIONS.
            'If so.Count > 0 Then
            ' ADD A CHECKBOX ON THE FORM TO INDICATE THAT THIS IS THE PRICE THE USER WANTS TO SUBMIT VERSUS IF A RECORD EXISTS OR NOT SEND ORDER ONLY

            'cprice = txtPrice.Text
            'Else
            priceint = Int(currentprice)                                                                                        ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
            checksum = currentprice - priceint                                                                                  ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
            cprice = (Int(checksum / hi.FirstOrDefault.opentrigger) * hi.FirstOrDefault.opentrigger + priceint)                 ' CALCULATE THE STARTING BUY TO OPEN PRICE 
            'End If

            order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                                           ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
            order.TotalQuantity = hi.FirstOrDefault().shares                                                                    ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
            order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                                                   ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)
            order.OrderId = nextValidOrderId                                                                                    ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
            order.Action = txtAction.Text.ToUpper()                                                                             ' SET THE ORDER ACTION 

            order.LmtPrice = cprice               ' SET TO REDUCE THE PRICE BY  $1.00 FOR TESTING REMOVE WHEN DONE.             ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

            Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

            'End If

        End Using


        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                         ' ADD THE CURRENT FINISH TIME TO THE DATASTRING TO GET THE FULL CYCLE TIME
        lblConStatus.Text = datastring                                                                                          ' DISPLAY THE DATASTRING TO THE USER

    End Sub

    Private Sub btnckprice_Click(sender As Object, e As EventArgs) Handles btnckprice.Click
        MsgBox(currentprice.ToString())                                                                                         ' DISPLAY THE CURRENT PRICE TO THE USER VIA A MESSAGE BOX
    End Sub

    Private Sub bntlistclear_Click(sender As Object, e As EventArgs) Handles bntlistclear.Click
        lstServerResponses.Items.Clear()                                                                                        ' CLEAR THE MESSAGES IN THE SERVER RESPONSE LISTBOX
    End Sub

    Private Sub TimerAtTime_Tick(sender As Object, e As EventArgs) Handles TimerAtTime.Tick

        Dim now As DateTime = DateTime.Now                                                                                      ' SET THE NOW VARIABLE EQUAL TO DATE AND TIME OF NOW
        Dim tickTime As String = System.Configuration.ConfigurationManager.AppSettings.Get("hoursmin")                          ' SET THE TICKTIME VARIABLE CONFIGURATION TO HOURS THEN MINUTES
        Dim hours As Integer = Integer.Parse(tickTime.Split(":").GetValue(0))                                                   ' PARSE HOURS FROM TICKTIME
        Dim min As Integer = Integer.Parse(tickTime.Split(":").GetValue(1))                                                     ' PARSE MINUTES FRIN TICKTIME

        If (now.TimeOfDay.Hours.Equals(hours) And now.TimeOfDay.Minutes.Equals(min)) Then                                       ' IF THE HOURS AND MINUTES EQUAL THE TIME SET IN THE CONFIGURATION SETTINGS PERFORM ACTIONS
            getMarketDataTick(ticksymbol)                                                                                       ' GET THE TICKDATA FOR THE CURRENT TICKSYMBOL
            TimerAtTime.Stop()                                                                                                  ' ONCE COMPLETE DO NOT RUN AGAIN
            TimerAtTime.Enabled = False                                                                                         ' DISABLE THE TIMER
        End If

    End Sub

    Private Sub ckRobotOn_CheckedChanged(sender As Object, e As EventArgs) Handles ckRobotOn.CheckedChanged

        If ckRobotOn.Checked = True Then
            RobotOn = True                                                                                  ' SET THE FLAG FOR THE ROBOT ON TO TRUE 
        Else
            RobotOn = False                                                                                 ' SET THE FLAG FOR THE ROBOT ON TO FALSE
        End If

    End Sub

    Private Sub getMarketDataTick(stk As String)

        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                           ' ESTABLISH A NEW CONTRACT CLASS

        If ticksymbol = "" Then                                                                                                         ' CHECK TO SEE IF THE TICKSYMBOL HAS A VALUE
            Exit Sub                                                                                                                    ' IF THERE IS NO VALUE IN TICKSYMBOL THEN EXIT THE SUBROUTINE
        End If                                                                                                                          ' EXIT THE CONDITIONAL CHECK

        contract.Symbol = ticksymbol                                                                                                    ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT

        contract.SecType = "STK"                    ' SET TO STK for STOCK tick price                                                   ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Currency = "USD"                                                                                                       ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Exchange = "SMART"                                                                                                     ' INITIALIZE EXCHANGE USED FOR THE CONTRACT

        Tws1.reqMarketDataType(3)                                                                                                       ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(tickId + 1, contract, "", False, Nothing)                                                                     ' CALL THE FUNCTION TO GET THE MARKET DATA FROM TWS VIA THE API CALL
        Tws1.tickCount = 0                                                                                                              ' SET THE TICKCOUNT EQUAL TO ZERO (FLAG TO CONTROL LOOPS)

    End Sub

    ' NEED TO VALIDATE THAT THESE STILL WORK AND THAT THEY ARE NEEDED.  btnOpPrice & getOptionPrice
    Private Sub btnOpPrice_Click(sender As Object, e As EventArgs) Handles btnOpPrice.Click

        ' THIS BUTTON TESTS CALCUALTING THE PRICE OF AN OPTION FOR A SPECIFIC UNDERLYING STOCK AT A SPECIFIED STRIKE AND iv LEVEL

        ' Assign inputs to variables
        optionsymbol = txtOptionSymbol.Text
        optionexpirationdate = txtOptionExpirationDate.Text
        optionstrike = txtOptionStrike.Text
        optionright = txtOptionRight.Text
        optionmultiplier = "100" 'txtOptionMultiplier.Text
        optionIV = txtOptionIV.Text


        getOptionPrice(optionsymbol)

    End Sub

    Private Sub getOptionPrice(ByVal optionsymbol As String)

        Dim contract As Contract = New Contract
        product = optionsymbol
        contract.Symbol = optionsymbol                                                                                                  ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
        contract.SecType = "STK"                                                                                                        ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Currency = "USD"                                                                                                       ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Exchange = "SMART"                                                                                                     ' INITIALIZE EXCHANGE USED FOR THE CONTRACT

        Tws1.reqMarketDataType(3)                                                                                                       ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(tickId + 1, contract, "", False, Nothing)
        Tws1.tickCount = 0


        MsgBox(underlying.ToString())



        contract.Symbol = optionsymbol
        contract.SecType = "OPT"
        'contract.Exchange = "SMART"
        'contract.Currency = "USD"
        contract.Strike = 165
        contract.Right = "P"
        contract.Multiplier = "100"
        contract.LastTradeDateOrContractMonth = "20180518"

        product = contract.Symbol
        strike = contract.Strike

        Tws1.calculateOptionPrice(1, contract, 0.3155, underlying)
        Tws1.cancelCalculateOptionPrice(1)

    End Sub

    Private Sub Timer60Sec_Tick(sender As Object, e As EventArgs) Handles Timer60Sec.Tick

        Dim datastring As String = "Order State: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "              ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                   ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                            ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

        Try

            If RobotOn = True Then                                                                                              ' DETERMINE IF THE TIMER ACTION OF THE ROBOT TO GET PRICES EVERY x SECONDS IS ACTIVE 

                getMarketDataTick(ticksymbol)                                                                                   ' CALL GET MARKET DATA FUNCTION TO GET THE CURRENT PRICE OF THIS TICKSYMBOL(S) IN PLAY

                ' check to see if the price has moved above an open buy order
                Using db As BondiModel = New BondiModel()                                                                       ' INITIALIZE CONNECTION TO THE DATABASE USING THE ENTITY FRAMEWORK

                    Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                               ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
                    hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()      ' GET THE INDEX DATA FOR THE SELECTED INDEX FROM THE HARVEST INDEX TABLE

                    tempHarvestKey = hi.FirstOrDefault().harvestKey                                                             ' SET THE TEMP HARVEST KEY TO THE SELECTED INDEX HARVEST KEY

                    Dim sellOrderExists = (From q In db.stockorders Where q.roboIndex = tempHarvestKey And
                                                                        q.Action = "SELL" And q.Status = "Open" Select q)       ' DETERMINE IF A SELL TO CLOSE ORDER EXISTS - INDICATES THAT THE TRAILING BUY TO OPEN ORDER IS COVERED WITH A STC ORDER

                    If sellOrderExists.Count > 0 Then                                                                           ' DOES A STC ORDER EXIST

                        lbldatastring.Text = ("Sell Order Active")                                                              ' SEND A MESSAGE TO THE USER INDICATING THAT A STC ORDER EXISTS

                    Else                                                                                                        ' IF A STC ORDER DOES NOT EXIST

                        lbldatastring.Text = "No Sell Order Active"                                                             ' SEND A MESSAGE TO THE USER INDICATING THAT A STC ORDER DOES NOT EXIST

                        Dim buyOrderExists = (From q In db.stockorders Where q.roboIndex = tempHarvestKey And
                                                                           q.Action = "BUY" And q.Status = "Open" Select q)     ' GET THE TRAILING BUY TO OPEN ORDER INFORMATION FROM THE DATABASE
                        '    'Stop

                        If buyOrderExists.Count > 0 Then                                                                        ' IF THE BTO ORDER EXISTS

                            If currentprice - buyOrderExists.FirstOrDefault.LimitPrice >= hi.FirstOrDefault().width * 2 Then    ' DETERMINE IF THE CURRENT TICK PRICE OF THE TICKSYMBOL IS MORE THAN 2 WIDTHS GREATER THAN THE TRAILING BTO ORDER 

                                contract.Symbol = buyOrderExists.FirstOrDefault().Symbol.ToUpper()                              ' SET THE CONTRACT SYMBOL TO THE STOCK ORDER UPDATED SYMBOL
                                contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                   ' SET THE CONTRACT SECURITY TYPE TO THE INDEX STOCK SECURITY TYPE
                                contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                  ' SET THE CONTRACT CURRENCY TYPE TO THE INDEX CURRENCY TYPE
                                contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                      ' SET THE CONTRACT EXCHANGE TYPE TO THE INDEX EXCHANGE TYPE

                                order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                       ' SET THE ORDER ORDER TYPE TO THE INDEX ORDER TYPE (lmt OR mkt)
                                order.TotalQuantity = hi.FirstOrDefault().shares                                                ' SET THE ORDER NUMBER OF SHARES TO THE INDEX NUMBER OF SHARES - CONSIDER SETTING TO THE UPDATED ORDER SHARES VALUE
                                order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                               ' SET THE ORDER TRADE IN FORCE TO THE INDEX TRADE IN FORCE (day OR gtc)

                                order.OrderId = buyOrderExists.FirstOrDefault().OrderId                                         ' SET THE ORDER ORDER ID TO THE UPDATED RECORD ORDER ID
                                order.Action = "BUY"                                                                            ' SET THE ORDER ACTION TO BUY
                                order.LmtPrice = buyOrderExists.FirstOrDefault().LimitPrice + hi.FirstOrDefault().width         ' SET THE ORDER LIMIT PRICE TO THE UPDATED RECORD LIMIT PRICE PLUS THE INDEX WIDTH VALUE

                                Call Tws1.placeOrderEx(order.OrderId, contract, order)                                          ' CALL THE PLACEORDER FUNCTION TO SEND THE ORDER CREATED TO TWS

                                ' UPDATE THE TRAILING BUY ORDER HERE.
                                buyOrderExists.FirstOrDefault.Status = "Open"
                                buyOrderExists.FirstOrDefault.LimitPrice = order.LmtPrice
                                buyOrderExists.FirstOrDefault.timestamp = DateTime.Parse(Now).ToUniversalTime()                 ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                                db.SaveChanges()                                                                                ' SAVE THE CHANGES TO THE DATABASE   

                                lbldatastring.Text = "Elevated Stranded Buy Order " &
                                    String.Format("{0:C}", (currentprice + hi.FirstOrDefault().width).ToString())               ' IF THE BTO IS LESS THAN 2 WIDTHS BELOW CURRENT PRICE SEND A MESSAGE TO THE USER INDICATING THE CONDITION

                            End If

                        End If
                    End If
                End Using

            End If

            datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " " & loopcounter                             ' ADD THE CURRENT FINISH TIME TO THE DATASTRING TO GET THE FULL CYCLE TIME
            lblStatus.Text = datastring                                                                                                     ' DISPLAY THE APPLICATION MESSAGE TO THE USER 
        Catch ex As Exception
            MsgBox("BUY TO OPEN Modification Error: " & ex.ToString())                                                                       ' SUPPLY AN ERROR MESSAGE TO BE DEBUGGED OR USED BY THE USER. 
        End Try


    End Sub

    Private Sub btnClearList_Click(sender As Object, e As EventArgs)
        ' lstOHLC.Items.Clear()
        ' lblRecordsProcessed.Text = ""
        lblStatus.Text = ""                                                                                                                 ' CLEAR THE STATUS MESSAGES
    End Sub

    Private Sub btnGetPrice_Click(sender As Object, e As EventArgs) Handles btnGetPrice.Click

        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                               ' ESTABLISH A NEW CONTRACT CLASS

        If txtGetPriceSymbol.Text <> "" Then                                                                                                ' CHECK IF THE USER HAS ENTERED A SYMBOL
            contract.Symbol = txtGetPriceSymbol.Text                                                                                        ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
        Else
            MsgBox("Please enter a symbol.")                                                                                                ' PROMPT THE USER TO CORRECT THE ERROR AND ENTER A SYMBOL
            Exit Sub
        End If

        contract.SecType = "STK"                                                                                                            ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Currency = "USD"                                                                                                           ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Exchange = "SMART"                                                                                                         ' INITIALIZE EXCHANGE USED FOR THE CONTRACT

        Tws1.reqMarketDataType(3)                                                                                                           ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(tickId + 1, contract, "", False, Nothing)                                                                         ' CALL FUNCTION TO REQUEST MARKET DATA
        Tws1.tickCount = 0                                                                                                                  ' SET THE TICKCOUNTER EQUAL TO ZERO
        'currentprice = Tws1_tickPrice()                                                                                                    ' SET CURRENT PRICE TO STOCKTICKPRICE TO BE PASSED TO CALLING FUNCTION


    End Sub

    'Private Sub btnOptionChain_Click(sender As Object, e As EventArgs) Handles btnOptionChain.Click
    '    Dim contract As Contract = New Contract
    '    contract.Symbol = "VXX"
    '    contract.SecType = "OPT"
    '    contract.Exchange = "SMART"
    '    contract.Currency = "USD"
    '    'Tws1.reqContractDetailsEx(1, contract)
    '    Tws1.reqMarketDataType(24)
    '    Tws1.reqMktDataEx(1005, contract, String.Empty, False, Nothing)
    '    Tws1.reqSecDefOptParams(1, "VXX", "", "STK", 285777413)
    '    Tws1.calculateOptionPrice(1, contract, 0, 0)
    '    Tws1.cancelCalculateOptionPrice(1)
    'End Sub











    ' Use this one to test db connections and get data

    Private Sub btnGetData_Click(sender As Object, e As EventArgs)

        ' TODO: DETERMINE IF I WANT TO KEEP THIS CODE BLOCK.  IF I DO NEED TO COMMENT THE CODE AND ADD ERROR CHECKING

        Dim symbol As String = ""
        Using db As BondiModel = New BondiModel()
            'Dim _lstHarvestindex As List(Of HarvestIndex) = New List(Of HarvestIndex)()
            '_lstHarvestindex = _entity.HarvestIndexes.AsEnumerable.[Select](Function(x) New HarvestIndex).Where(Function(s) s.harvestKey = cmbIndexes.SelectedValue).ToList()
            'cmbIndexes.DataSource = _lstHarvestindex
            'cmbIndexes.DisplayMember = "name"
            'cmbIndexes.ValueMember = "harvestKey"

            Dim _lstHarvestindex As List(Of HarvestIndex) = New List(Of HarvestIndex)()
            _lstHarvestindex = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()
            symbol = _lstHarvestindex.FirstOrDefault().product


            getMarketDataTick(txtGetPriceSymbol.Text)
        End Using



    End Sub

    Private Sub btnReqNextValidId_Click(sender As Object, e As EventArgs) Handles btnReqNextValidId.Click

        Dim datastring = "Next Valid Order Id: " & nextValidOrderId & "  "                                                              ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS OCCURRING WITHIN THE APPLICAITON
        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                                 ' ADD THE TIME STAMP TO THE DATASTRING FOR THE NEXT ORDERID PRESENTED
        lblStatus.Text = datastring                                                                                                     ' DISPLAY THE DATASTRING VALUE TO THE USER USING THE STATUS LABEL

    End Sub





    ' BLOCK 4: TWS FUNCTIONS USED IN APPLICATION HERE

    Private Sub Tws1_managedAccounts(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_managedAccountsEvent) Handles Tws1.OnmanagedAccounts

        Dim msg As String                                                                                                               ' VARIABLE USED TO HOUSE THE MESSAGE DETAILS COMMUNICATED TO THE USER

        ' TODO:  Add code here to check the database for the amount of time that the user has traded in 
        ' paper before they can use the robot live.  Initial thoughts are 6 months with 75 days of activity 
        ' using the robot before live account through the robot can be used.        

        If Mid(eventArgs.accountsList, 1, 1) = "D" Then                                                                                 ' DETERMINE THE ACCOUNT TYPE THE USER IS LOGGED INTO TWS WITH 
            msg = "CONNECTED : PAPER account: [" & eventArgs.accountsList & "]"                                                         ' MESSAGE SENT TO THE CONNECTED MESSAGE LISTBOX INDICATING CONNECTED, ACCOUNT TYPE, AND ACCOUNT NUMBER
        Else
            msg = "CONNECTED : The LIVE account: [" & eventArgs.accountsList & "]"                                                      ' MESSAGE SENT TO THE CONNECTED MESSAGE LISTBOX INDICATING CONNECTED, ACCOUNT TYPE, AND ACCOUNT NUMBER 
        End If
        Call m_utils.addListItem(Utils.List_Types.CONNECTION_RESPONSES, msg)                                                            ' CALL THE MESSAGE UTILITY TO PRESENT THE CONNECTED ACCOUNT INFORMATIOJN TO THE USER

        m_faAccount = True                                                                                                              ' SET THE FINANCIAL ACCOUNT MANAGER STATUS TO TRUE
        m_faAcctsList = eventArgs.accountsList                                                                                          ' SET THE ACCOUNTS LIS TO THE CURRENT LIST OF ACCOUNTS FOR THE LOGGED IN USER        

    End Sub

    Private Sub Tws1_tickOptionComputation(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickOptionComputationEvent) Handles Tws1.OnTickOptionComputation

        ' TODO: COMMENT AND ERROR PROOF THE CODE BLOCK

        Dim mktDataStr As String, volStr As String, deltaStr As String, gammaStr As String, vegaStr As String,
            thetaStr As String, optPriceStr As String, pvDividendStr As String, undPriceStr As String

        If eventArgs.impliedVolatility = Double.MaxValue Or eventArgs.impliedVolatility < 0 Then
            volStr = "N/A"
        Else
            volStr = eventArgs.impliedVolatility
        End If
        If eventArgs.delta = Double.MaxValue Or Math.Abs(eventArgs.delta) > 1 Then
            deltaStr = "N/A"
        Else
            deltaStr = eventArgs.delta
        End If
        If eventArgs.gamma = Double.MaxValue Or Math.Abs(eventArgs.gamma) > 1 Then
            gammaStr = "N/A"
        Else
            gammaStr = eventArgs.gamma
        End If
        If eventArgs.vega = Double.MaxValue Or Math.Abs(eventArgs.vega) > 1 Then
            vegaStr = "N/A"
        Else
            vegaStr = eventArgs.vega
        End If
        If eventArgs.theta = Double.MaxValue Or Math.Abs(eventArgs.theta) > 1 Then
            thetaStr = "N/A"
        Else
            thetaStr = eventArgs.theta
        End If
        If eventArgs.optPrice = Double.MaxValue Then
            optPriceStr = "N/A"
        Else
            optPriceStr = eventArgs.optPrice
        End If
        If eventArgs.pvDividend = Double.MaxValue Then
            pvDividendStr = "N/A"
        Else
            pvDividendStr = eventArgs.pvDividend
        End If
        If eventArgs.undPrice = Double.MaxValue Then
            undPriceStr = "N/A"
        Else
            undPriceStr = eventArgs.undPrice
        End If
        mktDataStr = "Calculated Option Price for: " & product.ToUpper() ' " = " & eventArgs.tickerId & " vol = " & volStr & " delta = " & String.Format("{0:00.00}", deltaStr) '&
        ' " gamma = " & gammaStr & " vega = " & vegaStr & " theta = " & thetaStr &
        ' " Price = " & optPriceStr & " D = " & pvDividendStr & " underlying = " & undPriceStr & " " & m_utils.getField(eventArgs.tickType) 
        Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)
    End Sub

    ' THIS IS WHERE MIHIR ADDED THE COMBO CODE TO ADD THE LEG DATA TO THE GRID
    Private Sub Tws1_contractDetailsEx(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_contractDetailsExEvent) Handles Tws1.OncontractDetailsEx
        Dim contractDetails As IBApi.ContractDetails
        contractDetails = eventArgs.contractDetails

        Dim contract As IBApi.Contract
        contract = contractDetails.Summary
        grdContracts.Rows.Add(New String() {contract.Symbol, contract.LastTradeDateOrContractMonth, contract.Strike, contract.Right, contract.ConId})
        'Dim reqId As Long
        'reqId = eventArgs.reqId

        'Dim contractDetails As IBApi.ContractDetails
        'contractDetails = eventArgs.contractDetails

        'Dim contract As IBApi.Contract
        'contract = contractDetails.Summary

        'Dim offset As Long
        'offset = lstServerResponses.Items.Count

        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "reqId = " & reqId & " ===================================")

        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ---- Contract Details Begin ----")
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "Contract:")
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  conId = " & contract.ConId)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  symbol = " & contract.Symbol)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  secType = " & contract.SecType)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  lastTradeDate = " & contract.LastTradeDateOrContractMonth)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  strike = " & contract.Strike)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  right = " & contract.Right)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  multiplier = " & contract.Multiplier)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  exchange = " & contract.Exchange)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  primaryExchange = " & contract.PrimaryExch)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  currency = " & contract.Currency)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  localSymbol = " & contract.LocalSymbol)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  tradingClass = " & contract.TradingClass)

        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "Details:")
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  marketName = " & contractDetails.MarketName)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  minTick = " & contractDetails.MinTick)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  priceMagnifier = " & contractDetails.PriceMagnifier)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  orderTypes = " & contractDetails.OrderTypes)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  validExchanges = " & contractDetails.ValidExchanges)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  underConId = " & contractDetails.UnderConId)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  longName = " & contractDetails.LongName)

        'If (contract.SecType <> "BOND") Then
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  contractMonth = " & contractDetails.ContractMonth)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  industry = " & contractDetails.Industry)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  category = " & contractDetails.Category)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  subcategory = " & contractDetails.Subcategory)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  timeZoneId = " & contractDetails.TimeZoneId)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  tradingHours = " & contractDetails.TradingHours)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  liquidHours = " & contractDetails.LiquidHours)
        'End If
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  evRule = " & contractDetails.EvRule)
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  evMultiplier = " & contractDetails.EvMultiplier)

        'If (contract.SecType = "BOND") Then

        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "Bond Details:")
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  cusip = " & contractDetails.Cusip)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  ratings = " & contractDetails.Ratings)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  descAppend = " & contractDetails.DescAppend)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  bondType = " & contractDetails.BondType)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  couponType = " & contractDetails.CouponType)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  callable = " & contractDetails.Callable)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  putable = " & contractDetails.Putable)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  coupon = " & contractDetails.Coupon)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  convertible = " & contractDetails.Convertible)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  maturity = " & contractDetails.Maturity)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  issueDate = " & contractDetails.IssueDate)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  nextOptionDate = " & contractDetails.NextOptionDate)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  nextOptionType = " & contractDetails.NextOptionType)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  nextOptionPartial = " & contractDetails.NextOptionPartial)
        '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  notes = " & contractDetails.Notes)


        'End If

        '' CUSIP/ISIN/etc.
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  secIdList={")
        'Dim secIdList As List(Of IBApi.TagValue)
        'secIdList = contractDetails.SecIdList
        'If (Not secIdList Is Nothing) Then
        '    Dim secIdListCount As Long
        '    secIdListCount = secIdList.Count
        '    Dim iLoop As Long
        '    For iLoop = 0 To secIdListCount - 1
        '        Dim param As IBApi.TagValue
        '        param = secIdList.Item(iLoop)
        '        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "    " & param.Tag & "=" & param.Value)
        '    Next iLoop
        'End If
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  }")

        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ---- Contract Details End ----")

        '' move into view
        'lstServerResponses.TopIndex = offset                                                                                            ' ADJUST THE SCROLL ON THE LISTBOX SO THAT THE LATEST MESSAGE WILL BE DISPLAYED

    End Sub

    Private Sub Tws1_contractDetailsEnd(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_contractDetailsEndEvent) Handles Tws1.OncontractDetailsEnd

        Dim reqId As Long                                                                                                               ' INITIALIZE THE REQUESTED ORDER ID VARIABLE TO HOLD THE ORDER ID FROM THE TWS PLATFORM USING THE API
        reqId = eventArgs.reqId                                                                                                         ' ASSIGN THE CURRENT ORDERID FROM THE API TO THE REQID VARIABLE

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "reqId = " & reqId & " =============== end ===============")        ' CALLED FUNCTION TO ADD THE ORDERID TO THE LISTBOX

        ' move into view
        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1                                                                ' ADJUST THE SCROLL ON THE LISTBOX SO THAT THE LATEST MESSAGE WILL BE DISPLAYED

    End Sub

    Private Sub Tws1_nextValidId(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_nextValidIdEvent) Handles Tws1.OnNextValidId

        nextValidOrderId = eventArgs.Id                                                                                                 ' ASSIGN THE ORDERID TO THE NEXT VALID ORDER ID VARIABLE USED TO SEND ORDERS TO TWS USING THE API
        'm_dlgOrder.orderId = eventArgs.Id 'Set Order Id Here

    End Sub

    Private Sub Tws1_tickPrice(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickPriceEvent) Handles Tws1.OnTickPrice

        Dim datastring As String
        datastring = "Symbol: " & ticksymbol & " Tick Type: " & eventArgs.tickType & " Current Price: " & String.Format("{0:C}", eventArgs.price) &
            " Time: " & String.Format("{0:hh:mm:ss}", Now.ToLocalTime)                                                           ' SET THE DATASTRING FOR THE LISTBOX DISPLAY
        ' INITIALIZE DATASTRING VARIABLE TO HOLD MESSAGING FOR THE USER
        If (tickTypeId = eventArgs.tickType) Then
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, datastring)                                                               ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")                                      ' CALL FUNTION TO ADD THE LAST LINT TO THE LISTBOX
        End If

        If eventArgs.tickCount = 1 Then

            ' DETERMINE IF I WANT TO HAVE OTHER PRICE TICKS SAVED OR STORE THE LAST 5 OR 10 MINUTES OF TICKS.

            'Call m_utils.addListItem(Utils.List_Types.MKT_DATA, datastring)                                                             ' WRITES THE CURRENT PRICE TO THE LISTBOX
            lblConStatus.Text = datastring
            currentprice = eventArgs.price                                                                                              ' SET THE PUBLIC VARIABLE CURRENT PRICE TO THE TICKPRICE
            txtPrice.Text = currentprice                                                                                                ' SEND THE TICKPRICE TO THE VIEW FOR THE USER TO SEE
            underlying = eventArgs.price
        End If

    End Sub

    Private Sub Tws1_openOrderEx(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_openOrderExEvent) Handles Tws1.OnopenOrderEx

        ' NOTE:  KEEP ALL THIS CODE AS REFERENCE FOR LISTBOX MESSAGING AND USE THIS TO ASSIGN VALUES TO THE ORDER AND CONTRACT CLASSES.
        ' WILL NEED TO USE SOME OF THESE ADDITIONAL ITEMS AS OPTIONS ARE ADDED ETC.

        ' THIS CODE EXECUTES WHEN AN ORDER IS SENT TO TWS USING THE API.

        Dim ordermsg As String = ""                                                                                                         ' INITIALIZE THE ORDER MESSAGE VARIABLE TO HOLD ORDER MESSAGE DETAILS FOR THE USER
        Dim contractmsg As String = ""                                                                                                      ' INITIALIZE THE CONTRACT MESSAGE VARIABLE TO HOLD CONTRACT MESSAGE DETAILS FOR THE USER
        Dim orderstatemsg As String = ""                                                                                                    ' INITIALIZE THE ORDER STATE MESSAGE TO HOLD ORDER STATE DETAILS FOR THE USER

        Dim contract As IBApi.Contract                                                                                                      ' INITIALIZE THE CONTRACT CLASS VARIABLE AS AN ibapi CONTRACT
        contract = eventArgs.contract                                                                                                       ' ASSIGN THE VALUES OF THE CURRENT EVENT ARGUMENTS TO THE CONTRACT CLASS VARIABLE

        Dim order As IBApi.Order                                                                                                            ' INITIALIZE THE ORDER CLASS VARIABLE AS AN ibapi ORDER
        order = eventArgs.order                                                                                                             ' ASSIGN THE VALUES OF THE CURRENT EVENT ARGUMENTS TO THE ORDER CLASS VARIABLE

        Dim orderState As IBApi.OrderState                                                                                                  ' INITIALIZE THE ORDER STATE CLASS VARIABLE AS AN ibapi ORDER STATE
        orderState = eventArgs.orderState                                                                                                   ' ASSIGN THE CURRENT ORDERSTATE TO THE ORDER STATE VARIABLE

        If order.Action = "BUY" Then

            If orderState.Status.ToLower() = "presubmitted" Or orderState.Status.ToLower() = "submitted" Then

                ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Order: " &
                    order.PermId & "." & order.OrderId & "." & loopcounter & " BUY TO OPEN: " & order.TotalQuantity &
                    " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", order.LmtPrice) & " " & contract.SecType &
                    " - " & orderState.Status.ToUpper()

                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                               ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")                                      ' CALL FUNTION TO ADD THE LAST LINT TO THE LISTBOX
                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ")                                                                    ' CALL FUNTION TO ADD A BLANK LINE TO THE LISTBOX

            ElseIf orderState.Status.ToLower() = "filled" Then

                If loopcounter < 1 Then
                    ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Order: " &
                   order.PermId & "." & order.OrderId & "." & loopcounter & " BUY TO OPEN: " & order.TotalQuantity &
                   " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", order.LmtPrice) & " " & contract.SecType &
                   " - " & orderState.Status.ToUpper()

                    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                           ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
                    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")                                  ' CALL FUNTION TO ADD THE LAST LINT TO THE LISTBOX
                    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ")                                                                ' CALL FUNTION TO ADD A BLANK LINE TO THE LISTBOX
                End If

            End If

        ElseIf order.Action = "SELL" Then

            If orderState.Status.ToLower() = "presubmitted" Or orderState.Status.ToLower() = "submitted" Then

                ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Order: " &
                    order.PermId & "." & order.OrderId & "." & loopcounter & " SELL TO CLOSE: " & order.TotalQuantity &
                    " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", order.LmtPrice) & " " & contract.SecType &
                    " -  " & orderState.Status.ToUpper()

                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                               ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")                                      ' CALL FUNTION TO ADD THE LAST LINT TO THE LISTBOX
                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ")                                                                    ' CALL FUNTION TO ADD A BLANK LINE TO THE LISTBOX

            ElseIf orderState.Status.ToLower() = "filled" Then

                If loopcounter < 1 Then
                    ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Order: " &
                   order.PermId & "." & order.OrderId & "." & loopcounter & " SELL TO CLOSE: " & order.TotalQuantity &
                   " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", order.LmtPrice) & " " & contract.SecType &
                   " -  " & orderState.Status.ToUpper()

                    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                           ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
                    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")                                  ' CALL FUNTION TO ADD THE LAST LINT TO THE LISTBOX
                    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ")                                                                ' CALL FUNTION TO ADD A BLANK LINE TO THE LISTBOX
                End If
                loopcounter = 0
            End If


        End If


        Using db As BondiModel = New BondiModel()                                                                                           ' DATABASE MODEL USING ENTITY FRAMEWORK
            ' ADD USERID SEARCH TO THIS AS WELL TO REFINE THE SEARCH. 
            ' CHECK WITH MIHIR ON HOW TO UPDATE THE BONDIMODEL 

            Dim ordersexist = (From q In db.stockorders Where q.PermID = order.PermId Select q)

            If ordersexist.Count = 0 Then                                                                                               ' IF THE RECORD DOESNT ALREADY EXIST ADD A NEW RECORD TO THE DATABASE

                Dim newStockOrder As New stockorder                                                                                     ' OPEN NEW STRUCTURE FOR RECORD IN STOCK PRODUCTION TABLE.                    

                '' TODO:  CHANGE THE MODEL AND CODE BELOW TO SWAP STATUS AND ORDERSTATUS FIELD SIZES 

                If order.Action = "BUY" Then
                    matchid = order.OrderId
                End If

                Dim newindex As New stockorder With {
                                                            .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                            .OrderId = order.OrderId,
                                                            .PermID = order.PermId,
                                                            .Symbol = contract.Symbol.ToUpper(),
                                                            .Action = order.Action,
                                                            .ordertype = order.OrderType,
                                                            .TickPrice = currentprice,
                                                            .LimitPrice = order.LmtPrice,
                                                            .Status = "Open",
                                                            .Quantity = order.TotalQuantity,
                                                            .OrderStatus = orderState.Status,
                                                            .roboIndex = indexselected,
                                                            .matchID = matchid,
                                                            .OrderTimestamp = DateTime.Parse(Now).ToUniversalTime()
                                                        }                                                                                   ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                db.stockorders.Add(newindex)                                                                                            ' INSERT THE NEW RECORD TO BE ADDED.
                db.SaveChanges()                                                                                                        ' SAVE THE RECORD TO THE DATABASE

            End If

        End Using

    End Sub

    Private Sub Tws1_orderStatus(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_orderStatusEvent) Handles Tws1.OnorderStatus

        ' ANY CHANGE IN ORDER STATUS WILL HAPPEN HERE - SAVE THE VARS TO THE CLASS HERE FOR USE BEYOND THIS SUB

        Dim datastring As String = "Order State: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                          ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP

        Select Case eventArgs.status.ToLower()                                                                                              ' DETERMINE HOW TO PROCESS THE ORDER STATE CHANGE

            Case "presubmitted"

                ' WHEN AN ORDER IS PRESUBMITTED TO THE TWS PLATFORM THE FOLLOWING CODE WILL DETERMINE IF THERE IS AN ASSOCIATED ORDER IN THE DATABASE.
                ' IF NOT THE CODE WILL ADD A NEW RECORD FOR THAT ORDERID. IF THE RECORD EXISTS THE CODE WILL UPDATE THE ORDERSTATUS AND TIMESTAMP FOR THE RECORD.
                ' FINALLY, THE CODE WILL DISPLAY THE APPROPRIATE MESSAGE TO THE USER INDICATING WHAT HAPPENED WITH EACH ORDER IN THE LISTBOX OF THE APP.

                Try


                    'CheckOrder(eventArgs.permId)
                    'Stop

                    Using db As BondiModel = New BondiModel()                                                                               ' DATABASE MODEL USING ENTITY FRAMEWORK

                        Dim orderexists = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q)                             ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED

                        If orderexists.Count > 0 Then                                                                                       ' DETERMINE IF THERE IS A RECORD TO UPDATE THE ORDERSTATUS TO SUBMITTED (NOTE: THIS TYPICALLY WILL HAPPEN BETWEEN PRE-SUBMITTED AND SUBMITTED.)

                            Dim ou = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q).FirstOrDefault()                 ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED                           

                            If ou.OrderStatus <> eventArgs.status Then                                                                      ' ONLY UPDATE THE ORDER IF THERE HAS BEEN A CHANGE IN STATUS FROM WHAT WAS RECORDED IN THE RECORD
                                ou.OrderStatus = eventArgs.status                                                                           ' SET THE ORDERSTATUS OF THE RECORD TO THE EVENT STATUS RESULT                                                           
                                ou.timestamp = DateTime.Parse(Now).ToUniversalTime()                                                        ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                                db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            
                                datastring = datastring & " Order PreSubmitted "                                                            ' INDICATE TO THE USER WHAT HAPPENED IN THE ORDER STATE CHANGE
                            End If

                        Else

                            ' CURRENT CODE ADDS AN ORDER ON OPENORDEREX NEED TO DETERMINE IF I WANT THAT TO OCCUR HERE AND THE OPEN ORDER IS USED ONLY TO SEND ORDERS

                        End If

                    End Using
                    loopcounter = 0
                Catch ex As Exception
                    ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.
                    MsgBox("Order PreSubmitted Error: " & ex.ToString())                                                                    ' SUPPLY AN ERROR MESSAGE TO BE DEBUGGED OR USED BY THE USER. 
                End Try

            Case "submitted"

                ' WHEN AN ORDER IS SUBMITTED TO THE TWS PLATFORM THE FOLLOWING CODE WILL DETERMINE IF THERE IS AN ASSOCIATED ORDER IN THE DATABASE.
                ' IF NOT THE CODE WILL ADD A NEW RECORD FOR THAT ORDERID. IF THE RECORD EXISTS THE CODE WILL UPDATE THE ORDERSTATUS AND TIMESTAMP FOR THE RECORD.
                ' FINALLY, THE CODE WILL DISPLAY THE APPROPRIATE MESSAGE TO THE USER INDICATING WHAT HAPPENED WITH EACH ORDER IN THE LISTBOX OF THE APP.

                Try

                    ' CheckOrder(eventArgs.permId)
                    'Stop

                    Using db As BondiModel = New BondiModel()                                                                               ' DATABASE MODEL USING ENTITY FRAMEWORK

                        Dim orderexists = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q)                             ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED

                        If orderexists.Count > 0 Then                                                                                       ' DETERMINE IF THERE IS A RECORD TO UPDATE THE ORDERSTATUS TO SUBMITTED (NOTE: THIS TYPICALLY WILL HAPPEN BETWEEN PRE-SUBMITTED AND SUBMITTED.)

                            Dim ou = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q).FirstOrDefault()                 ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED                           

                            If ou.OrderStatus <> eventArgs.status Then                                                                      ' ONLY UPDATE THE ORDER IF THERE HAS BEEN A CHANGE IN STATUS FROM WHAT WAS RECORDED IN THE RECORD
                                ou.OrderStatus = eventArgs.status                                                                           ' SET THE ORDERSTATUS OF THE RECORD TO THE EVENT STATUS RESULT                                                           
                                ou.timestamp = DateTime.Parse(Now).ToUniversalTime()                                                        ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                                db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            
                                datastring = datastring & " Order Submitted "                                                               ' INDICATE TO THE USER WHAT HAPPENED IN THE ORDER STATE CHANGE
                            End If

                        End If

                    End Using

                    loopcounter = 0

                Catch ex As Exception
                    ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.
                    MsgBox("Order Submitted Error: " & ex.ToString())                                                                       ' SUPPLY AN ERROR MESSAGE TO BE DEBUGGED OR USED BY THE USER. 
                End Try

            Case "filled"

                ' WHEN AN ORDER IS FILLED IN THE TWS PLATFORM THE FOLLOWING CODE WILL DETERMINE IF THERE IS AN ASSOCIATED ORDER IN THE DATABASE AND UPDATE THAT RECORD AS FILLED AND CLOSED.
                ' CHECK THE WORKFLOW AFTER THIS HAPPENS TO SEE IF THERE IS A NEED TO ADD CODE HERE TO HANDLE THE SENDING OF THE SUBSEQUENT ORDERS OR NOT.
                ' this status loops twice

                ' MsgBox(loopcounter & " " & eventArgs.status)

                Try

                    'If loopcntr = 0 Then

                    Dim filledaction As String = ""                                                                                                     ' INITIALIZE THE FILLED ACTION VARIABLE
                    Dim filledharvestkey As String = ""                                                                                         ' INITIALIZE THE FILLED HARVEST KEY VARIABLE 
                    Dim filledlimitprice As Double = 0                                                                                          ' INITIALIZE THE FILLED LIMIT PRICE VARIABLE
                    Dim filledmatchid As Integer = 0                                                                                            ' INITIALIZE THE FILLED  MATCH ID VARIABLE

                    Dim contract As IBApi.Contract = New IBApi.Contract()                                                                       ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
                    Dim order As IBApi.Order = New IBApi.Order()                                                                                ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

                    ' UPDATE THE ORDER THAT WAS FILLED IN THE DATABASE TABLE HERE

                    Using db As BondiModel = New BondiModel()                                                                                           ' DATABASE MODEL USING ENTITY FRAMEWORK

                        Dim orderexists = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q)                                         ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED

                        ' IF THE ORDER FILLED EXISTS IN THE DATABASE UPDATE THE ORDER TO REFLECT 
                        ' THAT IT WAS FILLED WITH LAST FILL PRICE AND ALL OTHER DETAILS.

                        If orderexists.Count > 0 Then                                                                                                   ' DETERMINE IF THERE IS A RECORD TO UPDATE THE ORDERSTATUS TO SUBMITTED (NOTE: THIS TYPICALLY WILL HAPPEN BETWEEN PRE-SUBMITTED AND SUBMITTED.)

                            Dim ou = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q).FirstOrDefault()                             ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED                           

                            If ou.OrderStatus <> eventArgs.status Then                                                                      ' ONLY UPDATE THE ORDER IF THERE HAS BEEN A CHANGE IN STATUS FROM WHAT WAS RECORDED IN THE RECORD
                                ou.OrderStatus = eventArgs.status                                                                           ' SET THE ORDERSTATUS OF THE RECORD TO THE EVENT STATUS RESULT                                                           
                                ou.TickPrice = eventArgs.lastFillPrice                                                                      ' SET THE TICKPRICE AT THE LAST FILL PRICE TO CAPTURE ANY OVERAGE IN PRICE
                                ou.Status = "Closed"                                                                                        ' SET THE RECORD STATUS TO CLOSED
                                ou.timestamp = DateTime.Parse(Now).ToUniversalTime()                                                        ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                                db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            
                                datastring = datastring & " Order Filled "                                                                  ' INDICATE TO THE USER WHAT HAPPENED IN THE ORDER STATE CHANGE

                                filledaction = ou.Action                                                                                        ' SET THE FILLEDACTION FLAG TO THE ORDER ACTION TO DETERMINE WHAT NEXT STEPS FOR ADDITIONAL ORDERS SHOULD BE
                                filledharvestkey = ou.roboIndex                                                                                 ' SET THE FILLED HARVEST KEY TO THE ROBOINDEX KEY TO BE USED IN SENDING THE NEXT SET OF ORDERS BASED ON THIS FILLED ORDER
                                filledlimitprice = ou.LimitPrice                                                                                ' SET THE FILLED LIMIT PRICE TO THE ORDERS LIMIT PRICE THAT WAS FILLED TO BE USED IN SENDING THE NEXT SET OF ODERS BASED ON THIS FILLED ORDER
                                filledmatchid = ou.OrderId                                                                                      ' SET THE FILLED MATCH ID TO THE ORDER FILLED ORDER ID TO BE USED IN SENDING THE NEXT SET OF ORDERS BASED ON THIS FILLED ORDER
                                'Stop
                            End If
                        End If

                        ' THIS IS WHERE ASSESSEMENT OF THE ORDER FILLED IS MADE AND ADDITIONAL ORDERS ARE SENT TO TWS USING THE API

                        If filledaction.ToUpper() = "BUY" Then                                                                              ' IF THE ACTION OF THE FILLED ORDER WAS BUY SEND A BUY TO OPEN ORDER 1 WIDTH BELOW AND A SELL TO CLOSE 1 WIDTH ABOVE

                            ' 1. GET THE INDEX VALUES NEEDED TO SEND ADDITIONAL ORDER(S)
                            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                   ' GET THE USERID OF THE USER TO CHECK FOR ORDERS FOR THIS ID AS WELL AS THE INDEX
                            hi = db.HarvestIndexes.AsEnumerable.Where(Function(u) u.harvestKey = filledharvestkey).ToList()                 ' BUILD THE LIST OF USERS BASED ON THIS USERNAME

                            orderexists = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q)                             ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER FILLED

                            If orderexists.Count > 0 Then                                                                                   ' DETERMINE IF THERE IS AN ORDER THAT EXISTS TO BASE THE NEXT ORDER SENT OFF OF

                                'MsgBox(loopcounter)

                                ' this means that the order was sent and added to the db already

                                'If loopcounter = 0 Then                                                                                     ' BECAUSE THE eREADER LOOPS TWICE CONTROL THE NUMBER OF ORDERS SENT AND SAVED IN THE DATABASE

                                ' SEND A SELL TO CLOSE ORDER 

                                contract.Symbol = hi.FirstOrDefault().product.ToUpper()                                                 ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
                                contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                           ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
                                contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                          ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
                                contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                              ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

                                order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                               ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
                                order.TotalQuantity = hi.FirstOrDefault().shares                                                        ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
                                order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                                       ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)

                                order.OrderId = nextValidOrderId                                                                        ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
                                order.Action = "SELL"                                                                                   ' SET THE ORDER ACTION 
                                order.LmtPrice = filledlimitprice + hi.FirstOrDefault().width                                           ' SET TO REDUCE THE PRICE BY  $.50 FOR TESTING REMOVE WHEN DONE                                                    ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE
                                matchid = filledmatchid                                                                                 ' SET THE MATCH ID TO THE SAME AS THE FILLED ORDER TO TRACK THE PAIR OF ORDERS

                                Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                  ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 


                                ' SEND A BUY TO OPEN ORDER

                                order.OrderId = nextValidOrderId                                                                        ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
                                order.Action = "BUY"                                                                                    ' SET THE ORDER ACTION 
                                order.LmtPrice = filledlimitprice - hi.FirstOrDefault().width                                           ' SET TO REDUCE THE PRICE BY  $.50 FOR TESTING REMOVE WHEN DONE.                                                    ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE
                                '                   matchid = nextValidOrderId                                                                              ' SET THE MATCHID FOR THE ADDITIONAL BUY TO OPEN TO THE SAME AS THE ORDERID 

                                Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                  ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

                                'loopcounter = 0                                                                                       ' INCREMENT THE COUNTER TO PREVENT DUPLICATE ORDERS BEING PLACED AND SAVED
                                'Else
                                'loopcounter = 0                                                                                         ' RESET THE LOOPCOUNTER SINCE ORDERS HAVE BEEN PROCESSED
                                'End If
                            Else

                            End If

                        ElseIf filledaction.ToUpper() = "SELL" Then                                                                         ' IF THE ACTION OF THE FILLED ORDER WAS SELL CHECK FOR A BUY ORDER BELOW AND MODIFY IT 1 WIDTH UP FROM WHERE IT IS

                            ' MODIFY THE OPEN BUY TO OPEN ORDER RIDING BELOW THE SELL TO CLOSE ORDER

                            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                   ' GET THE USERID OF THE USER TO CHECK FOR ORDERS FOR THIS ID AS WELL AS THE INDEX
                            hi = db.HarvestIndexes.AsEnumerable.Where(Function(u) u.harvestKey = filledharvestkey).ToList()                 ' BUILD THE LIST OF USERS BASED ON THIS USERNAME

                            Dim sl As List(Of stockorder) = New List(Of stockorder)()                                                       ' INITIALIZE THE STOCKORDER LIST TO BE USED TO GET THE STOCK ORDER RECORD TO UPDATE
                            sl = db.stockorders.AsEnumerable.Where(Function(s) s.Action = "BUY" And s.Status = "Open").ToList()             ' PULL THE STOCKORDER RECORD STRANDED BUY TO OPEN ORDER BASED ON LIMITPRICE AND OPEN STATUS

                            'sl = db.stockorders.AsEnumerable.Where(Function(s) s.LimitPrice =
                            '                    (filledlimitprice - (hi.FirstOrDefault().width * 2)) And s.OrderStatus = "Open").ToList()   ' PULL THE STOCKORDER RECORD STRANDED BUY TO OPEN ORDER BASED ON LIMITPRICE AND OPEN STATUS

                            If sl.Count > 0 Then

                                Dim findorderid As Integer = sl.FirstOrDefault().OrderId
                                Dim ou = (From q In db.stockorders Where q.OrderId = findorderid Select q).FirstOrDefault()             ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED

                                'loopcounter = 0                     ' CHECK TO MAKE SURE THAT THE TRAILING BUY ORDER GETS MOVED

                                If loopcounter = 0 Then

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

                                    Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                  ' CALL THE PLACEORDER FUNCTION TO SEND THE ORDER CREATED TO TWS

                                    ' UPDATE THE TRAINING BUY ORDER HERE.
                                    ou.Status = "Open"
                                    ou.LimitPrice = order.LmtPrice
                                    ou.timestamp = DateTime.Parse(Now).ToUniversalTime()                                                    ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                                    db.SaveChanges()                                                                                        ' SAVE THE CHANGES TO THE DATABASE                            
                                    datastring = datastring & " Order Filled "                                                              ' INDICATE TO THE USER WHAT HAPPENED IN THE ORDER STATE CHANGE

                                    loopcounter += 1                                                                                        ' INCREMENT THE LOOPCOUNTER TO PREVENT DOUBLE ORDERS 

                                Else
                                    loopcounter = 0                                                                                         ' RESET THE LOOPCOUNTER SINCE ORDERS HAVE BEEN PROCESSED
                                End If


                            End If

                        End If

                    End Using

                    '    'End If
                Catch ex As Exception
                    ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.
                    MsgBox("Order Submitted Error: " & ex.ToString())                                                                   ' SUPPLY AN ERROR MESSAGE TO BE DEBUGGED OR USED BY THE USER. 
                End Try

                loopcounter += 1

            Case "cancelled"

                ' WHEN AN ORDER IS CANCELLED IN THE TWS PLATFORM THE FOLLOWING CODE WILL DETERMINE IF THERE IS AN ASSOCIATED ORDER IN THE DATABASE AND CLOSE AND CANCEL THAT ORDERS RECORD AND ALERT THE USER THROUGH THE DATASTRING.

                Dim ordermsg As String = ""

                Try
                    Using db As BondiModel = New BondiModel()                                                                           ' DATABASE MODEL USING ENTITY FRAMEWORK

                        Dim orderexists = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q)                         ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED

                        If orderexists.Count > 0 Then                                                                                   ' DETERMINE IF THERE IS A RECORD TO UPDATE THAT MATCHES THE PERMID OF CANCELLED ORDER

                            Dim ou = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q).FirstOrDefault()             ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED

                            ou.OrderStatus = eventArgs.status                                                                           ' SET THE ORDERSTATUS OF THE RECORD TO THE EVENT STATUS RESULT
                            ou.Status = "Closed"                                                                                        ' SET THE STATUS OF THE RECORD TO CLOSED
                            ou.TickPrice = currentprice                                                                                 ' SET THE TICK PRICE TO THE PRICE OF THE PRODUCT AT THE TIME THE ORDER WAS CANCELLED
                            ou.timestamp = DateTime.Parse(Now).ToUniversalTime()                                                        ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                            db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            
                            datastring = datastring & " Order Cancelled "                                                               ' INDICATE TO THE USER WHAT HAPPENED IN THE ORDER STATE CHANGE

                            If ou.Action = "BUY" Then

                                ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Order: " &
                                    eventArgs.permId & "." & eventArgs.orderId & "." & loopcounter & " BUY TO OPEN: " &
                                    ou.Quantity & " " & ou.Symbol & " " & " @ " & String.Format("{0:C}", ou.LimitPrice) & " " &
                                    " - CANCELLED "

                                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                           ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
                                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")                  ' CALL FUNTION TO ADD THE LAST LINT TO THE LISTBOX
                                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ")                                                ' CALL FUNTION TO ADD A BLANK LINE TO THE LISTBOX
                            Else

                                ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Order: " &
                                    eventArgs.permId & "." & eventArgs.orderId & "." & loopcounter & " SELL TO CLOSE: " &
                                    ou.Quantity & " " & ou.Symbol & " " & " @ " & String.Format("{0:C}", ou.LimitPrice) & " " &
                                    " - CANCELLED "

                                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                           ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
                                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")                  ' CALL FUNTION TO ADD THE LAST LINT TO THE LISTBOX
                                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ")                                                ' CALL FUNTION TO ADD A BLANK LINE TO THE LISTBOX
                            End If

                        Else
                            ' set the datastring variable here                                                                                  ' DETERMINE IF THERE IS ANYTHING NEEDED TO BE DONE HERE
                        End If

                        loopcounter = 0


                    End Using
                Catch ex As Exception
                    ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.
                    MsgBox("Order Cancellation Error: " & ex.ToString())                                                                        ' SUPPLY AN ERROR MESSAGE TO BE DEBUGGED OR USED BY THE USER. 
                End Try

        End Select

        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " " & loopcounter                                     ' ADD THE CURRENT FINISH TIME TO THE DATASTRING TO GET THE FULL CYCLE TIME
        'If RobotOn = True Then
        'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, datastring)                                                            ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER
        'End If
        'lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1                                                                        ' SETS THE FOCUS OF THE LISTBOX TO THE LATEST DETAIL SENT TO IT
        'loopcounter = 1
        'lblStatus.Text = datastring

    End Sub

    Private Sub Tws1_OnSecurityDefinitionOptionParameter(tws As Tws, DTWsEvents_securityDefinitionOptionParameterEvent As AxTWSLib._DTWsEvents_securityDefinitionOptionParameterEvent) Handles Tws1.OnSecurityDefinitionOptionParameter
        Dim displayString As String

        displayString = String.Format("reqId: {0}, exchange {1}, underlyingConId: {2}, tradingClass: {3}, multiplier: {4}, expirations: {5}, strikes: {6}",
            DTWsEvents_securityDefinitionOptionParameterEvent.reqId,
            DTWsEvents_securityDefinitionOptionParameterEvent.exchange,
            DTWsEvents_securityDefinitionOptionParameterEvent.underlyingConId,
            DTWsEvents_securityDefinitionOptionParameterEvent.tradingClass,
            DTWsEvents_securityDefinitionOptionParameterEvent.multiplier,
            String.Join(",", DTWsEvents_securityDefinitionOptionParameterEvent.expirations),
            String.Join(", ", DTWsEvents_securityDefinitionOptionParameterEvent.strikes))

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, displayString)

        ' move into view
        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1
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

    Function gettickprice(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickPriceEvent) As Double

        'MsgBox(eventArgs.price)
        If eventArgs.tickCount = 1 Then
            'Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)
            currentprice = eventArgs.price
            underlying = eventArgs.price
        End If

        Return currentprice
    End Function




    ' BLOCK 5: FUNCTIONS NOT USED 

    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click

        Dim csvdata As String = ""                                                                                                                                                      ' STRING TO HOLD THE DATA FROM EACH CSV FILE READ INTO MEMORY
        Dim filedate As String = "20160104"                                                                                                                                             ' STRING TO HOLD THE FILE DATE FOR THE CSV FILE TO BE READ THIS WILL INCREMENT FROM DB
        Dim symbol As String = "vxx"                                                                                                                                                    ' STRING TO HOLD THE SYMBOL OF THE PRODUCT BEING TESTED

        Dim path As String = "C:\Users\Troy Belden\Desktop\stockprices\allstocks_"                                                                                                      ' GENERIC PATH FOR READING THE CSV FILES - WILL NEED TO SET TO USER INPUT FOR PRODUCTION

        Try
            Using textReader As New System.IO.StreamReader(path & filedate & "\table_" & symbol & ".csv")                                                                               ' TEXT READER READS THE CSV FILE INTO MEMORY
                csvdata = textReader.ReadToEnd                                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING.
                backprices = ParseBackData(csvdata)                                                                                                                                     ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.                        
                lblStatus.Text = lblStatus.Text & " " & backprices.Count                                                                                              ' LABEL INDICATOR SHOWING THAT PROCESSING IS COMPLETE
            End Using
        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)                                                                                                ' IF THERE IS AN ERROR READING THE FILE DISPLAY THE ERROR MESSAGE
        Finally

        End Try

    End Sub

    Private Sub btnReadBacktest_Click(sender As Object, e As EventArgs)

        Dim datastring As String = "  Backtest Cycle Time: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "
        Dim csvdata As String = ""                                                                                                                                                      ' STRING TO HOLD THE DATA FROM EACH CSV FILE READ INTO MEMORY
        Dim filedate As String = "20160104"                                                                                                                                             ' STRING TO HOLD THE FILE DATE FOR THE CSV FILE TO BE READ THIS WILL INCREMENT FROM DB
        Dim symbol As String = ""                                                                                                                                                       ' STRING TO HOLD THE SYMBOL OF THE PRODUCT BEING TESTED
        Dim priceint As Integer = 0
        Dim currentprice As Double = 0
        Dim checksum As Double = 0
        Dim opentrigger As Double = 0
        Dim recordsread As Integer = 0

        Using db As BondiModel = New BondiModel()
            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()
            hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()
            symbol = hi.FirstOrDefault().product
            opentrigger = hi.FirstOrDefault().opentrigger
        End Using
        Dim path As String = "C:\Users\Troy Belden\Desktop\stockprices\allstocks_"                                                                                                      ' GENERIC PATH FOR READING THE CSV FILES - WILL NEED TO SET TO USER INPUT FOR PRODUCTION

        Try
            Using textReader As New System.IO.StreamReader(path & filedate & "\table_" & symbol & ".csv")                                                                               ' TEXT READER READS THE CSV FILE INTO MEMORY
                csvdata = textReader.ReadToEnd                                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING.
                backprices = ParseBackData(csvdata)                                                                                                                                     ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.                        
                'Stop

                'lstOHLC.Items.Add("Row" & vbTab & "Time" & vbTab & "Open" & vbTab & "High" & vbTab & "Low" & vbTab & "Close")
                For Each price As backPrice In backprices

                    If price.interval = 0 Then

                        priceint = Int(price.OpenPrice)                                                                                                                                 ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
                        checksum = price.OpenPrice - priceint                                                                                                                           ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
                        currentprice = (Int(checksum / opentrigger) * opentrigger + priceint)                                                                                         ' CALCULATE THE NEAREST MARK PRICE TO SET THE LIMIT ORDER AGAINST                    

                    End If

                    'lstOHLC.Items.Add(price.interval & vbTab & price.MarketTime & vbTab & (String.Format("{0:C}", price.OpenPrice)) &
                    'vbTab & (String.Format("{0:C}", price.HighPrice)) & vbTab & (String.Format("{0:C}", price.LowPrice)) &
                    'vbTab & (String.Format("{0:C}", price.ClosePrice)))
                    recordsread += 1
                Next

                'lblRecordsProcessed.Text = "Records Processed: " & backprices.Count                                                                                            ' LABEL INDICATOR SHOWING THAT PROCESSING IS COMPLETE
            End Using
        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)                                                                                                ' IF THERE IS AN ERROR READING THE FILE DISPLAY THE ERROR MESSAGE
        Finally

        End Try

        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)
        lblStatus.Text = "Backtest Records Read: " & recordsread & " " & datastring

    End Sub

    Private Sub cmbIndexes_SelectedIndexChanged(sender As Object, e As EventArgs)

        ' if connected to TWS get the symbol from the database and get current price.
        ' used to establish the first price for the harvest robot
        Dim product As String = ""
        indexselected = cmbWillie.SelectedValue.ToString()

        If (Tws1.serverVersion() > 0) Then

            Dim contract As IBApi.Contract = New IBApi.Contract()                                                                           ' ESTABLISH A NEW CONTRACT CLASS

            Using db As BondiModel = New BondiModel()                                                                      ' DATABASE MODEL USING ENTITY FRAMEWORK

                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()
                hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()
                product = hi.FirstOrDefault().product

                'POPULATE THE SEND ORDER TEXTBOXES WITH THE INDEX SELECTED DATA.
                txtOrderId.Text = nextValidOrderId
                txtSymbol.Text = hi.FirstOrDefault().product
                txtAction.Text = "BUY"
                txtType.Text = hi.FirstOrDefault().ordertype
                txtQty.Text = hi.FirstOrDefault().shares

                txtGetPriceSymbol.Text = product

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

    Private Sub btnAnalysis_Click(sender As Object, e As EventArgs) Handles btnAnalysis.Click
        dlgAnalysis.Show()
    End Sub

    Private Sub btnBackTest_Click(sender As Object, e As EventArgs) Handles btnBackTest.Click
        dlgHarvestBacktest.ShowDialog()
    End Sub
    Dim tickTypeId As Integer = 0
    Private Sub btnTickPrice_Click(sender As Object, e As EventArgs) Handles btnTickPrice.Click
        Dim contract As IBApi.Contract = New IBApi.Contract()
        contract.Symbol = "VXX"                                                                                                   ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
        contract.SecType = "STK"                                                                                                    ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Currency = "USD"                                                                                                   ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Exchange = "SMART"                                                                                                 ' INITIALIZE EXCHANGE USED FOR THE CONTRACT
        'contract.SecType = "OPT"
        'contract.Exchange = "SMART"
        'contract.Currency = "USD"
        'contract.LastTradeDateOrContractMonth = 20180518
        'contract.Strike = 40
        'contract.Right = "C"
        tickTypeId = txtTickId.Text
        Tws1.reqMarketDataType(3)                                                                                                   ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(1, contract, "", False, Nothing)
    End Sub

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

    Private Sub Tws1_tickSize(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickSizeEvent) Handles Tws1.OnTickSize
        Dim mktDataStr As String
        mktDataStr = "id=" & eventArgs.id & " " & m_utils.getField(eventArgs.tickType) & "=" & eventArgs.size
        If (tickTypeId = eventArgs.tickType) Then
            Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)
        End If

        ' move into view
        'lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Market data generic tick event - triggered by the reqMktDataEx() method
    '--------------------------------------------------------------------------------
    Private Sub Tws1_tickGeneric(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickGenericEvent) Handles Tws1.OnTickGeneric
        Dim mktDataStr As String

        mktDataStr = "id=" & eventArgs.id & " " & m_utils.getField(eventArgs.tickType) & "=" & eventArgs.value
        If (tickTypeId = eventArgs.tickType) Then
            Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)
        End If


        ' move into view
        'lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Market data string tick event - triggered by the reqMktDataEx() method
    '--------------------------------------------------------------------------------
    Private Sub Tws1_tickString(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickStringEvent) Handles Tws1.OnTickString
        Dim mktDataStr As String

        mktDataStr = "id=" & eventArgs.id & " " & m_utils.getField(eventArgs.tickType) & "=" & eventArgs.value
        If (tickTypeId = eventArgs.tickType) Then
            Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)
        End If


        ' move into view
        'lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Market data EFP computation event - triggered by the reqMktDataEx() method
    '--------------------------------------------------------------------------------
    Private Sub Tws1_tickEFP(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickEFPEvent) Handles Tws1.OnTickEFP
        Dim mktDataStr As String
        mktDataStr = "id=" & eventArgs.tickerId & " " & m_utils.getField(eventArgs.field) & ":" &
             eventArgs.basisPoints & " / " & eventArgs.formattedBasisPoints &
             " totalDividends=" & eventArgs.totalDividends & " holdDays=" & eventArgs.holdDays &
             " futureLastTradeDate=" & eventArgs.futureLastTradeDate & " dividendImpact=" & eventArgs.dividendImpact &
             " dividendsToLastTradeDate=" & eventArgs.dividendsToLastTradeDate

        Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)

        ' move into view
        'lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Market depth book entry - triggered by the reqMktDepthEx() method
    '--------------------------------------------------------------------------------
    'Private Sub Tws1_updateMktDepth(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_updateMktDepthEvent) Handles Tws1.OnUpdateMktDepth
    ' m_dlgMktDepth.updateMktDepth(eventArgs.tickerId, eventArgs.position, " ", eventArgs.operation, eventArgs.side, eventArgs.price, eventArgs.size)
    'End Sub

    '--------------------------------------------------------------------------------
    ' Market depth Level II book entry - triggered by the reqMktDepthEx() method
    '--------------------------------------------------------------------------------
    'Private Sub Tws1_updateMktDepthL2(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_updateMktDepthL2Event) Handles Tws1.OnUpdateMktDepthL2
    'm_dlgMktDepth.updateMktDepth(eventArgs.tickerId, eventArgs.position, eventArgs.marketMaker, eventArgs.operation, eventArgs.side, eventArgs.price, eventArgs.size)
    'End Sub
End Class
