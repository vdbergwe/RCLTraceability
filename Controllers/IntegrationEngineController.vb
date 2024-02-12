Imports System.Data.Entity

Namespace Controllers
    Public Class IntegrationEngineController
        Inherits Controller

        Private OMDdb As New OMD_DatawarehouseEntities
        Private OMDdbBatches As New OMD_DatawarehouseEntities
        Private SAPdb As New zzSAPIntegrationTSHEntities
        Private SAPdbBatches As New zzSAPIntegrationTSHEntities
        Private Log As New Integration_SyncLogs With {
            .Created = Now()
            }

        Function get_SAP_Material_Update()
            Log.CreatedBy = User.Identity.Name
            Log.Description = ""
            Log.SyncScope = "Get SAP Materials"
            Log.SourceSystem = "SAP"
            Log.DestinationSystem = "OMD Traceability"
            Dim destination = OMDdb.Products
            Dim source = SAPdb.zTraceIn_SAPMaterials
            Log.Description = "Sync Materials from SAP | S: " & source.Count().ToString & " | D: " & source.Count().ToString
            For Each i In source
                Dim MatnrTrimmed = i.MATNR.TrimStart("0")
                Dim MaterialExist = OMDdb.Products.Where(Function(s) s.PLU = MatnrTrimmed And s.WERKS = i.WERKS).Count()
                Dim c As Product = Nothing
                If MaterialExist > 0 Then
                    c = OMDdb.Products.Single(Function(s) s.PLU = MatnrTrimmed And s.WERKS = i.WERKS)
                End If
                If IsNothing(c) Then
                    Dim p As New Product With {
                    .PLU = i.MATNR.TrimStart("0"),
                    .Description = i.MAKTX,
                    .ConsumerBarcode = i.GTIN_Level1,
                    .SalesUnitBarcode = i.GTIN_CON,
                    .GTin_Con = i.GTIN_CON,
                    .GTIN_HU = i.GTIN_HU,
                    .GTIN_Level1 = i.GTIN_Level1,
                    .GTIN_Level2 = i.GTIN_Level2,
                    .UOM = i.SAPUOM_Base,
                    .ProducedBy = OMDdb.Business_Units_Plants.Single(Function(f) f.PlantCode = i.WERKS).Description,
                    .Commodity = i.GTIN_CON,
                    .ConsumerUnits = i.HUQty_CON,
                    .SalesUnits = i.HUQty_Level1,
                    .HUTargetWeight = i.NetWt_HU,
                    .Labels = OMDdb.Software_Settings.Find("b2542cc5-0f9f-4495-93fa-78de561aa981").SettingValue,
                    .QCSampleSize = OMDdb.Software_Settings.Find("170cce7d-1cc4-44be-9023-5cc1de85c035").SettingValue,
                    .ExpiryDays = 365 * 3,
                    .Packaging = i.SAPUOM_Level1,
                    .Status = IIf(IsNothing(i.GTIN_CON) Or IsNothing(i.GTIN_HU) Or IsNothing(i.GTIN_Level1), "Failed", "Active"),
                    .TareWeight = i.TareWt_CON,
                    .Type = i.ProductType,
                    .TargetWeight = i.NetWt_CON,
                    .WERKS = i.WERKS,
                    .MATNR = i.MATNR
                    }
                    OMDdbBatches.Products.Add(p)
                    OMDdbBatches.SaveChanges()
                Else
                    Dim RecordChanged = False
                    Select Case True
                        Case c.Description <> i.MAKTX
                            RecordChanged = True
                        Case c.GTin_Con <> i.GTIN_CON
                            RecordChanged = True
                        Case c.GTIN_HU <> i.GTIN_HU
                            RecordChanged = True
                        Case c.GTIN_Level1 <> i.GTIN_Level1
                            RecordChanged = True
                        Case c.GTIN_Level2 <> i.GTIN_Level2
                            RecordChanged = True
                        Case c.Packaging <> i.SAPUOM_Level1
                            RecordChanged = True
                        Case c.UOM <> i.SAPUOM_Base
                            RecordChanged = True
                        Case c.ConsumerUnits <> i.HUQty_CON
                            RecordChanged = True
                        Case c.SalesUnits <> i.HUQty_Level1
                            RecordChanged = True
                        Case c.HUTargetWeight <> i.NetWt_HU
                            RecordChanged = True
                        Case c.TareWeight <> i.TareWt_CON
                            RecordChanged = True
                        Case c.Type <> i.ProductType
                            RecordChanged = True
                        Case c.TareWeight <> i.NetWt_CON
                            RecordChanged = True
                        Case c.WERKS <> i.WERKS
                            RecordChanged = True
                        Case c.MATNR <> i.MATNR
                            RecordChanged = True
                    End Select
                    If RecordChanged Then
                        With c
                            .PLU = i.MATNR.TrimStart("0")
                            .Description = i.MAKTX
                            .ConsumerBarcode = i.GTIN_Level1
                            .SalesUnitBarcode = i.GTIN_CON
                            .GTin_Con = i.GTIN_CON
                            .GTIN_HU = i.GTIN_HU
                            .GTIN_Level1 = i.GTIN_Level1
                            .GTIN_Level2 = i.GTIN_Level2
                            .UOM = i.SAPUOM_Base
                            .ProducedBy = OMDdb.Business_Units_Plants.Single(Function(f) f.PlantCode = i.WERKS).Description
                            .Commodity = i.GTIN_CON
                            .ConsumerUnits = i.HUQty_CON
                            .SalesUnits = i.HUQty_Level1
                            .HUTargetWeight = i.NetWt_HU
                            .Labels = OMDdb.Software_Settings.Find("b2542cc5-0f9f-4495-93fa-78de561aa981").SettingValue
                            .QCSampleSize = OMDdb.Software_Settings.Find("170cce7d-1cc4-44be-9023-5cc1de85c035").SettingValue
                            .ExpiryDays = 365 * 3
                            .Packaging = i.SAPUOM_Level1
                            .Status = IIf(IsNothing(i.GTIN_CON) Or IsNothing(i.GTIN_HU) Or IsNothing(i.GTIN_Level1), "Failed", "Active")
                            .TareWeight = i.TareWt_CON
                            .Type = i.ProductType
                            .TargetWeight = i.NetWt_CON
                            .WERKS = i.WERKS
                            .MATNR = i.MATNR
                        End With
                        OMDdb.Entry(c).State = EntityState.Modified
                        OMDdb.SaveChanges()
                    End If
                End If
            Next
            OMDdb.Integration_SyncLogs.Add(Log)
            OMDdb.SaveChanges()
            Return ("OK")
        End Function

        Function get_SAP_Material()
            Log.CreatedBy = User.Identity.Name
            Log.Description = ""
            Log.SyncScope = "Get SAP Materials"
            Log.SourceSystem = "SAP"
            Log.DestinationSystem = "OMD Traceability"
            Dim destination = OMDdb.Products
            Dim source = SAPdb.zTraceIn_SAPMaterials
            Log.Description = "Sync Materials from SAP | S: " & source.Count().ToString & " | D: " & source.Count().ToString
            For Each i In source.Where(Function(f) f.GTIN_CON IsNot Nothing And f.GTIN_HU IsNot Nothing And f.GTIN_Level1 IsNot Nothing)
                Dim c = OMDdb.Products.Single(Function(s) s.PLU = i.MATNR.TrimStart("0"))
                If IsNothing(c) Then
                    Dim p As New Product With {
                    .PLU = i.MATNR.TrimStart("0"),
                    .Description = i.MAKTX,
                    .ConsumerBarcode = i.GTIN_Level1,
                    .SalesUnitBarcode = i.GTIN_CON,
                    .UOM = i.SAPUOM_Base,
                    .ProducedBy = OMDdb.Business_Units_Plants.Single(Function(f) f.PlantCode = i.WERKS).Description,
                    .Commodity = i.GTIN_CON,
                    .ConsumerUnits = i.HUQty_CON,
                    .SalesUnits = i.HUQty_Level1,
                    .HUTargetWeight = i.NetWt_HU,
                    .Labels = OMDdb.Software_Settings.Find("b2542cc5-0f9f-4495-93fa-78de561aa981").SettingValue,
                    .QCSampleSize = OMDdb.Software_Settings.Find("170cce7d-1cc4-44be-9023-5cc1de85c035").SettingValue,
                    .ExpiryDays = 365 * 3,
                    .Packaging = i.SAPUOM_Level1,
                    .Status = IIf(IsNothing(i.GTIN_CON) Or IsNothing(i.GTIN_HU) Or IsNothing(i.GTIN_Level1), "Failed", "Active"),
                    .TareWeight = i.TareWt_CON,
                    .Type = i.ProductType,
                    .TargetWeight = i.NetWt_CON
                    }
                    OMDdbBatches.Products.Add(p)
                    OMDdbBatches.SaveChanges()
                End If
            Next
            OMDdb.Integration_SyncLogs.Add(Log)
            OMDdb.SaveChanges()
            Return ("OK")
        End Function
        Function get_SAP_Deliveries()
            Log.CreatedBy = User.Identity.Name
            Log.Description = ""
            Log.SyncScope = "Get Transaction From SAP"
            Log.SourceSystem = "SAP"
            Log.DestinationSystem = "OMD Traceability"
            Dim destination = OMDdb.Loadslips
            Dim source = SAPdb.SAPTransactions.OrderByDescending(Function(o) o.SrcRefDocNr).Where(Function(d) d.SrcMessageTime > "2023-03-14 00:00:00")
            Log.Description = "Sync Transaptions from SAP | S: " & source.Count().ToString & " | D: " & source.Count().ToString
            OMDdb.Integration_SyncLogs.Add(Log)
            OMDdb.SaveChanges()
            For Each i In source.Where(Function(v) v.SrcRefDocNr IsNot Nothing)
                Dim c = OMDdb.Loadslips.SingleOrDefault(Function(l) l.LoadReference.Trim = i.SrcRefDocNr.Trim)
                Dim fs = OMDdb.Loadslips.Where(Function(l) l.LoadReference.Trim = i.SrcRefDocNr.Trim)
                'Dim VSTEL = SAPdb.zTraceIn_SAPDeliveryHdrs.Where(Function(s) s.SrcRefDocNr = i.SrcRefDocNr)
                'If VSTEL.FirstOrDefault() IsNot Nothing Then
                Dim WERKS = OMDdb.Business_Units_Plants.Single(Function(f) f.PlantCode = 1110)
                If IsNothing(c) Then
                    Dim n As New Loadslip With {
                            .Created = Now(),
                            .CreatedBy = i.Src_IntegrationUser.Trim,
                            .Driver = "",
                            .Horse = "",
                            .Trailer = "",
                            .Notes = "Synced from SAP | " & Now.ToString,
                            .ToLocation = i.SrcDoc_KUNNR_NAME.Trim,
                            .LoadReference = i.SrcRefDocNr.Trim,
                            .Status = "Pending",
                            .FromLocation = "MISSINGINTEG",
                            .Type = "Delivery Note",
                            .PlantId = WERKS.Id,
                            .IsFullLoad = IIf(fs.Count > 1, False, True),
                            .IsSharedLoad = IIf(fs.Count > 1, True, False),
                            .Transporter = ""
                            }
                    OMDdbBatches.Loadslips.Add(n)
                    OMDdbBatches.SaveChanges()
                End If
            Next
            Return ("OK")
        End Function
        Function get_SAP_DeliveriesLines()
            Log.CreatedBy = User.Identity.Name
            Log.SyncScope = "Get Delivery Lines from SAP"
            Log.SourceSystem = "SAP"
            Log.DestinationSystem = "OMD Traceability"
            Dim source = SAPdb.zTraceIn_SAPDeliveryLines.Where(Function(a) a.MTART = "FERT")
            Dim destination = OMDdb.Loadslips_Details
            Log.Description = "Sync Delivery Lines from SAP | S: " & source.Count().ToString & " | D: " & source.Count().ToString
            OMDdb.Integration_SyncLogs.Add(Log)
            OMDdb.SaveChanges()
            For Each i In source
                Dim plu = i.MATNR.TrimStart("0")
                Dim product = OMDdb.Products.FirstOrDefault(Function(p) p.PLU = plu)
                Dim c = OMDdb.Loadslips_Details.Where(Function(p) p.LoadReference.Trim = i.SrcRefDocNr.Trim And p.ProductId = product.Id).ToList()
                'Dim VSTEL = SAPdb.zTraceIn_SAPDeliveryHdrs.Single(Function(s) s.SrcRefDocNr = i.SrcRefDocNr).VSTEL
                Dim WERKS = OMDdb.Business_Units_Plants.Single(Function(f) f.PlantCode = 1110)
                If c.Count = 0 Then
                    Dim lId = OMDdb.Loadslips.FirstOrDefault(Function(d) d.LoadReference = i.SrcRefDocNr)
                    Dim req = i.NTGEW / product.HUTargetWeight
                    Dim Current = 0
                    While Current < req
                        Current += 1
                        Dim n As New Loadslips_Details With {
                            .Loaded = Nothing,
                            .Status = "Pending Allocation",
                            .LoadReference = i.SrcRefDocNr.Trim,
                            .LoadId = lId.Id,
                            .ProductId = product.Id,
                            .SSCC = Nothing,
                            .Created = Now(),
                            .Postion = Current,
                            .TotalRequired = req,
                            .HUDescription = product.Description
                        }
                        OMDdbBatches.Loadslips_Details.Add(n)
                    End While
                    OMDdbBatches.SaveChanges()
                End If
            Next
            Return ("OK")
        End Function
        Function post_HandlingUnits()
            Log.Description = "Sync Handling Units"
            Log.SyncScope = "SSCC"
            Log.SourceSystem = "OMD Traceability"
            Log.DestinationSystem = "SAP"
            Dim source = OMDdb.Integration_SSCC
            Dim destination = SAPdb.zTraceOut_SSCCUnit
            Log.Description = "Sync Handling Units from OMD | S: " & source.Count().ToString & " | D: " & source.Count().ToString
            For Each hu In source
                Dim c = SAPdb.zTraceOut_SSCCUnit.Find(hu.Id)
                If IsNothing(c) Then
                    Dim n As New zTraceOut_SSCCUnit With {
                        .ActualWeight = hu.ActualWeight,
                        .Created = hu.Created,
                        .CreatedDate = hu.CreatedDate,
                        .CreatedBy = hu.CreatedBy,
                        .CreatedTime = hu.CreatedTime,
                        .Label_Country = hu.Label_Country,
                        .Id = hu.Id,
                        .Label_Description = hu.Label_Description,
                        .WERKS = hu.WERKS,
                        .Label_GTIN = hu.Label_GTIN,
                        .MATNR = hu.MATNR,
                        .PData_BatchCode = hu.PData_BatchCode,
                        .PData_BestBefore = hu.PData_BatchCode,
                        .PData_DateCode = hu.PData_DateCode,
                        .PData_DateTime = hu.PData_DateTime,
                        .PDet_ConsUnits = hu.PDet_ConsUnits,
                        .PDet_NetWt = hu.PDet_NetWt,
                        .PDet_OrdUnits = hu.PDet_OrdUnits,
                        .PDet_PCode = hu.PDet_PCode,
                        .ScannedGTIN = hu.ScannedGTIN,
                        .SSCC = hu.SSCC,
                        .Waypoint = hu.Waypoint,
                        .WaypointId = hu.WaypointId
                        }
                    SAPdb.zTraceOut_SSCCUnit.Add(n)
                    SAPdb.SaveChanges()
                Else
                    c.ActualWeight = hu.ActualWeight
                    c.Created = hu.Created
                    c.CreatedDate = hu.CreatedDate
                    c.CreatedBy = hu.CreatedBy
                    c.CreatedTime = hu.CreatedTime
                    c.Label_Country = hu.Label_Country
                    c.Id = hu.Id
                    c.Label_Description = hu.Label_Description
                    c.WERKS = hu.WERKS
                    c.Label_GTIN = hu.Label_GTIN
                    c.MATNR = hu.MATNR
                    c.PData_BatchCode = hu.PData_BatchCode
                    c.PData_BestBefore = hu.PData_BatchCode
                    c.PData_DateCode = hu.PData_DateCode
                    c.PData_DateTime = hu.PData_DateTime
                    c.PDet_ConsUnits = hu.PDet_ConsUnits
                    c.PDet_NetWt = hu.PDet_NetWt
                    c.PDet_OrdUnits = hu.PDet_OrdUnits
                    c.PDet_PCode = hu.PDet_PCode
                    c.ScannedGTIN = hu.ScannedGTIN
                    c.SSCC = hu.SSCC
                    c.Waypoint = hu.Waypoint
                    c.WaypointId = hu.WaypointId
                    SAPdb.Entry(c).State = EntityState.Modified
                    SAPdb.SaveChanges()
                End If
            Next
            OMDdb.Integration_SyncLogs.Add(Log)
            OMDdb.SaveChanges()
            Return ("OK")
        End Function
        Function post_HandlingUnits_Movements()
            Log.Description = "Sync Handling Unit Movements"
            Log.SyncScope = "SSCC"
            Log.SourceSystem = "OMD Traceability"
            Log.DestinationSystem = "SAP"
            Dim destination = SAPdb.zTraceOut_SSCCMovements
            Dim lastdestinationRecord = SAPdbBatches.zTraceOut_SSCCMovements.Max(Function(ma) ma.Id)
            Dim source = OMDdb.Handling_Units_Movements.Where(Function(dc) dc.Id > lastdestinationRecord)
            Log.Description = "Sync Movements from OMD | S: " & source.Count().ToString & " | D: " & source.Count().ToString
            Dim m = OMDdb.Handling_Units_Movements.Where(Function(s) s.Type = "PAS" Or s.Type = "CPC" Or s.Type = "GUS")
            For Each d In source
                Dim nm As New zTraceOut_SSCCMovements With {
                    .Id = d.Id,
                    .SSCC = d.Handling_Units.SSCC,
                    .MovementDesc = d.Type + " | " + d.Status,
                    .MovementDirection = "",
                    .NewStatus = "",
                    .OperatorID = d.CreatedBy,
                    .WaypointID = OMDdb.Waypoints.FirstOrDefault(Function(f) f.Description = d.Waypoint).Id,
                    .MovementTime = d.Created
                    }
                SAPdbBatches.zTraceOut_SSCCMovements.Add(nm)
                SAPdbBatches.SaveChanges()
            Next
            OMDdb.Integration_SyncLogs.Add(Log)
            OMDdb.SaveChanges()
            Return ("OK")
        End Function

    End Class
End Namespace