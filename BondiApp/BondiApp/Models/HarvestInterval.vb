Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class HarvestInterval
    Public Property ID As Integer

    <Column("Date")>
    Public Property _Date As Date

    Public Property Interval As Integer

    <Column(TypeName:="money")>
    Public Property OpenPrice As Decimal

    <Column(TypeName:="money")>
    Public Property HighPrice As Decimal

    <Column(TypeName:="money")>
    Public Property LowPrice As Decimal

    <Column(TypeName:="money")>
    Public Property ClosePrice As Decimal

    Public Property Volume As Long

    <Required>
    <StringLength(4)>
    Public Property symbol As String

    Public Property timestamp As Date?
End Class
