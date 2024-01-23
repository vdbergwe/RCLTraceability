Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class Software_PackagesController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: Software_Packages
        Function Index() As ActionResult
            Return View(db.Software_Packages.ToList())
        End Function

        ' GET: Software_Packages/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim software_Packages As Software_Packages = db.Software_Packages.Find(id)
            If IsNothing(software_Packages) Then
                Return HttpNotFound()
            End If
            Return View(software_Packages)
        End Function

        ' GET: Software_Packages/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Software_Packages/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,Type,Status,Version,ReleaseDate,ExpiryDate,PackageLocation,PackageExecuteScriptLocation")> ByVal software_Packages As Software_Packages) As ActionResult
            If ModelState.IsValid Then
                db.Software_Packages.Add(software_Packages)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(software_Packages)
        End Function

        ' GET: Software_Packages/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim software_Packages As Software_Packages = db.Software_Packages.Find(id)
            If IsNothing(software_Packages) Then
                Return HttpNotFound()
            End If
            Return View(software_Packages)
        End Function

        ' POST: Software_Packages/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,Type,Status,Version,ReleaseDate,ExpiryDate,PackageLocation,PackageExecuteScriptLocation")> ByVal software_Packages As Software_Packages) As ActionResult
            If ModelState.IsValid Then
                db.Entry(software_Packages).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(software_Packages)
        End Function

        ' GET: Software_Packages/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim software_Packages As Software_Packages = db.Software_Packages.Find(id)
            If IsNothing(software_Packages) Then
                Return HttpNotFound()
            End If
            Return View(software_Packages)
        End Function

        ' POST: Software_Packages/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim software_Packages As Software_Packages = db.Software_Packages.Find(id)
            db.Software_Packages.Remove(software_Packages)
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
