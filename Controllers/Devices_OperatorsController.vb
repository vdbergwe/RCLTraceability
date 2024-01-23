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
    Public Class Devices_OperatorsController
        Inherits System.Web.Mvc.Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: Devices_Operators
        Function Index() As ActionResult
            Return View(db.Devices_Operators.ToList())
        End Function

        ' GET: Devices_Operators/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim devices_Operators As Devices_Operators = db.Devices_Operators.Find(id)
            If IsNothing(devices_Operators) Then
                Return HttpNotFound()
            End If
            Return View(devices_Operators)
        End Function

        ' GET: Devices_Operators/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Devices_Operators/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,FirstName,Code")> ByVal devices_Operators As Devices_Operators) As ActionResult
            If ModelState.IsValid Then
                db.Devices_Operators.Add(devices_Operators)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(devices_Operators)
        End Function

        ' GET: Devices_Operators/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim devices_Operators As Devices_Operators = db.Devices_Operators.Find(id)
            If IsNothing(devices_Operators) Then
                Return HttpNotFound()
            End If
            Return View(devices_Operators)
        End Function

        ' POST: Devices_Operators/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,FirstName,Code")> ByVal devices_Operators As Devices_Operators) As ActionResult
            If ModelState.IsValid Then
                db.Entry(devices_Operators).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(devices_Operators)
        End Function

        ' GET: Devices_Operators/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim devices_Operators As Devices_Operators = db.Devices_Operators.Find(id)
            If IsNothing(devices_Operators) Then
                Return HttpNotFound()
            End If
            Return View(devices_Operators)
        End Function

        ' POST: Devices_Operators/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim devices_Operators As Devices_Operators = db.Devices_Operators.Find(id)
            db.Devices_Operators.Remove(devices_Operators)
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
