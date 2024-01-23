@ModelType Intranet.Waypoint
@Code
    ViewData("Title") = "Devices"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = Model.Type & " | " & Model.Description & " | " & Model.Status
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")

End Code
<div class="btn-toolbar">
    <div class="btn-group">
        @Html.ActionLink("View Device", "Details", "Devices", New With {.id = Model.Devices.First.Id}, New With {.class = "btn btn-default"})
        @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-default"})
        @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
    </div>
</div>
<dl class="dl-horizontal">
    <dt>
        @Html.DisplayNameFor(Function(model) model.UOM)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.UOM)
    </dd>

    <dt>
        @Html.DisplayNameFor(Function(model) model.LoadCapcity)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.LoadCapcity)
    </dd>
    <dt>
        @Html.DisplayNameFor(Function(model) model.HasPrinter)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.HasPrinter)
    </dd>
    <dt>
        @Html.DisplayNameFor(Function(model) model.HasScanner)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.HasScanner)
    </dd>
</dl>
<div class="splitgrid-container">
    <div class="leftcolum">
        <h2>
            Device Control
        </h2>
        <div>
            @Html.Action("Device_Control", "Devices", New With {.Id = Model.Devices.FirstOrDefault.Id, .IsPartial = True})
        </div>
    </div>
    <div class="rightcolum">
        
        <h2>
            Number Bank History
        </h2>
        <div>
            @Html.Action("Index", "Waypoints_NumberBanks", New With {.Id = Model.Id, .IsPartial = True, .FilterBy = "Waypoint", .IsJson = False})
        </div>
        <h2>
            Handling Unit Movements
        </h2>
        <div>
            @Html.Action("Index", "Handling_Units_Movements", New With {.Id = Model.Devices.FirstOrDefault.Id, .FilterBy = "Device", .IsPartial = True})
        </div>
    </div>
</div>

