Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class QC_Scales_ReadingsController
        Inherits Controller

        Private db As New OMD_DatawarehouseEntities
        'Get Old Method Readings
        Function GetOld(qcreading As String)
            Dim ScaleDate As DateTime
            Dim ScaleModel As String
            Dim ScaleSerial As String
            Dim ScaleVersion As String
            Dim ScaleBoardVersion As String
            Dim PLU As String

            Dim Sample1 As String
            Dim Sample2 As String
            Dim Sample3 As String
            Dim Sample4 As String
            Dim SampleTare As String
            Dim SampleMean As String
            Dim SampleOperator As String
            Dim SampleMachine As String

            qcreading = Trim(qcreading)
            If qcreading.Length = 740 Then 'Label 1 Design
                qcreading = Trim(qcreading.Replace("--------------------", ""))
                Dim ScaleConvert = Left(qcreading, 16)
                ScaleDate = DateTime.ParseExact(ScaleConvert, "dd.MM.yyyy h:mm", Globalization.CultureInfo.InvariantCulture)
                qcreading = qcreading.Remove(0, 22)
                ScaleModel = Trim(Left(qcreading, 6))
                qcreading = qcreading.Remove(0, 14)
                ScaleSerial = Trim(Left(qcreading, 8))
                qcreading = qcreading.Remove(0, 14)
                ScaleVersion = Trim(Left(qcreading, 14))
                qcreading = qcreading.Remove(0, 22)
                ScaleBoardVersion = Trim(Left(qcreading, 8))
                qcreading = qcreading.Remove(0, 66)
                PLU = Trim(Left(qcreading, 6))
                qcreading = qcreading.Remove(0, 163)
                SampleTare = Trim(Left(qcreading, 6)).Replace(".", ",")
                qcreading = qcreading.Remove(0, 27)
                Sample1 = Trim(Left(qcreading, 8)).Replace(".", ",")
                qcreading = qcreading.Remove(0, 13)
                Sample2 = Trim(Left(qcreading, 8)).Replace(".", ",")
                qcreading = qcreading.Remove(0, 13)
                Sample3 = Trim(Left(qcreading, 8)).Replace(".", ",")
                qcreading = qcreading.Remove(0, 13)
                Sample4 = Trim(Left(qcreading, 8)).Replace(".", ",")
                qcreading = qcreading.Remove(0, 26)
                SampleMean = Trim(Left(qcreading, 10)).Replace(".", ",")
                qcreading = qcreading.Remove(0, 218)
                SampleOperator = Trim(Left(qcreading, 2))


                Dim QC_Scale = db.QC_Scales.Single(Function(s) s.SerialNumber = ScaleSerial)
                QC_Scale.SoftwareVersion = ScaleVersion
                QC_Scale.BoardVersion = ScaleBoardVersion
                Dim QC_Sample_Product = db.Products.Single(Function(s) s.PLU = PLU)
                Dim QC_Sample_Batch = db.Production_Batches.Single(Function(s) s.Plant = "FIX" And s.Status = "Current")

                Dim qC_Scales_Reading As New QC_Scales_Readings With {
                    .Batch = QC_Sample_Batch.Id,
                    .ReadingDate = ScaleDate,
                    .QC_Scale = QC_Scale.Id,
                    .Median = CDec(SampleMean),
                    .Product = QC_Sample_Product.Id,
                    .S1 = CDec(Sample1),
                    .S2 = CDec(Sample2),
                    .S3 = CDec(Sample3),
                    .S4 = CDec(Sample4),
                    .[Operator] = SampleOperator,
                    .Result = IIf(SampleMean > QC_Sample_Product.TargetWeight, "Critical - Under Packed", IIf(SampleMean < QC_Sample_Product.TargetWeight, "Warning - Over Packed", "Passed")),
                    .Status = IIf(SampleMean > QC_Sample_Product.TargetWeight, "Pending QC Action", "Passed"),
                    .Tare = CDec(SampleTare),
                    .Target = QC_Sample_Product.TargetWeight,
                    .UOM = QC_Sample_Product.UOM
                    }
                db.Entry(QC_Scale).State = EntityState.Modified
                db.SaveChanges()
                db.QC_Scales_Readings.Add(qC_Scales_Reading)
                db.SaveChanges()
                Return Json(Response.StatusCode, JsonRequestBehavior.AllowGet)
            End If
            Return Json(Response.StatusCode, JsonRequestBehavior.AllowGet)

        End Function
        ' GET: QC_Scales_Readings
        Function Index(IsPartial As Boolean?, Id As Integer?, FilterBy As String) As ActionResult
            ViewBag.IsPartial = IsPartial
            Dim qC_Scales_Readings = db.QC_Scales_Readings.Include(Function(q) q.QC_Scales).Include(Function(q) q.QC_Scales_Stations).OrderByDescending(Function(o) o.ReadingDate)
            If Id IsNot Nothing Then
                qC_Scales_Readings = qC_Scales_Readings.Where(Function(f) f.Batch = Id)
            End If
            If IsPartial = True Then
                Return PartialView(qC_Scales_Readings.Take(10).ToList())
            Else
                Return View(qC_Scales_Readings.ToList())
            End If
        End Function
        ' GET: QC_Scales_Readings/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim qC_Scales_Readings As QC_Scales_Readings = db.QC_Scales_Readings.Find(id)
            If IsNothing(qC_Scales_Readings) Then
                Return HttpNotFound()
            End If
            Return View(qC_Scales_Readings)
        End Function
        ' POST: QC_Scales_Readings/Create
        <HttpPost()>
        Function Create(qC_Scales_Readings As QC_Scales_Readings) As ActionResult
            qC_Scales_Readings.Status = "Synced"
            If qC_Scales_Readings.Median < qC_Scales_Readings.Target Then
                qC_Scales_Readings.Result = "Under Packed | Requires Action"
            ElseIf qC_Scales_Readings.Median > qC_Scales_Readings.Target Then
                qC_Scales_Readings.Result = "Over Packed | Requires Action"
            ElseIf qC_Scales_Readings.Median = qC_Scales_Readings.Target Then
                qC_Scales_Readings.Result = "Within Tolerances | Requires No Action"
            End If
            db.QC_Scales_Readings.Add(qC_Scales_Readings)
            db.SaveChanges()
            Return Json(qC_Scales_Readings, JsonRequestBehavior.AllowGet)
        End Function
        ' GET: QC_Scales_Readings/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim qC_Scales_Readings As QC_Scales_Readings = db.QC_Scales_Readings.Find(id)
            If IsNothing(qC_Scales_Readings) Then
                Return HttpNotFound()
            End If
            Return View(qC_Scales_Readings)
        End Function
        ' POST: QC_Scales_Readings/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim qC_Scales_Readings As QC_Scales_Readings = db.QC_Scales_Readings.Find(id)
            db.QC_Scales_Readings.Remove(qC_Scales_Readings)
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
