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

Partial Public Class Financial_Periods
    Public Property Id As Integer
    Public Property Description As String
    Public Property Code As String
    Public Property Status As String
    Public Property StartDate As Date
    Public Property EndDate As Date
    Public Property Finalized As Nullable(Of Date)
    Public Property Business_Unit As Nullable(Of Integer)

    Public Overridable Property Business_Units_Plants As Business_Units_Plants

End Class
