Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class visitor
    <Key>
    Public Property vID As Integer

    <Required>
    <StringLength(50)>
    Public Property PageViewed As String

    Public Property timestamp As Date
End Class
