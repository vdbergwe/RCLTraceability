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

Partial Public Class Stock
    Public Property Id As Integer
    Public Property Code As String
    Public Property Description As String
    Public Property Type As String
    Public Property Grouping As String
    Public Property SubGrouping As String
    Public Property UoM As String
    Public Property CostPerUnit As String
    Public Property FlagMin As Nullable(Of Integer)
    Public Property FlagOrder As Nullable(Of Integer)
    Public Property FlagMax As Nullable(Of Integer)
    Public Property OrderQty As Nullable(Of Integer)
    Public Property PlantId As Nullable(Of Integer)
    Public Property Status As String
    Public Property Created As Nullable(Of Date)
    Public Property CreatedBy As String

    Public Overridable Property Business_Units_Plants As Business_Units_Plants
    Public Overridable Property Stock_Movements As ICollection(Of Stock_Movements) = New HashSet(Of Stock_Movements)

End Class
