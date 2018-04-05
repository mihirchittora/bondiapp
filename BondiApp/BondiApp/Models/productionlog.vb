Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("productionlog")>
Partial Public Class productionlog
    Public Property id As Integer

    Public Property timestamp As Date?
End Class
