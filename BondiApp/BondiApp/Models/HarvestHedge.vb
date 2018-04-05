Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class HarvestHedge
    Public Property id As Integer

    <StringLength(4)>
    Public Property symbol As String

    <StringLength(1)>
    Public Property type As String

    Public Property lots As Integer?

    <Column(TypeName:="money")>
    Public Property strike As Decimal?

    <Column(TypeName:="date")>
    Public Property exp As Date?

    <Column(TypeName:="money")>
    Public Property stockatopen As Decimal?

    Public Property opendate As Date?

    <Column(TypeName:="money")>
    Public Property openprice As Decimal?

    <Column(TypeName:="money")>
    Public Property stockatclose As Decimal?

    Public Property closedate As Date?

    <Column(TypeName:="money")>
    Public Property closeprice As Decimal?

    Public Property open As Boolean?

    Public Property timestamp As Date?

    <StringLength(12)>
    Public Property harvestkey As String

    Public Property positionID As Integer?

    <Column(TypeName:="date")>
    Public Property marketdate As Date?

    <Column(TypeName:="money")>
    Public Property targetexit As Decimal?

    Public Property openrowid As Integer?

    Public Property closerowid As Integer?
End Class
