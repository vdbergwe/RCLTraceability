Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class StocksController
        Inherits System.Web.Mvc.Controller

        Private db As New OMD_DatawarehouseEntities

        ' GET: Stocks
        Function Index() As ActionResult
            Dim stocks = db.Stocks.Include(Function(s) s.Business_Units_Plants)
            Return View(stocks.ToList())
        End Function

        ' GET: Stocks/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim stock As Stock = db.Stocks.Find(id)
            If IsNothing(stock) Then
                Return HttpNotFound()
            End If
            Return View(stock)
        End Function

        ' GET: Stocks/Create
        Function Create() As ActionResult
            ViewBag.PlantId = New SelectList(db.Business_Units_Plants, "Id", "Description")
            Return View()
        End Function

        ' POST: Stocks/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Code,Description,Type,Grouping,SubGrouping,UoM,CostPerUnit,FlagMin,FlagOrder,FlagMax,OrderQty,PlantId,Status,Created,CreatedBy")> ByVal stock As Stock) As ActionResult
            If ModelState.IsValid Then
                db.Stocks.Add(stock)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.PlantId = New SelectList(db.Business_Units_Plants, "Id", "Description", stock.PlantId)
            Return View(stock)
        End Function

        ' GET: Stocks/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim stock As Stock = db.Stocks.Find(id)
            If IsNothing(stock) Then
                Return HttpNotFound()
            End If
            ViewBag.PlantId = New SelectList(db.Business_Units_Plants, "Id", "Description", stock.PlantId)
            Return View(stock)
        End Function

        ' POST: Stocks/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Code,Description,Type,Grouping,SubGrouping,UoM,CostPerUnit,FlagMin,FlagOrder,FlagMax,OrderQty,PlantId,Status,Created,CreatedBy")> ByVal stock As Stock) As ActionResult
            If ModelState.IsValid Then
                db.Entry(stock).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.PlantId = New SelectList(db.Business_Units_Plants, "Id", "Description", stock.PlantId)
            Return View(stock)
        End Function

        ' GET: Stocks/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim stock As Stock = db.Stocks.Find(id)
            If IsNothing(stock) Then
                Return HttpNotFound()
            End If
            Return View(stock)
        End Function

        ' POST: Stocks/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim stock As Stock = db.Stocks.Find(id)
            db.Stocks.Remove(stock)
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
