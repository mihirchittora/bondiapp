Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class TradeLog
    <Key>
    Public Property tradeID As Long

    <Column(TypeName:="date")>
    Public Property opentradeDATE As Date

    <Column(TypeName:="date")>
    Public Property addDATE As Date

    <Required>
    <StringLength(150)>
    Public Property openingTRADE As String

    <Column(TypeName:="date")>
    Public Property closetradeDATE As Date

    <Column(TypeName:="date")>
    Public Property closeDATE As Date

    <StringLength(150)>
    Public Property closingTRADE As String

    <Column(TypeName:="date")>
    Public Property expirationDATE As Date

    <Column(TypeName:="money")>
    Public Property openingAMOUNT As Decimal

    <Column(TypeName:="money")>
    Public Property closingAMOUNT As Decimal

    <StringLength(50)>
    Public Property userID As String

    Public Property status As Boolean?

    Public Property dit As Integer?

    <StringLength(12)>
    Public Property uniqueID As String
End Class
