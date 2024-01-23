Imports System.Data.Entity
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.Json
Imports System.Threading.Tasks
Imports Intranet.EventTrapper

Namespace SystemHealthTrapper

    Public Class SystemHealthTrapper

        Public Shared Async Function SendAsync(data) As Task
            Dim client As New HttpClient
            Dim response = New HttpResponseMessage()
            Dim serialerOptions = New JsonSerializerOptions
            Dim Uri As Uri = New Uri("https://omegadata.azurewebsites.net/Event_Logger/NewSystemEvent/")
            Dim requestcontent As String = JsonSerializer.Serialize(data, serialerOptions)
            Dim content As New StringContent(requestcontent, Encoding.UTF8, "application/json")
            response = Await client.PostAsync(Uri, content)
            Dim payload = Await response.Content.ReadAsStringAsync()
        End Function

    End Class

End Namespace