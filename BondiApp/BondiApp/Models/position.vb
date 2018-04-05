Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class position
    Public Property id As Integer

    Public Property timestamp As Date?

    Public Property lasttimestamp As Date?

    <StringLength(4)>
    Public Property symbol As String

    Public Property qty As Long?

    <StringLength(12)>
    Public Property roboIndex As String
End Class
