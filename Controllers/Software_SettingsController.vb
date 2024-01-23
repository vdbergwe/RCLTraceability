Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class Software_SettingsController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: Software_Settings
        Function Index() As ActionResult
            Dim results = db.Software_Settings.OrderBy(Function(o) o.SettingGroup)
            Return View(results.ToList())
        End Function
        ' GET: Software_Settings
        Function get_Device_Software_Configuration(FilterBy As String) As ActionResult
            Dim results = db.Software_Settings.Where(Function(f) f.SettingGroup.Contains(FilterBy) Or f.SettingSubGroup.Contains(FilterBy))
            Return Json(results.ToList(), JsonRequestBehavior.AllowGet)
        End Function

        ' GET: Software_Settings/Details/5
        Function Details(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim software_Settings As Software_Settings = db.Software_Settings.Find(id)
            If IsNothing(software_Settings) Then
                Return HttpNotFound()
            End If
            Return View(software_Settings)
        End Function

        ' GET: Software_Settings/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Software_Settings/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,SettingName,SettingValue,SettingGroup,SettingSubGroup")> ByVal software_Settings As Software_Settings) As ActionResult
            Dim SGuid = Guid.NewGuid()
            software_Settings.Id = SGuid.ToString()
            If ModelState.IsValid Then
                db.Software_Settings.Add(software_Settings)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(software_Settings)
        End Function

        ' GET: Software_Settings/Edit/5
        Function Edit(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim software_Settings As Software_Settings = db.Software_Settings.Find(id)
            If IsNothing(software_Settings) Then
                Return HttpNotFound()
            End If
            Return View(software_Settings)
        End Function

        ' POST: Software_Settings/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,SettingName,SettingValue,SettingGroup,SettingSubGroup")> ByVal software_Settings As Software_Settings) As ActionResult
            If ModelState.IsValid Then
                db.Entry(software_Settings).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(software_Settings)
        End Function

        ' GET: Software_Settings/Delete/5
        Function Delete(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim software_Settings As Software_Settings = db.Software_Settings.Find(id)
            If IsNothing(software_Settings) Then
                Return HttpNotFound()
            End If
            Return View(software_Settings)
        End Function

        ' POST: Software_Settings/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As String) As ActionResult
            Dim software_Settings As Software_Settings = db.Software_Settings.Find(id)
            db.Software_Settings.Remove(software_Settings)
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
