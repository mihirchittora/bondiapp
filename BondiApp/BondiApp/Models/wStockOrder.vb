Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class wStockOrder
    Public Property id As Integer

    Public Property createdtimestamp As Date?

    Public Property userid As Guid?

    <StringLength(12)>
    Public Property keyid As String

    Public Property orderid As Integer?

    Public Property permid As Integer?

    <StringLength(4)>
    Public Property symbol As String

    Public Property orderopen As Boolean?
End Class
