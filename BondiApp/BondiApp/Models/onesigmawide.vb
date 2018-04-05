Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("onesigmawide")>
Partial Public Class onesigmawide
    <Key>
    Public Property recordId As Integer

    Public Property CreateDate As Date

    Public Property UpdateDate As Date

    Public Property EntryDate As Date

    <Required>
    <StringLength(4)>
    Public Property Symbol As String

    <Required>
    <StringLength(1)>
    Public Property Position As String

    <Column(TypeName:="money")>
    Public Property StockPrice As Decimal

    Public Property IVPercentile As Decimal

    Public Property ExpirationDate As Date

    Public Property NumberLots As Integer

    <Column(TypeName:="money")>
    Public Property ShortStrike As Decimal

    Public Property PITM As Decimal

    <Column(TypeName:="money")>
    Public Property OpeningCredit As Decimal

    <Column(TypeName:="money")>
    Public Property LongStrike As Decimal

    <Column(TypeName:="money")>
    Public Property OpeningDebit As Decimal

    <Required>
    <StringLength(8)>
    Public Property Status As String

    <Column(TypeName:="money")>
    Public Property ClosingDebit As Decimal

    <Column(TypeName:="money")>
    Public Property ClosingCredit As Decimal

    <Required>
    <StringLength(50)>
    Public Property Account As String

    Public Property MaxProfitTarget As Decimal

    Public Property ExitDate As Date?

    <StringLength(1500)>
    Public Property Notes As String
End Class
