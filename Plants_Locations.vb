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

Partial Public Class Plants_Locations
    Public Property Id As Integer
    Public Property PlantId As Nullable(Of Integer)
    Public Property Description As String
    Public Property Type As String

    Public Overridable Property Business_Units_Plants As Business_Units_Plants
    Public Overridable Property QC_Scales_Stations As ICollection(Of QC_Scales_Stations) = New HashSet(Of QC_Scales_Stations)
    Public Overridable Property Waypoints As ICollection(Of Waypoint) = New HashSet(Of Waypoint)

End Class
