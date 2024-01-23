Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class Integration_SyncLogsController
        Inherits System.Web.Mvc.Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: Integration_SyncLogs
        Function Index() As ActionResult
            Return View(db.Integration_SyncLogs.ToList())
        End Function
        ' GET: Integration_SyncLogs/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim integration_SyncLogs As Integration_SyncLogs = db.Integration_SyncLogs.Find(id)
            If IsNothing(integration_SyncLogs) Then
                Return HttpNotFound()
            End If
            Return View(integration_SyncLogs)
        End Function
        ' GET: Integration_SyncLogs/Create
        Function Create() As ActionResult
            Return View()
        End Function
        ' POST: Integration_SyncLogs/Create
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,Created,CreatedBy,SourceSystem,DestinationSystem,SyncScope")> ByVal integration_SyncLogs As Integration_SyncLogs) As ActionResult
            If ModelState.IsValid Then
                db.Integration_SyncLogs.Add(integration_SyncLogs)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(integration_SyncLogs)
        End Function
        ' GET: Integration_SyncLogs/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim integration_SyncLogs As Integration_SyncLogs = db.Integration_SyncLogs.Find(id)
            If IsNothing(integration_SyncLogs) Then
                Return HttpNotFound()
            End If
            Return View(integration_SyncLogs)
        End Function
        ' POST: Integration_SyncLogs/Edit/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,Created,CreatedBy,SourceSystem,DestinationSystem,SyncScope")> ByVal integration_SyncLogs As Integration_SyncLogs) As ActionResult
            If ModelState.IsValid Then
                db.Entry(integration_SyncLogs).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(integration_SyncLogs)
        End Function
        ' GET: Integration_SyncLogs/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim integration_SyncLogs As Integration_SyncLogs = db.Integration_SyncLogs.Find(id)
            If IsNothing(integration_SyncLogs) Then
                Return HttpNotFound()
            End If
            Return View(integration_SyncLogs)
        End Function
        ' POST: Integration_SyncLogs/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim integration_SyncLogs As Integration_SyncLogs = db.Integration_SyncLogs.Find(id)
            db.Integration_SyncLogs.Remove(integration_SyncLogs)
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
