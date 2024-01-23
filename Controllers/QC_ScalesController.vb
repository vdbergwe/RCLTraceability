Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class QC_ScalesController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: QC_Scales
        Function Index(IsPartial As Boolean?, Id As Integer?, FilterBy As String) As ActionResult
            ViewBag.IsPartial = IsPartial
            Dim qC_Scales = db.QC_Scales.OrderBy(Function(o) o.Description)
            If Id IsNot Nothing Then
                qC_Scales = qC_Scales.Where(Function(f) f.Device = Id)
            End If
            If IsPartial = True Then
                Return PartialView(qC_Scales.ToList())
            Else
                Return View(qC_Scales.ToList())
            End If
        End Function
        ' GET: QC_Scales/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim qC_Scales As QC_Scales = db.QC_Scales.Find(id)
            If IsNothing(qC_Scales) Then
                Return HttpNotFound()
            End If
            Return View(qC_Scales)
        End Function
        ' GET: QC_Scales/Create
        Function Create() As ActionResult
            ViewBag.UOM = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "UOM"), "Description", "Description")
            Return View()
        End Function
        ' POST: QC_Scales/Create
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,Make,Model,LoadCapacity,UOM,Device,SerialNumber,BoardVersion,SoftwareVersion")> ByVal qC_Scales As QC_Scales) As ActionResult
            If ModelState.IsValid Then
                db.QC_Scales.Add(qC_Scales)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.UOM = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "UOM"), "Description", "Description", qC_Scales.UOM)
            Return View(qC_Scales)
        End Function
        ' GET: QC_Scales/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim qC_Scales As QC_Scales = db.QC_Scales.Find(id)
            If IsNothing(qC_Scales) Then
                Return HttpNotFound()
            End If
            ViewBag.Device = New SelectList(db.Devices.Where(Function(d) d.Type = "Sartorius Scale Connector").OrderBy(Function(o) o.Description), "Id", "Description", qC_Scales.Device)
            ViewBag.UOM = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "UOM"), "Description", "Description", qC_Scales.UOM)
            Return View(qC_Scales)
        End Function
        ' POST: QC_Scales/Edit/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,Make,Model,LoadCapacity,UOM,Device,SerialNumber,BoardVersion,SoftwareVersion")> ByVal qC_Scales As QC_Scales) As ActionResult
            If ModelState.IsValid Then
                db.Entry(qC_Scales).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Device = New SelectList(db.Devices, "Id", "Description", qC_Scales.Device)
            ViewBag.UOM = New SelectList(db.Software_Dropdowns.Where(Function(f) f.Dropdown = "UOM"), "Description", "Description", qC_Scales.UOM)
            Return View(qC_Scales)
        End Function
        ' GET: QC_Scales/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim qC_Scales As QC_Scales = db.QC_Scales.Find(id)
            If IsNothing(qC_Scales) Then
                Return HttpNotFound()
            End If
            Return View(qC_Scales)
        End Function
        ' POST: QC_Scales/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim qC_Scales As QC_Scales = db.QC_Scales.Find(id)
            db.QC_Scales.Remove(qC_Scales)
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
