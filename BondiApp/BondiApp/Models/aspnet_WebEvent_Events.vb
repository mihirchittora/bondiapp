Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class aspnet_WebEvent_Events
    <Key>
    <StringLength(32)>
    Public Property EventId As String

    Public Property EventTimeUtc As Date

    Public Property EventTime As Date

    <Required>
    <StringLength(256)>
    Public Property EventType As String

    Public Property EventSequence As Decimal

    Public Property EventOccurrence As Decimal

    Public Property EventCode As Integer

    Public Property EventDetailCode As Integer

    <StringLength(1024)>
    Public Property Message As String

    <StringLength(256)>
    Public Property ApplicationPath As String

    <StringLength(256)>
    Public Property ApplicationVirtualPath As String

    <Required>
    <StringLength(256)>
    Public Property MachineName As String

    <StringLength(1024)>
    Public Property RequestUrl As String

    <StringLength(256)>
    Public Property ExceptionType As String

    <Column(TypeName:="ntext")>
    Public Property Details As String
End Class
