Imports System.Data.Entity
Imports System.Net.Http
Imports System.Net
Imports System.IO
Imports System.Threading.Tasks
Imports Intranet.EventTrapper
Imports Intranet.SystemHealthTrapper
Imports System.Text.Json
Imports Intranet.Meta_Device
Imports Intranet.Communications

Namespace Logic
    Public Class NumberBank_Logic
        Private Shared db As New OMD_DatawarehouseEntities
        Private Shared s As New SystemHealthTrapper.SystemHealthTrapper
        Private Shared TrapperEnabled As String = db.Software_Settings.Find("87bb6d48-402d-433d-88e6-8f763384a3d7").SettingValue
        Private Shared Function check_NumberBank(numberBank As Waypoints_NumberBanks)
            Return numberBank
        End Function
    End Class
End Namespace