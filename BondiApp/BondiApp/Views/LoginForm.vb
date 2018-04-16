Imports System.Text.RegularExpressions

Public Class LoginForm
    Private m_utils As New Utils
    Private mainForm As New Main

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUserId.Text.Trim.Equals("") Then
            MsgBox("Please enter email address")
            txtUserId.Focus()
            Return
        End If
        If txtPassword.Text.Trim.Equals("") Then
            MsgBox("Please enter password", True)
            txtPassword.Focus()
            Return
        End If
        Try
            Using db As BondiModel = New BondiModel()
                Dim loggedinUser = (From q In db.Memberships Where q.Email = txtUserId.Text AndAlso q.Password = txtPassword.Text Select q).FirstOrDefault()
                If (loggedinUser IsNot Nothing) Then
                    If (loggedinUser.IsApproved = True) Then
                        Me.Hide()
                        mainForm.Show()
                    Else
                        MsgBox("Your account is not approved so you cant login.")
                    End If
                Else
                    MsgBox("Invalid UserId/Password")
                End If

            End Using
        Catch ex As Exception
            MsgBox("Load Error " & ex.ToString())
        End Try
    End Sub
    Dim EmailValid As Boolean = False
    Private Sub ValidateEmail()

        Dim reEmail As Regex = New Regex("([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\." +
        ")|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})",
        RegexOptions.IgnoreCase _
        Or RegexOptions.CultureInvariant _
        Or RegexOptions.IgnorePatternWhitespace _
        Or RegexOptions.Compiled
        )

        Dim blnPossibleMatch As Boolean = reEmail.IsMatch(txtUserId.Text)

        If blnPossibleMatch Then

            If Not txtUserId.Text.Equals(reEmail.Match(txtUserId.Text).ToString) Then

                MessageBox.Show("Invalid Email Address!")

            Else

                EmailValid = True

            End If

        Else

            EmailValid = False

            MessageBox.Show("Invalid Email Address!")

            txtUserId.Clear()

            txtUserId.Focus()

        End If

    End Sub

    Private Sub txtUserId_Leave(sender As Object, e As EventArgs) Handles txtUserId.Leave
        ValidateEmail()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUserId.Focus()
        'Call m_utils.init(Me)
        'mainForm.in
    End Sub
End Class