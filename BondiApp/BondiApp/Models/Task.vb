Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Task
    Public Property taskID As Integer

    <Column("Task")>
    <Required>
    <StringLength(500)>
    Public Property Task1 As String

    <Required>
    <StringLength(50)>
    Public Property Status As String

    Public Property dateadded As Date

    Public Property dateupdated As Date

    Public Property datecompleted As Date
End Class
