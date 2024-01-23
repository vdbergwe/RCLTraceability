Imports System.Data.Entity

Namespace Logic
    Public Class Batch_Functions
        Private Shared db As New OMD_DatawarehouseEntities
        Private Shared db_commit As New OMD_DatawarehouseEntities
        Public Shared Function BatchRun(Id As Integer?) As String
            Dim jDate As New Globalization.JulianCalendar
            Dim plants_List = db.Business_Units_Plants.ToList()
            Dim ToD = Now.TimeOfDay
            If IsNothing(Id) = False Then
                plants_List = plants_List.Where(Function(f) f.Id = Id).ToList()
            End If
            Try
                For Each p In plants_List
                    Dim b = db.Production_Batches.Where(Function(f) f.Plant = p.Description And f.BatchEnded >= Now()).ToList()
                    Dim s = p.Plants_Shifts.FirstOrDefault(Function(f) f.Plant = p.Id And f.StartTime > ToD Or f.Plant = p.Id)
                    If b.Count > 0 Then
                        For Each d In db.Production_Batches.Where(Function(st) st.BatchEnded < Now And st.Status = "Current").ToList()
                            d.Status = "Completed"
                            db.Entry(d).State = EntityState.Modified
                            db.SaveChanges()
                        Next
                    End If
                    If b.Count = 0 Then
                        Dim n As New Production_Batches With {
                                .BatchCreated = Now(),
                                .BatchEnded = Now.AddHours(s.Business_Units_Plants.ShiftDurationHrs),
                                .BatchDate = Today.ToShortDateString,
                                .Status = "Current",
                                .Type = "Production Batch",
                                .Shift = s.Id,
                                .Plant = p.Description,
                                .Description = Now.Year().ToString & Now.DayOfYear.ToString.PadLeft(3, "0") & s.Business_Units_Plants.Identifier & s.Business_Units_Plants.PlantCode & s.ShiftCode & ("000")
                                    }
                        db.Production_Batches.Add(n)
                        db.SaveChanges()
                    End If
                Next
                Return "OK - Batch Created Successfully"
            Catch ex As Exception
                Return "FAILED - " & ex.Message
            End Try
        End Function
    End Class
End Namespace
