Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Profile
    <Key>
    Public Property UserId As Guid

    Public Property LastUpdatedDate As Date

    <Required>
    <StringLength(250)>
    Public Property ScreenName As String

    <StringLength(50)>
    Public Property image As String

    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ProfileId As Integer

    <StringLength(50)>
    Public Property mobile As String

    Public Property demo As Boolean?

    <StringLength(50)>
    Public Property FirstName As String

    <StringLength(100)>
    Public Property LastName As String

    <StringLength(150)>
    Public Property Skype As String

    <StringLength(500)>
    Public Property Location As String

    <StringLength(500)>
    Public Property email As String

    Public Property MaxProfitPercent As Short?

    Public Property ShowAny As Boolean?

    Public Property ShowTrades As Boolean?

    Public Property TOS As Boolean?

    <Column(TypeName:="smallmoney")>
    Public Property commission As Decimal?

    Public Overridable Property User As User
End Class
