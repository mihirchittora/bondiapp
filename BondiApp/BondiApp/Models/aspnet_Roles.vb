Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class aspnet_Roles
    Public Sub New()
        aspnet_Users = New HashSet(Of aspnet_Users)()
    End Sub

    Public Property ApplicationId As Guid

    <Key>
    Public Property RoleId As Guid

    <Required>
    <StringLength(256)>
    Public Property RoleName As String

    <Required>
    <StringLength(256)>
    Public Property LoweredRoleName As String

    <StringLength(256)>
    Public Property Description As String

    Public Overridable Property aspnet_Applications As aspnet_Applications

    Public Overridable Property aspnet_Users As ICollection(Of aspnet_Users)
End Class
