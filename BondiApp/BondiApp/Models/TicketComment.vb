Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class TicketComment
    <Key>
    Public Property commentID As Integer

    Public Property ticketID As Integer

    <Required>
    <StringLength(50)>
    Public Property userID As String

    <Required>
    <StringLength(500)>
    Public Property comment As String

    Public Property timestamp As Date

    Public Overridable Property Ticket As Ticket
End Class
