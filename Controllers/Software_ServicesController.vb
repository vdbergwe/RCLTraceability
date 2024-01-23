Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class Software_ServicesController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: Services
        Function Index() As ActionResult
            Return View(db.Software_Services.ToList())
        End Function
        ' GET: Services/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim service As Software_Services = db.Software_Services.Find(id)
            If IsNothing(service) Then
                Return HttpNotFound()
            End If
            Return View(service)
        End Function
        ' GET: Services/Create
        Function Create() As ActionResult
            Return View()
        End Function
        ' POST: Services/Create
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,Status,Type,EndpointUrl,HostName,IP")> ByVal service As Software_Services) As ActionResult
            If ModelState.IsValid Then
                db.Software_Services.Add(service)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(service)
        End Function
        ' GET: Services/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim service As Software_Services = db.Software_Services.Find(id)
            If IsNothing(service) Then
                Return HttpNotFound()
            End If
            Return View(service)
        End Function
        ' POST: Services/Edit/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,Status,Type,EndpointUrl,HostName,IP")> ByVal service As Software_Services) As ActionResult
            If ModelState.IsValid Then
                db.Entry(service).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(service)
        End Function
        ' GET: Services/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim service As Software_Services = db.Software_Services.Find(id)
            If IsNothing(service) Then
                Return HttpNotFound()
            End If
            Return View(service)
        End Function
        ' POST: Services/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim service As Software_Services = db.Software_Services.Find(id)
            db.Software_Services.Remove(service)
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
