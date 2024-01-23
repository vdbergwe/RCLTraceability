Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class Handling_Units_MovementsController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: Handling_Units_Movements
        Function Index(IsPartial As Boolean?, Id As Integer?, FilterBy As String) As ActionResult
            Dim handling_Units_Movements = db.Handling_Units_Movements.Include(Function(h) h.Handling_Units)
            If Id IsNot Nothing Then
                If FilterBy = "Handling Unit" Then
                    handling_Units_Movements = handling_Units_Movements.Where(Function(f) f.Handling_UnitId = Id)
                ElseIf FilterBy = "Device" Then
                    handling_Units_Movements = handling_Units_Movements.Where(Function(f) f.Device = Id)
                ElseIf FilterBy = "Waypoint" Then
                    handling_Units_Movements = handling_Units_Movements.Where(Function(f) f.Waypoint = Id)
                End If
            End If
            If IsPartial = True Then
                Return PartialView(handling_Units_Movements.ToList())
            Else
                Return View(handling_Units_Movements.ToList())
            End If
        End Function

        ' GET: Handling_Units_Movements/Details/5
        Function Details(id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim handling_Units_Movements As Handling_Units_Movements = db.Handling_Units_Movements.Find(id)
            If IsNothing(handling_Units_Movements) Then
                Return HttpNotFound()
            End If
            Return View(handling_Units_Movements)
        End Function

        ' GET: Handling_Units_Movements/Create
        Function Create() As ActionResult
            ViewBag.Device = New SelectList(db.Devices, "Id", "Description")
            ViewBag.Handling_Unit = New SelectList(db.Handling_Units, "Id", "SSCC")
            Return View()
        End Function

        ' POST: Handling_Units_Movements/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Handling_Unit,Device,Created,CreatedBy,Type,Status,Horse,Trailer")> ByVal handling_Units_Movements As Handling_Units_Movements) As ActionResult
            If ModelState.IsValid Then
                db.Handling_Units_Movements.Add(handling_Units_Movements)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Device = New SelectList(db.Devices, "Id", "Description", handling_Units_Movements.Device)
            ViewBag.Handling_Unit = New SelectList(db.Handling_Units, "Id", "SSCC", handling_Units_Movements.Handling_UnitId)
            Return View(handling_Units_Movements)
        End Function

        ' GET: Handling_Units_Movements/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim handling_Units_Movements As Handling_Units_Movements = db.Handling_Units_Movements.Find(id)
            If IsNothing(handling_Units_Movements) Then
                Return HttpNotFound()
            End If
            ViewBag.Device = New SelectList(db.Devices, "Id", "Description", handling_Units_Movements.Device)
            ViewBag.Handling_Unit = New SelectList(db.Handling_Units, "Id", "SSCC", handling_Units_Movements.Handling_UnitId)
            Return View(handling_Units_Movements)
        End Function

        ' POST: Handling_Units_Movements/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Handling_Unit,Device,Created,CreatedBy,Type,Status")> ByVal handling_Units_Movements As Handling_Units_Movements) As ActionResult
            If ModelState.IsValid Then
                db.Entry(handling_Units_Movements).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Device = New SelectList(db.Devices, "Id", "Description", handling_Units_Movements.Device)
            ViewBag.Handling_Unit = New SelectList(db.Handling_Units, "Id", "SSCC", handling_Units_Movements.Handling_UnitId)
            Return View(handling_Units_Movements)
        End Function

        ' GET: Handling_Units_Movements/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim handling_Units_Movements As Handling_Units_Movements = db.Handling_Units_Movements.Find(id)
            If IsNothing(handling_Units_Movements) Then
                Return HttpNotFound()
            End If
            Return View(handling_Units_Movements)
        End Function

        ' POST: Handling_Units_Movements/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim handling_Units_Movements As Handling_Units_Movements = db.Handling_Units_Movements.Find(id)
            db.Handling_Units_Movements.Remove(handling_Units_Movements)
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
