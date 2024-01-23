Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Intranet

Namespace Controllers
    Public Class Waypoints_ConfigurationsController
        Inherits System.Web.Mvc.Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: Waypoints_Configurations
        Function Index() As ActionResult
            Dim waypoints_Configurations = db.Waypoints_Configurations.Include(Function(w) w.Waypoint1)
            Return View(waypoints_Configurations.ToList())
        End Function

        ' GET: Waypoints_Configurations/Details/5
        Function Details(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim waypoints_Configurations As Waypoints_Configurations = db.Waypoints_Configurations.Find(id)
            If IsNothing(waypoints_Configurations) Then
                Return HttpNotFound()
            End If
            Return View(waypoints_Configurations)
        End Function

        ' GET: Waypoints_Configurations/Create
        Function Create() As ActionResult
            ViewBag.Waypoint = New SelectList(db.Waypoints, "Id", "Description")
            Return View()
        End Function

        ' POST: Waypoints_Configurations/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,SettingName,SettingValue,SettingType,SettingGroup,SettingSubGroup,Active,Waypoint,IsGlobalSetting")> ByVal waypoints_Configurations As Waypoints_Configurations) As ActionResult
            If ModelState.IsValid Then
                db.Waypoints_Configurations.Add(waypoints_Configurations)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Waypoint = New SelectList(db.Waypoints, "Id", "Description", waypoints_Configurations.Waypoint)
            Return View(waypoints_Configurations)
        End Function

        ' GET: Waypoints_Configurations/Edit/5
        Function Edit(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim waypoints_Configurations As Waypoints_Configurations = db.Waypoints_Configurations.Find(id)
            If IsNothing(waypoints_Configurations) Then
                Return HttpNotFound()
            End If
            ViewBag.Waypoint = New SelectList(db.Waypoints, "Id", "Description", waypoints_Configurations.Waypoint)
            Return View(waypoints_Configurations)
        End Function

        ' POST: Waypoints_Configurations/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,SettingName,SettingValue,SettingType,SettingGroup,SettingSubGroup,Active,Waypoint,IsGlobalSetting")> ByVal waypoints_Configurations As Waypoints_Configurations) As ActionResult
            If ModelState.IsValid Then
                db.Entry(waypoints_Configurations).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Waypoint = New SelectList(db.Waypoints, "Id", "Description", waypoints_Configurations.Waypoint)
            Return View(waypoints_Configurations)
        End Function

        ' GET: Waypoints_Configurations/Delete/5
        Function Delete(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim waypoints_Configurations As Waypoints_Configurations = db.Waypoints_Configurations.Find(id)
            If IsNothing(waypoints_Configurations) Then
                Return HttpNotFound()
            End If
            Return View(waypoints_Configurations)
        End Function

        ' POST: Waypoints_Configurations/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As String) As ActionResult
            Dim waypoints_Configurations As Waypoints_Configurations = db.Waypoints_Configurations.Find(id)
            db.Waypoints_Configurations.Remove(waypoints_Configurations)
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
