Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class vw_aspnet_Profiles
    <Key>
    <Column(Order:=0)>
    Public Property UserId As Guid

    <Key>
    <Column(Order:=1)>
    Public Property LastUpdatedDate As Date

    Public Property DataSize As Integer?
End Class
