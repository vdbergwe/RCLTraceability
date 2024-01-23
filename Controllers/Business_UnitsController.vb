Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class Business_UnitsController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities
        ' GET: Business_Units | Done
        Function Index(IsPartial As Boolean?) As ActionResult
            ViewBag.IsPartial = IsPartial
            Dim business_Unit = db.Business_Units
            If IsPartial = True Then
                Return PartialView(business_Unit.ToList())
            Else
                Return View(business_Unit.ToList())
            End If
        End Function
        ' GET: Business_Units/Details/5 | Done
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim business_Units As Business_Units = db.Business_Units.Find(id)
            If IsNothing(business_Units) Then
                Return HttpNotFound()
            End If
            Return View(business_Units)
        End Function
        ' GET: Business_Units/Create
        Function Create() As ActionResult
            Return View()
        End Function
        ' POST: Business_Units/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,BUCode")> ByVal business_Units As Business_Units) As ActionResult
            If ModelState.IsValid Then
                db.Business_Units.Add(business_Units)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(business_Units)
        End Function

        ' GET: Business_Units/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim business_Units As Business_Units = db.Business_Units.Find(id)
            If IsNothing(business_Units) Then
                Return HttpNotFound()
            End If
            Return View(business_Units)
        End Function

        ' POST: Business_Units/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,BUCode")> ByVal business_Units As Business_Units) As ActionResult
            If ModelState.IsValid Then
                db.Entry(business_Units).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(business_Units)
        End Function

        ' GET: Business_Units/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim business_Units As Business_Units = db.Business_Units.Find(id)
            If IsNothing(business_Units) Then
                Return HttpNotFound()
            End If
            Return View(business_Units)
        End Function

        ' POST: Business_Units/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim business_Units As Business_Units = db.Business_Units.Find(id)
            db.Business_Units.Remove(business_Units)
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
