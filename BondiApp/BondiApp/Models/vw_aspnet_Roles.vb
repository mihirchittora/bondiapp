Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class vw_aspnet_Roles
    <Key>
    <Column(Order:=0)>
    Public Property ApplicationId As Guid

    <Key>
    <Column(Order:=1)>
    Public Property RoleId As Guid

    <Key>
    <Column(Order:=2)>
    <StringLength(256)>
    Public Property RoleName As String

    <Key>
    <Column(Order:=3)>
    <StringLength(256)>
    Public Property LoweredRoleName As String

    <StringLength(256)>
    Public Property Description As String
End Class
