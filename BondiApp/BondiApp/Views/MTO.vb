﻿Public Class MTO
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "0123456789"
            If Not allowedChars.Contains(e.KeyChar) Then
                If Asc(e.KeyChar) = 46 Then
                    If (TextBox3.Text.Contains(".")) Then
                        e.KeyChar = ChrW(0)
                        e.Handled = True
                    End If
                Else
                    e.KeyChar = ChrW(0)
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyz"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "0123456789"
            If Not allowedChars.Contains(e.KeyChar) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub MTO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UtcToLocalOffset(DateTime.UtcNow)
    End Sub

    Sub UtcToLocalOffset(utcdatetime As DateTime)
        Dim dateTime As DateTime = utcdatetime
        Dim zone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.Id)
        Dim utcOffset = New DateTimeOffset(dateTime, TimeSpan.Zero)
        lblUtcToLocal.Text = (utcOffset.ToOffset(zone.GetUtcOffset(utcOffset))).LocalDateTime
    End Sub
End Class