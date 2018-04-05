Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class TradeDetail
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property tradeID As Long

    <Column(TypeName:="date")>
    Public Property addDATE As Date

    <Required>
    <StringLength(10)>
    Public Property transTYPE As String

    Public Property lots As Integer

    <Required>
    <StringLength(50)>
    Public Property tradeTYPE As String

    <Required>
    <StringLength(10)>
    Public Property symbol As String

    <Required>
    <StringLength(10)>
    Public Property count As String

    <Column(TypeName:="date")>
    Public Property expirationDATE As Date

    <Column(TypeName:="money")>
    Public Property shortCALL As Decimal

    <Column(TypeName:="money")>
    Public Property longCALL As Decimal

    <Column(TypeName:="money")>
    Public Property shortPUT As Decimal

    <Column(TypeName:="money")>
    Public Property longPUT As Decimal

    <Column(TypeName:="money")>
    Public Property creditreceived As Decimal

    Public Property open As Boolean

    <Column(TypeName:="money")>
    Public Property debitpaid As Decimal

    <Column(TypeName:="date")>
    Public Property openDATE As Date

    <Column(TypeName:="date")>
    Public Property closeDATE As Date

    <StringLength(12)>
    Public Property uniqueid As String

    Public Property winFLAG As Boolean?

    Public Property dit As Long?

    <Column(TypeName:="date")>
    Public Property updateDATE As Date?

    <StringLength(50)>
    Public Property userID As String

    <StringLength(10)>
    Public Property exp As String
End Class
