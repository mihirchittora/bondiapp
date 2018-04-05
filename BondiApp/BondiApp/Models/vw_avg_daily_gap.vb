Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class vw_avg_daily_gap
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

    <Column(TypeName:="money")>
    Public Property ten_day_range As Decimal?

    <Column(TypeName:="money")>
    Public Property fifty_day_range As Decimal?

    <Column(TypeName:="money")>
    Public Property one_hundred_day_range As Decimal?

    <Column(TypeName:="money")>
    Public Property three_hundred_day_range As Decimal?
End Class
