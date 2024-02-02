<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title</title>
    <script src="https://kit.fontawesome.com/679062be7c.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="~/Content/Sitev2.css">
    <script src="https://cdn.tiny.cloud/1/s25uxpc05oca1wcsqix1e5ipt85urutblb6kqpbxa050eypb/tinymce/5/tinymce.min.js" referrerpolicy="origin"></script>
    <script>
        tinymce.init({
            selector: 'textarea'
        });
    </script>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>

<body>
    <h1>
        @ViewBag.ViewTitle
    </h1>
    <div class="layout">
        <div class="Menu-Main">
            <div class="Menu-Item grow" data-bs-toggle="collapse" data-bs-target="#Home" onclick="location.href = '@Url.Action("Index", "Home")'">
                <i class="fa fa-5 fa-home"></i> Home
            </div>
            <div class="Menu-Item grow" data-bs-toggle="collapse" data-bs-target="#mnReporting">
                <i class="fa-solid fa-print"></i> Reporting
            </div>
            <div class="collapse" id="mnReporting">
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "ShiftForemansReports")'">
                    <i class="fa-solid fa-people-roof"></i> Foremans Report
                </div>
                <div class="Menu-Item-Sub grow">
                    <i class="fa-solid fa-down-left-and-up-right-to-center"></i> Over\Under Report
                </div>
            </div>
            <div class="Menu-Item grow" data-bs-toggle="collapse" data-bs-target="#mnBatches">
                <i class="fa-solid fa-business-time"></i> Batches
            </div>
            <div class="collapse" id="mnBatches">
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Production_Batches", New With {.FilterBy = "CR"})'">
                    <i class="fa-solid fa-boxes-stacked"></i> Active Batches
                </div>
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Production_Batches")'">
                    <i class="fa-solid fa-magnifying-glass"></i> Search
                </div>
            </div>
            <div class="Menu-Item grow" data-bs-toggle="collapse" data-bs-target="#mnTraceability">
                <i class="fa-solid fa-magnifying-glass-location"></i> Traceability
            </div>
            <div class="collapse" id="mnTraceability">
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Devices_Operators")'">
                    <i class="fa-solid fa-users-viewfinder"></i> Operators
                </div>
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Handling_Units", New With {.Size = 25})'">
                    <i class="fa-solid fa-boxes-stacked"></i> Handling Units
                </div>
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Waypoints")'">
                    <i class="fa-solid fa-arrow-down-up-across-line"></i> Waypoints
                </div>
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Production_Batches")'">
                    <i class="fa-solid fa-magnifying-glass"></i> Search
                </div>
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Loadslips")'">
                    <i class="fa-solid fa-truck-arrow-right"></i> Outbound Logitics
                </div>
                @If User.IsInRole("Admin") Or User.IsInRole("Traceability Administrator") Then
                    @<div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Waypoints_NumberBanks")'">
                        <i class="fa-solid fa-arrow-up-1-9"></i> Number Ranges
                    </div>
                End If
            </div>
            <div Class="Menu-Item grow" data-bs-toggle="collapse" data-bs-target="#mnMaterial">
                <i class="fa-solid fa-boxes-packing"></i> Material
            </div>
            <div class="collapse" id="mnMaterial">
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Create", "Stocks")'">
                    New Stock Item
                </div>
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Create", "Stock_Movements")'">
                    <i class="fa-solid fa-parachute-box"></i>Request Stock
                </div>
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Stock_Movements")'">
                    <i class="fa-solid fa-dolly"></i> Receive Stock
                </div>
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Stocks")'">
                    <i class="fa-solid fa-square-check"></i> Flags and Levels
                </div>
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Stocks")'">
                    <i class="fa-solid fa-boxes-stacked"></i> Stock Items
                </div>
            </div>
            <div Class="Menu-Item grow" onclick="location.href = '@Url.Action("Index", "Products")'">
                <i class="fa-brands fa-product-hunt"></i> Products
            </div>

            <div Class="Menu-Item grow" data-bs-toggle="collapse" data-bs-target="#mnScales">
                <i class="fa-solid fa-weight-scale"></i> Scales
            </div>
            <div class="collapse" id="mnScales">
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "QC_Scales_Stations")'">
                    Scale Stations
                </div>
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "QC_Scales")'">
                    Scale Devices
                </div>
                <div class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "QC_Scales_Readings")'">
                    Scale Readings
                </div>
            </div>
            <div Class="Menu-Item grow" data-bs-toggle="collapse" data-bs-target="#mnSystem">
                <i Class="fa fa-5 fa-gear"></i> System
            </div>
            <div Class="collapse" id="mnSystem">
                <div Class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Software_Dropdowns")'">
                    <i Class="fa fa-5 fa-list"></i> Dropdowns
                </div>
                <div Class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Business_Units")'">
                    <i Class="fa fa-5 fa-home"></i> Business Units
                </div>
                <div Class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Integration_SyncLogs")'">
                    <i Class="fa fa-5 fa-arrows"></i> Integration
                </div>
                <div Class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Devices")'">
                    <i Class="fa fa-5 fa-tablet"></i> Devices
                </div>
                <div Class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Waypoints_Configurations")'">
                    <i Class="fa fa-5 fa-tablet"></i> Waypoint Configurations
                </div>
                <div Class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Software_Packages")'">
                    <i Class="fa fa-5 fa-software"></i> Client Software
                </div>
                <div Class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Software_Settings")'">
                    <i Class="fa fa-5 fa-software"></i> Software Settings
                </div>
                <div Class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Software_Services")'">
                    <i Class="fa fa-5 fa-software"></i> Software Services
                </div>
                <div Class="Menu-Item-Sub grow" onclick="location.href = '@Url.Action("Index", "Plants_Shifts")'">
                    <i Class="fa fa-5 fa-clock"></i> Shift Management
                </div>
            </div>
        </div>
        <div Class="renderedBody">
            @If ViewBag.pageMsg <> "" Or IsNothing(ViewBag.pageMsg) = False Then
                @<div class="Top-Message-Box" style="background-color:@ViewBag.MsgBgColor; color:@ViewBag.pageMsgColor">
                    @ViewBag.pageMsg
                </div>
            End If
            @RenderBody()
        </div>
    </div>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
