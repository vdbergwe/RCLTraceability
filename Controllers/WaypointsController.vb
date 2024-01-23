Imports System.Data.Entity
Imports System.Net
Imports Microsoft.AspNet.Identity

Namespace Controllers
    Public Class WaypointsController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: Waypoints
        <Authorize>
        Function Index() As ActionResult
            Dim results = db.Waypoints
            Dim UserDetails = db.AspNetUsers_Extended.Find(User.Identity.GetUserId)
            Dim BusinessDetails = db.Business_Units.Find(UserDetails.BusinessUnitId)
            If User.IsInRole("Admin") Or User.IsInRole("Group Executive") Then
                results = results
            Else
                results = results
            End If
            Return View(results.ToList())
        End Function
        ' GET: Waypoints/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Waypoints As Waypoint = db.Waypoints.Find(id)
            If IsNothing(Waypoints) Then
                Return HttpNotFound()
            End If
            Return View(Waypoints)
        End Function
        ' GET: Waypoints/Create
        Function Create() As ActionResult
            ViewBag.Device = New SelectList(db.Devices, "Id", "Description")
            ViewBag.PlantId = New SelectList(db.Business_Units_Plants, "Id", "Description")
            ViewBag.LocationId = New SelectList(db.Plants_Locations, "Id", "Description")
            ViewBag.Type = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "Waypoint Types"), "Description", "Description")
            ViewBag.UOM = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "UOM"), "Description", "Description")
            Return View()
        End Function
        ' POST: Waypoints/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,Type,Status,UOM,LoadCapcity,HasPrinter,HasScanner,PlantId,LocationId")> Waypoints As Waypoint) As ActionResult
            If ModelState.IsValid Then
                db.Waypoints.Add(Waypoints)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Type = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "Waypoint Types"), "Description", "Description", Waypoints.Type)
            ViewBag.UOM = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "UOM"), "Description", "Description", Waypoints.UOM)
            ViewBag.Location = New SelectList(db.Plants_Locations, "Id", "Description", Waypoints.Plants_Locations.Id)
            ViewBag.LoadCapacity = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "Waypoint Load Capacity"), "Description", "Description", Waypoints.UOM)
            Return View(Waypoints)
        End Function
        ' GET: Waypoints/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Waypoints As Waypoint = db.Waypoints.Find(id)
            If IsNothing(Waypoints) Then
                Return HttpNotFound()
            End If
            ViewBag.Type = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "Waypoint Types"), "Description", "Description", Waypoints.Type)
            ViewBag.UOM = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "UOM"), "Description", "Description", Waypoints.UOM)
            ViewBag.LoadCapacity = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "Waypoint Load Capacity"), "Description", "Description", Waypoints.UOM)
            ViewBag.Location = New SelectList(db.Plants_Locations, "Id", "Description", Waypoints.Location)
            Return View(Waypoints)
        End Function
        ' POST: Waypoints/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,CurrentDevice,Type,Status,UOM,LoadCapcity,HasPrinter,HasScanner,Location")> ByVal Waypoints As Waypoint) As ActionResult
            If ModelState.IsValid Then
                db.Entry(Waypoints).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Type = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "Waypoint Types"), "Description", "Description", Waypoints.Type)
            ViewBag.UOM = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "UOM"), "Description", "Description", Waypoints.UOM)
            ViewBag.LoadCapacity = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "Waypoint Load Capacity"), "Description", "Description", Waypoints.UOM)
            ViewBag.Location = New SelectList(db.Plants_Locations, "Id", "Description", Waypoints.Location)
            Return View(Waypoints)
        End Function
        ' GET: Waypoints/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Waypoints As Waypoint = db.Waypoints.Find(id)
            If IsNothing(Waypoints) Then
                Return HttpNotFound()
            End If
            Return View(Waypoints)
        End Function
        ' POST: Waypoints/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim Waypoints As Waypoint = db.Waypoints.Find(id)
            db.Waypoints.Remove(Waypoints)
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
