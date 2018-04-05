Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Application
    Public Sub New()
        Memberships = New HashSet(Of Membership)()
        Roles = New HashSet(Of Role)()
        Users = New HashSet(Of User)()
    End Sub

    <Required>
    <StringLength(235)>
    Public Property ApplicationName As String

    Public Property ApplicationId As Guid

    <StringLength(256)>
    Public Property Description As String

    Public Overridable Property Memberships As ICollection(Of Membership)

    Public Overridable Property Roles As ICollection(Of Role)

    Public Overridable Property Users As ICollection(Of User)
End Class
