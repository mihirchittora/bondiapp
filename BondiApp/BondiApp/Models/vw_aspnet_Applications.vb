Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class vw_aspnet_Applications
    <Key>
    <Column(Order:=0)>
    <StringLength(256)>
    Public Property ApplicationName As String

    <Key>
    <Column(Order:=1)>
    <StringLength(256)>
    Public Property LoweredApplicationName As String

    <Key>
    <Column(Order:=2)>
    Public Property ApplicationId As Guid

    <StringLength(256)>
    Public Property Description As String
End Class
