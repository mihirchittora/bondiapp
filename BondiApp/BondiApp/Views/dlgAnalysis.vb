Imports System.IO
Public Class dlgAnalysis

    Public backprices As List(Of backPrice)                                                                                                     ' CLASS DEFINITION TO HOUSE BACKPRICES FROM CSV FILES 

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        'm_ok = False
        Close()
    End Sub

    Private Sub btnGetFile_Click(sender As Object, e As EventArgs) Handles btnGetFile.Click

        Dim openFileDialog1 As New OpenFileDialog()
        Dim path As String = ""
        Dim csvdata As String = ""
        Dim rowcounter As Integer = 0


        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try

                path = openFileDialog1.FileName
                Using textReader As New System.IO.StreamReader(path)                                                                                                        ' TEXT READER READS THE CSV FILE INTO MEMORY
                    csvdata = textReader.ReadToEnd                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING.
                    backprices = ParseBackData(csvdata)                                                                                                                     ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.                        
                    lblstatus.Text = lblstatus.Text & " " & backprices.Count                                                                                                ' LABEL INDICATOR SHOWING THAT PROCESSING IS COMPLETE
                End Using

                For Each price In backprices


                    rowcounter += 1
                Next
                Stop
                'MsgBox()


                'If (myStream IsNot Nothing) Then
                '    MsgBox(myStream)
                '    ' Insert code to read the stream here.
                'End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (path IsNot Nothing) Then
                    'myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Function ParseBackData(csvData As String) As List(Of backPrice)                                                                                                             ' THIS FUNCTION WILL PARSE THE INTERVAL PRICES FROM THE CSV FILE.
        Dim rowcntr As Integer = 0                                                                                                                                                      ' INITALIZE THE ROW COUNTER.
        Dim backprices As New List(Of backPrice)()                                                                                                                                      ' INITIALIZE THE BACKPRICES LIST
        Dim statistics As New List(Of Stats)()
        Dim range As Double = 0
        Dim upday As Integer = 0
        'Dim marketdatetime As DateTime                                                                                                                                                  ' INITIALIZE THE MARKET DATE BEING PROCESSED    
        Dim last300 As Integer = 0



        Dim rows As String() = csvData.Replace(vbCr, "").Split(ControlChars.Lf)                                                                                                         ' LOADS EACH LINE INTO ROWS TO BE PARSED

        last300 = (rows.Count - 301)
        'Stop

        For Each row As String In rows                                                                                                                                                  ' ROW LOOPS

            If String.IsNullOrEmpty(row) Then                                                                                                                                           ' IF THE LINE IS NULL OR EMPTY MOVE TO NEXT ROW
                Continue For                                                                                                                                                            ' MOVE FORWARD IN THE LOOP
            End If

            If rowcntr > 0 Then
                If rowcntr >= last300 Then
                    Dim cols As String() = row.Split(","c)                                                                                                                                      ' SPLIT ROWS INTO FIELDS BASED ON , 

                    'If cols(0) = "Date" Then                                                                                                                                                    ' CHECK FOR THE DATE ROW. USED IN YAHOO FINANCE
                    '    Continue For
                    'End If

                    Dim p As New backPrice()                                                                                                                                                    ' INITIALIZE A NEW BACKPRICE 
                    Dim s As New Stats()
                    p.BPRow = rowcntr
                    'p.MarketDate = cols(0).Substring(4, 2) & "/" & cols(0).Substring(6, 2) & "/" & cols(0).Substring(0, 4)                                                                      ' SET COLUMN 0 TO MARKET DATE
                    'If Len(cols(1)) < 4 Then
                    '    p.MarketTime = cols(1).Substring(0, 1) & ":" & cols(1).Substring(1, 2)                                                                                                  ' SET COLUMN 1 TO MARKET TIME
                    'ElseIf Len(cols(1)) = 4 Then
                    '    p.MarketTime = cols(1).Substring(0, 2) & ":" & cols(1).Substring(2, 2)                                                                                                  ' SET COLUMN 1 TO MARKET TIME                
                    'End If

                    p.OpenPrice = Convert.ToDecimal(cols(1))                                                                                                                                    ' SET COLUMN 2 TO OPEN PRICE    
                    p.HighPrice = Convert.ToDecimal(cols(2))                                                                                                                                    ' SET COLUMN 3 TO HIGH PRICE
                    p.LowPrice = Convert.ToDecimal(cols(3))                                                                                                                                     ' SET COLUMN 4 TO LOW PRICE
                    p.ClosePrice = Convert.ToDecimal(cols(4))                                                                                                                                   ' SET COLUMN 5 TO CLOSE PRICE            
                    p.Volume = Convert.ToDouble(cols(6))
                    'marketdatetime = p.MarketDate & " " & p.MarketTime

                    'If p.ClosePrice > p.OpenPrice Then
                    '    s.updays = s.updays + 1
                    'Else
                    '    s.downdays = s.downdays + 1
                    'End If
                    'range = s.range300 = 
                    ' ONLY ADD ROWS WHERE THE MARKET IS OPEN.
                    'If marketdatetime.ToShortTimeString() > #9:29:00 AM# Then                                                                                                                   ' CHECK IF MARKET TIME IS AFTER MARKET OPENS                
                    '    If marketdatetime.ToShortTimeString() < #4:01:00 PM# Then                                                                                                               ' CHECK IF MARKET TIME IS BEFORE MARKET CLOSES CHANGE BACK TO 4:01:00 PM                    
                    '        p.interval = rowcntr                                                                                                                                                ' SET INTERVAL FIELD IN PRICE TO CURRENT ROW

                    'Stop
                    backprices.Add(p)                                                                                                                                                   ' ADD P TO BACKPRICES
                    'statistics.Add(s)
                End If
            End If
                rowcntr = rowcntr + 1                                                                                                                                                       ' INCREMENT THE ROW COUNTER
        Next

        Return backprices                                                                                                                                                               ' RETURN TO CALLING FUNCTION WITH BACKPRICES MODEL POPULATED
    End Function

    Public Class backPrice

        Private m_row As Integer
        Public Property BPRow As Integer
            Get
                Return m_row
            End Get
            Set(value As Integer)
                m_row = value
            End Set
        End Property

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

    Public Class Stats

        Private m_updays As Integer
        Public Property updays As Integer
            Get
                Return m_updays
            End Get
            Set(value As Integer)
                m_updays = value
            End Set
        End Property

        Private m_downdays As Integer
        Public Property downdays As Integer
            Get
                Return m_downdays
            End Get
            Set(value As Integer)
                m_downdays = value
            End Set
        End Property


        Private m_range300 As Integer
        Public Property range300 As Integer
            Get
                Return m_range300
            End Get
            Set(value As Integer)
                m_range300 = value
            End Set
        End Property

    End Class

End Class