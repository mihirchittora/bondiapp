Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Pricing
    Public Property id As Integer

    Public Property symbolID As Integer

    <Column(TypeName:="money")>
    Public Property openprice As Decimal

    <Column(TypeName:="money")>
    Public Property highprice As Decimal

    <Column(TypeName:="money")>
    Public Property lowprice As Decimal

    <Column(TypeName:="money")>
    Public Property closeprice As Decimal

    <Column(TypeName:="money")>
    Public Property adjcloseprice As Decimal

    Public Property volume As Long

    <Column(TypeName:="money")>
    Public Property RangeDollars As Decimal

    Public Property RangePercent As Decimal

    <Required>
    <StringLength(50)>
    Public Property Message As String

    Public Property marketdate As Date

    Public Property dateadded As Date

    <Column(TypeName:="money")>
    Public Property changedollars As Decimal?

    Public Property ChangePercent As Decimal?

    <Column(TypeName:="money")>
    Public Property GapDollars As Decimal?

    Public Property GapPercent As Decimal?

    Public Property AvgRange10Day As Decimal?

    Public Property AvgRange50Day As Decimal?

    Public Property AvgRange100Day As Decimal?

    Public Property AvgRange300Day As Decimal?

    Public Property AvgChange10Day As Decimal?

    Public Property AvgChange50Day As Decimal?

    Public Property AvgChange100Day As Decimal?

    Public Property AvgChange300Day As Decimal?

    Public Property RangePrctLast10 As Decimal?

    Public Property RangePrctlast50 As Decimal?

    Public Property RangePrctLast100 As Decimal?

    Public Property RangePrctLast300 As Decimal?

    Public Property ChangePrctLast10 As Decimal?

    Public Property ChangePrctLast50 As Decimal?

    Public Property ChangePrctLast100 As Decimal?

    Public Property ChangePrctLast300 As Decimal?

    <Column(TypeName:="money")>
    Public Property StrikeWidth As Decimal?

    Public Property StrikeToPrice As Decimal?
End Class
