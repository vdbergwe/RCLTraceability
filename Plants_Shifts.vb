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

Partial Public Class Plants_Shifts
    Public Property Id As Integer
    Public Property Description As String
    Public Property StartTime As Nullable(Of System.TimeSpan)
    Public Property EndTime As Nullable(Of System.TimeSpan)
    Public Property Mon As Nullable(Of Boolean)
    Public Property Tue As Nullable(Of Boolean)
    Public Property Wed As Nullable(Of Boolean)
    Public Property Thu As Nullable(Of Boolean)
    Public Property Fri As Nullable(Of Boolean)
    Public Property Sat As Nullable(Of Boolean)
    Public Property Sun As Nullable(Of Boolean)
    Public Property Active As Nullable(Of Boolean)
    Public Property Plant As Nullable(Of Integer)
    Public Property ShiftCode As String

    Public Overridable Property Business_Units_Plants As Business_Units_Plants
    Public Overridable Property Production_Batches As ICollection(Of Production_Batches) = New HashSet(Of Production_Batches)
    Public Overridable Property ShiftForemansReports As ICollection(Of ShiftForemansReport) = New HashSet(Of ShiftForemansReport)

End Class
