Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("backtest")>
Partial Public Class backtest
    Public Property id As Integer

    <StringLength(10)>
    Public Property month As String

    Public Property year As Integer?

    <Column(TypeName:="date")>
    Public Property marketdate As Date?

    Public Property complete As Boolean?
End Class
