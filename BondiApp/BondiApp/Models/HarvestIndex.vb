Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("HarvestIndex")>
Partial Public Class HarvestIndex
    Public Property id As Integer

    <StringLength(12)>
    Public Property harvestKey As String

    Public Property userID As Guid?

    <StringLength(140)>
    Public Property name As String

    <StringLength(4)>
    Public Property product As String

    <Column(TypeName:="money")>
    Public Property opentrigger As Decimal?

    <Column(TypeName:="money")>
    Public Property width As Decimal?

    Public Property timestamp As Date?

    Public Property active As Boolean?

    Public Property shares As Integer?

    Public Property hedge As Boolean?

    <Column(TypeName:="money")>
    Public Property hedgewidth As Decimal?

    Public Property expdatewidth As Integer?

    Public Property hedgelots As Integer?

    <Column(TypeName:="money")>
    Public Property pricetoprotect As Decimal?

    <Column(TypeName:="money")>
    Public Property OpeningMark As Decimal?

    <StringLength(4)>
    Public Property stocksectype As String

    <StringLength(4)>
    Public Property optsectype As String

    <StringLength(4)>
    Public Property currencytype As String

    <StringLength(10)>
    Public Property exchange As String

    <StringLength(4)>
    Public Property ordertype As String

    <StringLength(4)>
    Public Property inforce As String

    Public Property opentimestamp As Date?
End Class

