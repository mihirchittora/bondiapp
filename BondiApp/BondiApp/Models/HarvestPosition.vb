Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class HarvestPosition
    Public Property id As Integer

    <StringLength(4)>
    Public Property symbol As String

    Public Property shares As Integer?

    Public Property opendate As Date?

    <Column(TypeName:="money")>
    Public Property openprice As Decimal?

    Public Property hedge As Boolean?

    <Column(TypeName:="money")>
    Public Property strike As Decimal?

    Public Property closedate As Date?

    <Column(TypeName:="money")>
    Public Property closeprice As Decimal?

    Public Property timestamp As Date?

    Public Property open As Boolean?

    <StringLength(1)>
    Public Property openflag As String

    <StringLength(1)>
    Public Property closeflag As String

    <StringLength(12)>
    Public Property harvestkey As String

    Public Property hedgeid As Integer?

    Public Property openrowid As Integer?

    Public Property closerowid As Integer?
End Class
