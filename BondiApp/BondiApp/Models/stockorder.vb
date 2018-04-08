Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class stockorder
    Public Property id As Integer
    Public Property USERID As Integer

    Public Property timestamp As Date?

    Public Property OrderId As Integer?

    Public Property PermID As Integer?

    <StringLength(4)>
    Public Property Symbol As String

    <StringLength(4)>
    Public Property Action As String

    <StringLength(25)>
    Public Property Status As String

    <Column(TypeName:="money")>
    Public Property TickPrice As Decimal?

    <Column(TypeName:="money")>
    Public Property LimitPrice As Decimal?

    Public Property Quantity As Integer?

    <StringLength(10)>
    Public Property OrderStatus As String

    Public Property OrderTimestamp As Date?

    <StringLength(12)>
    Public Property roboIndex As String

    <StringLength(15)>
    Public Property matchID As String
End Class
