'Option Strict On
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
Imports Excel = Microsoft.Office.Interop.Excel

Friend Class WGB
    ' *************************************************
    ' DESCRIPTION: THIS CLASS HOUSES ALL OF THE SUBPROCESSES THAT ALLOW WILLIE TO RUN. NAMED AFTER WILLIAM GEORGE BELDEN THIS APPLICATION IS A DEDICATION TO HIS MEMORY.
    ' WILLIE IS THE ROBOTIC ENGINE THAT ENABLES STOCK STRATEGIES TO BE BACKTESTED, FORWARD TESTED AND RUN IN PRODUCTION. 
    ' THE INITIAL STRATEGY FOR WHICH WILLIE WAS BUILT IS HARVESTING. ADDITIONAL STRATEGIES WILL BE ADDED OVER TIME.
    ' THIS APPLICAION IS FOR MY FAMILY, FOR OUR FUTURES, TO PROVIDE FINANCIAL FREEDOM IN MEMORY OF THOSE WHO WENT ON AHEAD OF US.
    ' THANK YOU DAD, YOU GAVE ME EVERYTHING. I LOVE YOU.  
    ' TROY 
    ' DECEMBER 9, 2018
    ' *************************************************

    Inherits System.Windows.Forms.Form                                                                                                                                  ' SYSTEM INHERITANCE FOR WINDOWS FORMS
    Public WithEvents Tws1 As Tws                                                                                                                                       ' DECLARES TWS FOR THE APPLICATION TO USE THE FUNCTIONS CONTAINED WITHIN
    Private m_utils As New Utils                                                                                                                                        ' CREATES A NEW INSTANCE OF UTILS TO BE USED IN THIS FORM
    Public contract As IBApi.Contract                                                                                                                                   ' INITIALIZE THE CONTRACT CLASS VARIABLE AS AN ibapi CONTRACT
    Dim order As IBApi.Order = New IBApi.Order()                                                                                                                        ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA
    Public harvestindexes As List(Of HarvestIndex)                                                                                                                      ' CREATES THE CONTAINER TO HOUSE THE HARVEST KEY LIST

    Public datastring As String = ""                                                                                                                                    ' VARIABLE USED TO HOLD TEXT TO BE COMMUNICATED TO THE USER FROM THE APPLICATION
    Public harvestkey As String = ""                                                                                                                                    ' USED TO HOLD THE HARVEST INDEX KEY WHEN CALLING FUNCTIONS
    Public indexselected As String = ""                                                                                                                                 ' INITIALIZE THE INDEXSELECTED AS EMPTY - USED TO GET THE HARVEST INDEX
    Public ticksymbol As String = ""                                                                                                                                    ' VARIABLE USED TO HOLD THE TICKSYMBOL WITHIN THE APPLICATION
    Public mktDataStr As String = ""
    Public pricetype As String = ""
    Public ordermsg As String = ""                                                                                                                                      ' INITIALIZE THE ORDER MESSAGE VARIABLE TO HOLD ORDER MESSAGE DETAILS FOR THE USER

    Private m_faAccount, faError As Boolean                                                                                                                             ' VARIABLE TO HOLD FINACIAL ADVISOR STATUS SETTINGS
    Public stream As Boolean = True
    Public stock As Boolean = True
    Public buyopen As Boolean = False
    Public sellopen As Boolean = False

    Public tickId As Integer = 0                                                                                                                                        ' INITIALIZE THE TICK ID EQUAL TO ZERO - USED IN GATHERING MARKET DATA FOR A PRODUCT
    Public nextValidOrderId As Integer = 0                                                                                                                              ' PUBLIC VARIABLE TO HOLD CURRENTORDERID - TO BE USED TO SET THE NEXTVALIDID FOR ORDERS
    Public prod As Integer = 1
    Public expdatewidth As Integer = 0                                                                                                                                  ' USED TO HOLD THE EXPDATEWIDTH VALUE FROM THE DATABASE FOR A HARVEST INDEX RECORD EX: 2 MONTHS OR 3 MONTHS

    Public openprice As Decimal = 0
    Public highprice As Decimal = 0
    Public lowprice As Decimal = 0
    Public closeprice As Decimal = 0
    Public lastprice As Decimal = 0
    Public priceamount As Decimal = 0
    Public bid As Decimal = 0
    Public ask As Decimal = 0
    Public lastamount As Decimal = 0
    Public closeamount As Decimal = 0
    Public buytrigger As Decimal = 0                                                                                                                                    ' USED TO HOLD THE BUYTRIGGER VALUE FROM THE DATABASE FOR A HARVEST INDEX RECORD
    Public selltrigger As Decimal = 0                                                                                                                                   ' USED TO HOLD THE SELLTRIGGER VALUE FROM THE DATABASE FOR A HARVEST INDEX RECORD
    Public stockprice As Decimal = 0
    Public closetoday As Decimal = 0                                                                                                                                    ' VARIABLE USED TO HOUSE THE CURRENT CLOSE PRICE TODAY WHEN CONNECTED TO THE TWS API
    Public nextbuyprice As Decimal = 0                                                                                                                                  ' VARIABLE USED TO CALCULATE AND HOLD THE NEXT PRICE TO BUY SHARES AT
    Public btomoveprice As Decimal = 0                                                                                                                                  ' VARIABLE USED TO CALCULATE AND HOLD THE NEXT PRICE TO MOVE A TRAILING BTO TO - CALCULATED BASED ON LAST PRICE
    Public orderprice As Decimal = 0

    Public btoPermid As Double = 0                                                                                                                                      ' VARIABLE USED TO HOLD THE BTO PERM ID FOR REFERENCE WHEN A STC ORDER IS ADDED TO HE DATABASE
    Public cprice As Double = 0                                                                                                                                         ' VARIABLE USED TO HOLD THE STARTING OPEN TO BUY PRICE FOR EACH USER & INDEX
    Public priceint As Double = 0                                                                                                                                       ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
    Public checksum As Double = 0                                                                                                                                       ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
    Public currentprice As Double = 0                                                                                                                                   ' VALUE RETURNED FROM THIS FUNCTION BEING CALLED




    Public Sub New()
        MyBase.New()                                                                                                                                ' SET THE BASE TO A NEW INSTANCE
        Tws1 = New Tws(Me)                                                                                                                          ' INITIALIZE TWS WITHIN THE APPLICATION TO A NEW INSTANCE
        InitializeComponent()                                                                                                                       ' INITIALIZE ALL COMPONENTS
    End Sub

    Private Sub WGB_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()                                                                                                         ' CENTERS THE FORM ON THE SCREEN
        Call m_utils.init(Me)                                                                                                       ' INITIALIZES THE UTILS TO SEND AND READ MESSAGES FROM THE API

        ' Temp set the userid - would normally get pulled from the login screen.
        Utils.username = "boss"                   'boss - twfabrizio - RolandAEH                                                    ' SETS THE USERID TO MY USERID = THIS WILL BE PASSED FROM THE LOGIN SCREEN

        Try                                                                                                                         ' OPEN THE TRY / CATCH PROCESS

            Using db As BondiModel = New BondiModel()                                                                               ' INITIALIZE THE MODEL TO THE DB VARIABLE FOR USE IN GETTING DATA FROM THE DATATABLES

                Dim u = (From q In db.Users Where q.UserName = Utils.username Select q).FirstOrDefault()                            ' GET LOGGED IN USERS RECORD FROM THE DATABASE ***** THIS WILL GO AWAY WHEN THE LOGIN FROM IS IN USE
                Utils.userid = u.UserId                                                                                             ' PASSES THE USERID TO THE VARIABLE TO INDICATE WHO IS LOGGED INTO THIS INSTANCE

                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                       ' ESTABLISH THE LIST TO HOUSE THE HARVEST INDEX RECORDS
                hi = db.HarvestIndexes.Where(Function(s) s.active = True And s.userID = Utils.userid).AsEnumerable.[Select] _
                        (Function(x) New HarvestIndex With {.harvestKey = x.harvestKey, .name = x.name,
                        .product = x.product, .opentrigger = x.opentrigger, .width = x.width,
                        .expdatewidth = x.expdatewidth}).ToList()                                                                   ' PULL THE ACTIVE HARVEST INDEX RECORDS AND ADD THEM TO THE LIST 

                'cmbHarvestIndex.DataSource = hi                                                                                    ' SET THE DROPDOWN DATASOURCE EQUAL TO THE INDEX LIST
                'cmbHarvestIndex.DisplayMember = "name"                                                                             ' DROPDOWN DISPLAYS THE NAME FIELD OF THE LIST
                'cmbHarvestIndex.ValueMember = "harvestkey"                                                                         ' DROPDOWN VALUE TIED TO NAME IS THE HARVESTKEY FIELD
                'cmbHarvestIndex.SelectedIndex = 0                                                                                  ' SET THE INDEX DISPLAYED AS THE FIRST ONE

                harvestkey = hi.FirstOrDefault.harvestKey                                                                           ' ASSIGN THE HARVESTKEY TO THE GLOBAL VARIABLE HARVESTKEY FOR USE WITHIN THE APPLICATION
                ticksymbol = hi.FirstOrDefault().product                                                                            ' ASSIGN THE FIRST HARVEST INDEX PRODUCT SYMBOL TO TICKSYMBOL WITH THE FORM LOAD
                buytrigger = hi.FirstOrDefault().opentrigger                                                                        ' ASSIGN THE BUY TO OPEN TRIGGER AMOUNT TO THE BUYTRIGGER GLOBAL VARIABLE FOR USE WITHIN THE APPLICATION
                selltrigger = hi.FirstOrDefault().width                                                                             ' ASSIGN THE SELL TO CLOSE WIDTH LIMIT TO THE GLOBAL SELLTRIGGER VARIABLE FOR USE WITHIN THE APPLICAITON
                expdatewidth = hi.FirstOrDefault().expdatewidth                                                                     ' ASSIGN THE EXPIRATION DATE WIDTH TO THE VARIABLE USED TO CALCULATE THE SPAN OF EXPIRATION

                lblTickSymbol.Text = ticksymbol.ToUpper()                                                                           ' ASSIGN THE SYMBOL FOR THE INDEX TO THE GLOBAL SYMBOL VARIABLE FOR USE WITHIN THE APPLICATION
                lblStatus.Text = "Key: " & harvestkey.ToUpper()                                                                     ' ASSIGN THE HARVEST KEY TO THE GLOBAL HARVEST KEY VARIABLE FOR USE WIHTIN THE APPLICAITON              

            End Using                                                                                                               ' END USING DB AS THE DATABSE MODEL

        Catch ex As Exception                                                                                                       ' ANY ERROR CAUGHT HERE AND DISPLAYED TO THE USER
            ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.
            Call m_utils.addListItem(Utils.List_Types.ERRORS, "Form Load Error: " & ex.ToString())                                  ' ADD DESCRIPTION TO THE LIST BOX TO INDICATE ERROR STATUS

        End Try                                                                                                                     ' CLOSE THE TRY / CATCH PROCESS 

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()                                                                                                                                                      ' CLOSES THE APPLICATION.
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' *************************************************
        ' DESCRIPTION:          CLEARS ANY DATAFIELDS POPULATED RUNNING THE STRATEGY
        ' METHODS OR PROCESSES: REMOVES DATA FROM LISTS AND TEXT BOXES ON THE MAIN APPLICATION FORM
        ' *************************************************

        lstServerResponses.Items.Clear()                                                                                                                                ' PROVIDE THE USER WITH THE STATUS MESSAGE OF THIS SUBROUTINE
        lstConnectionResponses.Items.Clear()                                                                                                                            ' PROVIDE THE USER WITH THE STATUS MESSAGE OF THIS SUBROUTINE
        ' lblBuyOrderExists.Text = ""                                                                                                                                    ' PROVIDE THE USER WITH THE STATUS MESSAGE OF THIS SUBROUTINE

    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click

        ' *************************************************
        ' DESCRIPTION:          CONNECTS THE APPLICAITON TO THE TRADER WORKSTATION PLATFORM FOR INTERACTIVE BROKERS.
        ' METHODS OR PROCESSES: USING THE CONNECTION PARAMETERS SUPPLIED BY THE USER THE APP CONNECTS TO THE TWS PLATFORM 
        '                       AND PULLS THE INITIAL DATA FOR THE DEFAULT INDEX IN THE COMBOBOX. 
        ' *************************************************

        Try

            datastring = "Connected to TWS " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                                                        ' VARIABLE USED TO SUPPLY MESSAGES TO THE USER ON PROCESSING AND CYCLETIME  
            m_faAccount = False                                                                                                                                     ' THIS IS NOT A FINANCIAL ADVISORS ACCOUNT SET THE VARIABLE ACCORDINGLY TO INDICATE NOT A FA ACCOUNT

            Dim msg As String = ""                                                                                                                                  ' VARIABLE USED TO SUPPLY DATA TO THE LISTBOX DETERMINE IF I WANT TO KEEP THIS VAR NAME.
            Dim host As String = "127.0.0.1" 'txtHarvestingIP.Text                                                                                                               ' STORE THE HOST IP INTO THE HOST VARIABLE - NEED TO EITHER PULL THIS FROM THE PROFILE OR ERROR CHECK THE VALUES
            Dim port As String = "7497" 'txtHarvestingPort.Text                                                                                                             ' STORE THE PORT ADDRESS INTO THE PORT VARIABLE - NEED TO EITHER PULL THIS FROM THE PROFILE OR ERROR CHECK THE VALUES
            Dim clientid As String = "0" 'txtHarvestingClientId.Text                                                                                                     ' STORE THE CLIENT ID INTO THE CLIENT ID VARIABLE - NEED TO EITHER PULL THIS FROM THE PROFILE OR ERROR CHECK THE VALUES

            Tws1.connect(host, port, clientid, False, "")  'pass connection variables

            If Tws1.serverVersion() > 0 Then     ' WORK ON SETTING THIS IN THE CONNECTION tws PASS AND USING A GLOBAL VARIABLE TO MAKE MORE EFFICIENT               ' IF THE RESPONSE BACK IS THE SERVER VERSION THAT IS THE INDICATION THAT THE APP IS CONNECTED TO TWS
                msg = "CONNECTING - ClientID: " & txtHarvestingClientId.Text & " SV: " & Tws1.serverVersion() & " at " & Tws1.TwsConnectionTime()                   ' SET THE MSG TO THE CONNECTION STRING AND TIME OF CONNECTION
                Call m_utils.addListItem(Utils.List_Types.CONNECTION_RESPONSES, msg)                                                                                    ' CALL THE ADD LIST ITEM FUNCTION TO ADD THE MESSAGE TO THE LISTBOX                 
            End If

            Call getPrice(True)

            'buyorderexists = False                                                                                                                                 ' SET THE VARIABLE INDICATING WHETHER A BUY ORDER EXISTS TO FALSE
            'lblBuyOrderExists.Text = buyorderexists                                                                                                                 ' SET THE LABEL ON THE FORM TO THE VARIABLE ----> REMOVE THIS IN PRODUCTION
            'lblSellOrderExists.Text = sellorderexists

            'getMarketDataTick(ticksymbol)                                                                                                                           ' GET THE TICK PRICE OF THE CURRENT TICKSYMBOL IN THE SYSTE
            'Tws1.reqAllOpenOrders()                                                                                                                                 ' GET ALL OPEN ORDERS FROM TWS

            'datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                                                         ' SET THE DATASTRING TO THE EXIT TIME OF THE SUB TO DISPLAY FULL CYCLE TIME OF THE CONNECTION
            'lblStatus.Text = datastring                                                                                                                             ' SEND THE DATASTRING TO THE FORM VIEW 
            btnConnect.Enabled = False                                                                                                                              ' SET THE CONNECT BUTTON ENABLED TO FALSE TO REDUCE THE ERROR OF DOUBLE CLICKING AND CAUSING AN ERROR

        Catch ex As Exception
            ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.            
            MsgBox("Connection Error: " & ex.ToString())                                                                                                            ' MESSAGE WHERE THE ERROR OCCURRED - IN WHICH SUB - THIS CODE MAY BE COMMENTED OUT LATER            

        End Try

    End Sub

    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click

        ' *************************************************
        ' DESCRIPTION:          DISCONNECTS THE APPLICAITON TO THE TRADER WORKSTATION PLATFORM FOR INTERACTIVE BROKERS.
        ' METHODS OR PROCESSES: USING THE CONNECTION PARAMETERS SUPPLIED BY THE USER THE APP DISCONNECTS THE TWS PLATFORM. 
        ' *************************************************

        datastring = "Disonnected from TWS at " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                                                     ' VARIABLE USED TO SUPPLY MESSAGES TO THE USER ON PROCESSING AND CYCLETIME

        Try

            Tws1.disconnect()                                                                                                                                       ' CALLED FUNCTION TO DISCONNECT THE APP FROM THE TWS PLATFORM USING THE API
            'Timer60Sec.stop()
            datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                                                         ' INITIALIZE THE DATASTRING WITH THE CURRENT TIME CLOSING THE TIME SPAN LOOP
            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, datastring)                                                                                 ' CALL THE ADD LIST ITEM FUNCTION TO ADD THE MESSAGE TO THE LISTBOX 

            btnConnect.Enabled = True                                                                                                                            ' RE-ENABLE THE CONNECT BUTTON BECAUSE THE DISCONNECT HAS OCCURRED

            'lblStatus.Text = datastring                                                                                                                             ' PROVIDE THE USER WITH THE STATUS MESSAGE OF THIS SUBROUTINE
        Catch ex As Exception
            MsgBox("Disconnection Error " & ex.ToString())                                                                                                          ' MESSAGE WHERE THE ERROR OCCURRED - IN WHICH SUB - THIS CODE MAY BE COMMENTED OUT LATER  
        End Try

    End Sub

    Private Sub btnGetStockPrice_Click(sender As Object, e As EventArgs) Handles btnGetStockPrice.Click

        prod = 1

        Call getPrice(stream)                                                                                                                        ' CALL THE GET PRICE FUNCTION AND PASS THE BOOLEAN VALUE FOR SNAPSHOT TRUE EQUALS SNAPSHOT FALSE EQUALS STREAM

    End Sub

    Private Sub btnGetOptionPrice_Click(sender As Object, e As EventArgs) Handles btnGetOptionPrice.Click
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                                       ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                                                ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA
        Dim expdate As Date = #01/18/2019#
        Dim stockprice As Decimal = 47.0


        prod = 2

        Using db As BondiModel = New BondiModel()                                                                                                   ' DATABASE MODEL USING ENTITY FRAMEWORK

            Dim hi = (From q In db.HarvestIndexes Where q.harvestKey = "FYODHP6KFPX1" Select q).FirstOrDefault()                                    ' GET INDEX RECORD FROM THE DATABASE TO DETERMINE WHETHER WE ARE ADDING A HEDGE 

            ' CONTRACT DATA FOR EITHER STOCK OR OPTION PRICE REQUESTS
            contract.Symbol = hi.product.ToUpper()                                                                                                  ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
            contract.Exchange = hi.exchange.ToUpper()                                                                                               ' INITIALIZE THE EXCHANGE FOR THE CONTRACT
            contract.Currency = hi.currencytype.ToUpper()                                                                                           ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT        
            contract.SecType = "OPT"
            contract.LastTradeDateOrContractMonth = String.Format("{0: yyyyMMdd}", expdate)
            contract.Strike = Int(stockprice - hi.hedgewidth)
            contract.Right = "P"

            'Stop
            'Tws1.cancelMktData(1)

            'sectype = "OPT"

            tickId += 1                                                                                                                     ' INCREMENT THE TICKID 

            Tws1.reqMarketDataType(1)                                                                                                       ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
            Tws1.reqMktDataEx(tickId, contract, "", True, Nothing)                                                                      ' CALL THE FUNCTION TO GET THE MARKET DATA FROM TWS VIA THE API CALL
            Tws1.tickCount = 0

            'getMarketDataTick(hi.product.ToUpper())

            'Tws1.reqMarketDataType(1)                                                                                                   ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
            'Tws1.reqMktDataEx(1, contract, "", False, Nothing)
        End Using

    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click

        Call getPrice(stream)

        Using db As BondiModel = New BondiModel()                                                                                                               ' DATABASE MODEL USED TO CAPTURE THE ROBOTS DATA

            ' CHECK TO SEE WHETHER THERE IS A BUY ORDER IN TWS IF THERE IS MATCH IT WITH THE RECORD IN THE DB.
            ' IF THERE IS A BTO ORDER THEN DO NOT SEND ANOTHER BTO WHEN START WILLIE IS CLICKED. - THIS SHOULD BE DONE AT THE CONNECT SUB 

            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                       ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
            hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = harvestkey).ToList()                           ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

            'currentprice = closetoday
            priceint = Int(currentprice)                                                                                        ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
            checksum = currentprice - priceint                                                                                  ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
            cprice = (Int(checksum / hi.FirstOrDefault.opentrigger) * hi.FirstOrDefault.opentrigger + priceint)                 ' CALCULATE THE STARTING BUY TO OPEN PRICE 

            Stop

        End Using

    End Sub

    Private Sub btnStartWillie_Click(sender As Object, e As EventArgs) Handles btnStartWillie.Click

        Call getPrice(False)                                                                                                         ' GET THE LATEST PRICE FOR THE PRODUCT AS TIME HAS ELAPSED AND THERE MAY BE A PRICE DIFFERENCE THAT HAS OCCURRED

        Dim datastring As String = "Willie Initiated: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "             ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP
        Dim Symbol As String = ""                                                                                                   ' VARIABLE USED TO HOLD THE SYMBOL FOR THE USER & INDEX
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                       ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                                ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

        Try

            Using db As BondiModel = New BondiModel()                                                                               ' DATABASE MODEL USED TO CAPTURE THE ROBOTS DATA

                ' CHECK TO SEE WHETHER THERE IS A BUY ORDER IN TWS IF THERE IS MATCH IT WITH THE RECORD IN THE DB.
                ' IF THERE IS A BTO ORDER THEN DO NOT SEND ANOTHER BTO WHEN START WILLIE IS CLICKED. - THIS SHOULD BE DONE AT THE CONNECT SUB 

                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                       ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
                hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = harvestkey).ToList()                           ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

                contract.Symbol = hi.FirstOrDefault().product.ToUpper()                                                             ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
                contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                                       ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
                contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                                      ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
                contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                                          ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

                order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                                           ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
                order.TotalQuantity = hi.FirstOrDefault().shares                                                                    ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
                order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                                                   ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)
                order.OrderId = nextValidOrderId                                                                                    ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
                order.Action = "BUY"                                                                                                ' SET THE ORDER ACTION 

                If lastprice > 0 Then                                                                                               ' THIS CHECKS WHETHER LAST PRICE IS GREATER THAN ZERO (WEEKEND TESTING) TO CALCULATE OPENING PRICE FROM
                    currentprice = lastprice                                                                                        ' IF TRUE THEN USE THE LAST PRICE THE PRODUCT TRADED AT
                Else
                    currentprice = closeprice                                                                                       ' IF FALSE THEN USE THE PREVIOUS DAYS CLOSE PRICE
                End If

                priceint = Int(currentprice)                                                                                        ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
                checksum = currentprice - priceint                                                                                  ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
                cprice = (Int(checksum / hi.FirstOrDefault.opentrigger) * hi.FirstOrDefault.opentrigger + priceint)                 ' CALCULATE THE STARTING BUY TO OPEN PRICE 

                order.LmtPrice = cprice                                                                                             ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

                nextbuyprice = cprice                                                                                               ' SET THE NEXT ORDER AMOUNT TO BE SENT IN THIS CASE IT IS THE ORDER AMOUNT
                btomoveprice = cprice + (2 * hi.FirstOrDefault().width)                                                             ' SET THE TRIGGER TO MOVE THE BTO UP BASED ON THE PRODUCT PRICE RUNNING UP

                'lblOrderPrice.Text = String.Format("{0:C}", nextbuyprice)                                                           ' SEND THE NEXTBUYPRICE TO THE VIEW 
                'lblBTOMovePrice.Text = String.Format("{0:C}", btomoveprice)                                                         ' SEND THE BTO MOVE PRICE TO THE VIEW

                Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

            End Using

            datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                         ' ADD THE CURRENT FINISH TIME TO THE DATASTRING TO GET THE FULL CYCLE TIME
            lblWelcome.Text = datastring                                                                                            ' DISPLAY THE DATASTRING TO THE USER

        Catch ex As Exception
            'Stop
        End Try
    End Sub


    ' CALLED FUNCTIONS

    Private Function getPrice(ByVal snapshot As Boolean) As Decimal

        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                                       ' ESTABLISH A NEW CONTRACT CLASS

        contract.Symbol = ticksymbol                                                                                                                ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT

        contract.SecType = "STK"                                                                                                                    ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Currency = "USD"                                                                                                                   ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Exchange = "SMART"                                                                                                                 ' INITIALIZE EXCHANGE USED FOR THE CONTRACT

        Tws1.reqMarketDataType(1)                                                                                                                   ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(tickId + 2, contract, "", False, Nothing)                                                                              ' CALL FUNCTION TO REQUEST MARKET DATA
        Tws1.tickCount = 0                                                                                                                          ' SET THE TICKCOUNTER EQUAL TO ZERO        

        Return getPrice

    End Function

    Private Function sendSTCStockorder(ByVal btoFilledprice As Decimal) As Boolean
        ' THIS FUNCTION SENDS AN ORDER TO TWS WHEN CALLED FROM SUB PROCESSES

        Using db As BondiModel = New BondiModel()                                                                                                               ' DATABASE MODEL USED TO CAPTURE THE ROBOTS DATA

            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                       ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
            hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = harvestkey).ToList()                           ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

            contract.Symbol = hi.FirstOrDefault().product.ToUpper()                                                             ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
            contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                                       ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
            contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                                      ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
            contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                                          ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

            order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                                           ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
            order.TotalQuantity = hi.FirstOrDefault().shares                                                                    ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
            order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                                                   ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)
            order.OrderId = nextValidOrderId                                                                                    ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
            order.Action = "SELL"                                                                                               ' SET THE ORDER ACTION 

            order.LmtPrice = btoFilledprice + hi.FirstOrDefault().width                                                         ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

            Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

        End Using

    End Function

    Private Function sendBTOStockorder(ByVal btoFilledprice As Decimal) As Boolean
        ' THIS FUNCTION SENDS AN ORDER TO TWS WHEN CALLED FROM SUB PROCESSES

        Using db As BondiModel = New BondiModel()                                                                               ' DATABASE MODEL USED TO CAPTURE THE ROBOTS DATA

            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                       ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
            hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = harvestkey).ToList()                           ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

            contract.Symbol = hi.FirstOrDefault().product.ToUpper()                                                             ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
            contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                                       ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
            contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                                      ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
            contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                                          ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

            order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                                           ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
            order.TotalQuantity = hi.FirstOrDefault().shares                                                                    ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
            order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                                                   ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)
            order.OrderId = nextValidOrderId                                                                                    ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
            order.Action = "BUY"                                                                                                ' SET THE ORDER ACTION 

            order.LmtPrice = btoFilledprice - hi.FirstOrDefault().width                                                         ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

            Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

        End Using

    End Function

    Private Function modifyBTOStockorder(ByVal btoSpermid As Integer, ByVal updatedprice As Decimal) As Boolean
        ' THIS FUNCTION SENDS AN ORDER TO TWS WHEN CALLED FROM SUB PROCESSES

        Using db As BondiModel = New BondiModel()                                                                               ' DATABASE MODEL USED TO CAPTURE THE ROBOTS DATA

            'Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                       ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
            'hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = harvestkey).ToList()                           ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

            Dim ou = (From q In db.MyOrders Where q.btoSpermid = btoSpermid Select q).FirstOrDefault()                          ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED

            contract.Symbol = ou.symbol                                                                                         ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
            contract.SecType = "STK"                                                                                            ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
            contract.Currency = "USD"                                                                                           ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
            contract.Exchange = "SMART"                                                                                         ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

            order.OrderType = "LMT"                                                                                             ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
            order.TotalQuantity = ou.shares                                                                                     ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
            order.Tif = "GTC"                                                                                                   ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)
            order.OrderId = ou.btoSorderid                                                                                      ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
            order.Action = "BUY"                                                                                                ' SET THE ORDER ACTION 

            If updatedprice = 0 Then
                order.LmtPrice = ou.btoSlimitprice + buytrigger
            Else
                order.LmtPrice = updatedprice                                                                                       ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE
            End If


            ou.btoSlimitprice = order.LmtPrice
            ou.btoStimestamp = DateTime.Parse(Now).ToUniversalTime()
            ou.lastactiontimestamp = DateTime.Parse(Now).ToUniversalTime()

            db.SaveChanges()

            Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

            ordermsg = "Perm ID: " & order.PermId & " Order ID: " & ou.btoSorderid & "." & " BUY" & " " & ou.shares &
                               " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", order.LmtPrice) & " " & contract.SecType &
                               " - " & "PRICE ADJUSTED"                                                                                                  ' SET THE ORDER MESSAGE TO THE ORDER PARAMETERS TO BE DISPLAYED IN THE SERVER LISTBOX

            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                               ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX

        End Using

    End Function

    Private Function sendLongPutOptionOrder(ByVal calcexpdate As Date, ByVal btofilledprice As Decimal) As Boolean

        ' THIS FUNCTION SENDS AN ORDER TO TWS WHEN CALLED FROM SUB PROCESSES

        Using db As BondiModel = New BondiModel()                                                                                   ' DATABASE MODEL USING ENTITY FRAMEWORK

            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                           ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
            hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = harvestkey).ToList()                               ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

            contract.Symbol = hi.FirstOrDefault().product.ToUpper()                                                                 ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
            contract.SecType = "OPT"        'hi.FirstOrDefault().stocksectype.ToUpper()                                             ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
            contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                                          ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
            contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                                              ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

            contract.LastTradeDateOrContractMonth = "20190315"
            contract.Strike = 36 'btofilledprice - hi.FirstOrDefault().hedgewidth
            contract.Right = "P"

            cprice = 0.88               ' txtPrice.Text

            order.OrderType = "MKT"                 ' hi.FirstOrDefault().ordertype.ToUpper()                                   ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
            order.TotalQuantity = 1                 ' hi.FirstOrDefault().shares                                                ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
            order.Tif = "GTC"                       ' hi.FirstOrDefault().inforce.ToUpper()                                     ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)
            order.OrderId = nextValidOrderId                                                                                    ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
            order.Action = "BUY"                    ' txtAction.Text.ToUpper()                                                  ' SET THE ORDER ACTION 
            order.LmtPrice = cprice                                                                                             ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

            Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 
            'Tws1.reqMktDataEx(1, contract, "", True, Nothing)

        End Using

    End Function

    Function calcExpirationDate() As Date                                                                                                   ' CALLED FUNCTION TO CALCULATE THE EXPIRATION DATE FOR THE HEDGE OPTIONS.

        Dim expyear As Integer = Now.Year                                                                                            ' SET THE YEAR FOR THE EXPIRATION OF THE HEDGE
        Dim expmonth As Integer = Now.Month                                                                                          ' SET THE MONTH FOR THE EXPIRATION OF THE HEDGE.

        expmonth = expmonth + expdatewidth                                                                                                  ' ADD 2 MONTHS TO THE HEDGE EXPIRATION   
        'Stop
        If expmonth = 13 Then
            expmonth = 1
            expyear = expyear + 1
        ElseIf expmonth = 14 Then
            expmonth = 2
            expyear = expyear + 1
        End If

        Dim exp As Date = New DateTime(expyear, expmonth, 1)                                                                                                                        ' SET THE FIRST DATE TO CHECK AS THE 1ST OF THE MONTH.              ****  THIS ONLY ALLOWS MONTHLY EXPIRATIONS AT THIS POINT NEED TO ADD WEEKLYS  ****
        For d = 0 To 6                                                                                                                                                              ' LOOP THROUGH 7 DAYS TO FIND FRIDAY.
            If exp.DayOfWeek = DayOfWeek.Friday Then                                                                                                                                ' CHECK TO SEE IF THE DAY OF THE WEEK FOR EXP IS FRIDAY.
                exp = exp.AddDays(14)                                                                                                                                               ' ADD 2 WEEKS TO THE FRIDAY TO GET THE THIRD FRIDAY OF THE MONTH FOR EXPIRATION.
                Exit For
            End If
            exp = exp.AddDays(d)
        Next
        calcExpirationDate = exp

        Return calcExpirationDate
    End Function












    ' TWS CODE 
    Private Sub Tws1_openOrderEx(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_openOrderExEvent) Handles Tws1.OnopenOrderEx

        contract = eventArgs.contract                                                                                                                               ' ASSIGN THE VALUES OF THE CURRENT EVENT ARGUMENTS TO THE CONTRACT CLASS VARIABLE

        Dim order As IBApi.Order                                                                                                                                    ' INITIALIZE THE ORDER CLASS VARIABLE AS AN ibapi ORDER
        order = eventArgs.order                                                                                                                                     ' ASSIGN THE VALUES OF THE CURRENT EVENT ARGUMENTS TO THE ORDER CLASS VARIABLE

        Dim orderState As IBApi.OrderState                                                                                                                          ' INITIALIZE THE ORDER STATE CLASS VARIABLE AS AN ibapi ORDER STATE
        orderState = eventArgs.orderState                                                                                                                           ' ASSIGN THE ORDERSTATE VARIABLE THE EVENTARGS ORDERSTATE VALUE

        Using db As BondiModel = New BondiModel()                                                                                                                   ' CONNECT TO THE DATABASE VIA THE BONDIMODEL STRUCTURE

            If orderState.Status.ToLower() = "presubmitted" Or orderState.Status.ToLower() = "submitted" Then                                                       ' IF THE ORDER STATUS IS PRESUBMITTED OR SUBMITTED IN TWS THEN AN ORDER HAS BEEN SUBMITTED PROCESS THE NEXT STEPS

                If order.Action = "BUY" Then                                                                                                                        ' IF THERE IS AN ORDER THAT EXISTS IN TWS AND THE ACTION IS BUY THEN PERFORM THE FOLLOWING

                    Dim ordersexist = (From q In db.MyOrders Where Trim(q.btoSpermid) = Trim(order.PermId) Select q)                                                ' SEARCH THE DATABASE FOR A CORRESPONDING RECORD USING THE TWS PERMID AS A KEY

                    If ordersexist.Count = 0 Then                                                                                                                   ' IF THERE IS NOT A RECORD IN THE DATABASE THEN ADD ONE HERE.

                        Dim newindex As New myorder With {
                                                            .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                            .harvestkey = harvestkey,
                                                            .btoStimestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                            .lastactiontimestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                            .btoSpermid = order.PermId,
                                                            .btoSorderid = order.OrderId,
                                                            .symbol = ticksymbol,
                                                            .shares = order.TotalQuantity,
                                                            .btoSlimitprice = order.LmtPrice,
                                                            .btoSfillprice = 0,
                                                            .btoSorderstatus = orderState.Status,
                                                            .LPbtoOpen = False,
                                                            .btoSCapital = 0
                                                        }                                                                                                           ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                        db.MyOrders.Add(newindex)                                                                                                                   ' INSERT THE NEW RECORD TO BE ADDED.
                        db.SaveChanges()                                                                                                                            ' SAVE THE RECORD TO THE DATABASE

                    End If                                                                                                                                          ' END THE CHECK TO SEE IF THE RECORD EXISTS
                ElseIf order.Action = "SELL" Then

                    ' This area handles two separate functions.
                    ' 1. updates the BTO with the STC information 
                    ' 2. if there is a STC open update the record with the current time stamp
                    Dim orderexists = (From q In db.MyOrders Where Trim(q.stcSpermid) = Trim(order.PermId) Select q)                                                ' SEARCH THE DATABASE FOR A CORRESPONDING RECORD USING THE TWS PERMID AS A KEY

                    If orderexists.Count = 0 Then
                        Dim ou = (From q In db.MyOrders Where q.btoSpermid = Trim(btoPermid) Select q).FirstOrDefault()                                                 ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED

                        ou.stcStimestamp = DateTime.Parse(Now).ToUniversalTime()
                        ou.stcSpermid = order.PermId
                        ou.stcSorderid = order.OrderId
                        ou.stcSlimitprice = order.LmtPrice
                        ou.stcSorderstatus = orderState.Status
                        ou.lastactiontimestamp = DateTime.Parse(Now).ToUniversalTime()

                        db.SaveChanges()
                    Else

                        Dim ou = (From q In db.MyOrders Where q.stcSpermid = Trim(order.PermId) Select q).FirstOrDefault()                                                 ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED

                        ou.stcStimestamp = DateTime.Parse(Now).ToUniversalTime()
                        db.SaveChanges()

                    End If



                End If                                                                                                                                              ' END THE CHECK ON WHETHER ORDER STATUS IS PRESUBMITTED OR SUBMITTED

            End If

        End Using                                                                                                                                                   ' END USING THE DATABASE CONNECTION 

        'MsgBox(order.Action.ToString())

        ordermsg = "Perm ID: " & order.PermId & " Order ID: " & order.OrderId & "." & order.Action.ToUpper() & " " & order.TotalQuantity &
                       " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", order.LmtPrice) & " " & contract.SecType &
                       " - " & orderState.Status.ToUpper()                                                                                                          ' SET THE ORDER MESSAGE TO THE ORDER PARAMETERS TO BE DISPLAYED IN THE SERVER LISTBOX

        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                                                       ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX

    End Sub

    Private Sub Tws1_orderStatus(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_orderStatusEvent) Handles Tws1.OnorderStatus


        'Dim tempstring As String = eventArgs.status.ToLower()
        'MsgBox(order.Action)
        'Stop

        Select Case eventArgs.status.ToLower()                                                                                                                      ' DETERMINE HOW TO PROCESS THE ORDER STATE CHANGE

            Case "presubmitted"

                ' WHEN AN ORDER IS PRESUBMITTED TO THE TWS PLATFORM THE FOLLOWING CODE WILL DETERMINE IF THERE IS AN ASSOCIATED ORDER IN THE DATABASE.
                ' IF NOT THE CODE WILL ADD A NEW RECORD FOR THAT ORDERID. IF THE RECORD EXISTS THE CODE WILL UPDATE THE ORDERSTATUS AND TIMESTAMP FOR THE RECORD.
                ' FINALLY, THE CODE WILL DISPLAY THE APPROPRIATE MESSAGE TO THE USER INDICATING WHAT HAPPENED WITH EACH ORDER IN THE LISTBOX OF THE APP.

                Try

                    Using db As BondiModel = New BondiModel()                                                                                                       ' DATABASE MODEL USING ENTITY FRAMEWORK

                        Dim orderexists = (From q In db.MyOrders Where q.btoSpermid = eventArgs.permId Select q)                                                    ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED

                        If orderexists.Count > 0 Then                                                                                                               ' DETERMINE IF THERE IS A RECORD TO UPDATE THE ORDERSTATUS TO SUBMITTED (NOTE: THIS TYPICALLY WILL HAPPEN BETWEEN PRE-SUBMITTED AND SUBMITTED.)

                            Dim ou = (From q In db.MyOrders Where q.btoSpermid = eventArgs.permId Select q).FirstOrDefault()                                        ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED

                            ou.btoSorderstatus = eventArgs.status                                                                                                   ' SET THE ORDERSTATUS OF THE RECORD TO THE EVENT STATUS RESULT                            
                            ou.lastactiontimestamp = DateTime.Parse(Now).ToUniversalTime()                                                                          ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                            db.SaveChanges()                                                                                                                        ' SAVE THE CHANGES TO THE DATABASE  

                        Else

                            ' LEFT EMPTY AS I AM NOT SURE I NEED TO ADD ANY FUNCTIONALITY HERE FOR TO HANDLE IF A PRESUBMITTED ORDER EXISTS IN TWS THAT IS NOT IN THE DATABASE

                        End If

                    End Using

                Catch ex As Exception
                    ' ADD ERROR HANDLING HERE.  SEND ERROR TO THE LIST BOX VERSUS A MESSAGE BOX.
                End Try

            Case "submitted"

                ' WHEN AN ORDER IS PRESUBMITTED TO THE TWS PLATFORM THE FOLLOWING CODE WILL DETERMINE IF THERE IS AN ASSOCIATED ORDER IN THE DATABASE.
                ' IF NOT THE CODE WILL ADD A NEW RECORD FOR THAT ORDERID. IF THE RECORD EXISTS THE CODE WILL UPDATE THE ORDERSTATUS AND TIMESTAMP FOR THE RECORD.
                ' FINALLY, THE CODE WILL DISPLAY THE APPROPRIATE MESSAGE TO THE USER INDICATING WHAT HAPPENED WITH EACH ORDER IN THE LISTBOX OF THE APP.

                Try

                    Using db As BondiModel = New BondiModel()                                                                                                       ' DATABASE MODEL USING ENTITY FRAMEWORK

                        Dim orderexists = (From q In db.MyOrders Where q.btoSpermid = eventArgs.permId Select q)                                                    ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED

                        If orderexists.Count > 0 Then                                                                                                               ' DETERMINE IF THERE IS A RECORD TO UPDATE THE ORDERSTATUS TO SUBMITTED (NOTE: THIS TYPICALLY WILL HAPPEN BETWEEN PRE-SUBMITTED AND SUBMITTED.)

                            Dim ou = (From q In db.MyOrders Where q.btoSpermid = eventArgs.permId Select q).FirstOrDefault()                                        ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED

                            ou.btoSorderstatus = eventArgs.status                                                                                                   ' SET THE ORDERSTATUS OF THE RECORD TO THE EVENT STATUS RESULT                            
                            ou.lastactiontimestamp = DateTime.Parse(Now).ToUniversalTime()                                                                          ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                            db.SaveChanges()                                                                                                                        ' SAVE THE CHANGES TO THE DATABASE  

                        Else

                            ' LEFT EMPTY AS I AM NOT SURE I NEED TO ADD ANY FUNCTIONALITY HERE FOR TO HANDLE IF A PRESUBMITTED ORDER EXISTS IN TWS THAT IS NOT IN THE DATABASE

                        End If

                    End Using

                Catch ex As Exception
                    ' ADD ERROR HANDLING HERE.  SEND ERROR TO THE LIST BOX VERSUS A MESSAGE BOX.
                End Try

            Case "cancelled" '"filled"
                ' WHEN AN ORDER IS FILLED IN THE TWS PLATFORM THE FOLLOWING CODE WILL DETERMINE IF THERE IS AN ASSOCIATED ORDER IN THE DATABASE AND UPDATE THAT RECORD AS FILLED AND CLOSED.
                ' CHECK THE WORKFLOW AFTER THIS HAPPENS TO SEE IF THERE IS A NEED TO ADD CODE HERE TO HANDLE THE SENDING OF THE SUBSEQUENT ORDERS OR NOT.
                ' this status loops twice

                Try
                    Using db As BondiModel = New BondiModel()                                                                                                       ' DATABASE MODEL USING ENTITY FRAMEWORK

                        ' FIRST SEE IF THERE IS A BTO THAT WAS FILLED BY SEARCHING FOR THE BTO PERMID IN THE DB FROM THE BTO PERMID
                        ' BEING SENT FROM TWS IN THE EVENTARGS 

                        Dim orderexists = (From q In db.MyOrders Where q.btoSpermid = eventArgs.permId Select q)                                                    ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED

                        If orderexists.Count > 0 Then                                                                                                               ' DETERMINE IF THERE IS A RECORD TO UPDATE THAT MATCHES THE PERMID OF CANCELLED ORDER

                            Dim ou = (From q In db.MyOrders Where q.btoSpermid = eventArgs.permId Select q).FirstOrDefault()                                        ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED

                            ' First log that the BTO was filled

                            If ou.btoSorderstatus <> "filled" Then
                                ou.btoSorderstatus = "filled"    ' eventArgs.status
                                ou.btoSfillprice = eventArgs.lastFillPrice
                                ou.lastactiontimestamp = DateTime.Parse(Now).ToUniversalTime()                                                                      ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME
                                ou.btoSfilledtimestamp = DateTime.Parse(Now).ToUniversalTime()                                                                      ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME
                                ou.btoSCapital = ou.shares * eventArgs.lastFillPrice

                                db.SaveChanges()

                                'ordermsg = "Perm ID: " & eventArgs.permId & " Order ID: " & ou.btoSorderid & "." & " - " & eventArgs.status.ToUpper()               ' SET THE ORDER MESSAGE TO THE ORDER PARAMETERS TO BE DISPLAYED IN THE SERVER LISTBOX

                                ordermsg = "Perm ID: " & eventArgs.permId & " Order ID: " & ou.btoSorderid & "." & " BUY" & " " & ou.shares &
                                " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", eventArgs.lastFillPrice + ou.btoSfillprice) & " " & contract.SecType &
                                " - " & eventArgs.status.ToUpper()                                                                                                  ' SET THE ORDER MESSAGE TO THE ORDER PARAMETERS TO BE DISPLAYED IN THE SERVER LISTBOX

                                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                               ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX

                                ' Second, send a STC order
                                btoPermid = ou.btoSpermid
                                Call sendSTCStockorder(ou.btoSlimitprice)       ' REPLACE THIS WITH ou.btolimitprice
                                Call sendBTOStockorder(ou.btoSlimitprice)

                                ' Third, check for long put hedge at this price - if exist do nothing, else calc expiration & strike and send long put hedge order

                                Dim LPexists = (From q In db.MyOrders Where q.btoSlimitprice = orderprice And q.LPbtoOpen = True Select q)                          ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH A LONG PUT AT THIS PRICE


                                If LPexists.Count = 0 Then


                                    Dim calcexpdate As Date = String.Format("{0: MM/dd/yy}", calcExpirationDate())                                                   ' IF A HEDGE IS NEEDED CALCULATE THE EXPIRATION DATE TARGET TO BE USED IN THE BLACK SCHOLES CALCULATION
                                    'Stop
                                    'Call sendLongPutOptionOrder(calcexpdate, ou.btoSlimitprice)







                                    'Using db As BondiModel = New BondiModel()                                                                                   ' DATABASE MODEL USING ENTITY FRAMEWORK

                                    Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                           ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
                                        hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = harvestkey).ToList()                               ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

                                    Dim contract As New IBApi.Contract                                                                                                                                   ' INITIALIZE THE CONTRACT CLASS VARIABLE AS AN ibapi CONTRACT

                                    contract.Symbol = hi.FirstOrDefault().product.ToUpper()                                                                 ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
                                    contract.SecType = "OPT"        'hi.FirstOrDefault().stocksectype.ToUpper()                                             ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
                                    contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                                          ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
                                    contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                                              ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

                                    contract.LastTradeDateOrContractMonth = "20190315"
                                    contract.Strike = Int(ou.btoSlimitprice - hi.FirstOrDefault().hedgewidth)
                                    contract.Right = "P"

                                    ' cprice = 0.88               ' txtPrice.Text

                                    order.OrderType = "MKT"                 ' hi.FirstOrDefault().ordertype.ToUpper()                                   ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
                                    order.TotalQuantity = 1                 ' hi.FirstOrDefault().shares                                                ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
                                    order.Tif = "GTC"                       ' hi.FirstOrDefault().inforce.ToUpper()                                     ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)
                                    order.OrderId = nextValidOrderId                                                                                    ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
                                    order.Action = "BUY"                    ' txtAction.Text.ToUpper()                                                  ' SET THE ORDER ACTION 
                                    'order.LmtPrice = cprice                                                                                             ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

                                    Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 
                                    'Tws1.reqMktDataEx(1, contract, "", True, Nothing)

                                    'End Using








                                    '    ordermsg = " Hedge Order Sent: "                                                                                                ' SET THE ORDER MESSAGE TO THE ORDER PARAMETERS TO BE DISPLAYED IN THE SERVER LISTBOX
                                    '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                           ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
                                Else
                                    Stop
                                End If


                            End If

                        Else
                            ' SECOND SEE IF THERE IS A STC THAT WAS FILLED BY SEARCHING FOR THE STC PERMID IN THE EB FROM THE STC PERMID
                            ' SENT FROM TWS IN THE EVENTARGS

                            orderexists = (From q In db.MyOrders Where q.stcSpermid = eventArgs.permId Select q)                                                    ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED

                            If orderexists.Count > 0 Then

                                Dim ou = (From q In db.MyOrders Where q.stcSpermid = eventArgs.permId Select q).FirstOrDefault()                                        ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED

                                ' First log that the BTO was filled

                                If ou.stcSorderstatus <> "filled" Then
                                    ou.stcSorderstatus = eventArgs.status
                                    ou.stcSfillprice = eventArgs.lastFillPrice
                                    ou.lastactiontimestamp = DateTime.Parse(Now).ToUniversalTime()                                                                      ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME
                                    ou.stcSfilledtimestamp = DateTime.Parse(Now).ToUniversalTime()                                                                      ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                                    db.SaveChanges()

                                    'ordermsg = "Perm ID: " & order.PermId & " Order ID: " & order.OrderId & "." & " - " & eventArgs.status.ToUpper()                   ' SET THE ORDER MESSAGE TO THE ORDER PARAMETERS TO BE DISPLAYED IN THE SERVER LISTBOX

                                    ordermsg = "Perm ID: " & eventArgs.permId & " Order ID: " & ou.btoSorderid & "." & " SELL" & " " & ou.shares &
                                        " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", eventArgs.lastFillPrice + ou.stcSfillprice) & " " & contract.SecType &
                                        " - " & eventArgs.status.ToUpper()                                                                                              ' SET THE ORDER MESSAGE TO THE ORDER PARAMETERS TO BE DISPLAYED IN THE SERVER LISTBOX

                                    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                               ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX

                                    ' Second, Modify the current open BTO order.
                                    Dim btoorderexists = (From q In db.MyOrders Where q.btoSorderstatus.ToLower() = "presubmitted" Or
                                                                                q.btoSorderstatus.ToLower() = "submitted" Select q)

                                    If btoorderexists.Count > 0 Then
                                        Dim btoou = (From q In db.MyOrders Where q.btoSorderstatus.ToLower() = "presubmitted" Or
                                                                                    q.btoSorderstatus.ToLower() = "submitted" Select q).FirstOrDefault()

                                        btoou.btoSlimitprice = btoou.btoSlimitprice + buytrigger
                                        btoou.lastactiontimestamp = DateTime.Parse(Now).ToUniversalTime()                                                                      ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                                        db.SaveChanges()

                                        Call modifyBTOStockorder(btoou.btoSpermid, ou.btoSlimitprice)

                                    End If

                                End If

                                    'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                                   ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX

                                End If
                        End If



                    End Using
                Catch ex As Exception

                End Try

            Case "filled" '"cancelled"

                Try

                    Using db As BondiModel = New BondiModel()                                                                                                       ' DATABASE MODEL USING ENTITY FRAMEWORK

                        ' FIRST SEE IF THERE IS A BTO THAT WAS FILLED BY SEARCHING FOR THE BTO PERMID IN THE DB FROM THE BTO PERMID
                        ' BEING SENT FROM TWS IN THE EVENTARGS 

                        Dim orderexists = (From q In db.MyOrders Where q.btoSpermid = eventArgs.permId Select q)                                                    ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED

                        If orderexists.Count > 0 Then                                                                                                               ' DETERMINE IF THERE IS A RECORD TO UPDATE THAT MATCHES THE PERMID OF CANCELLED ORDER

                            Dim ou = (From q In db.MyOrders Where q.btoSpermid = eventArgs.permId Select q).FirstOrDefault()                                        ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED

                            ' THIS IS THE CANCEL CODE THAT MUST REMAIN
                            ou.btoSorderstatus = eventArgs.status                                                                                               ' SET THE ORDERSTATUS OF THE RECORD TO THE EVENT STATUS RESULT
                            ou.lastactiontimestamp = DateTime.Parse(Now).ToUniversalTime()                                                                      ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                            db.SaveChanges()                                                                                                                    ' SAVE THE CHANGES TO THE DATABASE                            

                            ordermsg = "Perm ID: " & eventArgs.permId & " Order ID: " & eventArgs.orderId & "." & eventArgs.status.ToLower()                    ' SET THE ORDER MESSAGE TO THE ORDER PARAMETERS TO BE DISPLAYED IN THE SERVER LISTBOX

                        End If

                        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                                   ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX

                    End Using

                Catch ex As Exception

                End Try

        End Select

    End Sub








    Private Sub Tws1_managedAccounts(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_managedAccountsEvent) Handles Tws1.OnmanagedAccounts

        Dim msg As String                                                                                                               ' VARIABLE USED TO HOUSE THE MESSAGE DETAILS COMMUNICATED TO THE USER

        ' TODO:  Add code here to check the database for the amount of time that the user has traded in 
        ' paper before they can use the robot live.  Initial thoughts are 6 months with 75 days of activity 
        ' using the robot before live account through the robot can be used.        

        If Mid(eventArgs.accountsList, 1, 1) = "D" Then                                                                                 ' DETERMINE THE ACCOUNT TYPE THE USER IS LOGGED INTO TWS WITH 
            msg = "CONNECTED : PAPER account: [" & eventArgs.accountsList & "]"                                                         ' MESSAGE SENT TO THE CONNECTED MESSAGE LISTBOX INDICATING CONNECTED, ACCOUNT TYPE, AND ACCOUNT NUMBER
        Else
            msg = "CONNECTED : The LIVE account: [" & eventArgs.accountsList & "]"                                                      ' MESSAGE SENT TO THE CONNECTED MESSAGE LISTBOX INDICATING CONNECTED, ACCOUNT TYPE, AND ACCOUNT NUMBER 

            MsgBox("This application is only set up for a paper trading account")

            Me.Close()


        End If
        Call m_utils.addListItem(Utils.List_Types.CONNECTION_RESPONSES, msg)                                                                ' CALL THE MESSAGE UTILITY TO PRESENT THE CONNECTED ACCOUNT INFORMATIOJN TO THE USER

        'm_faAccount = True                                                                                                              ' SET THE FINANCIAL ACCOUNT MANAGER STATUS TO TRUE
        'm_faAcctsList = eventArgs.accountsList                                                                                          ' SET THE ACCOUNTS LIST TO THE CURRENT LIST OF ACCOUNTS FOR THE LOGGED IN USER        

    End Sub

    Private Sub Tws1_tickPrice(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickPriceEvent) Handles Tws1.OnTickPrice

        ' THIS SUB RETURNS TICK PRICE DATA FROM TWS. THIS WILL BE USED TO POPULATE DATA FOR ALL PRODUCT TYPES: STOCK, OPTIONS, FUTURES ETC.

        Select Case eventArgs.tickType
            Case 1                                                                                                                                                  ' BID PRICE OF PRODUCT
                'MsgBox("bid " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
                bid = eventArgs.price
                lblBid.Text = String.Format("{0:C}", bid)
            Case 2                                                                                                                                                  ' CASE FOR ASK
                'MsgBox("ask " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
                ask = eventArgs.price
                lblAsk.Text = String.Format("{0:C}", ask)
            Case 4
                'MsgBox("last " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())

                If ckTest.Checked = True Then
                    lastprice = txtTestPrice.Text 'eventArgs.price
                    lblLastPrice.Text = String.Format("{0:C}", lastprice)
                    If lastprice >= btomoveprice Then
                        If btomoveprice > 0 Then
                            Call modifyBTOStockorder(btoPermid, 0)
                        End If
                    End If
                Else
                    lastprice = eventArgs.price
                    lblLastPrice.Text = String.Format("{0:C}", lastprice)
                    'MsgBox(String.Format("{0:C}", orderprice) & " " & String.Format("{0:C}", btomoveprice))
                    'MsgBox(String.Format("{0:C}", closeprice) & " " & String.Format("{0:C}", btomoveprice))
                End If


            Case 6
                'MsgBox("high " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 7
                'MsgBox("low " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 9
                'MsgBox("close " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())


                If ckTest.Checked = True Then
                    closeprice = txtTestPrice.Text
                    lblClose.Text = String.Format("{0:C}", closeprice)

                    If lastprice = 0 Then
                        lastprice = closeprice
                        lblLastPrice.Text = String.Format("{0:C}", lastprice)
                    End If

                    'MsgBox(String.Format("{0:C}", orderprice) & " " & String.Format("{0:C}", btomoveprice))
                    'If closeprice >= btomoveprice Then
                    '    If btomoveprice > 0 Then
                    '        Call modifyBTOStockorder(btoPermid)
                    '    End If
                    'End If
                Else
                    closeprice = eventArgs.price
                    lblClose.Text = String.Format("{0:C}", closeprice)
                    If lastprice = 0 Then
                        lastprice = closeprice
                        lblLastPrice.Text = String.Format("{0:C}", lastprice)
                    End If
                    'MsgBox(String.Format("{0:C}", orderprice) & " " & String.Format("{0:C}", btomoveprice))
                    'MsgBox(String.Format("{0:C}", closeprice) & " " & String.Format("{0:C}", btomoveprice))
                End If



            Case 14
               ' MsgBox("open " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 15
                'MsgBox("13 week low " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 16
                'MsgBox("13 week high " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 17
               ' MsgBox("26 week low " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 18
                'MsgBox("26 week high " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 19
                'MsgBox("52week low " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 20
                'MsgBox("52 week high " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 35
                'MsgBox("auction price " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 37
                'MsgBox("mark price " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 50
                'MsgBox("bid yield " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 51
                'MsgBox("ask yield " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 52
                'MsgBox("last yield " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 57
                'MsgBox("last RTH trade " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 66
                'MsgBox("delayed bid " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
                bid = eventArgs.price
                lblBid.Text = String.Format("{0:C}", bid)
            Case 67
                'MsgBox("delayed ask " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
                ask = eventArgs.price
                lblAsk.Text = String.Format("{0:C}", ask)
            Case 68
                'MsgBox("delayed last " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
                lastprice = eventArgs.price
                lblLastPrice.Text = String.Format("{0:C}", lastprice)
                If lastprice >= btomoveprice Then
                    Call modifyBTOStockorder(btoPermid, 0)
                End If

            Case 72
                'MsgBox("delayed high " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 73
                'MsgBox("delayed low " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 75
                'MsgBox("delayed close " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())


                If ckTest.Checked = True Then
                    closeprice = txtTestPrice.Text
                    lblClose.Text = String.Format("{0:C}", closeprice)
                    'MsgBox(String.Format("{0:C}", orderprice) & " " & String.Format("{0:C}", btomoveprice))
                    If closeprice >= btomoveprice Then
                        Call modifyBTOStockorder(btoPermid, 0)
                    End If
                Else
                    closeprice = eventArgs.price
                    lblClose.Text = String.Format("{0:C}", closeprice)
                    'MsgBox(String.Format("{0:C}", orderprice) & " " & String.Format("{0:C}", btomoveprice))
                    'MsgBox(String.Format("{0:C}", closeprice) & " " & String.Format("{0:C}", btomoveprice))
                End If

            Case 76
                'MsgBox("delayed open " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 78
            Case 79
            Case 80
                'MsgBox("delayed bid option " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 81
                'MsgBox("delayed ask option " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 82
                'MsgBox("delayed last option " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())
            Case 83
                'MsgBox("delayed model option " & eventArgs.id & ":" & eventArgs.price & ":" & eventArgs.tickCount & ":" & eventArgs.tickType.ToString())


        End Select



        'priceamount = eventArgs.price

        ''Stop

        'Select Case eventArgs.tickType
        '    Case 1
        '        'oBid = eventArgs.price
        '        pricetype = " " & eventArgs.tickType.ToString() & " "
        '        bid = eventArgs.price
        '        lblBid.Text = String.Format("{0:C}", bid)
        '    Case 2
        '        'oAsk = eventArgs.price
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask))
        '        pricetype = " " & eventArgs.tickType.ToString() & " "
        '        ask = eventArgs.price
        '        lblAsk.Text = String.Format("{0:C}", ask)
        '    Case 4
        '        'oLast = eventArgs.price

        '        'MsgBox(prod)


        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "last: " & String.Format("{0:C}", last))
        '        pricetype = " " & eventArgs.tickType.ToString() & " "
        '        priceamount = 39.3 'eventArgs.price
        '        lastamount = 39.3 'eventArgs.price
        '        currentprice = 39.3 ' eventArgs.price

        '        priceint = Int(currentprice)                                                                                                                        ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
        '        checksum = currentprice - priceint                                                                                                                  ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
        '        cprice = (Int(checksum / buytrigger) * buytrigger + priceint)                                                                                       ' CALCULATE THE STARTING BUY TO OPEN PRICE 
        '        btomoveprice = cprice + (2 * buytrigger)                                                                                                            ' CALCULATE THE PRICE TO MOVE AN OPEN BTO IF THE STOCK PRICE MOVES UP (TRAILING BTO)

        '        lblLastPrice.Text = String.Format("{0:C}", lastamount)                                                                                              ' SEND THE CURRENT PRICE TO THE VIEW FOMATTED IN CURRENCY
        '        lblOrderPrice.Text = String.Format("{0:C}", cprice)                                                                                                 ' SEND THE EXISTING BTO TO THE VIEW FORMATTED IN CURRENCY
        '        lblBTOMovePrice.Text = String.Format("{0:C}", btomoveprice)                                                                                         ' SEND THE TRAILING BTO TRIGGER TO THE VIEW FORMATTED IN CURRENCY

        '    Case 6
        '        'oHighToday = eventArgs.price
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "Last: " & String.Format("{0:C}", last) & " High: " & String.Format("{0:C}", hightoday))
        '        pricetype = " " & eventArgs.tickType.ToString() & " "
        '        priceamount = eventArgs.price
        '        'lbloHighToday.Text = String.Format("{0:C}", oHighToday)
        '    Case 7

        '        'oLowToday = eventArgs.price
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "Last: " & String.Format("{0:C}", last) & " High: " & String.Format("{0:C}", hightoday) & " low: " & String.Format("{0:C}", lowtoday))
        '        pricetype = " " & eventArgs.tickType.ToString() & " "
        '        priceamount = eventArgs.price
        '        'lbloLowToday.Text = String.Format("{0:C}", oLowToday)
        '    Case 9

        '        'oClose = eventArgs.price
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) &
        '        '       " Ask: " & String.Format("{0:C}", ask) &
        '        '       " Last: " & String.Format("{0:C}", last) &
        '        '       " High: " & String.Format("{0:C}", hightoday) &
        '        '       " Low: " & String.Format("{0:C}", lowtoday) &
        '        '       " Close: " & String.Format("{0:C}", closetoday))
        '        pricetype = " " & eventArgs.tickType.ToString() & " "
        '        priceamount = 39.3 'eventArgs.price
        '        closeamount = 39.3

        '        'lblOprior.Text = String.Format("{0:C}", oClose)                                                                          ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE PRIOR DAYS CLOSE PRICE
        '    Case 14

        '        'oOpenToday = eventArgs.price
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) &
        '        '       " Ask: " & String.Format("{0:C}", ask) &
        '        '       " Last: " & String.Format("{0:C}", last) &
        '        '       " Open: " & String.Format("{0:C}", opentoday) &
        '        '       " High: " & String.Format("{0:C}", hightoday) &
        '        '       " Low: " & String.Format("{0:C}", lowtoday) &
        '        '       " Close: " & String.Format("{0:C}", closetoday))
        '        pricetype = " " & eventArgs.tickType.ToString() & " "
        '        priceamount = eventArgs.price
        '        'lbloOpenToday.Text = String.Format("{0:C}", oOpenToday)
        'End Select










        ' Else                                                                                                                        ' CAPTURE THE STOCK OR FUTURES DATA
        'Select Case eventArgs.tickType
        '    Case 1
        '        bid = eventArgs.price
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid))
        '        lblBidPrice.Text = String.Format("{0:C}", bid)                                                                              ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE BID PRICE
        '    Case 2
        '        ask = eventArgs.price
        '        'MsgBox("Ask: " & String.Format("{0:C}", ask))
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask))
        '        lblAskPrice.Text = String.Format("{0:C}", ask)                                                                              ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE ASK PRICE
        '    Case 4
        '        last = eventArgs.price
        '        'MsgBox("Last: " & String.Format("{0:C}", last))
        '        lblPriorClose.Text = String.Format("{0:C}", prior)                                                                          ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE PRIOR DAYS CLOSE PRICE
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "last: " & String.Format("{0:C}", last))
        '    Case 6
        '        hightoday = eventArgs.price
        '        'MsgBox("High: " & String.Format("{0:C}", hightoday))
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "Last: " & String.Format("{0:C}", last) & " High: " & String.Format("{0:C}", hightoday))
        '        lblTodaysHigh.Text = String.Format("{0:C}", hightoday)                                                                      ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE TODAYS HIGH PRICE
        '    Case 7
        '        lowtoday = eventArgs.price
        '        ' MsgBox(" low: " & String.Format("{0:C}", lowtoday))
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "Last: " & String.Format("{0:C}", last) & " High: " & String.Format("{0:C}", hightoday) & " low: " & String.Format("{0:C}", lowtoday))
        '        lblTodaysLow.Text = String.Format("{0:C}", lowtoday)                                                                        ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE TODAYS LOW PRICE
        '    Case 9
        '        closetoday = eventArgs.price
        '        'MsgBox(" Close: " & String.Format("{0:C}", closetoday))
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) &
        '        '   " Ask: " & String.Format("{0:C}", ask) &
        '        '   " Last: " & String.Format("{0:C}", last) &
        '        '   " High: " & String.Format("{0:C}", hightoday) &
        '        '   " Low: " & String.Format("{0:C}", lowtoday) &
        '        '   " Close: " & String.Format("{0:C}", closetoday))
        '        lblLastPrice.Text = String.Format("{0:C}", closetoday)                                                                            ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE LAST TRADE PRICE
        '    Case 14
        '        opentoday = eventArgs.price
        '        'MsgBox(" Open: " & String.Format("{0:C}", opentoday))
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) &
        '        '       " Ask: " & String.Format("{0:C}", ask) &
        '        '       " Last: " & String.Format("{0:C}", last) &
        '        '       " Open: " & String.Format("{0:C}", opentoday) &
        '        '       " High: " & String.Format("{0:C}", hightoday) &
        '        '       " Low: " & String.Format("{0:C}", lowtoday) &
        '        '       " Close: " & String.Format("{0:C}", closetoday))
        '        lblTodaysOpen.Text = String.Format("{0:C}", opentoday)                                                                      ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE OPEN TODAY PRICE
        'End Select











        ' End If

        'Select Case eventArgs.tickType
        '    Case 1
        '        'bid = eventArgs.price
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid))
        '    Case 2
        '        'ask = eventArgs.price
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask))
        '    Case 4
        '        'last = eventArgs.price
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "last: " & String.Format("{0:C}", last))
        '    Case 6
        '        'hightoday = eventArgs.price
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "Last: " & String.Format("{0:C}", last) & " High: " & String.Format("{0:C}", hightoday))
        '    Case 7
        '        'lowtoday = eventArgs.price
        '       'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "Last: " & String.Format("{0:C}", last) & " High: " & String.Format("{0:C}", hightoday) & " low: " & String.Format("{0:C}", lowtoday))
        '    Case 9
        '        'closetoday = eventArgs.price
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) &
        '        '       " Ask: " & String.Format("{0:C}", ask) &
        '        '       " Last: " & String.Format("{0:C}", last) &
        '        '       " High: " & String.Format("{0:C}", hightoday) &
        '        '       " Low: " & String.Format("{0:C}", lowtoday) &
        '        '       " Close: " & String.Format("{0:C}", closetoday))
        '    Case 14
        '        'opentoday = eventArgs.price
        '        'MsgBox("Bid: " & String.Format("{0:C}", bid) &
        '        '       " Ask: " & String.Format("{0:C}", ask) &
        '        '       " Last: " & String.Format("{0:C}", last) &
        '        '       " Open: " & String.Format("{0:C}", opentoday) &
        '        '       " High: " & String.Format("{0:C}", hightoday) &
        '        '       " Low: " & String.Format("{0:C}", lowtoday) &
        '        '       " Close: " & String.Format("{0:C}", closetoday))
        'End Select



        'If sectype = "OPT" And eventArgs.tickType >= 7 Then

        '    lastoptionprice = last

        '    Stop

        '    MsgBox("Bid: " & String.Format("{0:C}", bid) &
        '               " Ask: " & String.Format("{0:C}", ask) &
        '               " Last: " & String.Format("{0:C}", last) &
        '               " High: " & String.Format("{0:C}", hightoday) &
        '               " Low: " & String.Format("{0:C}", lowtoday) &
        '               " Close: " & String.Format("{0:C}", closetoday))
        '    lblOprior.Text = String.Format("{0:C}", oPrior)
        '    lbloOpenToday.Text = String.Format("{0:C}", oOpenToday)
        '    lbloHighToday.Text = String.Format("{0:C}", hightoday)
        '    lbloLowToday.Text = String.Format("{0:C}", lowtoday)

        '    lbloBidPrice.Text = String.Format("{0:C}", bid)
        '    lbloAskPrice.Text = String.Format("{0:C}", ask)

        '    If lblLastPrice.Text = last Then
        '        Dim calcexpdate As Date = String.Format("{0: MM/dd/yy}", calcExpirationDate(harvestkey, Now()))                         ' IF A HEDGE IS NEEDED CALCULATE THE EXPIRATION DATE TARGET TO BE USED IN THE BLACK SCHOLES CALCULATION

        '        getOptionPrice(harvestkey, calcexpdate, 26.5)
        '    End If
        '    lbloLast.Text = String.Format("{0:C}", last)
        '    'lblBidPrice.Text = String.Format("{0:C}", 0)                                                                            ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE BID PRICE
        '    'lblAskPrice.Text = String.Format("{0:C}", 0)                                                                            ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE ASK PRICE
        '    'lblTodaysOpen.Text = String.Format("{0:C}", 0)                                                                          ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE OPEN TODAY PRICE
        '    'lblPriorClose.Text = String.Format("{0:C}", 0)                                                                          ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE PRIOR DAYS CLOSE PRICE
        '    'lblTodaysLow.Text = String.Format("{0:C}", 0)                                                                           ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE TODAYS LOW PRICE
        '    'lblTodaysHigh.Text = String.Format("{0:C}", 0)                                                                          ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE TODAYS HIGH PRICE
        '    'lblLastPrice.Text = String.Format("{0:C}", 0)                                                                           ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE LAST TRADE PRICE

        '    sectype = "STK"

        '    'getPriceData()

        'End If

        'If sectype = "STK" And eventArgs.tickType >= 14 Then

        '    '    'MsgBox("Bid: " & String.Format("{0:C}", bid) &
        '    '    '           " Ask: " & String.Format("{0:C}", ask) &
        '    '    '           " Last: " & String.Format("{0:C}", last) &
        '    '    '           " High: " & String.Format("{0:C}", hightoday) &
        '    '    '           " Low: " & String.Format("{0:C}", lowtoday) &
        '    '    '           " Close: " & String.Format("{0:C}", closetoday))
        '    lblBidPrice.Text = String.Format("{0:C}", bid)                                                                              ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE BID PRICE
        '    lblAskPrice.Text = String.Format("{0:C}", ask)                                                                              ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE ASK PRICE
        '    lblTodaysOpen.Text = String.Format("{0:C}", opentoday)                                                                      ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE OPEN TODAY PRICE
        '    lblPriorClose.Text = String.Format("{0:C}", prior)                                                                          ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE PRIOR DAYS CLOSE PRICE
        '    lblTodaysLow.Text = String.Format("{0:C}", lowtoday)                                                                        ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE TODAYS LOW PRICE
        '    lblTodaysHigh.Text = String.Format("{0:C}", hightoday)                                                                      ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE TODAYS HIGH PRICE
        '    lblLastPrice.Text = String.Format("{0:C}", last)                                                                            ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE LAST TRADE PRICE

        '    '    sectype = "OPT"

        'End If






        'If eventArgs.tickType = 1 Or eventArgs.tickType = 66 Then
        '        bid = eventArgs.price                                                                                                   ' ASSIGN THE EVENT ARGUMENT PRICE TO THE BID VARIABLE
        '    ElseIf eventArgs.tickType = 2 Or eventArgs.tickType = 67 Then
        '        ask = eventArgs.price                                                                                                   ' ASSIGN THE EVENT ARGUMENT PRICE TO THE ASK VARIABLE
        '    ElseIf eventArgs.tickType = 4 Or eventArgs.tickType = 68 Then
        '        last = eventArgs.price                                                                                                  ' ASSIGN THE EVENT ARGUMENT PRICE TO THE LAST VARIABLE
        '        priceint = Int(last)                                                                                                    ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
        '        checksum = last - priceint                                                                                              ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
        '        cprice = (Int(checksum / buytrigger) * buytrigger + priceint)                                                           ' CALCULATE THE STARTING BUY TO OPEN PRICE 


        '        trail = cprice + 0.1 'selltrigger * 2
        '        lblbtoMove.Text = String.Format("{0:C}", trail)



        '        If last > trail Then
        '            trail = trail + 0.1
        '        End If

        '        ' HERE IS WHERE i NEED TO ADD IN CODE TO DETERMINE IF THE LAST PRICE IS GREATER THAN THE TRAIL IN ORDER TO MOVE THE CURRENT BTO

        '        lblCurrentMark.Text = String.Format("{0:C}", cprice)                                                                    ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE CURRENT MARK
        '        lblbtoMove.Text = String.Format("{0:C}", trail)                                                                         ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE CURRENT MARK
        '        lblNextBTO.Text = String.Format("{0:C}", cprice - buytrigger)                                                           ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE CURRENT MARK


        '    ElseIf eventArgs.tickType = 6 Or eventArgs.tickType = 72 Then
        '        hightoday = eventArgs.price                                                                                             ' ASSIGN THE EVENT ARGUMENT PRICE TO THE HIGH TODAY VARIABLE
        '    ElseIf eventArgs.tickType = 7 Or eventArgs.tickType = 73 Then
        '        lowtoday = eventArgs.price                                                                                              ' ASSIGN THE EVENT ARGUMENT PRICE TO THE LOW TODAY VARIABLE
        '    ElseIf eventArgs.tickType = 9 Or eventArgs.tickType = 75 Then
        '        prior = eventArgs.price                                                                                                 ' ASSIGN THE EVENT ARGUMENT PRICE TO THE PRIOR DAYS PRICE VARIABLE
        '    ElseIf eventArgs.tickType = 14 Then
        '        opentoday = eventArgs.price                                                                                             ' ASSIGN THE EVENT ARGUMENT PRICE TO THE OPEN TODAY VARIABLE
        '    End If

        '    lblBidPrice.Text = String.Format("{0:C}", bid)                                                                              ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE BID PRICE
        '    lblAskPrice.Text = String.Format("{0:C}", ask)                                                                              ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE ASK PRICE
        '    lblTodaysOpen.Text = String.Format("{0:C}", opentoday)                                                                      ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE OPEN TODAY PRICE
        '    lblPriorClose.Text = String.Format("{0:C}", prior)                                                                          ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE PRIOR DAYS CLOSE PRICE
        '    lblTodaysLow.Text = String.Format("{0:C}", lowtoday)                                                                        ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE TODAYS LOW PRICE
        '    lblTodaysHigh.Text = String.Format("{0:C}", hightoday)                                                                      ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE TODAYS HIGH PRICE
        '    lblLastPrice.Text = String.Format("{0:C}", last)                                                                            ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE LAST TRADE PRICE

        '    datastring = "Symbol: " & ticksymbol & " Last Price: " & String.Format("{0:C}", last) &
        '    " Time: " & String.Format("{0:hh:mm:ss}", Now.ToLocalTime)                                                              ' SET THE DATASTRING FOR THE LISTBOX DISPLAY       & " Tick Type: "

        '    lblConStatus.Text = datastring                                                                                              ' PUSH THE DATASTRING DATA TO THE VIEW FOR THE USER TO SEE THE INFORMATION
        '    currentprice = last                                                                                                         ' SET THE PUBLIC VARIABLE CURRENT PRICE TO THE TICKPRICE
        '    'txtPrice.Text = currentprice                                                                                                ' SEND THE TICKPRICE TO THE VIEW FOR THE USER TO SEE
        '    underlying = last
        'End If




        'Stop
        ' Insert willie mark calculation here.

        ' THIS IS FOR OPTIONS - NEED TO WORK THROUGH THE FLAGS AND THE PROCESS 
        'ElseIf pricetype = 2 Then                                                                                                       ' INDICATES THAT THIS IS AN OPTION PRICE BEING RETRIEVED

        ' test

        '    If eventArgs.tickType = 1 Or eventArgs.tickType = 66 Then
        '        oBid = eventArgs.price
        '    ElseIf eventArgs.tickType = 2 Or eventArgs.tickType = 67 Then
        '        oAsk = eventArgs.price                                                                                                   ' ASSIGN THE EVENT ARGUMENT PRICE TO THE ASK VARIABLE
        '    ElseIf eventArgs.tickType = 4 Or eventArgs.tickType = 68 Then
        '        oLast = eventArgs.price
        '    ElseIf eventArgs.tickType = 6 Or eventArgs.tickType = 72 Then
        '        oHighToday = eventArgs.price                                                                                             ' ASSIGN THE EVENT ARGUMENT PRICE TO THE HIGH TODAY VARIABLE
        '    ElseIf eventArgs.tickType = 7 Or eventArgs.tickType = 73 Then
        '        oLowToday = eventArgs.price                                                                                              ' ASSIGN THE EVENT ARGUMENT PRICE TO THE LOW TODAY VARIABLE
        '    ElseIf eventArgs.tickType = 9 Or eventArgs.tickType = 75 Then
        '        oPrior = eventArgs.price                                                                                                 ' ASSIGN THE EVENT ARGUMENT PRICE TO THE PRIOR DAYS PRICE VARIABLE
        '    ElseIf eventArgs.tickType = 14 Then
        '        oOpenToday = eventArgs.price                                                                                             ' ASSIGN THE EVENT ARGUMENT PRICE TO THE OPEN TODAY VARIABLE' ASSIGN THE EVENT ARGUMENT PRICE TO THE LAST VARIABLE
        '    End If

        '    lblOprior.Text = String.Format("{0:C}", oPrior)
        '    lbloOpenToday.Text = String.Format("{0:C}", oOpenToday)
        '    lbloHighToday.Text = String.Format("{0:C}", oHighToday)
        '    lbloLowToday.Text = String.Format("{0:C}", oLowToday)
        '    lbloLast.Text = String.Format("{0:C}", oLast)

        '    lbloAskPrice.Text = String.Format("{0:C}", oAsk)

        ' MsgBox(String.Format("{0:C}", oLast))

        'mktDataStr = "Symbol: " & "VXX " & "Exp. Strike " & String.Format("{0:C}", optionstrike) & " " & eventArgs.tickType.ToString() & ": " & String.Format("{0:C}", eventArgs.price, eventArgs.tickCount)




        mktDataStr = "Symbol: " & ticksymbol.ToUpper() & " " & pricetype.ToUpper() & " : " & String.Format("{0:C}", priceamount) '& " " & eventArgs.tickType.ToString() & ": " & String.Format("{0:C}", eventArgs.price, eventArgs.tickCount)
        ' Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)                                                             ' WRITES THE CURRENT PRICE TO THE LISTBOX

        ' pricetype = 1

        ' End If






    End Sub

    Private Sub Tws1_tickSize(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickSizeEvent) Handles Tws1.OnTickSize

        Select Case eventArgs.tickType
            Case 0
            Case 3
                ' BID Size
            Case 5
            Case 21
            Case 27
            Case 28
            Case 29
            Case 30
            Case 34
            Case 36
            Case 61
            Case 63
            Case 64
            Case 65
            Case 69
            Case 70
            Case 71
            Case 74
            Case 87

        End Select

        Dim mktDataStr As String
        mktDataStr = "id=" & eventArgs.id & " " & m_utils.getField(eventArgs.tickType) & "=" & eventArgs.size

        ' Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)

    End Sub

    Private Sub Tws1_tickOptionComputation(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickOptionComputationEvent) Handles Tws1.OnTickOptionComputation

        Select Case eventArgs.tickType
            Case 10
            Case 11
            Case 12
            Case 13
            Case 53
        End Select



        'Stop
        ' TODO: COMMENT AND ERROR PROOF THE CODE BLOCK

        'Dim mktDataStr As String, volStr As String, deltaStr As String, gammaStr As String, vegaStr As String,
        '    thetaStr As String, optPriceStr As String, pvDividendStr As String, undPriceStr As String

        'If eventArgs.impliedVolatility = Double.MaxValue Or eventArgs.impliedVolatility < 0 Then
        '    volStr = "N/A"
        'Else
        '    volStr = eventArgs.impliedVolatility
        'End If
        'If eventArgs.delta = Double.MaxValue Or Math.Abs(eventArgs.delta) > 1 Then
        '    deltaStr = "N/A"
        'Else
        '    deltaStr = eventArgs.delta
        'End If
        'If eventArgs.gamma = Double.MaxValue Or Math.Abs(eventArgs.gamma) > 1 Then
        '    gammaStr = "N/A"
        'Else
        '    gammaStr = eventArgs.gamma
        'End If
        'If eventArgs.vega = Double.MaxValue Or Math.Abs(eventArgs.vega) > 1 Then
        '    vegaStr = "N/A"
        'Else
        '    vegaStr = eventArgs.vega
        'End If
        'If eventArgs.theta = Double.MaxValue Or Math.Abs(eventArgs.theta) > 1 Then
        '    thetaStr = "N/A"
        'Else
        '    thetaStr = eventArgs.theta
        'End If
        'If eventArgs.optPrice = Double.MaxValue Then
        '    optPriceStr = "N/A"
        'Else
        '    optPriceStr = eventArgs.optPrice
        'End If
        'If eventArgs.pvDividend = Double.MaxValue Then
        '    pvDividendStr = "N/A"
        'Else
        '    pvDividendStr = eventArgs.pvDividend
        'End If
        'If eventArgs.undPrice = Double.MaxValue Then
        '    undPriceStr = "N/A"
        'Else
        '    undPriceStr = eventArgs.undPrice
        'End If
        'mktDataStr = "Calculated Option Price for: " & product.ToUpper() & " = " & eventArgs.tickerId & " vol = " & volStr & " delta = " & String.Format("{0:00.00}", deltaStr) &
        ' " gamma = " & gammaStr & " vega = " & vegaStr & " theta = " & thetaStr &
        ' " Price = " & optPriceStr & " D = " & pvDividendStr & " underlying = " & undPriceStr & " " & m_utils.getField(eventArgs.tickType)
        'Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)
    End Sub

    Private Sub Tws1_tickGeneric(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickGenericEvent) Handles Tws1.OnTickGeneric
        Select Case eventArgs.tickType
            Case 23
            Case 24
            Case 31
            Case 46
            Case 49
            Case 54
            Case 55
            Case 56
            Case 58

        End Select
        'Dim mktDataStr As String

        'mktDataStr = "id=" & eventArgs.id & " " & m_utils.getField(eventArgs.tickType) & "=" & eventArgs.value

        '  Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)

    End Sub

    Private Sub Tws1_tickString(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickStringEvent) Handles Tws1.OnTickString

        Select Case eventArgs.tickType
            Case 25
            Case 26
            Case 32
            Case 33
            Case 45
            Case 47
            Case 48
            Case 59
            Case 62
            Case 77
            Case 84
            Case 85
            Case 88
        End Select

        'Dim mktDataStr As String

        'mktDataStr = "id=" & eventArgs.id & " " & m_utils.getField(eventArgs.tickType) & "=" & eventArgs.value

        ' Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)

    End Sub

    Private Sub Tws1_tickEFP(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickEFPEvent) Handles Tws1.OnTickEFP

        Select Case eventArgs.tickerId
            Case 38
            Case 39
            Case 40
            Case 41
            Case 42
            Case 43
            Case 44

        End Select

        'Dim mktDataStr As String
        'mktDataStr = "id=" & eventArgs.tickerId & " " & m_utils.getField(eventArgs.field) & ":" &
        '     eventArgs.basisPoints & " / " & eventArgs.formattedBasisPoints &
        '     " totalDividends=" & eventArgs.totalDividends & " holdDays=" & eventArgs.holdDays &
        '     " futureLastTradeDate=" & eventArgs.futureLastTradeDate & " dividendImpact=" & eventArgs.dividendImpact &
        '     " dividendsToLastTradeDate=" & eventArgs.dividendsToLastTradeDate

        'Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)


    End Sub











    Private Sub btnSendOptionOrder_Click(sender As Object, e As EventArgs) Handles btnSendOptionOrder.Click

        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                       ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                                ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

        contract.Symbol = "VXXB" 'hi.FirstOrDefault().product.ToUpper()                                                                 ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
        contract.SecType = "OPT"        'hi.FirstOrDefault().stocksectype.ToUpper()                                             ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
        contract.Currency = "USD"   'hi.FirstOrDefault().currencytype.ToUpper()                                                          ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
        contract.Exchange = "SMART" 'hi.FirstOrDefault().exchange.ToUpper()                                                              ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

        contract.LastTradeDateOrContractMonth = "20190315"
        contract.Strike = 36
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

        order.OrderType = "MKT"                 ' hi.FirstOrDefault().ordertype.ToUpper()                                   ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
        order.TotalQuantity = 1                 ' hi.FirstOrDefault().shares                                                ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
        order.Tif = "GTC"                       ' hi.FirstOrDefault().inforce.ToUpper()                                     ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)
        order.OrderId = nextValidOrderId                                                                                    ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
        order.Action = "BUY"                    ' txtAction.Text.ToUpper()                                                  ' SET THE ORDER ACTION 
        order.LmtPrice = cprice                                                                                             ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

        Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

    End Sub









    Private Sub Tws1_nextValidId(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_nextValidIdEvent) Handles Tws1.OnNextValidId

        nextValidOrderId = eventArgs.Id                                                                                                 ' ASSIGN THE ORDERID TO THE NEXT VALID ORDER ID VARIABLE USED TO SEND ORDERS TO TWS USING THE API
        'm_dlgOrder.orderId = eventArgs.Id 'Set Order Id Here

    End Sub



End Class