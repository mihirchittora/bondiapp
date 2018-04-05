Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class aspnet_Profile
    <Key>
    Public Property UserId As Guid

    <Column(TypeName:="ntext")>
    <Required>
    Public Property PropertyNames As String

    <Column(TypeName:="ntext")>
    <Required>
    Public Property PropertyValuesString As String

    <Column(TypeName:="image")>
    <Required>
    Public Property PropertyValuesBinary As Byte()

    Public Property LastUpdatedDate As Date

    Public Overridable Property aspnet_Users As aspnet_Users
End Class
