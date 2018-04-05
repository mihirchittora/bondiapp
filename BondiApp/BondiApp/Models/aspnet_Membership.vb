Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class aspnet_Membership
    Public Property ApplicationId As Guid

    <Key>
    Public Property UserId As Guid

    <Required>
    <StringLength(128)>
    Public Property Password As String

    Public Property PasswordFormat As Integer

    <Required>
    <StringLength(128)>
    Public Property PasswordSalt As String

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

    Public Property IsApproved As Boolean

    Public Property IsLockedOut As Boolean

    Public Property CreateDate As Date

    Public Property LastLoginDate As Date

    Public Property LastPasswordChangedDate As Date

    Public Property LastLockoutDate As Date

    Public Property FailedPasswordAttemptCount As Integer

    Public Property FailedPasswordAttemptWindowStart As Date

    Public Property FailedPasswordAnswerAttemptCount As Integer

    Public Property FailedPasswordAnswerAttemptWindowStart As Date

    <Column(TypeName:="ntext")>
    Public Property Comment As String

    Public Overridable Property aspnet_Applications As aspnet_Applications

    Public Overridable Property aspnet_Users As aspnet_Users
End Class
