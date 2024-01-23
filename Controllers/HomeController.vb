Imports Microsoft.AspNet.Identity

Public Class HomeController
    Inherits Controller
    Private db As New OMD_DatawarehouseEntities
    <Authorize>
    Function Index() As ActionResult
        Return View()
    End Function
End Class
