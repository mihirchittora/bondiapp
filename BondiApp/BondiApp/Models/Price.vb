Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Price
    Public Property id As Integer

    Public Property timestamp As Date

    Public Property dateandtime As Date

    Public Property interval As Integer

    <Required>
    <StringLength(4)>
    Public Property symbol As String

    <Column(TypeName:="money")>
    Public Property open As Decimal

    <Column(TypeName:="money")>
    Public Property high As Decimal

    <Column(TypeName:="money")>
    Public Property low As Decimal

    <Column(TypeName:="money")>
    Public Property close As Decimal

    Public Property volume As Long

    <Column("date", TypeName:="date")>
    Public Property _date As Date?
End Class
