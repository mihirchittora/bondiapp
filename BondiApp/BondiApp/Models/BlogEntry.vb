Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class BlogEntry
    Public Property id As Integer

    Public Property DatePublished As Date

    <Column("Date Modified")>
    Public Property Date_Modified As Date

    <Required>
    <StringLength(100)>
    Public Property Author As String

    <Required>
    <StringLength(500)>
    Public Property Name As String

    <Required>
    <StringLength(500)>
    Public Property Title As String

    <Required>
    Public Property Description As String

    <Required>
    Public Property Text As String

    Public Property Active As Boolean
End Class
