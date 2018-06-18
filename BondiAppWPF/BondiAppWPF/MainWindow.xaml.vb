

Imports IBApi
Imports BondiAppWPF.Tws
Imports BondiAppWPF

Class MainWindow
    Private _tws1 As Tws

    Public Sub New()
        MyBase.New()                                                                                                                            ' SET THE BASE TO A NEW INSTANCE
        Tws1 = New Tws()                                                                                                                      ' INITIALIZE TWS WITHIN THE APPLICATION TO A NEW INSTANCE
        InitializeComponent()                                                                                                                   ' INITIALIZE ALL COMPONENTS
    End Sub

    Friend Property Tws1 As Tws
        Get
            Return _tws1
        End Get
        Set(value As Tws)
            _tws1 = value
        End Set
    End Property

    Private Sub btnConnect_Click(sender As Object, e As RoutedEventArgs) Handles btnConnect.Click
        Try
            Tws1.connect(txtHost.Text, txtPort.Text, txtClient.Text, False, "")                                                                       ' TWS CALL TO CONNECT THE APPLICATION TO THE TWS PLATFORM USING THE API

            If Tws1.serverVersion() > 0 Then     ' WORK ON SETTING THIS IN THE CONNECTION tws PASS AND USING A GLOBAL VARIABLE TO MAKE MORE EFFICIENT   ' IF THE RESPONSE BACK IS THE SERVER VERSION THAT IS THE INDICATION THAT THE APP IS CONNECTED TO TWS
                MsgBox("Connected")
            End If
            ' SEND THE DATASTRING TO THE FORM VIEW 

        Catch ex As Exception                                                                                                                           ' IF THERE IS AN ERROR CATCH IT HERE
            ' TODO: ADD CODE HERE TO LOG THIS IN A TABLE IN THE DB.            
            MsgBox("Connection Error: " & ex.ToString())                                                                                                ' MESSAGE WHERE THE ERROR OCCURRED - IN WHICH SUB - THIS CODE MAY BE COMMENTED OUT LATER            
        End Try
    End Sub
End Class
