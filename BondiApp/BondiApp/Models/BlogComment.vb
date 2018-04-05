Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class BlogComment
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property Id As Integer

    Public Property BlogEntryId As Integer

    <Required>
    <StringLength(100)>
    Public Property Title As String

    <Required>
    <StringLength(100)>
    Public Property Name As String

    <Required>
    <StringLength(500)>
    Public Property Email As String

    <Required>
    <StringLength(500)>
    Public Property Url As String

    Public Property DatePublished As Date

    <Required>
    Public Property Text As String

    Public Property active As Boolean
End Class
