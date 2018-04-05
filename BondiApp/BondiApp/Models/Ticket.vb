Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Ticket
    Public Sub New()
        TicketComments = New HashSet(Of TicketComment)()
    End Sub

    Public Property ticketID As Integer

    <Required>
    <StringLength(100)>
    Public Property Type As String

    <Required>
    <StringLength(50)>
    Public Property Priority As String

    <Required>
    <StringLength(250)>
    Public Property Components As String

    <Required>
    <StringLength(50)>
    Public Property Label As String

    <Required>
    <StringLength(150)>
    Public Property Browsers As String

    <Required>
    <StringLength(50)>
    Public Property Status As String

    <Required>
    <StringLength(50)>
    Public Property FixVersions As String

    <Required>
    <StringLength(150)>
    Public Property Assignee As String

    <Required>
    <StringLength(150)>
    Public Property Reporter As String

    <Required>
    <StringLength(1000)>
    Public Property Description As String

    <Required>
    <StringLength(5)>
    Public Property TicketPrefix As String

    Public Property dateadded As Date

    Public Property dateupdated As Date

    Public Property datecompleted As Date

    Public Property duedate As Date

    Public Overridable Property TicketComments As ICollection(Of TicketComment)
End Class
