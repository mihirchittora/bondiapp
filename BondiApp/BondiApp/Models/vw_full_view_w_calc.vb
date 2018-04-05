Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class vw_full_view_w_calc
    <Key>
    <Column(Order:=0)>
    <StringLength(10)>
    Public Property Symbol As String

    <Key>
    <Column(Order:=1)>
    <StringLength(200)>
    Public Property Name As String

    <Key>
    <Column(Order:=2)>
    <StringLength(50)>
    Public Property Product As String

    <Key>
    <Column(Order:=3, TypeName:="money")>
    Public Property openprice As Decimal

    <Key>
    <Column(Order:=4, TypeName:="money")>
    Public Property highprice As Decimal

    <Key>
    <Column(Order:=5, TypeName:="money")>
    Public Property lowprice As Decimal

    <Key>
    <Column(Order:=6, TypeName:="money")>
    Public Property closeprice As Decimal

    <Key>
    <Column(Order:=7, TypeName:="money")>
    Public Property adjcloseprice As Decimal

    <Key>
    <Column(Order:=8)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property volume As Long

    <Key>
    <Column(Order:=9, TypeName:="money")>
    Public Property RangeDollars As Decimal

    <Key>
    <Column(Order:=10)>
    Public Property RangePercent As Decimal

    <Key>
    <Column(Order:=11)>
    <StringLength(50)>
    Public Property Message As String

    <Key>
    <Column(Order:=12)>
    Public Property marketdate As Date

    <Key>
    <Column(Order:=13)>
    Public Property dateadded As Date

    <Column(TypeName:="money")>
    Public Property daily_gap As Decimal?

    <Key>
    <Column(Order:=14)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property id As Integer
End Class
