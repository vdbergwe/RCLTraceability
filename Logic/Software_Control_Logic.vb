Imports System.Data.Entity
Imports System.Net
Namespace Logic
    Public Class Software_Control_Logic
        Private Shared db As New OMD_DatawarehouseEntities
        Private Shared db_commit As New OMD_DatawarehouseEntities
        Private Shared FE_Version As Software_Settings = db.Software_Settings.Find("a5415c91-2ebb-407e-bc19-c1751b606715")
        Private Shared Waypoints_Version As Software_Settings = db.Software_Settings.Find("975f034e-27f4-4222-ac11-52dc6a359113")
        Private Shared MobileApp_Version As Software_Settings = db.Software_Settings.Find("53af1943-340a-44cc-9b97-2482634739ca")
        Private Shared Scales_Version As Software_Settings = db.Software_Settings.Find("72798793-e313-4821-98fa-e3b1b295f4c9")
        Private Shared SendToTrapper = New With {
                    .System = "Traceability",
                    .Class = "Software_Logic",
                    .Type = "System Health Layer",
                    .Created = Now(),
                    .CreatedBy = "System Health Layer",
                    .Event = Nothing,
                    .Severity = "Information",
                    .Source = Nothing,
                    .Origin = Nothing,
                    .SupportNotified = False,
                    .EventPayload = "",
                    .Archive = False
    }





    End Class
End Namespace