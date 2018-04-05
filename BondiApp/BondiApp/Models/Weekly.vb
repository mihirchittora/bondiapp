Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Weeklys")>
Partial Public Class Weekly
    Public Property id As Integer

    <Required>
    <StringLength(10)>
    Public Property Symbol As String

    <Required>
    <StringLength(200)>
    Public Property Name As String

    <Required>
    <StringLength(50)>
    Public Property Product As String

    <Required>
    <StringLength(50)>
    Public Property IssueDate As String

    Public Property firstissuedate As Date

    Public Property lastupdate As Date

    Public Property active As Boolean

    <Column(TypeName:="money")>
    Public Property strikewidth As Decimal?
End Class
