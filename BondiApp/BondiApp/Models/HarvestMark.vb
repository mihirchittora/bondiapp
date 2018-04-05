Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class HarvestMark
    Public Property id As Integer

    Public Property userid As Guid?

    Public Property timestamp As Date?

    <StringLength(4)>
    Public Property symbol As String

    <Column(TypeName:="money")>
    Public Property mark As Decimal?

    Public Property turns As Long?

    Public Property ctimestamp As Date?

    Public Property open As Boolean?

    <StringLength(12)>
    Public Property harvestkey As String
End Class
