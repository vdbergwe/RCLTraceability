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
Imports Intranet.Logic.Waypoint_Logic

Namespace Logic
    Public Class Device_Logic
        Private Shared db As New OMD_DatawarehouseEntities
        Private Shared db_commit As New OMD_DatawarehouseEntities
        Private Shared FE_Version As Software_Settings = db.Software_Settings.Find("a5415c91-2ebb-407e-bc19-c1751b606715")
        Private Shared Waypoints_Version As Software_Settings = db.Software_Settings.Find("975f034e-27f4-4222-ac11-52dc6a359113")
        Private Shared MobileApp_Version As Software_Settings = db.Software_Settings.Find("53af1943-340a-44cc-9b97-2482634739ca")
        Private Shared Scales_Version As Software_Settings = db.Software_Settings.Find("72798793-e313-4821-98fa-e3b1b295f4c9")
        Private Shared s As New SystemHealthTrapper.SystemHealthTrapper
        Private Shared TrapperEnabled As String = db.Software_Settings.Find("87bb6d48-402d-433d-88e6-8f763384a3d7").SettingValue
        Public Shared Function Check_Device(device As Device)
            device.LastReportedStatus = device.Status
            device.Status = "Online"
            device.LastCheckin = Now()
            Dim t As New TrapperEvent
            If IsNothing(device) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            device = check_Operator(device)
            '6. Check Network
            device = check_Network(device)
            '7. Check Device Waypoint
            device = check_Device_Waypoint(device)
            '8. Check Device Number Bank
            Dim result = get_Meta_Configuration(device)
            Return result
            If device.Type = "Mobile Device" And device.SoftwareVersion <> MobileApp_Version.SettingValue Then
                device.Status = "Check-In - Requires Software Update \ Configuration Error"
                device.RequiresUpdate = False
                t.Event = "Check-In - Requires Software Update \ Configuration Error"
                t.Severity = "Low"
                If TrapperEnabled = "True" Then
                    s.SendAsync(t)
                End If
                Return (device)
            End If
            If device.Type = "Sartorius Scale Connector" And device.SoftwareVersion <> Scales_Version.SettingValue Then
                device.Status = "Check-In - Requires Software Update \ Configuration Error"
                device.RequiresUpdate = True
                t.Event = "Check-In - Requires Software Update \ Configuration Error"
                t.Severity = "Low"
                If TrapperEnabled = "True" Then
                    s.SendAsync(t)
                End If
                Return (device)
            End If
            Return device
        End Function
        Public Shared Function check_Security(device As Device)
            Dim t As New TrapperEvent
            t.Origin = device.Description
            t.Source = "Device Check | Security"
            device.Status = "Security | Check"
            If device.LockedOut = True Or device.SecurityKey Is Nothing Then
                t.Event = "Device Check | Security | Failed"
                device.LockedOut = True
                device.Status = "Security | Failed"
                device.LockedOutOn = IIf(device.LockedOutOn Is Nothing, Now, device.LockedOutOn)
                device.LockedOutBy = IIf(device.LockedOutBy Is Nothing, "AUTOLOCKER", device.LockedOutOn)
                device.SecurityKey = Nothing
                If device.LockedOutBy = "AUTOLOCKER" And device.LockedOutOn.Value.AddDays(1) > Now() Then
                    device.RequiresSupport = True
                    t.Event = "Device Security Check | Failed | Device Auto Locked Out"
                    t.Severity = "Serious"
                End If
                If TrapperEnabled = "True" Then
                    s.SendAsync(t)
                End If
            End If
            Dim transactionUGUID As Guid = Guid.NewGuid()
            device.SecurityKey = transactionUGUID.ToString()
            device.LockedOut = False
            device.Status = "Online"
            device.LockedOutOn = Nothing
            device.LockedOutBy = Nothing
            Dim d = New Device With {
                .CurrentOperatorId = device.CurrentOperatorId,
                .Description = device.Description,
                .HardwareVersion = device.HardwareVersion,
                .Id = device.Id,
                .IP = device.IP,
                .LastCheckin = device.LastCheckin,
                .LastReportedStatus = device.LastReportedStatus,
                .LocalWebServerUrlPORT = device.LocalWebServerUrlPORT,
                .LockedOut = device.LockedOut,
                .LockedOutBy = device.LockedOutBy,
                .LockedOutOn = device.LockedOutOn,
                .MAC = device.MAC,
                .NetworkConfigDNS = device.NetworkConfigDNS,
                .NetworkConfigGateway = device.NetworkConfigGateway,
                .NetworkConfigIP = device.NetworkConfigIP,
                .NetworkConfigSubnet = device.NetworkConfigSubnet,
                .NetworkInformation = device.NetworkInformation,
                .RequiresSupport = device.RequiresSupport,
                .RequiresUpdate = device.RequiresUpdate,
                .SecurityKey = device.SecurityKey,
                .SerialNumber = device.SerialNumber,
                .SoftwareVersion = device.SoftwareVersion,
                .Status = device.Status,
                .StorageInformation = device.StorageInformation,
                .Switch = device.Switch,
                .SwitchPort = device.SwitchPort,
                .Type = device.Type,
                .Waypoint = device.Waypoint,
                .Waypoint1 = device.Waypoint1
                }
            Return d
            If device.Type Is Nothing Or device.Type = "" Then
                device.Status = "Offline | Configuration | No Type"
                device.Type = "New Device"
                device.RequiresUpdate = True
                t.Event = "No Device Type"
                t.Severity = "Serious"
            End If
            If device.Type Is Nothing Or device.Type = "New Device" Or device.Type = "" And device.Waypoint IsNot Nothing Then
                device.Type = "Traceability Waypoint"
                device.Status = "Check-In - Requires Software Update \ Configuration Error"
                device.RequiresUpdate = True
                t.Event = "New Device Detected"
                t.Severity = "Low"
            End If
        End Function
        Public Shared Function check_Software(device As Device)
            Dim t As New TrapperEvent
            t.Origin = device.Description
            t.Source = "Device Check | Software"
            Try
                If device.Type = "Traceability Waypoint" And IsNothing(device.SoftwareVersion) = True Then
                    device.SoftwareVersion = Waypoints_Version.SettingValue
                End If
                If device.Type = "Traceability Waypoint" And IsNothing(device.SoftwareVersion) <> Waypoints_Version.SettingValue Then
                    device.RequiresUpdate = True
                    device.RequiresSupport = True
                End If
            Catch ex As Exception
                t.Event = "Device Check | Software | Failed"
                t.Severity = "Serious"
                If TrapperEnabled = "True" Then
                    s.SendAsync(t)
                End If
            End Try
            Return device
        End Function
        Public Shared Function check_Batch(device As Device)
            Dim t As New TrapperEvent
            t.Origin = device.Description
            t.Source = "Device Check | Batch"
            Try
                Batch_Functions.BatchRun(device.Waypoint1.Plants_Locations.PlantId)
            Catch ex As Exception
                device.RequiresSupport = True
                device.LockedOut = True
                t.Event = "Device Check | Batch | Device Auto Locked Out"
                t.Severity = "Serious"
                If TrapperEnabled = "True" Then
                    s.SendAsync(t)
                End If
            End Try
            Return device
        End Function
        Public Shared Function check_Operator(device As Device)
            If IsNothing(device.CurrentOperatorId) = True Then
                device.Status = "Operator | Logged Out"
            Else
                device.Status = "Operator | Logged In"
            End If
            Return device
        End Function
        Public Shared Function check_Hardware(device As Device)
            'device = Layer_SSH.Get_SystemInfo(device)
            Return device
        End Function
        Public Shared Function check_Network(device As Device)
            Dim t As New TrapperEvent
            t.Origin = device.Description
            t.Source = "Device Check | Network"
            Try
                Dim ip = System.Web.HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
                If ip Is Nothing Then
                    ip = System.Web.HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")
                End If
                device.IP = ip
                Try
                    device = Layer_SSH.Get_NetworkInfo(device)
                Catch ex As Exception

                End Try
            Catch ex As Exception
                t.Event = "Device Check | Network | Failed"
                t.Severity = "Serious"
                If TrapperEnabled = "True" Then
                    s.SendAsync(t)
                End If
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End Try
            Return device
        End Function
        Public Shared Function check_NumberBanks(numberBank As Waypoints_NumberBanks)
            Dim s_NumberBank = db.Waypoints_NumberBanks.Find(numberBank.Id)
            If IsNothing(s_NumberBank) = False Then
                s_NumberBank.Id = numberBank.Id
                s_NumberBank.Bank = numberBank.Bank
                s_NumberBank.Created = numberBank.Created
                s_NumberBank.Depleted = numberBank.Depleted
                s_NumberBank.Device = numberBank.Device
                s_NumberBank.FirstNumber = numberBank.FirstNumber
                s_NumberBank.LastIssued = numberBank.LastIssued
                s_NumberBank.LastNumber = numberBank.LastNumber
                s_NumberBank.Prefix = numberBank.Prefix
                s_NumberBank.Released = numberBank.Released
                s_NumberBank.Reserved = numberBank.Reserved
                s_NumberBank.Root = numberBank.Root
                s_NumberBank.Status = numberBank.Status
                s_NumberBank.Waypoint = numberBank.Waypoint
                db.Entry(s_NumberBank).State = EntityState.Modified
                db.SaveChanges()
                Return s_NumberBank
            End If
            Return s_NumberBank

        End Function
        Public Shared Function get_Meta_Configuration(device As Device)
            Dim w = db.Waypoints.Single(Function(r) r.Id = device.Waypoint)
            Dim pb = db.Production_Batches.Single(Function(r) r.Status = "Current" And r.Plants_Shifts.Plant = device.Waypoint1.Plants_Locations.PlantId)
            Dim nb = db.Waypoints_NumberBanks.FirstOrDefault(Function(r) r.Status = "Allocated" And r.Waypoint = w.Id)
            Dim wc = db.Waypoints_Configurations.Where(Function(r) r.Waypoint = w.Id Or r.IsGlobalSetting = True).ToList()
            Dim result As New Meta_Device With {
                .CurrentOperatorId = device.CurrentOperatorId,
                .Description = device.Description,
                .HardwareVersion = device.HardwareVersion,
                .Id = device.Id,
                .IP = device.IP,
                .LastCheckin = Now().ToString(),
                .LastReportedStatus = device.Status,
                .Status = device.Status,
                .LocalWebServerUrlPORT = device.LocalWebServerUrlPORT,
                .LockedOut = device.LockedOut,
                .LockedOutBy = device.LockedOutBy,
                .LockedOutOn = device.LockedOutOn,
                .MAC = device.MAC,
                .NetworkConfigDNS = device.NetworkConfigDNS,
                .NetworkConfigIP = device.NetworkConfigIP,
                .NetworkConfigGateway = device.NetworkConfigGateway,
                .NetworkConfigSubnet = device.NetworkConfigSubnet,
                .NetworkInformation = device.NetworkInformation,
                .RequiresSupport = device.RequiresSupport,
                .RequiresUpdate = device.RequiresUpdate,
                .SecurityKey = device.SecurityKey,
                .SerialNumber = device.SerialNumber,
                .SoftwareVersion = device.SoftwareVersion,
                .StorageInformation = device.StorageInformation,
                .Switch = device.Switch,
                .SwitchPort = device.SwitchPort,
                .Type = device.Type
                }
            Dim waypoint As New Meta_Waypoint With {
                .Id = device.Waypoint1.Id,
                .Description = device.Waypoint1.Description,
                .LoadCapcity = device.Waypoint1.LoadCapcity,
                .Status = device.Waypoint1.Status,
                .Type = device.Waypoint1.Type,
                .UOM = device.Waypoint1.UOM,
                .HasPrinter = device.Waypoint1.HasPrinter,
                .HasScanner = device.Waypoint1.HasScanner,
                .Location = device.Waypoint1.Location,
                .Waypoints_Configurations = New List(Of Meta_Waypoint.Meta_Waypoint_Configs)
                }
            result.Waypoint1 = waypoint
            Dim numberBank = New Meta_Waypoint.Meta_Waypoint_NumberBank With {
                .Bank = "",
                .Id = 0,
                .Created = Nothing,
                .Depleted = Nothing,
                .Status = "N\A",
                .Device = Nothing,
                .FirstNumber = Nothing,
                .LastIssued = 0,
                .Prefix = Nothing,
                .LastNumber = 1,
                .Released = Nothing,
                .Reserved = Nothing,
                .Root = Nothing,
                .Waypoint = Nothing
                }
            If device.Waypoint1.Type = "PAS" Then
                If IsNothing(nb) Then
                    nb = db.Waypoints_NumberBanks.FirstOrDefault(Function(r) r.Status = "New" And r.Waypoint <> w.Id)
                    nb.Status = "Allocated"
                    nb.Reserved = Now
                    nb.Waypoint = device.Waypoint
                    nb.Device = device.Description
                    db.Entry(nb).State = EntityState.Modified
                    db.SaveChanges()
                End If
                numberBank = New Meta_Waypoint.Meta_Waypoint_NumberBank With {
                .Bank = nb.Bank,
                .Id = nb.Id,
                .Created = nb.Created,
                .Depleted = nb.Depleted,
                .Status = nb.Status,
                .Device = nb.Device,
                .FirstNumber = nb.FirstNumber,
                .LastIssued = nb.LastIssued,
                .Prefix = nb.Prefix,
                .LastNumber = nb.LastNumber,
                .Released = nb.Released,
                .Reserved = nb.Reserved,
                .Root = nb.Root,
                .Waypoint = nb.Waypoint
                }

            End If
            result.Waypoint1.Waypoints_NumberBanks = numberBank

            Dim productionbatch As New Meta_Waypoint.Meta_Production_Batches With {
                .Id = pb.Id,
                .BatchCreated = pb.BatchCreated,
                .BatchDate = pb.BatchDate,
                .BatchEnded = pb.BatchEnded,
                .Description = pb.Description,
                .Plant = pb.Plant,
                .Shift = pb.Shift,
                .Status = pb.Status,
                .Type = pb.Type
                }
            result.Waypoint1.Waypoints_Batches = productionbatch
            For Each i In wc
                Dim c As New Meta_Waypoint.Meta_Waypoint_Configs With {
                    .Active = i.Active,
                    .Id = i.Id,
                    .SettingGroup = i.SettingGroup,
                    .IsGlobalSetting = i.IsGlobalSetting,
                    .SettingName = i.SettingName,
                    .SettingSubGroup = i.SettingSubGroup,
                    .SettingType = i.SettingType,
                    .SettingValue = i.SettingValue,
                    .Waypoint = i.Waypoint
                    }
                waypoint.Waypoints_Configurations.Add(c)
            Next
            Dim d = db.Devices.Find(device.Id)
            d.LastCheckin = Now()
            d.Status = "Online"
            d.LastReportedStatus = device.Status
            db.Entry(d).State = EntityState.Modified
            db.SaveChanges()
            Return result
        End Function
    End Class
End Namespace