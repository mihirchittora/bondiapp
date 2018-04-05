Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Role
    Public Sub New()
        Users = New HashSet(Of User)()
    End Sub

    Public Property ApplicationId As Guid

    Public Property RoleId As Guid

    <Required>
    <StringLength(256)>
    Public Property RoleName As String

    <StringLength(256)>
    Public Property Description As String

    Public Overridable Property Application As Application

    Public Overridable Property Users As ICollection(Of User)
End Class
