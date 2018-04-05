Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class aspnet_Users
    Public Sub New()
        aspnet_PersonalizationPerUser = New HashSet(Of aspnet_PersonalizationPerUser)()
        aspnet_Roles = New HashSet(Of aspnet_Roles)()
    End Sub

    Public Property ApplicationId As Guid

    <Key>
    Public Property UserId As Guid

    <Required>
    <StringLength(256)>
    Public Property UserName As String

    <Required>
    <StringLength(256)>
    Public Property LoweredUserName As String

    <StringLength(16)>
    Public Property MobileAlias As String

    Public Property IsAnonymous As Boolean

    Public Property LastActivityDate As Date

    Public Overridable Property aspnet_Applications As aspnet_Applications

    Public Overridable Property aspnet_Membership As aspnet_Membership

    Public Overridable Property aspnet_PersonalizationPerUser As ICollection(Of aspnet_PersonalizationPerUser)

    Public Overridable Property aspnet_Profile As aspnet_Profile

    Public Overridable Property aspnet_Roles As ICollection(Of aspnet_Roles)
End Class
