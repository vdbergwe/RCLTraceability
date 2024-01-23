Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class Plants_LocationsController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: Plants_Locations
        Function Index(IsPartial As Boolean?, Id As Integer?, FilterBy As String) As ActionResult
            ViewBag.IsPartial = IsPartial
            Dim plants_Locations = db.Plants_Locations.Include(Function(p) p.Business_Units_Plants).OrderBy(Function(o) o.Type)
            If Id IsNot Nothing And FilterBy = "BU" Then
                plants_Locations = plants_Locations.Where(Function(f) f.Business_Units_Plants.Id = Id)
            ElseIf Id IsNot Nothing And FilterBy = "PL" Then
                plants_Locations = plants_Locations.Where(Function(f) f.PlantId = Id)
            End If
            If IsPartial = True Then
                Return PartialView(plants_Locations.ToList())
            Else
                Return View(plants_Locations.ToList())
            End If
        End Function

        ' GET: Plants_Locations/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plants_Locations As Plants_Locations = db.Plants_Locations.Find(id)
            If IsNothing(plants_Locations) Then
                Return HttpNotFound()
            End If
            Return View(plants_Locations)
        End Function

        ' GET: Plants_Locations/Create
        Function Create() As ActionResult
            ViewBag.PlantId = New SelectList(db.Business_Units_Plants, "Id", "Description")
            Return View()
        End Function

        ' POST: Plants_Locations/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,PlantId,Description,Type")> ByVal plants_Locations As Plants_Locations) As ActionResult
            If ModelState.IsValid Then
                db.Plants_Locations.Add(plants_Locations)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.PlantId = New SelectList(db.Business_Units_Plants, "Id", "Description", plants_Locations.PlantId)
            Return View(plants_Locations)
        End Function

        ' GET: Plants_Locations/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plants_Locations As Plants_Locations = db.Plants_Locations.Find(id)
            If IsNothing(plants_Locations) Then
                Return HttpNotFound()
            End If
            ViewBag.PlantId = New SelectList(db.Business_Units_Plants, "Id", "Description", plants_Locations.PlantId)
            Return View(plants_Locations)
        End Function

        ' POST: Plants_Locations/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,PlantId,Description,Type")> ByVal plants_Locations As Plants_Locations) As ActionResult
            If ModelState.IsValid Then
                db.Entry(plants_Locations).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.PlantId = New SelectList(db.Business_Units_Plants, "Id", "Description", plants_Locations.PlantId)
            Return View(plants_Locations)
        End Function

        ' GET: Plants_Locations/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plants_Locations As Plants_Locations = db.Plants_Locations.Find(id)
            If IsNothing(plants_Locations) Then
                Return HttpNotFound()
            End If
            Return View(plants_Locations)
        End Function

        ' POST: Plants_Locations/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim plants_Locations As Plants_Locations = db.Plants_Locations.Find(id)
            db.Plants_Locations.Remove(plants_Locations)
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
