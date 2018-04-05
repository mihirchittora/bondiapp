Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class vw_aspnet_WebPartState_Shared
    <Key>
    <Column(Order:=0)>
    Public Property PathId As Guid

    Public Property DataSize As Integer?

    <Key>
    <Column(Order:=1)>
    Public Property LastUpdatedDate As Date
End Class
