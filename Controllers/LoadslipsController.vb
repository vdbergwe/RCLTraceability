Imports System.Data.Entity
Imports System.Net
Imports Intranet.Meta_Devices

Namespace Controllers
    Public Class LoadslipsController
        Inherits System.Web.Mvc.Controller

        Private db As New OMD_DatawarehouseEntities
        ' GET: Loadslips                                                    DONE
        Function GetLoadslip(loadslip As Loadslip) As ActionResult
            Dim data = db.Loadslips.Single(Function(s) s.LoadReference = loadslip.LoadReference)
            data.Loaded = loadslip.Loaded
            data.LoadedBy = loadslip.LoadedBy
            data.Device = loadslip.Device
            data.Waypoint = loadslip.Waypoint
            data.Driver = loadslip.Driver
            data.Horse = loadslip.Horse
            data.Trailer = loadslip.Trailer
            data.Trailer2 = loadslip.Trailer2
            data.FromLocation = loadslip.FromLocation
            data.Transporter = loadslip.Transporter
            db.Entry(data).State = EntityState.Modified
            db.SaveChanges()
            Dim result = Json(data).Data
            Return Json(result, JsonRequestBehavior.AllowGet)
        End Function
        ' GET: Loadslips_Details                                            DONE
        Function GetLoadslip_Details(Id As String, Status As String) As ActionResult
            Dim data = db.Loadslips_Details.Where(Function(i) i.LoadReference = Id And i.Status = Status)
            Dim result = Json(data).Data
            Return Json(result, JsonRequestBehavior.AllowGet)
        End Function
        ' GET: Loadslips
        Function Index() As ActionResult
            Return View(db.Loadslips.Where(Function(f) f.Status = "Loading").ToList())
        End Function
        ' GET: Loadslips/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim loadslip As Loadslip = db.Loadslips.Find(id)
            If IsNothing(loadslip) Then
                Return HttpNotFound()
            End If
            Return View(loadslip)
        End Function
        ' GET: Loadslips/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim loadslip As Loadslip = db.Loadslips.Find(id)
            If IsNothing(loadslip) Then
                Return HttpNotFound()
            End If
            Return View(loadslip)
        End Function
        ' POST: Loadslips/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim loadslip As Loadslip = db.Loadslips.Find(id)
            db.Loadslips.Remove(loadslip)
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
