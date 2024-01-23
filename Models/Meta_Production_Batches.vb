Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
<MetadataType(GetType(Meta_Production_Batches))>
Partial Public Class Production_Batches

End Class

Public Class Meta_Production_Batches
    Public Property Id As Integer
    <DisplayName("Batch Code")>
    Public Property Description As String
    <DisplayName("Batch Type")>
    Public Property Type As String
    <DisplayName("Batch Status")>
    Public Property Status As String
    <DisplayName("Batch Shift")>
    Public Property Shift As Integer?
    <DisplayName("Batch Date")>
    Public Property BatchDate As Date?
    <DisplayName("Batch Created")>
    Public Property BatchCreated As Date?
    <DisplayName("Batch Ended")>
    Public Property BatchEnded As Date?
End Class