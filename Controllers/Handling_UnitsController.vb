Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class Handling_UnitsController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities
        Private db2 As New zzSAPIntegrationTSHEntities

        ' GET: Handling_Units
        Function Index(IsPartial As Boolean?, Id As Integer?, FilterBy As String, Size As Integer?) As ActionResult
            Dim handling_Units = db.Handling_Units.Include(Function(h) h.Production_Batches).Include(Function(h) h.Product1).Include(Function(h) h.Waypoints_NumberBanks).OrderByDescending(Function(o) o.Created)
            ViewBag.IsPartial = IsPartial
            If Id IsNot Nothing And FilterBy = "Batch" Then
                handling_Units = handling_Units.Where(Function(f) f.Batch = Id)
            End If
            If IsNothing(Size) = False Then
                handling_Units = handling_Units.Take(Size)
            End If
            If IsPartial = True Then
                Return PartialView(handling_Units.ToList())
            Else
                Return View(handling_Units.ToList())
            End If
        End Function
        ' GET: Handling_Units
        Function Get_CPC_List(DeviceId As Integer?, Status As String) As ActionResult
            Dim AgeCalc = Now()
            Dim Device = db.Devices.Find(DeviceId)
            Dim result = From b In db.Handling_Units.Where(Function(s) s.Status.Contains(Status) And s.Created >= "2023-08-15") Select New Intranet.Meta_Devices.handling_Unit() With {
                .Id = b.Id,
                .Batch = b.Batch,
                .Created = b.Created,
                .CreatedBy = b.CreatedBy,
                .Device = b.Device,
                .NumberBank = b.NumberBank,
                .Product = b.Product,
                .SSCC = b.SSCC,
                .Status = b.Status,
                .Age = 0,
                .ProductDescription = b.Product1.Description,
                .Berth = b.Berth,
                .ScannedCode = b.ScannedCode,
                .Trailer = b.Trailer,
                .Horse = b.Horse
                       }
            If IsNothing(result) Then
                Return HttpNotFound()
            End If
            Return Json(result, JsonRequestBehavior.AllowGet)
        End Function
        'GET: Handling_Units
        Function Get_GUS_List(DeviceId As Integer?, Status As String) As ActionResult
            Dim AgeCalc = Now()
            Dim Device = db.Devices.Find(DeviceId)
            Dim result = From b In db.Handling_Units.Where(Function(s) s.Status.Contains(Status)).Take(10).OrderByDescending(Function(a) a.Created) Select New Meta_Devices.handling_Unit() With {
                .Id = b.Id,
                .Batch = b.Batch,
                .Created = b.Created,
                .CreatedBy = b.CreatedBy,
                .Device = b.Device,
                .NumberBank = b.NumberBank,
                .Product = b.Product,
                .SSCC = b.SSCC,
                .Status = b.Status,
                .Age = 0,
                .ProductDescription = b.Product1.Description,
                .Berth = b.Berth,
                .ScannedCode = b.ScannedCode,
                .Trailer = b.Trailer,
                .Horse = b.Horse
                        }

            If IsNothing(result) Then
                Return HttpNotFound()
            End If
            Return Json(result, JsonRequestBehavior.AllowGet)
        End Function
        ' GET: Handling_Units/Details/5
        Function Details(id As Integer?, SSCC As String) As ActionResult
            Dim handling_Units As Handling_Units = db.Handling_Units.Find(id)
            If IsNothing(id) Then
                handling_Units = db.Handling_Units.Single(Function(s) s.SSCC = SSCC)
            End If
            If IsNothing(handling_Units) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            If IsNothing(handling_Units) Then
                Return HttpNotFound()
            End If
            Return View(handling_Units)
        End Function
        ' POST: Handling_Units/Create
        <HttpPost()>
        Function PAS(handling_Units As Handling_Units) As ActionResult
            Dim c = db.Handling_Units.Where(Function(s) s.SSCC = handling_Units.SSCC)
            If ModelState.IsValid And c.Count = 0 Then
                db.Handling_Units.Add(handling_Units)
                Dim LogEvent As New Log With {
                    .AlertLevel = "Information",
                    .Description = "New Handling Unit Registered",
                    .[Event] = "Handling Unit Registration",
                    .EventRaised = Now(),
                    .RecordType = "Handling Units",
                    .RelatedRecord = handling_Units.Id
                    }
                Dim NumberRange = db.Waypoints_NumberBanks.Find(handling_Units.NumberBank)
                NumberRange.LastIssued = Left(Right(handling_Units.SSCC, 6), 5)
                db.Entry(NumberRange).State = EntityState.Modified
                Dim HandlingUnitMovement As New Handling_Units_Movements With {
                .Created = handling_Units.Created,
                .CreatedBy = handling_Units.CreatedBy,
                .Device = handling_Units.Device,
                .Type = "PAS",
                .Handling_UnitId = handling_Units.Id,
                .Status = "Registered at PAS"
                }
                db.Logs.Add(LogEvent)
                db.Handling_Units_Movements.Add(HandlingUnitMovement)
                Dim sapHU As New zTraceOut_SSCCUnit With {
                .PData_BatchCode = db.Production_Batches.Find(handling_Units.Batch).Description,
                .Created = handling_Units.Created,
                .CreatedBy = handling_Units.CreatedBy,
                .SSCC = handling_Units.SSCC,
                .Label_GTIN = db.Products.Find(handling_Units.Product).SalesUnitBarcode,
                .ActualWeight = 0,
                .CreatedDate = handling_Units.Created.Value.Date,
                .CreatedTime = handling_Units.Created.Value.TimeOfDay,
                .Label_Country = handling_Units.Production_Batches.Plants_Shifts.Business_Units_Plants.Country,
                .Label_Description = handling_Units.Product1.Description,
                .MATNR = handling_Units.Product1.PLU,
                .WERKS = handling_Units.Production_Batches.Plants_Shifts.Business_Units_Plants.PlantCode,
                .PData_BestBefore = handling_Units.Created.Value.Date.AddDays(handling_Units.Product1.ExpiryDays),
                .PData_DateCode = handling_Units.Created.Value.DayOfYear,
                .PData_DateTime = handling_Units.Created,
                .PDet_ConsUnits = handling_Units.Product1.ConsumerUnits,
                .PDet_NetWt = handling_Units.Product1.TargetWeight,
                .PDet_OrdUnits = handling_Units.Product1.SalesUnits,
                .PDet_PCode = handling_Units.Product1.PLU,
                .Waypoint = handling_Units.Waypoints_NumberBanks.Waypoint1.Description,
                .WaypointId = handling_Units.Waypoints_NumberBanks.Waypoint1.Id,
                .ScannedGTIN = handling_Units.ScannedCode
                }
                Dim sapUnitMovement As New zTraceOut_SSCCMovements With {
                .OperatorID = handling_Units.CreatedBy,
                .MovementDesc = "Registered at PAS",
                .MovementDirection = "PAS",
                .SSCC = handling_Units.SSCC,
                .NewStatus = "Registered at PAS",
                .MovementTime = Now,
                .WaypointID = handling_Units.Waypoints_NumberBanks.Waypoint1.Id
                }
                db2.zTraceOut_SSCCUnit.Add(sapHU)
                db2.zTraceOut_SSCCMovements.Add(sapUnitMovement)
                db.SaveChanges()
                db.Dispose()
                db2.SaveChanges()
                db2.Dispose()
                Return Json(LogEvent, JsonRequestBehavior.AllowGet)
            End If
            Return Json(handling_Units, JsonRequestBehavior.AllowGet)
        End Function
        <HttpPost()>
        Function CPC(handling_Units As Handling_Units) As ActionResult
            Dim HandlingUnitDetails = db.Handling_Units.Find(handling_Units.Id)
            If handling_Units.Status = "ACCEPTED" Then
                If ModelState.IsValid Then
                    HandlingUnitDetails.Status = handling_Units.Status
                    HandlingUnitDetails.Horse = handling_Units.Horse
                    HandlingUnitDetails.Trailer = handling_Units.Trailer
                    HandlingUnitDetails.Berth = handling_Units.Berth
                    db.Entry(HandlingUnitDetails).State = EntityState.Modified
                    db.SaveChanges()
                    Dim HandlingUnitMovement As New Handling_Units_Movements With {
                    .Created = Now(),
                    .CreatedBy = handling_Units.CreatedBy,
                    .Device = handling_Units.Device,
                    .Type = "CPC",
                    .Handling_UnitId = handling_Units.Id,
                    .Status = handling_Units.Status,
                    .Horse = handling_Units.Horse,
                    .Trailer = handling_Units.Trailer,
                    .Berth = handling_Units.Berth
                    }
                    db.Handling_Units_Movements.Add(HandlingUnitMovement)
                    db.SaveChanges()
                End If
            ElseIf handling_Units.Status = "REJECT" Then
                HandlingUnitDetails.Status = handling_Units.Status
                HandlingUnitDetails.Horse = handling_Units.Horse
                HandlingUnitDetails.Trailer = handling_Units.Trailer
                HandlingUnitDetails.Berth = handling_Units.Berth
                If ModelState.IsValid Then
                    db.Entry(HandlingUnitDetails).State = EntityState.Modified
                    db.SaveChanges()
                    Dim HandlingUnitMovement As New Handling_Units_Movements With {
                        .Created = Now(),
                        .CreatedBy = handling_Units.CreatedBy,
                        .Device = handling_Units.Device,
                        .Type = "CPC",
                        .Handling_UnitId = handling_Units.Id,
                        .Status = handling_Units.Status,
                        .Horse = handling_Units.Horse,
                        .Trailer = handling_Units.Trailer,
                        .Berth = handling_Units.Berth
                        }
                    db.Handling_Units_Movements.Add(HandlingUnitMovement)
                    db.SaveChanges()
                End If
            ElseIf handling_Units.Status = "RELEASEALL" Then
                'Tag All HU Records on Train and Release All Check All Rejected are removed
                Dim Consignment = db.Handling_Units.Where(Function(t) t.Horse = handling_Units.Horse).ToList()
                If Consignment.Where(Function(f) f.Status <> "ACCEPTED" And f.Status <> "REJECT").Count = 0 Then
                    For Each i In Consignment.Where(Function(f) f.Status = "ACCEPTED")
                        i.Status = "From CPC"
                        If ModelState.IsValid Then
                            db.Entry(i).State = EntityState.Modified
                            db.SaveChanges()
                            Dim HandlingUnitMovement As New Handling_Units_Movements With {
                                .Created = Now(),
                                .CreatedBy = i.CreatedBy,
                                .Device = i.Device,
                                .Type = "CPC",
                                .Handling_UnitId = handling_Units.Id,
                                .Status = i.Status,
                                .Horse = i.Horse,
                                .Trailer = i.Trailer,
                                .Berth = i.Berth
                                }
                            db.Handling_Units_Movements.Add(HandlingUnitMovement)
                            db.SaveChanges()
                        End If
                    Next
                End If
            ElseIf handling_Units.Status = "RESET" Then
                Dim Consignment = db.Handling_Units.Where(Function(t) t.Horse = handling_Units.Horse).ToList()
                For Each i In Consignment
                    i.Status = "Synced"
                    i.Horse = Nothing
                    i.Trailer = Nothing
                    i.Berth = Nothing
                    If ModelState.IsValid Then
                        db.Entry(i).State = EntityState.Modified
                        db.SaveChanges()
                        Dim HandlingUnitMovement As New Handling_Units_Movements With {
                            .Created = Now(),
                            .CreatedBy = i.CreatedBy,
                            .Device = i.Device,
                            .Type = "CPC",
                            .Handling_UnitId = i.Id,
                            .Status = i.Status,
                            .Horse = i.Horse,
                            .Trailer = i.Trailer,
                            .Berth = i.Berth
                            }
                        db.Handling_Units_Movements.Add(HandlingUnitMovement)
                        db.SaveChanges()
                    End If
                Next
            End If
            Dim LogEvent As New Log With {
                .AlertLevel = "Information",
                .Description = handling_Units.Status + " | " + handling_Units.SSCC,
                .[Event] = "Handling Unit Movement",
                .EventRaised = Now(),
                .RecordType = "Handling Units",
                .RelatedRecord = handling_Units.Id
                }
            db.Logs.Add(LogEvent)
            db.SaveChanges()
            Dim results = New List(Of Meta_Devices.handling_Unit)
            Dim hus = db.Handling_Units.Where(Function(s) s.Horse = handling_Units.Horse)
            For Each b In hus
                Dim n As New Meta_Devices.handling_Unit With {
                    .Id = b.Id,
                    .Batch = b.Batch,
                    .Created = b.Created,
                    .CreatedBy = b.CreatedBy,
                    .Device = b.Device,
                    .NumberBank = b.NumberBank,
                    .Product = b.Product,
                    .SSCC = b.SSCC,
                    .Status = b.Status,
                    .Berth = b.Berth,
                    .ScannedCode = b.ScannedCode,
                    .Trailer = b.Trailer,
                    .Horse = b.Horse
                    }
                results.Add(n)
            Next
            Return Json(results, JsonRequestBehavior.AllowGet)
        End Function
        <HttpPost()>
        Function HU_Reject(SSCC As String, OperatorName As String, DeviceId As String) As ActionResult
            Dim HandlingUnit = db.Handling_Units.Find(SSCC)
            HandlingUnit.Status = "Rejected"
            Dim HandlingUnitMovement = New Handling_Units_Movements
            If ModelState.IsValid Then
                db.Entry(HandlingUnit).State = EntityState.Modified
                db.SaveChanges()
                HandlingUnitMovement = New Handling_Units_Movements With {
                    .Created = Now(),
                    .CreatedBy = OperatorName,
                    .Device = DeviceId,
                    .Type = "Rejected",
                    .Handling_UnitId = HandlingUnit.Id,
                    .Status = HandlingUnit.Status
                }
                db.Handling_Units_Movements.Add(HandlingUnitMovement)
                db.SaveChanges()
            End If
            Return Json(HandlingUnitMovement, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost()>
        Function GUS(handling_Units As Handling_Units) As ActionResult
            Dim HandlingUnitDetails = db.Handling_Units.Find(handling_Units.Id)
            If handling_Units.Status = "ACCEPTED" Then
                If ModelState.IsValid Then
                    HandlingUnitDetails.Status = handling_Units.Status
                    HandlingUnitDetails.Horse = handling_Units.Horse
                    HandlingUnitDetails.Trailer = handling_Units.Trailer
                    HandlingUnitDetails.Berth = handling_Units.Berth
                    db.Entry(HandlingUnitDetails).State = EntityState.Modified
                    db.SaveChanges()
                    Dim HandlingUnitMovement As New Handling_Units_Movements With {
                    .Created = Now(),
                    .CreatedBy = handling_Units.CreatedBy,
                    .Device = handling_Units.Device,
                    .Type = "GUS",
                    .Handling_UnitId = handling_Units.Id,
                    .Status = handling_Units.Status,
                    .Horse = handling_Units.Horse,
                    .Trailer = handling_Units.Trailer,
                    .Berth = handling_Units.Berth
                    }
                    db.Handling_Units_Movements.Add(HandlingUnitMovement)
                    db.SaveChanges()
                End If
            ElseIf handling_Units.Status = "REJECT" Then
                HandlingUnitDetails.Status = handling_Units.Status
                HandlingUnitDetails.Horse = handling_Units.Horse
                HandlingUnitDetails.Trailer = handling_Units.Trailer
                HandlingUnitDetails.Berth = handling_Units.Berth
                If ModelState.IsValid Then
                    db.Entry(HandlingUnitDetails).State = EntityState.Modified
                    db.SaveChanges()
                    Dim HandlingUnitMovement As New Handling_Units_Movements With {
                        .Created = Now(),
                        .CreatedBy = handling_Units.CreatedBy,
                        .Device = handling_Units.Device,
                        .Type = "GUS",
                        .Handling_UnitId = handling_Units.Id,
                        .Status = handling_Units.Status,
                        .Horse = handling_Units.Horse,
                        .Trailer = handling_Units.Trailer,
                        .Berth = handling_Units.Berth
                        }
                    db.Handling_Units_Movements.Add(HandlingUnitMovement)
                    db.SaveChanges()
                End If
            ElseIf handling_Units.Status = "RELEASEALL" Then
                'Tag All HU Records on Train and Release All Check All Rejected are removed
                Dim Consignment = db.Handling_Units.Where(Function(t) t.Horse = handling_Units.Horse).ToList()
                If Consignment.Where(Function(f) f.Status <> "ACCEPTED" And f.Status <> "REJECTED").Count = 0 Then
                    For Each i In Consignment.Where(Function(f) f.Status = "ACCEPTED")
                        i.Status = "From GUS"
                        If ModelState.IsValid Then
                            db.Entry(i).State = EntityState.Modified
                            db.SaveChanges()
                            Dim HandlingUnitMovement As New Handling_Units_Movements With {
                                .Created = Now(),
                                .CreatedBy = i.CreatedBy,
                                .Device = i.Device,
                                .Type = "GUS",
                                .Handling_UnitId = handling_Units.Id,
                                .Status = i.Status,
                                .Horse = i.Horse,
                                .Trailer = i.Trailer,
                                .Berth = i.Berth
                                }
                            db.Handling_Units_Movements.Add(HandlingUnitMovement)
                            db.SaveChanges()
                        End If
                    Next
                End If
            ElseIf handling_Units.Status = "RESET" Then
                Dim Consignment = db.Handling_Units.Where(Function(t) t.Horse = handling_Units.Horse).ToList()
                For Each i In Consignment
                    i.Status = "From CPC"
                    i.Horse = Nothing
                    i.Trailer = Nothing
                    i.Berth = Nothing
                    If ModelState.IsValid Then
                        db.Entry(i).State = EntityState.Modified
                        db.SaveChanges()
                        Dim HandlingUnitMovement As New Handling_Units_Movements With {
                            .Created = Now(),
                            .CreatedBy = i.CreatedBy,
                            .Device = i.Device,
                            .Type = "GUS",
                            .Handling_UnitId = handling_Units.Id,
                            .Status = i.Status,
                            .Horse = i.Horse,
                            .Trailer = i.Trailer,
                            .Berth = i.Berth
                            }
                        db.Handling_Units_Movements.Add(HandlingUnitMovement)
                        db.SaveChanges()
                    End If
                Next
            End If
            Dim LogEvent As New Log With {
                .AlertLevel = "Information",
                .Description = handling_Units.Status + " | " + handling_Units.SSCC,
                .[Event] = "Handling Unit Movement",
                .EventRaised = Now(),
                .RecordType = "Handling Units",
                .RelatedRecord = handling_Units.Id
                }
            db.Logs.Add(LogEvent)
            db.SaveChanges()
            Dim results = New List(Of Meta_Devices.handling_Unit)
            Dim hus = db.Handling_Units.Where(Function(s) s.Horse = handling_Units.Horse)
            For Each b In hus
                Dim n As New Meta_Devices.handling_Unit With {
                    .Id = b.Id,
                    .Batch = b.Batch,
                    .Created = b.Created,
                    .CreatedBy = b.CreatedBy,
                    .Device = b.Device,
                    .NumberBank = b.NumberBank,
                    .Product = b.Product,
                    .SSCC = b.SSCC,
                    .Status = b.Status,
                    .Berth = b.Berth,
                    .ScannedCode = b.ScannedCode,
                    .Trailer = b.Trailer,
                    .Horse = b.Horse
                    }
                results.Add(n)
            Next
            Return Json(results, JsonRequestBehavior.AllowGet)
        End Function
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
