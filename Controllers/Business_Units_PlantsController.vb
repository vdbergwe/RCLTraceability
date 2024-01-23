Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class Business_Units_PlantsController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities
        ' GET: Business_Units_Plants | Done
        Function Index(IsPartial As Boolean?, Id As Integer?) As ActionResult
            Dim business_Units_Plants = db.Business_Units_Plants.Include(Function(b) b.Business_Units).OrderBy(Function(o) o.Description)
            ViewBag.IsPartial = IsPartial
            If Id IsNot Nothing Then
                business_Units_Plants = business_Units_Plants.Where(Function(f) f.BusinessUnit = Id)
            End If
            If IsPartial = True Then
                Return PartialView(business_Units_Plants.ToList())
            Else
                Return View(business_Units_Plants.ToList())
            End If
        End Function
        ' GET: Business_Units_Plants/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim business_Units_Plants As Business_Units_Plants = db.Business_Units_Plants.Find(id)
            If IsNothing(business_Units_Plants) Then
                Return HttpNotFound()
            End If
            Return View(business_Units_Plants)
        End Function
        ' GET: Business_Units_Plants/Create
        Function Create() As ActionResult
            ViewBag.BusinessUnit = New SelectList(db.Business_Units, "Id", "Description")
            Return View()
        End Function
        ' POST: Business_Units_Plants/Create
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,BusinessUnit,PlantCode,Country")> ByVal business_Units_Plants As Business_Units_Plants) As ActionResult
            If ModelState.IsValid Then
                db.Business_Units_Plants.Add(business_Units_Plants)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.BusinessUnit = New SelectList(db.Business_Units, "Id", "Description", business_Units_Plants.BusinessUnit)
            Return View(business_Units_Plants)
        End Function
        ' GET: Business_Units_Plants/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim business_Units_Plants As Business_Units_Plants = db.Business_Units_Plants.Find(id)
            If IsNothing(business_Units_Plants) Then
                Return HttpNotFound()
            End If
            ViewBag.BusinessUnit = New SelectList(db.Business_Units, "Id", "Description", business_Units_Plants.BusinessUnit)
            Return View(business_Units_Plants)
        End Function
        ' POST: Business_Units_Plants/Edit/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,BusinessUnit,PlantCode,Country")> ByVal business_Units_Plants As Business_Units_Plants) As ActionResult
            If ModelState.IsValid Then
                db.Entry(business_Units_Plants).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.BusinessUnit = New SelectList(db.Business_Units, "Id", "Description", business_Units_Plants.BusinessUnit)
            Return View(business_Units_Plants)
        End Function
        ' GET: Business_Units_Plants/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim business_Units_Plants As Business_Units_Plants = db.Business_Units_Plants.Find(id)
            If IsNothing(business_Units_Plants) Then
                Return HttpNotFound()
            End If
            Return View(business_Units_Plants)
        End Function
        ' POST: Business_Units_Plants/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim business_Units_Plants As Business_Units_Plants = db.Business_Units_Plants.Find(id)
            db.Business_Units_Plants.Remove(business_Units_Plants)
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
