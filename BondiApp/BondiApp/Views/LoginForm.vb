﻿Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Public Class LoginForm
    Private m_utils As New Utils
    Private mainForm As New WGB


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
                'Dim userId = Guid.Parse(txtUserId.Text.Trim())
                Dim loggedinUser = (From q In db.Memberships Where q.User.UserName = txtUserId.Text.Trim() Select q).FirstOrDefault()
                If (loggedinUser IsNot Nothing) Then
                    If (loggedinUser.User.RequiredPasswordReset = True And txtPassword.Text.Trim() = loggedinUser.User.NewPassword AndAlso loggedinUser.IsApproved = True) Then
                        Me.Hide()
                        Dim resetForm As New ResetPassword(loggedinUser.User.UserName)
                        resetForm.Show()
                        Return
                    End If



                    Dim password = EncodePassword(txtPassword.Text.Trim(), loggedinUser.PasswordFormat, loggedinUser.PasswordSalt)

                    If ((password = loggedinUser.Password Or txtPassword.Text.Trim() = loggedinUser.User.NewPassword) AndAlso loggedinUser.IsApproved = True) Then

                        Utils.username = loggedinUser.User.UserName
                        Utils.userid = loggedinUser.User.UserId

                        loggedinUser.LastLoginDate = DateTime.Parse(Now).ToUniversalTime()                                                                    ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME

                        loggedinUser.User.LastActivityDate = DateTime.Parse(Now).ToUniversalTime()                                                                 ' SET THE TIMESTAMP OF THE RECORD TO UPDATE TO THE CURRENT DATE AND TIME
                        db.SaveChanges()

                        Me.Hide()
                        mainForm.Show()
                    Else
                        MsgBox("You are not authorised to enter the application")
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

        'Dim reEmail As Regex = New Regex("([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\." +
        '")|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})",
        'RegexOptions.IgnoreCase _
        'Or RegexOptions.CultureInvariant _
        'Or RegexOptions.IgnorePatternWhitespace _
        'Or RegexOptions.Compiled
        ')

        'Dim blnPossibleMatch As Boolean = reEmail.IsMatch(txtUserId.Text)

        'If blnPossibleMatch Then

        '    If Not txtUserId.Text.Equals(reEmail.Match(txtUserId.Text).ToString) Then

        '        MessageBox.Show("Invalid Email Address!")

        '    Else

        '        EmailValid = True

        '    End If

        'Else

        '    EmailValid = False

        '    MessageBox.Show("Invalid Email Address!")

        '    txtUserId.Clear()

        '    txtUserId.Focus()

        'End If

    End Sub

    Private Sub txtUserId_Leave(sender As Object, e As EventArgs) Handles txtUserId.Leave
        'ValidateEmail()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        txtUserId.Select()
    End Sub


    Private Function EncodePassword(ByVal pass As String, ByVal passwordFormat As Integer, ByVal salt As String) As String
        If passwordFormat = 0 Then Return pass
        Dim bIn As Byte() = Encoding.Unicode.GetBytes(pass)
        Dim bSalt As Byte() = Convert.FromBase64String(salt)
        Dim bAll As Byte() = New Byte(bSalt.Length + bIn.Length - 1) {}
        Dim bRet As Byte() = Nothing
        Buffer.BlockCopy(bSalt, 0, bAll, 0, bSalt.Length)
        Buffer.BlockCopy(bIn, 0, bAll, bSalt.Length, bIn.Length)
        If passwordFormat = 1 Then
            Dim s As HashAlgorithm = HashAlgorithm.Create("SHA1")
            bRet = s.ComputeHash(bAll)
        End If

        Return Convert.ToBase64String(bRet)
    End Function


    Private Function generatePassword() As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 8
            Dim idx As Integer = r.Next(0, 35)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function

    Private Sub sendMail(member As Membership)
        Dim mail As New MailMessage()
        Dim SmtpServer As New SmtpClient("smtp.gmail.com")
        mail.From = New MailAddress("bondinotifications@gmail.com")
        mail.[To].Add(member.Email)
        mail.Subject = "Bondi App Temporary Password"
        mail.Body = member.User.NewPassword
        SmtpServer.Port = 587
        SmtpServer.UseDefaultCredentials = True
        SmtpServer.Credentials = New System.Net.NetworkCredential("bondinotifications@gmail.com", "Roswell1!")
        SmtpServer.EnableSsl = True
        SmtpServer.Send(mail)
    End Sub


    Private Sub txtForgot_Click(sender As Object, e As EventArgs) Handles txtForgot.Click
        If txtUserId.Text.Trim.Equals("") Then
            MsgBox("Please enter User Id")
            txtUserId.Focus()
            Return
        End If

        Try
            Using db As BondiModel = New BondiModel()
                Dim loggedinUser = (From q In db.Memberships Where q.User.UserName = txtUserId.Text.Trim() Select q).FirstOrDefault()
                If (loggedinUser IsNot Nothing) Then
                    If (loggedinUser.IsApproved = True) Then
                        loggedinUser.User.NewPassword = generatePassword()
                        loggedinUser.User.RequiredPasswordReset = True
                        sendMail(loggedinUser)

                        db.SaveChanges()

                        MsgBox("Mail has been sent to your registered email address containg your temporary password.")
                    Else
                        MsgBox("You are not authorised to enter the application")
                    End If
                Else
                    MsgBox("Invalid UserId/Password")
                End If

            End Using
        Catch ex As Exception
            MsgBox("Load Error " & ex.ToString())
        End Try
    End Sub
End Class