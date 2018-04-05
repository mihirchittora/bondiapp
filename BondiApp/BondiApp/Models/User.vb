Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class User
    Public Sub New()
        Roles = New HashSet(Of Role)()
    End Sub

    Public Property ApplicationId As Guid

    Public Property UserId As Guid

    <Required>
    <StringLength(50)>
    Public Property UserName As String

    Public Property IsAnonymous As Boolean

    Public Property LastActivityDate As Date

    Public Overridable Property Application As Application

    Public Overridable Property Membership As Membership

    Public Overridable Property Profile As Profile

    Public Overridable Property Roles As ICollection(Of Role)
End Class
