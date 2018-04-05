Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class aspnet_Paths
    Public Sub New()
        aspnet_PersonalizationPerUser = New HashSet(Of aspnet_PersonalizationPerUser)()
    End Sub

    Public Property ApplicationId As Guid

    <Key>
    Public Property PathId As Guid

    <Required>
    <StringLength(256)>
    Public Property Path As String

    <Required>
    <StringLength(256)>
    Public Property LoweredPath As String

    Public Overridable Property aspnet_Applications As aspnet_Applications

    Public Overridable Property aspnet_PersonalizationAllUsers As aspnet_PersonalizationAllUsers

    Public Overridable Property aspnet_PersonalizationPerUser As ICollection(Of aspnet_PersonalizationPerUser)
End Class
