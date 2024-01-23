Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Text.Json.Serialization
Imports Intranet.Meta_Device
Imports Intranet.Meta_Devices

<MetadataType(GetType(Meta_Device))>
Partial Public Class Device

End Class

Public Class Meta_Devices
    Partial Public Class Product
        Public Property Id As Integer
        Public Property Description As String
        Public Property PLU As Integer?
        Public Property Type As String
        Public Property Packaging As String
        Public Property ConsumerUnits As Integer?
        Public Property SalesUnits As Integer?
        Public Property TargetWeight As Decimal?
        Public Property HUTargetWeight As Decimal?
        Public Property UOM As String
        Public Property TareWeight As String
        Public Property ConsumerBarcode As String
        Public Property SalesUnitBarcode As String
        Public Property Commodity As String
        Public Property ProducedBy As String
        Public Property Status As String
        Public Property Expiry As Integer
        Public Property Labels As Integer
        Public Property QCSampleSize As Integer
    End Class
    Partial Public Class machine_Config
        Public Property BASE_URL As String
        Public Property REGISTRATION_URL As String
        Public Property CONFIGURATION_ENDPOINTS_URL As String
        Public Property DEVICE_ID As String
        Public Property DEV_MODE As String
        Public Property COUNTRY As String
    End Class
    Partial Public Class handling_Unit
        Public Property Id As String
        Public Property Batch As String
        Public Property Created As String
        Public Property CreatedBy As String
        Public Property Device As String
        Public Property NumberBank As String
        Public Property Product As String
        Public Property SSCC As String
        Public Property Status As String
        Public Property Age As String
        Public Property ProductDescription As String
        Public Property Berth As String
        Public Property ScannedCode As String
        Public Property Trailer As String
        Public Property Horse As String
    End Class
End Class
Partial Public Class Meta_Device
    Public Property Id As Integer
    Public Property Description As String
    Public Property IP As String
    Public Property Type As String
    Public Property Status As String
    Public Property MAC As String
    Public Property SwitchPort As Nullable(Of Integer)
    Public Property Switch As String
    Public Property SerialNumber As String
    Public Property HardwareVersion As String
    Public Property SoftwareVersion As String
    Public Property StorageInformation As String
    Public Property NetworkInformation As String
    Public Property LocalWebServerUrlPORT As String
    Public Property RequiresUpdate As Nullable(Of Boolean)
    Public Property LastCheckin As String
    Public Property LastReportedStatus As String
    Public Property NetworkConfigIP As String
    Public Property NetworkConfigSubnet As String
    Public Property NetworkConfigGateway As String
    Public Property NetworkConfigDNS As String
    Public Property LockedOut As Nullable(Of Boolean)
    Public Property LockedOutBy As String
    Public Property LockedOutOn As Nullable(Of Date)
    Public Property SecurityKey As String
    Public Property CurrentOperatorId As String
    Public Property RequiresSupport As Nullable(Of Boolean)
    Public Property Waypoint1 As Meta_Waypoint

    Partial Public Class Meta_Waypoint
        Public Property Id As Integer
        Public Property Description As String
        Public Property Type As String
        Public Property Status As String
        Public Property UOM As String
        Public Property LoadCapcity As String
        Public Property HasPrinter As Nullable(Of Boolean)
        Public Property HasScanner As Nullable(Of Boolean)
        Public Property Location As Nullable(Of Integer)
        Public Property Waypoints_NumberBanks As Meta_Waypoint_NumberBank
        Public Property Waypoints_Batches As Meta_Production_Batches
        Public Property Waypoints_Configurations As ICollection(Of Meta_Waypoint_Configs)

        Partial Public Class Meta_Waypoint_Configs
            Public Property Id As String
            Public Property SettingName As String
            Public Property SettingValue As String
            Public Property SettingType As String
            Public Property SettingGroup As String
            Public Property SettingSubGroup As String
            Public Property Active As Nullable(Of Boolean)
            Public Property Waypoint As Nullable(Of Integer)
            Public Property IsGlobalSetting As Nullable(Of Boolean)
        End Class
        Partial Public Class Meta_Waypoint_NumberBank
            Public Property Id As Integer?
            Public Property Prefix As String
            Public Property Bank As String
            Public Property Root As String
            Public Property FirstNumber As Nullable(Of Integer)
            Public Property LastNumber As Nullable(Of Integer)
            Public Property LastIssued As String
            Public Property Created As Nullable(Of Date)
            Public Property Reserved As Nullable(Of Date)
            Public Property Released As Nullable(Of Date)
            Public Property Depleted As Nullable(Of Date)
            Public Property Waypoint As Nullable(Of Integer)
            Public Property Device As String
            Public Property Status As String
        End Class
        Partial Public Class Meta_Production_Batches
            Public Property Id As Integer
            Public Property Description As String
            Public Property Type As String
            Public Property Status As String
            Public Property Shift As Nullable(Of Integer)
            Public Property BatchDate As Nullable(Of Date)
            Public Property BatchCreated As Nullable(Of Date)
            Public Property BatchEnded As Nullable(Of Date)
            Public Property Plant As String
        End Class
    End Class

End Class