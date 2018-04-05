Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class email
    Public Property emailID As Long

    <Required>
    <StringLength(500)>
    Public Property emailaddress As String

    <Column(TypeName:="date")>
    Public Property addDATE As Date
End Class
