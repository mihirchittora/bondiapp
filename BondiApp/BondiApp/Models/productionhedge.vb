Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("productionhedge")>
Partial Public Class productionhedge
    Public Property id As Integer

    Public Property timestamp As Date?

    Public Property permid As Integer?
End Class
