Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class Loadslips_DetailsController
        Inherits System.Web.Mvc.Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: Loadslips_Details
        Function Index(Id As Integer) As ActionResult
            Return PartialView(db.Loadslips_Details.Where(Function(i) i.LoadId = Id).ToList())
        End Function
        ' GET: Loadslips_Details/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim loadslips_Details As Loadslips_Details = db.Loadslips_Details.Find(id)
            If IsNothing(loadslips_Details) Then
                Return HttpNotFound()
            End If
            Return View(loadslips_Details)
        End Function
        ' POST: Loadslips_Details/Edit/5
        Function Edit(loadslips_Details As Loadslips_Details) As ActionResult
            'Get Picking Slip
            Dim loadslip = db.Loadslips.Find(loadslips_Details.LoadId)
            Dim loadslip_Detail_Lines = db.Loadslips_Details.Where(Function(s) s.LoadId = loadslips_Details.LoadId)
            'Check Picklist Completion
            Dim completion_Check = loadslip_Detail_Lines.Where(Function(f) f.Status = "Pending Allocation").Count()
            If loadslip.Status = "Pending" And completion_Check > 0 Then
                loadslip.Status = "Loading"
                loadslip.FromLocation = "1110"
                loadslip.LoadedBy = loadslips_Details.LoadedBy
                loadslip.Device = loadslips_Details.Device
                loadslip.Waypoint = loadslip.Waypoint
                db.Entry(loadslip).State = EntityState.Modified
            ElseIf completion_Check = 0 Then
                loadslip.Status = "Loaded"
                loadslip.FromLocation = "1110"
                loadslip.Loaded = Now()
                loadslip.LoadedBy = loadslips_Details.LoadedBy
                loadslip.Device = loadslips_Details.Device
                loadslip.Waypoint = loadslip.Waypoint
                db.Entry(loadslip).State = EntityState.Modified
            Else
                loadslip.Status = "Loading"
                loadslip.LoadedBy = loadslips_Details.LoadedBy
                loadslip.Device = loadslips_Details.Device
                loadslip.Waypoint = loadslip.Waypoint
                db.Entry(loadslip).State = EntityState.Modified
            End If
            'Check if HU has been loaded on Load before
            Dim handling_Unit = db.Handling_Units.Single(Function(f) f.SSCC = loadslips_Details.SSCC And f.Status = "From GUS")
            Dim handling_Unit_Movement As New Handling_Units_Movements With {
                .Created = Now(),
                .CreatedBy = loadslips_Details.LoadedBy,
                .Handling_UnitId = handling_Unit.Id,
                .Type = "Outbound Logistics",
                .Device = db.Devices.FirstOrDefault(Function(d) d.Description = loadslips_Details.Device).Id
                }
            Dim handling_Unit_Check = loadslip_Detail_Lines.Where(Function(s) s.SSCC = loadslips_Details.SSCC).FirstOrDefault()
            If IsNothing(handling_Unit_Check) Then
                'If Not Loaded Unit Is Loaded and Update on System
                Dim load_Position = db.Loadslips_Details.FirstOrDefault(Function(s) s.Status.Contains("Pending") And s.ProductId = handling_Unit.Product)
                load_Position.Loaded = loadslips_Details.Loaded
                load_Position.Status = "Loaded"
                load_Position.LoadedBy = loadslips_Details.LoadedBy
                load_Position.SSCC = loadslips_Details.SSCC
                db.Entry(load_Position).State = EntityState.Modified

                handling_Unit_Movement.Status = "Loaded"
                handling_Unit_Movement.Horse = loadslip.Horse
                handling_Unit_Movement.Trailer = loadslip.Trailer
                handling_Unit_Movement.Berth = "N\A"
                db.Handling_Units_Movements.Add(handling_Unit_Movement)

                handling_Unit.Status = "Outbound"
                handling_Unit.Horse = loadslip.Horse
                handling_Unit.Trailer = loadslip.Trailer
                db.Entry(handling_Unit).State = EntityState.Modified

                db.SaveChanges()

                Return Json(load_Position, JsonRequestBehavior.AllowGet)
            Else
                'If Loaded Unit Is Off-Loaded and Update on System
                handling_Unit_Check.Loaded = Nothing
                handling_Unit_Check.Status = "Pending Allocation"
                handling_Unit_Check.LoadedBy = Nothing
                handling_Unit_Check.SSCC = Nothing
                handling_Unit_Check.Device = Nothing
                handling_Unit_Check.Waypoint = Nothing
                db.Entry(handling_Unit_Check).State = EntityState.Modified

                handling_Unit_Movement.Status = "Off-Loaded"
                db.Handling_Units_Movements.Add(handling_Unit_Movement)

                handling_Unit.Status = "Warehousing"
                handling_Unit.Horse = Nothing
                handling_Unit.Trailer = Nothing
                db.Entry(handling_Unit).State = EntityState.Modified

                db.SaveChanges()

                Return Json(handling_Unit_Check, JsonRequestBehavior.AllowGet)
            End If


        End Function
        ' GET: Loadslips_Details/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim loadslips_Details As Loadslips_Details = db.Loadslips_Details.Find(id)
            If IsNothing(loadslips_Details) Then
                Return HttpNotFound()
            End If
            Return View(loadslips_Details)
        End Function
        ' POST: Loadslips_Details/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim loadslips_Details As Loadslips_Details = db.Loadslips_Details.Find(id)
            db.Loadslips_Details.Remove(loadslips_Details)
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
