﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Partial Public Class optionwavesdbEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=optionwavesdbEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property Applications() As DbSet(Of Application)
    Public Overridable Property aspnet_Applications() As DbSet(Of aspnet_Applications)
    Public Overridable Property aspnet_Membership() As DbSet(Of aspnet_Membership)
    Public Overridable Property aspnet_Paths() As DbSet(Of aspnet_Paths)
    Public Overridable Property aspnet_PersonalizationAllUsers() As DbSet(Of aspnet_PersonalizationAllUsers)
    Public Overridable Property aspnet_PersonalizationPerUser() As DbSet(Of aspnet_PersonalizationPerUser)
    Public Overridable Property aspnet_Profile() As DbSet(Of aspnet_Profile)
    Public Overridable Property aspnet_Roles() As DbSet(Of aspnet_Roles)
    Public Overridable Property aspnet_SchemaVersions() As DbSet(Of aspnet_SchemaVersions)
    Public Overridable Property aspnet_Users() As DbSet(Of aspnet_Users)
    Public Overridable Property aspnet_WebEvent_Events() As DbSet(Of aspnet_WebEvent_Events)
    Public Overridable Property backtests() As DbSet(Of backtest)
    Public Overridable Property BlogComments() As DbSet(Of BlogComment)
    Public Overridable Property BlogEntries() As DbSet(Of BlogEntry)
    Public Overridable Property emails() As DbSet(Of email)
    Public Overridable Property HarvestHedges() As DbSet(Of HarvestHedge)
    Public Overridable Property HarvestIndexes() As DbSet(Of HarvestIndex)
    Public Overridable Property HarvestIntervals() As DbSet(Of HarvestInterval)
    Public Overridable Property HarvestLogs() As DbSet(Of HarvestLog)
    Public Overridable Property HarvestMarks() As DbSet(Of HarvestMark)
    Public Overridable Property HarvestPositions() As DbSet(Of HarvestPosition)
    Public Overridable Property Memberships() As DbSet(Of Membership)
    Public Overridable Property onesigmawides() As DbSet(Of onesigmawide)
    Public Overridable Property positions() As DbSet(Of position)
    Public Overridable Property Prices() As DbSet(Of Price)
    Public Overridable Property Pricings() As DbSet(Of Pricing)
    Public Overridable Property productionhedges() As DbSet(Of productionhedge)
    Public Overridable Property productionlogs() As DbSet(Of productionlog)
    Public Overridable Property productionstocks() As DbSet(Of productionstock)
    Public Overridable Property Profiles() As DbSet(Of Profile)
    Public Overridable Property Roles() As DbSet(Of Role)
    Public Overridable Property Tasks() As DbSet(Of Task)
    Public Overridable Property TicketComments() As DbSet(Of TicketComment)
    Public Overridable Property Tickets() As DbSet(Of Ticket)
    Public Overridable Property TradeDetails() As DbSet(Of TradeDetail)
    Public Overridable Property TradeLogs() As DbSet(Of TradeLog)
    Public Overridable Property Users() As DbSet(Of User)
    Public Overridable Property visitors() As DbSet(Of visitor)
    Public Overridable Property Weeklys() As DbSet(Of Weekly)
    Public Overridable Property wStockOrders() As DbSet(Of wStockOrder)
    Public Overridable Property vw_aspnet_Applications() As DbSet(Of vw_aspnet_Applications)
    Public Overridable Property vw_aspnet_MembershipUsers() As DbSet(Of vw_aspnet_MembershipUsers)
    Public Overridable Property vw_aspnet_Profiles() As DbSet(Of vw_aspnet_Profiles)
    Public Overridable Property vw_aspnet_Roles() As DbSet(Of vw_aspnet_Roles)
    Public Overridable Property vw_aspnet_Users() As DbSet(Of vw_aspnet_Users)
    Public Overridable Property vw_aspnet_UsersInRoles() As DbSet(Of vw_aspnet_UsersInRoles)
    Public Overridable Property vw_aspnet_WebPartState_Paths() As DbSet(Of vw_aspnet_WebPartState_Paths)
    Public Overridable Property vw_aspnet_WebPartState_Shared() As DbSet(Of vw_aspnet_WebPartState_Shared)
    Public Overridable Property vw_aspnet_WebPartState_User() As DbSet(Of vw_aspnet_WebPartState_User)
    Public Overridable Property vw_avg_daily_gap() As DbSet(Of vw_avg_daily_gap)
    Public Overridable Property vw_avg_ranges() As DbSet(Of vw_avg_ranges)
    Public Overridable Property vw_full_view_w_calc() As DbSet(Of vw_full_view_w_calc)
    Public Overridable Property vw_Pricings_DESC() As DbSet(Of vw_Pricings_DESC)
    Public Overridable Property activitylogs() As DbSet(Of activitylog)
    Public Overridable Property backteststats() As DbSet(Of backteststat)
    Public Overridable Property stockorders() As DbSet(Of stockorder)
    Public Overridable Property Trades() As DbSet(Of Trade)
    Public Overridable Property harvestorders() As DbSet(Of harvestorder)
    Public Overridable Property myorders() As DbSet(Of myorder)

End Class
