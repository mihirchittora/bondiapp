Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("productionstock")>
Partial Public Class productionstock
    Public Property id As Integer

    Public Property timestamp As Date?

    Public Property PermId As Integer?

    <StringLength(12)>
    Public Property OrderID As String

    <StringLength(4)>
    Public Property Symbol As String

    <StringLength(20)>
    Public Property Status As String
End Class
