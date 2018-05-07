'Option Strict Off
'Option Explicit On
Imports System.Threading
Imports System.Xml
Imports System.Collections.Generic
Imports System.Data
Imports System.Configuration
Imports System.IO
Imports System.Data.SqlClient

Friend Class dlgHarvestBacktest
    Inherits System.Windows.Forms.Form

    Public indexselected As String = ""                                                                                                                                                 ' ESTABLISHES THE VARIABLE TO HOLD THE INDEX SEELCTED IN THE BACKTESTING
    Public backprices As List(Of backPrice)                                                                                                                                             ' CLASS DEFINITION TO HOUSE                         
    Public filedate As String = ""                                                                                                                                                      ' ESTABLISHES THE VARIABLE TO HOLD THE FILE DATE FROM THE DATETIME SELECTOR ON THE FORM
    Public datastring As String = ""                                                                                                                                                    ' ESTABLISHES THE VARIABLE TO HOLD THE STRING TO COMMUNICATE MESSAGES BACK TO THE FORM
    Public firstprice As Double = 0                                                                                                                                                     ' ESTABLISHES THE VARIABLE TO HOLD THE FIRST TRIGGER PRICE IN THE BACKTEST (USED WHEN THERE IS NOT AN ORDER IN THE DATABASE)

    Private Sub dlgHarvestBacktest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using db As BondiModel = New BondiModel()                                                                                                                                               ' ESTABLISH CONNECTION TO THE DATABASE THROUGH THE BONDIMODEL USING ENTITY FRAMEWORK

            Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()                                                                                                                       ' ESTABLISH THE LIST TO HOUSE THE HARVEST INDEX RECORDS
            hi = db.HarvestIndexes.Where(Function(s) s.active = True).AsEnumerable.[Select](Function(x) New HarvestIndex With {.harvestKey = x.harvestKey, .name = x.name}).ToList()            ' PULL THE ACTIVE HARVEST INDEX RECORDS AND ADD THEM TO THE LIST 

            cmbWillie.DataSource = hi                                                                                                                                                           ' SET THE DROPDOWN DATASOURCE EQUAL TO THE INDEX LIST
            cmbWillie.DisplayMember = "name"                                                                                                                                                    ' DROPDOWN DISPLAYS THE NAME FIELD OF THE LIST
            cmbWillie.ValueMember = "harvestkey"                                                                                                                                                ' DROPDOWN VALUE TIED TO NAME IS THE HARVESTKEY FIELD
            cmbWillie.SelectedIndex = 0                                                                                                                                                         ' SET THE INDEX DISPLAYED AS THE FIRST ONE

        End Using                                                                                                                                                                               ' RELEASE THE CONNECTION TO THE DATABASE 

    End Sub

    Private Sub btnStartBackTest_Click(sender As Object, e As EventArgs) Handles btnStartBackTest.Click
        Dim datastring As String = "  Backtest Cycle Time: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "
        Dim csvdata As String = ""                                                                                                                                                      ' STRING TO HOLD THE DATA FROM EACH CSV FILE READ INTO MEMORY
        'Dim filedate As String = "20160104"                                                                                                                                            ' STRING TO HOLD THE FILE DATE FOR THE CSV FILE TO BE READ THIS WILL INCREMENT FROM DB
        Dim symbol As String = ""                                                                                                                                                       ' STRING TO HOLD THE SYMBOL OF THE PRODUCT BEING TESTED
        Dim priceint As Integer = 0
        Dim mark As Double = 0
        Dim currentprice As Double = 0
        Dim checksum As Double = 0
        Dim buytrigger As Double = 0
        Dim selltrigger As Double = 0
        Dim recordsread As Integer = 0
        Dim direction As Char = ""
        Dim levels As Integer = 0
        Dim buytarget As Double = 0
        Dim selltarget As Double = 0
        Dim BTO As Integer = 0
        Dim STC As Integer = 0
        Dim gap As Double = 0
        Dim trans As Double = 0

        'Dim path As String = "C:\Users\Troy Belden\Desktop\stockprices\allstocks_"                                                                                                      ' GENERIC PATH FOR READING THE CSV FILES - WILL NEED TO SET TO USER INPUT FOR PRODUCTION

        Try

            Using db As BondiModel = New BondiModel()

                ' determine if I want to pull index data or allow user to input it or both


                Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()
                hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()
                symbol = hi.FirstOrDefault().product
                buytrigger = hi.FirstOrDefault().opentrigger
                selltrigger = hi.FirstOrDefault().width


                Dim readFile As String = "C:\Users\Troy Belden\Desktop\" & txtSymbol.Text & "_StockData.txt"
                Dim strFile As String = "C:\Users\Troy Belden\Desktop\" & txtSymbol.Text & "_Output.csv"

                Dim sw As StreamWriter

                If (Not File.Exists(strFile)) Then
                    sw = File.CreateText(strFile)
                Else
                    sw = File.AppendText(strFile)
                End If

                If (Not File.Exists(strFile)) Then

                Else

                    Using textReader As New System.IO.StreamReader(readFile)                                                                                                                     ' TEXT READER READS THE CSV FILE INTO MEMORY
                        csvdata = textReader.ReadToEnd                                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING.
                        backprices = ParseBackData2(csvdata)                                                                                                                                     ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.                        
                    End Using

                End If
                lstOHLC.Items.Add("Date / Time" & vbTab & "Price" & vbTab & "Action") ' & vbTab & "B Target" & vbTab & "S Target")
                For Each price As backPrice In backprices

                    price.MarketDate = price.MarketDate.Substring(4, 2) & "/" & price.MarketDate.Substring(6, 2) & "/" & price.MarketDate.Substring(0, 4)

                    If recordsread = 0 Then

                        priceint = Int(price.OpenPrice)                                                                                                                                 ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
                        checksum = price.OpenPrice - priceint                                                                                                                           ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
                        currentprice = (Int(checksum / buytrigger) * buytrigger + priceint)                                                                                             ' CALCULATE THE NEAREST MARK PRICE TO SET THE LIMIT ORDER AGAINST                    
                        buytarget = currentprice
                        selltarget = buytarget + selltrigger * 2

                    End If

                    If price.ClosePrice > price.OpenPrice Then
                        direction = "U"
                    Else
                        direction = "D"
                    End If

                    If direction = "U" Then

                        If price.OpenPrice < buytarget Then
                            levels = Int((buytarget - price.OpenPrice) / buytrigger)
                            For l = 0 To levels
                                lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", buytarget - (buytrigger * l)) & vbTab & "B")
                                sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", buytarget - (buytrigger * l)) & "," & "B")

                                ' SAVE THE RECORD TO THE DATABASE
                                Dim newBuyOrder As New backtest With {
                                                                        .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                                        .index = hi.FirstOrDefault().harvestKey,
                                                                        .symbol = hi.FirstOrDefault().product,
                                                                        .btomarketdate = DateTime.Parse(price.MarketDate & " " & price.MarketTime).ToUniversalTime(),
                                                                        .buyprice = buytarget - (buytrigger * l),
                                                                        .open = True
                                                                        }
                                db.backtests.Add(newBuyOrder)                                                                                            ' INSERT THE NEW RECORD TO BE ADDED.
                                db.SaveChanges()                                                                                                        ' SAVE THE RECORD TO THE DATABASE

                            Next
                            buytarget = buytarget - (buytrigger * (levels + 1))
                            selltarget = buytarget + (selltrigger * 2)
                            trans = trans + levels + 1
                            levels = 0

                            'MsgBox(buytarget & " " & selltarget)
                        ElseIf price.OpenPrice > selltarget Then
                            levels = Int((price.OpenPrice - selltarget) / selltrigger)
                            For l = 0 To levels
                                'lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", selltarget + (selltrigger * l)) & vbTab & "S")
                                'sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", selltarget + (selltrigger * l)) & "," & "S")
                                currentprice = String.Format("{0:C}", (selltarget + (selltrigger * l) - buytrigger))

                                Dim stcorderupdate = (From q In db.backtests Where q.open = True And q.buyprice = currentprice Select q)                 ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED                           

                                If stcorderupdate.Count > 0 Then

                                    stcorderupdate.FirstOrDefault.open = False
                                    stcorderupdate.FirstOrDefault.stcmarketdate = DateTime.Parse(price.MarketDate & " " & price.MarketTime).ToUniversalTime()
                                    stcorderupdate.FirstOrDefault.sellprice = selltarget + (selltrigger * l)

                                    db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            

                                    lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", selltarget + (selltrigger * l)) & vbTab & "S")
                                    sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", selltarget + (selltrigger * l)) & "," & "S")

                                End If

                            Next

                            selltarget = selltarget + (selltrigger * (levels + 1))
                            buytarget = selltarget - (buytrigger * 2)
                            trans = trans + levels + 1
                            levels = 0

                            'MsgBox(buytarget & " " & selltarget)
                        End If

                        If price.LowPrice < buytarget Then
                            levels = Int((buytarget - price.LowPrice) / buytrigger)
                            For l = 0 To levels
                                lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", buytarget - (buytrigger * l)) & vbTab & "B")
                                sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", buytarget - (buytrigger * l)) & "," & "B")

                                ' SAVE THE RECORD TO THE DATABASE
                                Dim newBuyOrder As New backtest With {
                                                                        .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                                        .index = hi.FirstOrDefault().harvestKey,
                                                                        .symbol = hi.FirstOrDefault().product,
                                                                        .btomarketdate = DateTime.Parse(price.MarketDate & " " & price.MarketTime).ToUniversalTime(),
                                                                        .buyprice = buytarget - (buytrigger * l),
                                                                        .open = True
                                                                        }
                                db.backtests.Add(newBuyOrder)                                                                                            ' INSERT THE NEW RECORD TO BE ADDED.
                                db.SaveChanges()                                                                                                        ' SAVE THE RECORD TO THE DATABASE

                            Next
                            buytarget = buytarget - (buytrigger * (levels + 1))
                            selltarget = buytarget + (selltrigger * 2)
                            trans = trans + levels + 1
                            levels = 0

                            'MsgBox(buytarget & " " & selltarget)
                        End If

                        If price.HighPrice > selltarget Then
                            levels = Int((price.HighPrice - selltarget) / selltrigger)
                            For l = 0 To levels
                                'lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", selltarget + (selltrigger * l)) & vbTab & "S")
                                'sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", selltarget + (selltrigger * l)) & "," & "S")
                                currentprice = String.Format("{0:C}", (selltarget + (selltrigger * l) - buytrigger))

                                Dim stcorderupdate = (From q In db.backtests Where q.open = True And q.buyprice = currentprice Select q)                 ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED                           

                                If stcorderupdate.Count > 0 Then

                                    stcorderupdate.FirstOrDefault.open = False
                                    stcorderupdate.FirstOrDefault.stcmarketdate = DateTime.Parse(price.MarketDate & " " & price.MarketTime).ToUniversalTime()
                                    stcorderupdate.FirstOrDefault.sellprice = selltarget + (selltrigger * l)

                                    db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            

                                    lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", selltarget + (selltrigger * l)) & vbTab & "S")
                                    sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", selltarget + (selltrigger * l)) & "," & "S")

                                End If

                            Next

                            selltarget = selltarget + (selltrigger * (levels + 1))
                            buytarget = selltarget - (buytrigger * 2)
                            trans = trans + levels + 1
                            levels = 0

                            'MsgBox(buytarget & " " & selltarget)
                        End If

                        If price.ClosePrice < buytarget Then
                            levels = Int((buytarget - price.ClosePrice) / buytrigger)
                            For l = 0 To levels
                                lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", buytarget - (buytrigger * l)) & vbTab & "B")
                                sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", buytarget - (buytrigger * l)) & "," & "B")

                                ' SAVE THE RECORD TO THE DATABASE
                                Dim newBuyOrder As New backtest With {
                                                                        .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                                        .index = hi.FirstOrDefault().harvestKey,
                                                                        .symbol = hi.FirstOrDefault().product,
                                                                        .btomarketdate = DateTime.Parse(price.MarketDate & " " & price.MarketTime).ToUniversalTime(),
                                                                        .buyprice = buytarget - (buytrigger * l),
                                                                        .open = True
                                                                        }
                                db.backtests.Add(newBuyOrder)                                                                                            ' INSERT THE NEW RECORD TO BE ADDED.
                                db.SaveChanges()                                                                                                        ' SAVE THE RECORD TO THE DATABASE

                            Next
                            buytarget = buytarget - (buytrigger * (levels + 1))
                            selltarget = buytarget + (selltrigger * 2)
                            trans = trans + levels + 1
                            levels = 0

                        End If
                        'MsgBox(buytarget & " " & selltarget)

                    Else
                        If price.OpenPrice > selltarget Then
                            levels = Int((price.OpenPrice - selltarget) / selltrigger)
                            For l = 0 To levels
                                'lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", selltarget + (selltrigger * l)) & vbTab & "S")
                                'sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", selltarget + (selltrigger * l)) & "," & "S")
                                currentprice = String.Format("{0:C}", (selltarget + (selltrigger * l) - buytrigger))

                                Dim stcorderupdate = (From q In db.backtests Where q.open = True And q.buyprice = currentprice Select q)                 ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED                           

                                If stcorderupdate.Count > 0 Then

                                    stcorderupdate.FirstOrDefault.open = False
                                    stcorderupdate.FirstOrDefault.stcmarketdate = DateTime.Parse(price.MarketDate & " " & price.MarketTime).ToUniversalTime()
                                    stcorderupdate.FirstOrDefault.sellprice = selltarget + (selltrigger * l)

                                    db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            

                                    lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", selltarget + (selltrigger * l)) & vbTab & "S")
                                    sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", selltarget + (selltrigger * l)) & "," & "S")

                                End If

                            Next

                            selltarget = selltarget + (selltrigger * (levels + 1))
                            buytarget = selltarget - (buytrigger * 2)
                            'MsgBox(buytarget & " " & selltarget)
                            trans = trans + levels + 1
                            levels = 0

                        ElseIf price.OpenPrice < buytarget Then
                            levels = Int((buytarget - price.OpenPrice) / buytrigger)
                            For l = 0 To levels
                                lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", buytarget - (buytrigger * l)) & vbTab & "B")
                                sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", buytarget - (buytrigger * l)) & "," & "B")

                                ' SAVE THE RECORD TO THE DATABASE
                                Dim newBuyOrder As New backtest With {
                                                                        .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                                        .index = hi.FirstOrDefault().harvestKey,
                                                                        .symbol = hi.FirstOrDefault().product,
                                                                        .btomarketdate = DateTime.Parse(price.MarketDate & " " & price.MarketTime).ToUniversalTime(),
                                                                        .buyprice = buytarget - (buytrigger * l),
                                                                        .open = True
                                                                        }
                                db.backtests.Add(newBuyOrder)                                                                                            ' INSERT THE NEW RECORD TO BE ADDED.
                                db.SaveChanges()                                                                                                        ' SAVE THE RECORD TO THE DATABASE

                            Next
                            buytarget = buytarget - (buytrigger * (levels + 1))
                            selltarget = buytarget + (selltrigger * 2)
                            trans = trans + levels + 1
                            levels = 0

                        End If
                        ' MsgBox(buytarget & " " & selltarget)

                        If price.HighPrice > selltarget Then
                            levels = Int((price.HighPrice - selltarget) / selltrigger)
                            For l = 0 To levels
                                'lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", selltarget + (selltrigger * l)) & vbTab & "S")
                                'sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", selltarget + (selltrigger * l)) & "," & "S")
                                currentprice = String.Format("{0:C}", (selltarget + (selltrigger * l) - buytrigger))

                                Dim stcorderupdate = (From q In db.backtests Where q.open = True And q.buyprice = currentprice Select q)                 ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED                           

                                If stcorderupdate.Count > 0 Then

                                    stcorderupdate.FirstOrDefault.open = False
                                    stcorderupdate.FirstOrDefault.stcmarketdate = DateTime.Parse(price.MarketDate & " " & price.MarketTime).ToUniversalTime()
                                    stcorderupdate.FirstOrDefault.sellprice = selltarget + (selltrigger * l)

                                    db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            

                                    lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", selltarget + (selltrigger * l)) & vbTab & "S")
                                    sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", selltarget + (selltrigger * l)) & "," & "S")

                                End If

                            Next

                            selltarget = selltarget + (selltrigger * (levels + 1))
                            buytarget = selltarget - (buytrigger * 2)
                            trans = trans + levels + 1
                            levels = 0

                            'MsgBox(buytarget & " " & selltarget)
                        End If

                        If price.LowPrice < buytarget Then
                            levels = Int((buytarget - price.LowPrice) / buytrigger)
                            For l = 0 To levels
                                currentprice = buytarget - buytrigger * l
                                lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", buytarget - (buytrigger * l)) & vbTab & "B")
                                sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", buytarget - (buytrigger * l)) & "," & "B")

                                ' SAVE THE RECORD TO THE DATABASE
                                Dim newBuyOrder As New backtest With {
                                                                        .timestamp = DateTime.Parse(Now).ToUniversalTime(),
                                                                        .index = hi.FirstOrDefault().harvestKey,
                                                                        .symbol = hi.FirstOrDefault().product,
                                                                        .btomarketdate = DateTime.Parse(price.MarketDate & " " & price.MarketTime).ToUniversalTime(),
                                                                        .buyprice = buytarget - (buytrigger * l),
                                                                        .open = True
                                                                        }
                                db.backtests.Add(newBuyOrder)                                                                                            ' INSERT THE NEW RECORD TO BE ADDED.
                                db.SaveChanges()                                                                                                        ' SAVE THE RECORD TO THE DATABASE

                            Next
                            buytarget = buytarget - (buytrigger * (levels + 1))
                            selltarget = buytarget + (selltrigger * 2)
                            trans = trans + levels + 1
                            levels = 0

                            'MsgBox(buytarget & " " & selltarget)
                        End If

                        If price.ClosePrice > selltarget Then
                            levels = Int((price.ClosePrice - selltarget) / selltrigger)
                            For l = 0 To levels
                                'lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", selltarget + (selltrigger * l)) & vbTab & "S")
                                'sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", selltarget + (selltrigger * l)) & "," & "S")
                                currentprice = String.Format("{0:C}", (selltarget + (selltrigger * l) - buytrigger))

                                Dim stcorderupdate = (From q In db.backtests Where q.open = True And q.buyprice = currentprice Select q)                 ' GET RECORD FROM THE DATABASE SO IT CAN BE UPDATED                           

                                If stcorderupdate.Count > 0 Then

                                    stcorderupdate.FirstOrDefault.open = False
                                    stcorderupdate.FirstOrDefault.stcmarketdate = DateTime.Parse(price.MarketDate & " " & price.MarketTime).ToUniversalTime()
                                    stcorderupdate.FirstOrDefault.sellprice = selltarget + (selltrigger * l)

                                    db.SaveChanges()                                                                                            ' SAVE THE CHANGES TO THE DATABASE                            

                                    lstOHLC.Items.Add(price.MarketDate & " " & price.MarketTime & vbTab & String.Format("{0:C}", selltarget + (selltrigger * l)) & vbTab & "S")
                                    sw.WriteLine(price.MarketDate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & "," & String.Format("{0:C}", selltarget + (selltrigger * l)) & "," & "S")

                                End If

                            Next

                            selltarget = selltarget + (selltrigger * (levels + 1))
                            buytarget = selltarget - (buytrigger * 2)
                            trans = trans + levels + 1
                            levels = 0

                            'MsgBox(buytarget & " " & selltarget)
                        End If

                    End If

                    recordsread += 1

                    'If recordsread > 390 Then
                    '    Exit For
                    'End If

                Next

                'lblRecordsProcessed.Text = "Records Processed: " & recordsread                                                                                                   ' LABEL INDICATOR SHOWING THAT PROCESSING IS COMPLETE
                sw.Close()
            End Using

        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)                                                                                                ' IF THERE IS AN ERROR READING THE FILE DISPLAY THE ERROR MESSAGE
        Finally

        End Try

        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)
        lblStatus.Text = "Backtest Records Read: " & recordsread & " Trans: " & trans & datastring

    End Sub

    Private Sub btnReadBacktest_Click(sender As Object, e As EventArgs) Handles btnReadBacktest.Click

        Dim datastring As String = "  Backtest Cycle Time: " & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime) & " - "
        Dim csvdata As String = ""                                                                                                                                                      ' STRING TO HOLD THE DATA FROM EACH CSV FILE READ INTO MEMORY
        'Dim filedate As String = "20160104"                                                                                                                                            ' STRING TO HOLD THE FILE DATE FOR THE CSV FILE TO BE READ THIS WILL INCREMENT FROM DB
        Dim symbol As String = ""                                                                                                                                                       ' STRING TO HOLD THE SYMBOL OF THE PRODUCT BEING TESTED
        Dim priceint As Integer = 0
        Dim currentprice As Double = 0
        Dim checksum As Double = 0
        Dim opentrigger As Double = 0
        Dim recordsread As Integer = 0

        'Using db As BondiModel = New BondiModel()
        '    Dim hi As List(Of HarvestIndex) = New List(Of HarvestIndex)()
        '    hi = db.HarvestIndexes.AsEnumerable.Where(Function(x) x.harvestKey = cmbWillie.SelectedValue).ToList()
        '    symbol = hi.FirstOrDefault().product
        '    opentrigger = hi.FirstOrDefault().opentrigger
        'End Using

        symbol = txtLoadSymbol.Text


        Dim path As String = "C:\Users\Troy Belden\Desktop\stockprices\allstocks_"                                                                                                      ' GENERIC PATH FOR READING THE CSV FILES - WILL NEED TO SET TO USER INPUT FOR PRODUCTION

        Dim strFile As String = "C:\Users\Troy Belden\Desktop\" & symbol.ToUpper() & "_StockData" & ".txt"
        Dim sw As StreamWriter

        If (Not File.Exists(strFile)) Then
            sw = File.CreateText(strFile)
            'sw.WriteLine("Start Error Log for today")
        Else
            sw = File.AppendText(strFile)
        End If

        Try
            For yr = 0 To 1
                For mnth = 0 To 11
                    For dy = 0 To 30

                        filedate = (2016 + yr & String.Format("{0:00}", 1 + mnth) & String.Format("{0:00}", 1 + dy))

                        If (Not File.Exists(path & filedate & "\table_" & symbol & ".csv")) Then

                        Else

                            'For i As Integer = 0 To marketdates.Length - 1
                            'MessageBox.Show(marketdates(i))

                            Using textReader As New System.IO.StreamReader(path & filedate & "\table_" & symbol & ".csv")                                                                               ' TEXT READER READS THE CSV FILE INTO MEMORY
                                csvdata = textReader.ReadToEnd                                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING.
                                backprices = ParseBackData(csvdata)                                                                                                                                     ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.                        
                                'Stop

                                'lstOHLC.Items.Add("Row" & vbTab & "Time" & vbTab & "Open" & vbTab & "High" & vbTab & "Low" & vbTab & "Close")
                                For Each price As backPrice In backprices

                                    'If price.interval = 0 Then

                                    '    priceint = Int(price.OpenPrice)                                                                                                                                 ' RETURN THE INTERVAL OF THE STOCK TICK PRICE
                                    '    checksum = price.OpenPrice - priceint                                                                                                                           ' RETURN THE DECIMALS IN THE STOCK TICK PRICE FOR THE CALCULATIONS
                                    '    currentprice = (Int(checksum / opentrigger) * opentrigger + priceint)                                                                                           ' CALCULATE THE NEAREST MARK PRICE TO SET THE LIMIT ORDER AGAINST                    

                                    'End If

                                    'lstOHLC.Items.Add(price.interval & vbTab & price.MarketTime & vbTab & (String.Format("{0:C}", price.OpenPrice)) &
                                    '                  vbTab & (String.Format("{0:C}", price.HighPrice)) & vbTab & (String.Format("{0:C}", price.LowPrice)) &
                                    '                  vbTab & (String.Format("{0:C}", price.ClosePrice)))

                                    sw.WriteLine(filedate & "," & String.Format("{0:hh:mm}", price.MarketTime) & "," & price.interval & "," & price.OpenPrice & "," & price.HighPrice & "," & price.LowPrice &
                                                 "," & price.ClosePrice)

                                    recordsread += 1
                                Next

                                'lblRecordsProcessed.Text = "Records Processed: " & backprices.Count                                                                                                    ' LABEL INDICATOR SHOWING THAT PROCESSING IS COMPLETE
                            End Using
                        End If
                        'Next
                    Next
                Next
            Next
            sw.Close()

        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)                                                                                                ' IF THERE IS AN ERROR READING THE FILE DISPLAY THE ERROR MESSAGE
        Finally

        End Try

        datastring = datastring & String.Format("{0:hh:mm:ss.fff tt}", Now.ToLocalTime)
        lblStatus.Text = "Backtest Records Read: " & recordsread & " " & datastring

    End Sub

    Private Sub dtpBackDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpBackDate.ValueChanged
        lblStatus.Text = CDate(dtpBackDate.Value).ToString("yyyyMMdd")                                                                              ' String.Format("{0:yyyymmdd}", dtpBackDate.Value)
        filedate = lblStatus.Text
    End Sub



    Private Sub cmbWillie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWillie.SelectedIndexChanged
        indexselected = cmbWillie.SelectedValue.ToString()
    End Sub


    Private Sub btnClearList_Click(sender As Object, e As EventArgs) Handles btnClearList.Click
        lstOHLC.Items.Clear()
        'lblRecordsProcessed.Text = ""
        lblStatus.Text = ""
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Hide()
    End Sub




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

    Private Function ParseBackData2(csvData As String) As List(Of backPrice)                                                                                                             ' THIS FUNCTION WILL PARSE THE INTERVAL PRICES FROM THE CSV FILE.
        Dim rowcntr As Integer = 0                                                                                                                                                      ' INITALIZE THE ROW COUNTER.
        Dim backprices As New List(Of backPrice)()                                                                                                                                      ' INITIALIZE THE BACKPRICES LIST
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

            Dim p As New backPrice()                                                                                                                                                    ' INITIALIZE A NEW BACKPRICE 
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



End Class