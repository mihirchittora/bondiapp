Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class HarvestLog
    Public Property ID As Integer

    <StringLength(12)>
    Public Property harvestkey As String

    <Column(TypeName:="date")>
    Public Property marketdate As Date?

    Public Property trans As Long?

    Public Property opens As Long?

    Public Property closes As Long?

    <Column(TypeName:="money")>
    Public Property closingmark As Decimal?

    Public Property timestamp As Date?

    Public Property otimestamp As Date?

    <Column(TypeName:="money")>
    Public Property hedgeprofit As Decimal?

    <Column(TypeName:="money")>
    Public Property stockprofit As Decimal?

    <Column(TypeName:="money")>
    Public Property currentcapital As Decimal?

    <Column(TypeName:="money")>
    Public Property maxcapital As Decimal?

    Public Property sharesbought As Integer?

    Public Property sharessold As Integer?

    Public Property hedgebought As Integer?

    Public Property hedgesold As Integer?

    <Column(TypeName:="money")>
    Public Property openingmark As Decimal?
End Class
