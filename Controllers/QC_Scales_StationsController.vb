Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class QC_Scales_StationsController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities
        ' GET: QC_Scales_Stations
        Function Index() As ActionResult
            Dim qC_Scales_Stations = db.QC_Scales_Stations.Include(Function(q) q.Plants_Locations).Include(Function(q) q.QC_Scales)
            Return View(qC_Scales_Stations.ToList())
        End Function
        ' GET: QC_Scales_Stations/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim qC_Scales_Stations As QC_Scales_Stations = db.QC_Scales_Stations.Find(id)
            If IsNothing(qC_Scales_Stations) Then
                Return HttpNotFound()
            End If
            Return View(qC_Scales_Stations)
        End Function
        ' GET: QC_Scales_Stations/Create
        Function Create() As ActionResult
            ViewBag.Location = New SelectList(db.Plants_Locations, "Id", "Description")
            ViewBag.QC_Scale = New SelectList(db.QC_Scales, "Id", "Description")
            Return View()
        End Function
        ' POST: QC_Scales_Stations/Create
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,Location,Functions,QC_Scale")> ByVal qC_Scales_Stations As QC_Scales_Stations) As ActionResult
            If ModelState.IsValid Then
                db.QC_Scales_Stations.Add(qC_Scales_Stations)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Location = New SelectList(db.Plants_Locations, "Id", "Description", qC_Scales_Stations.Location)
            ViewBag.QC_Scale = New SelectList(db.QC_Scales, "Id", "Description", qC_Scales_Stations.QC_Scale)
            Return View(qC_Scales_Stations)
        End Function
        ' GET: QC_Scales_Stations/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim qC_Scales_Stations As QC_Scales_Stations = db.QC_Scales_Stations.Find(id)
            If IsNothing(qC_Scales_Stations) Then
                Return HttpNotFound()
            End If
            ViewBag.Location = New SelectList(db.Plants_Locations, "Id", "Description", qC_Scales_Stations.Location)
            ViewBag.QC_Scale = New SelectList(db.QC_Scales, "Id", "Description", qC_Scales_Stations.QC_Scale)
            Return View(qC_Scales_Stations)
        End Function
        ' POST: QC_Scales_Stations/Edit/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,Location,Functions,QC_Scale")> ByVal qC_Scales_Stations As QC_Scales_Stations) As ActionResult
            If ModelState.IsValid Then
                db.Entry(qC_Scales_Stations).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Location = New SelectList(db.Plants_Locations, "Id", "Description", qC_Scales_Stations.Location)
            ViewBag.QC_Scale = New SelectList(db.QC_Scales, "Id", "Description", qC_Scales_Stations.QC_Scale)
            Return View(qC_Scales_Stations)
        End Function
        ' GET: QC_Scales_Stations/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim qC_Scales_Stations As QC_Scales_Stations = db.QC_Scales_Stations.Find(id)
            If IsNothing(qC_Scales_Stations) Then
                Return HttpNotFound()
            End If
            Return View(qC_Scales_Stations)
        End Function
        ' POST: QC_Scales_Stations/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim qC_Scales_Stations As QC_Scales_Stations = db.QC_Scales_Stations.Find(id)
            db.QC_Scales_Stations.Remove(qC_Scales_Stations)
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
