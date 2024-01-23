Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class Waypoints_NumberBanksController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities
        ' GET: Waypoints_NumberBanks
        <Authorize>
        Function ReInit() As ActionResult
            Dim waypoints_NumberBanks = db.Waypoints_NumberBanks
            For Each i In waypoints_NumberBanks
                i.Status = "New"
                i.LastIssued = "-00001"
                i.Created = Now()
                i.Waypoint = Nothing
                i.Device = Nothing
                i.Reserved = Nothing
                db.Entry(i).State = EntityState.Modified
            Next
            db.SaveChanges()

            Return RedirectToAction("Index")
        End Function
        ' GET: Waypoints_NumberBanks
        Function Index(IsPartial As Boolean?, Id As Integer?, FilterBy As String, IsJson As Boolean?) As ActionResult
            ViewBag.IsPartial = IsPartial
            Dim waypoints_NumberBanks = db.Waypoints_NumberBanks.ToList()
            If Id IsNot Nothing Then
                If FilterBy = "Waypoint" Then
                    waypoints_NumberBanks = db.Waypoints_NumberBanks.Where(Function(f) f.Waypoint = Id And f.Status = "Allocated").ToList()
                ElseIf FilterBy = "Device" Then
                    waypoints_NumberBanks = db.Waypoints_NumberBanks.Where(Function(f) f.Device = Id)
                End If
            End If
            If IsPartial = True Then
                Return PartialView(waypoints_NumberBanks)
            ElseIf IsJson = True Then
                Return Json(waypoints_NumberBanks.ToList(), JsonRequestBehavior.AllowGet)
            Else
                Return View(waypoints_NumberBanks.ToList())
            End If
        End Function
        ' GET: Waypoints_NumberBanks/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim waypoints_NumberBanks As Waypoints_NumberBanks = db.Waypoints_NumberBanks.Find(id)
            If IsNothing(waypoints_NumberBanks) Then
                Return HttpNotFound()
            End If
            Return View(waypoints_NumberBanks)
        End Function
        ' GET: Waypoints_NumberBanks/Create
        Function Create() As ActionResult
            ViewBag.Device = New SelectList(db.Devices, "Id", "Description")
            Return View()
        End Function
        ' POST: Waypoints_NumberBanks/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Prefix,Bank,Root,FirstNumber,LastNumber,LastIssued,Created,Reserved,Released,Depleted,Waypoint,Device,Status")> ByVal waypoints_NumberBanks As Waypoints_NumberBanks) As ActionResult
            If ModelState.IsValid Then
                db.Waypoints_NumberBanks.Add(waypoints_NumberBanks)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Device = New SelectList(db.Devices, "Id", "Description", waypoints_NumberBanks.Device)
            Return View(waypoints_NumberBanks)
        End Function
        ' GET: Waypoints_NumberBanks/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim waypoints_NumberBanks As Waypoints_NumberBanks = db.Waypoints_NumberBanks.Find(id)
            If IsNothing(waypoints_NumberBanks) Then
                Return HttpNotFound()
            End If
            ViewBag.Device = New SelectList(db.Devices, "Id", "Description", waypoints_NumberBanks.Device)
            Return View(waypoints_NumberBanks)
        End Function

        ' POST: Waypoints_NumberBanks/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Prefix,Bank,Root,FirstNumber,LastNumber,LastIssued,Created,Reserved,Released,Depleted,Waypoint,Device,Status")> ByVal waypoints_NumberBanks As Waypoints_NumberBanks) As ActionResult
            If ModelState.IsValid Then
                db.Entry(waypoints_NumberBanks).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Device = New SelectList(db.Devices, "Id", "Description", waypoints_NumberBanks.Device)
            Return View(waypoints_NumberBanks)
        End Function

        ' GET: Waypoints_NumberBanks/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim waypoints_NumberBanks As Waypoints_NumberBanks = db.Waypoints_NumberBanks.Find(id)
            If IsNothing(waypoints_NumberBanks) Then
                Return HttpNotFound()
            End If
            Return View(waypoints_NumberBanks)
        End Function

        ' POST: Waypoints_NumberBanks/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim waypoints_NumberBanks As Waypoints_NumberBanks = db.Waypoints_NumberBanks.Find(id)
            db.Waypoints_NumberBanks.Remove(waypoints_NumberBanks)
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
