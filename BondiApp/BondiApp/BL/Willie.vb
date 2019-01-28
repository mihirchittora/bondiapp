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
Imports IBApi
Imports BondiApp.Tws


Friend Class Willie
    Public Shared buyorderopen As Boolean = False
    Public Shared activeuserid As String = ""
    Private m_utils As New Utils                                                                                                                        ' CREATES A NEW INSTANCE OF UTILS TO BE USED IN THIS FORM 


    Public WithEvents Tws1 As Tws

    Public Sub twsconnect(ByVal host As String, ByVal port As String, ByVal clientid As String)
        'Stop
        'Try
        '    Dim msg As String = ""                                                                                                                      ' VARIABLE USED TO SUPPLY DATA TO THE LISTBOX DETERMINE IF I WANT TO KEEP THIS VAR NAME.

        '    Call Tws1.connect(host, port, clientid, False, "")                                                                                               ' TWS CALL TO CONNECT THE APPLICATION TO THE TWS PLATFORM USING THE API

        '    If Tws1.serverVersion() > 0 Then     ' WORK ON SETTING THIS IN THE CONNECTION tws PASS AND USING A GLOBAL VARIABLE TO MAKE MORE EFFICIENT   ' IF THE RESPONSE BACK IS THE SERVER VERSION THAT IS THE INDICATION THAT THE APP IS CONNECTED TO TWS
        '        msg = "CONNECTING - ClientID: " & clientid & " SV: " & Tws1.serverVersion() & " at " & Tws1.TwsConnectionTime()                         ' SET THE MSG TO THE CONNECTION STRING AND TIME OF CONNECTION
        '        Call m_utils.addListItem(Utils.List_Types.SERVER_RESPONSES, msg)                                                                        ' CALL THE ADD LIST ITEM FUNCTION TO ADD THE MESSAGE TO THE LISTBOX                 
        '        '    'Call m_utils.addListItem(Utils.List_Types.CONNECTION_RESPONSES, "------------------------------")                                 ' CALL THE ADD A BLANK LINE TO THE MESSAGE TO THE LISTBOX 
        '    End If

        'Catch ex As Exception

        'End Try



    End Sub

    Public Sub getprice()




    End Sub



End Class


Public Class Harvest

End Class
