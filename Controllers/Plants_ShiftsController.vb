Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class Plants_ShiftsController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: Plants_Shifts
        Function Index(IsPartial As Boolean?, Id As Integer?) As ActionResult
            ViewBag.IsPartial = IsPartial
            Dim plants_Shifts = db.Plants_Shifts.Include(Function(p) p.Business_Units_Plants)
            If Id IsNot Nothing Then
                plants_Shifts = plants_Shifts.Where(Function(f) f.Plant = Id)
            End If
            If IsPartial = True Then
                Return PartialView(plants_Shifts.ToList())
            Else
                Return View(plants_Shifts.ToList())
            End If
        End Function

        ' GET: Plants_Shifts/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plants_Shifts As Plants_Shifts = db.Plants_Shifts.Find(id)
            If IsNothing(plants_Shifts) Then
                Return HttpNotFound()
            End If
            Return View(plants_Shifts)
        End Function

        ' GET: Plants_Shifts/Create
        Function Create() As ActionResult
            ViewBag.Plant = New SelectList(db.Business_Units_Plants, "Id", "Description")
            Return View()
        End Function

        ' POST: Plants_Shifts/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,StartTime,EndTime,Mon,Tue,Wed,Thu,Fri,Sat,Sun,Active,Plant")> ByVal plants_Shifts As Plants_Shifts) As ActionResult
            If ModelState.IsValid Then
                db.Plants_Shifts.Add(plants_Shifts)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Plant = New SelectList(db.Business_Units_Plants, "Id", "Description", plants_Shifts.Plant)
            Return View(plants_Shifts)
        End Function

        ' GET: Plants_Shifts/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plants_Shifts As Plants_Shifts = db.Plants_Shifts.Find(id)
            If IsNothing(plants_Shifts) Then
                Return HttpNotFound()
            End If
            ViewBag.Plant = New SelectList(db.Business_Units_Plants, "Id", "Description", plants_Shifts.Plant)
            Return View(plants_Shifts)
        End Function

        ' POST: Plants_Shifts/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,StartTime,EndTime,Mon,Tue,Wed,Thu,Fri,Sat,Sun,Active,Plant")> ByVal plants_Shifts As Plants_Shifts) As ActionResult
            If ModelState.IsValid Then
                db.Entry(plants_Shifts).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Plant = New SelectList(db.Business_Units_Plants, "Id", "Description", plants_Shifts.Plant)
            Return View(plants_Shifts)
        End Function

        ' GET: Plants_Shifts/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plants_Shifts As Plants_Shifts = db.Plants_Shifts.Find(id)
            If IsNothing(plants_Shifts) Then
                Return HttpNotFound()
            End If
            Return View(plants_Shifts)
        End Function

        ' POST: Plants_Shifts/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim plants_Shifts As Plants_Shifts = db.Plants_Shifts.Find(id)
            db.Plants_Shifts.Remove(plants_Shifts)
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
