Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class aspnet_Applications
    Public Sub New()
        aspnet_Membership = New HashSet(Of aspnet_Membership)()
        aspnet_Paths = New HashSet(Of aspnet_Paths)()
        aspnet_Roles = New HashSet(Of aspnet_Roles)()
        aspnet_Users = New HashSet(Of aspnet_Users)()
    End Sub

    <Required>
    <StringLength(256)>
    Public Property ApplicationName As String

    <Required>
    <StringLength(256)>
    Public Property LoweredApplicationName As String

    <Key>
    Public Property ApplicationId As Guid

    <StringLength(256)>
    Public Property Description As String

    Public Overridable Property aspnet_Membership As ICollection(Of aspnet_Membership)

    Public Overridable Property aspnet_Paths As ICollection(Of aspnet_Paths)

    Public Overridable Property aspnet_Roles As ICollection(Of aspnet_Roles)

    Public Overridable Property aspnet_Users As ICollection(Of aspnet_Users)
End Class
