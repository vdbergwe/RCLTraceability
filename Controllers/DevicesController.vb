Imports System.Data.Entity
Imports System.Net
Imports System.Net.Mail
Imports Intranet.Communications

Namespace Controllers
    Public Class DevicesController
        Inherits Controller
        Private Shared PageMessage As String
        Private db As New OMD_DatawarehouseEntities
        ' GET: Device_Registration                                              DONE FE v4
        Function Device_Registration(Id As Integer?) As ActionResult
            Dim device = db.Devices.Find(Id)
            If IsNothing(device) Then
                Return HttpNotFound()
            End If
            'Check if device is authenticated
            device = Logic.Device_Logic.check_Security(device)
            device = Logic.Device_Logic.check_Software(device)
            device = Logic.Device_Logic.check_Batch(device)
            device = Logic.Device_Logic.check_Hardware(device)
            Dim result = Logic.Device_Logic.get_Meta_Configuration(device)
            Return Json(result, JsonRequestBehavior.AllowGet)
        End Function
        ' GET: Device_CheckIn                                                   DONE FE v4
        Function Device_Checkin(data As Meta_Device) As ActionResult
            Dim s_device = db.Devices.Find(data.Id)
            If IsNothing(s_device) Then
                Return HttpNotFound()
            End If
            ' Strip Device From Payload to run checks and updates
            Dim r_device As New Device With {
                .Id = data.Id,
                .Description = data.Description,
                .IP = data.IP,
                .CurrentOperatorId = data.CurrentOperatorId,
                .HardwareVersion = data.HardwareVersion,
                .LastCheckin = data.LastCheckin,
                .LastReportedStatus = data.LastReportedStatus,
                .RequiresUpdate = data.RequiresUpdate,
                .RequiresSupport = data.RequiresSupport,
                .NetworkInformation = data.NetworkInformation,
                .NetworkConfigSubnet = data.NetworkConfigSubnet,
                .NetworkConfigIP = data.NetworkConfigIP,
                .NetworkConfigGateway = data.NetworkConfigGateway,
                .NetworkConfigDNS = data.NetworkConfigDNS,
                .MAC = data.MAC,
                .LocalWebServerUrlPORT = data.LocalWebServerUrlPORT,
                .LockedOut = data.LockedOut,
                .LockedOutBy = data.LockedOutBy,
                .LockedOutOn = data.LockedOutOn,
                .SecurityKey = data.SecurityKey,
                .SerialNumber = data.SerialNumber,
                .SoftwareVersion = data.SoftwareVersion,
                .Status = data.Status,
                .StorageInformation = data.StorageInformation,
                .Switch = data.Switch,
                .SwitchPort = data.SwitchPort,
                .Type = data.Type,
                .Waypoint = data.Waypoint1.Id,
                .Waypoint1 = Nothing
                }
            Dim r_Waypoint = New Waypoint With {
                .Id = data.Waypoint1.Id,
                .Description = data.Waypoint1.Description,
                .HasPrinter = data.Waypoint1.HasPrinter,
                .HasScanner = data.Waypoint1.HasScanner,
                .LoadCapcity = data.Waypoint1.LoadCapcity,
                .Location = data.Waypoint1.Location,
                .Status = data.Waypoint1.Status,
                .Type = data.Waypoint1.Type,
                .UOM = data.Waypoint1.UOM,
                .Plants_Locations = db.Plants_Locations.Find(data.Waypoint1.Location)
                }
            r_device.Waypoint1 = r_Waypoint
            Dim r_NumberBank = New Waypoints_NumberBanks
            If data.Waypoint1.Type = "PAS" Then
                If IsNothing(data.Waypoint1.Waypoints_NumberBanks) = True Then
                    r_NumberBank = db.Waypoints_NumberBanks.FirstOrDefault(Function(f) f.Status = "New")
                Else
                    r_NumberBank = New Waypoints_NumberBanks With {
                        .Id = data.Waypoint1.Waypoints_NumberBanks.Id,
                        .Bank = data.Waypoint1.Waypoints_NumberBanks.Bank,
                        .Created = data.Waypoint1.Waypoints_NumberBanks.Created,
                        .Depleted = data.Waypoint1.Waypoints_NumberBanks.Depleted,
                        .Device = data.Description,
                        .FirstNumber = data.Waypoint1.Waypoints_NumberBanks.FirstNumber,
                        .LastIssued = data.Waypoint1.Waypoints_NumberBanks.LastIssued,
                        .LastNumber = data.Waypoint1.Waypoints_NumberBanks.LastNumber,
                        .Prefix = data.Waypoint1.Waypoints_NumberBanks.Prefix,
                        .Released = data.Waypoint1.Waypoints_NumberBanks.Released,
                        .Reserved = data.Waypoint1.Waypoints_NumberBanks.Reserved,
                        .Root = data.Waypoint1.Waypoints_NumberBanks.Root,
                        .Status = data.Waypoint1.Waypoints_NumberBanks.Status,
                        .Waypoint = data.Waypoint1.Id,
                        .Waypoint1 = db.Waypoints.Find(data.Waypoint1.Id)
                        }
                    r_NumberBank = Logic.Device_Logic.check_NumberBanks(r_NumberBank)
                End If
            End If
            r_device = Logic.Device_Logic.check_Security(r_device)
            r_device = Logic.Device_Logic.check_Batch(r_device)
            r_device = Logic.Device_Logic.check_Operator(r_device)
            r_device.LastCheckin = Now()
            Dim result = Logic.Device_Logic.get_Meta_Configuration(r_device)
            Return Json(result, JsonRequestBehavior.AllowGet)
        End Function
        ' GET: Device_Endpoints                                                 DONE FE v4
        Function Device_Endpoints(Id As Integer?) As JsonResult
            Dim device = db.Devices.Find(Id)
            Dim check = Logic.Device_Logic.Check_Device(device)
            Dim result = db.Software_Services.ToList()
            If device.Type = "Traceability Waypoint" Then
                result = db.Software_Services.Where(Function(f) f.Type = "Waypoint Endpoint").ToList()
            ElseIf device.Type = "Sartorius Scale Connector" Then
                result = db.Software_Services.Where(Function(f) f.Type = "Scales Endpoint").ToList()
            End If
            Response.ContentType = "application/json"
            Return Json(result, JsonRequestBehavior.AllowGet)
        End Function
        ' GET: Get_Device_Products                                              DONE FE v4
        Function Get_Device_Products() As ActionResult
            Dim result = From b In db.Products.Where(Function(f) f.Status = "Active" And f.Labels IsNot Nothing And f.ExpiryDays IsNot Nothing) Select New Meta_Devices.Product() With {
                                                                                                .Id = b.Id,
                                                                                                .PLU = b.PLU,
                                                                                                .Description = b.Description,
                                                                                                .Commodity = b.Commodity,
                                                                                                .ConsumerBarcode = b.ConsumerBarcode,
                                                                                                .SalesUnitBarcode = b.SalesUnitBarcode,
                                                                                                .ConsumerUnits = b.ConsumerUnits,
                                                                                                .Packaging = b.Packaging,
                                                                                                .ProducedBy = b.ProducedBy,
                                                                                                .SalesUnits = b.SalesUnits,
                                                                                                .Status = b.Status,
                                                                                                .TareWeight = b.TareWeight,
                                                                                                .Type = b.Type,
                                                                                                .HUTargetWeight = b.HUTargetWeight,
                                                                                                .TargetWeight = b.TargetWeight,
                                                                                                .UOM = b.UOM,
                                                                                                .Expiry = b.ExpiryDays,
                                                                                                .Labels = b.Labels,
                                                                                                .QCSampleSize = b.QCSampleSize
                                                                                                }
            If IsNothing(result) Then
                Return HttpNotFound()
            End If
            Return Json(result, JsonRequestBehavior.AllowGet)
        End Function
        ' GET: Get_Device_Operators                                             DONE FE v4
        Function Get_Device_Operators() As ActionResult
            Dim result = db.Devices_Operators.ToList()
            If IsNothing(result) Then
                Return HttpNotFound()
            End If
            Return Json(result, JsonRequestBehavior.AllowGet)
        End Function
        'Mobile App Control                                                     NOT STARTED FE v4
        Function MobileAppRegistration(device As Device) As ActionResult
            Dim CheckExisting = db.Devices.Find(device.Id)
            If IsNothing(CheckExisting) Then
                Dim nd = New Device With {
                    .Description = device.Description,
                    .IP = Request.UserHostAddress,
                    .MAC = device.MAC,
                    .SerialNumber = device.SerialNumber,
                    .Status = device.Status,
                    .Type = device.Type,
                    .Switch = "Mobile Connection",
                    .SwitchPort = 0,
                    .SoftwareVersion = device.SoftwareVersion,
                    .HardwareVersion = device.HardwareVersion,
                    .NetworkInformation = device.NetworkInformation,
                    .StorageInformation = ""
                    }
                db.Devices.Add(nd)
                db.SaveChanges()
                device = nd
            Else
                device.IP = Request.UserHostAddress
                device.Status = "Online"
                db.Entry(device).State = EntityState.Modified
                db.SaveChanges()
            End If
            Return Json(device, JsonRequestBehavior.AllowGet)
        End Function
        'Device Control                                                         Busy FE v4
        'Get Reboot                                                             DONE FE v4
        Function Device_Control(id As Integer?, SSHFunction As String)
            Dim device = db.Devices.Find(id)
            Dim result = Nothing
            If SSHFunction = "Reboot" Then
                result = Layer_SSH.Reboot_Device(device)
            End If
            If SSHFunction = "Repos" Then
                result = Layer_SSH.Device_Update_Repos(device)
            End If
            If SSHFunction = "Python" Then
                result = Layer_SSH.Device_Install_Python(device)
            End If
            If SSHFunction = "pip" Then
                result = Layer_SSH.Device_Install_Pip(device)
            End If
            If SSHFunction = "GuiZero" Then
                result = Layer_SSH.Device_Install_GuiZero(device)
            End If
            If SSHFunction = "Pillow" Then
                result = Layer_SSH.Device_Install_Pillow(device)
            End If
            If SSHFunction = "7z" Then
                result = Layer_SSH.Device_Install_7z(device)
            End If
            If SSHFunction = "Julian" Then
                result = Layer_SSH.Device_Install_Julian(device)
            End If
            If SSHFunction = "Labelary" Then
                result = Layer_SSH.Device_Install_Labelary(device)
            End If
            If SSHFunction = "Zebra" Then
                result = Layer_SSH.Device_Install_Zebra(device)
            End If
            If SSHFunction = "Lock" Then
                result = Layer_SSH.Device_Software_Lock(device)
            End If
            If SSHFunction = "Backup" Then
                result = Layer_SSH.Device_Backup_Software(device)
            End If
            If SSHFunction = "Set_Host" Then
                result = Layer_SSH.Device_Set_HostName(device)
            End If
            If SSHFunction = "Directories" Then
                result = Layer_SSH.Device_Create_Directories(device)
            End If
            If SSHFunction = "Decompress" Then
                result = Layer_SSH.Device_Decompress_Software(device)
            End If
            If IsNothing(result) = False Then
                ViewBag.pageMsg = result
                ViewBag.MsgBgColor = "Red"
                ViewBag.pageMsgColor = "White"
                Return RedirectToAction("Details", New With {.Id = id})
            End If
            Return PartialView(device)
        End Function
        'SSH Sudo Update                                                        DONE FE v4
        Function Update_Device(id As Integer?)
            Dim device = db.Devices.Find(id)
            Try
                PageMessage = Layer_SSH.Update_Device_Software(device)
            Catch ex As Exception
                PageMessage = "Reboot Failed"
            End Try
            Return RedirectToAction("Details", New With {id})
        End Function
        ' GET: Get_Software                                                     DONE FE v4
        Function Get_Software(id As Integer?)
            Dim device = db.Devices.Find(id)
            Dim result = Layer_SSH.Update_Device_Software(device)
            Try
                PageMessage = result
            Catch ex As Exception
                PageMessage = "Software Send Failed Failed"
            End Try
            result = Layer_SSH.Send_Software(device)
            Try
                PageMessage = result
            Catch ex As Exception
                PageMessage = "Software Send Failed Failed"
            End Try
            Return RedirectToAction("Details", New With {device.Id})
        End Function
        'SSH Sudo Consule                                                       NOT STARTED FE v4
        Function Get_Device_Console(Id As Integer) As ActionResult
            ViewBag.ConsoleContent = ""
            ViewBag.ConsoleSendCommand = ""
            ViewBag.ConsoleReturn = ""
            ViewBag.ConsoleIsConnected = ""

        End Function
        'GUI v4
        ' GET: Devices/Details/5                                                DONE FE v4
        Function Details(ByVal id As Integer?, IsPartial As Boolean?) As ActionResult
            ViewBag.pageMsg = PageMessage
            ViewBag.IsPartial = IsPartial
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim device As Device = db.Devices.Find(id)
            If IsNothing(device) Then
                Return HttpNotFound()
            End If
            ViewBag.CPUTemp = Layer_SSH.Get_CPU_Temp(device)
            If IsPartial = True Then
                Return PartialView(device)
            End If
            Return View(device)
        End Function
        ' GET: Devices/Edit/5                                                   DONE FE v4
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim device As Device = db.Devices.Find(id)
            If device.LockedOut <> True And device.SecurityKey Is Nothing Then
                device.SecurityKey = Guid.NewGuid.ToString()
            End If
            If IsNothing(device) Then
                Return HttpNotFound()
            End If
            ViewBag.Type = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "Device Types"), "Description", "Description", device.Type)
            ViewBag.Waypoint = New SelectList(db.Waypoints, "Id", "Description", device.Waypoint)

            Return View(device)
        End Function
        ' POST: Devices/Edit/5                                                  DONE FE v4
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,IP,Type,Status,MAC,SwitchPort,Switch,Location,SerialNumber,HardwareVersion,SoftwareVersion,StorageInformation,NetworkInformation,LocalWebServerUrlPORT,RequiresUpdate,LastCheckin,LastReportedStatus,NetworkConfigIP,NetworkConfigSubnet,NetworkConfigGateway,NetworkConfigDNS,LockedOut,LockedOutBy,LockedOutOn,SecurityKey,CurrentOperatorId,RequiresSupport,Waypoint")> device As Device) As ActionResult
            If device.LockedOut <> True And device.SecurityKey Is Nothing Then
                device.SecurityKey = Guid.NewGuid.ToString()
                device.LockedOutBy = Nothing
                device.LockedOutOn = Nothing
            End If
            If ModelState.IsValid Then
                db.Entry(device).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Type = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "Device Types"), "Description", "Description", device.Type)
            ViewBag.Waypoint = New SelectList(db.Waypoints, "Id", "Description", device.Waypoint)
            Return View(device)
        End Function
        ' GET: Devices                                                          NOT STARTED FE v4
        Function Index(IsPartial As Boolean?, Id As Integer?, FilterBy As String) As ActionResult
            ViewBag.IsPartial = IsPartial
            Dim devices = db.Devices.Include(Function(d) d.Waypoint1).OrderBy(Function(o) o.Type)
            If Id IsNot Nothing And IsNothing(FilterBy) = True Then
                devices = devices.Where(Function(f) f.Waypoint1.Location = Id)
            ElseIf Id IsNot Nothing And FilterBy = "BU" Then
                devices = devices.Where(Function(f) f.Waypoint1.Plants_Locations.Business_Units_Plants.Business_Units.Id = Id)
            ElseIf Id IsNot Nothing And FilterBy = "PL" Then
                devices = devices.Where(Function(f) f.Waypoint1.Plants_Locations.PlantId = Id)
            ElseIf Id IsNot Nothing And FilterBy = "LO" Then
                devices = devices.Where(Function(f) f.Waypoint1.Location = Id)
            ElseIf FilterBy = "Online" Then
                devices = devices.Where(Function(f) f.Status = "Online")
            ElseIf FilterBy = "Offline" Then
                devices = devices.Where(Function(f) f.Status.Contains("Offline"))
            ElseIf FilterBy = "Waypoints" Then
                devices = devices.Where(Function(f) f.Type.Contains("Waypoint"))
            ElseIf FilterBy = "Scales" Then
                devices = devices.Where(Function(f) f.Type.Contains("Scale"))
            End If
            If IsPartial = True Then
                Return PartialView(devices.ToList())
            Else
                Return View(devices.ToList())
            End If
        End Function
        ' GET: Devices/Create                                                   NOT STARTED FE v4
        Function Create() As ActionResult
            ViewBag.Location = New SelectList(db.Plants_Locations, "Id", "Description")
            ViewBag.Type = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "Device Types"), "Description", "Description")
            Return View()
        End Function
        ' POST: Devices/Create                                                  NOT STARTED FE v4
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,IP,Type,Status,MAC,SwitchPort,Switch,Location,SerialNumber")> ByVal device As Device) As ActionResult
            If ModelState.IsValid Then
                db.Devices.Add(device)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Location = New SelectList(db.Plants_Locations, "Id", "Description", device.Waypoint1.Location)
            ViewBag.Type = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "Device Types"), "Description", "Description", device.Type)

            Return View(device)
        End Function
        ' GET: Devices/Delete/5                                                 NOT STARTED FE v4
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim device As Device = db.Devices.Find(id)
            If IsNothing(device) Then
                Return HttpNotFound()
            End If
            Return View(device)
        End Function
        ' POST: Devices/Delete/5                                                NOT STARTED FE v4
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim device As Device = db.Devices.Find(id)
            db.Devices.Remove(device)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
