Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class aspnet_PersonalizationAllUsers
    <Key>
    Public Property PathId As Guid

    <Column(TypeName:="image")>
    <Required>
    Public Property PageSettings As Byte()

    Public Property LastUpdatedDate As Date

    Public Overridable Property aspnet_Paths As aspnet_Paths
End Class
