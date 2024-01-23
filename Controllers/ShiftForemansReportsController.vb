Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class ShiftForemansReportsController
        Inherits System.Web.Mvc.Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: ShiftForemansReports
        Function Index() As ActionResult
            Dim shiftForemansReports = db.ShiftForemansReports.Include(Function(s) s.Business_Units_Plants).Include(Function(s) s.Plants_Shifts).Include(Function(s) s.Production_Batches)
            Return View(shiftForemansReports.ToList())
        End Function

        ' GET: ShiftForemansReports/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim shiftForemansReport As ShiftForemansReport = db.ShiftForemansReports.Find(id)
            If IsNothing(shiftForemansReport) Then
                Return HttpNotFound()
            End If
            Return View(shiftForemansReport)
        End Function

        ' GET: ShiftForemansReports/Create
        Function Create() As ActionResult
            ViewBag.PlantId = New SelectList(db.Business_Units_Plants, "Id", "Description")
            ViewBag.ShiftId = New SelectList(db.Plants_Shifts, "Id", "Description")
            ViewBag.BatchId = New SelectList(db.Production_Batches, "Id", "Description")
            Return View()
        End Function

        ' POST: ShiftForemansReports/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,Type,Created,CreatedBy,ShiftId,PlantId,BatchId")> ByVal shiftForemansReport As ShiftForemansReport) As ActionResult
            If ModelState.IsValid Then
                db.ShiftForemansReports.Add(shiftForemansReport)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.PlantId = New SelectList(db.Business_Units_Plants, "Id", "Description", shiftForemansReport.PlantId)
            ViewBag.ShiftId = New SelectList(db.Plants_Shifts, "Id", "Description", shiftForemansReport.ShiftId)
            ViewBag.BatchId = New SelectList(db.Production_Batches, "Id", "Description", shiftForemansReport.BatchId)
            Return View(shiftForemansReport)
        End Function

        ' GET: ShiftForemansReports/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim shiftForemansReport As ShiftForemansReport = db.ShiftForemansReports.Find(id)
            If IsNothing(shiftForemansReport) Then
                Return HttpNotFound()
            End If
            ViewBag.PlantId = New SelectList(db.Business_Units_Plants, "Id", "Description", shiftForemansReport.PlantId)
            ViewBag.ShiftId = New SelectList(db.Plants_Shifts, "Id", "Description", shiftForemansReport.ShiftId)
            ViewBag.BatchId = New SelectList(db.Production_Batches, "Id", "Description", shiftForemansReport.BatchId)
            Return View(shiftForemansReport)
        End Function

        ' POST: ShiftForemansReports/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,Type,Created,CreatedBy,ShiftId,PlantId,BatchId")> ByVal shiftForemansReport As ShiftForemansReport) As ActionResult
            If ModelState.IsValid Then
                db.Entry(shiftForemansReport).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.PlantId = New SelectList(db.Business_Units_Plants, "Id", "Description", shiftForemansReport.PlantId)
            ViewBag.ShiftId = New SelectList(db.Plants_Shifts, "Id", "Description", shiftForemansReport.ShiftId)
            ViewBag.BatchId = New SelectList(db.Production_Batches, "Id", "Description", shiftForemansReport.BatchId)
            Return View(shiftForemansReport)
        End Function

        ' GET: ShiftForemansReports/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim shiftForemansReport As ShiftForemansReport = db.ShiftForemansReports.Find(id)
            If IsNothing(shiftForemansReport) Then
                Return HttpNotFound()
            End If
            Return View(shiftForemansReport)
        End Function

        ' POST: ShiftForemansReports/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim shiftForemansReport As ShiftForemansReport = db.ShiftForemansReports.Find(id)
            db.ShiftForemansReports.Remove(shiftForemansReport)
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
