Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class vw_aspnet_WebPartState_Paths
    <Key>
    <Column(Order:=0)>
    Public Property ApplicationId As Guid

    <Key>
    <Column(Order:=1)>
    Public Property PathId As Guid

    <Key>
    <Column(Order:=2)>
    <StringLength(256)>
    Public Property Path As String

    <Key>
    <Column(Order:=3)>
    <StringLength(256)>
    Public Property LoweredPath As String
End Class
