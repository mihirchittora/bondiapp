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
Imports Excel = Microsoft.Office.Interop.Excel

' This area defines any immediate actions to take to improve, bug fix, or enhance the code of the application
' TODO: Organize the code into logical blocks
'        
'       Install connection event.  This will pull orders from TWS based on the user being logged into TWS. 

'       Order reconcilation: Upon connection need to reconcile orders in the DB and orders from TWS by Perm ID. Need to determine how to handle any discrepencies.
'           - An order that has been cancelled in TWS that shows open in the DB
'           - An order that was filled in TWS while Willie was not running that shows open in the DB



Friend Class Main
    Inherits System.Windows.Forms.Form                                                                                                          ' SYSTEM INHERITANCE FOR WINDOWS FORMS

    'Public m_tws As EClient

    Dim codebuild As Date = #11/05/2018#

    Dim indexselected As String = ""                                                                                                            ' INITIALIZE THE INDEXSELECTED AS EMPTY - USED TO GET THE HARVEST INDEX
    Dim tickId As Integer = 0                                                                                                                   ' INITIALIZE THE TICK ID EQUAL TO ZERO - USED IN GATHERING MARKET DATA FOR A PRODUCT

    Private m_utils As New Utils                                                                                                                ' CREATES A NEW INSTANCE OF UTILS TO BE USED IN THIS FORM 
    Private m_dlgConnect As New dlgConnect                                                                                                      ' DEFINE THE CONNECT DIALOG BOX
    Private m_dlgHarvest As New dlgHarvest                                                                                                      ' DEFINE THE HARVEST DIALOG BOX
    'Private m_dlgManual As New dlgManual                                                                                                      ' DEFINE THE HARVEST DIALOG BOX
    Private m_dlgAddRecord As New dlgAddRecord                                                                                                  ' DEFINES THE ADD RECORD DIALOGUE BOX USED TO CONFIRM ADDING A RECORD
    Private m_faAcctsList As String                                                                                                             ' VARIABLE TO HOUSE THE FINANCIAL ADVISOR LIST PARAMETERS
    Private m_faAccount, faError As Boolean                                                                                                     ' VARIABLE TO HOLD FINACIAL ADVISOR STATUS SETTINGS
    Private m_willie As New Willie
    Private m_contractinfo As IBApi.Contract


    ' VARIABLES USED IN THE BACKTEST PROCESSES
    Public backprices As List(Of backPrice)                                                                                                     ' CLASS DEFINITION TO HOUSE BACKPRICES FROM CSV FILES                             
    Public harvestindexes As List(Of HarvestIndex)
    Public ticksymbol As String = ""                                                                                                            ' VARIABLE USED TO HOLD THE TICKSYMBOL WITHIN THE APPLICATION
    Public harvestkey As String = ""                                                                                                            ' USED TO HOLD THE HARVEST INDEX KEY WHEN CALLING FUNCTIONS
    Public tempHarvestKey As String = ""                                                                                                        ' USED TO HOLD HARVEST INDEX KEYS IN SEARCH FUNCTIONS
    Public buytrigger As Decimal = 0                                                                                                            ' USED TO HOLD THE BUYTRIGGER VALUE FROM THE DATABASE FOR A HARVEST INDEX RECORD
    Public selltrigger As Decimal = 0                                                                                                           ' USED TO HOLD THE SELLTRIGGER VALUE FROM THE DATABASE FOR A HARVEST INDEX RECORD
    Public currentCapital As Decimal = 0
    Public rollingcapital As Decimal = 0
    Public hedgecapital As Decimal = 0
    Public maxCapital As Decimal = 0
    Public currcap As Decimal = 0                                                                           ' USED TO HOLD THE WIDTH VALUE FROM THE DATABASE FOR A HARVEST INDEX RECORD EXAMPLE: $1 OR $2 WIDE ON THE HEDGE
    Public lots As Integer = 0                                                                                                                  ' USED TO HOLD THE LOTS VALUE FROM THE DATABASE FOR A HARVEST INDEX RECORD
    Public shares As Integer = 0                                                                                                                ' USED TO HOLD THE SHARES VALUE FROM THE DATABASE FOR A HARVEST INDEX RECORD
    Public hedgewidth As Integer = 0                                                                                                            ' USED TO HOLD THE HEDGEWIDTH VALUE FROM THE DATABASE FOR A HARVEST INDEX RECORD
    Public expdatewidth As Integer = 0                                                                                                          ' USED TO HOLD THE EXPDATEWIDTH VALUE FROM THE DATABASE FOR A HARVEST INDEX RECORD EX: 2 MONTHS OR 3 MONTHS
    Public hedge As Boolean = False                                                                                                             ' USED TO HOLD THE HEDGE VALUE FROM THE DATABASE FOR A HARVEST INDEX RECORD WHETHER WE USE A HEDGE OR NOT ON THIS INDEX
    Public buytarget As Decimal = 0
    Public outputstring As String = ""
    Public putprice As Decimal = 0

    ' Backtesting Stats Variables Here

    Public openedBTO As Integer = 0
    Public closedBTO As Integer = 0
    Public openedSTC As Integer = 0
    Public closedSTC As Integer = 0
    Public trans As Integer = 0
    'Public width As Integer = 0


    ' VARIABLES USED TO HOLD OPTION DATA
    Public product As String = ""                                                                                                               ' VARIABLE TO REPRESENT A PRODUCT USED IN TRADING (STOCK, OPTION, FUTURE) SYMBOL HOUSED HERE
    Public pricetype As Integer = 1                                                                                                             ' VARIABLE USED TO REPRESENT STOCKS (1), OPTIONS (2), OR FUTURES(3)
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


    ' VARIABLES USED IN ROBOT HARVESTING

    Public connectflag As Boolean = True                                                                                                        ' VARIABLE USED TO HOUSE THE FLAG INDICATING THAT THE LOOP THROUGH THE OPENORDEREX AND ORDERSTATUSEX IS THE FIRST CONNECTION
    Public openorderloop As Boolean = True


    Public UpdateBuy As Boolean = False                         ' DO I NEED TO KEEP?
    Public matchid As Integer                                                                                                                   ' VARIABLE USED TO HOUSE THE ID OF THE CORRESPONDING BUY TO OPEN ORDER FOR SELL TO CLOSE ORDERS

    Public ask As Decimal = 0                                                                                                                   ' VARIABLE USED TO HOUSE THE CURRENT ASK PRICE WHEN CONNECTED TO THE TWS API
    Public bid As Decimal = 0                                                                                                                   ' VARIABLE USED TO HOUSE THE CURRENT BID PRICE WHEN CONNECTED TO THE TWS API
    Public last As Decimal = 0                                                                                                                  ' VARIABLE USED TO HOUSE THE CURRENT LAST PRICE WHEN CONNECTED TO THE TWS API
    Public hightoday As Decimal = 0                                                                                                             ' VARIABLE USED TO HOUSE THE CURRENT HIGH PRICE FOR TODAY WHEN CONNECTED TO THE TWS API
    Public lowtoday As Decimal = 0                                                                                                              ' VARIABLE USED TO HOUSE THE CURRENT LOW PRICE FOR TODAY WHEN CONNECTED TO THE TWS API
    Public opentoday As Decimal = 0                                                                                                             ' VARIABLE USED TO HOUSE THE CURRENT OPEN PRICE TODAY WHEN CONNECTED TO THE TWS API
    Public closetoday As Decimal = 0                                                                                                            ' VARIABLE USED TO HOUSE THE CURRENT CLOSE PRICE TODAY WHEN CONNECTED TO THE TWS API
    Public sectype As String = "STK"
    Public prior As Decimal = 0                                                                                                                 ' VARIABLE USED TO HOUSE THE CURRENT PRIOD DAYS CLOSING PRICE WHEN CONNECTED TO THE TWS API
    Public priceint As Double = 0                                                                                                               ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
    Public checksum As Double = 0                                                                                                               ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
    Public cprice As Double = 0                                                                                                                 ' VARIABLE USED TO HOLD THE STARTING OPEN TO BUY PRICE FOR EACH USER & INDEX
    Public trail As Decimal = 0
    Public orderaction As String = ""                                                                                                           ' VARIABLE USED TO HOLD THE ACTION OF BUY OR SELL OF AN ORDER FOR ROBOT PROCESSING
    Public lastoptionprice As Decimal = 0
    Public permid As String = ""                                                                                                                                        ' VARIABLE USED IN CHECKING WHETHER AN ORDER EXISTS - THIS IS THE ONLY REAL UNIQUE ID FOR AN ORDER


    ' OPTION VARIABLES USED IN ROBOT HARVESTING
    Public oAsk As Decimal = 0
    Public oBid As Decimal = 0
    Public oLast As Decimal = 0
    Public oHighToday As Decimal = 0
    Public oLowToday As Decimal = 0
    Public oOpenToday As Decimal = 0
    Public oPrior As Decimal = 0
    Public oClose As Decimal = 0

    ' FLAGS USED IN THE ROBOT PROCESSING
    Public buyorderexists As Boolean = False
    Public sellorderexists As Boolean = False

    Public ManualOrder As Boolean                                                                                                                                       ' VARIABLE USED TO INDICATE THAT THE ORDER SENT IS A MANUAL ORDER ALSO USED TO START WILLIE
    Public SendSingleOrder As Boolean                                                                                                                                   ' PUBLIC VARIABLE INDICAITNG WHETHER THIS IS A SINGLE ORDER OR NOT
    Public RobotOn As Boolean                                                                                                                                           ' INDICATES THAT THE ROBOT IS RUNNING IN THE OPENORDEREX SUB TO ADD ORDERS
    Public connecting As Boolean = True                                                                                                                                 ' VARIABLE INDICATING THE APP IS CONNECTING TO THE TWS PLATFORM VIA THE API
    Public tickCounter As Integer = 0
    Public tickTypeId As Integer = 0
    Public lastprice As Decimal = 0
    Public DPdatetime As DateTime = Now()
    Public snapshot As Boolean = False                                                                                                                                  ' VARIABLE USED TO HOUSE WHETHER THE DATA FROM TWS IS STREAMED OR IS A SNAPSHOT NEEDING TO BE POLLED AGAIN AND AGAIN

    Public WithEvents Tws1 As Tws

    ' THE CODE FOR THE APPLICATION IS SET UP IN LOGICAL BLOCKS WITH 5 LINES SPACED BETWEEN THE BLOCKS.
    ' BLOCK 1: APPLICATION INITIALIZATION CODE (LOAD, INDEXCHANGE, CONNECT, DISCONNECT, CLEAR, CLOSE)

    Public Sub New()
        MyBase.New()                                                                                                                                                    ' SET THE BASE TO A NEW INSTANCE
        Tws1 = New Tws(Me)                                                                                                                                              ' INITIALIZE TWS WITHIN THE APPLICATION TO A NEW INSTANCE
        InitializeComponent()                                                                                                                                           ' INITIALIZE ALL COMPONENTS
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs)

        ' *************************************************
        ' DESCRIPTION: SUB LOADS THE MAIN FORM FOR THE APPLICATION.
        ' METHODS OR PROCESSES: BASED ON THE USER LOGIN THE PROCESS PULLS THE INDEXES FOR THE USER AND LOADS THEM INTO 
        ' A COMBOBOX, ADDS THE SYMBOL OF THE DEFAULT INDEX INTO A TEXTBOX FOR IDENTIFICATION TO THE USER AND LOADS OTHER NECESSART INFO.
        ' *************************************************

        lblBuild.Text = "Build Date: " & String.Format("{0: MM.dd.yy}", codebuild)                                                                                      ' DISPLAY THE LATEST BUILD DATE
        Me.CenterToScreen()                                                                                                                                             ' CENTERS THE FORM ON THE SCREEN
        Call m_utils.init(Me)                                                                                                                                           ' INITIALIZES THE UTILS TO SEND AND READ MESSAGES FROM THE API

        ' Temp set the userid - would normally get pulled from the login screen.
        Utils.username = "boss"                                                                                                                                         ' SETS THE USERID TO MY USERID = THIS WILL BE PASSED FROM THE LOGIN SCREEN

        Try                                                                                                                                                             ' OPEN THE TRY / CATCH PROCESS

            Using db As BondiModel = New BondiModel()                                                                                                                   ' INITIALIZE THE MODEL TO THE DB VARIABLE FOR USE IN GETTING DATA FROM THE DATATABLES

                Dim u = (From q In db.Users Where q.UserName = Utils.username Select q).FirstOrDefault()                                                                ' GET LOGGED IN USERS RECORD FROM THE DATABASE ***** THIS WILL GO AWAY WHEN THE LOGIN FROM IS IN USE
                Utils.userid = u.UserId                                                                                                                                 ' PASSES THE USERID TO THE VARIABLE TO INDICATE WHO IS LOGGED INTO THIS INSTANCE

                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                                                           ' ESTABLISH THE LIST TO HOUSE THE HARVEST INDEX RECORDS
                hi = db.HarvestIndexes.Where(Function(s) s.active = True And s.userID = Utils.userid).AsEnumerable.[Select] _
                        (Function(x) New HarvestIndex With {.harvestKey = x.harvestKey, .name = x.name}).ToList()                                                       ' PULL THE ACTIVE HARVEST INDEX RECORDS AND ADD THEM TO THE LIST 

                cmbHarvestIndex.DataSource = hi                                                                                                                         ' SET THE DROPDOWN DATASOURCE EQUAL TO THE INDEX LIST
                cmbHarvestIndex.DisplayMember = "name"                                                                                                                  ' DROPDOWN DISPLAYS THE NAME FIELD OF THE LIST
                cmbHarvestIndex.ValueMember = "harvestkey"                                                                                                              ' DROPDOWN VALUE TIED TO NAME IS THE HARVESTKEY FIELD

                cmbHarvestIndex.SelectedIndex = 0                                                                                                                       ' SET THE INDEX DISPLAYED AS THE FIRST ONE

                harvestkey = cmbHarvestIndex.SelectedValue

                hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbHarvestIndex.SelectedValue).ToList()                                            ' INITIALIZE THE HARVEST INDEX DATABASE RECORDS TO A LIST
                ticksymbol = hi.FirstOrDefault().product                                                                                                                ' ASSIGN THE FIRST HARVEST INDEX PRODUCT SYMBOL TO TICKSYMBOL WITH THE FORM LOAD
                txtPriceSymbol.Text = ticksymbol                                                                                                                        ' PLACE THE TICKSYMBOL INTO THE VIEW SO THE USER KNOWS WHAT SYMBOL IS ACTIVE
                buytrigger = hi.FirstOrDefault().opentrigger                                                                                                            ' LOAD THE BUYTRIGGER VALUE INTO THE VARIABLE TO CALCULATE THE BUY TARGETS
                selltrigger = hi.FirstOrDefault().width                                                                                                                 ' LOAD THE WIDTH OF THE SELL TRIGGER FROM THE DATABASE
            End Using                                                                                                                                                   ' END USING DB AS THE DATABSE MODEL

        Catch ex As Exception                                                                                                                                           ' ANY ERROR CAUGHT HERE AND DISPLAYED TO THE USER
            ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.
            Call m_utils.addListItem(Utils.List_Types.ERRORS, "Form Load Error: " & ex.ToString())                                                                      ' ADD DESCRIPTION TO THE LIST BOX TO INDICATE ERROR STATUS

        End Try                                                                                                                                                         ' CLOSE THE TRY / CATCH PROCESS 

    End Sub

    Private Sub Main_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

        ' *************************************************
        ' DESCRIPTION: SUB LOADS THE MAIN FORM FOR THE APPLICATION.
        ' METHODS OR PROCESSES: BASED ON THE USER LOGIN THE PROCESS PULLS THE INDEXES FOR THE USER AND LOADS THEM INTO 
        ' A COMBOBOX, ADDS THE SYMBOL OF THE DEFAULT INDEX INTO A TEXTBOX FOR IDENTIFICATION TO THE USER AND LOADS OTHER NECESSART INFO.
        ' *************************************************

        lblBuild.Text = "Build Date: " & String.Format("{0: MM.dd.yy}", codebuild)                                                                                      ' DISPLAY THE LATEST BUILD DATE
        Me.CenterToScreen()                                                                                                                                             ' CENTERS THE FORM ON THE SCREEN
        Call m_utils.init(Me)                                                                                                                                           ' INITIALIZES THE UTILS TO SEND AND READ MESSAGES FROM THE API

        ' Temp set the userid - would normally get pulled from the login screen.
        Utils.username = "boss"                                                                                                                                         ' SETS THE USERID TO MY USERID = THIS WILL BE PASSED FROM THE LOGIN SCREEN

        Try                                                                                                                                                             ' OPEN THE TRY / CATCH PROCESS

            Using db As BondiModel = New BondiModel()                                                                                                                   ' INITIALIZE THE MODEL TO THE DB VARIABLE FOR USE IN GETTING DATA FROM THE DATATABLES

                Dim u = (From q In db.Users Where q.UserName = Utils.username Select q).FirstOrDefault()                                                                ' GET LOGGED IN USERS RECORD FROM THE DATABASE ***** THIS WILL GO AWAY WHEN THE LOGIN FROM IS IN USE
                Utils.userid = u.UserId                                                                                                                                 ' PASSES THE USERID TO THE VARIABLE TO INDICATE WHO IS LOGGED INTO THIS INSTANCE

                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                                                           ' ESTABLISH THE LIST TO HOUSE THE HARVEST INDEX RECORDS
                hi = db.HarvestIndexes.Where(Function(s) s.active = True And s.userID = Utils.userid).AsEnumerable.[Select] _
                        (Function(x) New HarvestIndex With {.harvestKey = x.harvestKey, .name = x.name}).ToList()                                                       ' PULL THE ACTIVE HARVEST INDEX RECORDS AND ADD THEM TO THE LIST 

                cmbHarvestIndex.DataSource = hi                                                                                                                         ' SET THE DROPDOWN DATASOURCE EQUAL TO THE INDEX LIST
                cmbHarvestIndex.DisplayMember = "name"                                                                                                                  ' DROPDOWN DISPLAYS THE NAME FIELD OF THE LIST
                cmbHarvestIndex.ValueMember = "harvestkey"                                                                                                              ' DROPDOWN VALUE TIED TO NAME IS THE HARVESTKEY FIELD

                cmbHarvestIndex.SelectedIndex = 0                                                                                                                       ' SET THE INDEX DISPLAYED AS THE FIRST ONE

                harvestkey = cmbHarvestIndex.SelectedValue

                hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbHarvestIndex.SelectedValue).ToList()                                            ' INITIALIZE THE HARVEST INDEX DATABASE RECORDS TO A LIST
                ticksymbol = hi.FirstOrDefault().product                                                                                                                ' ASSIGN THE FIRST HARVEST INDEX PRODUCT SYMBOL TO TICKSYMBOL WITH THE FORM LOAD
                txtPriceSymbol.Text = ticksymbol                                                                                                                        ' PLACE THE TICKSYMBOL INTO THE VIEW SO THE USER KNOWS WHAT SYMBOL IS ACTIVE
                buytrigger = hi.FirstOrDefault().opentrigger                                                                                                            ' LOAD THE BUYTRIGGER VALUE INTO THE VARIABLE TO CALCULATE THE BUY TARGETS
                selltrigger = hi.FirstOrDefault().width                                                                                                                 ' LOAD THE WIDTH OF THE SELL TRIGGER FROM THE DATABASE
            End Using                                                                                                                                                   ' END USING DB AS THE DATABSE MODEL

        Catch ex As Exception                                                                                                                                           ' ANY ERROR CAUGHT HERE AND DISPLAYED TO THE USER
            ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.
            Call m_utils.addListItem(Utils.List_Types.ERRORS, "Form Load Error: " & ex.ToString())                                                                      ' ADD DESCRIPTION TO THE LIST BOX TO INDICATE ERROR STATUS

        End Try                                                                                                                                                         ' CLOSE THE TRY / CATCH PROCESS 

    End Sub

    Private Sub cmbHarvestIndex_SelectedIndexChanged(sender As Object, e As EventArgs)

        ' *************************************************
        ' DESCRIPTION: DETECTS WHEN THE USER HAS SELECTED A DIFFERENT INDEX.
        ' METHODS OR PROCESSES: RETIREVES INDEX RECORD FROM DATABASE BASED ON THE SELECTED ITEM IN THE COMBOBOX AND UPDATES APP INFO.
        ' *************************************************

        Dim product As String = ""                                                                                                                                  ' VARIABLE USED TO HOUSE THE SYMBOL FOR THE INDEX SELECTED
        indexselected = cmbHarvestIndex.ValueMember.ToString()                                                                                                      ' SETS INDEXSELECTED TO THE CURRENT VALUE IN THE COMBOBOX

        If (Tws1.serverVersion() > 0) Then                                                                                                                          ' CHECK IF TWS IS LOGGED IN AND THE APP IS CONNECTED BY GETTING THE SERVER VERSION

            Using db As BondiModel = New BondiModel()                                                                                                               ' DATABASE MODEL USING ENTITY FRAMEWORK

                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                                                       ' INITIALIZE A LIST OF THE HARVEST INDEXES
                hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbHarvestIndex.SelectedValue.ToString()).ToList()                             ' GET THE SELECTED INDEX FROM THE DATABASE 
                ticksymbol = hi.FirstOrDefault().product                                                                                                            ' SET THE PRODUCT VARIABLE EQUAL TO THE SYMBOL OF THE INDEX SELECTED

                getMarketDataTick(ticksymbol)                                                                                                                       ' GET THE TICK PRICE OF THE CURRENT TICKSYMBOL IN THE SYSTEM
                txtPriceSymbol.Text = ticksymbol.ToUpper()

            End Using                                                                                                                                               ' CLOSE THE ENTITY MODEL FRAMEWORK

        End If                                                                                                                                                      ' CLOSE THE CHECK ON THE TWS SERVER VERSION

    End Sub

    Private Sub btnConnectTWS_Click(sender As Object, e As EventArgs)

        ' *************************************************
        ' DESCRIPTION:          CONNECTS THE APPLICAITON TO THE TRADER WORKSTATION PLATFORM FOR INTERACTIVE BROKERS.
        ' METHODS OR PROCESSES: USING THE CONNECTION PARAMETERS SUPPLIED BY THE USER THE APP CONNECTS TO THE TWS PLATFORM 
        '                       AND PULLS THE INITIAL DATA FOR THE DEFAULT INDEX IN THE COMBOBOX. 
        ' *************************************************

        Try
            'btnConnectTWS1.Enabled = False
            datastring = "Connected to TWS " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                                                        ' VARIABLE USED TO SUPPLY MESSAGES TO THE USER ON PROCESSING AND CYCLETIME  
            m_faAccount = False                                                                                                                                     ' THIS IS NOT A FINANCIAL ADVISORS ACCOUNT SET THE VARIABLE ACCORDINGLY TO INDICATE NOT A FA ACCOUNT
            'lstConnectionResponses.Items.Clear()                                                                                                                   ' CLEAR ANY CONNECTION MESSAGE BEFORE THE NEXT ACTION IS TAKEN

            Dim msg As String = ""                                                                                                                                  ' VARIABLE USED TO SUPPLY DATA TO THE LISTBOX DETERMINE IF I WANT TO KEEP THIS VAR NAME.
            Dim host As String = txtHarvestingIP.Text                                                                                                               ' STORE THE HOST IP INTO THE HOST VARIABLE - NEED TO EITHER PULL THIS FROM THE PROFILE OR ERROR CHECK THE VALUES
            Dim port As String = txtHarvestingPort.Text                                                                                                             ' STORE THE PORT ADDRESS INTO THE PORT VARIABLE - NEED TO EITHER PULL THIS FROM THE PROFILE OR ERROR CHECK THE VALUES
            Dim clientid As String = txtHarvestingClientId.Text                                                                                                     ' STORE THE CLIENT ID INTO THE CLIENT ID VARIABLE - NEED TO EITHER PULL THIS FROM THE PROFILE OR ERROR CHECK THE VALUES

            Tws1.connect(host, port, clientid, False, "")  'pass connection variables

            If Tws1.serverVersion() > 0 Then     ' WORK ON SETTING THIS IN THE CONNECTION tws PASS AND USING A GLOBAL VARIABLE TO MAKE MORE EFFICIENT               ' IF THE RESPONSE BACK IS THE SERVER VERSION THAT IS THE INDICATION THAT THE APP IS CONNECTED TO TWS
                msg = "CONNECTING - ClientID: " & txtHarvestingClientId.Text & " SV: " & Tws1.serverVersion() & " at " & Tws1.TwsConnectionTime()                   ' SET THE MSG TO THE CONNECTION STRING AND TIME OF CONNECTION
                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, msg)                                                                                    ' CALL THE ADD LIST ITEM FUNCTION TO ADD THE MESSAGE TO THE LISTBOX                 
            End If

            'buyorderexists = False                                                                                                                                 ' SET THE VARIABLE INDICATING WHETHER A BUY ORDER EXISTS TO FALSE
            lblBuyOrderExists.Text = buyorderexists                                                                                                                 ' SET THE LABEL ON THE FORM TO THE VARIABLE ----> REMOVE THIS IN PRODUCTION
            lblSellOrderExists.Text = sellorderexists

            getMarketDataTick(ticksymbol)                                                                                                                           ' GET THE TICK PRICE OF THE CURRENT TICKSYMBOL IN THE SYSTE
            Tws1.reqAllOpenOrders()                                                                                                                                 ' GET ALL OPEN ORDERS FROM TWS

            datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                                                         ' SET THE DATASTRING TO THE EXIT TIME OF THE SUB TO DISPLAY FULL CYCLE TIME OF THE CONNECTION
            lblStatus.Text = datastring                                                                                                                             ' SEND THE DATASTRING TO THE FORM VIEW 
            btnConnectTWS.Enabled = False                                                                                                                           ' SET THE CONNECT BUTTON ENABLED TO FALSE TO REDUCE THE ERROR OF DOUBLE CLICKING AND CAUSING AN ERROR

        Catch ex As Exception
            ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.            
            MsgBox("Connection Error: " & ex.ToString())                                                                                                            ' MESSAGE WHERE THE ERROR OCCURRED - IN WHICH SUB - THIS CODE MAY BE COMMENTED OUT LATER            

        End Try
        'Stop
    End Sub

    Private Sub btnDisconnectTWS_Click(sender As Object, e As EventArgs)

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

            btnConnectTWS.Enabled = True                                                                                                                            ' RE-ENABLE THE CONNECT BUTTON BECAUSE THE DISCONNECT HAS OCCURRED

            lblStatus.Text = datastring                                                                                                                             ' PROVIDE THE USER WITH THE STATUS MESSAGE OF THIS SUBROUTINE
        Catch ex As Exception
            MsgBox("Disconnection Error " & ex.ToString())                                                                                                          ' MESSAGE WHERE THE ERROR OCCURRED - IN WHICH SUB - THIS CODE MAY BE COMMENTED OUT LATER  
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)

        ' *************************************************
        ' DESCRIPTION:          CLEARS ANY DATAFIELDS POPULATED RUNNING THE STRATEGY
        ' METHODS OR PROCESSES: REMOVES DATA FROM LISTS AND TEXT BOXES ON THE MAIN APPLICATION FORM
        ' *************************************************

        lstServerResponses.Items.Clear()                                                                                                                            ' PROVIDE THE USER WITH THE STATUS MESSAGE OF THIS SUBROUTINE
        lblBuyOrderExists.Text = ""                                                                                                                                 ' PROVIDE THE USER WITH THE STATUS MESSAGE OF THIS SUBROUTINE

    End Sub

    Private Sub btnCloseMe_Click(sender As Object, e As EventArgs) Handles btnCloseMe.Click

        ' *************************************************
        ' DESCRIPTION:          CLOSE APPLICATION
        ' METHODS OR PROCESSES: CLOSES AND EXITS THE APPLICATION 
        ' *************************************************

        Me.Close()                                                                                                                              ' CLOSE THE APPLICATION
    End Sub













































    ' BLOCK 2: CODE INITIATED BY THE VIEW THE INTERACTS WITH TWS VIA THE API CONTROLS AND CODE USED TO CONNECT TO THE TWS API   















    Private Sub btnHarvestingStartWillie_Click(sender As Object, e As EventArgs)

        Dim datastring As String = "Willie Initiated: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                                             ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP
        Dim Symbol As String = ""                                                                                                                                   ' VARIABLE USED TO HOLD THE SYMBOL FOR THE USER & INDEX
        Dim opentrigger As Double = 0                                                                                                                               ' VARIABLE USED TO HOLD THE TRIGGER FOR THE BUY TO OPEN POSITIONS
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                                                       ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                                                                ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

        Try

            Using db As BondiModel = New BondiModel()                                                                                                               ' DATABASE MODEL USED TO CAPTURE THE ROBOTS DATA

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

                currentprice = closetoday
                priceint = Int(currentprice)                                                                                        ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
                checksum = currentprice - priceint                                                                                  ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
                cprice = (Int(checksum / hi.FirstOrDefault.opentrigger) * hi.FirstOrDefault.opentrigger + priceint)                 ' CALCULATE THE STARTING BUY TO OPEN PRICE 

                order.LmtPrice = cprice                                                                                             ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

                Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 



                'If buyorderexists = True Then
                '    '    'Stop
                'Else
                '    ' IF THERE IS NOT A BTO IN TWS IS THERE IN THE DB?
                '    Dim so As List(Of stockorder) = New List(Of stockorder)()                                                                                       ' INITIALIZE THE STOCK ORDER LIST TO BE USED TO GET THE STOCK RECORD     
                '    so = db.stockorders.AsEnumerable.Where(Function(s) s.roboIndex = cmbWillie.SelectedValue).ToList()                                              ' BUILD THE LIST OF STOCKORDERS FOR THIS USER AND THIS INDEX (MAY NOT NEED TO DO THIS AS INDEXES ARE UNIQUE BY USER. - REFACTOR)

                '    If so.Count = 0 Then

                '        Stop

                '    Else

                '        Dim u = (From q In db.harvest Where q.harvestkey = harvestkey And q.btoopen = True Select q).FirstOrDefault()                                   ' GET LOGGED IN USERS RECORD FROM THE DATABASE ***** THIS WILL GO AWAY WHEN THE LOGIN FROM IS IN USE
                '        MsgBox(u.btoprice)                                                                                                                              ' PASSES THE USERID TO THE VARIABLE TO INDICATE WHO IS LOGGED INTO THIS INSTANCE

                '        '    'Stop
                '    End If


                'End If

            End Using

            datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                                                         ' ADD THE CURRENT FINISH TIME TO THE DATASTRING TO GET THE FULL CYCLE TIME
            lblStatus.Text = datastring                                                                                                                             ' DISPLAY THE DATASTRING TO THE USER

        Catch ex As Exception
            Stop
        End Try
    End Sub












    Private Sub btnSendOrder_Click(sender As Object, e As EventArgs)

        Dim datastring As String = "Order Sent: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                   ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP
        'Dim priceint As Double = 0                                                                                                  ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        'Dim checksum As Double = 0                                                                                                  ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        'Dim cprice As Double = 0                                                                                                    ' VARIABLE USED TO HOLD THE STARTING OPEN TO BUY PRICE FOR EACH USER & INDEX
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
                'hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()              ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

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

    Private Sub btnModOrder_Click(sender As Object, e As EventArgs)

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







    Private Sub btnSendOption_Click(sender As Object, e As EventArgs)

        ' TODO: WORK ON GETTING PARAMETERS DYNAMICALLY FROM THE DATABASE OR THE API - EXAMPLE: OPTION PRICE SHOULD BE SUPPLIED BY THE TICK REQUEST TO GET THE CURRENT OPTION PRICE. DISPLAY FOR USER TO DECIDE TO USE OR SET ANOTHER PRICE TO SEND.

        ' SEND HARD CODED OPTION ORDER
        Dim datastring As String = "Option Order Sent: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "            ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP

        'Dim priceint As Double = 0                                                                                                  ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        'Dim checksum As Double = 0                                                                                                  ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        'Dim cprice As Double = 0                                                                                                    ' VARIABLE USED TO HOLD THE STARTING OPEN TO BUY PRICE FOR EACH USER & INDEX
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

            'so = db.stockorders.AsEnumerable.Where(Function(s) s.harvestkey = cmbWillie.SelectedValue).ToList()                      ' BUILD THE LIST OF STOCKORDERS FOR THIS USER AND THIS INDEX (MAY NOT NEED TO DO THIS AS INDEXES ARE UNIQUE BY USER. - REFACTOR)

            ' THE ORDER COUNTER DOES NOT NEED TO BE CHECKED HERE AS AN ORDER IS BEING SENT NO MATTER WHAT
            'If so.Count = 0 Then                                                                                                   ' INDICATES THAT THIS IS THE FIRST ORDER CALC OPEN PRICE AND SEND FIRST BUY TO OPEN ORDER

            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                           ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
            'h            i = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()                  ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

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

    ' TODO: COMMENT THESE CODE BLOCKS AND ADD ERROR HANDLING.
    ' TODO: TEST & VALIDATE THESE CODE BLOCKS - INTEGRATE THEM AS TO HOW I WANT TO USE THEM IN THE ROBOT

    Private Sub btnAddLeg_Click(sender As Object, e As EventArgs)
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

    Private Sub btnSpreadOrder_Click(sender As Object, e As EventArgs)
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

    Private Sub CmbWillie_SelectedIndexChanged(sender As Object, e As EventArgs)


        ' todo: CLEAN UP THE DATA THAT IS SENT TO THE LISTBOX SIZE, EXCHANGES ETC



        ' If connected to TWS get the symbol from the database and get current price.

        Dim product As String = ""                                                                                                          ' VARIABLE USED TO HOUSE THE SYMBOL FOR THE INDEX SELECTED
        ' indexselected = cmbWillie.SelectedValue.ToString()                                                                                  ' SETS INDEXSELECTED TO THE CURRENT VALUE IN THE COMBOBOX

        If (Tws1.serverVersion() > 0) Then                                                                                                  ' CHECK IF TWS IS LOGGED IN AND THE APP IS CONNECTED BY GETTING THE SERVER VERSION

            Dim contract As IBApi.Contract = New IBApi.Contract()                                                                           ' ESTABLISH A NEW CONTRACT CLASS

            Using db As BondiModel = New BondiModel()                                                                                       ' DATABASE MODEL USING ENTITY FRAMEWORK

                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                               ' INITIALIZE A LIST OF THE HARVEST INDEXES
                ' hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()                      ' GET THE SELECTED INDEX FROM THE DATABASE 
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
                Tws1.reqMktDataEx(tickId + 1, contract, "", True, Nothing)                                                                  ' CALL REQUEST MARKET DATA FOR THE INDEX SYMBOL
                Tws1.tickCount = 0                                                                                                          ' INITIALIZE THE TICKCOUNT VARIABLE TO ZERO

            End Using                                                                                                                       ' CLOSE THE ENTITY MODEL FRAMEWORK

        End If                                                                                                                              ' CLOSE THE CHECK ON THE TWS SERVER VERSION

    End Sub





    Private Sub BtnWillie_Click(sender As Object, e As EventArgs)

        ' TODO:  04.10.18 - DOCUMENT CODE AND ADD ERROR HANDLING


        ' Use this code to test the initial sending of an order to fill with the callback steps to set up for Willie

        Dim datastring As String = "Order Sent: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "               ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP
        'Dim priceint As Double = 0                                                                                              ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        'Dim checksum As Double = 0                                                                                              ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        'Dim cprice As Double = 0                                                                                                ' VARIABLE USED TO HOLD THE STARTING OPEN TO BUY PRICE FOR EACH USER & INDEX
        Dim Symbol As String = ""                                                                                               ' VARIABLE USED TO HOLD THE SYMBOL FOR THE USER & INDEX
        Dim opentrigger As Double = 0                                                                                           ' VARIABLE USED TO HOLD THE TRIGGER FOR THE BUY TO OPEN POSITIONS
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                   ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                            ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA


        SendSingleOrder = True

        'Dim userid As Guid                                                                                                      ' VARIABLE USED TO HOLD THE CURRENT USERS USERID (NEED TO DETERMINE IF I NEED TO KEEP THIS OR NOT)
        ManualOrder = True                                                                                                      ' SET FLAG TO TRUE AS ORDER IS MANUAL - THIS WILL ADD THE ORDER DETAILS TO THE STOCKORDER TABLE
        RobotOn = True                                                                                                          ' FLAG USED TO INDICATE THAT THIS CALL IS NOT DUE TO CONNECTING TO TWS
        'cntr = 1                                                                                                               ' COUNTER FLAG USED TO ELIMINATE THE TWO CYCLES THROUGH THE ORDER PROCESSING 

        Using db As BondiModel = New BondiModel()                                                                               ' DATABASE MODEL USED TO CAPTURE THE ROBOTS DATA

            'Dim ul As List(Of User) = New List(Of User)()                                                                       ' GET THE USERID OF THE USER TO CHECK FOR ORDERS FOR THIS ID AS WELL AS THE INDEX
            'ul = db.Users.AsEnumerable.Where(Function(u) u.UserName = "boss").ToList()                                          ' BUILD THE LIST OF USERS BASED ON THIS USERNAME
            'userid = ul.FirstOrDefault().UserId                                                                                 ' SET THE USERID EQUAL TO THE USERS USERID - CONSIDER DOING THIS IN A PUBLIC VAR AT LOGIN

            'Dim so As List(Of stockorder) = New List(Of stockorder)()                                                           ' INITIALIZE THE STOCK ORDER LIST TO BE USED TO GET THE STOCK RECORD     
            'so = db.stockorders.AsEnumerable.Where(Function(s) s.roboIndex = cmbWillie.SelectedValue).ToList()                  ' BUILD THE LIST OF STOCKORDERS FOR THIS USER AND THIS INDEX (MAY NOT NEED TO DO THIS AS INDEXES ARE UNIQUE BY USER. - REFACTOR)

            ' THE ORDER COUNTER DOES NOT NEED TO BE CHECKED HERE AS AN ORDER IS BEING SENT NO MATTER WHAT
            'If so.Count = 0 Then                                                                                               ' INDICATES THAT THIS IS THE FIRST ORDER CALC OPEN PRICE AND SEND FIRST BUY TO OPEN ORDER

            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                       ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
            hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = harvestkey).ToList()                           ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

            contract.Symbol = hi.FirstOrDefault().product.ToUpper()                                                             ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
            contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                                       ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
            contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                                      ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
            contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                                          ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

            ' THE USER CAN CHOOSE TO ENTER A PRICE OR HAVE THE NEAREST PRICE SET BY THE INDEX AND CALCULATIONS.
            'If so.Count > 0 Then
            ' ADD A CHECKBOX ON THE FORM TO INDICATE THAT THIS IS THE PRICE THE USER WANTS TO SUBMIT VERSUS IF A RECORD EXISTS OR NOT SEND ORDER ONLY

            'cprice = txtPrice.Text
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

            order.LmtPrice = cprice               ' SET TO REDUCE THE PRICE BY  $1.00 FOR TESTING REMOVE WHEN DONE.             ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

            Stop

            Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

            'End If







            'cprice = txtPrice.Text


            'order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                                           ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
            'order.TotalQuantity = hi.FirstOrDefault().shares                                                                    ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
            'order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                                                   ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)
            'order.OrderId = nextValidOrderId                                                                                    ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
            'order.Action = txtAction.Text.ToUpper()                                                                             ' SET THE ORDER ACTION 
            'order.LmtPrice = cprice                                                                                             ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

            'Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                              ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

            'End If







        End Using


        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                         ' ADD THE CURRENT FINISH TIME TO THE DATASTRING TO GET THE FULL CYCLE TIME
        lblConStatus.Text = datastring                                                                                          ' DISPLAY THE DATASTRING TO THE USER

    End Sub




    Private Sub btnckprice_Click(sender As Object, e As EventArgs)
        MsgBox(currentprice.ToString())                                                                                         ' DISPLAY THE CURRENT PRICE TO THE USER VIA A MESSAGE BOX
    End Sub



    Private Sub TimerAtTime_Tick(sender As Object, e As EventArgs)

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

    Private Sub ckRobotOn_CheckedChanged(sender As Object, e As EventArgs)

        If ckRobotOn.Checked = True Then
            RobotOn = True                                                                                  ' SET THE FLAG FOR THE ROBOT ON TO TRUE 
        Else
            RobotOn = False                                                                                 ' SET THE FLAG FOR THE ROBOT ON TO FALSE
        End If

    End Sub

    Private Sub getMarketDataTick(ticksymbol As String)

        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                           ' ESTABLISH A NEW CONTRACT CLASS

        If ticksymbol = "" Then                                                                                                         ' CHECK TO SEE IF THE TICKSYMBOL HAS A VALUE
            Exit Sub                                                                                                                    ' IF THERE IS NO VALUE IN TICKSYMBOL THEN EXIT THE SUBROUTINE
        End If                                                                                                                          ' EXIT THE CONDITIONAL CHECK

        contract.Symbol = ticksymbol                                                                                                    ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT

        contract.SecType = "STK"                    ' SET TO STK for STOCK tick price                                                   ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Currency = "USD"                                                                                                       ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Exchange = "SMART"                                                                                                     ' INITIALIZE EXCHANGE USED FOR THE CONTRACT

        'tickId = 0
        tickId += 1                                                                                                                     ' INCREMENT THE TICKID 

        Tws1.reqMarketDataType(1)                                                                                                       ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(tickId, contract, "", snapshot, Nothing)                                                                      ' CALL THE FUNCTION TO GET THE MARKET DATA FROM TWS VIA THE API CALL
        Tws1.tickCount = 0                                                                                                              ' SET THE TICKCOUNT EQUAL TO ZERO (FLAG TO CONTROL LOOPS)

    End Sub

    ' NEED TO VALIDATE THAT THESE STILL WORK AND THAT THEY ARE NEEDED.  btnOpPrice & getOptionPrice
    Private Sub btnOpPrice_Click(sender As Object, e As EventArgs)

        ' THIS BUTTON TESTS CALCUALTING THE PRICE OF AN OPTION FOR A SPECIFIC UNDERLYING STOCK AT A SPECIFIED STRIKE AND iv LEVEL

        ' Assign inputs to variables
        optionsymbol = txtOptionSymbol.Text
        optionexpirationdate = txtOptionExpirationDate.Text
        optionstrike = txtOptionStrike.Text
        optionright = txtOptionRight.Text
        optionmultiplier = "100" 'txtOptionMultiplier.Text
        optionIV = txtOptionIV.Text

        getOptionPrice(optionsymbol)

        Stop

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

    Private Sub Timer60Sec_Tick(sender As Object, e As EventArgs)

        Dim datastring As String = "Order State: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "              ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                   ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                            ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

        Try

            ' getMarketDataTick(ticksymbol)                                                                                   ' CALL GET MARKET DATA FUNCTION TO GET THE CURRENT PRICE OF THIS TICKSYMBOL(S) IN PLAY
            'Tws1.requestOpenOrders()
            ' check to see if the price has moved above an open buy order
            'Using db As BondiModel = New BondiModel()                                                                       ' INITIALIZE CONNECTION TO THE DATABASE USING THE ENTITY FRAMEWORK

            '        Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                               ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
            '        hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()      ' GET THE INDEX DATA FOR THE SELECTED INDEX FROM THE HARVEST INDEX TABLE

            '        tempHarvestKey = hi.FirstOrDefault().harvestKey                                                             ' SET THE TEMP HARVEST KEY TO THE SELECTED INDEX HARVEST KEY

            '        Dim sellOrderExists = (From q In db.stockorders Where q.roboIndex = tempHarvestKey And
            '                                                            q.Action = "SELL" And q.Status = "Open" Select q)       ' DETERMINE IF A SELL TO CLOSE ORDER EXISTS - INDICATES THAT THE TRAILING BUY TO OPEN ORDER IS COVERED WITH A STC ORDER

            '        If sellOrderExists.Count > 0 Then                                                                           ' DOES A STC ORDER EXIST

            '            lbldatastring.Text = ("Sell Order Active")                                                              ' SEND A MESSAGE TO THE USER INDICATING THAT A STC ORDER EXISTS

            '        Else                                                                                                        ' IF A STC ORDER DOES NOT EXIST

            '            lbldatastring.Text = "No Sell Order Active"                                                             ' SEND A MESSAGE TO THE USER INDICATING THAT A STC ORDER DOES NOT EXIST

            '            Dim buyOrderExists = (From q In db.stockorders Where q.roboIndex = tempHarvestKey And
            '                                                               q.Action = "BUY" And q.Status = "Open" Select q)     ' GET THE TRAILING BUY TO OPEN ORDER INFORMATION FROM THE DATABASE
            '        '    'Stop

            '        'If buyOrderExists.Count > 0 Then                                                                        ' IF THE BTO ORDER EXISTS

            '        ' If currentprice - buyOrderExists.FirstOrDefault.LimitPrice >= hi.FirstOrDefault().width * 2 Then    ' DETERMINE IF THE CURRENT TICK PRICE OF THE TICKSYMBOL IS MORE THAN 2 WIDTHS GREATER THAN THE TRAILING BTO ORDER 

            '        contract.Symbol = buyOrderExists.FirstOrDefault().Symbol.ToUpper()                              ' SET THE CONTRACT SYMBOL TO THE STOCK ORDER UPDATED SYMBOL
            '                    contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                   ' SET THE CONTRACT SECURITY TYPE TO THE INDEX STOCK SECURITY TYPE
            '                    contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                  ' SET THE CONTRACT CURRENCY TYPE TO THE INDEX CURRENCY TYPE
            '                    contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                      ' SET THE CONTRACT EXCHANGE TYPE TO THE INDEX EXCHANGE TYPE

            '                    order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                       ' SET THE ORDER ORDER TYPE TO THE INDEX ORDER TYPE (lmt OR mkt)
            '                    order.TotalQuantity = hi.FirstOrDefault().shares                                                ' SET THE ORDER NUMBER OF SHARES TO THE INDEX NUMBER OF SHARES - CONSIDER SETTING TO THE UPDATED ORDER SHARES VALUE
            '                    order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                               ' SET THE ORDER TRADE IN FORCE TO THE INDEX TRADE IN FORCE (day OR gtc)

            '                    order.OrderId = buyOrderExists.FirstOrDefault().OrderId                                         ' SET THE ORDER ORDER ID TO THE UPDATED RECORD ORDER ID
            '                    order.Action = "BUY"                                                                            ' SET THE ORDER ACTION TO BUY
            '                    order.LmtPrice = buyOrderExists.FirstOrDefault().LimitPrice + hi.FirstOrDefault().opentrigger   ' SET THE ORDER LIMIT PRICE TO THE UPDATED RECORD LIMIT PRICE PLUS THE INDEX WIDTH VALUE

            '                    Call Tws1.placeOrderEx(order.OrderId, contract, order)                                          ' CALL THE PLACEORDER FUNCTION TO SEND THE ORDER CREATED TO TWS

            '                    ' UPDATE THE TRAILING BUY ORDER HERE.
            '                    buyOrderExists.FirstOrDefault.Status = "Open"
            '                    buyOrderExists.FirstOrDefault.LimitPrice = order.LmtPrice
            '                    buyOrderExists.FirstOrDefault.timestamp = DateTime.Parse(Now).ToUniversalTime()                 ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

            '                    db.SaveChanges()                                                                                ' SAVE THE CHANGES TO THE DATABASE   

            '                    lbldatastring.Text = "Elevated Stranded Buy Order " &
            '                        String.Format("{0:C}", (currentprice + hi.FirstOrDefault().width).ToString())               ' IF THE BTO IS LESS THAN 2 WIDTHS BELOW CURRENT PRICE SEND A MESSAGE TO THE USER INDICATING THE CONDITION

            '        ' End If

            '        ' End If
            '    End If
            '    End Using



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

    Private Sub btnGetPrice_Click(sender As Object, e As EventArgs)

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
            '_lstHarvestindex = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()
            symbol = _lstHarvestindex.FirstOrDefault().product


            getMarketDataTick(txtGetPriceSymbol.Text)
        End Using



    End Sub

    Private Sub btnReqNextValidId_Click(sender As Object, e As EventArgs)

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
        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, msg)                                                                ' CALL THE MESSAGE UTILITY TO PRESENT THE CONNECTED ACCOUNT INFORMATIOJN TO THE USER

        'm_faAccount = True                                                                                                              ' SET THE FINANCIAL ACCOUNT MANAGER STATUS TO TRUE
        'm_faAcctsList = eventArgs.accountsList                                                                                          ' SET THE ACCOUNTS LIST TO THE CURRENT LIST OF ACCOUNTS FOR THE LOGGED IN USER        

    End Sub

    ' THIS IS WHERE MIHIR ADDED THE COMBO CODE TO ADD THE LEG DATA TO THE GRID
    Private Sub Tws1_contractDetailsEx(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_contractDetailsExEvent) Handles Tws1.OncontractDetailsEx
        Dim contractDetails As IBApi.ContractDetails
        contractDetails = eventArgs.contractDetails

        Dim contract As IBApi.Contract
        contract = contractDetails.Summary
        grdContracts.Rows.Add(New String() {contract.Symbol, contract.LastTradeDateOrContractMonth, contract.Strike, contract.Right, contract.ConId})
        Dim reqId As Long
        reqId = eventArgs.reqId

        'Dim contractDetails As IBApi.ContractDetails
        contractDetails = eventArgs.contractDetails

        'Dim contract As IBApi.Contract
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

        '' move into view
        lstServerResponses.TopIndex = offset                                                                                            ' ADJUST THE SCROLL ON THE LISTBOX SO THAT THE LATEST MESSAGE WILL BE DISPLAYED

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






    ' ORDER STATUS AND OPEN ORDER HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    Private Sub Tws1_openOrderEx(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_openOrderExEvent) Handles Tws1.OnopenOrderEx

        'Stop

        Dim ordermsg As String = ""                                                                                                                 ' INITIALIZE THE ORDER MESSAGE VARIABLE TO HOLD ORDER MESSAGE DETAILS FOR THE USER
        Dim contract As IBApi.Contract                                                                                                              ' INITIALIZE THE CONTRACT CLASS VARIABLE AS AN ibapi CONTRACT
        contract = eventArgs.contract                                                                                                               ' ASSIGN THE VALUES OF THE CURRENT EVENT ARGUMENTS TO THE CONTRACT CLASS VARIABLE

        Dim order As IBApi.Order                                                                                                                    ' INITIALIZE THE ORDER CLASS VARIABLE AS AN ibapi ORDER
        order = eventArgs.order                                                                                                                     ' ASSIGN THE VALUES OF THE CURRENT EVENT ARGUMENTS TO THE ORDER CLASS VARIABLE

        Dim orderState As IBApi.OrderState                                                                                                          ' INITIALIZE THE ORDER STATE CLASS VARIABLE AS AN ibapi ORDER STATE
        orderState = eventArgs.orderState                                                                                                           ' ASSIGN THE CURRENT ORDERSTATE TO THE ORDER STATE VARIABLE

        Using db As BondiModel = New BondiModel()                                                                                                   ' DATABASE MODEL USING ENTITY FRAMEWORK

            If order.Action = "BUY" Then                                                                                                            ' IF THERE IS AN ORDER THAT EXISTS IN TWS AND THE ACTION IS BUY THEN PERFORM THE FOLLOWING
                orderaction = "BUY"
                buyorderexists = True                                                                                                               ' SET THE BUYORDEREXISTS FLAG EQUAL TO TRUE
                lblBuyOrderExists.Text = buyorderexists                                                                                             ' INDICATE THE BUYORDERSTATUS FLAG ON THE MAIN VIEW FOR THE USER
                btnHarvestingStartWillie.Enabled = False
                permid = order.PermId

                If orderState.Status.ToLower() = "presubmitted" Or orderState.Status.ToLower() = "submitted" Then                                   ' IF THE ORDER HAS A STATUS OF PRE-SUBMITTED OR SUBMITTED THEN PERFORM THE FOLLOWING

                    Dim ordersexist = (From q In db.stockorders Where Trim(q.StockOpenPermId) = Trim(order.PermId) Select q)                        ' DETERMINE WHETHER THERE IS A RECORD IN THE DATABASE WITH THE ORDERS PERMID (UNIQUE IDENTIFIER)

                    ' WE ADD A NEW ORDER TO THE DATABASE HERE WHETHER IT IS A BTO OR A STC FOR STOCK OR OPTIONS
                    ' IN ORDERSTATUS WE UPDATE THE RECORDS BASED ON STATUS CHANGES OF (PRESUBMITTED, SUBMITTED, FILLED, OR CANCELLED)

                    If ordersexist.Count = 0 Then

                        Dim newindex As New stockorder With {
                                                            .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                            .harvestkey = harvestkey,
                                                            .symbol = contract.Symbol.ToUpper(),
                                                            .StockOpenOrderId = order.OrderId,
                                                            .StockOpenPermId = order.PermId,
                                                            .shares = order.TotalQuantity,
                                                            .StockOpenLimitPrice = order.LmtPrice,
                                                            .StockOpenFilled = False,
                                                            .StockOpenFillPrice = 0,
                                                            .StockOpenOrderStatus = orderState.Status,
                                                            .HedgePosition = False,
                                                            .StockOpenCapital = order.TotalQuantity * order.LmtPrice
                                                        }                                                                                       ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                        db.stockorders.Add(newindex)                                                                                            ' INSERT THE NEW RECORD TO BE ADDED.
                        db.SaveChanges()                                                                                                        ' SAVE THE RECORD TO THE DATABASE
                    End If


                    ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Perm ID: " &
                           order.PermId & " Order ID: " & order.OrderId & "." & " BUY: " & order.TotalQuantity &
                           " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", order.LmtPrice) & " " & contract.SecType &
                           " - " & orderState.Status.ToUpper()                                                                                  ' SET THE ORDER MESSAGE TO THE ORDER PARAMETERS TO BE DISPLAYED IN THE SERVER LISTBOX
                End If
                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                           ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
            End If










            If order.Action = "SELL" Then
                Stop
                sellorderexists = True
                lblSellOrderExists.Text = sellorderexists
                btnHarvestingStartWillie.Enabled = False


                permid = order.PermId

                If orderState.Status.ToLower() = "presubmitted" Or orderState.Status.ToLower() = "submitted" Then                               ' IF THE ORDER HAS A STATUS OF PRE-SUBMITTED OR SUBMITTED THEN PERFORM THE FOLLOWING

                    Dim ordersexist = (From q In db.stockorders Where Trim(q.StockOpenPermId) = Trim(order.PermId) Select q)                                 ' DETERMINE WHETHER THERE IS A RECORD IN THE DATABASE WITH THE ORDERS PERMID (UNIQUE IDENTIFIER)

                    ' WE ADD A NEW ORDER TO THE DATABASE HERE WHETHER IT IS A BTO OR A STC FOR STOCK OR OPTIONS
                    ' IN ORDERSTATUS WE UPDATE THE RECORDS BASED ON STATUS CHANGES OF (PRESUBMITTED, SUBMITTED, FILLED, OR CANCELLED)

                    If ordersexist.Count = 0 Then

                        Dim newindex As New stockorder With {
                                                            .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                            .harvestkey = harvestkey,
                                                            .symbol = contract.Symbol.ToUpper(),
                                                            .StockOpenOrderId = order.OrderId,
                                                            .StockOpenPermId = order.PermId,
                                                            .shares = order.TotalQuantity,
                                                            .StockOpenLimitPrice = order.LmtPrice,
                                                            .StockOpenFilled = False,
                                                            .StockOpenFillPrice = 0,
                                                            .StockOpenOrderStatus = orderState.Status,
                                                            .StockOpenCapital = order.TotalQuantity * order.LmtPrice
                                                        }                                                                                   ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                        db.stockorders.Add(newindex)                                                                                            ' INSERT THE NEW RECORD TO BE ADDED.
                        db.SaveChanges()                                                                                                        ' SAVE THE RECORD TO THE DATABASE
                    End If




                    ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Perm ID: " &
                       order.PermId & " Order ID: " & order.OrderId & "." & " SELL: " & order.TotalQuantity &
                       " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", order.LmtPrice) & " " & contract.SecType &
                       " - " & orderState.Status.ToUpper()                                                                                     ' SET THE ORDER MESSAGE TO THE ORDER PARAMETERS TO BE DISPLAYED IN THE SERVER LISTBOX

                End If
                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg & " - ")                                                       ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX

            End If


        End Using


    End Sub




    Private Sub openorderTEST(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_openOrderExEvent)
        Stop
        ' NOTE:  KEEP ALL THIS CODE AS REFERENCE FOR LISTBOX MESSAGING AND USE THIS TO ASSIGN VALUES TO THE ORDER AND CONTRACT CLASSES.
        ' WILL NEED TO USE SOME OF THESE ADDITIONAL ITEMS AS OPTIONS ARE ADDED ETC.

        ' THIS CODE EXECUTES WHEN AN ORDER IS SENT TO TWS USING THE API.

        'If connectflag = True Then
        '    Stop
        '    Exit Sub
        'End If

        Dim ordermsg As String = ""                                                                                                         ' INITIALIZE THE ORDER MESSAGE VARIABLE TO HOLD ORDER MESSAGE DETAILS FOR THE USER
        Dim contractmsg As String = ""                                                                                                      ' INITIALIZE THE CONTRACT MESSAGE VARIABLE TO HOLD CONTRACT MESSAGE DETAILS FOR THE USER
        Dim orderstatemsg As String = ""                                                                                                    ' INITIALIZE THE ORDER STATE MESSAGE TO HOLD ORDER STATE DETAILS FOR THE USER

        Dim contract As IBApi.Contract                                                                                                      ' INITIALIZE THE CONTRACT CLASS VARIABLE AS AN ibapi CONTRACT
        contract = eventArgs.contract                                                                                                       ' ASSIGN THE VALUES OF THE CURRENT EVENT ARGUMENTS TO THE CONTRACT CLASS VARIABLE

        Dim order As IBApi.Order                                                                                                            ' INITIALIZE THE ORDER CLASS VARIABLE AS AN ibapi ORDER
        order = eventArgs.order                                                                                                             ' ASSIGN THE VALUES OF THE CURRENT EVENT ARGUMENTS TO THE ORDER CLASS VARIABLE

        Dim orderState As IBApi.OrderState                                                                                                  ' INITIALIZE THE ORDER STATE CLASS VARIABLE AS AN ibapi ORDER STATE
        orderState = eventArgs.orderState                                                                                                   ' ASSIGN THE CURRENT ORDERSTATE TO THE ORDER STATE VARIABLE

        Stop

        If order.Action = "BUY" Then                                                                                                        ' IF THERE IS AN ORDER THAT EXISTS IN TWS AND THE ACTION IS BUY THEN PERFORM THE FOLLOWING

            'TODO: WORK THROUGH THE BUY ORDER TRIGGER LOGIC
            orderaction = "BUY"
            buyorderexists = True                                                                                                           ' SET THE BUYORDEREXISTS FLAG EQUAL TO TRUE
            lblBuyOrderExists.Text = buyorderexists                                                                                         ' INDICATE THE BUYORDERSTATUS FLAG ON THE MAIN VIEW FOR THE USER






















            If orderState.Status.ToLower() = "presubmitted" Or orderState.Status.ToLower() = "submitted" Then                               ' IF THE ORDER HAS A STATUS OF PRE-SUBMITTED OR SUBMITTED THEN PERFORM THE FOLLOWING

                ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Perm ID: " &
                    order.PermId & " Order ID: " & order.OrderId & "." & " BUY TO OPEN: " & order.TotalQuantity &
                    " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", order.LmtPrice) & " " & contract.SecType &
                    " - " & orderState.Status.ToUpper()                                                                                     ' SET THE ORDER MESSAGE TO THE ORDER PARAMETERS TO BE DISPLAYED IN THE SERVER LISTBOX

                permid = order.PermId        ' not needed                                                                                   ' SET THE PERMID TO BE USED TO DETERMINE WHETHER THERE IS A MATCHING ORDER IN THE DATABASE FOR THIS OPEN ORDER



                'If contract.Symbol = ticksymbol And order.OrderId = 0 Then                                                                  ' ANY ORDER THAT HAS THE INDEX SYMBOL AND HAS AN ORDERID OF 0 WILL DROP THROUGH THIS PROCESS

                Using db As BondiModel = New BondiModel()                                                                               ' DATABASE MODEL USING ENTITY FRAMEWORK

                    Dim ordersexist = (From q In db.stockorders Where q.StockOpenPermId = order.PermId Select q)                                 ' DETERMINE WHETHER THERE IS A RECORD IN THE DATABASE WITH THE ORDERS PERMID (UNIQUE IDENTIFIER)

                    Stop

                    MsgBox(ordersexist.Count.ToString())

                    If ordersexist.Count > 0 Then
                        Stop
                    Else


                        Dim newindex As New stockorder With {
                                                            .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                            .harvestkey = harvestkey,
                                                            .symbol = contract.Symbol.ToUpper(),
                                                            .StockOpenOrderId = order.OrderId,
                                                            .StockOpenPermId = order.PermId,
                                                            .shares = order.TotalQuantity,
                                                            .StockOpenLimitPrice = order.LmtPrice,
                                                            .StockOpenFilled = False,
                                                            .StockOpenFillPrice = 0,
                                                            .StockOpenOrderStatus = orderState.Status,
                                                            .StockOpenCapital = order.TotalQuantity * order.LmtPrice
                                                        }                                                                                   ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                        db.stockorders.Add(newindex)                                                                                            ' INSERT THE NEW RECORD TO BE ADDED.
                        db.SaveChanges()                                                                                                        ' SAVE THE RECORD TO THE DATABASE


                        Stop



                        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg & " - ")    ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX



                    End If






                    'If ordersexist.Count = 0 Then                                                                                       ' IF THE COUNT EQUALS 0 THEN THERE IS NOT A RECORD THEN DISPLAY THE DIALOGUE TO ADD THE RECORD IF THE USER ACCEPTS

                    '    'firstloop = False                                                                                              ' SET THE FIRSTLOOP FLAG TO FALSE AS THE FIRST PASS THROUGH HAS BEEN COMPLETED (INITIAL CONNECTION IS DONE)
                    '    'Stop

                    '    m_dlgAddRecord.Frame1.Text = "TWS Perm ID: " & order.PermId.ToString()                                          ' SET THE PERMID IN THE FRAME TO THE PERM ID OF THE ORDER
                    '    m_dlgAddRecord.lblSymbol.Text = contract.Symbol.ToUpper()                                                       ' SET THE SYMBOL IN THE FORM TO THE CONTRACT SYMBOL
                    '    m_dlgAddRecord.lblAction.Text = order.Action.ToUpper()                                                          ' SET THE ACTION IN THE FORM TO THE ACTION OF THE ORDER
                    '    m_dlgAddRecord.lblLimitPrice.Text = String.Format("{0:C}", order.LmtPrice)                                      ' SET THE PRICE IN THE FORM TO THE LIMIT PRICE OF THE ORDER
                    '    m_dlgAddRecord.lblQty.Text = String.Format("{0:#,##0}", order.TotalQuantity)                                    ' SET THE QUANTITY IN THE FORM TO THE TOTAL QUANTITY OF THE ORDER
                    '    m_dlgAddRecord.lblStatus.Text = orderState.Status.ToUpper()                                                     ' SET THE ORDER STATE IN THE FROM TO THE ORDER STATE OF THE ORDER
                    '    m_dlgAddRecord.TopMost = True                                                                                   ' MAKE SURE THAT THE FORM IS ON THE TOP OF THE DISPLAY
                    '    m_dlgAddRecord.ShowDialog(m_contractinfo)                                                                       ' SHOW THE ADD RECORD DIALOGUE

                    '    If m_dlgAddRecord.ok Then
                    '        'Record the record to the database
                    '        Dim newStockOrder As New Harvest                                                                             ' OPEN NEW STRUCTURE FOR RECORD IN STOCK PRODUCTION TABLE.                    

                    '        '' TODO:  CHANGE THE MODEL AND CODE BELOW TO SWAP STATUS AND ORDERSTATUS FIELD SIZES 

                    '        matchid = order.OrderId                                                                                     ' SET THE MATCHID EQUAL TO THE ORDERID FOR THE STC ORDER WHEN IT IS SENT AND ADDED TO THE DATABASE

                    '        Dim newindex As New harvestorder With {
                    '                                    .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                    '                                    .harvestkey = harvestkey,
                    '                                    .symbol = contract.Symbol.ToUpper(),
                    '                                    .btoorderid = order.OrderId,
                    '                                    .btopermid = order.PermId,
                    '                                    .btoordertype = order.OrderType,
                    '                                    .btoprice = currentprice,
                    '                                    .btolimitprice = order.LmtPrice,
                    '                                    .btoopen = True,
                    '                                    .Quantity = order.TotalQuantity,
                    '                                    .btoorderstatus = orderState.Status,
                    '                                    .btoorderdate = DateTime.Parse(Now).ToUniversalTime()
                    '                                }                                                                                       ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                    '        db.harvestorders.Add(newindex)                                                                                    ' INSERT THE NEW RECORD TO BE ADDED.
                    '        db.SaveChanges()                                                                                                ' SAVE THE RECORD TO THE DATABASE

                    '        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg & " -  STATUS: Added to the database.")    ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX

                    '    Else

                    '        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg & " -  STATUS: NOT added to the database") ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX

                    '    End If

                    '    Else
                    ' WHAT TO DO IF THE ORDER COUNT IS GREATER THAN 0 AFTER THE TICKSYMBOL AND ORDER ID = 0

                    ' End If

                End Using

                ' Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")                                      ' CALL FUNTION TO ADD THE LAST LINT TO THE LISTBOX
                ' Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ")                                                                    ' CALL FUNTION TO ADD A BLANK LINE TO THE LISTBOX

                'Else
                ' Add CODE TO SEND AN ORDER 
                'End If





            ElseIf orderState.Status.ToLower() = "filled" Then           ' was filled
                Stop
                If loopcounter < 1 Then

                    'Stop
                    orderaction = order.Action                                                                                                      ' SET THE ORDERACTION TO THE CURRENT ORDER ACTION (BUY OR SELL)
                    ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Order: " &
                    order.PermId & "." & order.OrderId & "." & loopcounter & " BUY TO OPEN: " & order.TotalQuantity &
                    " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", order.LmtPrice) & " " & contract.SecType &
                    " - " & orderState.Status.ToUpper()

                    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                           ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
                    ' Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")                                  ' CALL FUNTION TO ADD THE LAST LINT TO THE LISTBOX
                    ' Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ")                                                                ' CALL FUNTION TO ADD A BLANK LINE TO THE LISTBOX
                End If

            End If

        ElseIf order.Action = "SELL" Then

            ' orderExists = True                                                                                                        ' SET THE GLOBAL ORDEREXISTS TO TRUE AS A SELL ORDER EXISTS

            If orderState.Status.ToLower() = "presubmitted" Or orderState.Status.ToLower() = "submitted" Then

                ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Order: " &
                order.PermId & "." & order.OrderId & "." & loopcounter & " SELL TO CLOSE: " & order.TotalQuantity &
                " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", order.LmtPrice) & " " & contract.SecType &
                " -  " & orderState.Status.ToUpper()

                Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                               ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
                ' Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")                                      ' CALL FUNTION TO ADD THE LAST LINT TO THE LISTBOX
                ' Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ")                                                                    ' CALL FUNTION TO ADD A BLANK LINE TO THE LISTBOX

                Utils.openSTCs = +1


            ElseIf orderState.Status.ToLower() = "filled" Then

                If loopcounter < 1 Then
                    ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Order: " &
               order.PermId & "." & order.OrderId & "." & loopcounter & " SELL TO CLOSE: " & order.TotalQuantity &
               " " & contract.Symbol & " " & " @ " & String.Format("{0:C}", order.LmtPrice) & " " & contract.SecType &
               " -  " & orderState.Status.ToUpper()

                    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                                           ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
                    '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")                                  ' CALL FUNTION TO ADD THE LAST LINT TO THE LISTBOX
                    '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ")                                                                ' CALL FUNTION TO ADD A BLANK LINE TO THE LISTBOX
                End If
                loopcounter = 0
            End If



        End If


        Using db As BondiModel = New BondiModel()                                                                                           ' DATABASE MODEL USING ENTITY FRAMEWORK
            ' ADD USERID SEARCH TO THIS AS WELL TO REFINE THE SEARCH. 
            ' CHECK WITH MIHIR ON HOW TO UPDATE THE BONDIMODEL 

            Dim ordersexist = (From q In db.stockorders Where q.StockOpenPermId = order.PermId Select q)

            If ordersexist.Count = 0 Then                                                                                               ' IF THE RECORD DOESNT ALREADY EXIST ADD A NEW RECORD TO THE DATABASE

                Dim newStockOrder As New stockorder                                                                                     ' OPEN NEW STRUCTURE FOR RECORD IN STOCK PRODUCTION TABLE.                    

                '' TODO:  CHANGE THE MODEL AND CODE BELOW TO SWAP STATUS AND ORDERSTATUS FIELD SIZES 

                If order.Action = "BUY" Then
                    matchid = order.OrderId
                End If

                'Dim newindex As New stockorder With {
                '                                        .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                '                                        .OrderId = order.OrderId,
                '                                        .PermID = order.PermId,
                '                                        .Symbol = contract.Symbol.ToUpper(),
                '                                        .Action = order.Action,
                '                                        .ordertype = order.OrderType,
                '                                        .TickPrice = currentprice,
                '                                        .LimitPrice = order.LmtPrice,
                '                                        .Status = "Open",
                '                                        .Quantity = order.TotalQuantity,
                '                                        .OrderStatus = orderState.Status,
                '                                        .roboIndex = harvestkey,
                '                                        .matchID = matchid,
                '                                        .OrderTimestamp = DateTime.Parse(Now).ToUniversalTime()
                '                                    }                                                                                   ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                'db.stockorders.Add(newindex)                                                                                            ' INSERT THE NEW RECORD TO BE ADDED.
                'db.SaveChanges()                                                                                                        ' SAVE THE RECORD TO THE DATABASE

            End If

        End Using


    End Sub

    Private Sub Tws1_orderStatus(ByVal eventSender As System.Object, ByVal eventArgs As _DTwsEvents_orderStatusEvent) Handles Tws1.OnorderStatus
        'Stop
        ' ANY CHANGE IN ORDER STATUS WILL HAPPEN HERE - SAVE THE VARS TO THE CLASS HERE FOR USE BEYOND THIS SUB

        Dim datastring As String = "Order State: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                          ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP

        Select Case eventArgs.status.ToLower()                                                                                              ' DETERMINE HOW TO PROCESS THE ORDER STATE CHANGE

            Case "presubmitted"

                ' WHEN AN ORDER IS PRESUBMITTED TO THE TWS PLATFORM THE FOLLOWING CODE WILL DETERMINE IF THERE IS AN ASSOCIATED ORDER IN THE DATABASE.
                ' IF NOT THE CODE WILL ADD A NEW RECORD FOR THAT ORDERID. IF THE RECORD EXISTS THE CODE WILL UPDATE THE ORDERSTATUS AND TIMESTAMP FOR THE RECORD.
                ' FINALLY, THE CODE WILL DISPLAY THE APPROPRIATE MESSAGE TO THE USER INDICATING WHAT HAPPENED WITH EACH ORDER IN THE LISTBOX OF THE APP.

                Try


                    'CheckOrder(eventArgs.permId)
                    ' MsgBox(orderaction)
                    'Stop

                    Using db As BondiModel = New BondiModel()                                                                               ' DATABASE MODEL USING ENTITY FRAMEWORK

                        ' Dim orderexists = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q)                             ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED

                        'If orderexists.Count > 0 Then                                                                                       ' DETERMINE IF THERE IS A RECORD TO UPDATE THE ORDERSTATUS TO SUBMITTED (NOTE: THIS TYPICALLY WILL HAPPEN BETWEEN PRE-SUBMITTED AND SUBMITTED.)

                        '    'Dim ou = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q).FirstOrDefault()                 ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED                           

                        '    If ou.OrderStatus <> eventArgs.status Then                                                                      ' ONLY UPDATE THE ORDER IF THERE HAS BEEN A CHANGE IN STATUS FROM WHAT WAS RECORDED IN THE RECORD
                        '        ou.OrderStatus = eventArgs.status                                                                           ' SET THE ORDERSTATUS OF THE RECORD TO THE EVENT STATUS RESULT                                                           
                        '        ou.timestamp = DateTime.Parse(Now).ToUniversalTime()                                                        ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                        '        db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            
                        '        datastring = datastring & " Order PreSubmitted "                                                            ' INDICATE TO THE USER WHAT HAPPENED IN THE ORDER STATE CHANGE
                        '    End If

                        'Else

                        '    ' CURRENT CODE ADDS AN ORDER ON OPENORDEREX NEED TO DETERMINE IF I WANT THAT TO OCCUR HERE AND THE OPEN ORDER IS USED ONLY TO SEND ORDERS

                        'End If

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

                    Using db As BondiModel = New BondiModel()                                                                                       ' DATABASE MODEL USING ENTITY FRAMEWORK

                        'Dim orderexists = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q)                                    ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED
                        Dim orderexists = (From q In db.stockorders Where Trim(q.StockOpenPermId) = Trim(permid) Select q)                                ' DETERMINE WHETHER THERE IS A RECORD IN THE DATABASE WITH THE ORDERS PERMID (UNIQUE IDENTIFIER)



                    End Using

                    loopcounter = 0

                Catch ex As Exception
                    ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.
                    MsgBox("Order Submitted Error: " & ex.ToString())                                                                       ' SUPPLY AN ERROR MESSAGE TO BE DEBUGGED OR USED BY THE USER. 
                End Try

            Case "filled"  ' revert back to filled when done testing

                ' WHEN AN ORDER IS FILLED IN THE TWS PLATFORM THE FOLLOWING CODE WILL DETERMINE IF THERE IS AN ASSOCIATED ORDER IN THE DATABASE AND UPDATE THAT RECORD AS FILLED AND CLOSED.
                ' CHECK THE WORKFLOW AFTER THIS HAPPENS TO SEE IF THERE IS A NEED TO ADD CODE HERE TO HANDLE THE SENDING OF THE SUBSEQUENT ORDERS OR NOT.
                ' this status loops twice




                Try

                    'If loopcntr = 0 Then

                    Dim filledaction As String = ""                                                                                             ' INITIALIZE THE FILLED ACTION VARIABLE
                    Dim filledharvestkey As String = ""                                                                                         ' INITIALIZE THE FILLED HARVEST KEY VARIABLE 
                    Dim filledlimitprice As Double = 0                                                                                          ' INITIALIZE THE FILLED LIMIT PRICE VARIABLE
                    Dim filledmatchid As Integer = 0                                                                                            ' INITIALIZE THE FILLED  MATCH ID VARIABLE

                    Dim contract As IBApi.Contract = New IBApi.Contract()                                                                       ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
                    Dim order As IBApi.Order = New IBApi.Order()                                                                                ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

                    ' UPDATE THE ORDER THAT WAS FILLED IN THE DATABASE TABLE HERE

                    Using db As BondiModel = New BondiModel()                                                                                   ' DATABASE MODEL USING ENTITY FRAMEWORK

                        ' does the tws order filled have a match in the database based on permid and filled = false?

                        Dim orderexists = (From q In db.stockorders Where q.StockOpenPermId = eventArgs.permId Select q)                        ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED

                        If orderexists.Count > 0 Then                                                                                           ' DETERMINE IF THERE IS A RECORD TO UPDATE THE ORDERSTATUS TO SUBMITTED (NOTE: THIS TYPICALLY WILL HAPPEN BETWEEN PRE-SUBMITTED AND SUBMITTED.)

                            Dim ou = (From q In db.stockorders Where q.StockOpenPermId = eventArgs.permId Select q).FirstOrDefault()            ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED 

                            '' IF THE ORDER FILLED EXISTS IN THE DATABASE UPDATE THE ORDER TO REFLECT 
                            '' THAT IT WAS FILLED WITH LAST FILL PRICE AND ALL OTHER DETAILS.
                            If ou.StockOpenFilled = False Then                                                                                  ' IF THE ACTION OF THE FILLED ORDER WAS BUY SEND A BUY TO OPEN ORDER 1 WIDTH BELOW AND A SELL TO CLOSE 1 WIDTH ABOVE

                                If ou.StockOpenOrderStatus <> eventArgs.status Then                                                             ' ONLY UPDATE THE ORDER IF THERE HAS BEEN A CHANGE IN STATUS FROM WHAT WAS RECORDED IN THE RECORD
                                    ou.StockOpenOrderStatus = eventArgs.status.ToUpper()                                                        ' SET THE ORDERSTATUS OF THE RECORD TO THE EVENT STATUS RESULT                                                           
                                    ou.StockOpenFillPrice = eventArgs.lastFillPrice                                                             ' SET THE TICKPRICE AT THE LAST FILL PRICE TO CAPTURE ANY OVERAGE IN PRICE
                                    ou.StockOpenFilled = True                                                                                   ' SET THE RECORD STATUS TO CLOSED
                                    ou.StockOpenFillTimeStamp = DateTime.Parse(Now).ToUniversalTime()                                           ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                                    db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            






                                    ' is there a hedge for this stockfillprice already?  If not get hedge parameters from index record. if there is do nothing

                                    Dim hi = (From q In db.HarvestIndexes Where q.harvestKey = harvestkey Select q).FirstOrDefault()            ' GET INDEX RECORD FROM THE DATABASE TO DETERMINE WHETHER WE ARE ADDING A HEDGE 

                                    If hi.hedge = True Then                                                                                     ' IF THE INDEX HAS A HEDGE COMPONENT TO IT THEN CHECK FOR HEDGING ON THIS PRICEPOINT

                                        Dim hedgeexists = (From h In db.stockorders Where
                                                           h.StockOpenFillPrice = ou.StockOpenLimitPrice And h.HedgePosition = True)            ' DETERMINE WHETHER THERE IS AN OPEN HEDGE FOR THIS PRICEPOINT OR NOT

                                        If hedgeexists.Count = 0 Then                                                                           ' IF THE COUNT EQUALS 0 THEN THERE IS NOT A HEDGE AT THIS PRICEPOINT ADD A HEDGE TO THIS RECORD AND SEND TO TWS

                                            getHedgeData(harvestkey)
                                            Dim calcexpdate As Date = String.Format("{0: MM/dd/yy}", calcExpirationDate(harvestkey, Now()))                         ' IF A HEDGE IS NEEDED CALCULATE THE EXPIRATION DATE TARGET TO BE USED IN THE BLACK SCHOLES CALCULATION

                                            getOptionPrice(calcexpdate)


                                            'MsgBox(String.Format("{0: yyyyMMdd}", calcexpdate))
                                            'Stop            ' indicates that there is not a hedge open for this pricepoint

                                            'lstServerResponses.Items.Clear()
                                            'pricetype = 2

                                            '' CONTRACT DATA FOR EITHER STOCK OR OPTION PRICE REQUESTS
                                            'contract.Symbol = "VXX"                                                                                                     ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
                                            'contract.Exchange = "SMART"                                                                                                 ' INITIALIZE THE EXCHANGE FOR THE CONTRACT
                                            'contract.Currency = "USD"                                                                                                   ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT        

                                            '' STOCK CONTRACT DATA FOR REQUEST OF PRICE
                                            ''contract.SecType = "STK"                                                                                                    ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT

                                            '' OPTION CONTRACT DATA FOR PRICE REQUEST
                                            'contract.SecType = "OPT"
                                            'contract.LastTradeDateOrContractMonth = String.Format("{0: yyyyMMdd}", calcexpdate)
                                            'contract.Strike = Int(ou.StockOpenLimitPrice - hi.hedgewidth)
                                            'contract.Right = "P"

                                            'Stop
                                            'Tws1.cancelMktData(1)

                                            'Tws1.reqMarketDataType(1)                                                                                                   ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
                                            'Tws1.reqMktDataEx(1, contract, "", False, Nothing)




                                            ' Since there is not a hedge for this price point get the hedge details for this index if 
                                            'Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                       ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
                                            'hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = harvestkey).FirstOrDefault()                   ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

                                            'Dim hi = (From q In db.HarvestIndexes Where q.harvestKey = harvestkey Select q).FirstOrDefault()                    ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED 










                                        Else
                                            Stop            ' indicates that there is a hedge open for this pricepoint



                                            'ha.hedgeopen = True


                                            'db.SaveChanges()
                                            'Stop






                                        End If


                                    End If






                                End If

                            End If
                        ElseIf filledaction.ToUpper() = "SELL" Then                                                                         ' IF THE ACTION OF THE FILLED ORDER WAS SELL CHECK FOR A BUY ORDER BELOW AND MODIFY IT 1 WIDTH UP FROM WHERE IT IS

                            ' add sell detail here

                        End If

                        ' THIS IS WHERE ASSESSEMENT OF THE ORDER FILLED IS MADE AND ADDITIONAL ORDERS ARE SENT TO TWS USING THE API

                        'If filledaction.ToUpper() = "BUY" Then                                                                              ' IF THE ACTION OF THE FILLED ORDER WAS BUY SEND A BUY TO OPEN ORDER 1 WIDTH BELOW AND A SELL TO CLOSE 1 WIDTH ABOVE

                        '' 1. GET THE INDEX VALUES NEEDED TO SEND ADDITIONAL ORDER(S)
                        'Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                   ' GET THE USERID OF THE USER TO CHECK FOR ORDERS FOR THIS ID AS WELL AS THE INDEX
                        'hi = db.HarvestIndexes.AsEnumerable.Where(Function(u) u.harvestKey = filledharvestkey).ToList()                 ' BUILD THE LIST OF USERS BASED ON THIS USERNAME

                        'orderexists = (From q In db.stockorders Where q.PermID = eventArgs.permId Select q)                             ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER FILLED

                        'If orderexists.Count > 0 Then                                                                                   ' DETERMINE IF THERE IS AN ORDER THAT EXISTS TO BASE THE NEXT ORDER SENT OFF OF

                        '    'MsgBox(loopcounter)

                        '    ' this means that the order was sent and added to the db already

                        '    'If loopcounter = 0 Then                                                                                     ' BECAUSE THE eREADER LOOPS TWICE CONTROL THE NUMBER OF ORDERS SENT AND SAVED IN THE DATABASE

                        '    ' SEND A SELL TO CLOSE ORDER 

                        '    contract.Symbol = hi.FirstOrDefault().product.ToUpper()                                                 ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
                        '    contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                           ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
                        '    contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                          ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
                        '    contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                              ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

                        '    order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                               ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
                        '    order.TotalQuantity = hi.FirstOrDefault().shares                                                        ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
                        '    order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                                       ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)

                        '    order.OrderId = nextValidOrderId                                                                        ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
                        '    order.Action = "SELL"                                                                                   ' SET THE ORDER ACTION 
                        '    order.LmtPrice = filledlimitprice + hi.FirstOrDefault().width                                         ' SET TO REDUCE THE PRICE BY  $.50 FOR TESTING REMOVE WHEN DONE                                                    ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE
                        '    matchid = filledmatchid                                                                                 ' SET THE MATCH ID TO THE SAME AS THE FILLED ORDER TO TRACK THE PAIR OF ORDERS

                        '    Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                  ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 


                        '    ' SEND A BUY TO OPEN ORDER

                        '    order.OrderId = nextValidOrderId                                                                        ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
                        '    order.Action = "BUY"                                                                                    ' SET THE ORDER ACTION 
                        '    order.LmtPrice = filledlimitprice - hi.FirstOrDefault().opentrigger                                           ' SET TO REDUCE THE PRICE BY  $.50 FOR TESTING REMOVE WHEN DONE.                                                    ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE
                        '    '                   matchid = nextValidOrderId                                                                              ' SET THE MATCHID FOR THE ADDITIONAL BUY TO OPEN TO THE SAME AS THE ORDERID 

                        '    Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                  ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

                        '    'loopcounter = 0                                                                                       ' INCREMENT THE COUNTER TO PREVENT DUPLICATE ORDERS BEING PLACED AND SAVED
                        '    'Else
                        '    'loopcounter = 0                                                                                         ' RESET THE LOOPCOUNTER SINCE ORDERS HAVE BEEN PROCESSED
                        '    'End If
                        'Else

                        'End If

                        'ElseIf filledaction.ToUpper() = "SELL" Then                                                                         ' IF THE ACTION OF THE FILLED ORDER WAS SELL CHECK FOR A BUY ORDER BELOW AND MODIFY IT 1 WIDTH UP FROM WHERE IT IS

                        '    ' MODIFY THE OPEN BUY TO OPEN ORDER RIDING BELOW THE SELL TO CLOSE ORDER

                        '    Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                   ' GET THE USERID OF THE USER TO CHECK FOR ORDERS FOR THIS ID AS WELL AS THE INDEX
                        '    hi = db.HarvestIndexes.AsEnumerable.Where(Function(u) u.harvestKey = filledharvestkey).ToList()                 ' BUILD THE LIST OF USERS BASED ON THIS USERNAME

                        'Dim sl As List(Of stockorder) = New List(Of stockorder)()                                                       ' INITIALIZE THE STOCKORDER LIST TO BE USED TO GET THE STOCK ORDER RECORD TO UPDATE
                        'sl = db.stockorders.AsEnumerable.Where(Function(s) s.Action = "BUY" And s.Status = "Open").ToList()             ' PULL THE STOCKORDER RECORD STRANDED BUY TO OPEN ORDER BASED ON LIMITPRICE AND OPEN STATUS

                        'sl = db.stockorders.AsEnumerable.Where(Function(s) s.btoLimitPrice =
                        '                    (filledlimitprice - (hi.FirstOrDefault().width * 2)) And s.OrderStatus = "Open").ToList()   ' PULL THE STOCKORDER RECORD STRANDED BUY TO OPEN ORDER BASED ON LIMITPRICE AND OPEN STATUS

                        'If sl.Count > 0 Then

                        '    'Dim findorderid As Integer = sl.FirstOrDefault().OrderId
                        '    'Dim ou = (From q In db.stockorders Where q.OrderId = findorderid Select q).FirstOrDefault()             ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED

                        '    'loopcounter = 0                     ' CHECK TO MAKE SURE THAT THE TRAILING BUY ORDER GETS MOVED

                        '    If loopcounter = 0 Then

                        '        contract.Symbol = sl.FirstOrDefault().Symbol.ToUpper()                                                  ' SET THE CONTRACT SYMBOL TO THE STOCK ORDER UPDATED SYMBOL
                        '        contract.SecType = hi.FirstOrDefault().stocksectype.ToUpper()                                           ' SET THE CONTRACT SECURITY TYPE TO THE INDEX STOCK SECURITY TYPE
                        '        contract.Currency = hi.FirstOrDefault().currencytype.ToUpper()                                          ' SET THE CONTRACT CURRENCY TYPE TO THE INDEX CURRENCY TYPE
                        '        contract.Exchange = hi.FirstOrDefault().exchange.ToUpper()                                              ' SET THE CONTRACT EXCHANGE TYPE TO THE INDEX EXCHANGE TYPE

                        '        order.OrderType = hi.FirstOrDefault().ordertype.ToUpper()                                               ' SET THE ORDER ORDER TYPE TO THE INDEX ORDER TYPE (lmt OR mkt)
                        '        order.TotalQuantity = hi.FirstOrDefault().shares                                                        ' SET THE ORDER NUMBER OF SHARES TO THE INDEX NUMBER OF SHARES - CONSIDER SETTING TO THE UPDATED ORDER SHARES VALUE
                        '        order.Tif = hi.FirstOrDefault().inforce.ToUpper()                                                       ' SET THE ORDER TRADE IN FORCE TO THE INDEX TRADE IN FORCE (day OR gtc)

                        '        'order.OrderId = sl.FirstOrDefault().OrderId                                                             ' SET THE ORDER ORDER ID TO THE UPDATED RECORD ORDER ID
                        '        'order.Action = "BUY"                                                                                    ' SET THE ORDER ACTION TO BUY
                        '        'order.LmtPrice = sl.FirstOrDefault().LimitPrice + hi.FirstOrDefault().opentrigger                             ' SET THE ORDER LIMIT PRICE TO THE UPDATED RECORD LIMIT PRICE PLUS THE INDEX WIDTH VALUE

                        '        Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                  ' CALL THE PLACEORDER FUNCTION TO SEND THE ORDER CREATED TO TWS

                        '        ' UPDATE THE TRAINING BUY ORDER HERE.
                        '        'ou.Status = "Open"
                        '        'ou.LimitPrice = order.LmtPrice
                        '        'ou.timestamp = DateTime.Parse(Now).ToUniversalTime()                                                    ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                        '        db.SaveChanges()                                                                                        ' SAVE THE CHANGES TO THE DATABASE                            
                        '        datastring = datastring & " Order Filled "                                                              ' INDICATE TO THE USER WHAT HAPPENED IN THE ORDER STATE CHANGE

                        '        loopcounter += 1                                                                                        ' INCREMENT THE LOOPCOUNTER TO PREVENT DOUBLE ORDERS 

                        '    Else
                        '        loopcounter = 0                                                                                         ' RESET THE LOOPCOUNTER SINCE ORDERS HAVE BEEN PROCESSED
                        '    End If


                        'End If

                        'End If

                    End Using

                    '    'End If
                Catch ex As Exception
                    ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.
                    MsgBox("Order Submitted Error: " & ex.ToString())                                                                   ' SUPPLY AN ERROR MESSAGE TO BE DEBUGGED OR USED BY THE USER. 
                End Try

                loopcounter += 1

            Case "cancelled"           ' REVERT BACK TO CANCELLED WHEN LIVE

                'Stop
                ' WHEN AN ORDER IS CANCELLED IN THE TWS PLATFORM THE FOLLOWING CODE WILL DETERMINE IF THERE IS AN ASSOCIATED ORDER IN THE DATABASE AND CLOSE AND CANCEL THAT ORDERS RECORD AND ALERT THE USER THROUGH THE DATASTRING.

                Dim ordermsg As String = ""

                Try
                    Using db As BondiModel = New BondiModel()                                                                                       ' DATABASE MODEL USING ENTITY FRAMEWORK

                        Dim orderexists = (From q In db.stockorders Where q.StockOpenPermId = eventArgs.permId Select q)                            ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED

                        If orderexists.Count > 0 Then                                                                                               ' DETERMINE IF THERE IS A RECORD TO UPDATE THAT MATCHES THE PERMID OF CANCELLED ORDER

                            Dim ou = (From q In db.stockorders Where q.StockOpenPermId = eventArgs.permId Select q).FirstOrDefault()                ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED
                            Stop


                            ou.StockOpenOrderStatus = eventArgs.status                                                                           ' SET THE ORDERSTATUS OF THE RECORD TO THE EVENT STATUS RESULT
                            'ou.Status = "Closed"                                                                                        ' SET THE STATUS OF THE RECORD TO CLOSED
                            'ou.TickPrice = currentprice                                                                                 ' SET THE TICK PRICE TO THE PRICE OF THE PRODUCT AT THE TIME THE ORDER WAS CANCELLED
                            'ou.timestamp = DateTime.Parse(Now).ToUniversalTime()                                                        ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                            'db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            
                            'datastring = datastring & " Order Cancelled "                                                               ' INDICATE TO THE USER WHAT HAPPENED IN THE ORDER STATE CHANGE

                            'If ou.Action = "BUY" Then

                            buyorderexists = False                                                                                              ' SET THE BUYORDEREXISTS FLAG EQUAL TO FALSE
                            lblBuyOrderExists.Text = buyorderexists                                                                             ' INDICATE THE BUYORDERSTATUS FLAG ON THE MAIN VIEW FOR THE USER

                            ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Order: " &
                                    eventArgs.permId & "." & eventArgs.orderId & "." & loopcounter & " BUY TO OPEN: " & " - CANCELLED "
                            'ou.Quantity & " " & ou.symbol & " " & " @ " & String.Format("{0:C}", ou.LimitPrice) & " " &


                            Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                           ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
                            '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")                  ' CALL FUNTION TO ADD THE LAST LINT TO THE LISTBOX
                            '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ")                                                ' CALL FUNTION TO ADD A BLANK LINE TO THE LISTBOX
                            'Else

                            '    ordermsg = String.Format("{0:MM/dd/yyyy hh:mm:ss}", Now.ToLocalTime) & " Order: " &
                            '        eventArgs.permId & "." & eventArgs.orderId & "." & loopcounter & " SELL TO CLOSE: " &
                            '        ou.Quantity & " " & ou.Symbol & " " & " @ " & String.Format("{0:C}", ou.LimitPrice) & " " &
                            '        " - CANCELLED "

                            '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, ordermsg)                                           ' CALLED FUNCTION TO ADD THE ORDER MESSAGE TO THE LISTBOX
                            '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "===============================")                  ' CALL FUNTION TO ADD THE LAST LINT TO THE LISTBOX
                            '    Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ")                                                ' CALL FUNTION TO ADD A BLANK LINE TO THE LISTBOX
                            'End If

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




    Private Sub btnGetOptionPrice_Click(sender As Object, e As EventArgs) Handles btnGetOptionPrice.Click

        Using db As BondiModel = New BondiModel()                                                                                   ' DATABASE MODEL USING ENTITY FRAMEWORK

            Dim hi = (From q In db.HarvestIndexes Where q.harvestKey = harvestkey Select q).FirstOrDefault()            ' GET INDEX RECORD FROM THE DATABASE TO DETERMINE WHETHER WE ARE ADDING A HEDGE 

            If hi.hedge = True Then                                                                                     ' IF THE INDEX HAS A HEDGE COMPONENT TO IT THEN CHECK FOR HEDGING ON THIS PRICEPOINT

                Dim hedgeexists = (From h In db.stockorders Where
                                                           h.StockOpenFillPrice = 26.5 And h.HedgePosition = True)            ' DETERMINE WHETHER THERE IS AN OPEN HEDGE FOR THIS PRICEPOINT OR NOT

                If hedgeexists.Count = 0 Then                                                                           ' IF THE COUNT EQUALS 0 THEN THERE IS NOT A HEDGE AT THIS PRICEPOINT ADD A HEDGE TO THIS RECORD AND SEND TO TWS

                    getHedgeData(harvestkey)
                    Dim calcexpdate As Date = String.Format("{0: MM/dd/yy}", calcExpirationDate(harvestkey, Now()))                         ' IF A HEDGE IS NEEDED CALCULATE THE EXPIRATION DATE TARGET TO BE USED IN THE BLACK SCHOLES CALCULATION

                    getOptionPrice(harvestkey, calcexpdate, 26.5)

                    'MsgBox(String.Format("{0:C}", lastoptionprice))

                End If
            End If

        End Using

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

    '--------------------------------------------------------------------------------
    ' An order execution report. This event is triggered by the explicit request for
    ' execution reports reqExecutionDetials(), and also by order state changes method
    '--------------------------------------------------------------------------------
    'Private Sub Tws1_execDetails(sender As Object, ByVal eventArgs As _DTwsEvents_contractDetailsExEvent) Handles Tws1.OnexecDetailsEx
    'Dim offset = lstServerResponses.Items.Count

    'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, "  longName = " & ContractDetails.LongName)

    'Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, " ---- Execution Details begin ----")

    'm_utils.addListItem(Utils.ListType.ServerResponses, "reqId = " & e.reqId)

    'm_utils.addListItem(Utils.ListType.ServerResponses, "Contract:")
    'With e.contract

    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  conId=" & .ConId)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  symbol=" & .Symbol)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  secType=" & .SecType)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  lastTradeDate=" & .LastTradeDateOrContractMonth)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  strike=" & .Strike)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  right=" & .Right)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  multiplier=" & .Multiplier)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  exchange=" & .Exchange)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  primaryExchange=" & .PrimaryExch)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  currency=" & .Currency)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  localSymbol=" & .LocalSymbol)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  tradingClass=" & .TradingClass)

    'End With

    'm_utils.addListItem(Utils.ListType.ServerResponses, "Execution:")
    'With e.execution

    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  execId = " & .ExecId)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  orderId = " & .OrderId)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  clientId = " & .ClientId)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  permId = " & .PermId)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  time = " & .Time)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  acctNumber = " & .AcctNumber)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  modelCode = " & .ModelCode)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  exchange = " & .Exchange)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  side = " & .Side)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  shares = " & .Shares)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  price = " & .Price)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  liquidation = " & .Liquidation)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  cumQty = " & .CumQty)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  avgPrice = " & .AvgPrice)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  orderRef = " & .OrderRef)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  evRule = " & .EvRule)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  evMultiplier = " & .EvMultiplier)
    '    m_utils.addListItem(Utils.ListType.ServerResponses, "  lastLiquidity = " & .LastLiquidity.ToString())

    'End With

    'm_utils.addListItem(Utils.ListType.ServerResponses, " ---- Execution Details End ----")

    ' move into view
    'lstServerResponses.TopIndex = offset
    ' End Sub

    'Private Sub Api_execDetailsEnd(sender As Object, e As ExecDetailsEndEventArgs) Handles m_apiEvents.ExecDetailsEnd
    'm_utils.addListItem(Utils.ListType.ServerResponses, "reqId = " & e.reqId & " =============== end ===============")

    '' move into view
    'lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1
    'End Sub













    '--------------------------------------------------------------------------------
    ' FUNCTIONS USED TO GET TICK DETAIL FROM THE TWS PLATFORM USING THE API (USED IN REQUEST MARKET DATA CALLS)
    '--------------------------------------------------------------------------------



    Private Sub Tws1_tickPrice(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickPriceEvent) Handles Tws1.OnTickPrice

        'MsgBox(sectype)

        Dim datastring As String = ""                                                                                               ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP
        Dim mktDataStr As String = ""

        'Stop
        'If pricetype = 1 Then

        'bid = 0
        'ask = 0
        'last = 0
        'hightoday = 0
        'lowtoday = 0
        'closetoday = 0
        'opentoday = 0

        If sectype = "OPT" Then                                                                                                     ' CAPTURE THE OPTION PRICE DATA

            Select Case eventArgs.tickType
                Case 1
                    oBid = eventArgs.price
                    'MsgBox("Bid: " & String.Format("{0:C}", bid))
                    lbloBidPrice.Text = String.Format("{0:C}", oBid)
                Case 2
                    oAsk = eventArgs.price
                    'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask))
                    lbloAskPrice.Text = String.Format("{0:C}", oAsk)
                Case 4
                    oLast = eventArgs.price
                    'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "last: " & String.Format("{0:C}", last))
                    lbloLast.Text = String.Format("{0:C}", oLast)
                Case 6
                    oHighToday = eventArgs.price
                    'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "Last: " & String.Format("{0:C}", last) & " High: " & String.Format("{0:C}", hightoday))
                    lbloHighToday.Text = String.Format("{0:C}", oHighToday)
                Case 7
                    oLowToday = eventArgs.price
                    'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "Last: " & String.Format("{0:C}", last) & " High: " & String.Format("{0:C}", hightoday) & " low: " & String.Format("{0:C}", lowtoday))
                    lbloLowToday.Text = String.Format("{0:C}", oLowToday)
                Case 9
                    oClose = eventArgs.price
                    'MsgBox("Bid: " & String.Format("{0:C}", bid) &
                    '       " Ask: " & String.Format("{0:C}", ask) &
                    '       " Last: " & String.Format("{0:C}", last) &
                    '       " High: " & String.Format("{0:C}", hightoday) &
                    '       " Low: " & String.Format("{0:C}", lowtoday) &
                    '       " Close: " & String.Format("{0:C}", closetoday))
                    lblOprior.Text = String.Format("{0:C}", oClose)                                                                          ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE PRIOR DAYS CLOSE PRICE
                Case 14
                    oOpenToday = eventArgs.price
                    'MsgBox("Bid: " & String.Format("{0:C}", bid) &
                    '       " Ask: " & String.Format("{0:C}", ask) &
                    '       " Last: " & String.Format("{0:C}", last) &
                    '       " Open: " & String.Format("{0:C}", opentoday) &
                    '       " High: " & String.Format("{0:C}", hightoday) &
                    '       " Low: " & String.Format("{0:C}", lowtoday) &
                    '       " Close: " & String.Format("{0:C}", closetoday))
                    lbloOpenToday.Text = String.Format("{0:C}", oOpenToday)
            End Select










        Else                                                                                                                        ' CAPTURE THE STOCK OR FUTURES DATA
            Select Case eventArgs.tickType
                Case 1
                    bid = eventArgs.price
                    'MsgBox("Bid: " & String.Format("{0:C}", bid))
                    lblBidPrice.Text = String.Format("{0:C}", bid)                                                                              ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE BID PRICE
                Case 2
                    ask = eventArgs.price
                    'MsgBox("Ask: " & String.Format("{0:C}", ask))
                    'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask))
                    lblAskPrice.Text = String.Format("{0:C}", ask)                                                                              ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE ASK PRICE
                Case 4
                    last = eventArgs.price
                    'MsgBox("Last: " & String.Format("{0:C}", last))
                    lblPriorClose.Text = String.Format("{0:C}", prior)                                                                          ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE PRIOR DAYS CLOSE PRICE
                    'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "last: " & String.Format("{0:C}", last))
                Case 6
                    hightoday = eventArgs.price
                    'MsgBox("High: " & String.Format("{0:C}", hightoday))
                    'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "Last: " & String.Format("{0:C}", last) & " High: " & String.Format("{0:C}", hightoday))
                    lblTodaysHigh.Text = String.Format("{0:C}", hightoday)                                                                      ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE TODAYS HIGH PRICE
                Case 7
                    lowtoday = eventArgs.price
                    ' MsgBox(" low: " & String.Format("{0:C}", lowtoday))
                    'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "Last: " & String.Format("{0:C}", last) & " High: " & String.Format("{0:C}", hightoday) & " low: " & String.Format("{0:C}", lowtoday))
                    lblTodaysLow.Text = String.Format("{0:C}", lowtoday)                                                                        ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE TODAYS LOW PRICE
                Case 9
                    closetoday = eventArgs.price
                    'MsgBox(" Close: " & String.Format("{0:C}", closetoday))
                    'MsgBox("Bid: " & String.Format("{0:C}", bid) &
                    '   " Ask: " & String.Format("{0:C}", ask) &
                    '   " Last: " & String.Format("{0:C}", last) &
                    '   " High: " & String.Format("{0:C}", hightoday) &
                    '   " Low: " & String.Format("{0:C}", lowtoday) &
                    '   " Close: " & String.Format("{0:C}", closetoday))
                    lblLastPrice.Text = String.Format("{0:C}", closetoday)                                                                            ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE LAST TRADE PRICE
                Case 14
                    opentoday = eventArgs.price
                    'MsgBox(" Open: " & String.Format("{0:C}", opentoday))
                    'MsgBox("Bid: " & String.Format("{0:C}", bid) &
                    '       " Ask: " & String.Format("{0:C}", ask) &
                    '       " Last: " & String.Format("{0:C}", last) &
                    '       " Open: " & String.Format("{0:C}", opentoday) &
                    '       " High: " & String.Format("{0:C}", hightoday) &
                    '       " Low: " & String.Format("{0:C}", lowtoday) &
                    '       " Close: " & String.Format("{0:C}", closetoday))
                    lblTodaysOpen.Text = String.Format("{0:C}", opentoday)                                                                      ' ASSIGN THE VALUE TO THE LABEL IN THE VIEW FOR THE OPEN TODAY PRICE
            End Select











        End If

        Select Case eventArgs.tickType
            Case 1
                'bid = eventArgs.price
                'MsgBox("Bid: " & String.Format("{0:C}", bid))
            Case 2
                'ask = eventArgs.price
                'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask))
            Case 4
                'last = eventArgs.price
                'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "last: " & String.Format("{0:C}", last))
            Case 6
                'hightoday = eventArgs.price
                'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "Last: " & String.Format("{0:C}", last) & " High: " & String.Format("{0:C}", hightoday))
            Case 7
                'lowtoday = eventArgs.price
               'MsgBox("Bid: " & String.Format("{0:C}", bid) & " Ask: " & String.Format("{0:C}", ask) & "Last: " & String.Format("{0:C}", last) & " High: " & String.Format("{0:C}", hightoday) & " low: " & String.Format("{0:C}", lowtoday))
            Case 9
                'closetoday = eventArgs.price
                'MsgBox("Bid: " & String.Format("{0:C}", bid) &
                '       " Ask: " & String.Format("{0:C}", ask) &
                '       " Last: " & String.Format("{0:C}", last) &
                '       " High: " & String.Format("{0:C}", hightoday) &
                '       " Low: " & String.Format("{0:C}", lowtoday) &
                '       " Close: " & String.Format("{0:C}", closetoday))
            Case 14
                'opentoday = eventArgs.price
                'MsgBox("Bid: " & String.Format("{0:C}", bid) &
                '       " Ask: " & String.Format("{0:C}", ask) &
                '       " Last: " & String.Format("{0:C}", last) &
                '       " Open: " & String.Format("{0:C}", opentoday) &
                '       " High: " & String.Format("{0:C}", hightoday) &
                '       " Low: " & String.Format("{0:C}", lowtoday) &
                '       " Close: " & String.Format("{0:C}", closetoday))
        End Select



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
        '    lbloBidPrice.Text = String.Format("{0:C}", oBid)
        '    lbloAskPrice.Text = String.Format("{0:C}", oAsk)

        ' MsgBox(String.Format("{0:C}", oLast))

        'mktDataStr = "Symbol: " & optionsymbol.ToUpper() & "Exp. Strike " & String.Format("{0:C}", optionstrike) & " " & eventArgs.tickType.ToString() & ": " & String.Format("{0:C}", eventArgs.price, eventArgs.tickCount)



        'Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)                                                             ' WRITES THE CURRENT PRICE TO THE LISTBOX

        ' pricetype = 1

        ' End If






    End Sub




    Private Sub Tws1_tickSize(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickSizeEvent) Handles Tws1.OnTickSize

        Dim mktDataStr As String
        mktDataStr = "id=" & eventArgs.id & " " & m_utils.getField(eventArgs.tickType) & "=" & eventArgs.size

        ' Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)

    End Sub

    Private Sub Tws1_tickGeneric(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickGenericEvent) Handles Tws1.OnTickGeneric

        Dim mktDataStr As String

        mktDataStr = "id=" & eventArgs.id & " " & m_utils.getField(eventArgs.tickType) & "=" & eventArgs.value

        '  Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)

    End Sub

    Private Sub Tws1_tickString(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickStringEvent) Handles Tws1.OnTickString

        Dim mktDataStr As String

        mktDataStr = "id=" & eventArgs.id & " " & m_utils.getField(eventArgs.tickType) & "=" & eventArgs.value

        ' Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)

    End Sub

    Private Sub Tws1_tickEFP(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickEFPEvent) Handles Tws1.OnTickEFP

        Dim mktDataStr As String
        mktDataStr = "id=" & eventArgs.tickerId & " " & m_utils.getField(eventArgs.field) & ":" &
             eventArgs.basisPoints & " / " & eventArgs.formattedBasisPoints &
             " totalDividends=" & eventArgs.totalDividends & " holdDays=" & eventArgs.holdDays &
             " futureLastTradeDate=" & eventArgs.futureLastTradeDate & " dividendImpact=" & eventArgs.dividendImpact &
             " dividendsToLastTradeDate=" & eventArgs.dividendsToLastTradeDate

        Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)


    End Sub

    Private Sub Tws1_tickOptionComputation(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickOptionComputationEvent) Handles Tws1.OnTickOptionComputation
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

    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs)

        Dim csvdata As String = ""                                                                                                                                  ' STRING TO HOLD THE DATA FROM EACH CSV FILE READ INTO MEMORY
        Dim filedate As String = "20160104"                                                                                                                         ' STRING TO HOLD THE FILE DATE FOR THE CSV FILE TO BE READ THIS WILL INCREMENT FROM DB
        Dim symbol As String = "vxx"                                                                                                                                ' STRING TO HOLD THE SYMBOL OF THE PRODUCT BEING TESTED

        Dim path As String = "C:\Users\Troy Belden\Desktop\stockprices\allstocks_"                                                                                  ' GENERIC PATH FOR READING THE CSV FILES - WILL NEED TO SET TO USER INPUT FOR PRODUCTION

        Try
            Using textReader As New System.IO.StreamReader(path & filedate & "\table_" & symbol & ".csv")                                                           ' TEXT READER READS THE CSV FILE INTO MEMORY
                csvdata = textReader.ReadToEnd                                                                                                                      ' LOAD THE ENTIRE FILE INTO THE STRING.
                backprices = ParseBackData(csvdata)                                                                                                                 ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.                        
                lblStatus.Text = lblStatus.Text & " " & backprices.Count                                                                                            ' LABEL INDICATOR SHOWING THAT PROCESSING IS COMPLETE
            End Using
        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)                                                                            ' IF THERE IS AN ERROR READING THE FILE DISPLAY THE ERROR MESSAGE
        Finally

        End Try

    End Sub


    Private Sub cmbIndexes_SelectedIndexChanged(sender As Object, e As EventArgs)

        ' if connected to TWS get the symbol from the database and get current price.
        ' used to establish the first price for the harvest robot
        Dim product As String = ""
        ' indexselected = cmbWillie.SelectedValue.ToString()

        If (Tws1.serverVersion() > 0) Then

            Dim contract As IBApi.Contract = New IBApi.Contract()                                                                           ' ESTABLISH A NEW CONTRACT CLASS

            Using db As BondiModel = New BondiModel()                                                                      ' DATABASE MODEL USING ENTITY FRAMEWORK

                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()
                ' hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()
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







    Private Sub btnTickPrice_Click(sender As Object, e As EventArgs)
        Dim contract As IBApi.Contract = New IBApi.Contract()
        contract.Symbol = "VXX"                                                                                                     ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
        'contract.SecType = "STK"                                                                                                    ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Currency = "USD"                                                                                                   ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Exchange = "SMART"                                                                                                 ' INITIALIZE EXCHANGE USED FOR THE CONTRACT
        contract.SecType = "OPT"
        'contract.Exchange = "SMART"
        'contract.Currency = "USD"
        contract.LastTradeDateOrContractMonth = 20180921
        contract.Strike = 27
        contract.Right = "P"
        tickTypeId = txtTickId.Text
        Tws1.reqMarketDataType(1)                                                                                                   ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(1, contract, "", False, Nothing)

        Stop

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










    ' ***** WORK AREA - THIS AREA HOUSES ALL THE NEW CODE ADDED TO THE SOLUTION TO BE WORKED ON AND TESTED BEFORE ENTERED INTO PRODUCTION *****








    ' CODE TO KEEP TESTING TO GET PRICE - TESTING NEEDED TO SUSPEND THE TICK LEVEL UPDATING - WANT TO MAKE IT A 5 SECOND UPDATE AND NOT EVERY TICK - WIP
    Private Sub btnGetPrice_Click_1(sender As Object, e As EventArgs) Handles btnGetPrice.Click

        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                           ' ESTABLISH A NEW CONTRACT CLASS

        If txtPriceSymbol.Text <> "" Then
            contract.Symbol = txtPriceSymbol.Text                                                                                       ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
        Else
            MsgBox("Please enter a symbol.")
            Exit Sub
        End If

        ' CONTRACT INFORMATION TO GET STOCK PRICE FROM TWS
        contract.SecType = "STK"                                                                                                        ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Currency = "USD"                                                                                                       ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Exchange = "SMART"                                                                                                     ' INITIALIZE EXCHANGE USED FOR THE CONTRACT

        ' CONTRACT INFORMATION TO GET OPTION PRICE FROM TWS
        ' contract.SecType = "OPT"                                                                                                        ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        'contract.Currency = "USD"                                                                                                       ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT


        'contract.Exchange = "SMART"                                                                                                     ' INITIALIZE EXCHANGE USED FOR THE CONTRACT


        pricetype = 1

        Tws1.reqMarketDataType(1)                                                                                                       ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(tickId + 1, contract, "", False, Nothing)                                                                     ' MAKES A MARKET DATA REQUEST FOR THE CONTACT DETAIL SUPPLIED PASSED VARS(ID, CONTRACT INFO., idk, SNAPSHOT, idk)
        'Tws1.cancelMktData(tickId + 1)
        Tws1.tickCount = 0
        'currentprice = Tws1.tickPrice()                                                                                                ' SET CURRENT PRICE TO STOCKTICKPRICE TO BE PASSED TO CALLING FUNCTION

    End Sub








    ' PANEL MANAGEMENT HERE

    Private Sub btnBackTesting_Click(sender As Object, e As EventArgs) Handles btnBackTesting.Click

        Using db As BondiModel = New BondiModel()                                                                                                                                               ' ESTABLISH CONNECTION TO THE DATABASE THROUGH THE BONDIMODEL USING ENTITY FRAMEWORK

            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                                                                                       ' ESTABLISH THE LIST TO HOUSE THE HARVEST INDEX RECORDS
            hi = db.HarvestIndexes.Where(Function(s) s.active = True).AsEnumerable.[Select](Function(x) New HarvestIndex With {.harvestKey = x.harvestKey, .name = x.name}).ToList()            ' PULL THE ACTIVE HARVEST INDEX RECORDS AND ADD THEM TO THE LIST 

            cmbBackTestIndexes.DataSource = hi                                                                                                                                                  ' SET THE DROPDOWN DATASOURCE EQUAL TO THE INDEX LIST
            cmbBackTestIndexes.DisplayMember = "name"                                                                                                                                           ' DROPDOWN DISPLAYS THE NAME FIELD OF THE LIST
            cmbBackTestIndexes.ValueMember = "harvestkey"                                                                                                                                       ' DROPDOWN VALUE TIED TO NAME IS THE HARVESTKEY FIELD
            cmbBackTestIndexes.SelectedIndex = 0                                                                                                                                                ' SET THE INDEX DISPLAYED AS THE FIRST ONE

            'hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()                                                                              ' INITIALIZE THE HARVEST INDEX DATABASE RECORDS TO A LIST
            ticksymbol = hi.FirstOrDefault().product                                                                                                                                            ' ASSIGN THE FIRST HARVEST INDEX PRODUCT SYMBOL TO TICKSYMBOL WITH THE FORM LOAD
            'txtSymbol.Text = ticksymbol
            harvestkey = hi.FirstOrDefault().harvestKey                                                                                                                                         ' CAPTURE THE HARVEST KEY OF THE INDEX TO BE USED TO GET THE INDEX DETAILS
            lblHarvestKey.Text = harvestkey
        End Using

        pnlBacktest.Visible = True                                                                                                                                                              ' MAKE THE BACKTESTING PANEL AND CONTROLS VISIBLE TO THE USER BASED ON THEIR SELECTION
        pnlHarvesting.Visible = False
        pnlMan.Visible = False

        txtLoadSymbol.Select()

    End Sub

    Private Sub btnHideBackTesting_Click(sender As Object, e As EventArgs) Handles btnHideBackTesting.Click
        pnlBacktest.Visible = False                                                                                                     ' HIDE THE BACKTESTING PANEL AND CONTROLS BASED ON THE USER SELECTING TO CLOSE THE PANEL
    End Sub

    Private Sub btnManualOrders_Click(sender As Object, e As EventArgs)
        'dlgManual.Show()
        pnlMan.Visible = True
        pnlBacktest.Visible = False
        pnlHarvesting.Visible = False
    End Sub

    Private Sub btnHideManual_Click(sender As Object, e As EventArgs) Handles btnHideManual.Click

        pnlBacktest.Visible = False
        pnlHarvesting.Visible = False
    End Sub




    ' BUILD THIS OUT TO GET ALL OF THE VBSAMPLE APP BUTTONS WORKING ON THIS PANEL

    Private Sub btnShowManual_Click(sender As Object, e As EventArgs) Handles btnShowManual.Click

        pnlBacktest.Visible = False
        pnlHarvesting.Visible = False
    End Sub


    ' DIALOGUE BOX MANAGEMENT HERE


    Private Sub btnAnalysis_Click(sender As Object, e As EventArgs) Handles btnAnalysis.Click
        dlgAnalysis.Show()
    End Sub







    ' ********************************************************
    ' CODE FOR BACKTESTING HERE
    ' ********************************************************

    Private Sub btnAssembleDataFile_Click(sender As Object, e As EventArgs) Handles btnAssembleDataFile.Click

        ' THIS SUBROUTINE WILL TAKE THE USERS INPUT AND CALL THE ASSEMBLE DATA FILE FUNCTION TO ASSEMBLE THE DATAFILE TO BE READ FOR BACKTESTING. THIS CODE IS FOR THE QUANTQUOTE DATA.

        Dim datastring As String = "Data file assembly QQ: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                                                            ' SET INITIAL DATASTRING TO BACKTEST PROCESS AND DATE / TIME

        Try

            If buildfile.assembledatafile(txtLoadSymbol.Text.ToUpper(), txtStartYear.Text, txtYears.Text, txtMonths.Text, txtDays.Text) = True Then                                         ' CALLS THE ASSEMBLE FUNCTION AND PASSES THE REQUIRED DATA ELEMENTS - IF SUCCESS THEN THE CALL WILL RETURN TRUE
                Cursor = Cursors.Default                                                                                                                                                ' RETURN CURSOR TO DEFAULT STATUS
                btnAssembleDataFile.Enabled = True                                                                                                                                      ' SET THE ASSEMBLE DATA FILE BUTTON ENABLED TO TRUE
                datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                                                                         ' CLOSE THE LOOP ON THE SUBROUTINE CYCLE TIME AND ADD IT TO THE DATASTRING
                lblStatus.Text = "Backtest Records Read: " & String.Format("{0: ##,###,000}", Utils.recordsread) & " " & datastring                                                     ' SEND THE RETURN DATA TO THE VIEW FOR THE USER INDICATING THE STATUS OF RECORDS READ AND CYCLETIME
            Else
                lblStatus.Text = "An Error occurred!" & " " & datastring                                                                                                                ' IF AN ERROR OCCURS NOTIFY THE USER.  **** bUILD OUT BETTER MESSAGING
            End If

        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)                                                                                                ' IF THERE IS AN ERROR READING THE FILE DISPLAY THE ERROR MESSAGE

        End Try

    End Sub








    '***************************




    Private Sub btnAssembleDataFileDIrectPull_Click(sender As Object, e As EventArgs) Handles btnAssembleDataFileDIrectPull.Click
        ' **********
        ' THIS SUB ADDS RECORDS FROM THE DIRECT PULL OF DATA FROM THE MARKET AND ADDS IT TO THE DATAFILE
        ' **********

        Dim datastring As String = "Data File Assembly DP: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                                                            ' SET INITIAL DATASTRING TO BACKTEST PROCESS AND DATE / TIME
        Dim csvdata As String = ""                                                                                                                                                      ' STRING TO HOLD THE DATA FROM EACH CSV FILE READ INTO MEMORY
        Dim recordsread As Integer = 0                                                                                                                                                  ' VARIABLE TO HOUSE THE NUMBER OF RECORDS READ IN THE DATAFILE
        Dim symbol As String = ""                                                                                                                                                       ' STRING TO HOLD THE SYMBOL OF THE PRODUCT BEING TESTED
        Dim filedate As String = String.Format("{0:0#}", Month(DPdatetime)) & "-" & String.Format("{0:0#}", DateAndTime.Day(DPdatetime)) & "-" & Year(DPdatetime) '"06/06/2018"                                                                                                                                                     ' ESTABLISHES THE VARIABLE TO HOLD THE FILE DATE FROM THE DATETIME SELECTOR ON THE FORM

        ' WILL NEED TO HANLDE TWO TYPES OF FILES HERE: 1. QUANTQUOTE FILE FORMAT AND THE DREAMBIG FILE FORMAT PULLED FROM GOOGLE FINANCE.

        symbol = txtLoadSymbol.Text                                     ' ********* Change this to take the symbol from the harvest key?                                                ' GET THE SYMBOL FOR THE FILE FOR ALL THE PRICES TO BE ASSEMBLED INTO THE MAIN FILE.

        Dim path As String = "C:\Users\Troy Belden\Desktop\stocks\" & filedate & "\"                                                                                                    ' GENERIC PATH FOR READING THE DIRECT PULL TXT FILES - WILL NEED TO SET TO USER INPUT FOR PRODUCTION

        Dim strFile As String = "C:\Users\Troy Belden\Desktop\" & symbol.ToUpper() & "_StockData" & ".txt"                                                                              ' PATH FOR THE OUTPUT ASSEMBLED DATA FILE
        Dim sw As StreamWriter                                                                                                                                                          ' DEFINE THE STREAMWRITER FOR FILE ASSEMBLY

        If (Not File.Exists(strFile)) Then                                                                                                                                              ' CHECKS TO SEE IF THE FILE ALREADY EXISTS - IF NOT IT CREATES THE FILE IF IT DOES IT APPENDS TO THE FILE
            sw = File.CreateText(strFile)                                                                                                                                               ' CREATE THE FILE USING THE STREAMWRITER FUNCTIONALITY
        Else
            sw = File.AppendText(strFile)                                                                                                                                               ' APPEND THE DATA RECORDS BEING READ TO THE EXISTING DATA FILE
        End If

        Try

            Cursor = Cursors.WaitCursor                                                                                                                                                 ' SET THE CURSOR TO A BUSY STATE 
            btnAssembleDataFileDIrectPull.Enabled = False                                                                                                                               ' DISABLE THE CREATE DATASET BUTTON UNTIL PROCESS COMPLETED
            lstServerResponses.Items.Clear()                                                                                                                                            ' CLEAR THE LISTBOX TO START A FRESH LISTING

            Using textReader As New System.IO.StreamReader(path & symbol & ".txt")                                                                                                      ' TEXT READER READS THE CSV FILE INTO MEMORY
                csvdata = textReader.ReadToEnd                                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING.
                backprices = ParseBackDataDP(csvdata)                                                                                                                                   ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.                        

                lstServerResponses.Items.Add("Date" & vbTab & vbTab & "Row" & vbTab & "Time" & vbTab & "Open" & vbTab & "High" & vbTab & "Low" & vbTab & "Close")                       ' ADD THE HEADING TO THE LISTBOX FOR THE OUTPUT
                For Each price As BackPrice In backprices                                                                                                                               ' CYCLE THROUGH ALL OF THE INTERVALS IN THE BACKPRICE CLASS

                    ' UNCOMMENT TO ADD DATA TO THE LIST BOX - CHANGE TO WRITE TO THE SERVER RESPONSE LISTBOX.
                    lstServerResponses.Items.Add(Year(price.MarketDate) & String.Format("{0:0#}", Month(price.MarketDate)) & String.Format("{0:0#}", DateAndTime.Day(price.MarketDate)) &
                        vbTab & price.interval & vbTab & String.Format("{0:g}", Hour(price.MarketTime)) & ":" & String.Format("{0:00}", Minute(price.MarketTime)) & vbTab &
                                                 (String.Format("{0:C}", price.OpenPrice)) & vbTab & (String.Format("{0:C}", price.HighPrice)) &
                                                 vbTab & (String.Format("{0:C}", price.LowPrice)) & vbTab & (String.Format("{0:C}", price.ClosePrice)))                                 ' ADD THE OUTPUT OF THE INTERVAL TO THE LISTBOX


                    ' JUST COMMENTED OUT 6/29/18 UNCOMMENT TO WRITE DATA TO DATAFILE
                    sw.WriteLine(Year(price.MarketDate) & String.Format("{0:0#}", Month(price.MarketDate)) & String.Format("{0:0#}", DateAndTime.Day(price.MarketDate)) &
                                "," & String.Format("{0:g}", Hour(price.MarketTime)) & ":" & String.Format("{0:00}", Minute(price.MarketTime)) & "," &
                                price.interval & "," & price.OpenPrice & "," & price.HighPrice & "," & price.LowPrice & "," & price.ClosePrice)                                         ' WRITE THE OUTPUT OF THE INTERVAL TO THE DATAFILE

                    recordsread += 1                                                                                                                                                    ' ADD THE INTERVAL TO ALL INTERVALS PROCESSES (RECORDS READ)

                Next
            End Using

            sw.Close()                                                                                                                                                                  ' CLOSE THE STREAMWRITER

        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)                                                                                                ' IF THERE IS AN ERROR READING THE FILE DISPLAY THE ERROR MESSAGE
        Finally
            Cursor = Cursors.Default                                                                                                                                                    ' RESTORE THE CURSOR TO THE DEFAULT STATE
            btnAssembleDataFileDIrectPull.Enabled = True                                                                                                                                ' SET THE ASSEMBLEDATAFILEDIRECTPULL BUTTON ENABLED EQUAL TO TRUE
            datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                                                                             ' ADD CURRENT TIME TO THE DATASTRING CAPTURING THE FINISHING TIME OF THE PROCESS
            lblStatus.Text = "Backtest Records Read: " & String.Format("{0: ##,###,000}", recordsread) & " " & datastring                                                               ' LABEL INDICATOR SHOWING THAT PROCESSING IS COMPLETE
        End Try

    End Sub

    Private Sub btnBackTest_Click(sender As Object, e As EventArgs) Handles btnBackTest.Click
        dlgHarvestBacktest.ShowDialog()
    End Sub



    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        DPdatetime = (dtpStartDate.Value.ToShortDateString)
    End Sub




    Private Sub btnStartBackTest_Click(sender As Object, e As EventArgs) Handles btnStartBackTest.Click

        ' ******************************************************************************************************************************
        ' CODE WILL READ THE ASSEMBLED DATAFILE AND APPLY THE HARVEST INDEX SETTINGS AS TREATMENT OF THE FILE
        ' BUYING AND SELLING STOCK AND APPLYING THE PUT HEDGES WHERE NEEDED AS DETERMINED BY THE STOCK MOVEMENT AGAINST THE PARAMETER SETTINGS IN THE INDEX
        ' ******************************************************************************************************************************

        Dim datastring As String = "Backtest Cycle Time: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                                                          ' SET INITIAL DATASTRING TO BACKTEST PROCESS AND DATE / TIME
        Dim recordsread As Integer = 0
        Dim csvdata As String = ""                                                                                                                                                  ' STRING TO HOLD THE DATA FROM EACH CSV FILE READ INTO MEMORY
        Dim priceint As Integer = 0
        Dim checksum As Double = 0
        'Dim buytarget As Double = 0
        Dim selltarget As Double = 0
        Dim intervalDirection As String = ""
        Dim levels As Integer = 0
        'Dim buytarget As Double = 0
        'Dim selltarget As Double = 0
        Dim buyprice As Decimal = 0
        Dim sellprice As Decimal = 0
        Dim gap As Double = 0
        Dim trans As Double = 0



        'Dim path As String = "C:\Users\Troy Belden\Desktop\stockprices\allstocks_"                                                                                                      ' GENERIC PATH FOR READING THE CSV FILES - WILL NEED TO SET TO USER INPUT FOR PRODUCTION
        'Dim harvestkey As String = ""
        Dim setHedge As Boolean = False
        Dim lots As Integer = 0
        Dim strike As Double = 0
        Dim type As String = ""
        Dim hedgeexit As Double = 0
        Dim targetprice As Double = 0
        Dim width As Integer = 0


        Dim passedprice As Decimal = 0


        Try
            btnStartBackTest.Enabled = False                                                                                                                                        ' SET THE STARTBACKTEST BUTTON ENABLED TO FALSE TO PREVENT DUPLICATE TESTING / CLICKING
            Cursor = Cursors.WaitCursor                                                                                                                                             ' SET THE CURSOR TO A WAIT CURSOR STATUS WHILE THE PROCESS IS WORKING

            getHedgeData(harvestkey)                                                                                                                                                ' CALLED FUNCTION TO PULL ALL THE RELEVANT HARVEST INDEX DATA AND LOAD IT TO VARIABLES

            Dim readFile As String = "C:\Users\Troy Belden\Desktop\" & ticksymbol & "_StockData.txt"                                                                                ' SETS THE FILE TO BE READ CONTAINING ALL INTERVALS TO BE PROCESSED
            'Dim strFile As String = "C:\Users\Troy Belden\Desktop\" & ticksymbol & "_Output.csv"

            'Dim sw As StreamWriter                                                                                                                                                  ' DEFINES THE STREAM WRITER TO WRITE THE OUTPUT TO A FILE THAT CAN BE COPIED INTO EXCEL 

            'If (Not File.Exists(strFile)) Then
            '    sw = File.CreateText(strFile)
            'Else
            '    sw = File.AppendText(strFile)
            'End If

            If (Not File.Exists(readFile)) Then

                ' WILL WANT TO BUILD ERROR CHECKING IN HERE TO ALERT THE USER IF THERE IS NOT A FILE MATCHING THE SYMBOL SELECTED BY THE INDEX RECORD SELECTED FOR THE BACKTEST

            Else

                Using textReader As New System.IO.StreamReader(readFile)                                                                                                            ' TEXT READER READS THE CSV FILE INTO MEMORY
                    csvdata = textReader.ReadToEnd                                                                                                                                  ' LOAD THE ENTIRE FILE INTO THE STRING.
                    backprices = ParseBackTestData(csvdata)                                                                                                                         ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.                        
                End Using                                                                                                                                                           ' CLOSE THE TEXTREADER STREAMREADER 

            End If

            lstServerResponses.Items.Add("Date" & vbTab & vbTab & "Time" & vbTab & "Price" & vbTab & "Action" & vbTab & "Type" & vbTab & "Strike" & vbTab &
                                         "Exp." & vbTab & vbTab & "Price" & vbTab & "Target")                                                                                          ' ADD THE HEADER TO THE LISTBOX

            For Each price As BackPrice In backprices                                                                                                                               ' PROCESS LOOP FOR EACH INTERVAL IN THE DATAFILE READ INTO MEMORY (BACKPRICE CLASS)

                price.MarketDate = price.MarketDate.Substring(4, 2) & "/" & price.MarketDate.Substring(6, 2) & "/" & price.MarketDate.Substring(0, 4)                               ' FORMAT THE MARKET DATE FOR EACH INTERVAL TO MM/DD/YYYY

                Dim calcexpdate As Date = String.Format("{0: MM/dd/yy}", calcExpirationDate(harvestkey, price.MarketDate))                                                          ' IF A HEDGE IS NEEDED CALCULATE THE EXPIRATION DATE TARGET TO BE USED IN THE BLACK SCHOLES CALCULATION

                'If String.Format("{0: MM/dd/yy}", price.MarketDate) = "1/30/18" Then
                '    Stop
                'End If


                If recordsread = 0 Then                                                                                                                                             ' IF THIS IS THE FIRST INTERVAL READ FOR THIS HARVESTKEY THEN SET THE BUY AND SELL TARGETS BASED ON THE INITIAL OPEN PRICE

                    priceint = Int(price.OpenPrice)                                                                                                                                 ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
                    checksum = price.OpenPrice - priceint                                                                                                                           ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
                    currentprice = (Int(checksum / buytrigger) * buytrigger + priceint)                                                                                             ' CALCULATE THE NEAREST MARK PRICE TO SET THE LIMIT ORDER AGAINST                    
                    buytarget = currentprice                                                                                                                                        ' SET THE BUY TARGET TO THE CURRENT PRICE - NEED TO INVESTIGATE WHY I NEED THE CURRENT PRICE HERE AND NOT JUST SET THE BUYTARGET
                    selltarget = buytarget + selltrigger * 2                                                                                                                        ' SET THE SELL TARGET TO THE BUY TARGET PLUS THE SELLTRIGGER TIMES 2

                End If

                If price.ClosePrice > price.OpenPrice Then                                                                                                                          ' DETERMINE THE DIRECTION OF THE INTERVAL UP = CLOSE HIGHER THAN OPEN | DOWN = CLOSE LOWER THAN OPEN
                    intervalDirection = "U"                                                                                                                                         ' DEFINE AND SET DIRECTION TO UP
                Else
                    intervalDirection = "D"                                                                                                                                         ' DEFINE AND SET DIRECTION TO DOWN
                End If

                If intervalDirection = "U" Then                                                                                                                                     ' THE DIRECTION OF THE INTERVAL DETERMINES THE ORDER OF CHECKING BETWEEN THE HIGH AND LOW PRICES IN THE INTERVAL THIS SEGMENT IS FOR AN UP INTERVAL

                    ' check the open prices for triggers
                    If price.OpenPrice <= buytarget Then                                                                                                                             ' CHECK THE OPEN PRICE OF THIS INTERVAL AGAINST THE BUY TO OPEN TARGET

                        ' Calculate the number of levels (loops) to add BTO positions here called process should only add the record to the database that is the buy 
                        levels = Int((buytarget - price.OpenPrice) / buytrigger)                                                                                                     ' CALCULATION FOR THE NUMBER OF LEVELS BASED ON TRIGGERS, PASSED PRICE AND TARGETS

                        For i = 0 To levels                                                                                                                                         ' INITIATE THE LOOP BASED ON THE NUMBER OF LEVELS FROM THE CALCULATION

                            buyprice = buytarget - (buytrigger * i)                                                                                                                 ' CALCULATE THE PRICE AT WHICH THE POSITION WAS BOUGHT 
                            BuyToOpen(buyprice, "UO", price.MarketDate, price.MarketTime)                                                                                           ' CALLED PROCESS TO CHECK IF THERE IS ALREADY A BUY TO OPEN POSITION FOR THIS PRICE LEVEL: IF NOT ADD IT TO THE DB IF THERE IS RETURN WITH NO ACTION.

                            buytarget = buyprice - (buytrigger * (levels + 1))                                                                                                      ' RE-ESTABLISH THE NEW BUYTARGET TO CHECK ALL FUTURE PRICES AGAINST
                            selltarget = buyprice + (selltrigger)                                                                                                                   ' ESTABLISH THE NEW SELLTARGET TO CHECK ALL FUTURE PRICES AGAINST

                            'For this price determine if a hedge can be added and add it to the position and db
                            ' addHedge(buyprice, calcexpdate)

                            ' Add the short hedge for the hedge added.
                            ' calcexpdate = calcexpdate.AddMonths(6)                                                                                                                  ' TO GET THE EXPIRATION DATE FOR THE SHORT HEDGE (FINANCING FOR HEDGE)
                            'addShortHedge(buyprice, calcexpdate)                                                                                                                    ' FUNCTION TO ADD THE HEDGE TO THE DATABASE TABLES

                            ' For this price determine if any hedge/stock positions can be closed for profit 
                            'closeHedge(buyprice, price.MarketDate, price.MarketTime, "UL")

                            lstServerResponses.Items.Add(outputstring)                                                                                                                      ' TEMP WRITE OUTPUT TO THE LISTBOX

                        Next

                    ElseIf price.OpenPrice >= selltarget Then                                                                                                                        ' CHECK THE OPEN PRICE OF THIS INTERVAL AGAINST THE SELL TO CLOSE TARGET

                        ' Calculate the number of levels (loops) to add BTO positions here called process should only add the record to the database that is the buy 
                        levels = Int((selltarget - price.OpenPrice) * -1 / selltrigger)                                                                                             ' CALCULATION FOR THE NUMBER OF LEVELS BASED ON TRIGGERS, PASSED PRICE AND TARGETS

                        'determine if this is a gap up - two conditions must be met 1. First interval of a new day.  2. level must be greater than 0?

                        'For i = 0 To levels                                                                                                                                         ' LOOP FOR EACH LEVEL BASED ON A GAP UP
                        For i = levels To 0 Step -1

                            'If price.MarketDate = #01/18/2018# Then
                            If price.interval = 0 And levels > 0 Then                                                                                                               ' DETERMINE IF THE OPEN PRICE IS THE FIRST OF THE DAY AND IS A GAP UP

                                sellprice = selltarget + (selltrigger * i)                                                                                                          ' SET THE SELLPRICE TO BE PASSED BASED ON THE SELLTARGET MULTIPLIED BY THE SELLTRIGGER TIMES EACH LEVEL

                                STCGapUp(sellprice, "UO", price.MarketDate, price.MarketTime)                                                                                       ' CALLED GAP UP PROCESS TO HANDLE THE PROCESSING OF THE GAPPED PROCE

                                selltarget = sellprice                                                                                                                              ' SET THE SELL TARGET PRICE BASED ON THE GAP UP
                                buytarget = sellprice - buytrigger                                                                                                                  ' SET THE BUY TARGET BASED ON THE GAP UP

                            Else

                                sellprice = selltarget + (selltrigger * i)                                                                                                          ' SET THE SELLPRICE TO BE PASSED BASED ON THE SELLTARGET MULTIPLIED BY THE SELLTRIGGER TIMES EACH LEVEL

                                SellToClose(sellprice - buytrigger, "UO", price.MarketDate, price.MarketTime)                                                                       ' CALL THE PROCESS TO SELLTOCLOSE THE POSITION

                                selltarget = sellprice + (selltrigger * (levels + 1))                                                                                               ' UPDATE THE SELLTARGET BASED ON THE MOST RECENT POSITION CLOSED
                                buytarget = sellprice - buytrigger                                                                                                                  ' SET THE BUY TARGET BASED ON THE SELL TO CLOSE ACTIVITY

                            End If


                            'sellprice = selltarget + (selltrigger * i)                                                                                                ' SET THE SELLPRICE TO BE PASSED BASED ON THE SELLTARGET MULTIPLIED BY THE SELLTRIGGER TIMES EACH LEVEL

                            'Stop

                            'SellToClose(sellprice - buytrigger, "UO", price.MarketDate, price.MarketTime)                                                                           ' CALL THE PROCESS TO SELLTOCLOSE THE POSITION

                            'selltarget = sellprice + (selltrigger * (levels + 1))                                                                                                   ' UPDATE THE SELLTARGET BASED ON THE MOST RECENT POSITION CLOSED
                            'buytarget = sellprice - buytrigger                                                                                                                      ' UPDATE THE BUYTARGET BASED ON THE MOST RECENT POSITION CLOSED

                            'Stop

                            ' Check whether a financed hedge position can be BoughtToClosed                            
                            'closeShortHedge(sellprice - buytrigger)

                        Next

                        'outputstring = String.Format("{0:MM/dd/yy}", price.MarketDate) & vbTab & String.Format("{0:hh:mm}", price.MarketTime) &
                        '                vbTab & (String.Format("{0:C}", price.HighPrice) & vbTab & "S")

                        lstServerResponses.Items.Add(outputstring)                                                                                                                      ' TEMP WRITE OUTPUT TO THE LISTBOX

                    End If

                    If price.LowPrice <= buytarget Then                                                                                                                              ' CHECK THE LOW PRICE OF THIS INTERVAL AGAINST THE BUY TO OPEN TARGET - ORDER DETERMINED BY INTERVAL DIRECTION

                        ' Calculate the number of levels (loops) to add BTO positions here called process should only add the record to the database that is the buy 
                        levels = Int((buytarget - price.LowPrice) / buytrigger)                                                                                                     ' CALCULATION FOR THE NUMBER OF LEVELS BASED ON TRIGGERS, PASSED PRICE AND TARGETS

                        For i = 0 To levels                                                                                                                                         ' INITIATE THE LOOP BASED ON THE NUMBER OF LEVELS FROM THE CALCULATION

                            buyprice = buytarget - (buytrigger * i)                                                                                                                 ' CALCULATE THE PRICE AT WHICH THE POSITION WAS BOUGHT 
                            BuyToOpen(buyprice, "UL", price.MarketDate, price.MarketTime)                                                                                           ' CALLED PROCESS TO CHECK IF THERE IS ALREADY A BUY TO OPEN POSITION FOR THIS PRICE LEVEL: IF NOT ADD IT TO THE DB IF THERE IS RETURN WITH NO ACTION.

                            buytarget = buyprice - (buytrigger * (levels + 1))                                                                                                      ' RE-ESTABLISH THE NEW BUYTARGET TO CHECK ALL FUTURE PRICES AGAINST
                            selltarget = buyprice + (selltrigger)                                                                                                                   ' ESTABLISH THE NEW SELLTARGET TO CHECK ALL FUTURE PRICES AGAINST

                            'For this price determine if a hedge can be added and add it to the position and db
                            ' addHedge(buyprice, calcexpdate)

                            ' Add the short hedge for the hedge added.
                            'calcexpdate = calcexpdate.AddMonths(6)                                                                                                                  ' TO GET THE EXPIRATION DATE FOR THE SHORT HEDGE (FINANCING FOR HEDGE)
                            'addShortHedge(buyprice, calcexpdate)                                                                                                                    ' FUNCTION TO ADD THE HEDGE TO THE DATABASE TABLES

                            ' For this price determine if any hedge/stock positions can be closed for profit 
                            ' closeHedge(buyprice, price.MarketDate, price.MarketTime, "UL")

                            lstServerResponses.Items.Add(outputstring)                                                                                                                      ' TEMP WRITE OUTPUT TO THE LISTBOX

                        Next

                    End If

                    If price.HighPrice >= selltarget Then

                        ' Calculate the number of levels (loops) to add BTO positions here called process should only add the record to the database that is the buy 
                        levels = Int((selltarget - price.HighPrice) * -1 / selltrigger)                                                                                                     ' CALCULATION FOR THE NUMBER OF LEVELS BASED ON TRIGGERS, PASSED PRICE AND TARGETS

                        For i = 0 To levels                                                                                                                                         ' LOOP FOR EACH LEVEL BASED ON A GAP UP

                            sellprice = selltarget + (selltrigger * i)                                                                                                              ' SET THE SELLPRICE TO BE PASSED BASED ON THE SELLTARGET MULTIPLIED BY THE SELLTRIGGER TIMES EACH LEVEL
                            SellToClose(sellprice - buytrigger, "UH", price.MarketDate, price.MarketTime)                                                                           ' CALL THE PROCESS TO SELLTOCLOSE THE POSITION

                            selltarget = sellprice + (selltrigger * (levels + 1))                                                                                                   ' UPDATE THE SELLTARGET BASED ON THE MOST RECENT POSITION CLOSED
                            buytarget = sellprice - buytrigger                                                                                                                      ' UPDATE THE BUYTARGET BASED ON THE MOST RECENT POSITION CLOSED

                            ' Check whether a financed hedge position can be BoughtToClosed                            
                            'closeShortHedge(sellprice - buytrigger)


                        Next

                        lstServerResponses.Items.Add(outputstring)                                                                                                                      ' TEMP WRITE OUTPUT TO THE LISTBOX

                    End If

                    If price.ClosePrice <= buytarget Then

                        ' Calculate the number of levels (loops) to add BTO positions here called process should only add the record to the database that is the buy 
                        levels = Int((buytarget - price.ClosePrice) / buytrigger)                                                                                                     ' CALCULATION FOR THE NUMBER OF LEVELS BASED ON TRIGGERS, PASSED PRICE AND TARGETS

                        For i = 0 To levels                                                                                                                                         ' INITIATE THE LOOP BASED ON THE NUMBER OF LEVELS FROM THE CALCULATION

                            buyprice = buytarget - (buytrigger * i)                                                                                                                 ' CALCULATE THE PRICE AT WHICH THE POSITION WAS BOUGHT 
                            BuyToOpen(buyprice, "UC", price.MarketDate, price.MarketTime)                                                                                           ' CALLED PROCESS TO CHECK IF THERE IS ALREADY A BUY TO OPEN POSITION FOR THIS PRICE LEVEL: IF NOT ADD IT TO THE DB IF THERE IS RETURN WITH NO ACTION.

                            buytarget = buyprice - (buytrigger * (levels + 1))                                                                                                      ' RE-ESTABLISH THE NEW BUYTARGET TO CHECK ALL FUTURE PRICES AGAINST
                            selltarget = buyprice + (selltrigger)                                                                                                                   ' ESTABLISH THE NEW SELLTARGET TO CHECK ALL FUTURE PRICES AGAINST

                            'For this price determine if a hedge can be added and add it to the position and db
                            ' addHedge(buyprice, calcexpdate)

                            ' Add the short hedge for the hedge added.
                            '   calcexpdate = calcexpdate.AddMonths(6)                                                                                                                  ' TO GET THE EXPIRATION DATE FOR THE SHORT HEDGE (FINANCING FOR HEDGE)
                            'addShortHedge(buyprice, calcexpdate)                                                                                                                    ' FUNCTION TO ADD THE HEDGE TO THE DATABASE TABLES

                            ' For this price determine if any hedge/stock positions can be closed for profit 
                            ' closeHedge(buyprice, price.MarketDate, price.MarketTime, "UL")

                            lstServerResponses.Items.Add(outputstring)                                                                                                                      ' TEMP WRITE OUTPUT TO THE LISTBOX

                        Next

                    End If

                Else

                    If price.OpenPrice <= buytarget Then

                        ' Calculate the number of levels (loops) to add BTO positions here called process should only add the record to the database that is the buy 
                        levels = Int((buytarget - price.ClosePrice) / buytrigger)                                                                                                     ' CALCULATION FOR THE NUMBER OF LEVELS BASED ON TRIGGERS, PASSED PRICE AND TARGETS

                        For i = 0 To levels                                                                                                                                         ' INITIATE THE LOOP BASED ON THE NUMBER OF LEVELS FROM THE CALCULATION

                            buyprice = buytarget - (buytrigger * i)                                                                                                                 ' CALCULATE THE PRICE AT WHICH THE POSITION WAS BOUGHT 
                            BuyToOpen(buyprice, "DO", price.MarketDate, price.MarketTime)                                                                                           ' CALLED PROCESS TO CHECK IF THERE IS ALREADY A BUY TO OPEN POSITION FOR THIS PRICE LEVEL: IF NOT ADD IT TO THE DB IF THERE IS RETURN WITH NO ACTION.

                            buytarget = buyprice - (buytrigger * (levels + 1))                                                                                                      ' RE-ESTABLISH THE NEW BUYTARGET TO CHECK ALL FUTURE PRICES AGAINST
                            selltarget = buyprice + (selltrigger)                                                                                                                   ' ESTABLISH THE NEW SELLTARGET TO CHECK ALL FUTURE PRICES AGAINST

                            'For this price determine if a hedge can be added and add it to the position and db
                            ' addHedge(buyprice, calcexpdate)

                            ' Add the short hedge for the hedge added.
                            '      calcexpdate = calcexpdate.AddMonths(6)                                                                                                                  ' TO GET THE EXPIRATION DATE FOR THE SHORT HEDGE (FINANCING FOR HEDGE)
                            'addShortHedge(buyprice, calcexpdate)                                                                                                                    ' FUNCTION TO ADD THE HEDGE TO THE DATABASE TABLES

                            ' For this price determine if any hedge/stock positions can be closed for profit 
                            ' closeHedge(buyprice, price.MarketDate, price.MarketTime, "UL")

                            lstServerResponses.Items.Add(outputstring)                                                                                                                      ' TEMP WRITE OUTPUT TO THE LISTBOX

                        Next

                    ElseIf price.OpenPrice >= selltarget Then

                        ' Calculate the number of levels (loops) to add BTO positions here called process should only add the record to the database that is the buy 
                        levels = Int((selltarget - price.OpenPrice) * -1 / selltrigger)                                                                                             ' CALCULATION FOR THE NUMBER OF LEVELS BASED ON TRIGGERS, PASSED PRICE AND TARGETS

                        'determine if this is a gap up - two conditions must be met 1. First interval of a new day.  2. level must be greater than 0?

                        'For i = 0 To levels                                                                                                                                         ' LOOP FOR EACH LEVEL BASED ON A GAP UP
                        For i = levels To 0 Step -1

                            'If price.MarketDate = #01/18/2018# Then
                            If price.interval = 0 And levels > 0 Then                                                                                                               ' DETERMINE IF THE OPEN PRICE IS THE FIRST OF THE DAY AND IS A GAP UP

                                sellprice = selltarget + (selltrigger * i)                                                                                                          ' SET THE SELLPRICE TO BE PASSED BASED ON THE SELLTARGET MULTIPLIED BY THE SELLTRIGGER TIMES EACH LEVEL

                                STCGapUp(sellprice, "UO", price.MarketDate, price.MarketTime)                                                                                       ' CALLED GAP UP PROCESS TO HANDLE THE PROCESSING OF THE GAPPED PROCE

                                selltarget = sellprice                                                                                                                              ' SET THE SELL TARGET PRICE BASED ON THE GAP UP
                                buytarget = sellprice - buytrigger                                                                                                                  ' SET THE BUY TARGET BASED ON THE GAP UP

                            Else

                                sellprice = selltarget + (selltrigger * i)                                                                                                          ' SET THE SELLPRICE TO BE PASSED BASED ON THE SELLTARGET MULTIPLIED BY THE SELLTRIGGER TIMES EACH LEVEL

                                SellToClose(sellprice - buytrigger, "UO", price.MarketDate, price.MarketTime)                                                                       ' CALL THE PROCESS TO SELLTOCLOSE THE POSITION

                                selltarget = sellprice + (selltrigger * (levels + 1))                                                                                               ' UPDATE THE SELLTARGET BASED ON THE MOST RECENT POSITION CLOSED
                                buytarget = sellprice - buytrigger                                                                                                                  ' SET THE BUY TARGET BASED ON THE SELL TO CLOSE ACTIVITY

                            End If


                            'sellprice = selltarget + (selltrigger * i)                                                                                                ' SET THE SELLPRICE TO BE PASSED BASED ON THE SELLTARGET MULTIPLIED BY THE SELLTRIGGER TIMES EACH LEVEL

                            'Stop

                            'SellToClose(sellprice - buytrigger, "UO", price.MarketDate, price.MarketTime)                                                                           ' CALL THE PROCESS TO SELLTOCLOSE THE POSITION

                            'selltarget = sellprice + (selltrigger * (levels + 1))                                                                                                   ' UPDATE THE SELLTARGET BASED ON THE MOST RECENT POSITION CLOSED
                            'buytarget = sellprice - buytrigger                                                                                                                      ' UPDATE THE BUYTARGET BASED ON THE MOST RECENT POSITION CLOSED

                            'Stop

                            ' Check whether a financed hedge position can be BoughtToClosed                            
                            'closeShortHedge(sellprice - buytrigger)

                        Next

                        'outputstring = String.Format("{0:MM/dd/yy}", price.MarketDate) & vbTab & String.Format("{0:hh:mm}", price.MarketTime) &
                        '                vbTab & (String.Format("{0:C}", price.HighPrice) & vbTab & "S")

                        lstServerResponses.Items.Add(outputstring)                                                                                                                      ' TEMP WRITE OUTPUT TO THE LISTBOX

                    End If

                    If price.HighPrice >= selltarget Then

                        ' Calculate the number of levels (loops) to add BTO positions here called process should only add the record to the database that is the buy 
                        levels = Int((selltarget - price.HighPrice) * -1 / selltrigger)                                                                                                     ' CALCULATION FOR THE NUMBER OF LEVELS BASED ON TRIGGERS, PASSED PRICE AND TARGETS

                        For i = 0 To levels                                                                                                                                         ' LOOP FOR EACH LEVEL BASED ON A GAP UP

                            sellprice = selltarget + (selltrigger * i)                                                                                                              ' SET THE SELLPRICE TO BE PASSED BASED ON THE SELLTARGET MULTIPLIED BY THE SELLTRIGGER TIMES EACH LEVEL
                            SellToClose(sellprice - buytrigger, "DH", price.MarketDate, price.MarketTime)                                                                           ' CALL THE PROCESS TO SELLTOCLOSE THE POSITION

                            selltarget = sellprice + (selltrigger * (levels + 1))                                                                                                   ' UPDATE THE SELLTARGET BASED ON THE MOST RECENT POSITION CLOSED
                            buytarget = sellprice - buytrigger                                                                                                                      ' UPDATE THE BUYTARGET BASED ON THE MOST RECENT POSITION CLOSED

                            ' Check whether a financed hedge position can be BoughtToClosed                            
                            'closeShortHedge(sellprice - buytrigger)

                        Next

                        'outputstring = String.Format("{0:MM/dd/yy}", price.MarketDate) & vbTab & String.Format("{0:hh:mm}", price.MarketTime) &
                        '                vbTab & (String.Format("{0:C}", price.HighPrice) & vbTab & "S")

                        lstServerResponses.Items.Add(outputstring)                                                                                                                      ' TEMP WRITE OUTPUT TO THE LISTBOX


                    End If

                    If price.LowPrice <= buytarget Then

                        ' Calculate the number of levels (loops) to add BTO positions here called process should only add the record to the database that is the buy 
                        levels = Int((buytarget - price.LowPrice) / buytrigger)                                                                                                     ' CALCULATION FOR THE NUMBER OF LEVELS BASED ON TRIGGERS, PASSED PRICE AND TARGETS

                        For i = 0 To levels                                                                                                                                         ' INITIATE THE LOOP BASED ON THE NUMBER OF LEVELS FROM THE CALCULATION

                            buyprice = buytarget - (buytrigger * i)                                                                                                                 ' CALCULATE THE PRICE AT WHICH THE POSITION WAS BOUGHT 
                            BuyToOpen(buyprice, "DL", price.MarketDate, price.MarketTime)                                                                                           ' CALLED PROCESS TO CHECK IF THERE IS ALREADY A BUY TO OPEN POSITION FOR THIS PRICE LEVEL: IF NOT ADD IT TO THE DB IF THERE IS RETURN WITH NO ACTION.

                            buytarget = buyprice - (buytrigger * (levels + 1))                                                                                                      ' RE-ESTABLISH THE NEW BUYTARGET TO CHECK ALL FUTURE PRICES AGAINST
                            selltarget = buyprice + (selltrigger)                                                                                                                   ' ESTABLISH THE NEW SELLTARGET TO CHECK ALL FUTURE PRICES AGAINST

                            'For this price determine if a hedge can be added and add it to the position and db
                            ' addHedge(buyprice, calcexpdate)

                            ' Add the short hedge for the hedge added.
                            '          calcexpdate = calcexpdate.AddMonths(6)                                                                                                                  ' TO GET THE EXPIRATION DATE FOR THE SHORT HEDGE (FINANCING FOR HEDGE)
                            '          addShortHedge(buyprice, calcexpdate)                                                                                                                    ' FUNCTION TO ADD THE HEDGE TO THE DATABASE TABLES

                            ' For this price determine if any hedge/stock positions can be closed for profit 
                            ' closeHedge(buyprice, price.MarketDate, price.MarketTime, "UL")

                            lstServerResponses.Items.Add(outputstring)                                                                                                                      ' TEMP WRITE OUTPUT TO THE LISTBOX

                        Next
                    End If

                    If price.ClosePrice >= selltarget Then

                        ' Calculate the number of levels (loops) to add BTO positions here called process should only add the record to the database that is the buy 
                        levels = Int((selltarget - price.ClosePrice) * -1 / selltrigger)                                                                                                     ' CALCULATION FOR THE NUMBER OF LEVELS BASED ON TRIGGERS, PASSED PRICE AND TARGETS

                        For i = 0 To levels                                                                                                                                         ' LOOP FOR EACH LEVEL BASED ON A GAP UP

                            sellprice = selltarget + (selltrigger * i)                                                                                                              ' SET THE SELLPRICE TO BE PASSED BASED ON THE SELLTARGET MULTIPLIED BY THE SELLTRIGGER TIMES EACH LEVEL
                            SellToClose(sellprice - buytrigger, "DC", price.MarketDate, price.MarketTime)                                                                           ' CALL THE PROCESS TO SELLTOCLOSE THE POSITION

                            selltarget = sellprice + (selltrigger * (levels + 1))                                                                                                   ' UPDATE THE SELLTARGET BASED ON THE MOST RECENT POSITION CLOSED
                            buytarget = sellprice - buytrigger                                                                                                                      ' UPDATE THE BUYTARGET BASED ON THE MOST RECENT POSITION CLOSED

                            ' Check whether a financed hedge position can be BoughtToClosed                            
                            'closeShortHedge(sellprice - buytrigger)

                        Next

                        'outputstring = String.Format("{0:MM/dd/yy}", price.MarketDate) & vbTab & String.Format("{0:hh:mm}", price.MarketTime) &
                        '                vbTab & (String.Format("{0:C}", price.HighPrice) & vbTab & "S")

                        lstServerResponses.Items.Add(outputstring)                                                                                                                      ' TEMP WRITE OUTPUT TO THE LISTBOX

                    End If

                End If

                recordsread += 1                                                                                                                                                    ' INCREMENT THE NUMBER OF RECORDS (INTERVALS) READ BY 1
                Dim closedmarketintervaldate As Date = price.MarketDate

                ' Backtest Stats Pushed to View Here
                'lblTransactions.Text = (String.Format("{0:##,##0}", trans))
                'lblopenBTOs.Text = (String.Format("{0:##,##0}", openedBTO))
                'lblclosedSTCs.Text = (String.Format("{0:##,##0}", closedSTC))
                'lblMaxCap.Text = (String.Format("{0:C}", maxCapital))
                'lblCurrentCapital.Text = (String.Format("{0:C}", rollingcapital))
            Next                                                                                                                                                                    ' LOOP TO NEXT INTERVAL

        Catch ex As Exception

            ' ADD ERROR CODE LOGIC HERE TO ADD TO THE ERROR LISTBOX AND SEND A MSGBOX MESSAGE TO THE USER
            MsgBox("Error: " & ex.ToString())

        Finally
            Cursor = Cursors.Default                                                                                                                                                ' RETURN CURSOR TO DEFAULT STATUS
            btnStartBackTest.Enabled = True                                                                                                                                         ' SET STARTBACKTEST BUTTON ENABLED EQUALS TRUE
            datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                                                                         ' ADD THE CURRENT TIME TO THE DATASTRING TO CAPTURE THE END OF PROCESS TIME
            lblStatus.Text = "Backtest Records Read: " & String.Format("{0: ##,###,000}", recordsread) & " " & datastring                                                           ' LABEL INDICATOR SHOWING THAT PROCESSING IS COMPLETE
        End Try
    End Sub







    Private Function ParseBackDataDP(csvData As String) As List(Of BackPrice)                                                                                                             ' THIS FUNCTION WILL PARSE THE INTERVAL PRICES FROM THE CSV FILE.
        Dim rowcntr As Integer = 0                                                                                                                                                      ' INITALIZE THE ROW COUNTER.
        Dim backprices As New List(Of BackPrice)()                                                                                                                                      ' INITIALIZE THE BACKPRICES LIST
        Dim marketdatetime As DateTime = DPdatetime & " " & #9:30:00#                                                                                                                                             ' INITIALIZE THE MARKET DATE BEING PROCESSED    
        Dim markettime As DateTime = marketdatetime.ToShortTimeString()

        Dim rows As String() = csvData.Replace(vbCr, "").Split(ControlChars.Lf)                                                                                                         ' LOADS EACH LINE INTO ROWS TO BE PARSED

        For Each row As String In rows                                                                                                                                                  ' ROW LOOPS

            If String.IsNullOrEmpty(row) Then                                                                                                                                           ' IF THE LINE IS NULL OR EMPTY MOVE TO NEXT ROW
                rowcntr += 1
                Continue For                                                                                                                                                            ' MOVE FORWARD IN THE LOOP
            End If

            If rowcntr < 8 Then                                                                                                                                                    ' CHECK FOR THE DATE ROW. USED IN YAHOO FINANCE
                rowcntr += 1
                Continue For
            End If

            Dim cols As String() = row.Split(","c)                                                                                                                                      ' SPLIT ROWS INTO FIELDS BASED ON , 

            Dim p As New BackPrice()                                                                                                                                                    ' INITIALIZE A NEW BACKPRICE 

            If Len(cols(0)) > 3 Then
                p.interval = 0
            Else
                p.interval = Convert.ToInt16(cols(0))
            End If

            p.MarketTime = markettime.AddMinutes(rowcntr - 8)
            p.MarketDate = marketdatetime
            p.OpenPrice = Convert.ToDecimal(cols(1))                                                                                                                                    ' SET COLUMN 2 TO OPEN PRICE    
            p.HighPrice = Convert.ToDecimal(cols(2))                                                                                                                                    ' SET COLUMN 3 TO HIGH PRICE
            p.LowPrice = Convert.ToDecimal(cols(3))                                                                                                                                     ' SET COLUMN 4 TO LOW PRICE
            p.ClosePrice = Convert.ToDecimal(cols(4))                                                                                                                                   ' SET COLUMN 5 TO CLOSE PRICE            
            ' SET INTERVAL FIELD IN PRICE TO CURRENT ROW

            backprices.Add(p)

            rowcntr = rowcntr + 1                                                                                                                                                       ' INCREMENT THE ROW COUNTER
        Next

        Return backprices                                                                                                                                                               ' RETURN TO CALLING FUNCTION WITH BACKPRICES MODEL POPULATED
    End Function



    Private Function ParseBackTestData(csvData As String) As List(Of BackPrice)                                                                                                             ' THIS FUNCTION WILL PARSE THE INTERVAL PRICES FROM THE CSV FILE.
        Dim rowcntr As Integer = 0                                                                                                                                                      ' INITALIZE THE ROW COUNTER.
        Dim backprices As New List(Of BackPrice)()                                                                                                                                      ' INITIALIZE THE BACKPRICES LIST
        ' Dim marketdatetime As DateTime                                                                                                                                                  ' INITIALIZE THE MARKET DATE BEING PROCESSED    

        Dim rows As String() = csvData.Replace(vbCr, "").Split(ControlChars.Lf)                                                                                                         ' LOADS EACH LINE INTO ROWS TO BE PARSED

        For Each row As String In rows                                                                                                                                                  ' ROW LOOPS

            If String.IsNullOrEmpty(row) Then                                                                                                                                           ' IF THE LINE IS NULL OR EMPTY MOVE TO NEXT ROW
                Continue For                                                                                                                                                            ' MOVE FORWARD IN THE LOOP
            End If

            Dim cols As String() = row.Split(","c)                                                                                                                                      ' SPLIT ROWS INTO FIELDS BASED ON , 

            If cols(0) = "Date" Then                                                                                                                                                    ' CHECK FOR THE DATE ROW. USED IN YAHOO FINANCE
                Continue For
            End If

            Dim p As New BackPrice()                                                                                                                                                    ' INITIALIZE A NEW BACKPRICE 
            p.MarketDate = cols(0)                                                                                                                                                      ' SET COLUMN 0 TO MARKET DATE
            p.MarketTime = cols(1)
            p.interval = Convert.ToDecimal(cols(2))
            p.OpenPrice = Convert.ToDecimal(cols(3))                                                                                                                                    ' SET COLUMN 2 TO OPEN PRICE    
            p.HighPrice = Convert.ToDecimal(cols(4))                                                                                                                                    ' SET COLUMN 3 TO HIGH PRICE
            p.LowPrice = Convert.ToDecimal(cols(5))                                                                                                                                     ' SET COLUMN 4 TO LOW PRICE
            p.ClosePrice = Convert.ToDecimal(cols(6))                                                                                                                                   ' SET COLUMN 5 TO CLOSE PRICE            

            'marketdatetime = p.MarketDate & " " & p.MarketTime

            '' ONLY ADD ROWS WHERE THE MARKET IS OPEN.
            'If marketdatetime.ToShortTimeString() > #9:29:00 AM# Then                                                                                                                   ' CHECK IF MARKET TIME IS AFTER MARKET OPENS                
            '    If marketdatetime.ToShortTimeString() < #4:01:00 PM# Then                                                                                                               ' CHECK IF MARKET TIME IS BEFORE MARKET CLOSES CHANGE BACK TO 4:01:00 PM                    
            '        p.interval = rowcntr                                                                                                                                                ' SET INTERVAL FIELD IN PRICE TO CURRENT ROW
            backprices.Add(p)                                                                                                                                                   ' ADD P TO BACKPRICES
            '        rowcntr = rowcntr + 1                                                                                                                                               ' INCREMENT THE ROW COUNTER
            '    End If
            'End If

        Next

        Return backprices                                                                                                                                                               ' RETURN TO CALLING FUNCTION WITH BACKPRICES MODEL POPULATED
    End Function



    ' ******************************************************************************************************************************
    ' CALLED FUNCTIONS USED IN PROCESSED FOR THE APPLICATION
    '  prepare to move these to bondi.vb
    ' ******************************************************************************************************************************

    Private Function getHedgeData(ByVal harvestkey As String)

        ' **************************************************
        ' THIS FUNCTION GETS THE INDEX DATA FROM THE DATABASE AND SETS THE LOCAL VARIABLES BASED ON THE DB ATTRIBUTES FOR THE HERVESTKEY
        ' **************************************************

        Using db As BondiModel = New BondiModel()                                                                                           ' INITIALIZE THE MODEL TO THE DB VARIABLE FOR USE IN GETTING DATA FROM THE DATATABLES
            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                                   ' ESTABLISH THE LIST TO HOUSE THE HARVEST INDEX RECORDS
            hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = harvestkey).ToList()                                       ' INITIALIZE THE HARVEST INDEX DATABASE RECORDS TO A LIST

            ' SET VARIABLES EQUAL TO THE DATA IN THE DATABASE TABLE MATCHING THE HARVEST KEY

            buytrigger = hi.FirstOrDefault().opentrigger                                                                                    ' SET THE BUYTRIGGER
            selltrigger = hi.FirstOrDefault().width                                                                                         ' SET THE SELLTRIGGER
            shares = hi.FirstOrDefault().shares                                                                                             ' SET THE SHARES FOR THE STOCK POSITIONS
            lots = hi.FirstOrDefault().hedgelots                                                                                            ' SET THE LOTS FOR THE HEDGE POSITIONS
            hedgewidth = hi.FirstOrDefault().hedgewidth                                                                                     ' SET THE HEDGE WIDTH FOR THE HEDGE POSITIONS
            expdatewidth = hi.FirstOrDefault().expdatewidth                                                                                 ' SET THE EXPIRATION DATE WIDTH FOR THE HEDGE POSITIONS
            hedge = hi.FirstOrDefault().hedge                                                                                               ' SET WHETHER THERE IS A HEDGE TO BE USED OR NOT BASED ON THE HEDGE FLAG IN THE INDEX TABLE

        End Using

    End Function

    Function calcExpirationDate(ByVal harvestkey As String, ByVal marketdate As Date) As Date                                               ' CALLED FUNCTION TO CALCULATE THE EXPIRATION DATE FOR THE HEDGE OPTIONS.

        Dim expyear As Integer = marketdate.Year                                                                                            ' SET THE YEAR FOR THE EXPIRATION OF THE HEDGE
        Dim expmonth As Integer = marketdate.Month                                                                                          ' SET THE MONTH FOR THE EXPIRATION OF THE HEDGE.

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


    Function BuyToOpen(ByVal passedprice As Decimal, ByVal btoflag As String, ByVal marketdate As DateTime, ByVal markettime As DateTime)

        ' *************************************************
        ' WRITES THE BTO RECORD TO THE DATABASE & CALCULATES THE BTO STATISTICS AND ADDS TO THE DB
        ' *************************************************



        Using db As BondiModel = New BondiModel()                                                                                                                               ' ESTABLISH THE CONNECTION TO THE DATABASE MODEL USING ENTITY FRAMEWORK

            Dim orderexists = (From q In db.backtests Where q.harvestkey = harvestkey Select q)                                                                                 ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO FOR THIS HARVESTKEY
            If orderexists.Count = 0 Then                                                                                                                                       ' IF THE ORDER DOES NOT EXIST THEN ADD THIS RECORD TO THE db - **** CHECK IF NEED TO MOVE THIS CHECK UP RIGHT AFTER THE IF LOW<BUYTARGET

                currentCapital = passedprice * shares                                                                                                          ' SET THE INITIAL AMOUNT OF THE CURRENT CAPITAL EQUAL TO THE PASSEDPRICE TIMES SHARES (NO RECORDS FOR THIS INDEX EXIST)
                rollingcapital = rollingcapital + currentCapital

                ' SAVE THE RECORD TO THE DATABASE                   
                Dim newBuyOrder As New backtest With {
                                                        .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                        .btomarketdate = DateTime.Parse(marketdate & " " & markettime).ToUniversalTime(),
                                                        .harvestkey = harvestkey,
                                                        .symbol = ticksymbol,
                                                        .buyprice = passedprice,
                                                        .shares = shares,
                                                        .currentcapital = currentCapital,
                                                        .maxcapital = currentCapital,
                                                        .open = True,
                                                        .hedge = False,
                                                        .lastaction = DateTime.Parse(Now).ToUniversalTime(),
                                                        .btofield = btoflag
                                                        }                                                                                                                       ' ADD THE BTO RECORD TO THE BACKTEST TABLE
                db.backtests.Add(newBuyOrder)                                                                                                                                   ' INSERT THE NEW RECORD TO BE ADDED.
                db.SaveChanges()                                                                                                                                                ' SAVE THE RECORD TO THE DATABASE

                trans += 1
                openedBTO += 1

                outputstring = String.Format("{0:MM/dd/yy}", marketdate) & vbTab & String.Format("{0:hh:mm}", markettime) &
                   vbTab & (String.Format("{0:C}", passedprice) & vbTab & "B")                                                                                                 ' CREATE THE OUTPUT STRING FOR THE LISTBOX UPDATING USER FOR RECORD ADDED

            Else

                ' 1. determine if there is an order already open at this price
                Dim orderatprice = (From q In db.backtests Where q.harvestkey = harvestkey And q.buyprice = passedprice And q.open = True Select q)                             ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO FOR THIS HARVESTKEY AT THE PASSED PRICE
                If orderatprice.Count = 0 Then                                                                                                                                  ' IF THE ORDER DOES NOT EXIST THEN ADD THIS RECORD TO THE db - **** CHECK IF NEED TO MOVE THIS CHECK UP RIGHT AFTER THE IF LOW<BUYTARGET

                    Dim maxcap = From p In db.backtests Where p.harvestkey = harvestkey Order By p.maxcapital Descending Select p                                               ' GET THE LAST RECORD ADDED/UPDATED TO GET THE MAXIMUM CAPITAL AMOUNT
                    maxCapital = maxcap.FirstOrDefault().maxcapital                                                                                                             ' ASSIGN LAST MAX CAPITAL AMOUNT TO THE MAX CAPITAL VARIABLE TO CHECK IF WE HAVE ACHEIVED A NEW MAX CAPITAL LEVEL

                    ' NEED TO TEST THIS - IF WE ARE IN A SECOND OR THIRD RUN NEED TO GET THE LAST CURRENT CAPITAL AMOUNT FROM THE DB
                    'If currentCapital = 0 Then
                    '    currentCapital = currentCapital + passedprice * shares                                                                                                  ' IF CAPITAL REACHED ZERO THEN SET CURRENT CAPITAL EQUAL TO THE PASSED PRICE TIMES SHARES
                    'End If

                    ' Dim curcap = From p In db.backtests Where p.harvestkey = harvestkey And p.open = True Order By p.lastaction Descending Select p                             ' GET THE LAST RECORD ADDED/UPDATED TO GET THE CURRENT CAPITAL AMOUNT
                    ' currentCapital = curcap.FirstOrDefault().currentcapital                                                                                                     ' ASSIGN LAST CURRENT CAPITAL AMOUNT TO CURRENT CAPITAL VARIABLE TO BE ADDED TO BTOCAPITAL FOR CURRENT BTO ORDER
                    currentCapital = passedprice * shares                                                                                                    ' ADD CALCULATED CAPITAL FOR THIS BUY ORDER TO THE CURRENT CAPITAL VALUE FROM THE DB
                    rollingcapital = rollingcapital + currentCapital
                    ' Stop


                    If rollingcapital > maxCapital Then
                        maxCapital = rollingcapital
                    End If

                    ' SAVE THE RECORD TO THE DATABASE                  
                    Dim newBuyOrder As New backtest With {
                                                        .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                        .btomarketdate = DateTime.Parse(marketdate & " " & markettime).ToUniversalTime(),
                                                        .harvestkey = harvestkey,
                                                        .symbol = ticksymbol,
                                                        .buyprice = passedprice,
                                                        .shares = shares,
                                                        .currentcapital = rollingcapital,
                                                        .maxcapital = maxCapital,
                                                        .open = True,
                                                        .hedge = False,
                                                        .lastaction = DateTime.Parse(Now).ToUniversalTime(),
                                                        .btofield = btoflag
                                                        }                                                                                                                       ' ADD THE BTO RECORD TO THE BACKTEST TABLE
                    db.backtests.Add(newBuyOrder)                                                                                                                                   ' INSERT THE NEW RECORD TO BE ADDED.
                    db.SaveChanges()                                                                                                                                                ' SAVE THE RECORD TO THE DATABASE

                    trans += 1
                    openedBTO += 1

                    outputstring = String.Format("{0:MM/dd/yy}", marketdate) & vbTab & String.Format("{0:hh:mm}", markettime) &
                    vbTab & (String.Format("{0:C}", passedprice) & vbTab & "B")                                                                                                 ' CREATE THE OUTPUT STRING FOR THE LISTBOX UPDATING USER FOR RECORD ADDED
                    'lstServerResponses.Items.Add(outputstring)                                                                                                                      ' TEMP WRITE OUTPUT TO THE LISTBOX

                End If
            End If

        End Using

    End Function

    Function AddHedge(ByVal passedprice As Decimal, ByVal calcexpdate As Date)

        Dim hedgeexit As Decimal = 0

        ' Determine if there is a hedge position open for the passed price and harvestkey.
        Using db As BondiModel = New BondiModel()                                                                                                                               ' ESTABLISH THE CONNECTION TO THE DATABASE MODEL USING ENTITY FRAMEWORK

            Dim hedgeexists = (From q In db.backtests Where q.harvestkey.ToUpper() = harvestkey.ToUpper() And q.buyprice = passedprice _
                               And q.hedge = True Select q)                                                                                                                     ' QUERY TO SEE IF THERE IS A RECORD IN THE DATABASE TO MATCH THE ORDER CANCELLED
            'Dim hedgeorderexists = (From h In db.backtests Where h.harvestkey = harvestkey Select h)                                                                            ' QUERY THE DATABASE FOR A HEDGE POSITION AT THE CURRENT PASSED PRICE LEVEL

            'Stop

            If hedgeexists.Any() = True Then

                'Stop            ' Means that there is a position here without a hedge set to it.  Need to know if there is a position with a hedge on it already 

            Else
                ' calculate hedge details / get them from the index
                Dim iv As Double = 0.72                                                                                                                                         ' TO CALCULATE THE PUTPRICE IN EXCEL NEED TO PASS THE IMPLIED VOLATILITY VALUE
                Dim targetprice As Integer = Int(passedprice - hedgewidth)                                                                                                      ' USED IN CALCULATING THE TARGET MAX EXIT PRICE TO ACHEIVE PROFITABILITY IN THE HEDGE TARGET EXIT PRICE                

                Dim rtu = (From q In db.backtests Where q.harvestkey = harvestkey And q.buyprice = passedprice And q.open = True And q.hedge = False Select q).FirstOrDefault() ' GET THE RECORD TO HAVE THE HEDGE ADDED TO IT - RTU = RECORD TO UPDATE 

                ' MsgBox(rtu.buyprice & "  " & rtu.hedge.ToString() & " x")

                'Call BSCS(passedprice, Int(passedprice) - hedgewidth, rtu.btomarketdate, calcexpdate, iv)                                                                          ' CALL THE FUNCTION TO CALCULATE THE OPTION PRICE IN EXCEL USING THE BLACK SCHOLES MODEL - WHILE THIS IS NOT 100% ACCURATE IT WILL PROVIDE THE DATA FOR BACKTESTING HEDGES
                putprice = bcktst.Putprice(passedprice, Int(passedprice) - hedgewidth, rtu.btomarketdate, calcexpdate, iv)                                                                 ' CALL THE FUNCTION TO CALCULATE THE OPTION PRICE IN EXCEL USING THE BLACK SCHOLES MODEL - WHILE THIS IS NOT 100% ACCURATE IT WILL PROVIDE THE DATA FOR BACKTESTING HEDGES
                hedgeexit = ((((targetprice - passedprice) / lots) - putprice) - (buytrigger / lots)) * -1                                                                          ' CALCULATE THE HEDGE TARGET EXIT PRICE 

                hedgecapital = putprice * lots * shares
                rollingcapital = rollingcapital + hedgecapital

                If rtu.currentcapital + hedgecapital > rtu.maxcapital Then
                    rtu.maxcapital = rtu.currentcapital + hedgecapital
                End If

                rtu.hedge = True
                rtu.type = "P"
                rtu.lots = lots
                rtu.strike = Int(passedprice) - hedgewidth
                rtu.exp = DateTime.Parse(calcexpdate).ToUniversalTime()
                rtu.hedgeBTOprice = putprice
                rtu.currentcapital = rollingcapital
                rtu.hedgeOpenTimestamp = DateTime.Parse(rtu.btomarketdate)
                rtu.lastaction = DateTime.Parse(Now).ToUniversalTime()
                rtu.targetexit = hedgeexit

                db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            

                outputstring = outputstring & vbTab & "Put" & vbTab & String.Format("{0:C}", (Int(passedprice - hedgewidth))) & vbTab & String.Format("{0:MM/dd/yy}", calcexpdate) & vbTab & vbTab & String.Format("{0:c}", putprice) & vbTab & String.Format("{0:c}", hedgeexit)

            End If
        End Using

    End Function

    Function closeHedge(ByVal passedprice As Decimal, ByVal marketdate As DateTime, ByVal markettime As DateTime, ByVal stcfield As String)

        Try

            ' Function that will check all open hedges with the price passed to determine if it can be closed at a profit.
            Using db As BondiModel = New BondiModel()                                                                                                                               ' ESTABLISH THE CONNECTION TO THE DATABASE MODEL USING ENTITY FRAMEWORK
                ' get all BTOs that have a price greater than passed price where hedges are open

                Dim ch = From h In db.backtests Where h.open = True And h.buyprice > passedprice And h.hedge = True Select h                                                        ' PULL ALL RECORDS WHERE THE BUY PRICE IS GREATER THAN THE PASSED PRICE - REPOSITORY IS CH FOR CLOSE HEDGE

                If ch.Count > 0 Then

                    For i = 1 To ch.Count
                        Dim checkprice As Decimal = passedprice + (selltrigger * i)

                        Dim rtu = (From h In db.backtests Where h.open = True And h.buyprice = checkprice Select h Order By h.buyprice Descending).FirstOrDefault()                 ' PULL ALL RECORDS WHERE THE BUY PRICE IS GREATER THAN THE PASSED PRICE - REPOSITORY IS CH FOR CLOSE HEDGE

                        Dim iv As Double = 0.72 '+ (i * 0.01)

                        Call BSCS(passedprice, rtu.strike, rtu.btomarketdate, rtu.exp, iv)

                        Dim stockloss As Decimal = (passedprice * rtu.shares) - (rtu.buyprice * rtu.shares)
                        Dim hedgepl As Decimal = (putprice * rtu.lots * rtu.shares) - (rtu.hedgeBTOprice * rtu.lots * rtu.shares)

                        If hedgepl + stockloss > selltrigger * shares Then

                            currentCapital = rtu.hedgeBTOprice * rtu.lots * rtu.shares + rtu.buyprice * rtu.shares
                            rollingcapital = rollingcapital - currentCapital

                            ' Stop
                            ' with how I am catching whether a hedge exists for this position I will need to set hedge to closed here
                            rtu.open = False
                            rtu.hedge = False
                            rtu.hedgeclosed = True
                            rtu.hedgeCloseTimestamp = DateTime.Parse(marketdate & " " & markettime).ToUniversalTime()
                            rtu.hedgeSTCprice = putprice
                            rtu.stcmarketdate = DateTime.Parse(marketdate & " " & markettime).ToUniversalTime()
                            rtu.sellprice = passedprice
                            rtu.stcfield = stcfield
                            rtu.lastaction = DateTime.Parse(Now).ToUniversalTime()
                            'rtu.currentcapital = currentCapital - (rtu.buyprice * rtu.shares) - (rtu.hedgeBTOprice * rtu.lots * rtu.shares)

                            Dim currCapital = From h In db.backtests Where h.open = True And h.buyprice = passedprice Select h

                            currCapital.FirstOrDefault().currentcapital = rollingcapital
                            currCapital.FirstOrDefault().lastaction = DateTime.Parse(Now).ToUniversalTime()

                            db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            

                            trans -= 1                                                                                                  ' INCREMENT THE TRANSACTION COUNTER AS A TRANSACTION OCCURRED
                            closedBTO += 1
                        End If

                    Next

                End If

            End Using
        Catch ex As Exception
            Stop
            MsgBox(ex.ToString())
            Stop
        End Try

    End Function

    Function SellToClose(ByVal passedprice As Decimal, ByVal stcflag As String, ByVal marketdate As DateTime, ByVal markettime As DateTime)
        ' *************************************************
        ' WRITES THE STC RECORD TO THE DATABASE & CALCULATES THE STC STATISTICS AND ADDS TO THE DB
        ' *************************************************
        'Stop

        Using db As BondiModel = New BondiModel()                                                                                                                               ' ESTABLISH THE CONNECTION TO THE DATABASE MODEL USING ENTITY FRAMEWORK

            Dim rtu = (From h In db.backtests Where h.open = True And h.buyprice = passedprice Select h).FirstOrDefault()                                                       ' PULL ALL RECORDS WHERE THE BUY PRICE IS EQUAL TO THE PASSED PRICE 

            If rtu Is Nothing Then                                                                                                                                              ' BECAUSE THERE COULD BE PASSED PRICES TO SELL WHERE THERE IS NO INVENTORY THIS PREVENTS A NULL OBJECT ERROR
                Exit Function                                                                                                                                                   ' EXIT THE FUNCTION 
            End If

            currentCapital = passedprice * shares                                                                                                                               ' CALCULATES THE CURRENT CAPITAL FOR THIS STC TRANSACTION
            rollingcapital = rollingcapital - currentCapital                                                                                                                    ' BECAUSE THIS IS A STC SUBTRACT CURRENT CAPITAL FROM ROLLING CAPITAL


            rtu.open = False                                                                                                                                                    ' SET THE OPEN STATUS FOR THIS RECORD TO FALSE
            rtu.stcmarketdate = DateTime.Parse(marketdate & " " & markettime).ToUniversalTime()                                                                                 ' SET THE STC CLOSE MARKET DATE AND TIME 
            rtu.sellprice = passedprice + selltrigger                                                                                                                           ' SET THE PRICE AT WHICH THIS POSITION WAS CLOSED 
            rtu.stcfield = stcflag                                                                                                                                              ' CAPTURE THE INTERVAL DIRECTION AND OHLC PRICE THAT CAUSE THE EVENT TO TRIGGER
            rtu.lastaction = DateTime.Parse(Now).ToUniversalTime()                                                                                                              ' SET THE LAST ACTION DATE AND TIME TO NOW

            db.SaveChanges()                                                                                                                                                    ' SAVE THE CHANGES TO THE DATABASE          

            Dim currCapital = (From h In db.backtests Order By h.id Descending Select h).FirstOrDefault()                                                                       ' GET THE LAST RECORD ID TO SET THE CURRENT CAPITAL LEVEL IN THE DATABASE

            currCapital.currentcapital = rollingcapital                                                                                                                         ' SET THE CURRENT CAPITAL TO THE ROLLING CAPITAL
            currCapital.lastaction = DateTime.Parse(Now).ToUniversalTime()                                                                                                      ' UPDATE THE LAST ACTIONDATE FOR THIS RECORD

            db.SaveChanges()                                                                                                                                                    ' SAVE THE CHANGES TO THE DATABASE          
            trans += 1
            closedSTC += 1

            'TODO:  Add code to check to close any short hedge postions when a stock position closes - makes the most logical sense to do it here.
            outputstring = String.Format("{0:MM/dd/yy}", marketdate) & vbTab & String.Format("{0:hh:mm}", markettime) &
                                       vbTab & (String.Format("{0:C}", passedprice + selltrigger) & vbTab & "S")
        End Using

    End Function

    Function STCGapUp(ByVal passedprice As Decimal, ByVal stcflag As String, ByVal marketdate As DateTime, ByVal markettime As DateTime)
        ' THIS FUNCTION IS USED FOR A GAP UP OPEN IN THE BACKTEST SIMULATING THE EFFECT OF A 2 OR GREATER GAP UP IN THE PRICE OF THE STOCK AND CLOSING ALL STCs BELOW THAT PRICE LEVEL IN THE DATABASE.

        'Stop

        Using db As BondiModel = New BondiModel()                                                                                                                               ' ESTABLISH THE CONNECTION TO THE DATABASE MODEL USING ENTITY FRAMEWORK

            'Dim ptcExists = From h In db.backtests Where h.harvestkey = harvestkey And h.buyprice < passedprice And h.open = True Select h                                      ' QUERY THE DATABASE FOR A HEDGE POSITION AT THE CURRENT PASSED PRICE LEVEL
            'MsgBox(ptcExists.Count())

            Dim rtu = (From h In db.backtests Where h.harvestkey = harvestkey And h.open = True And h.buyprice < passedprice Select h).FirstOrDefault()                         ' PULL ALL RECORDS WHERE THE BUY PRICE IS EQUAL TO THE PASSED PRICE 

            If rtu Is Nothing Then                                                                                                                                              ' BECAUSE THERE COULD BE PASSED PRICES TO SELL WHERE THERE IS NO INVENTORY THIS PREVENTS A NULL OBJECT ERROR
                Exit Function                                                                                                                                                   ' EXIT THE FUNCTION 
            End If

            rtu.open = False                                                                                                                                                    ' SET THE OPEN STATUS FOR THIS RECORD TO FALSE
            rtu.stcmarketdate = DateTime.Parse(marketdate & " " & markettime).ToUniversalTime()                                                                                 ' SET THE STC CLOSE MARKET DATE AND TIME 
            rtu.sellprice = passedprice                                                                                                                                         ' SET THE PRICE AT WHICH THIS POSITION WAS CLOSED 
            rtu.stcfield = stcflag                                                                                                                                              ' CAPTURE THE INTERVAL DIRECTION AND OHLC PRICE THAT CAUSE THE EVENT TO TRIGGER
            rtu.lastaction = DateTime.Parse(Now).ToUniversalTime()                                                                                                              ' SET THE LAST ACTION DATE AND TIME TO NOW

            db.SaveChanges()                                                                                                                                                    ' SAVE THE CHANGES TO THE DATABASE          

            Dim currCapital = (From h In db.backtests Order By h.id Descending Select h).FirstOrDefault()                                                                       ' GET THE LAST RECORD ID TO SET THE CURRENT CAPITAL LEVEL IN THE DATABASE

            currCapital.currentcapital = rollingcapital                                                                                                                         ' SET THE CURRENT CAPITAL TO THE ROLLING CAPITAL
            currCapital.lastaction = DateTime.Parse(Now).ToUniversalTime()                                                                                                      ' UPDATE THE LAST ACTIONDATE FOR THIS RECORD

            db.SaveChanges()                                                                                                                                                    ' SAVE THE CHANGES TO THE DATABASE          
            trans += 1
            closedSTC += 1


            outputstring = String.Format("{0:MM/dd/yy}", marketdate) & vbTab & String.Format("{0:hh:mm}", markettime) &
                                      vbTab & (String.Format("{0:C}", passedprice) & vbTab & "S")

        End Using


    End Function

    Function SellToCloseGapUp(ByVal passedprice As Decimal, ByVal stcflag As String, ByVal marketdate As DateTime, ByVal markettime As DateTime)
        Stop
        ' *************************************************
        ' WRITES THE STC RECORD TO THE DATABASE & CALCULATES THE STC STATISTICS AND ADDS TO THE DB
        ' *************************************************
        'Stop
        If marketdate = #01/18/2018# Then
            Stop
        End If

        Using db As BondiModel = New BondiModel()                                                                                                                               ' ESTABLISH THE CONNECTION TO THE DATABASE MODEL USING ENTITY FRAMEWORK

            Dim rtu = (From h In db.backtests Where h.open = True And h.buyprice = passedprice Select h).FirstOrDefault()                                                       ' PULL ALL RECORDS WHERE THE BUY PRICE IS EQUAL TO THE PASSED PRICE 

            If rtu Is Nothing Then                                                                                                                                              ' BECAUSE THERE COULD BE PASSED PRICES TO SELL WHERE THERE IS NO INVENTORY THIS PREVENTS A NULL OBJECT ERROR
                Exit Function                                                                                                                                                   ' EXIT THE FUNCTION 
            End If

            currentCapital = passedprice * shares                                                                                                                               ' CALCULATES THE CURRENT CAPITAL FOR THIS STC TRANSACTION
            rollingcapital = rollingcapital - currentCapital                                                                                                                    ' BECAUSE THIS IS A STC SUBTRACT CURRENT CAPITAL FROM ROLLING CAPITAL


            rtu.open = False                                                                                                                                                    ' SET THE OPEN STATUS FOR THIS RECORD TO FALSE
            rtu.stcmarketdate = DateTime.Parse(marketdate & " " & markettime).ToUniversalTime()                                                                                 ' SET THE STC CLOSE MARKET DATE AND TIME 
            rtu.sellprice = passedprice + selltrigger                                                                                                                           ' SET THE PRICE AT WHICH THIS POSITION WAS CLOSED 
            rtu.stcfield = stcflag                                                                                                                                              ' CAPTURE THE INTERVAL DIRECTION AND OHLC PRICE THAT CAUSE THE EVENT TO TRIGGER
            rtu.lastaction = DateTime.Parse(Now).ToUniversalTime()                                                                                                              ' SET THE LAST ACTION DATE AND TIME TO NOW

            db.SaveChanges()                                                                                                                                                    ' SAVE THE CHANGES TO THE DATABASE          

            Dim currCapital = (From h In db.backtests Order By h.id Descending Select h).FirstOrDefault()                                                                       ' GET THE LAST RECORD ID TO SET THE CURRENT CAPITAL LEVEL IN THE DATABASE

            currCapital.currentcapital = rollingcapital                                                                                                                         ' SET THE CURRENT CAPITAL TO THE ROLLING CAPITAL
            currCapital.lastaction = DateTime.Parse(Now).ToUniversalTime()                                                                                                      ' UPDATE THE LAST ACTIONDATE FOR THIS RECORD

            db.SaveChanges()                                                                                                                                                    ' SAVE THE CHANGES TO THE DATABASE          
            trans += 1
            closedSTC += 1

            'TODO:  Add code to check to close any short hedge postions when a stock position closes - makes the most logical sense to do it here.
            outputstring = String.Format("{0:MM/dd/yy}", marketdate) & vbTab & String.Format("{0:hh:mm}", markettime) &
                                       vbTab & (String.Format("{0:C}", passedprice + selltrigger) & vbTab & "S")
        End Using

    End Function





    Function AddShortHedge(ByVal passedprice As Decimal, ByVal calcexpdate As Date)

        ' Determine if there is a short hedge position open for the passed price and harvestkey.
        Using db As BondiModel = New BondiModel()                                                                                                                               ' ESTABLISH THE CONNECTION TO THE DATABASE MODEL USING ENTITY FRAMEWORK


            'TODO: cannot have more short hedges open than existing hedge positions - do not add if there is no room.
            ' create a loop based on existing hedge positions check if there is one for that position or count not 
            ' sure the best route to take on working through that.


            Dim shorthedgeexists = From h In db.backtests Where h.harvestkey = harvestkey And h.buyprice = passedprice And h.shortHedge = False Select h                        ' QUERY THE DATABASE FOR A HEDGE POSITION AT THE CURRENT PASSED PRICE LEVEL
            If shorthedgeexists.Count = 0 Then                                                                                                                                  ' IF THIS COUNT EQUALS ZERO THEN THERE IS NOT A HEDGE PRESENT FOR THIS PRICE LEVEL THAT IS OPEN

                ' calculate hedge details / get them from the index
                Dim iv As Double = 0.72                                                                                                                                         ' TO CALCULATE THE PUTPRICE IN EXCEL NEED TO PASS THE IMPLIED VOLATILITY VALUE
                Dim targetprice As Integer = Int(passedprice - hedgewidth)                                                                                                      ' USED IN CALCULATING THE TARGET MAX EXIT PRICE TO ACHEIVE PROFITABILITY IN THE HEDGE TARGET EXIT PRICE                

                Dim rtu = (From q In db.backtests Where q.harvestkey = harvestkey And q.buyprice = passedprice And q.open = True Select q).FirstOrDefault()                     ' GET THE RECORD TO HAVE THE HEDGE ADDED TO IT - RTU = RECORD TO UPDATE 

                Call BSCS(passedprice, Int(passedprice) - hedgewidth, rtu.btomarketdate, calcexpdate, iv)                                                                       ' CALL THE FUNCTION TO CALCULATE THE OPTION PRICE IN EXCEL USING THE BLACK SCHOLES MODEL - WHILE THIS IS NOT 100% ACCURATE IT WILL PROVIDE THE DATA FOR BACKTESTING HEDGES

                rtu.shortHedge = True
                rtu.shortHedgeEXP = calcexpdate
                rtu.shortHedgeSTOcredit = putprice
                rtu.shortHedgeSTOtimestamp = DateTime.Parse(rtu.btomarketdate).ToUniversalTime()
                rtu.shortHedgeLastaction = DateTime.Parse(Now).ToUniversalTime()

                'db.SaveChanges()

            End If

        End Using
    End Function

    Function closeShortHedge(ByVal passedprice As Decimal)
        ' Determine if there is a shorthedge position open for the passed price and harvestkey.
        Using db As BondiModel = New BondiModel()                                                                                                                               ' ESTABLISH THE CONNECTION TO THE DATABASE MODEL USING ENTITY FRAMEWORK

            Dim shl As List(Of backtest) = New List(Of backtest)()                                                                                                              ' ESTABLISH THE LIST TO HOUSE THE BACKTEST RECORDS
            shl = db.backtests.AsEnumerable.Where(Function(x) x.shortHedge = True).ToList()                                                                                     ' INITIALIZE THE BACKTEST RECORDS WHERE THERE IS A SHORT HEDGE TO A LIST TO PROCESS

            For Each item In shl                                                                                                                                                ' LOOP THROUGH THE RECORDS WHERE THERE IS A SHORTHEDGE AND DETERMINE IF IT CAN BE CLOSED FOR A PROFIT

                If item.shortHedge = True Then
                    Dim iv As Double = 0.72                                                                                                                                     ' TO CALCULATE THE PUTPRICE IN EXCEL NEED TO PASS THE IMPLIED VOLATILITY VALUE

                    Call BSCS(passedprice, Int(passedprice) - hedgewidth, item.btomarketdate, item.shortHedgeEXP, iv)                                                           ' CALL THE FUNCTION TO CALCULATE THE OPTION PRICE IN EXCEL USING THE BLACK SCHOLES MODEL - WHILE THIS IS NOT 100% ACCURATE IT WILL PROVIDE THE DATA FOR BACKTESTING HEDGES

                    If putprice - item.shortHedgeSTOcredit > 25 Then

                        Dim rtu = (From q In db.backtests Where q.harvestkey = harvestkey And q.id = item.id Select q).FirstOrDefault()                                         ' GET THE RECORD TO HAVE THE HEDGE ADDED TO IT - RTU = RECORD TO UPDATE

                        rtu.shortHedge = False
                        rtu.shortHedgeBTCdebit = putprice
                        rtu.shortHedgeBTCtimestamp = DateTime.Parse(rtu.btomarketdate).ToUniversalTime()
                        rtu.shortHedgeLastaction = DateTime.Parse(Now).ToUniversalTime()

                        db.SaveChanges()


                    End If


                End If


            Next

        End Using
    End Function

    Private Sub btnBacktestClear_Click(sender As Object, e As EventArgs) Handles btnBacktestClear.Click
        lstServerResponses.Items.Clear()                                                                                        ' CLEAR THE MESSAGES IN THE SERVER RESPONSE LISTBOX
        lblStatus.Text = ""
    End Sub

    Private Sub BtnManualClear_Click(sender As Object, e As EventArgs)
        lstServerResponses.Items.Clear()
        lblBuyOrderExists.Text = ""
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        'Dim curdate As Date = 7 / 16 / 2018
        'Dim expdate As Date = #9/21/18#
        Dim curdate As Date = String.Format("{0: MM/dd/yy}", "7/16/18")                                                          ' IF A HEDGE IS NEEDED CALCULATE THE EXPIRATION DATE TARGET TO BE USED IN THE BLACK SCHOLES CALCULATION
        Dim expdate As Date = String.Format("{0: MM/dd/yy}", "9/21/18")                                                          ' IF A HEDGE IS NEEDED CALCULATE THE EXPIRATION DATE TARGET TO BE USED IN THE BLACK SCHOLES CALCULATION

        'Call bondi.testme(harvestkey)
        Dim testme As Decimal = bcktst.Putprice(31.25, 30, curdate, expdate, 0.68)

        MsgBox(testme)

    End Sub












    '--------------------------------------------------------------------------------
    ' CODE FOR MANUAL PANEL TESTED AND COMPLETE
    '--------------------------------------------------------------------------------
    Private Sub btnReqOpenOrders_Click(sender As Object, e As EventArgs) Handles btnReqOpenOrders.Click
        Tws1.reqOpenOrders()
    End Sub

    Private Sub btnReqAllOpenOrders_Click(sender As Object, e As EventArgs) Handles btnReqAllOpenOrders.Click
        Tws1.reqAllOpenOrders()
    End Sub

    Private Sub btnReqMktData_Click(sender As Object, e As EventArgs) Handles btnReqMktData.Click

        ' need to determine how to get generic ticks: 106 Implied Vol

        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                           ' ESTABLISH A NEW CONTRACT CLASS
        contract.SecType = "STK"                                                                                                        ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Currency = "USD"                                                                                                       ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        contract.Exchange = "SMART"                                                                                                     ' INITIALIZE EXCHANGE USED FOR THE CONTRACT
        contract.Symbol = "VXX"

        Tws1.reqMarketDataType(1)                                                                                                       ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(tickId + 1, contract, "", False, Nothing)                                                                      ' CALLS REQUEST FOR MARKET DATA(ID#, CONTRACT DETAILS, SNAPSHOT T/F, 

        Tws1.tickCount = 0

    End Sub

    Private Sub btnCancelMarketData_Click(sender As Object, e As EventArgs) Handles btnCancelMarketData.Click
        Dim mktDataStr As String
        Tws1.cancelMktData(1)

        mktDataStr = "**********  Market Data Cancelled  **********"

        Call m_utils.addListItem(Utils.List_Types.MKT_DATA, mktDataStr)


    End Sub

    Private Sub btnReqContractDetails_Click(sender As Object, e As EventArgs) Handles btnReqContractDetails.Click

        'Stop

        Dim contract As IBApi.Contract = New IBApi.Contract()

        ' CONTRACT DATA FOR EITHER STOCK OR OPTION PRICE REQUESTS
        contract.Symbol = "VXX"                                                                                                     ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
        contract.Exchange = "SMART"                                                                                                 ' INITIALIZE THE EXCHANGE FOR THE CONTRACT
        contract.Currency = "USD"                                                                                                   ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT        

        ' STOCK CONTRACT DATA FOR REQUEST OF PRICE
        contract.SecType = "STK"                                                                                                    ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT

        ' OPTION CONTRACT DATA FOR PRICE REQUEST
        'contract.SecType = "OPT"
        'contract.Currency = "USD"
        'contract.LastTradeDateOrContractMonth = 20180921
        'contract.Strike = 27
        'contract.Right = "P"

        Tws1.reqMarketDataType(1)                                                                                                   ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqContractDetailsEx(1, contract)

        'Stop
    End Sub

    Private Sub btnReqExecutions_Click(sender As Object, e As EventArgs) Handles btnReqExecutions.Click
        'Tws1.reqExecutionsEx()
    End Sub















    ' CODE TO DISCARD AS IT IS IN A SEPARATE CLASS:
    Public Class BackPrice

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

    Private Function BSCS(ByVal stockprice As Double, ByVal strike As Double, ByVal startdate As Date, ByVal enddate As Date, ByVal iv As Double) As Decimal

        Dim excel As New Excel.Application
        Dim fullpath As String = "C:\Users\Troy Belden\Desktop\BSCS.xlsx"

        Dim wb As Excel.Workbook = excel.Workbooks.Open(fullpath)
        Dim ws As Excel.Worksheet = wb.Worksheets("Pricing")
        Dim interestrate As Double = 0
        Dim dividend As Double = 0

        ws.Range("C4").Value = stockprice
        ws.Range("C6").Value = strike
        ws.Range("C8").Value = iv
        ws.Range("C10").Value = interestrate
        ws.Range("C12").Value = dividend
        ws.Range("C15").Value = startdate
        ws.Range("C17").Value = enddate

        Dim callprice As Double = ws.Range("h4").Value
        putprice = ws.Range("h6").Value

        'MsgBox("Black Scholes Call Price: " & String.Format("{0:C}", callprice))
        'MsgBox("Black Scholes Put Price: " & String.Format("{0:C}", putprice))

        ws = Nothing
        wb.Close(False)
        wb = Nothing

        excel.Quit()
        excel = Nothing

        Return putprice

    End Function

    Private Function ParseBackData(csvData As String) As List(Of BackPrice)                                                                                                             ' THIS FUNCTION WILL PARSE THE INTERVAL PRICES FROM THE CSV FILE.
        Dim rowcntr As Integer = 0                                                                                                                                                      ' INITALIZE THE ROW COUNTER.
        Dim backprices As New List(Of BackPrice)()                                                                                                                                      ' INITIALIZE THE BACKPRICES LIST
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

            Dim p As New BackPrice()                                                                                                                                                    ' INITIALIZE A NEW BACKPRICE 
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

    'Private Sub btnAssembleDataFile_Click(sender As Object, e As EventArgs) Handles btnAssembleDataFile.Click

    '    ' possible refactor of code:  If assembledata(variables to be passed) = true then 
    '    '   datastring = "Data file successfully assembled."
    '    'else 
    '    '   datastring = "There was an error assembling the data file, please review."
    '    ' This type of code will allow for a cleaner main file and house the work in the appropriate vb module file.

    '    ' Wrap with try catch and finally

    '    'Dim assembledatafile As New assembledatafile()

    '    'Call bondi.assembledatafile("VXX")









    '    Dim datastring As String = "Data file assembly QQ: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                                                            ' SET INITIAL DATASTRING TO BACKTEST PROCESS AND DATE / TIME
    '    'Dim csvdata As String = ""                                                                                                                                                      ' STRING TO HOLD THE DATA FROM EACH CSV FILE READ INTO MEMORY
    '    'Dim recordsread As Integer = 0                                                                                                                                                  ' VARIABLE TO HOUSE THE NUMBER OF RECORDS READ IN THE DATAFILE
    '    'Dim symbol As String = ""                                                                                                                                                       ' STRING TO HOLD THE SYMBOL OF THE PRODUCT BEING TESTED
    '    'Dim filedate As String = ""                                                                                                                                                     ' ESTABLISHES THE VARIABLE TO HOLD THE FILE DATE FROM THE DATETIME SELECTOR ON THE FORM
    '    '' WILL NEED TO HANLDE TWO TYPES OF FILES HERE: 1. QUANTQUOTE FILE FORMAT AND THE DREAMBIG FILE FORMAT PULLED FROM GOOGLE FINANCE.

    '    'symbol = txtLoadSymbol.Text                                     ' ********* Change this to take the symbol from the harvest key?                                                ' GET THE SYMBOL FOR THE FILE FOR ALL THE PRICES TO BE ASSEMBLED INTO THE MAIN FILE.

    '    'Dim path As String = "C:\Users\Troy Belden\Desktop\stockprices\allstocks_"                                                                                                      ' GENERIC PATH FOR READING THE QUANTQUOTE CSV FILES - WILL NEED TO SET TO USER INPUT FOR PRODUCTION

    '    'Dim strFile As String = "C:\Users\Troy Belden\Desktop\" & symbol.ToUpper() & "_StockData" & ".txt"                                                                              ' PATH FOR THE OUTPUT ASSEMBLED DATA FILE
    '    'Dim sw As StreamWriter                                                                                                                                                          ' DEFINE THE STREAMWRITER FOR FILE ASSEMBLY

    '    'If (Not File.Exists(strFile)) Then                                                                                                                                              ' CHECKS TO SEE IF THE FILE ALREADY EXISTS - IF NOT IT CREATES THE FILE IF IT DOES IT APPENDS TO THE FILE
    '    '    sw = File.CreateText(strFile)                                                                                                                                               ' CREATE THE FILE USING THE STREAMWRITER FUNCTIONALITY
    '    'Else
    '    '    sw = File.AppendText(strFile)                                                                                                                                               ' APPEND THE DATA RECORDS BEING READ TO THE EXISTING DATA FILE
    '    'End If

    '    Try

    '        If bondi.assembledatafile(txtLoadSymbol.Text.ToUpper(), txtStartYear.Text, txtYears.Text, txtMonths.Text, txtDays.Text) = True Then
    '            Cursor = Cursors.Default
    '            btnAssembleDataFile.Enabled = True
    '            datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)
    '            lblStatus.Text = "Backtest Records Read: " & String.Format("{0: ##,###,000}", Utils.recordsread) & " " & datastring
    '        Else
    '            lblStatus.Text = "An Error occurred!" & " " & datastring
    '        End If


    '        'Cursor = Cursors.WaitCursor
    '        'btnAssembleDataFile.Enabled = False                                                                                                                                             ' DISABLE THE CREATE DATASET BUTTON UNTIL PROCESS COMPLETED
    '        ''lblDFStatus.Text = "Working..."
    '        'lstServerResponses.Items.Clear()

    '        '' ADD CODE TO ALLOW THE USER TO SELECT THE START DATE AND CALCULATE THE LOOPS FROM THAT START DATE FORWARD.

    '        'For yr = 2 To 2
    '        '    For mnth = 0 To 0
    '        '        For dy = 0 To 1

    '        '            filedate = (2016 + yr & String.Format("{0:00}", 1 + mnth) & String.Format("{0:00}", 1 + dy))

    '        '            If (Not File.Exists(path & filedate & "\table_" & symbol & ".csv")) Then

    '        '                'Exit Sub
    '        '            Else

    '        '                Using textReader As New System.IO.StreamReader(path & filedate & "\table_" & symbol & ".csv")                                                                               ' TEXT READER READS THE CSV FILE INTO MEMORY
    '        '                    csvdata = textReader.ReadToEnd                                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING.
    '        '                    backprices = ParseBackData(csvdata)                                                                                                                                     ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.                        
    '        '                    'Stop

    '        '                    lstServerResponses.Items.Add("Date" & vbTab & vbTab & "Row" & vbTab & "Time" & vbTab & "Open" & vbTab & "High" & vbTab & "Low" & vbTab & "Close")
    '        '                    For Each price As backPrice In backprices

    '        '                        ' UNCOMMENT TO ADD DATA TO THE LIST BOX - CHANGE TO WRITE TO THE SERVER RESPONSE LISTBOX.
    '        '                        lstServerResponses.Items.Add(filedate & vbTab & price.interval & vbTab & price.MarketTime & vbTab & (String.Format("{0:C}", price.OpenPrice)) &
    '        '                                          vbTab & (String.Format("{0:C}", price.HighPrice)) & vbTab & (String.Format("{0:C}", price.LowPrice)) &
    '        '                                          vbTab & (String.Format("{0:C}", price.ClosePrice)))


    '        '                        ' JUST COMMENTED OUT 6/29/18 UNCOMMENT TO WRITE DATA TO DATAFILE
    '        '                        sw.WriteLine(filedate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," &
    '        '                                     price.interval & "," & price.OpenPrice & "," & price.HighPrice & "," &
    '        '                                     price.LowPrice & "," & price.ClosePrice)

    '        '                        recordsread += 1

    '        '                    Next
    '        '                End Using
    '        '            End If
    '        '            'Next
    '        '        Next
    '        '    Next
    '        'Next
    '        ''lblDFStatus.Text = recordsread
    '        'sw.Close()

    '    Catch Ex As Exception
    '        MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)                                                                                                ' IF THERE IS AN ERROR READING THE FILE DISPLAY THE ERROR MESSAGE
    '    Finally
    '        ' LABEL INDICATOR SHOWING THAT PROCESSING IS COMPLETE
    '    End Try

    '    ' ENABLE THE ASSEMBKE BUTTON AS THE PROCESS HAS FINISHED
    '    'datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                                                                                 ' ADD CLOSING TIME TO DATASTRING FOR THE BACKTEST PROCESS
    '    'lblStatus.Text = "Backtest Records Read: " & recordsread & " " & datastring
    'End Sub







    ' MIHIR please place all new code below this line.  Thank you!
    ' Sprint is to mirror all of the buttons on the manual panel to the code in the VB Sample from IB.

    Private Function getOptionPrice(ByVal harvestkey As String, ByVal expdate As Date, ByVal stockprice As Decimal)

        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                       ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                                ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

        Using db As BondiModel = New BondiModel()                                                                                   ' DATABASE MODEL USING ENTITY FRAMEWORK

            Dim hi = (From q In db.HarvestIndexes Where q.harvestKey = harvestkey Select q).FirstOrDefault()                        ' GET INDEX RECORD FROM THE DATABASE TO DETERMINE WHETHER WE ARE ADDING A HEDGE 

            ' CONTRACT DATA FOR EITHER STOCK OR OPTION PRICE REQUESTS
            contract.Symbol = hi.product.ToUpper()                                                                                  ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
            contract.Exchange = hi.exchange.ToUpper()                                                                               ' INITIALIZE THE EXCHANGE FOR THE CONTRACT
            contract.Currency = hi.currencytype.ToUpper()                                                                           ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT        
            contract.SecType = "OPT"
            contract.LastTradeDateOrContractMonth = String.Format("{0: yyyyMMdd}", expdate)
            contract.Strike = Int(stockprice - hi.hedgewidth)
            contract.Right = "P"

            'Stop
            'Tws1.cancelMktData(1)

            sectype = "OPT"

            tickId += 1                                                                                                                     ' INCREMENT THE TICKID 

            Tws1.reqMarketDataType(1)                                                                                                       ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
            Tws1.reqMktDataEx(tickId, contract, "", snapshot, Nothing)                                                                      ' CALL THE FUNCTION TO GET THE MARKET DATA FROM TWS VIA THE API CALL
            Tws1.tickCount = 0

            'getMarketDataTick(hi.product.ToUpper())

            'Tws1.reqMarketDataType(1)                                                                                                   ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
            'Tws1.reqMktDataEx(1, contract, "", False, Nothing)


        End Using

    End Function

    Private Function getPriceData()

        ' need to determine how to get generic ticks: 106 Implied Vol

        'Dim contract As IBApi.Contract = New IBApi.Contract()                                                                           ' ESTABLISH A NEW CONTRACT CLASS
        'contract.SecType = "STK"                                                                                                        ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        'contract.Currency = "USD"                                                                                                       ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT
        'contract.Exchange = "SMART"                                                                                                     ' INITIALIZE EXCHANGE USED FOR THE CONTRACT
        'contract.Symbol = "VXX"

        'Tws1.reqMarketDataType(1)                                                                                                       ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        'Tws1.reqMktDataEx(tickId + 1, contract, "", False, Nothing)                                                                      ' CALLS REQUEST FOR MARKET DATA(ID#, CONTRACT DETAILS, SNAPSHOT T/F, 

        'Tws1.tickCount = 0

    End Function










    Private Sub btnCloseHarvest_Click(sender As Object, e As EventArgs)
        pnlHarvesting.Visible = False
        pnlBacktest.Visible = False
        pnlMan.Visible = False
    End Sub

    Private Sub btnHarvesting_Click(sender As Object, e As EventArgs) Handles btnHarvesting.Click
        pnlHarvesting.Visible = True
        pnlBacktest.Visible = False
        pnlMan.Visible = False
    End Sub





    Private Sub btnGetTWStime_Click(sender As Object, e As EventArgs)
        'Tws1.currentTime()
    End Sub

    Private Sub btnOpPrice_Click_1(sender As Object, e As EventArgs) Handles btnOpPrice.Click
        'Stop
        sectype = "OPT"

        'Tws1.cancelMktData(1)
        'lstServerResponses.Items.Clear()
        pricetype = 2
        Dim contract As IBApi.Contract = New IBApi.Contract()

        ' CONTRACT DATA FOR EITHER STOCK OR OPTION PRICE REQUESTS
        contract.Symbol = "VXX"                                                                                                     ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
        contract.Exchange = "SMART"                                                                                                 ' INITIALIZE THE EXCHANGE FOR THE CONTRACT
        contract.Currency = "USD"                                                                                                   ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT        

        getHedgeData(harvestkey)
        Dim calcexpdate As Date = String.Format("{0: MM/dd/yy}", calcExpirationDate(harvestkey, Now()))                             ' IF A HEDGE IS NEEDED CALCULATE THE EXPIRATION DATE TARGET TO BE USED IN THE BLACK SCHOLES CALCULATION

        ' OPTION CONTRACT DATA FOR PRICE REQUEST
        contract.SecType = "OPT"
        contract.LastTradeDateOrContractMonth = String.Format("{0: yyyyMMdd}", calcexpdate)
        contract.Strike = 38
        contract.Right = "P"

        ' Set all the global variables for reporting to the user
        optionsymbol = contract.Symbol
        optionexpirationdate = String.Format("{0: yyyyMMdd}", calcexpdate)
        optionstrike = contract.Strike

        Tws1.reqMarketDataType(1)                                                                                                   ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(tickId + 1, contract, "", True, Nothing)

        'Stop
    End Sub

    Private Sub btnTickPrice_Click_1(sender As Object, e As EventArgs) Handles btnTickPrice.Click

        'Stop

        Dim contract As IBApi.Contract = New IBApi.Contract()

        ' CONTRACT DATA FOR EITHER STOCK OR OPTION PRICE REQUESTS
        contract.Symbol = "VXX"                                                                                                     ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
        contract.Exchange = "SMART"                                                                                                 ' INITIALIZE THE EXCHANGE FOR THE CONTRACT
        contract.Currency = "USD"                                                                                                   ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT        

        ' STOCK CONTRACT DATA FOR REQUEST OF PRICE
        contract.SecType = "STK"                                                                                                    ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT

        ' OPTION CONTRACT DATA FOR PRICE REQUEST
        'contract.SecType = "OPT"
        'contract.Currency = "USD"
        'contract.LastTradeDateOrContractMonth = 20180921
        'contract.Strike = 27
        'contract.Right = "P"

        Tws1.reqMarketDataType(1)                                                                                                   ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(1, contract, "", True, Nothing)

        'Stop
    End Sub

    Private Sub btnReqMktDepth_Click(sender As Object, e As EventArgs)
        'Stop

        Dim contract As IBApi.Contract = New IBApi.Contract()

        ' CONTRACT DATA FOR EITHER STOCK OR OPTION PRICE REQUESTS
        contract.Symbol = "VXX"                                                                                                     ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
        contract.Exchange = "SMART"                                                                                                 ' INITIALIZE THE EXCHANGE FOR THE CONTRACT
        contract.Currency = "USD"                                                                                                   ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT        

        ' STOCK CONTRACT DATA FOR REQUEST OF PRICE
        'contract.SecType = "STK"                                                                                                    ' INITIALIZE THE SECURITY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT

        ' OPTION CONTRACT DATA FOR PRICE REQUEST
        contract.SecType = "OPT"
        contract.Currency = "USD"
        contract.LastTradeDateOrContractMonth = 20180921
        contract.Strike = 27
        contract.Right = "P"



        'tickTypeId = 11      'txtTickId.Text
        Tws1.reqMarketDataType(1)                                                                                                   ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(1, contract, "", True, Nothing)

        'Stop
    End Sub

    Private Sub btnSendOrder_Click_1(sender As Object, e As EventArgs) Handles btnSendOrder.Click

        Dim datastring As String = "Order Sent: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "                   ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS HAPPENING WITHIN THE APP
        'Dim priceint As Double = 0                                                                                                  ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        'Dim checksum As Double = 0                                                                                                  ' VARIABLE USED TO CALCULATE THE STARTING BUY TO OPEN PRICE FOR EACH USER & INDEX
        'Dim cprice As Double = 0                                                                                                    ' VARIABLE USED TO HOLD THE STARTING OPEN TO BUY PRICE FOR EACH USER & INDEX
        Dim Symbol As String = ""                                                                                                   ' VARIABLE USED TO HOLD THE SYMBOL FOR THE USER & INDEX
        Dim opentrigger As Double = 0                                                                                               ' VARIABLE USED TO HOLD THE TRIGGER FOR THE BUY TO OPEN POSITIONS
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                       ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                                ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA


        'SendSingleOrder = True

        ' Dim userid As Guid                                                                                                          ' VARIABLE USED TO HOLD THE CURRENT USERS USERID (NEED TO DETERMINE IF I NEED TO KEEP THIS OR NOT)
        'ManualOrder = True                                                                                                         ' SET FLAG TO TRUE AS ORDER IS MANUAL - THIS WILL ADD THE ORDER DETAILS TO THE STOCKORDER TABLE
        'connecting = False                                                                                                         ' FLAG USED TO INDICATE THAT THIS CALL IS NOT DUE TO CONNECTING TO TWS
        'cntr = 1                                                                                                                   ' COUNTER FLAG USED TO ELIMINATE THE TWO CYCLES THROUGH THE ORDER PROCESSING 
        Try

            Using db As BondiModel = New BondiModel()                                                                               ' DATABASE MODEL USED TO CAPTURE THE ROBOTS DATA

                'Dim ul As List(Of User) = New List(Of User)()                                                                       ' GET THE USERID OF THE USER TO CHECK FOR ORDERS FOR THIS ID AS WELL AS THE INDEX
                'ul = db.Users.AsEnumerable.Where(Function(u) u.UserName = "boss").ToList()                                          ' BUILD THE LIST OF USERS BASED ON THIS USERNAME
                'userid = ul.FirstOrDefault().UserId                                                                                 ' SET THE USERID EQUAL TO THE USERS USERID - CONSIDER DOING THIS IN A PUBLIC VAR AT LOGIN

                'Dim so As List(Of stockorder) = New List(Of stockorder)()                                                           ' INITIALIZE THE STOCK ORDER LIST TO BE USED TO GET THE STOCK RECORD     
                'so = db.stockorders.AsEnumerable.Where(Function(s) s.roboIndex = cmbWillie.SelectedValue).ToList()                  ' BUILD THE LIST OF STOCKORDERS FOR THIS USER AND THIS INDEX (MAY NOT NEED TO DO THIS AS INDEXES ARE UNIQUE BY USER. - REFACTOR)

                ' THE ORDER COUNTER DOES NOT NEED TO BE CHECKED HERE AS AN ORDER IS BEING SENT NO MATTER WHAT
                'If so.Count = 0 Then                                                                                               ' INDICATES THAT THIS IS THE FIRST ORDER CALC OPEN PRICE AND SEND FIRST BUY TO OPEN ORDER

                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                       ' INITIALIZE THE HARVEST INDEX LIST TO BE USED TO GET THE INDEX RECORD 
                hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = harvestkey).ToList()              ' PULL THE HARVEST INDEX RECORD TO GET THE CONTRACT AND ORDER PARAMETERS

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

    Private Sub btnReqNextValidId_Click_1(sender As Object, e As EventArgs)
        Dim datastring = "Next Valid Order Id: " & nextValidOrderId & "  "                                                              ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS OCCURRING WITHIN THE APPLICAITON
        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                                 ' ADD THE TIME STAMP TO THE DATASTRING FOR THE NEXT ORDERID PRESENTED
        lblStatus.Text = datastring
    End Sub

    Private Sub btnReqNextId_Click(sender As Object, e As EventArgs) Handles btnReqNextId.Click
        Dim datastring = "Next Valid Order Id: " & nextValidOrderId & "  "                                                              ' DATASTRING USED TO PROVIDE FEEDBACK TO THE USER ON ACTIONS OCCURRING WITHIN THE APPLICAITON
        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)                                                 ' ADD THE TIME STAMP TO THE DATASTRING FOR THE NEXT ORDERID PRESENTED
        lblStatus.Text = datastring
    End Sub

    Private Sub btnGetPositions_Click(sender As Object, e As EventArgs) Handles btnGetPositions.Click
        Tws1.reqAllOpenOrders()                                                                                                                     ' GET ALL OPEN ORDERS FROM TWS
    End Sub

    Private Sub btnPlaceOrder_Click(sender As Object, e As EventArgs) Handles btnPlaceOrder.Click
        ' This sub used to work through the TWS loops 
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                       ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                                ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

        contract.Symbol = "VXX"                                                                                                     ' SET THE SYMBOL FOR THE CONTRACT TO THE INDEX SYMBOL 
        contract.SecType = "STK"                                                                                                    ' SET THE SECURITY TYPE FOR THE CONTRACT TO THE INDEX SECURITY TYPE
        contract.Currency = "USD"                                                                                                   ' SET THE CURRENCY TYPE FOR THE CONTRACT TO THE INDEX CURRENCY TYPE
        contract.Exchange = "SMART"                                                                                                 ' SET THE EXCHANGE FOR THE CONTRACT TO THE INDEX EXCHANGE            

        order.OrderType = "LMT"                                                                                                     ' SET THE ORDER TYPE FOR THE ORDER TO THE INDEX ORDER TYPE (lmt OR mkt)
        order.TotalQuantity = 1                                                                                                     ' SET THE NUMBER OF SHARES FOR THE ORDER TO THE INDEX NUMBER OF SHARES 
        order.Tif = "GTC"                                                                                                           ' SET THE TRADE IN FORCE FOR THE ORDER TO THE INDEX TRADE IN FORCE (day OR gtc)
        order.OrderId = nextValidOrderId                                                                                            ' SET THE ORDER ID OF THE ORDER TO THE NEXT VALID ORDER ID
        order.Action = "BUY"                                                                                                        ' SET THE ORDER ACTION 
        order.LmtPrice = 1.0                                                                                                       ' SET THE ORDER LIMIT PRICE TO THE CALCULATED BUY TO OPEN LIMIT PRICE

        Call Tws1.placeOrderEx(order.OrderId, contract, order)                                                                      ' CALL FUNCTION TO ADD MESSAGE TO THE LISTBOX AND PROCESS THE ORDER 

    End Sub



    Private Sub btnPlaceOptionOrder_Click(sender As Object, e As EventArgs) Handles btnPlaceOptionOrder.Click

        ' Stop

        ' This sub used to work through the TWS loops 
        Dim contract As IBApi.Contract = New IBApi.Contract()                                                                       ' INTIIATE THE CONTRACT VARIABLE CLASS TO HANDLE CONTRACT DATA
        Dim order As IBApi.Order = New IBApi.Order()                                                                                ' INITIATE THE ORDER VARIABLE CLASS TO HANDLE ORDER DATA

        sectype = "OPT"
        pricetype = 2

        ' CONTRACT DATA FOR EITHER STOCK OR OPTION PRICE REQUESTS
        contract.Symbol = "VXX"                                                                                                     ' INITIALIZE SYMBOL VALUE FOR THE CONTRACT
        contract.Exchange = "SMART"                                                                                                 ' INITIALIZE THE EXCHANGE FOR THE CONTRACT
        contract.Currency = "USD"                                                                                                   ' INITIALIZE CURRENCY TYPE FOR THE CONTRACT - MOVE TO SETTINGS AT SOME POINT        

        getHedgeData(harvestkey)
        Dim calcexpdate As Date = String.Format("{0: MM/dd/yy}", calcExpirationDate(harvestkey, Now()))                         ' IF A HEDGE IS NEEDED CALCULATE THE EXPIRATION DATE TARGET TO BE USED IN THE BLACK SCHOLES CALCULATION

        ' OPTION CONTRACT DATA FOR PRICE REQUEST
        contract.SecType = "OPT"
        contract.LastTradeDateOrContractMonth = String.Format("{0: yyyyMMdd}", calcexpdate)
        contract.Strike = 25
        contract.Right = "P"

        ' Set all the global variables for reporting to the user
        optionsymbol = contract.Symbol
        optionexpirationdate = String.Format("{0: yyyyMMdd}", calcexpdate)
        optionstrike = contract.Strike

        Tws1.reqMarketDataType(1)                                                                                                   ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
        Tws1.reqMktDataEx(1, contract, "", True, Nothing)
        Stop


    End Sub





    'Private Sub Tws1_CurrentTime(ByVal eventSender As System.Object, e As currenttimeeventargs) Handles Tws1.currentTime

    '    Dim offset = lstServerResponses.Items.Count
    '    Dim datastring = "Current Time: " & e.time

    '    m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, datastring)

    '    lstServerResponses.TopIndex = offset

    'End Sub




End Class

