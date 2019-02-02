Public Class ResetPassword
    Dim xLoggedinUser As String
    Private m_utils As New Utils
    Private mainForm As New WGB
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Using db As BondiModel = New BondiModel()
            If (txtPassword.Text = txtConfirmPassword.Text) Then
                Dim loggedinUser = (From q In db.Memberships Where q.User.UserName = xLoggedinUser Select q).FirstOrDefault()
                loggedinUser.User.RequiredPasswordReset = False
                loggedinUser.User.NewPassword = txtConfirmPassword.Text

                Utils.username = loggedinUser.User.UserName
                Utils.userid = loggedinUser.User.UserId

                loggedinUser.LastLoginDate = DateTime.Parse(Now).ToUniversalTime()                                                                    ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                loggedinUser.User.LastActivityDate = DateTime.Parse(Now).ToUniversalTime()                                                                 ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME
                db.SaveChanges()

                Me.Hide()
                mainForm.Show()
            Else
                MsgBox("New Password and Confirm password do not match. Please try again.")
            End If
        End Using

    End Sub

    Public Sub New(ByVal loggedinUser As String)
        InitializeComponent()
        xLoggedinUser = loggedinUser
    End Sub
End Class