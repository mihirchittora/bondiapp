Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class vw_aspnet_MembershipUsers
    <Key>
    <Column(Order:=0)>
    Public Property UserId As Guid

    <Key>
    <Column(Order:=1)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property PasswordFormat As Integer

    <StringLength(16)>
    Public Property MobilePIN As String

    <StringLength(256)>
    Public Property Email As String

    <StringLength(256)>
    Public Property LoweredEmail As String

    <StringLength(256)>
    Public Property PasswordQuestion As String

    <StringLength(128)>
    Public Property PasswordAnswer As String

    <Key>
    <Column(Order:=2)>
    Public Property IsApproved As Boolean

    <Key>
    <Column(Order:=3)>
    Public Property IsLockedOut As Boolean

    <Key>
    <Column(Order:=4)>
    Public Property CreateDate As Date

    <Key>
    <Column(Order:=5)>
    Public Property LastLoginDate As Date

    <Key>
    <Column(Order:=6)>
    Public Property LastPasswordChangedDate As Date

    <Key>
    <Column(Order:=7)>
    Public Property LastLockoutDate As Date

    <Key>
    <Column(Order:=8)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property FailedPasswordAttemptCount As Integer

    <Key>
    <Column(Order:=9)>
    Public Property FailedPasswordAttemptWindowStart As Date

    <Key>
    <Column(Order:=10)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property FailedPasswordAnswerAttemptCount As Integer

    <Key>
    <Column(Order:=11)>
    Public Property FailedPasswordAnswerAttemptWindowStart As Date

    <Column(TypeName:="ntext")>
    Public Property Comment As String

    <Key>
    <Column(Order:=12)>
    Public Property ApplicationId As Guid

    <Key>
    <Column(Order:=13)>
    <StringLength(256)>
    Public Property UserName As String

    <StringLength(16)>
    Public Property MobileAlias As String

    <Key>
    <Column(Order:=14)>
    Public Property IsAnonymous As Boolean

    <Key>
    <Column(Order:=15)>
    Public Property LastActivityDate As Date
End Class
