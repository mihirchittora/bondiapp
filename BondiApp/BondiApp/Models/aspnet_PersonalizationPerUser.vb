Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class aspnet_PersonalizationPerUser
    Public Property Id As Guid

    Public Property PathId As Guid?

    Public Property UserId As Guid?

    <Column(TypeName:="image")>
    <Required>
    Public Property PageSettings As Byte()

    Public Property LastUpdatedDate As Date

    Public Overridable Property aspnet_Paths As aspnet_Paths

    Public Overridable Property aspnet_Users As aspnet_Users
End Class
