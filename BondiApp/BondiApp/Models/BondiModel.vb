Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class BondiModel
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=BondiModel")
    End Sub

    Public Overridable Property Applications As DbSet(Of Application)
    Public Overridable Property aspnet_Applications As DbSet(Of aspnet_Applications)
    Public Overridable Property aspnet_Membership As DbSet(Of aspnet_Membership)
    Public Overridable Property aspnet_Paths As DbSet(Of aspnet_Paths)
    Public Overridable Property aspnet_PersonalizationAllUsers As DbSet(Of aspnet_PersonalizationAllUsers)
    Public Overridable Property aspnet_PersonalizationPerUser As DbSet(Of aspnet_PersonalizationPerUser)
    Public Overridable Property aspnet_Profile As DbSet(Of aspnet_Profile)
    Public Overridable Property aspnet_Roles As DbSet(Of aspnet_Roles)
    Public Overridable Property aspnet_SchemaVersions As DbSet(Of aspnet_SchemaVersions)
    Public Overridable Property aspnet_Users As DbSet(Of aspnet_Users)
    Public Overridable Property aspnet_WebEvent_Events As DbSet(Of aspnet_WebEvent_Events)
    Public Overridable Property backtests As DbSet(Of backtest)
    Public Overridable Property BlogComments As DbSet(Of BlogComment)
    Public Overridable Property BlogEntries As DbSet(Of BlogEntry)
    Public Overridable Property emails As DbSet(Of email)
    Public Overridable Property HarvestHedges As DbSet(Of HarvestHedge)
    Public Overridable Property HarvestIndexes As DbSet(Of HarvestIndex)
    Public Overridable Property HarvestIntervals As DbSet(Of HarvestInterval)
    Public Overridable Property HarvestLogs As DbSet(Of HarvestLog)
    Public Overridable Property HarvestMarks As DbSet(Of HarvestMark)
    Public Overridable Property HarvestPositions As DbSet(Of HarvestPosition)
    Public Overridable Property Memberships As DbSet(Of Membership)
    Public Overridable Property onesigmawides As DbSet(Of onesigmawide)
    Public Overridable Property positions As DbSet(Of position)
    Public Overridable Property Prices As DbSet(Of Price)
    Public Overridable Property Pricings As DbSet(Of Pricing)
    Public Overridable Property productionhedges As DbSet(Of productionhedge)
    Public Overridable Property productionlogs As DbSet(Of productionlog)
    Public Overridable Property productionstocks As DbSet(Of productionstock)
    Public Overridable Property Profiles As DbSet(Of Profile)
    Public Overridable Property Roles As DbSet(Of Role)
    Public Overridable Property stockorders As DbSet(Of stockorder)
    Public Overridable Property Tasks As DbSet(Of Task)
    Public Overridable Property TicketComments As DbSet(Of TicketComment)
    Public Overridable Property Tickets As DbSet(Of Ticket)
    Public Overridable Property TradeDetails As DbSet(Of TradeDetail)
    Public Overridable Property TradeLogs As DbSet(Of TradeLog)
    Public Overridable Property Users As DbSet(Of User)
    Public Overridable Property visitors As DbSet(Of visitor)
    Public Overridable Property Weeklys As DbSet(Of Weekly)
    Public Overridable Property wStockOrders As DbSet(Of wStockOrder)
    Public Overridable Property vw_aspnet_Applications As DbSet(Of vw_aspnet_Applications)
    Public Overridable Property vw_aspnet_MembershipUsers As DbSet(Of vw_aspnet_MembershipUsers)
    Public Overridable Property vw_aspnet_Profiles As DbSet(Of vw_aspnet_Profiles)
    Public Overridable Property vw_aspnet_Roles As DbSet(Of vw_aspnet_Roles)
    Public Overridable Property vw_aspnet_Users As DbSet(Of vw_aspnet_Users)
    Public Overridable Property vw_aspnet_UsersInRoles As DbSet(Of vw_aspnet_UsersInRoles)
    Public Overridable Property vw_aspnet_WebPartState_Paths As DbSet(Of vw_aspnet_WebPartState_Paths)
    Public Overridable Property vw_aspnet_WebPartState_Shared As DbSet(Of vw_aspnet_WebPartState_Shared)
    Public Overridable Property vw_aspnet_WebPartState_User As DbSet(Of vw_aspnet_WebPartState_User)
    Public Overridable Property vw_avg_daily_gap As DbSet(Of vw_avg_daily_gap)
    Public Overridable Property vw_avg_ranges As DbSet(Of vw_avg_ranges)
    Public Overridable Property vw_full_view_w_calc As DbSet(Of vw_full_view_w_calc)
    Public Overridable Property vw_Pricings_DESC As DbSet(Of vw_Pricings_DESC)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Application)() _
            .HasMany(Function(e) e.Memberships) _
            .WithRequired(Function(e) e.Application) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Application)() _
            .HasMany(Function(e) e.Roles) _
            .WithRequired(Function(e) e.Application) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Application)() _
            .HasMany(Function(e) e.Users) _
            .WithRequired(Function(e) e.Application) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of aspnet_Applications)() _
            .HasMany(Function(e) e.aspnet_Membership) _
            .WithRequired(Function(e) e.aspnet_Applications) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of aspnet_Applications)() _
            .HasMany(Function(e) e.aspnet_Paths) _
            .WithRequired(Function(e) e.aspnet_Applications) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of aspnet_Applications)() _
            .HasMany(Function(e) e.aspnet_Roles) _
            .WithRequired(Function(e) e.aspnet_Applications) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of aspnet_Applications)() _
            .HasMany(Function(e) e.aspnet_Users) _
            .WithRequired(Function(e) e.aspnet_Applications) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of aspnet_Paths)() _
            .HasOptional(Function(e) e.aspnet_PersonalizationAllUsers) _
            .WithRequired(Function(e) e.aspnet_Paths)

        modelBuilder.Entity(Of aspnet_Roles)() _
            .HasMany(Function(e) e.aspnet_Users) _
            .WithMany(Function(e) e.aspnet_Roles) _
            .Map(Function(m) m.ToTable("aspnet_UsersInRoles").MapLeftKey("RoleId").MapRightKey("UserId"))

        modelBuilder.Entity(Of aspnet_Users)() _
            .HasOptional(Function(e) e.aspnet_Membership) _
            .WithRequired(Function(e) e.aspnet_Users)

        modelBuilder.Entity(Of aspnet_Users)() _
            .HasOptional(Function(e) e.aspnet_Profile) _
            .WithRequired(Function(e) e.aspnet_Users)

        modelBuilder.Entity(Of aspnet_WebEvent_Events)() _
            .Property(Function(e) e.EventId) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of aspnet_WebEvent_Events)() _
            .Property(Function(e) e.EventSequence) _
            .HasPrecision(19, 0)

        modelBuilder.Entity(Of aspnet_WebEvent_Events)() _
            .Property(Function(e) e.EventOccurrence) _
            .HasPrecision(19, 0)

        modelBuilder.Entity(Of HarvestHedge)() _
            .Property(Function(e) e.strike) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestHedge)() _
            .Property(Function(e) e.stockatopen) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestHedge)() _
            .Property(Function(e) e.openprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestHedge)() _
            .Property(Function(e) e.stockatclose) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestHedge)() _
            .Property(Function(e) e.closeprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestHedge)() _
            .Property(Function(e) e.targetexit) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestIndex)() _
            .Property(Function(e) e.opentrigger) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestIndex)() _
            .Property(Function(e) e.width) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestIndex)() _
            .Property(Function(e) e.hedgewidth) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestIndex)() _
            .Property(Function(e) e.pricetoprotect) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestIndex)() _
            .Property(Function(e) e.OpeningMark) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestInterval)() _
            .Property(Function(e) e.OpenPrice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestInterval)() _
            .Property(Function(e) e.HighPrice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestInterval)() _
            .Property(Function(e) e.LowPrice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestInterval)() _
            .Property(Function(e) e.ClosePrice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestLog)() _
            .Property(Function(e) e.closingmark) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestLog)() _
            .Property(Function(e) e.hedgeprofit) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestLog)() _
            .Property(Function(e) e.stockprofit) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestLog)() _
            .Property(Function(e) e.currentcapital) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestLog)() _
            .Property(Function(e) e.maxcapital) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestLog)() _
            .Property(Function(e) e.openingmark) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestMark)() _
            .Property(Function(e) e.mark) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestPosition)() _
            .Property(Function(e) e.openprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestPosition)() _
            .Property(Function(e) e.strike) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of HarvestPosition)() _
            .Property(Function(e) e.closeprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of onesigmawide)() _
            .Property(Function(e) e.StockPrice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of onesigmawide)() _
            .Property(Function(e) e.ShortStrike) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of onesigmawide)() _
            .Property(Function(e) e.OpeningCredit) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of onesigmawide)() _
            .Property(Function(e) e.LongStrike) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of onesigmawide)() _
            .Property(Function(e) e.OpeningDebit) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of onesigmawide)() _
            .Property(Function(e) e.ClosingDebit) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of onesigmawide)() _
            .Property(Function(e) e.ClosingCredit) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Price)() _
            .Property(Function(e) e.open) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Price)() _
            .Property(Function(e) e.high) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Price)() _
            .Property(Function(e) e.low) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Price)() _
            .Property(Function(e) e.close) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.openprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.highprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.lowprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.closeprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.adjcloseprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.RangeDollars) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.RangePercent) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.changedollars) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.ChangePercent) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.GapDollars) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.GapPercent) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.AvgRange10Day) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.AvgRange50Day) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.AvgRange100Day) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.AvgRange300Day) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.AvgChange10Day) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.AvgChange50Day) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.AvgChange100Day) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.AvgChange300Day) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.RangePrctLast10) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.RangePrctlast50) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.RangePrctLast100) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.RangePrctLast300) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.ChangePrctLast10) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.ChangePrctLast50) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.ChangePrctLast100) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.ChangePrctLast300) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.StrikeWidth) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Pricing)() _
            .Property(Function(e) e.StrikeToPrice) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of Profile)() _
            .Property(Function(e) e.commission) _
            .HasPrecision(10, 4)

        modelBuilder.Entity(Of Role)() _
            .HasMany(Function(e) e.Users) _
            .WithMany(Function(e) e.Roles) _
            .Map(Function(m) m.ToTable("UsersInRoles").MapLeftKey("RoleId").MapRightKey("UserId"))

        modelBuilder.Entity(Of stockorder)() _
            .Property(Function(e) e.TickPrice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of stockorder)() _
            .Property(Function(e) e.LimitPrice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Ticket)() _
            .HasMany(Function(e) e.TicketComments) _
            .WithRequired(Function(e) e.Ticket) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of TradeDetail)() _
            .Property(Function(e) e.shortCALL) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of TradeDetail)() _
            .Property(Function(e) e.longCALL) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of TradeDetail)() _
            .Property(Function(e) e.shortPUT) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of TradeDetail)() _
            .Property(Function(e) e.longPUT) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of TradeDetail)() _
            .Property(Function(e) e.creditreceived) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of TradeDetail)() _
            .Property(Function(e) e.debitpaid) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of TradeLog)() _
            .Property(Function(e) e.openingAMOUNT) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of TradeLog)() _
            .Property(Function(e) e.closingAMOUNT) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of User)() _
            .HasOptional(Function(e) e.Membership) _
            .WithRequired(Function(e) e.User)

        modelBuilder.Entity(Of User)() _
            .HasOptional(Function(e) e.Profile) _
            .WithRequired(Function(e) e.User)

        modelBuilder.Entity(Of Weekly)() _
            .Property(Function(e) e.strikewidth) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_avg_daily_gap)() _
            .Property(Function(e) e.ten_day_range) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_avg_daily_gap)() _
            .Property(Function(e) e.fifty_day_range) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_avg_daily_gap)() _
            .Property(Function(e) e.one_hundred_day_range) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_avg_daily_gap)() _
            .Property(Function(e) e.three_hundred_day_range) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_avg_ranges)() _
            .Property(Function(e) e.ten_day_range) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_avg_ranges)() _
            .Property(Function(e) e.fifty_day_range) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_avg_ranges)() _
            .Property(Function(e) e.one_hundred_day_range) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_avg_ranges)() _
            .Property(Function(e) e.three_hundred_day_range) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_full_view_w_calc)() _
            .Property(Function(e) e.openprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_full_view_w_calc)() _
            .Property(Function(e) e.highprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_full_view_w_calc)() _
            .Property(Function(e) e.lowprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_full_view_w_calc)() _
            .Property(Function(e) e.closeprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_full_view_w_calc)() _
            .Property(Function(e) e.adjcloseprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_full_view_w_calc)() _
            .Property(Function(e) e.RangeDollars) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_full_view_w_calc)() _
            .Property(Function(e) e.RangePercent) _
            .HasPrecision(18, 0)

        modelBuilder.Entity(Of vw_full_view_w_calc)() _
            .Property(Function(e) e.daily_gap) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_Pricings_DESC)() _
            .Property(Function(e) e.openprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_Pricings_DESC)() _
            .Property(Function(e) e.highprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_Pricings_DESC)() _
            .Property(Function(e) e.lowprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_Pricings_DESC)() _
            .Property(Function(e) e.closeprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_Pricings_DESC)() _
            .Property(Function(e) e.adjcloseprice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_Pricings_DESC)() _
            .Property(Function(e) e.RangeDollars) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of vw_Pricings_DESC)() _
            .Property(Function(e) e.RangePercent) _
            .HasPrecision(18, 0)
    End Sub
End Class
