Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class vw_Pricings_DESC
    <Key>
    <Column(Order:=0)>
    Public Property id As Integer

    <Key>
    <Column(Order:=1)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property symbolID As Integer

    <Key>
    <Column(Order:=2, TypeName:="money")>
    Public Property openprice As Decimal

    <Key>
    <Column(Order:=3, TypeName:="money")>
    Public Property highprice As Decimal

    <Key>
    <Column(Order:=4, TypeName:="money")>
    Public Property lowprice As Decimal

    <Key>
    <Column(Order:=5, TypeName:="money")>
    Public Property closeprice As Decimal

    <Key>
    <Column(Order:=6, TypeName:="money")>
    Public Property adjcloseprice As Decimal

    <Key>
    <Column(Order:=7)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property volume As Long

    <Key>
    <Column(Order:=8, TypeName:="money")>
    Public Property RangeDollars As Decimal

    <Key>
    <Column(Order:=9)>
    Public Property RangePercent As Decimal

    <Key>
    <Column(Order:=10)>
    <StringLength(50)>
    Public Property Message As String

    <Key>
    <Column(Order:=11)>
    Public Property marketdate As Date

    <Key>
    <Column(Order:=12)>
    Public Property dateadded As Date
End Class
