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
Imports System.Data.Entity.Core.Objects
Imports System.Linq

Partial Public Class OMD_DatawarehouseEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=OMD_DatawarehouseEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property AspNetUsers_Extended() As DbSet(Of AspNetUsers_Extended)
    Public Overridable Property Business_Units() As DbSet(Of Business_Units)
    Public Overridable Property Business_Units_Plants() As DbSet(Of Business_Units_Plants)
    Public Overridable Property Devices() As DbSet(Of Device)
    Public Overridable Property Devices_Operators() As DbSet(Of Devices_Operators)
    Public Overridable Property Financial_Periods() As DbSet(Of Financial_Periods)
    Public Overridable Property Handling_Units() As DbSet(Of Handling_Units)
    Public Overridable Property Handling_Units_Movements() As DbSet(Of Handling_Units_Movements)
    Public Overridable Property Integration_SSCC() As DbSet(Of Integration_SSCC)
    Public Overridable Property Integration_SyncLogs() As DbSet(Of Integration_SyncLogs)
    Public Overridable Property Loadslips() As DbSet(Of Loadslip)
    Public Overridable Property Loadslips_Details() As DbSet(Of Loadslips_Details)
    Public Overridable Property Logs() As DbSet(Of Log)
    Public Overridable Property Plants_Locations() As DbSet(Of Plants_Locations)
    Public Overridable Property Plants_Shifts() As DbSet(Of Plants_Shifts)
    Public Overridable Property Production_Batches() As DbSet(Of Production_Batches)
    Public Overridable Property Products() As DbSet(Of Product)
    Public Overridable Property QC_Scales() As DbSet(Of QC_Scales)
    Public Overridable Property QC_Scales_Readings() As DbSet(Of QC_Scales_Readings)
    Public Overridable Property QC_Scales_Stations() As DbSet(Of QC_Scales_Stations)
    Public Overridable Property ShiftForemansReports() As DbSet(Of ShiftForemansReport)
    Public Overridable Property Software_Development() As DbSet(Of Software_Development)
    Public Overridable Property Software_Dropdowns() As DbSet(Of Software_Dropdowns)
    Public Overridable Property Software_Packages() As DbSet(Of Software_Packages)
    Public Overridable Property Software_Services() As DbSet(Of Software_Services)
    Public Overridable Property Software_Settings() As DbSet(Of Software_Settings)
    Public Overridable Property Stocks() As DbSet(Of Stock)
    Public Overridable Property Stock_Movements() As DbSet(Of Stock_Movements)
    Public Overridable Property sysdiagrams() As DbSet(Of sysdiagram)
    Public Overridable Property Vehicles() As DbSet(Of Vehicle)
    Public Overridable Property Waypoints() As DbSet(Of Waypoint)
    Public Overridable Property Waypoints_Configurations() As DbSet(Of Waypoints_Configurations)
    Public Overridable Property Waypoints_NumberBanks() As DbSet(Of Waypoints_NumberBanks)

    Public Overridable Function Truncate_Products() As Integer
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("Truncate_Products")
    End Function

End Class
