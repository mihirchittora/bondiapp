Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class aspnet_SchemaVersions
    <Key>
    <Column(Order:=0)>
    Public Property Feature As String

    <Key>
    <Column(Order:=1)>
    Public Property CompatibleSchemaVersion As String

    Public Property IsCurrentVersion As Boolean
End Class
