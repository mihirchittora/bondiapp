'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class aspnet_Users
    Public Property ApplicationId As System.Guid
    Public Property UserId As System.Guid
    Public Property UserName As String
    Public Property LoweredUserName As String
    Public Property MobileAlias As String
    Public Property IsAnonymous As Boolean
    Public Property LastActivityDate As Date

    Public Overridable Property aspnet_Applications As aspnet_Applications
    Public Overridable Property aspnet_Membership As aspnet_Membership
    Public Overridable Property aspnet_PersonalizationPerUser As ICollection(Of aspnet_PersonalizationPerUser) = New HashSet(Of aspnet_PersonalizationPerUser)
    Public Overridable Property aspnet_Profile As aspnet_Profile
    Public Overridable Property aspnet_Roles As ICollection(Of aspnet_Roles) = New HashSet(Of aspnet_Roles)

End Class
