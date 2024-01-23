Imports System.Data.Entity
Imports System.Net
Imports Intranet.Meta_Devices
Imports Microsoft.AspNet.Identity
Imports Intranet.Logic

Namespace Controllers
    Public Class Production_BatchesController
        Inherits Controller
        Private db As New OMD_DatawarehouseEntities
        Private db_commit As New OMD_DatawarehouseEntities
        Private r = Batch_Functions.BatchRun(Nothing)
        ' GET: Device_Batch                                                     DONE          
        <Authorize>
        Function Index(IsPartial As Boolean?, Id As Integer?, FilterBy As String) As ActionResult
            ViewBag.IsPartial = IsPartial
            Dim production_Batches = db.Production_Batches.Include(Function(p) p.Plants_Shifts).OrderByDescending(Function(o) o.BatchDate)
            Dim UserDetails = db.AspNetUsers_Extended.Find(User.Identity.GetUserId)
            Dim BusinessDetails = db.Business_Units.Find(UserDetails.BusinessUnitId)
            'Apply Security
            If User.IsInRole("Admin") Or User.IsInRole("Group Executive") Then
                production_Batches = production_Batches.Where(Function(f) f.Plants_Shifts.Business_Units_Plants.Business_Units.Id = UserDetails.BusinessUnitId)
            Else
                production_Batches = production_Batches.Where(Function(f) f.Plants_Shifts.Plant = UserDetails.PlantId)
            End If
            If Id IsNot Nothing And IsNothing(FilterBy) = True Then
                production_Batches = production_Batches.Where(Function(f) f.Shift = Id)
            ElseIf Id IsNot Nothing And FilterBy = "SH" Then
                production_Batches = production_Batches.Where(Function(f) f.Shift = Id)
            ElseIf Id IsNot Nothing And FilterBy = "PL" Then
                production_Batches = production_Batches.Where(Function(f) f.Plants_Shifts.Plant = Id)
            ElseIf FilterBy = "CR" Then
                production_Batches = production_Batches.Where(Function(f) f.Status = "Current")
            End If
            If IsPartial = True Then
                Return PartialView(production_Batches.ToList())
            Else
                Return View(production_Batches.ToList())
            End If
            Return View(production_Batches.ToList())
        End Function
        ' GET: Production_Batches/Details/5
        <Authorize>
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim production_Batches As Production_Batches = db.Production_Batches.Find(id)
            If IsNothing(production_Batches) Then
                Return HttpNotFound()
            End If
            Return View(production_Batches)
        End Function
        <Authorize>
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim production_Batches As Production_Batches = db.Production_Batches.Find(id)
            If IsNothing(production_Batches) Then
                Return HttpNotFound()
            End If
            Return View(production_Batches)
        End Function
        ' POST: Production_Batches/Delete/5
        <HttpPost()>
        <Authorize>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim production_Batches As Production_Batches = db.Production_Batches.Find(id)
            db.Production_Batches.Remove(production_Batches)
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
