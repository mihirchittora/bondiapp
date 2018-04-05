Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class vw_aspnet_Users
    <Key>
    <Column(Order:=0)>
    Public Property ApplicationId As Guid

    <Key>
    <Column(Order:=1)>
    Public Property UserId As Guid

    <Key>
    <Column(Order:=2)>
    <StringLength(256)>
    Public Property UserName As String

    <Key>
    <Column(Order:=3)>
    <StringLength(256)>
    Public Property LoweredUserName As String

    <StringLength(16)>
    Public Property MobileAlias As String

    <Key>
    <Column(Order:=4)>
    Public Property IsAnonymous As Boolean

    <Key>
    <Column(Order:=5)>
    Public Property LastActivityDate As Date
End Class
