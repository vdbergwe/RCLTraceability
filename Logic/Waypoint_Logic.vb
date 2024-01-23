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
    Public Class Waypoint_Logic

        Private Shared db As New OMD_DatawarehouseEntities
        Private Shared s As New SystemHealthTrapper.SystemHealthTrapper
        Private Shared TrapperEnabled As String = db.Software_Settings.Find("87bb6d48-402d-433d-88e6-8f763384a3d7").SettingValue
        Private Shared CHECK_IN_INTERVAL = db.Waypoints_Configurations.Find("CHECK_IN_INTERVAL").SettingValue
        Public Shared Function check_Device_Waypoint(device As Device)
            If IsNothing(device.LastCheckin) = False Then
                If DateDiff(DateInterval.Second, device.LastCheckin.Value, Now) > CHECK_IN_INTERVAL * 5 Then
                    device.Status = "Offline | Not Checking In"
                End If
            End If
            'Check if Unit Requires a Number Bank
            If device.Waypoint1.Type = "PAS" Then
                'Check Number Bank
                Dim b = device.Waypoint1.Waypoints_NumberBanks
                If b.Count = 0 Then
                    Dim n = db.Waypoints_NumberBanks.FirstOrDefault(Function(s) s.Waypoint = device.Waypoint And s.Status = "Allocated" Or s.Waypoint Is Nothing)
                    If n.Status = "New" Then
                        n.Status = "Allocated"
                        n.Waypoint = device.Waypoint
                        n.Device = device.Description
                        n.Reserved = Now()
                        n.LastIssued = IIf(IsNothing(n.LastIssued), 0, n.LastIssued)
                        db.Entry(n).State = EntityState.Modified
                        db.SaveChanges()
                    End If
                End If
            End If
            Return device
        End Function
        Public Shared Function check_Waypoint_Status(waypoint As Waypoint)
            Dim CHECK_IN_INTERVAL = db.Waypoints_Configurations.Find("CHECK_IN_INTERVAL").SettingValue
            Dim d = db.Devices.Find(waypoint.Devices.First.Id)
            If DateDiff(DateInterval.Second, d.LastCheckin.Value, Now) > CHECK_IN_INTERVAL * 5 Then
                d.Status = "Offline | Not Checking In"
                waypoint.Status = "Offline | Not Checking In"
            End If
            db.Entry(waypoint).State = EntityState.Modified
            db.Entry(d).State = EntityState.Modified
            db.SaveChanges()

            Return waypoint
        End Function
    End Class
End Namespace