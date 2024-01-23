Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

<MetadataType(GetType(Meta_QC_Scales_Readings))>
Partial Public Class QC_Scales_Readings

End Class

Partial Public Class Meta_QC_Scales_Readings
    Public Property Id As Integer
    <DisplayName("Date")>
    Public Property ReadingDate As Date
    <DisplayName("Product")>
    Public Property Product As Integer
    <DisplayName("Operator")>
    Public Property [Operator] As Integer?
    <DisplayName("Sample 1")>
    Public Property S1 As Decimal?
    <DisplayName("Sample 2")>
    Public Property S2 As Decimal?
    <DisplayName("Sample 3")>
    Public Property S3 As Decimal?
    <DisplayName("Sample 4")>
    Public Property S4 As Decimal?
    <DisplayName("Median")>
    Public Property Median As Decimal?
    <DisplayName("Tare")>
    Public Property Tare As Decimal?
    <DisplayName("Result")>
    Public Property Result As String
    <DisplayName("Status")>
    Public Property Status As String
    <DisplayName("Action Result")>
    Public Property Result_Action As String
    <DisplayName("Target")>
    Public Property Target As Decimal?
    <DisplayName("Batch")>
    Public Property Batch As Integer?
    <DisplayName("Station")>
    Public Property QC_Station As Integer?
    <DisplayName("Unit of Measure")>
    Public Property UOM As String
    <DisplayName("Scale")>
    Public Property QC_Scale As Integer?
End Class

