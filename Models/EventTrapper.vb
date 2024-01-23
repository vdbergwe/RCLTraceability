Public Class EventTrapper
    Partial Public Class TrapperEvent
        Public Property System As String = "RCL_TRACE"
        Public Property ClassName As String
        Public Property Type As String = "System Health Layer"
        Public Property Created As DateTime = Now()
        Public Property CreatedBy As String = "System Health Layer"
        Public Property [Event] As String = Nothing
        Public Property Severity As String = "Information"
        Public Property Source As String = Nothing
        Public Property Origin As String = Nothing
        Public Property SupportNotified As Boolean = False
        Public Property EventPayload As String = ""
        Public Property Archive As Boolean = False
    End Class
End Class
