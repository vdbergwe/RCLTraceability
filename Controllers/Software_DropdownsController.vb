Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class Software_DropdownsController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: Software_Dropdowns
        Function Index() As ActionResult
            Return View(db.Software_Dropdowns.ToList())
        End Function

        ' GET: Software_Dropdowns/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim software_Dropdowns As Software_Dropdowns = db.Software_Dropdowns.Find(id)
            If IsNothing(software_Dropdowns) Then
                Return HttpNotFound()
            End If
            Return View(software_Dropdowns)
        End Function

        ' GET: Software_Dropdowns/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Software_Dropdowns/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,Dropdown")> ByVal software_Dropdowns As Software_Dropdowns) As ActionResult
            If ModelState.IsValid Then
                db.Software_Dropdowns.Add(software_Dropdowns)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(software_Dropdowns)
        End Function

        ' GET: Software_Dropdowns/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim software_Dropdowns As Software_Dropdowns = db.Software_Dropdowns.Find(id)
            If IsNothing(software_Dropdowns) Then
                Return HttpNotFound()
            End If
            Return View(software_Dropdowns)
        End Function

        ' POST: Software_Dropdowns/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,Dropdown")> ByVal software_Dropdowns As Software_Dropdowns) As ActionResult
            If ModelState.IsValid Then
                db.Entry(software_Dropdowns).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(software_Dropdowns)
        End Function

        ' GET: Software_Dropdowns/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim software_Dropdowns As Software_Dropdowns = db.Software_Dropdowns.Find(id)
            If IsNothing(software_Dropdowns) Then
                Return HttpNotFound()
            End If
            Return View(software_Dropdowns)
        End Function

        ' POST: Software_Dropdowns/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim software_Dropdowns As Software_Dropdowns = db.Software_Dropdowns.Find(id)
            db.Software_Dropdowns.Remove(software_Dropdowns)
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
