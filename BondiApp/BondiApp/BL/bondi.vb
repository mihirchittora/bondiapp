' Copyright (C) 2018 Dream Big Capital LLC. All rights reserved. This code is subject to the terms
' and conditions of the Dream Big LLC User Agreement and all subsequent terms.

Option Strict Off
Option Explicit On

Imports System.Threading
Imports System.Xml
Imports System.Collections.Generic
Imports System.Data
Imports System.Configuration
Imports System.IO
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class buildfile

    Public Shared Function testme(ByVal harvestkey As String)

        MsgBox(harvestkey)

    End Function



    Public Shared Function assembledatafile(ByVal symbol As String, ByVal startyear As Integer, ByVal years As Integer, ByVal months As Integer, ByVal days As Integer) As Boolean

        ' This called function reads the CSV datafile and assembles it into a datafile used by the backtesting process.  The function removes non-needed time intervals and formats the data appropriately.

        Try
            Dim backprices As List(Of backPrice)                                                                                                                                            ' CLASS DEFINITION TO HOUSE BACKPRICES FROM CSV FILES 
            Dim csvdata As String = ""                                                                                                                                                      ' STRING TO HOLD THE DATA FROM EACH CSV FILE READ INTO MEMORY
            Dim filedate As String = ""                                                                                                                                                     ' ESTABLISHES THE VARIABLE TO HOLD THE FILE DATE FROM THE DATETIME SELECTOR ON THE FORM

            ' WILL NEED TO HANLDE TWO TYPES OF FILES HERE: 1. QUANTQUOTE FILE FORMAT AND THE DREAMBIG FILE FORMAT PULLED FROM GOOGLE FINANCE.

            Dim path As String = "C:\Users\Troy Belden\Desktop\stockprices\allstocks_"                                                                                                      ' GENERIC PATH FOR READING THE QUANTQUOTE CSV FILES - WILL NEED TO SET TO USER INPUT FOR PRODUCTION

            Dim strFile As String = "C:\Users\Troy Belden\Desktop\" & symbol.ToUpper() & "_StockData" & ".txt"                                                                              ' PATH FOR THE OUTPUT ASSEMBLED DATA FILE
            Dim sw As StreamWriter                                                                                                                                                          ' DEFINE THE STREAMWRITER FOR FILE ASSEMBLY

            If (Not File.Exists(strFile)) Then                                                                                                                                              ' CHECKS TO SEE IF THE FILE ALREADY EXISTS - IF NOT IT CREATES THE FILE IF IT DOES IT APPENDS TO THE FILE
                sw = File.CreateText(strFile)                                                                                                                                               ' CREATE THE FILE USING THE STREAMWRITER FUNCTIONALITY
            Else
                sw = File.AppendText(strFile)                                                                                                                                               ' APPEND THE DATA RECORDS BEING READ TO THE EXISTING DATA FILE
            End If

            Main.Cursor = Cursors.WaitCursor
            Main.btnAssembleDataFile.Enabled = False                                                                                                                                             ' DISABLE THE CREATE DATASET BUTTON UNTIL PROCESS COMPLETED
            'lblDFStatus.Text = "Working..."
            Main.lstServerResponses.Items.Clear()

            For yr = 0 To years - 1
                For mnth = 0 To months - 1
                    For dy = 0 To days - 1

                        filedate = (startyear + yr & String.Format("{0:00}", 1 + mnth) & String.Format("{0:00}", 1 + dy))

                        If (Not File.Exists(path & filedate & "\table_" & symbol & ".csv")) Then

                            'Exit Sub
                        Else

                            Using textReader As New System.IO.StreamReader(path & filedate & "\table_" & symbol & ".csv")                                                                               ' TEXT READER READS THE CSV FILE INTO MEMORY
                                csvdata = textReader.ReadToEnd                                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING.
                                backprices = buildfile.ParseBackData(csvdata)                                                                                                                                     ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.                        
                                'Stop

                                Main.lstServerResponses.Items.Add("Date" & vbTab & vbTab & "Row" & vbTab & "Time" & vbTab & "Open" & vbTab & "High" & vbTab & "Low" & vbTab & "Close")
                                For Each price As backPrice In backprices

                                    ' UNCOMMENT TO ADD DATA TO THE LIST BOX - CHANGE TO WRITE TO THE SERVER RESPONSE LISTBOX.
                                    Main.lstServerResponses.Items.Add(filedate & vbTab & price.interval & vbTab & price.MarketTime & vbTab & (String.Format("{0:C}", price.OpenPrice)) &
                                                      vbTab & (String.Format("{0:C}", price.HighPrice)) & vbTab & (String.Format("{0:C}", price.LowPrice)) &
                                                      vbTab & (String.Format("{0:C}", price.ClosePrice)))


                                    ' JUST COMMENTED OUT 6/29/18 UNCOMMENT TO WRITE DATA TO DATAFILE
                                    sw.WriteLine(filedate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," &
                                                 price.interval & "," & price.OpenPrice & "," & price.HighPrice & "," &
                                                 price.LowPrice & "," & price.ClosePrice)

                                    Utils.recordsread += 1

                                Next
                            End Using
                        End If
                        'Next
                    Next
                Next
            Next
            'lblDFStatus.Text = recordsread
            sw.Close()

            assembledatafile = True
        Catch ex As Exception
            assembledatafile = False
        End Try

        'Return assembledatafile()

    End Function

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

    Public Shared Function ParseBackData(csvData As String) As List(Of backPrice)                                                                                                             ' THIS FUNCTION WILL PARSE THE INTERVAL PRICES FROM THE CSV FILE.
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

End Class

Public Class bcktst

    Public Shared Function Putprice(ByVal stockprice As Double, ByVal strike As Double, ByVal startdate As Date, ByVal enddate As Date, ByVal iv As Double) As Decimal

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
        Putprice = ws.Range("h6").Value

        'MsgBox("Black Scholes Call Price: " & String.Format("{0:C}", callprice))
        'MsgBox("Black Scholes Put Price: " & String.Format("{0:C}", putprice))

        ws = Nothing
        wb.Close(False)
        wb = Nothing

        excel.Quit()
        excel = Nothing

        Return Putprice

    End Function

End Class