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

Partial Public Class Loadslips_Details
    Public Property Id As Integer
    Public Property SSCC As String
    Public Property Loaded As Nullable(Of Date)
    Public Property Status As String
    Public Property LoadId As Nullable(Of Integer)
    Public Property ProductId As Nullable(Of Integer)
    Public Property LoadReference As String
    Public Property Created As Nullable(Of Date)
    Public Property LoadedBy As String
    Public Property Postion As Nullable(Of Integer)
    Public Property TotalRequired As Nullable(Of Integer)
    Public Property HUDescription As String
    Public Property Device As String
    Public Property Waypoint As String

    Public Overridable Property Loadslip As Loadslip

End Class
